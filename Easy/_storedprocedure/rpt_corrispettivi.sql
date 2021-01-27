
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_corrispettivi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_corrispettivi]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE     PROCEDURE rpt_corrispettivi
(
	@year int,
	@month int,	
	@idivaregisterkind int,
	@official char(1),
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
)
AS BEGIN
 
-- exec rpt_corrispettivi 2009, 9, 1, 'S'
-- exec rpt_corrispettivi 2009, 9, 5, 'N'

CREATE TABLE #sales
(
	codeinvkind varchar(20),idinvkind int,	
	codeivaregisterkind varchar(20),	
	yinv int,
	reg_day int,
	reg_month varchar(20),
	taxable decimal(19,2),
	description  varchar(300),
	tax_with_rate1 decimal(19,2),
	tax_with_rate2 decimal(19,2),
	tax_with_rate3 decimal(19,2),
	tax_with_rate4 decimal(19,2),
	zerorated decimal(19,2),

	flagintracom char(1),
	registerclass char(1),	--tipo registro A/V
	kind char(1),			--tipo fattura A/V
	flagvariation char(1)
)
DECLARE @paramvalue1 varchar(10)
DECLARE @rate1 decimal(19,3)
SELECT @paramvalue1 = paramvalue
FROM reportadditionalparam  
WHERE reportname = 'registrocorrispettivi' AND paramname = 'Aliquota1'

IF ( ISNUMERIC(@paramvalue1) = 1 ) 
BEGIN
	SET @rate1 = CONVERT(decimal(19,3),@paramvalue1)
END

DECLARE @rate2 decimal(19,3)
DECLARE @paramvalue2 varchar(10)
SELECT @paramvalue2 = paramvalue
FROM reportadditionalparam  
WHERE reportname = 'registrocorrispettivi' AND paramname = 'Aliquota2'

IF ( ISNUMERIC(@paramvalue2) = 1 )
BEGIN
	SET @rate2 = CONVERT(decimal(19,3),@paramvalue2)
END

DECLARE @rate3 decimal(19,3)
DECLARE @paramvalue3 varchar(10)
SELECT @paramvalue3 = paramvalue
FROM reportadditionalparam  
WHERE reportname = 'registrocorrispettivi' AND paramname = 'Aliquota3'


IF ( ISNUMERIC(@paramvalue3) = 1 )
BEGIN
	SET @rate3 = CONVERT(decimal(19,3),@paramvalue3)
END

DECLARE @rate4 decimal(19,3)
DECLARE @paramvalue4 varchar(10)
SELECT @paramvalue4 = paramvalue
FROM reportadditionalparam  
WHERE reportname = 'registrocorrispettivi' AND paramname = 'Aliquota4'
IF ( ISNUMERIC(@paramvalue4) = 1 )
BEGIN
	SET @rate4 = CONVERT(decimal(19,3),@paramvalue4)
END

DECLARE @rate5 decimal(19,3)
SELECT  @rate5 = CONVERT(decimal(19,3),0)

DECLARE @monthname varchar(20)
SELECT  @monthname = title FROM monthname WHERE code = @month

-- Dati relativi ai mesi precedenti
INSERT INTO #sales
(
	codeinvkind,			
	codeivaregisterkind,	
	yinv,
	reg_month,
	taxable,
	flagintracom,
	registerclass,	--tipo registro A/V
	kind, 			--tipo fattura A/V
	flagvariation
)

