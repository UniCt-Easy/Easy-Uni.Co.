
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_flowchartcopy_copymissingrow]') 
and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_flowchartcopy_copymissingrow]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec closeyear_flowchartcopy_copymissingrow 2023, 2024

CREATE  PROCEDURE [closeyear_flowchartcopy_copymissingrow]
(
	@startayear int,
	@stopayear  int
	
)
AS BEGIN
CREATE TABLE #log (messaggio varchar(255))

IF (ISNULL(@stopayear,0) = 0)
	SET @stopayear = @startayear + 1

DECLARE @startayearstr varchar(4)
SET @startayearstr = CONVERT(varchar(4),@startayear)

DECLARE @stopayearstr varchar(4)
SET @stopayearstr = CONVERT(varchar(4),@stopayear)

-- controllo che esista la riga in accountingyear relativa all'esercizio finale
IF NOT EXISTS (SELECT * FROM accountingyear WHERE ayear = @stopayear) RETURN 

-- se non sono sttai trasferiti i livelli, esce.
IF NOT EXISTS (SELECT * FROM flowchartlevel WHERE ayear = @stopayear) return


-- Trasferisce solo le voci dell'organigramma mancanti 

INSERT INTO flowchart
		(
			idflowchart,
			ayear, codeflowchart,
			nlevel, paridflowchart, printingorder, title, 
			fax, phone, address, idcity, cap, location,idsor1,idsor2,idsor3,
			cu, ct, lu, lt
		)
	SELECT
		SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
		@stopayear, codeflowchart, nlevel,
		SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(paridflowchart, 3, 32),
		printingorder, title,
		fax, phone, address, idcity, cap, location,idsor1,idsor2,idsor3,
		cu, GETDATE(), lu, GETDATE()
	FROM flowchart
	WHERE ayear = @startayear
	and 
	SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
				not in (select f2.idflowchart from flowchart f2
						where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchart.idflowchart,3, 32)
						)

-- Trasferisce gli utenti dell'organigramma annuale nel nuovo esercizio
	INSERT INTO flowchartuser
		(
			idflowchart,
			ndetail,
			idcustomuser,
			start,
			stop,
			cu, ct, lu, lt,
			flagdefault,
			idsor01,
			idsor02,
			idsor03,
			idsor04,
			idsor05,
			title,
			all_sorkind01,
			all_sorkind02,
			all_sorkind03,
			all_sorkind04,
			all_sorkind05,
			sorkind01_withchilds,
			sorkind02_withchilds,
			sorkind03_withchilds,
			sorkind04_withchilds,
			sorkind05_withchilds
		)
	SELECT
			SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
			ndetail, idcustomuser,
			start, stop,
			cu, GETDATE(), lu, GETDATE(),
			flagdefault,
			idsor01,
			idsor02,
			idsor03,
			idsor04,
			idsor05,
			title,
			all_sorkind01,
			all_sorkind02,
			all_sorkind03,
			all_sorkind04,
			all_sorkind05,
			sorkind01_withchilds,
			sorkind02_withchilds,
			sorkind03_withchilds,
			sorkind04_withchilds,
			sorkind05_withchilds
			FROM flowchartuser
			WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
			and SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) not in 
						(	SELECT f2.idflowchart 
							FROM flowchartuser f2 
								WHERE f2.idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%'
								and f2.idcustomuser = flowchartuser.idcustomuser)

--- Trasferisce configurazioni sicurezza stampe nel nuovo esercizio
	INSERT INTO flowchartexportmodule
		(
			idflowchart,
			modulename,
			lu,
			lt
		)
	SELECT
			SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
			modulename,
			lu, GETDATE()
			FROM flowchartexportmodule
			WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
				and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
						not in (select f2.idflowchart from flowchartexportmodule f2
						where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartexportmodule.idflowchart,3, 32)
						and f2.modulename = flowchartexportmodule.modulename
						)

--Trasferisce responsabili organigramma nel nuovo esercizio
	INSERT INTO flowchartmanager
		(
			idflowchart,
			idman,
			cu, ct, lu, lt
		)
	SELECT
		SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
		idman,
		cu, GETDATE(), lu, GETDATE()
	FROM flowchartmanager
	WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
	and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
			not in (select f2.idflowchart from flowchartmanager  f2
			where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartmanager.idflowchart,3, 32)
			and f2.idman = flowchartmanager.idman
			)

	

-- Trasferisce configurazione sicurezza stampe nel nuovo esercizio 
	INSERT INTO flowchartmodulegroup
		(
			idflowchart,
			modulename,
			groupname,
			lu,
			lt

		)
	SELECT
			SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
			modulename,
			groupname,
			lu, GETDATE()
			FROM flowchartmodulegroup
			WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
			and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
					not in (select f2.idflowchart from flowchartmodulegroup  f2
					where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartmodulegroup.idflowchart,3, 32)
					and f2.modulename = flowchartmodulegroup.modulename
					and f2.groupname = flowchartmodulegroup.groupname
					)

--	 restrizioni sicurezza esportazioni nel nuovo esercizio 
	INSERT INTO flowchartrestrictedfunction
		(
			idflowchart,
			idrestrictedfunction,
			ct,cu,lt,lu
		)
	SELECT
			SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
			idrestrictedfunction,
			GETDATE(), cu, GETDATE(), lu
			FROM flowchartrestrictedfunction
			WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
			and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
					not in (select f2.idflowchart from flowchartrestrictedfunction  f2
					where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartrestrictedfunction.idflowchart,3, 32)
					and f2.idrestrictedfunction = flowchartrestrictedfunction.idrestrictedfunction
					)

