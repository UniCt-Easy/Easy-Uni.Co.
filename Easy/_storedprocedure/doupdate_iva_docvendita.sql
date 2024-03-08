
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

if exists (select * from dbo.sysobjects where id = object_id(N'[doupdate_iva_docvendita]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [doupdate_iva_docvendita]
GO

CREATE PROCEDURE [doupdate_iva_docvendita]
(
	@ayear int,
	@printkind char(1),
	@idinvkind int,
	@ninv_start int,
	@ninv_stop int
)
AS BEGIN
CREATE TABLE #printingdoc (num int)
IF @printkind = 'A'
BEGIN
	INSERT INTO #printingdoc (num) 
	SELECT ninv FROM invoice
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	WHERE invoicekind.flagbuysell = 'V'
		AND invoice.yinv = @ayear
		AND invoice.officiallyprinted <> 'S'
		AND invoicekind.idinvkind  = @idinvkind 
END
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printingdoc (num) 
	SELECT ninv FROM invoice
	WHERE yinv = @ayear
		AND ninv BETWEEN @ninv_start AND @ninv_stop
		AND idinvkind  = @idinvkind
END
UPDATE invoice SET officiallyprinted = 'S'
WHERE yinv = @ayear 
	AND ninv IN (SELECT num FROM #printingdoc)
	AND idinvkind = @idinvkind
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

