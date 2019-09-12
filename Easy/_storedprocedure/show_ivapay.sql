if exists (select * from dbo.sysobjects where id = object_id(N'[show_ivapay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_ivapay]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [show_ivapay](
	@yivapay int,
	@nivapay int
)
AS
BEGIN

-- exec [show_ivapay] 2015,6
-- exec [show_ivapay] 2010,1
CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

DECLARE @start	 datetime
DECLARE @stop	 datetime
SELECT @start = start,
		@stop = stop
FROM ivapay
WHERE nivapay = @nivapay AND yivapay = @yivapay 


DECLARE @creditamount decimal (19,2)
DECLARE @creditamount12 decimal (19,2)
DECLARE @creditamountdeferred decimal (19,2)
DECLARE @creditamountdeferred12 decimal (19,2)
DECLARE @debitamount decimal (19,2)
DECLARE @debitamount12 decimal (19,2)
DECLARE @debitamountsplit decimal (19,2)
DECLARE @debitamountdeferred decimal (19,2)
DECLARE @debitamountdeferred12 decimal (19,2)
DECLARE @debitamountdeferredsplit decimal (19,2)
DECLARE @flag tinyint
SELECT 
	@creditamount = creditamount,
	@creditamount12 = creditamount12,
	@creditamountdeferred = creditamountdeferred,
	@creditamountdeferred12 = creditamountdeferred12,
	@debitamount = debitamount,
	@debitamount12 = debitamount12,
	@debitamountsplit = debitamountsplit,
	@debitamountdeferred = debitamountdeferred,
	@debitamountdeferred12 = debitamountdeferred12,
	@debitamountdeferredsplit = debitamountdeferredsplit,
	@flag = ISNULL(flag,7) 
FROM ivapay
WHERE nivapay = @nivapay AND yivapay = @yivapay 
	INSERT INTO #situation VALUES ('Liquidazione ' + CONVERT(char(4), @yivapay ) + ' / '+CONVERT(char(4), @nivapay), NULL, 'H')
	INSERT INTO #situation VALUES ('Periodo della liquidazione', null, 'H')
	INSERT INTO #situation VALUES ('dal '+ convert(varchar(8),@start,3) + ' al '+ convert(varchar(8),@stop,3), null, 'H')

	If ((@flag&1) <> 0) BEGIN
		INSERT INTO #situation VALUES ('Iva Commerciale e Promiscua', null, 'S')
	
		INSERT INTO #situation VALUES('Iva a credito Immediata', @creditamount, ' ')
		INSERT INTO #situation VALUES('Iva a credito Differita', @creditamountdeferred, ' ')
		INSERT INTO #situation VALUES('Iva a debito Immediata', @debitamount, ' ')
		INSERT INTO #situation VALUES('Iva a debito Differita', @debitamountdeferred, ' ')
		INSERT INTO #situation VALUES('',NULL,'N')
	END
	
	IF ((@flag&2) <> 0) BEGIN
		INSERT INTO #situation VALUES ('Iva Istituzionale (INTRA12)', null, 'S')
		INSERT INTO #situation VALUES('Iva Intracomunitaria a credito Immediata', @creditamount12, ' ')
		INSERT INTO #situation VALUES('Iva Intracomunitaria a credito Differita', @creditamountdeferred12, ' ')
		INSERT INTO #situation VALUES('Iva Intracomunitaria a debito Immediata', @debitamount12, ' ')
		INSERT INTO #situation VALUES('Iva Intracomunitaria a debito Differita', @debitamountdeferred12, ' ')
		INSERT INTO #situation VALUES('',NULL,'N')
	END

	IF ((@flag&4) <> 0) BEGIN
		INSERT INTO #situation VALUES ('Iva Istituzionale Split Payment', null, 'S')
		INSERT INTO #situation VALUES('Iva  Istituzionale Split Payment a debito Immediata', @debitamountsplit, ' ')
		INSERT INTO #situation VALUES('Iva  Istituzionale Split Payment a debito Differita', @debitamountdeferredsplit, ' ')
		INSERT INTO #situation VALUES('',NULL,'N')
	END
	SELECT * FROM  #situation
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

