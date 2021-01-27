
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_tappe]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_tappe]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--rpt_missione_tappe 2015,1


CREATE  PROCEDURE [rpt_missione_tappe]
	@yitineration smallint, 
	@nitineration int
AS BEGIN
DECLARE @iditineration int
SELECT  @iditineration=iditineration
	FROM itineration 
	WHERE yitineration = @yitineration AND nitineration = @nitineration


SELECT 
	itinerationlap.lapnumber,
	itinerationlap.flagitalian,
	foreigncountry.description as foreigncountry,
	itinerationlap.description,
	itinerationlap.starttime,
	itinerationlap.stoptime,
	itinerationlap.days,
	itinerationlap.hours,
	reduction.description as riduzione,
	itinerationlap.reductionpercentage*100 as reductionpercentage,
	itinerationlap.allowance,
	itinerationlap.advancepercentage*100 as advancepercentage
FROM itinerationlap
join itineration						on itineration.iditineration = itinerationlap.iditineration
LEFT OUTER JOIN foreigncountry			ON foreigncountry.idforeigncountry = itinerationlap.idforeigncountry
LEFT OUTER JOIN reduction				ON reduction.idreduction = itinerationlap.idreduction
WHERE ISNULL(itineration.iditineration_ref,itineration.iditineration) = @iditineration
ORDER BY lapnumber
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
