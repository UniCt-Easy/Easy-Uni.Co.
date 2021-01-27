
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_prospetto_calcolo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_prospetto_calcolo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE   PROCEDURE  rpt_missione_prospetto_calcolo
	@ayear smallint, 
	@yitineration smallint, 
	@numberbegin int,
	@numberend int
AS
BEGIN

CREATE TABLE #rls
(
	idreg int,
	idposition varchar(20),
	incomeclass int,
	yitineration smallint,
	nitineration int,
	foreigngroupnumber smallint,
	start datetime,
	idwor varchar(20)
)

INSERT INTO #rls (idreg, idposition, incomeclass, yitineration, nitineration, start, idwor)
SELECT RLS.idreg, RLS.idposition, RLS.incomeclass, I.yitineration, I.nitineration, I.start, RLS.idwor
FROM registrylegalstatus RLS
JOIN itineration I
	ON I.idreg = RLS.idreg
WHERE I.yitineration = @yitineration
	AND I.nitineration BETWEEN @numberbegin AND @numberend
AND RLS.start =
	(SELECT MAX(RLS2.start)
	FROM registrylegalstatus RLS2
	JOIN itineration I2
		ON I2.idreg = RLS2.idreg
	WHERE I2.idreg = RLS2.idreg
		AND RLS2.start <= I2.start
		AND I.yitineration = I2.yitineration
		AND I.nitineration = I2.nitineration)

UPDATE #rls
SET foreigngroupnumber =
(SELECT DET.foreigngroupnumber
FROM foreigngroupruledetail DET
JOIN foreigngrouprule F
	ON F.idforeigngrouprule = DET.idforeigngrouprule
WHERE DET.idposition = #rls.idposition
	AND #rls.incomeclass BETWEEN DET.minincomeclass AND DET.maxincomeclass
	AND F.start =
		(SELECT MAX(F2.start)
		FROM foreigngrouprule F2
		JOIN foreigngroupruledetail DET2
			ON F.idforeigngrouprule = DET.idforeigngrouprule
		WHERE DET2.idposition = #rls.idposition
			AND #rls.incomeclass BETWEEN DET.minincomeclass AND DET.maxincomeclass
			AND start <= #rls.start)
)

SELECT 
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	registry.title as registry,
	registry.extmatricula AS matricula,
	service.description as service,
	itineration.authorizationdate,
	itineration.start,
	itineration.stop,
	itineration.adate,
	position.description as position,
	#rls.incomeclass AS currentclass,
	#rls.foreigngroupnumber,
	workcontract.description as workcontract
FROM itineration
JOIN registry
	ON registry.idreg = itineration.idreg
JOIN #rls
	ON itineration.yitineration = #rls.yitineration
	AND itineration.nitineration = #rls.nitineration
JOIN position
	ON position.idposition = #rls.idposition
JOIN service
	ON service.idser = itineration.idser
LEFT OUTER JOIN workcontract
	ON workcontract.idwor = #rls.idwor
WHERE itineration.yitineration = @yitineration   
	AND itineration.nitineration BETWEEN @numberbegin AND @numberend
ORDER BY itineration.nitineration ASC
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

