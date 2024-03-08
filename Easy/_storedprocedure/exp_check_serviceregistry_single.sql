
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_serviceregistry_single]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_check_serviceregistry_single]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE         PROCEDURE exp_check_serviceregistry_single (		
	@ayear int
) AS
BEGIN
/*
Creare una sp di check per gli incarichi dell'Anagrafe delle prestazioni, che estragga gli incarichi conferiti a Dipendenti (ossia i "serviceregistry" con "employkind = D " ), ove :
	> l'anagrafica ha valorizzato l'indirizzo Anagrafe delle prestazioni (07_SW_ANP)
	> aventi nel compenso oggetto del pagamento "non necessita di autorizzazione" o "Autorizzazione non applicabile" 
*/

DECLARE @code_ANP varchar(20)
SET @code_ANP = '07_SW_ANP'

DECLARE @id_ANP int
SELECT @id_ANP = idaddress FROM address WHERE codeaddress = @code_ANP

CREATE TABLE #DIPENDENTI(
	nservreg	int,
	yservreg	int,
	title		varchar(150),
	kind		varchar(50),
	ncon		int,
	ycon		int
)

/*
casualcontract :	cascon + ycon + ncon
wageaddition :		wageadd + ycon + ncon
itineration :		itineration + yitineration + nitineration
profservice :		profservice + ycon + ncon
*/

-- CasualContract
INSERT INTO #DIPENDENTI(nservreg,	yservreg, title, kind, ncon, ycon)
SELECT S.nservreg, S.yservreg, S.title, 'Autonomi Occasionali', C.ncon, C.ycon
FROM serviceregistry S
JOIN registryaddress R
	ON S.idreg = R.idreg 
JOIN casualcontract C
	ON C.ycon = substring(S.idrelated,8,4) AND C.ncon = substring(S.idrelated,13,len(S.idrelated)-12)
WHERE S.yservreg = @ayear
	AND S.employkind = 'D'
	AND R.idaddresskind = @id_ANP
	AND R.start<= C.start 
	AND ((R.stop IS NULL)OR(R.stop>=C.stop))
	AND substring(S.idrelated,1,6)='cascon' 
	AND C.authneeded in ('N','X') -- N = Non applicabile, X = Non necessaria

-- Wageaddition
INSERT INTO #DIPENDENTI(nservreg,	yservreg, title, kind, ncon, ycon)
SELECT S.nservreg, S.yservreg, S.title, 'Altri Compensi',C.ncon, C.ycon
FROM serviceregistry S
JOIN registryaddress R
	ON S.idreg = R.idreg 
JOIN wageaddition C
	ON C.ycon = substring(S.idrelated,9,4) AND C.ncon = substring(S.idrelated,14,len(S.idrelated)-13)
WHERE S.yservreg = @ayear
	AND S.employkind = 'D'
	AND R.idaddresskind = @id_ANP
	AND R.start<= C.start 
	AND ((R.stop IS NULL)OR(R.stop>=C.stop))
	AND substring(S.idrelated,1,7)='wageadd' 
	AND C.authneeded in ('N','X') -- N = Non applicabile, X = Non necessaria

-- itineration
INSERT INTO #DIPENDENTI(nservreg,	yservreg, title, kind, ncon, ycon)
SELECT S.nservreg, S.yservreg, S.title, 'Missioni',C.nitineration, C.yitineration
FROM serviceregistry S
JOIN registryaddress R
	ON S.idreg = R.idreg 
JOIN itineration C
	ON C.yitineration = substring(S.idrelated,13,4) AND C.nitineration = substring(S.idrelated,18,len(S.idrelated)-17)
WHERE S.yservreg = @ayear
	AND S.employkind = 'D'
	AND R.idaddresskind = @id_ANP
	AND R.start<= C.start 
	AND ((R.stop IS NULL)OR(R.stop>=C.stop))
	AND substring(S.idrelated,1,11)='itineration' 
	AND C.authneeded in ('N','X') -- N = Non applicabile, X = Non necessaria

-- profservice
INSERT INTO #DIPENDENTI(nservreg,	yservreg, title, kind, ncon, ycon)
SELECT S.nservreg, S.yservreg, S.title, 'Autonomi Professionali',C.ncon, C.ycon
FROM serviceregistry S
JOIN registryaddress R
	ON S.idreg = R.idreg 
JOIN profservice C
	ON C.ycon = substring(S.idrelated,13,4) AND C.ncon = substring(S.idrelated,18,len(S.idrelated)-17)
WHERE S.yservreg = @ayear
	AND S.employkind = 'D'
	AND R.idaddresskind = @id_ANP
	AND R.start<= C.start 
	AND ((R.stop IS NULL)OR(R.stop>=C.stop))
	AND substring(S.idrelated,1,11)='profservice' 
	AND C.authneeded in ('N','X') -- N = Non applicabile, X = Non necessaria

DECLARE @departmentname varchar(500)
SET  @departmentname  = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento'  
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'Manca Cfg. Parametri Tutte le stampe')

SELECT 
	@departmentname as 'Dipartimento',
	title as 'Anagrafica',
	nservreg as 'Nun.Incarico',
	yservreg as 'Eserc.Incarico',
	kind as 'Compenso',
	ncon as 'Nun.Compenso',
	ycon as 'Eserc.Compenso'
FROM #DIPENDENTI
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