SELECT
	'RIPORTO',
	'RIPORTO',
	@year,
	@monthname,
	CONVERT(decimal(19,2),
		ISNULL(SUM(
			ROUND(invoicedetail.taxable * invoicedetail.npackage * 
				CONVERT(decimal(19,10),ISNULL(invoice.exchangerate,1)) *
					(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
			)
		),0)
	)
	+
	ISNULL(SUM(invoicedetail.tax),0),
	invoice.flagintracom,
	ivaregisterkind.registerclass,		--tipo registro (A/V)
	CASE WHEN (invoicekind.flag & 1)=0 THEN 'A'
		 ELSE 'V'
	END ,--kind		--tipo fattura (A/V)
	CASE
		WHEN (invoicekind.flag & 4) = 0 THEN 'N'
		ELSE 'S'
	END --flagvariation	
FROM ivaregister
JOIN invoice
	ON invoice.idinvkind = ivaregister.idinvkind
	AND invoice.yinv = ivaregister.yinv
	AND invoice.ninv = ivaregister.ninv
JOIN invoicekind
	ON invoicekind.idinvkind = invoice.idinvkind
JOIN invoicedetail
	ON invoicedetail.idinvkind = invoice.idinvkind
	AND invoicedetail.yinv = invoice.yinv
	AND invoicedetail.ninv = invoice.ninv
JOIN ivaregisterkind
	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
WHERE ivaregister.idivaregisterkind = @idivaregisterkind
	AND DATEPART(year,invoice.adate) = @year
	AND DATEPART(month,invoice.adate) < @month
	AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
GROUP BY ivaregister.idivaregisterkind, ivaregister.yinv,
		invoice.flagintracom,ivaregisterkind.registerclass, (invoicekind.flag & 1), (invoicekind.flag & 4),
		invoice.idsor01, invoice.idsor02,invoice.idsor03,invoice.idsor04,invoice.idsor05
-- Stessa INSERT precedente ma interroga SOLO le Autofatture senza dettagli

UNION 

SELECT
	'RIPORTO',
	'RIPORTO',
	@year,
	@monthname,
	CONVERT(decimal(19,2),
		ISNULL(SUM(
			ROUND(invoicedetail.taxable * invoicedetail.npackage * 
				CONVERT(decimal(19,10),ISNULL(invoice.exchangerate,1)) *
					(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
			)
		),0)
	)
	+
	ISNULL(SUM(invoicedetail.tax),0),
	M.flagintracom,
	ivaregisterkind.registerclass,		--tipo registro (A/V)
	CASE WHEN (invoicekind.flag & 1)=0 THEN 'A'
		 ELSE 'V'
	END ,--kind		--tipo fattura (A/V)
	CASE
		WHEN (invoicekind.flag & 4) = 0 THEN 'N'
		ELSE 'S'
	END --flagvariation	
FROM invoice M --> fattura Madre
JOIN invoice 
	ON invoice.idinvkind_real = M.idinvkind
	AND invoice.yinv_real = M.yinv
	AND invoice.ninv_real = M.ninv
join invoicedetail 
	ON invoicedetail.idinvkind = M.idinvkind
	AND invoicedetail.yinv = M.yinv
	AND invoicedetail.ninv = M.ninv
JOIN ivaregister
	ON invoice.idinvkind = ivaregister.idinvkind
	AND invoice.yinv = ivaregister.yinv
	AND invoice.ninv = ivaregister.ninv
JOIN invoicekind
	ON invoicekind.idinvkind = invoice.idinvkind
JOIN ivaregisterkind
	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
WHERE ivaregister.idivaregisterkind = @idivaregisterkind
	AND DATEPART(year,M.adate) = @year
	AND DATEPART(month,M.adate) < @month
	AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
GROUP BY ivaregister.idivaregisterkind, ivaregister.yinv,
		M.flagintracom, ivaregisterkind.registerclass, (invoicekind.flag & 1), (invoicekind.flag & 4),
		invoice.idsor01, invoice.idsor02,invoice.idsor03,invoice.idsor04,invoice.idsor05

-- Dati del mese corrente
INSERT INTO #sales
(
	codeinvkind,
	idinvkind,
	codeivaregisterkind,	
	yinv,
	reg_day,
	reg_month,
	flagintracom,
	registerclass,	--tipo registro A/V
	kind, 			--tipo fattura A/V
	flagvariation
)
SELECT
	invoicekind.codeinvkind,
	ivaregister.idinvkind,
	ivaregisterkind.codeivaregisterkind,	
	ivaregister.yinv,
	datepart(dd,invoice.adate),
	@monthname,
	invoice.flagintracom,
	ivaregisterkind.registerclass,		--tipo registro (A/V)
	CASE WHEN (invoicekind.flag & 1)=0 THEN 'A'
		 ELSE 'V'
	END ,--kind		--tipo fattura (A/V)
	CASE
		WHEN (invoicekind.flag & 4) = 0 THEN 'N'
		ELSE 'S'
	END --flagvariation	
FROM ivaregister
JOIN invoice
	ON invoice.idinvkind = ivaregister.idinvkind
	AND invoice.yinv = ivaregister.yinv
	AND invoice.ninv = ivaregister.ninv
JOIN invoicekind
	ON invoicekind.idinvkind = ivaregister.idinvkind
JOIN ivaregisterkind
	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
WHERE ivaregister.idivaregisterkind = @idivaregisterkind
	AND DATEPART(year,invoice.adate) = @year
	AND DATEPART(month,invoice.adate) = @month
	AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
GROUP BY 
	invoicekind.codeinvkind,ivaregister.idinvkind,
	ivaregisterkind.codeivaregisterkind,	
	ivaregister.yinv,
	ivaregisterkind.description,
	DATEPART(dd,invoice.adate),
	invoice.flagintracom,ivaregisterkind.registerclass, (invoicekind.flag & 1), (invoicekind.flag & 4),
	invoice.idsor01, invoice.idsor02,invoice.idsor03,invoice.idsor04,invoice.idsor05

UPDATE #sales
SET tax_with_rate1 =
ISNULL(
	(SELECT ISNULL(SUM(invoicedetail.tax),0)
	FROM invoicedetail
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN invoice
		ON invoice.idinvkind = invoicedetail.idinvkind
		AND invoice.yinv = invoicedetail.yinv
		AND invoice.ninv = invoicedetail.ninv
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) = @rate1
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoicedetail.idinvkind = #sales.idinvkind

		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
)
,0)
+
-- Aggiungiamo lo stesso valore leggendolo dalle Autofatture senza dettagli
ISNULL(
	(SELECT ISNULL(SUM(invoicedetail.tax),0)
	FROM invoice M --> fattura Madre
	JOIN invoice
		ON invoice.idinvkind_real = M.idinvkind
		AND invoice.yinv_real = M.yinv
		AND invoice.ninv_real = M.ninv
	join invoicedetail 
		ON invoicedetail.idinvkind = M.idinvkind
		AND invoicedetail.yinv = M.yinv
		AND invoicedetail.ninv = M.ninv
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) = @rate1
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		--AND invoicedetail.idinvkind = #sales.idinvkind
		AND invoice.idinvkind = #sales.idinvkind
		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
)
,0),

