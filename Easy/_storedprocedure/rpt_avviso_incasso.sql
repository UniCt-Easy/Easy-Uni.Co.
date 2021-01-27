
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_avviso_incasso]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_avviso_incasso]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--	exec rpt_avviso_incasso 2013, 9, 9,null,7
CREATE   PROCEDURE [rpt_avviso_incasso]
(
	@ayear smallint, 
	@nprobegin int, 
	@nproend int,
	@idregproceeds int,
	@idtreasurer int
)
AS BEGIN

CREATE TABLE #advice
(
	ymov int,
	nmov int,
	ypro int,
	npro int,
	idreg int,
	idman int,
	idtreasurer int,
	amount decimal(19,2),
	data datetime,
	description varchar(255)
)


CREATE TABLE #address
(
	idman int,
	manager varchar(150),
	division  varchar(150),
	iddivision int,
	phonenumber varchar(30),
	email varchar(200)
)

IF @ayear = 0
BEGIN
	SET @ayear='1900'
END


INSERT INTO #advice
(
	ymov,
	nmov,
	ypro,
	npro,
	idreg,
	idman,
	idtreasurer,
	amount,
	data,
	description
)
SELECT
	income.ymov,
	income.nmov,
	income.ymov,
	proceeds.npro,
	income.idreg,
	income.idman,
	proceeds.idtreasurer,
	incometotal.curramount,
	proceeds.printdate,
	income.description
FROM income
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN incometotal
	ON incometotal.idinc = income.idinc
	AND incometotal.ayear = @ayear
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro
JOIN registry
	ON registry.idreg = income.idreg
WHERE income.ymov = @ayear AND
		( 	( proceeds.npro BETWEEN @nprobegin AND @nproend  AND (registry.idreg = @idregproceeds OR @idregproceeds IS NULL)  )
				OR 
			(registry.idreg = @idregproceeds AND @nprobegin is null AND @nproend is NULL)
  	 )
	AND proceeds.idtreasurer = @idtreasurer


--sp_help division

INSERT INTO #address
(
	idman,
	manager,
	iddivision,
	division,
	phonenumber,
	email
)
SELECT
	idman,
	title, 
	manager.iddivision, 
	description,
	manager.phonenumber,
	manager.email
FROM manager
LEFT OUTER JOIN division
	ON manager.iddivision = division.iddivision
WHERE (idman IN (select idman from #advice))

SELECT
	A.ymov, 
	A.nmov, 
	A.ypro, 
	A.npro, 
	A.description,
	A.idreg,
	R.title,
	ADS.manager, 
	ADS.division, 
	ADS.phonenumber,
	ADS.email,  
	A.amount,
	treasurerbank.description AS treasurerbank,
	treasurercab.description AS treasurercab,
	treasurer.address AS treasureraddress,
	treasurer.cap AS treasurercap,
	treasurer.city AS treasurercity,
	treasurer.country AS treasurercountry,
	treasurer.cc AS treasurercc,
	treasurer.header,
	A.data
FROM #advice A
JOIN registry R
	ON R.idreg = A.idreg
LEFT OUTER JOIN #address ADS
	ON ADS.idman = A.idman
LEFT OUTER JOIN treasurer
	ON treasurer.idtreasurer = A.idtreasurer
LEFT OUTER JOIN bank treasurerbank
	ON treasurerbank.idbank = treasurer.idbank
LEFT OUTER JOIN cab treasurercab
	ON treasurercab.idbank = treasurer.idbank
	AND treasurercab.idcab = treasurer.idcab
ORDER BY ADS.manager, A.npro ASC, R.title ASC
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

