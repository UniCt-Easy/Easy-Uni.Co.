if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_flowchartcopy]') 
and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_flowchartcopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE  PROCEDURE [closeyear_flowchartcopy]
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

--IF (ISNULL(@startayear,0) >= ISNULL(@stopayear,0)) RETURN 

IF NOT EXISTS (SELECT * FROM flowchartlevel WHERE ayear = @stopayear)
BEGIN
	INSERT INTO flowchartlevel
		(
			ayear, nlevel, description, flagusable,
			cu, ct, lu, lt
		)
	SELECT
		@stopayear, nlevel, description,flagusable,
		cu, GETDATE(), lu, GETDATE()
	FROM flowchartlevel
	WHERE ayear = @startayear
	
	INSERT INTO #log
	VALUES('Trasferiti livelli organigramma annuale per esercizio ' + @stopayearstr)
END



IF NOT EXISTS (SELECT * FROM flowchart WHERE ayear = @stopayear)
BEGIN
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

	INSERT INTO #log
	VALUES('Trasferite voci dell''organigramma annuale per esercizio ' + @stopayearstr)
END
	
  
IF NOT EXISTS (SELECT * FROM flowchartuser WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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

		INSERT INTO #log
		VALUES('Trasferiti utenti dell''organigramma annuale nel nuovo esercizio ' + @stopayearstr)
END

/*
sp_help flowchartexportmodule fatto
sp_help flowchartfin dopo il trasferimento del bilancio
sp_help flowchartmanager fatto 
sp_help flowchartmodulegroup
sp_help flowchartrestrictedfunction
sp_help flowchartsorting
sp_help flowchartupb  
sp_help flowchartauthagency
sp_help flowchartauthmodel
sp_help journal
*/


IF NOT EXISTS (SELECT * FROM flowchartexportmodule WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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

		INSERT INTO #log
		VALUES('Trasferite configurazioni sicurezza stampe nel nuovo esercizio ' + @stopayearstr)
END

IF NOT EXISTS (SELECT * FROM flowchartmanager WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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

	INSERT INTO #log
	VALUES('Trasferiti responsabili organigramma nel nuovo esercizio ' + @stopayearstr)
END

IF NOT EXISTS (SELECT * FROM flowchartmodulegroup WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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
		INSERT INTO #log
		VALUES('Trasferita configurazione sicurezza stampe nel nuovo esercizio ' + @stopayearstr)
END


IF NOT EXISTS (SELECT * FROM flowchartrestrictedfunction WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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
	INSERT INTO #log
	VALUES('Trasferita restrizioni sicurezza esportazioni nel nuovo esercizio ' + @stopayearstr)
END

IF NOT EXISTS (SELECT * FROM flowchartsorting WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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
	INSERT INTO #log
	VALUES('Trasferita classificazione organigramma nel nuovo esercizio ' + @stopayearstr)
END

IF NOT EXISTS (SELECT * FROM flowchartupb WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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
	INSERT INTO #log
	VALUES('Trasferita associazione UPB organigramma nel nuovo esercizio ' + @stopayearstr)
END


IF NOT EXISTS (SELECT * FROM flowchartmandatekind WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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

	INSERT INTO #log
	VALUES('Trasferita associazione tipi contratto passivo organigramma nel nuovo esercizio ' + @stopayearstr)
END


IF NOT EXISTS (SELECT * FROM flowchartestimatekind WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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

	INSERT INTO #log
	VALUES('Trasferiti associazione tipi contratto attivo organigramma nel nuovo esercizio ' + @stopayearstr)
END


IF NOT EXISTS (SELECT * FROM flowchartinvoicekind WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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

	INSERT INTO #log
	VALUES('Trasferita associazione documenti IVA organigramma nel nuovo esercizio ' + @stopayearstr)
END

IF NOT EXISTS (SELECT * FROM flowchartpettycash WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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

	INSERT INTO #log
	VALUES('Trasferita associazione fondi economali organigramma nel nuovo esercizio ' + @stopayearstr)
END

IF NOT EXISTS (SELECT * FROM flowchartauthagency WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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

	INSERT INTO #log
	VALUES('Trasferita associazione Agenti autorizzatori Missioni organigramma nel nuovo esercizio ' + @stopayearstr)
END


IF NOT EXISTS (SELECT * FROM flowchartauthmodel WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
BEGIN
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

	INSERT INTO #log
	VALUES('Trasferita associazione Modelli autorizzativi Missioni organigramma nel nuovo esercizio ' + @stopayearstr)
END

----------------------------------------------------------------------------------
----------------- FLOWCHARTFIN DOPO IL TRASFERIMENTO DEL BILANCIO-----------------
----------------------------------------------------------------------------------
IF (
    EXISTS (SELECT * 
	      FROM finlookup 
	      JOIN fin ON finlookup.oldidfin = fin.idfin
	     WHERE fin. ayear = @startayear)
    AND 
    NOT EXISTS (SELECT * 
		  FROM flowchartfin 
	         WHERE idflowchart like SUBSTRING(@stopayearstr, 3, 2) + '%')
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
	INSERT INTO #log
	VALUES('Trasferita configurazione sicurezza Bilancio nel nuovo esercizio ' + @stopayearstr)
END


SELECT * FROM #log
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

