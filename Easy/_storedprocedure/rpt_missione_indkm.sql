
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_indkm]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_indkm]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE                              PROCEDURE rpt_missione_indkm
	@yitineration	smallint, 
	@nitineration			int
AS

DECLARE @iditineration int
SELECT  @iditineration=iditineration
	FROM itineration 
	WHERE yitineration = @yitineration AND nitineration = @nitineration

	DECLARE @textclause varchar(1000)
	SELECT	@textclause = 	itinerationclause
	FROM	web_config
	
	BEGIN
		SELECT 
			max(admincarkmcost) as admincarkmcost,
			sum(admincarkm) as admincarkm,
			max(owncarkmcost) as owncarkmcost,
			sum(owncarkm) as owncarkm,
			max(footkmcost) as footkmcost,
			sum(footkm) as footkm,
			min(clause_accepted) as clause_accepted,
			@textclause as itinerationclause,
			min(ISNULL(vehicle_info,'')) as vehicle_info,
			min(ISNULL(vehicle_motive,'')) as vehicle_motive
			FROM itineration
			WHERE isnull(iditineration_ref,iditineration) = @iditineration
	END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