tax_with_rate2 =
ISNULL(
	(SELECT ISNULL(SUM(invoicedetail.tax),0)
	FROM invoicedetail
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN invoice
		ON invoice.idinvkind = invoicedetail.idinvkind
		AND invoice.yinv = invoicedetail.yinv
		AND invoice.ninv = invoicedetail.ninv
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) = @rate2
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoicedetail.idinvkind = #sales.idinvkind

		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
)
,0)
+
-- Aggiungiamo lo stesso valore leggendolo dalle Autofatture senza dettagli
ISNULL(
	(SELECT ISNULL(SUM(invoicedetail.tax),0)
	FROM invoice M --> fattura Madre
	JOIN invoice
		ON invoice.idinvkind_real = M.idinvkind
		AND invoice.yinv_real = M.yinv
		AND invoice.ninv_real = M.ninv
	join invoicedetail 
		ON invoicedetail.idinvkind = M.idinvkind
		AND invoicedetail.yinv = M.yinv
		AND invoicedetail.ninv = M.ninv
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) = @rate2
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoice.idinvkind = #sales.idinvkind

		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
)
,0)

,
tax_with_rate3 =
ISNULL(
	(SELECT ISNULL(SUM(invoicedetail.tax),0)
	FROM invoicedetail
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN invoice
		ON invoice.idinvkind = invoicedetail.idinvkind
		AND invoice.yinv = invoicedetail.yinv
		AND invoice.ninv = invoicedetail.ninv
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) = @rate3
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoicedetail.idinvkind = #sales.idinvkind

		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
)
,0)
+
-- Aggiungiamo lo stesso valore leggendolo dalle Autofatture senza dettagli
ISNULL(
	(SELECT ISNULL(SUM(invoicedetail.tax),0)
	FROM invoice M --> fattura Madre
	JOIN invoice
		ON invoice.idinvkind_real = M.idinvkind
		AND invoice.yinv_real = M.yinv
		AND invoice.ninv_real = M.ninv
	join invoicedetail 
		ON invoicedetail.idinvkind = M.idinvkind
		AND invoicedetail.yinv = M.yinv
		AND invoicedetail.ninv = M.ninv
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) = @rate3
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoice.idinvkind = #sales.idinvkind
		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
)
,0),
tax_with_rate4 =
ISNULL(
	(SELECT ISNULL(SUM(invoicedetail.tax),0)
	FROM invoicedetail
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN invoice
		ON invoice.idinvkind = invoicedetail.idinvkind
		AND invoice.yinv = invoicedetail.yinv
		AND invoice.ninv = invoicedetail.ninv
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) = @rate4
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoicedetail.idinvkind = #sales.idinvkind

		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
)
,0)
+
-- Aggiungiamo lo stesso valore leggendolo dalle Autofatture senza dettagli
ISNULL(
	(SELECT ISNULL(SUM(invoicedetail.tax),0)
	FROM invoice M --> fattura Madre
	JOIN invoice
		ON invoice.idinvkind_real = M.idinvkind
		AND invoice.yinv_real = M.yinv
		AND invoice.ninv_real = M.ninv
	join invoicedetail 
		ON invoicedetail.idinvkind = M.idinvkind
		AND invoicedetail.yinv = M.yinv
		AND invoicedetail.ninv = M.ninv
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) = @rate4
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoice.idinvkind = #sales.idinvkind
		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
)
,0),


