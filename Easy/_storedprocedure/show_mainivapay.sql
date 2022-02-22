
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_mainivapay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_mainivapay]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [show_mainivapay](
	@ymainivapay int,
	@nmainivapay int
)
AS
BEGIN
-- exec [show_mainivapay] 2010,11
-- exec [show_mainivapay] 2009,1

CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

DECLARE @nmonth	 int
SELECT @nmonth = nmonth FROM mainivapay WHERE nmainivapay = @nmainivapay AND ymainivapay = @ymainivapay 

DECLARE @denominazionemese varchar(10)
SELECT @denominazionemese = title FROM monthname WHERE code = @nmonth

DECLARE @creditamount decimal (19,2)
DECLARE @creditamount12 decimal (19,2)
DECLARE @creditamountdeferred decimal (19,2)
DECLARE @creditamountdeferred12 decimal (19,2)
DECLARE @debitamount decimal (19,2)
DECLARE @debitamount12 decimal (19,2)
DECLARE @debitamountdeferred decimal (19,2)
DECLARE @debitamountdeferred12 decimal (19,2)
DECLARE @flag tinyint

DECLARE @referenceyear INT
SELECT 
	@referenceyear = referenceyear,
	@creditamount = creditamount,
	@creditamount12 = creditamount12,
	@creditamountdeferred = creditamountdeferred,
	@creditamountdeferred12 = creditamountdeferred12,
	@debitamount = debitamount,
	@debitamount12 = debitamount12,
	@debitamountdeferred = debitamountdeferred, 
	@debitamountdeferred12 = debitamountdeferred12,
	@flag = ISNULL(flag,3) 
FROM mainivapay
WHERE nmainivapay = @nmainivapay AND ymainivapay = @ymainivapay 
	INSERT INTO #situation VALUES ('Liquidazione IVA Consolidata ' + CONVERT(char(4), @ymainivapay ) + ' / '+CONVERT(char(4), @nmainivapay), NULL, 'H')
	
	If (((@flag&1) <> 0)AND((@flag&2) = 0)) INSERT INTO #situation VALUES ('Iva Commerciale e Promiscua', null, 'H')
	If (((@flag&1) = 0)AND((@flag&2) <> 0)) INSERT INTO #situation VALUES ('Iva Istituzionale (INTRA12)', null, 'H')
	If (((@flag&1) <> 0)AND((@flag&2) <> 0)) INSERT INTO #situation VALUES ('Iva Commerciale, Promiscua e Istituzionale (INTRA12)', null, 'H')

	INSERT INTO #situation VALUES ('Mese di riferimento della liquidazione', null, 'H')
	INSERT INTO #situation VALUES (convert(varchar(10),@denominazionemese,3) +' '+ CONVERT(char(4), @referenceyear ), null, 'H')
	INSERT INTO #situation VALUES('',NULL,'H')
	INSERT INTO #situation VALUES('Iva a credito Immediata', @creditamount, 'S')
	INSERT INTO #situation VALUES('Iva a credito Differita', @creditamountdeferred, 'S')
	INSERT INTO #situation VALUES('Iva a debito Immediata', @debitamount, 'S')
	INSERT INTO #situation VALUES('Iva a debito Differita', @debitamountdeferred, 'S')
	INSERT INTO #situation VALUES('',NULL,'H')
	IF ((@flag&2) <> 0) BEGIN
		INSERT INTO #situation VALUES('Iva Intracomunitaria a credito Immediata', @creditamount12, 'S')
		INSERT INTO #situation VALUES('Iva Intracomunitaria a credito Differita', @creditamountdeferred12, 'S')
		INSERT INTO #situation VALUES('Iva Intracomunitaria a debito Immediata', @debitamount12, 'S')
		INSERT INTO #situation VALUES('Iva Intracomunitaria a debito Differita', @debitamountdeferred12, 'S')
	END

	SELECT * FROM  #situation
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