-- classificazione organigramma nel nuovo esercizio
	INSERT INTO flowchartsorting
		(
			idflowchart,
			quota,
			idsor,
			ct,cu,lt,lu
		)
	SELECT
			SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
			quota,
			idsor,
			GETDATE(), cu, GETDATE(), lu
			FROM flowchartsorting
			WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
			and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
					not in (select f2.idflowchart from flowchartsorting  f2
					where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartsorting.idflowchart,3, 32)
					and f2.idsor = flowchartsorting.idsor
					)

	-- associazione UPB organigramma nel nuovo esercizio 
	INSERT INTO flowchartupb
		(
			idflowchart,
			idupb,
			ct,cu,lt,lu
		)
	SELECT
		SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
		idupb,
		GETDATE(), cu, GETDATE(), lu
		FROM flowchartupb
		WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
			and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
			not in (select f2.idflowchart from flowchartupb  f2
			where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartupb.idflowchart,3, 32)
			and f2.idupb = flowchartupb.idupb
			)

--associazione tipi contratto passivo organigramma nel nuovo esercizio 
	INSERT INTO flowchartmandatekind
		(
			idflowchart,
			idmankind,
			cu, ct, lu, lt
		)
	SELECT
		SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
		idmankind,
		cu, GETDATE(), lu, GETDATE()
	FROM flowchartmandatekind
	WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
		and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
		not in (select f2.idflowchart from flowchartmandatekind  f2
		where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartmandatekind.idflowchart,3, 32)
		and f2.idmankind = flowchartmandatekind.idmankind
		)
	
-- associazione tipi contratto attivo organigramma nel nuovo esercizio 
	INSERT INTO flowchartestimatekind
		(
			idflowchart,
			idestimkind,
			cu, ct, lu, lt
		)
	SELECT
		SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
		idestimkind,
		cu, GETDATE(), lu, GETDATE()
	FROM flowchartestimatekind
	WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
		and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
		not in (select f2.idflowchart from flowchartestimatekind  f2
		where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartestimatekind.idflowchart,3, 32)
		and f2.idestimkind = flowchartestimatekind.idestimkind
		)

-- associazione documenti IVA organigramma nel nuovo esercizio 
	INSERT INTO flowchartinvoicekind
		(
			idflowchart,
			idinvkind,
			cu, ct, lu, lt
		)
	SELECT
		SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
		idinvkind,
		cu, GETDATE(), lu, GETDATE()
	FROM flowchartinvoicekind
	WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
	and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
		not in (select f2.idflowchart from flowchartinvoicekind  f2
		where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartinvoicekind.idflowchart,3, 32)
		and f2.idinvkind = flowchartinvoicekind.idinvkind
		)

-- associazione fondi economali organigramma nel nuovo esercizio 
	INSERT INTO flowchartpettycash
		(
			idflowchart,
			idpettycash,
			cu, ct, lu, lt
		)
	SELECT
		SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
		idpettycash,
		cu, GETDATE(), lu, GETDATE()
	FROM flowchartpettycash
	WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
		and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
		not in (select f2.idflowchart from flowchartpettycash  f2
		where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartpettycash.idflowchart,3, 32)
		and f2.idpettycash = flowchartpettycash.idpettycash
		)

-- associazione Agenti autorizzatori Missioni organigramma nel nuovo esercizio 
	INSERT INTO flowchartauthagency
		(
			idflowchart,
			idauthagency,
			lu, lt
		)
	SELECT
		SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
		idauthagency,
		lu, GETDATE()
	FROM flowchartauthagency
	WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
	and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
		not in (select f2.idflowchart from flowchartauthagency  f2
		where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartauthagency.idflowchart,3, 32)
		and f2.idauthagency = flowchartauthagency.idauthagency
		)
	
-- associazione Modelli autorizzativi Missioni organigramma nel nuovo esercizio 
	INSERT INTO flowchartauthmodel
		(
			idflowchart,
			idauthmodel,
			cu, ct, lu, lt
		)
	SELECT
		SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
		idauthmodel,
		cu, GETDATE(), lu, GETDATE()
	FROM flowchartauthmodel
	WHERE idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
		and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
		not in (select f2.idflowchart from flowchartauthmodel  f2
		where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartauthmodel.idflowchart,3, 32)
		and f2.idauthmodel = flowchartauthmodel.idauthmodel
		)




----------------------------------------------------------------------------------
----------------- FLOWCHARTFIN DOPO IL TRASFERIMENTO DEL BILANCIO-----------------
----------------------------------------------------------------------------------
--  configurazione sicurezza Bilancio nel nuovo esercizio 
	IF (
		EXISTS (SELECT * 
			  FROM finlookup 
			  JOIN fin ON finlookup.oldidfin = fin.idfin
			 WHERE fin. ayear = @startayear)
		)
	BEGIN
		INSERT INTO flowchartfin
			(
				idflowchart,
				idfin,
				ct,cu,lt,lu
			)
		SELECT
			SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
			FL.newidfin,
			GETDATE(), flowchartfin.cu, GETDATE(), flowchartfin.lu
			FROM flowchartfin
			JOIN fin F on flowchartfin.idfin=F.idfin
			JOIN finlookup FL ON flowchartfin.idfin = FL.oldidfin
			WHERE F.ayear=@startayear 
			AND idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
	
			and  SUBSTRING(@stopayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32) 
				not in (select f2.idflowchart from flowchartfin  f2
				where f2.idflowchart = SUBSTRING(@stopayearstr, 3, 2)+ substring(flowchartfin.idflowchart,3, 32)
				and f2.idfin = FL.newidfin
				)
	END


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

