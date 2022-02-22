
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_liquidazioneivasplitist_sub]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure rpt_liquidazioneivasplitist_sub
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rpt_liquidazioneivasplitist_sub
(
	@ayear int,
	@number int,
	@official char(1)
)
AS BEGIN

-- exec rpt_liquidazioneivasplitist_sub 2015,5 ,'N'

SELECT
	 ID.invoicekind, ID.yinv, ID.ninv, ID.doc, ID.docdate, ID.adate, ID.taxable, ID.tax, ID.unabatable, ID.total, ID.description, ID.registry, ID.flagvariation, ID.ivatotalpayed
FROM  invoicedeferredview ID
WHERE ID.yivapay = @ayear
	AND ID.nivapay = @number
	AND ID.registerclass='A' and ID.flagactivity=1  and ID.flag_enable_split_payment='S' and ID.flagintracom='N'
ORDER BY ID.description, ID.yinv, ID.ninv
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
