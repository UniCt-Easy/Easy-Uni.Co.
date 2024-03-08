
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_anticipo_dettaglio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_anticipo_dettaglio]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE rpt_anticipo_dettaglio
(
	@yitineraton smallint, 
	@nitineraton int
)
AS BEGIN
CREATE TABLE #itineration_advance
(
	description varchar(150),
	base decimal(19,2),
	amount decimal(19,2),
	percentage decimal(19,6),
	advancekind char(1)
)

declare @iditineration int
select @iditineration = iditineration from itineration where yitineration = @yitineraton and nitineration = @nitineraton

INSERT INTO #itineration_advance(description,base,percentage,advancekind)
SELECT
	itinerationlap.description,
	allowance * (1 - ISNULL( reductionpercentage, 0)) * (days * 24 + hours) / 24,
	itinerationlap.advancepercentage*100,
	'T'
FROM itinerationlap
join itineration
on itineration.iditineration = itinerationlap.iditineration
WHERE  ISNULL(itineration.iditineration_ref, itineration.iditineration)= @iditineration

	
INSERT INTO #itineration_advance
(
	description,
	percentage,
	base,
	advancekind
)
SELECT
	itinerationrefund.description,
	ISNULL(itinerationrefund.advancepercentage, 0) * 100,
	itinerationrefund.amount,
	'S'
FROM itinerationrefund
join itineration
	on itineration.iditineration = itinerationrefund.iditineration
WHERE  ISNULL(itineration.iditineration_ref, itineration.iditineration)= @iditineration
	AND ISNULL(itinerationrefund.advancepercentage,0)>0

SELECT advancekind,description, percentage, 
	convert(decimal(19,2),ROUND(base,2)) AS base, convert(decimal(19,2),ROUND((ISNULL(percentage, 0) / 100) * ISNULL(base, 0),2)) AS amount
FROM #itineration_advance
ORDER BY advancekind ASC
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
