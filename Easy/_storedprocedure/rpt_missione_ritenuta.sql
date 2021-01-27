
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_ritenuta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_ritenuta]
GO
GO

--setuser 'amm'
--rpt_missione_ritenuta 2016,1
CREATE    PROCEDURE [rpt_missione_ritenuta]
	@yitineration smallint, 
	@nitineration int
AS
BEGIN

DECLARE @iditineration int
SELECT  @iditineration=iditineration
	FROM itineration 
	WHERE yitineration = @yitineration AND nitineration = @nitineration



SELECT 
	tax.description AS ritenuta,
	CASE tax.taxkind
		WHEN 1 THEN 'Fiscale'
		WHEN 2 THEN 'Assistenziale'
		WHEN 3 THEN 'Previdenziale'
		WHEN 4 THEN 'Assicurativa'
		WHEN 5 THEN 'Arretrati'
		WHEN 6 THEN 'Altro'
	ELSE ''
	END AS taxkind,
	itinerationtax.taxable,
	itinerationtax.adminrate*100 AS aliquotaamministrazione,
	itinerationtax.employrate*100 AS aliquotadipendente,
	itinerationtax.admintax,
	itinerationtax.employtax
FROM itinerationtax
join itineration on itineration.iditineration = itinerationtax.iditineration 
JOIN tax
	ON itinerationtax.taxcode = tax.taxcode
WHERE ISNULL(itineration.iditineration_ref,itineration.iditineration) = @iditineration	
ORDER BY ritenuta ASC
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
