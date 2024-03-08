
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensodip_ritenuta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensodip_ritenuta]
GO



CREATE  PROCEDURE [rpt_compensodip_ritenuta]
	@ycon	smallint, 
	@ncon	int
AS
BEGIN
	SELECT 
		wageadditiontax.taxcode,
		description,
		'taxkind' = CASE tax.taxkind
			WHEN 1 THEN 'Fiscale'
			WHEN 2 THEN 'Assistenziale'
			WHEN 3 THEN 'Previdenziale'
			WHEN 4 THEN 'Assicurativa'
			WHEN 5 THEN 'Arretrati'
			WHEN 6 THEN 'Altro'
		ELSE ''
		END,
		taxable,
		'aliquotaamministrazione' = adminrate*100,
		'aliquotadipendente' = employrate*100,
		admintax,
		employtax
		FROM wageadditiontax
		LEFT OUTER JOIN tax
		ON wageadditiontax.taxcode = tax.taxcode
		WHERE ycon = @ycon
		AND ncon = @ncon
	ORDER BY wageadditiontax.taxcode ASC
END
go
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