taxable =
ISNULL(
	(SELECT ISNULL(CONVERT(decimal(19,2),
		SUM(
			ROUND(invoicedetail.taxable * invoicedetail.npackage * 
				CONVERT(decimal(19,10),ISNULL(invoice.exchangerate,1)) *
					(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
			)
		)
	),0)
	FROM invoicedetail
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN invoice
		ON invoice.idinvkind = invoicedetail.idinvkind
		AND invoice.yinv = invoicedetail.yinv
		AND invoice.ninv = invoicedetail.ninv
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) <> @rate5
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoicedetail.idinvkind = #sales.idinvkind
		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
	)
,0)
+
-- Aggiungiamo lo stesso valore leggendolo dalle Autofatture senza dettagli
ISNULL(
	(SELECT ISNULL(CONVERT(decimal(19,2),
		SUM(
			ROUND(invoicedetail.taxable * invoicedetail.npackage * 
				CONVERT(decimal(19,10),ISNULL(invoice.exchangerate,1)) *
					(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
			)
		)
	),0)
	FROM invoice M --> fattura Madre
	JOIN invoice
		ON invoice.idinvkind_real = M.idinvkind
		AND invoice.yinv_real = M.yinv
		AND invoice.ninv_real = M.ninv
	join invoicedetail 
		ON invoicedetail.idinvkind = M.idinvkind
		AND invoicedetail.yinv = M.yinv
		AND invoicedetail.ninv = M.ninv
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) <> @rate5
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoice.idinvkind = #sales.idinvkind
		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
	)
,0)
, 

