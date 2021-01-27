
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_spese_catania]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_spese_catania]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 


--setuser 'amministrazione'
-- rpt_missione_spese_catania 2019, 30

CREATE  PROCEDURE [rpt_missione_spese_catania]
	@yitineration smallint, 
	@nitineration int
AS BEGIN
DECLARE @iditineration int
SELECT  @iditineration=iditineration
	FROM itineration 
	WHERE yitineration = @yitineration AND nitineration = @nitineration

SELECT 
	nrefund=row_number() over(order by ISNULL(itineration.iditineration_ref,itineration.iditineration)), --itinerationrefund.nrefund,
	itinerationrefundkind.description AS itinerationrefundkind,
	itinerationrefund.description,
	itinerationrefund.extraallowance,
	--itinerationrefund.amount,
	CASE 
		WHEN exchangerate > 0 THEN
			ROUND(isnull(amount,0) / exchangerate, 2)
		ELSE
  			isnull(amount,0)
		END as 'amount',
	isnull(itinerationrefund.advancepercentage,0) *100 AS advancepercentage,
	itinerationrefund.starttime,
	itinerationrefund.stoptime,
	currency.codecurrency as idcurrency,
	itinerationrefund.exchangerate,
	foreigncountry.description as foreigncountry
FROM itinerationrefund
join itineration on itineration.iditineration = itinerationrefund.iditineration
LEFT OUTER JOIN itinerationrefundkind	ON itinerationrefundkind.iditinerationrefundkind = itinerationrefund.iditinerationrefundkind
LEFT OUTER JOIN currency		ON currency.idcurrency  = itinerationrefund.idcurrency
LEFT OUTER JOIN foreigncountry	ON foreigncountry.idforeigncountry  = itinerationrefund.idforeigncountry
WHERE ISNULL(itineration.iditineration_ref,itineration.iditineration) = @iditineration
	AND itinerationrefund.flagadvancebalance = 'S'
ORDER BY nrefund
END

GO
 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
