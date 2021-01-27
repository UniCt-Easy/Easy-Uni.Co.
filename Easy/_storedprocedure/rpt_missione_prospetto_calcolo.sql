
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_prospetto_calcolo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_prospetto_calcolo]
GO

-- setuser 'amministrazione'
-- rpt_missione_prospetto_calcolo 2018,2018,194,194
CREATE  PROCEDURE  rpt_missione_prospetto_calcolo
	@ayear smallint, 
	@yitineration smallint, 
	@numberbegin int,
	@numberend int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
BEGIN

CREATE TABLE #rls
(
	idreg int,
	idposition int,
	incomeclass int,
	yitineration smallint,
	nitineration int,
	foreigngroupnumber smallint,
	iditineration int,
	start datetime
)

INSERT INTO #rls (idreg, idposition, incomeclass, yitineration, nitineration,iditineration, start)
SELECT RLS.idreg, RLS.idposition, isnull(RLS.incomeclass,0), I.yitineration, I.nitineration,  I.iditineration,I.start
FROM registrylegalstatus RLS
JOIN itineration I
	ON I.idreg = RLS.idreg
	AND I.idregistrylegalstatus = RLS.idregistrylegalstatus
WHERE I.yitineration = @yitineration
	AND I.nitineration BETWEEN @numberbegin AND @numberend
	AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	AND I.iditineration_ref is null
	
UPDATE #rls
SET foreigngroupnumber =
(SELECT DET.foreigngroupnumber
FROM foreigngroupruledetail DET
JOIN foreigngrouprule F		ON F.idforeigngrouprule = DET.idforeigngrouprule
WHERE DET.idposition = #rls.idposition
	AND #rls.incomeclass BETWEEN DET.minincomeclass AND DET.maxincomeclass
	AND F.start =
		(SELECT MAX(F2.start)
		FROM foreigngrouprule F2
		JOIN foreigngroupruledetail DET2			ON F.idforeigngrouprule = DET.idforeigngrouprule
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
	itineration.applierannotations,
	itineration.location,
	DATEDIFF(day, itineration.start,itineration.stop) as ndays
FROM itineration
JOIN registry			ON registry.idreg = itineration.idreg
JOIN #rls		ON itineration.yitineration = #rls.yitineration	AND itineration.nitineration = #rls.nitineration
JOIN position	ON position.idposition = #rls.idposition
JOIN service	ON service.idser = itineration.idser
WHERE itineration.yitineration = @yitineration   
	AND itineration.nitineration BETWEEN @numberbegin AND @numberend
	AND (@idsor01 IS NULL OR itineration.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR itineration.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR itineration.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR itineration.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR itineration.idsor05 = @idsor05)
	AND itineration.iditineration_ref is null
ORDER BY itineration.nitineration ASC
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

