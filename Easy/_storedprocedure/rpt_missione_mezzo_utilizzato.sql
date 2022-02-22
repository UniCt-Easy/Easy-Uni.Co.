
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_mezzo_utilizzato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_mezzo_utilizzato]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--rpt_missione_mezzo_utilizzato 2015,1
CREATE  PROCEDURE [rpt_missione_mezzo_utilizzato]
	@yitineration smallint, 
	@nitineration int
AS BEGIN
-- exec [rpt_missione_mezzo_utilizzato] 2010,71
DECLARE @flagmedia tinyint
DECLARE @totflagmedia tinyint
SET @totflagmedia = 0

DECLARE @iditineration int
SELECT  @iditineration=iditineration
	FROM itineration 
	WHERE yitineration = @yitineration AND nitineration = @nitineration



DECLARE @textclause varchar(1000)
SELECT	@textclause = 	itinerationclause
FROM	web_config

DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT 
itinerationrefundkind.flagmedia
--case 
--	when (flagmedia&2) <> 0  then 'aereo'
--	when (flagmedia&4) <> 0  then 'treno'
--	when (flagmedia&8) <> 0  then 'autobus'
--	when (flagmedia&16)<> 0  then 'nave'
--	when (flagmedia&32)<> 0  then 'mezzo amministrazione'
--	when (flagmedia&64)<> 0  then 'mezzo a noleggio'
--	else 'altro'
--end  as media
from itineration
join itinerationrefund on itineration.iditineration = itinerationrefund.iditineration
join itinerationrefundkind  on itinerationrefundkind.iditinerationrefundkind = itinerationrefund.iditinerationrefundkind
join itinerationrefundkindgroup  on itinerationrefundkind.iditinerationrefundkindgroup =  itinerationrefundkindgroup.iditinerationrefundkindgroup 
WHERE itinerationrefundkindgroup.description = 'viaggio'
		AND itineration.iditineration = @iditineration
 
	-- AND itinerationrefund.flagadvancebalance = 'A' --> Commentiamo questa riga perchè col task 3873 si richiede di mostrare anche le spese a rendiconto.
	--order by itineration.yitineration, itineration.nitineration

FOR READ ONLY
OPEN rowcursor
FETCH NEXT FROM rowcursor
INTO @flagmedia
WHILE @@FETCH_STATUS = 0
BEGIN 
	SET @totflagmedia = @totflagmedia|@flagmedia
	print   @flagmedia
	print   @totflagmedia
	FETCH NEXT FROM rowcursor
	INTO @flagmedia 
END 
DEALLOCATE rowcursor
END

DECLARE @mezzoproprio char(1)
SET @mezzoproprio =  ( SELECT ISNULL(clause_accepted,'N') FROM itineration
							WHERE  itineration.iditineration = @iditineration
					)


SELECT 
	@yitineration as 'yitineration', 
	@nitineration as 'nitineration',
	@mezzoproprio as 'Mezzo proprio',
	case 
	when (@totflagmedia&1)  <> 0  then 'S' else 'N'
	end  as 'Aereo',
	case 
		when (@totflagmedia&2)  <> 0  then 'S' else 'N'
	end  as 'Treno',
	case 
		when (@totflagmedia&4)  <> 0  then 'S' else 'N'
	end  as 'Autobus',
	case 
		when (@totflagmedia&8) <> 0  then 'S' else 'N'
	end  as 'Nave',
	case 
		when (@totflagmedia&16) <> 0  then 'S' else 'N'
	end  as 'Mezzo amministrazione',
	case 
		when (@totflagmedia&32) <> 0  then 'S' else 'N'
	end  as 'Mezzo a noleggio',
	case 
		when (@totflagmedia&64) <> 0  then 'S' else 'N'
	end  as 'Altro - mezzo ord.',
	case 
		when (@totflagmedia&128) <> 0  then 'S' else 'N'
	end  as 'Altro - mezzo straord.',
	@textclause as 'itinerationclause'

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
