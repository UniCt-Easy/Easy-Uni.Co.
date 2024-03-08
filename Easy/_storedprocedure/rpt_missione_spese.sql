
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_spese]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_spese]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
--rpt_missione_spese 2023,1

CREATE  PROCEDURE [rpt_missione_spese]
	@yitineration smallint, 
	@nitineration int
AS BEGIN
DECLARE @iditineration int
SELECT  @iditineration=iditineration
	FROM itineration 
	WHERE yitineration = @yitineration AND nitineration = @nitineration

	DECLARE @refundlabel varchar(1000)
	SELECT	@refundlabel = 	refundlabel
	FROM	web_config

SELECT 
	nrefund=row_number() over(order by ISNULL(itineration.iditineration_ref,itineration.iditineration)), --itinerationrefund.nrefund,
	itinerationrefundkind.description AS itinerationrefundkind,
	itinerationrefund.description,
	itinerationrefund.extraallowance,
	itinerationrefund.amount_c,
	itinerationrefund.amount,
	itinerationrefund.requiredamount_c ,
	itinerationrefund.requiredamount ,
	/*
	CASE 
		WHEN exchangerate > 0 THEN
			ROUND(amount / exchangerate, 2)
		ELSE
  			amount 
		END as 'amount',
	CASE
		WHEN exchangerate > 0 THEN
			ROUND(requiredamount / exchangerate, 2)
		ELSE
			requiredamount
		END as 'requiredamount',
	*/
	itinerationrefund.advancepercentage*100 AS advancepercentage,
	CONVERT(datetime, itinerationrefund.starttime)   as starttime,
	CONVERT(datetime, itinerationrefund.stoptime)   as stoptime,
	currency.codecurrency as idcurrency,
	itinerationrefund.exchangerate,
	foreigncountry.description as foreigncountry,
	@refundlabel as refundlabel
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
