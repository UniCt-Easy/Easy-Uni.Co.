
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

if exists (select * from dbo.sysobjects where id = object_id(N'[doupdate_mandato_pagamento]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [doupdate_mandato_pagamento]
GO

CREATE PROCEDURE [doupdate_mandato_pagamento] 
(
	@ayear int,
	@printkind char(1),
	@startnpay int,
	@stopnpay int,
	@printdate datetime,
	@idtreasurer INT
)
AS BEGIN
CREATE TABLE #printingdoc(npay int)
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printingdoc (npay) 
	SELECT npay FROM payment 
	WHERE (ypay=@ayear) AND (printdate IS NULL) AND idtreasurer = @idtreasurer
END
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printingdoc (npay) 
	SELECT npay FROM payment 
	WHERE (ypay=@ayear) AND (npay BETWEEN @startnpay AND @stopnpay) AND idtreasurer = @idtreasurer
END
UPDATE payment
SET printdate =	@printdate
WHERE ypay = @ayear
	AND npay IN (SELECT npay FROM #printingdoc)
	AND idtreasurer = @idtreasurer
	AND printdate IS NULL
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