-- importo non soggetto a IVA
zerorated = 
ISNULL(
	(SELECT ISNULL(CONVERT(decimal(19,2),
		SUM(
			ROUND(invoicedetail.taxable * invoicedetail.npackage * 
				CONVERT(decimal(19,10),ISNULL(invoice.exchangerate,1)) *
					(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
			)
		)
	),0)
	FROM invoicedetail
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN invoice
		ON invoice.idinvkind = invoicedetail.idinvkind
		AND invoice.yinv = invoicedetail.yinv
		AND invoice.ninv = invoicedetail.ninv
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) = @rate5
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoicedetail.idinvkind = #sales.idinvkind
		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	

)
,0)
+
-- Aggiungiamo lo stesso valore leggendolo dalle Autofatture senza dettagli
ISNULL(
	(SELECT ISNULL(CONVERT(decimal(19,2),
		SUM(
			ROUND(invoicedetail.taxable * invoicedetail.npackage * 
				CONVERT(decimal(19,10),ISNULL(invoice.exchangerate,1)) *
					(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
			)
		)
	),0)
	FROM invoice M --> fattura Madre
	JOIN invoice
		ON invoice.idinvkind_real = M.idinvkind
		AND invoice.yinv_real = M.yinv
		AND invoice.ninv_real = M.ninv
	join invoicedetail 
		ON invoicedetail.idinvkind = M.idinvkind
		AND invoicedetail.yinv = M.yinv
		AND invoicedetail.ninv = M.ninv
	JOIN ivakind
		ON ivakind.idivakind = invoicedetail.idivakind
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE DATEPART(year,invoice.adate) = @year
		AND DATEPART(month,invoice.adate) = @month
		AND ROUND(ivakind.rate,3) = @rate5
		AND DATEPART(dd,invoice.adate) = #sales.reg_day
		AND invoice.idinvkind = #sales.idinvkind
		AND invoice.flagintracom = #sales.flagintracom
		AND ivaregisterkind.registerclass = #sales.registerclass
		AND ((invoicekind.flag & 1)=0  AND  #sales.kind = 'A'
			OR 
			(invoicekind.flag & 1)<> 0  AND  #sales.kind = 'V'
			)
		AND ((invoicekind.flag & 4)=0  AND  #sales.flagvariation = 'N'
			OR 
			(invoicekind.flag & 4)<> 0  AND  #sales.flagvariation = 'S'
			)
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	

)
,0)
WHERE  #sales.reg_day is not null

-- Aggiusta il segno di totaldoc in base a registerclass/kind/flagvariation

UPDATE #sales SET taxable = - taxable,
				zerorated = - zerorated,
				tax_with_rate1 = - tax_with_rate1,
				tax_with_rate2 = - tax_with_rate2,
				tax_with_rate3 = - tax_with_rate3,
				tax_with_rate4 = - tax_with_rate4
			WHERE registerclass<>kind AND flagintracom = 'N'

			
UPDATE #sales SET taxable = - taxable,
				zerorated = - zerorated,
				tax_with_rate1 = - tax_with_rate1,
				tax_with_rate2 = - tax_with_rate2,
				tax_with_rate3 = - tax_with_rate3,
				tax_with_rate4 = - tax_with_rate4
			WHERE flagvariation='S'


DECLARE @description  varchar(300)
DECLARE @description1 varchar(300)
DECLARE @reg_day int
DECLARE @idinvkind int
-- tipi di esenzione, prendo le descrizioni relative ai tipi IVA con aliquota pari a 0
DECLARE rowcursor INSENSITIVE CURSOR FOR
		SELECT DISTINCT ivakind.description, DATEPART(dd,invoice.adate), invoicedetail.idinvkind
		FROM invoicedetail
		JOIN ivakind
			ON ivakind.idivakind = invoicedetail.idivakind
		JOIN invoice
			ON invoice.idinvkind = invoicedetail.idinvkind
			AND invoice.yinv = invoicedetail.yinv
			AND invoice.ninv = invoicedetail.ninv
		WHERE DATEPART(year,invoice.adate) = @year
			AND DATEPART(month,invoice.adate) = @month
			AND ROUND(ivakind.rate,3) = @rate5
			AND DATEPART(dd,invoice.adate) IN (select #sales.reg_day FROM #sales) 
			AND invoicedetail.idinvkind  IN (select #sales.idinvkind from #sales)
		FOR READ ONLY
	OPEN rowcursor FETCH  NEXT FROM rowcursor 
	INTO  @description,@reg_day, @idinvkind
	print @description
	print @reg_day
	print @idinvkind
	DECLARE @CRLF char(2) 
	SET @CRLF = CHAR(13) + char(10) 

	WHILE @@FETCH_STATUS = 0
		BEGIN 
			UPDATE  #sales 
			SET	@description1 = ISNULL(#sales.description,'')
			WHERE   #sales.reg_day = @reg_day
			AND     #sales.idinvkind = @idinvkind
			
			print @description1
			IF PATINDEX(@description1 , @description)=0
			BEGIN
				UPDATE #sales  
				SET description = ISNULL(#sales.description,'') + 
						  @description + @CRLF
				WHERE   #sales.reg_day = @reg_day
				AND     #sales.idinvkind = @idinvkind
			END 
			FETCH NEXT FROM rowcursor INTO @description,@reg_day,@idinvkind
		END 
		
	DEALLOCATE rowcursor


DECLARE @currday int
SET @currday = 1
DECLARE @month01 datetime
SET @month01 = CONVERT(smalldatetime, '01-' + CONVERT(varchar(2),@month) + '-' + CONVERT(varchar(4),@year),105)
SET @month01 = DATEADD(DAY,-1,DATEADD(MONTH,1,@month01))
DECLARE @maxday int
SET @maxday = DATEPART(DAY,@month01)
WHILE @currday <= @maxday
BEGIN
-- Aggiunge nella tabella una riga vuota se il giorno corrente non è presente.
	IF (SELECT COUNT(*) FROM #sales
		WHERE reg_day = @currday) = 0
	BEGIN
		INSERT INTO #sales
		(
			codeinvkind,			
			codeivaregisterkind,	
			yinv,
			reg_day,
			reg_month
		)
		SELECT
		'.',
		r.codeivaregisterkind,		
		@year,
		@currday,
		@monthname
		FROM ivaregisterkind r
		WHERE r.idivaregisterkind = @idivaregisterkind
	END
	SET @currday = @currday + 1
END
DECLARE @descr_register varchar(150)
SET @descr_register = (SELECT UPPER(description) FROM ivaregisterkind WHERE idivaregisterkind = @idivaregisterkind)

-- Il campo codeinvkind serve al report SOLO per capire se è un riporto del mese precedente o meno
-- Potrebbero esserci documenti di acquisto e di vendita  registrati in registri di vendita, ma per ogni giorno serve una 
-- riga quindi è stato necessario fare l'update perchè non serve discriminare le righe in base al tipo di documento

UPDATE #sales SET codeinvkind  ='.' WHERE codeinvkind <>'RIPORTO'
SELECT 
	codeinvkind,			
	codeivaregisterkind,	
	@descr_register AS descr_register,
	yinv,
	reg_day,
	reg_month,
	SUBSTRING(@monthname,1,3) AS shortmonth,
	ISNULL(sum(taxable),0) AS taxable,
	ISNULL(sum(zerorated),0) AS zerorated,
	ISNULL(sum(tax_with_rate1),0) AS tax_with_rate1,
	ISNULL(sum(tax_with_rate2),0) AS tax_with_rate2,
	ISNULL(sum(tax_with_rate3),0) AS tax_with_rate3,
	ISNULL(sum(tax_with_rate4),0) AS tax_with_rate4,
	description
FROM #sales
GROUP BY codeinvkind,codeivaregisterkind,yinv,reg_day,reg_month,description

ORDER BY reg_day
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

