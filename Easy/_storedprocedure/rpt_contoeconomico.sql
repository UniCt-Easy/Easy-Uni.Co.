if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_contoeconomico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_contoeconomico]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [rpt_contoeconomico]
(
@ayear int,
@start datetime,
@stop datetime
)
AS BEGIN

-- Conto Economico Anno Precedente
DECLARE @firstdayPY datetime
DECLARE @lastdayPY datetime
SET @firstdayPY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear-1),105)
SET @lastdayPY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)
DECLARE @sk_prec char(2)
SET @sk_prec = SUBSTRING(CONVERT(varchar(4),@ayear-1),3,2)
 --Sezione COSTI
DECLARE @PY_C_B6 decimal(19,2)
SET @PY_C_B6 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C00010001')
,0)
DECLARE @PY_C_B7 decimal(19,2)
SET @PY_C_B7 =
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C00010002')
,0)
DECLARE @PY_C_B8 decimal(19,2)
SET @PY_C_B8 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C00010003')
,0)
DECLARE @PY_C_B9a decimal(19,2)
SET @PY_C_B9a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000100040001')
,0)
DECLARE @PY_C_B9b decimal(19,2)
SET @PY_C_B9b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000100040002')
,0)
DECLARE @PY_C_B9c decimal(19,2)
SET @PY_C_B9c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	-- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000100040003')
,0)
DECLARE @PY_C_B9d decimal(19,2)
SET @PY_C_B9d = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000100040004')
,0)
DECLARE @PY_C_B9e decimal(19,2)
SET @PY_C_B9e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000100040005')
,0)
DECLARE @PY_C_B9 decimal(19,2)
SET @PY_C_B9 = @PY_C_B9a + @PY_C_B9b + @PY_C_B9c + @PY_C_B9d + @PY_C_B9e
DECLARE @PY_C_B10a decimal(19,2)
SET @PY_C_B10a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000100050001')
,0)
DECLARE @PY_C_B10b decimal(19,2)
SET @PY_C_B10b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000100050002')
,0)
DECLARE @PY_C_B10c decimal(19,2)
SET @PY_C_B10c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO	
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000100050003')
,0)
DECLARE @PY_C_B10d decimal(19,2)
SET @PY_C_B10d = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000100050004')
,0)
DECLARE @PY_C_B10 decimal(19,2)
SET @PY_C_B10 = @PY_C_B10a + @PY_C_B10b + @PY_C_B10c + @PY_C_B10d
DECLARE @PY_C_B11 decimal(19,2)
SET @PY_C_B11 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C00010006')
,0)
DECLARE @PY_C_B12 decimal(19,2)
SET @PY_C_B12 =
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C00010007')
,0)
DECLARE @PY_C_B13 decimal(19,2)
SET @PY_C_B13 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C00010008')
,0)
DECLARE @PY_C_B14 decimal(19,2)
SET @PY_C_B14 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C00010009')
,0)
DECLARE @PY_C_B decimal(19,2)
SET @PY_C_B = @PY_C_B6 + @PY_C_B7 + @PY_C_B8 + @PY_C_B9 + @PY_C_B10 + @PY_C_B11 + @PY_C_B12 + @PY_C_B13 + @PY_C_B14
DECLARE @PY_C_C17a decimal(19,2)
SET @PY_C_C17a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000200010001')
,0)
DECLARE @PY_C_C17b decimal(19,2)
SET @PY_C_C17b = 
ISNULL(
	
	(SELECT -SUM(amount) 
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000200010002')
,0)
DECLARE @PY_C_C17c decimal(19,2)
SET @PY_C_C17c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000200010003')
,0)
DECLARE @PY_C_C17d decimal(19,2)
SET @PY_C_C17d = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000200010004')
,0)
DECLARE @PY_C_C17 decimal(19,2)
SET @PY_C_C17 = @PY_C_C17a + @PY_C_C17b + @PY_C_C17c + @PY_C_C17d
DECLARE @PY_C_C decimal(19,2)
SET @PY_C_C = @PY_C_C17
 --Attenzione i COSTI presenti nella lettera D non devono essere cambiati di segno perché sono presenti nella stessa sezione dei ricavi
DECLARE @PY_C_D19a decimal(19,2)
SET @PY_C_D19a = 
ISNULL(
	
	(SELECT -SUM(amount) 
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000300010001')
,0)
DECLARE @PY_C_D19b decimal(19,2)
SET @PY_C_D19b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000300010002')
,0)
DECLARE @PY_C_D19c decimal(19,2)
SET @PY_C_D19c = 
ISNULL(
	
	(SELECT -SUM(amount) 
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000300010003')
,0)
DECLARE @PY_C_D19 decimal(19,2)
SET @PY_C_D19 = @PY_C_D19a + @PY_C_D19b + @PY_C_D19c
DECLARE @PY_C_D decimal(19,2)
SET @PY_C_D = @PY_C_D19
 --Attenzione i COSTI presenti nella lettera E non devono essere cambiati di segno perché sono presenti nella stessa sezione dei ricavi
DECLARE @PY_C_E21a decimal(19,2)
SET @PY_C_E21a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000400010001')
,0)
DECLARE @PY_C_E21b decimal(19,2)
SET @PY_C_E21b = 
ISNULL(
	(SELECT -SUM(amount) 
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000400010002')
,0)
DECLARE @PY_C_E21c decimal(19,2)
SET @PY_C_E21c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000400010003')
,0)
DECLARE @PY_C_E21 decimal(19,2)
SET @PY_C_E21 = @PY_C_E21a + @PY_C_E21b + @PY_C_E21c
DECLARE @PY_C_E decimal(19,2)
SET @PY_C_E = @PY_C_E21
DECLARE @PY_C_22a decimal(19,2)
SET @PY_C_22a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000500010001')
,0)
DECLARE @PY_C_22b decimal(19,2)
SET @PY_C_22b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000500010002')
,0)
DECLARE @PY_C_22c decimal(19,2)
SET @PY_C_22c = 
ISNULL(
	(SELECT -SUM(amount) 
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'C000500010003')
,0)
DECLARE @PY_C_22 decimal(19,2)
SET @PY_C_22 = @PY_C_22a + @PY_C_22b + @PY_C_22c
DECLARE @PY_TOTCOSTI decimal(19,2)
SET @PY_TOTCOSTI = @PY_C_B + @PY_C_C + @PY_C_D + @PY_C_E + @PY_C_22
 --Sezione RICAVI
DECLARE @PY_R_A1 decimal(19,2)
SET @PY_R_A1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R00010001')
,0)
DECLARE @PY_R_A2 decimal(19,2)
SET @PY_R_A2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R00010002')
,0)
DECLARE @PY_R_A3 decimal(19,2)
SET @PY_R_A3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R00010003')
,0)
DECLARE @PY_R_A4 decimal(19,2)
SET @PY_R_A4 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R00010004')
,0)
DECLARE @PY_R_A5 decimal(19,2)
SET @PY_R_A5 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R00010005')
,0)
DECLARE @PY_R_A decimal(19,2)
SET @PY_R_A = @PY_R_A1 + @PY_R_A2 + @PY_R_A3 + @PY_R_A4 + @PY_R_A5
DECLARE @PY_R_C15a decimal(19,2)
SET @PY_R_C15a = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000200010001')
,0)
DECLARE @PY_R_C15b decimal(19,2)
SET @PY_R_C15b = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000200010002')
,0)
DECLARE @PY_R_C15c decimal(19,2)
SET @PY_R_C15c = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000200010003')
,0)
DECLARE @PY_R_C15 decimal(19,2)
SET @PY_R_C15 = @PY_R_C15a + @PY_R_C15b + @PY_R_C15c
DECLARE @PY_R_C16a1 decimal(19,2)
SET @PY_R_C16a1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R0002000200010001')
,0)
DECLARE @PY_R_C16a2 decimal(19,2)
SET @PY_R_C16a2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R0002000200010002')
,0)
DECLARE @PY_R_C16a3 decimal(19,2)
SET @PY_R_C16a3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R0002000200010003')
,0)
DECLARE @PY_R_C16a4 decimal(19,2)
SET @PY_R_C16a4 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R0002000200010004')
,0)
DECLARE @PY_R_C16a decimal(19,2)
SET @PY_R_C16a = @PY_R_C16a1 + @PY_R_C16a2 + @PY_R_C16a3 + @PY_R_C16a4
DECLARE @PY_R_C16b decimal(19,2)
SET @PY_R_C16b = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000200020002')
,0)
DECLARE @PY_R_C16c decimal(19,2)
SET @PY_R_C16c = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000200020003')
,0)
DECLARE @PY_R_C16d1 decimal(19,2)
SET @PY_R_C16d1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R0002000200040001')
,0)
DECLARE @PY_R_C16d2 decimal(19,2)
SET @PY_R_C16d2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R0002000200040002')
,0)
DECLARE @PY_R_C16d3 decimal(19,2)
SET @PY_R_C16d3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R0002000200040003')
	
,0)
DECLARE @PY_R_C16d4 decimal(19,2)
SET @PY_R_C16d4 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R0002000200040004')
,0)
DECLARE @PY_R_C16d decimal(19,2)
SET @PY_R_C16d = @PY_R_C16d1 + @PY_R_C16d2 + @PY_R_C16d3 + @PY_R_C16d4
DECLARE @PY_R_C16 decimal(19,2)
SET @PY_R_C16 = @PY_R_C16a + @PY_R_C16b + @PY_R_C16c + @PY_R_C16d
DECLARE @PY_R_C17bis decimal(19,2)
SET @PY_R_C17bis = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R00020003')
,0)
DECLARE @PY_R_C decimal(19,2)
SET @PY_R_C = @PY_R_C15 + @PY_R_C16 + @PY_R_C17bis
DECLARE @PY_R_D18a decimal(19,2)
SET @PY_R_D18a = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000300010001')
,0)
DECLARE @PY_R_D18b decimal(19,2)
SET @PY_R_D18b = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000300010002')
,0)
DECLARE @PY_R_D18c decimal(19,2)
SET @PY_R_D18c = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000300010003')
,0)
DECLARE @PY_R_D18 decimal(19,2)
SET @PY_R_D18 = @PY_R_D18a + @PY_R_D18b + @PY_R_D18c
DECLARE @PY_R_D decimal(19,2)
SET @PY_R_D = @PY_R_D18
DECLARE @PY_R_E20a decimal(19,2)
SET @PY_R_E20a = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000400010001')
,0)
DECLARE @PY_R_E20b decimal(19,2)
SET @PY_R_E20b = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000400010002')
,0)
DECLARE @PY_R_E20c decimal(19,2)
SET @PY_R_E20c = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R000400010003')
,0)
DECLARE @PY_R_E20 decimal(19,2)
SET @PY_R_E20 = @PY_R_E20a + @PY_R_E20b + @PY_R_E20c
DECLARE @PY_R_E decimal(19,2)
SET @PY_R_E = @PY_R_E20
DECLARE @PY_R_23 decimal(19,2)
SET @PY_R_23 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk_prec + 'R00050001')
,0)
DECLARE @PY_TOTRICAVI decimal(19,2)
SET @PY_TOTRICAVI = @PY_R_A + @PY_R_C + @PY_R_D + @PY_R_E + @PY_R_23
 --Conto Economico Anno Corrente
DECLARE @sk char(2)
SET @sk = SUBSTRING(CONVERT(varchar(4),@ayear),3,2)
 --Sezione COSTI
DECLARE @C_B6 decimal(19,2)
SET @C_B6 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C00010001')
,0)
DECLARE @C_B7 decimal(19,2)
SET @C_B7 =
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C00010002')
,0)
DECLARE @C_B8 decimal(19,2)
SET @C_B8 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C00010003')
,0)
DECLARE @C_B9a decimal(19,2)
SET @C_B9a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000100040001')
,0)
DECLARE @C_B9b decimal(19,2)
SET @C_B9b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000100040002')
,0)
DECLARE @C_B9c decimal(19,2)
SET @C_B9c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000100040003')
,0)
DECLARE @C_B9d decimal(19,2)
SET @C_B9d = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000100040004')
,0)
DECLARE @C_B9e decimal(19,2)
SET @C_B9e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000100040005')
,0)
DECLARE @C_B9 decimal(19,2)
SET @C_B9 = @C_B9a + @C_B9b + @C_B9c + @C_B9d + @C_B9e
DECLARE @C_B10a decimal(19,2)
SET @C_B10a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000100050001')
,0)
DECLARE @C_B10b decimal(19,2)
SET @C_B10b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000100050002')
,0)
DECLARE @C_B10c decimal(19,2)
SET @C_B10c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000100050003')
,0)
DECLARE @C_B10d decimal(19,2)
SET @C_B10d = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000100050004')
,0)
DECLARE @C_B10 decimal(19,2)
SET @C_B10 = @C_B10a + @C_B10b + @C_B10c + @C_B10d
DECLARE @C_B11 decimal(19,2)
SET @C_B11 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C00010006')
,0)
DECLARE @C_B12 decimal(19,2)
SET @C_B12 =
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C00010007')
,0)
DECLARE @C_B13 decimal(19,2)
SET @C_B13 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C00010008')
,0)
DECLARE @C_B14 decimal(19,2)
SET @C_B14 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C00010009')
,0)
DECLARE @C_B decimal(19,2)
SET @C_B = @C_B6 + @C_B7 + @C_B8 + @C_B9 + @C_B10 + @C_B11 + @C_B12 + @C_B13 + @C_B14
 --Attenzione i COSTI presenti nella lettera C non devono essere cambiati di segno perché sono presenti nella stessa sezione dei ricavi
DECLARE @C_C17a decimal(19,2)
SET @C_C17a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000200010001')
,0)
DECLARE @C_C17b decimal(19,2)
SET @C_C17b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000200010002')
,0)
DECLARE @C_C17c decimal(19,2)
SET @C_C17c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000200010003')
,0)
DECLARE @C_C17d decimal(19,2)
SET @C_C17d = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000200010004')
,0)
DECLARE @C_C17 decimal(19,2)
SET @C_C17 = @C_C17a + @C_C17b + @C_C17c + @C_C17d
DECLARE @C_C decimal(19,2)
SET @C_C = @C_C17
 --Attenzione i COSTI presenti nella lettera D non devono essere cambiati di segno perché sono presenti nella stessa sezione dei ricavi
DECLARE @C_D19a decimal(19,2)
SET @C_D19a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000300010001')
,0)
DECLARE @C_D19b decimal(19,2)
SET @C_D19b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000300010002')
,0)
DECLARE @C_D19c decimal(19,2)
SET @C_D19c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000300010003')
,0)
DECLARE @C_D19 decimal(19,2)
SET @C_D19 = @C_D19a + @C_D19b + @C_D19c
DECLARE @C_D decimal(19,2)
SET @C_D = @C_D19
 --Attenzione i COSTI presenti nella lettera E non devono essere cambiati di segno perché sono presenti nella stessa sezione dei ricavi
DECLARE @C_E21a decimal(19,2)
SET @C_E21a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000400010001')
,0)
DECLARE @C_E21b decimal(19,2)
SET @C_E21b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000400010002')
,0)
DECLARE @C_E21c decimal(19,2)
SET @C_E21c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000400010003')
,0)
DECLARE @C_E21 decimal(19,2)
SET @C_E21 = @C_E21a + @C_E21b + @C_E21c
DECLARE @C_E decimal(19,2)
SET @C_E = @C_E21
DECLARE @C_22a decimal(19,2)
SET @C_22a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000500010001')
,0)
DECLARE @C_22b decimal(19,2)
SET @C_22b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000500010002')
,0)
DECLARE @C_22c decimal(19,2)
SET @C_22c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'C000500010003')
,0)
DECLARE @C_22 decimal(19,2)
SET @C_22 = @C_22a + @C_22b + @C_22c
DECLARE @TOTCOSTI decimal(19,2)
SET @TOTCOSTI = @C_B + @C_C + @C_D + @C_E + @C_22
 --Sezione RICAVI
DECLARE @R_A1 decimal(19,2)
SET @R_A1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R00010001')
,0)
DECLARE @R_A2 decimal(19,2)
SET @R_A2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R00010002')
,0)
DECLARE @R_A3 decimal(19,2)
SET @R_A3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R00010003')
,0)
DECLARE @R_A4 decimal(19,2)
SET @R_A4 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R00010004')
,0)
DECLARE @R_A5 decimal(19,2)
SET @R_A5 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R00010005')
,0)
DECLARE @R_A decimal(19,2)
SET @R_A = @R_A1 + @R_A2 + @R_A3 + @R_A4 + @R_A5
DECLARE @R_C15a decimal(19,2)
SET @R_C15a = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000200010001')
,0)
DECLARE @R_C15b decimal(19,2)
SET @R_C15b = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000200010002')
,0)
DECLARE @R_C15c decimal(19,2)
SET @R_C15c = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000200010003')
,0)
DECLARE @R_C15 decimal(19,2)
SET @R_C15 = @R_C15a + @R_C15b + @R_C15c
DECLARE @R_C16a1 decimal(19,2)
SET @R_C16a1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R0002000200010001')
,0)
DECLARE @R_C16a2 decimal(19,2)
SET @R_C16a2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R0002000200010002')
,0)
DECLARE @R_C16a3 decimal(19,2)
SET @R_C16a3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R0002000200010003')
,0)
DECLARE @R_C16a4 decimal(19,2)
SET @R_C16a4 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R0002000200010004')
,0)
DECLARE @R_C16a decimal(19,2)
SET @R_C16a = @R_C16a1 + @R_C16a2 + @R_C16a3 + @R_C16a4
DECLARE @R_C16b decimal(19,2)
SET @R_C16b = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000200020002')
,0)
DECLARE @R_C16c decimal(19,2)
SET @R_C16c = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000200020003')
,0)
DECLARE @R_C16d1 decimal(19,2)
SET @R_C16d1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R0002000200040001')
,0)
DECLARE @R_C16d2 decimal(19,2)
SET @R_C16d2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R0002000200040002')
,0)
DECLARE @R_C16d3 decimal(19,2)
SET @R_C16d3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R0002000200040003')
,0)
DECLARE @R_C16d4 decimal(19,2)
SET @R_C16d4 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R0002000200040004')
,0)
DECLARE @R_C16d decimal(19,2)
SET @R_C16d = @R_C16d1 + @R_C16d2 + @R_C16d3 + @R_C16d4
DECLARE @R_C16 decimal(19,2)
SET @R_C16 = @R_C16a + @R_C16b + @R_C16c + @R_C16d
DECLARE @R_C17bis decimal(19,2)
SET @R_C17bis = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop	
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R00020003')
,0)
DECLARE @R_C decimal(19,2)
SET @R_C = @R_C15 + @R_C16 + @R_C17bis
DECLARE @R_D18a decimal(19,2)
SET @R_D18a = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000300010001')
,0)
DECLARE @R_D18b decimal(19,2)
SET @R_D18b = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000300010002')
,0)
DECLARE @R_D18c decimal(19,2)
SET @R_D18c = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000300010003')
,0)
DECLARE @R_D18 decimal(19,2)
SET @R_D18 = @R_D18a + @R_D18b + @R_D18c
DECLARE @R_D decimal(19,2)
SET @R_D = @R_D18
DECLARE @R_E20a decimal(19,2)
SET @R_E20a = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000400010001')
,0)
DECLARE @R_E20b decimal(19,2)
SET @R_E20b = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000400010002')
,0)
DECLARE @R_E20c decimal(19,2)
SET @R_E20c = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R000400010003')
,0)
DECLARE @R_E20 decimal(19,2)
SET @R_E20 = @R_E20a + @R_E20b + @R_E20c
DECLARE @R_E decimal(19,2)
SET @R_E = @R_E20
DECLARE @R_23 decimal(19,2)
SET @R_23 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.idplaccount = @sk + 'R00050001')
,0)
DECLARE @TOTRICAVI decimal(19,2)
SET @TOTRICAVI = @R_A + @R_C + @R_D + @R_E + @R_23
SELECT
@ayear AS ayear,
@PY_TOTCOSTI AS PY_TOTCOSTI,
@PY_C_B AS PY_C_B,
@PY_C_B6 AS PY_C_B6, @PY_C_B7 AS PY_C_B7, @PY_C_B8 AS PY_C_B8,
@PY_C_B9 AS PY_C_B9,
@PY_C_B9a AS PY_C_B9a, @PY_C_B9b AS PY_C_B9b, @PY_C_B9c AS PY_C_B9c, @PY_C_B9d AS PY_C_B9d, @PY_C_B9e AS PY_C_B9e,
@PY_C_B10 AS PY_C_B10,
@PY_C_B10a AS PY_C_B10a, @PY_C_B10b AS PY_C_B10b, @PY_C_B10c AS PY_C_B10c, @PY_C_B10d AS PY_C_B10d,
@PY_C_B11 AS PY_C_B11, @PY_C_B12 AS PY_C_B12, @PY_C_B13 AS PY_C_B13, @PY_C_B14 AS PY_C_B14,
@PY_C_C AS PY_C_C,
@PY_C_C17 AS PY_C_C17,
@PY_C_C17a AS PY_C_C17a, @PY_C_C17b AS PY_C_C17b, @PY_C_C17c AS PY_C_C17c, @PY_C_C17d AS PY_C_C17d,
@PY_C_D AS PY_C_D,
@PY_C_D19 AS PY_C_D19,
@PY_C_D19a AS PY_C_D19a, @PY_C_D19b AS PY_C_D19b, @PY_C_D19c AS PY_C_D19c, 
@PY_C_E AS PY_C_E,
@PY_C_E21 AS PY_C_E21,
@PY_C_E21a AS PY_C_E21a, @PY_C_E21b AS PY_C_E21b, @PY_C_E21c AS PY_C_E21c, 
@PY_C_22 AS PY_C_22,
@PY_C_22a AS PY_C_22a, @PY_C_22b AS PY_C_22b, @PY_C_22c AS PY_C_22c, 
@PY_TOTRICAVI AS PY_TOTRICAVI,
@PY_R_A AS PY_R_A,
@PY_R_A1 AS PY_R_A1, @PY_R_A2 AS PY_R_A2, @PY_R_A3 AS PY_R_A3, @PY_R_A4 AS PY_R_A4, @PY_R_A5 AS PY_R_A5,
@PY_R_C AS PY_R_C,
@PY_R_C15 AS PY_R_C15,
@PY_R_C15a AS PY_R_C15a, @PY_R_C15b AS PY_R_C15b, @PY_R_C15c AS PY_R_C15c,
@PY_R_C16 AS PY_R_C16,
@PY_R_C16a AS PY_R_C16a,
@PY_R_C16a1 AS PY_R_C16a1, @PY_R_C16a2 AS PY_R_C16a2, @PY_R_C16a3 AS PY_R_C16a3, @PY_R_C16a4 AS PY_R_C16a4,
@PY_R_C16b AS PY_R_C16b,
@PY_R_C16c AS PY_R_C16c,
@PY_R_C16d AS PY_R_C16d,
@PY_R_C16d1 AS PY_R_C16d1, @PY_R_C16d2 AS PY_R_C16d2, @PY_R_C16d3 AS PY_R_C16d3, @PY_R_C16d4 AS PY_R_C16d4,
@PY_R_C17bis AS PY_R_C17bis,
@PY_R_D AS PY_R_D,
@PY_R_D18 AS PY_R_D18,
@PY_R_D18a AS PY_R_D18a, @PY_R_D18b AS PY_R_D18b, @PY_R_D18c AS PY_R_D18c,
@PY_R_E AS PY_R_E,
@PY_R_E20 AS PY_R_E20,
@PY_R_E20a AS PY_R_E20a, @PY_R_E20b AS PY_R_E20b, @PY_R_E20c AS PY_R_E20c,
@PY_R_23 AS PY_R_23,
@TOTCOSTI AS TOTCOSTI,
@C_B AS C_B,
@C_B6 AS C_B6, @C_B7 AS C_B7, @C_B8 AS C_B8,
@C_B9 AS C_B9,
@C_B9a AS C_B9a, @C_B9b AS C_B9b, @C_B9c AS C_B9c, @C_B9d AS C_B9d, @C_B9e AS C_B9e,
@C_B10 AS C_B10,
@C_B10a AS C_B10a, @C_B10b AS C_B10b, @C_B10c AS C_B10c, @C_B10d AS C_B10d,
@C_B11 AS C_B11, @C_B12 AS C_B12, @C_B13 AS C_B13, @C_B14 AS C_B14,
@C_C AS C_C,
@C_C17 AS C_C17,
@C_C17a AS C_C17a, @C_C17b AS C_C17b, @C_C17c AS C_C17c, @C_C17d AS C_C17d,
@C_D AS C_D,
@C_D19 AS C_D19,
@C_D19a AS C_D19a, @C_D19b AS C_D19b, @C_D19c AS C_D19c, 
@C_E AS C_E,
@C_E21 AS C_E21,
@C_E21a AS C_E21a, @C_E21b AS C_E21b, @C_E21c AS C_E21c, 
@C_22 AS C_22,
@C_22a AS C_22a, @C_22b AS C_22b, @C_22c AS C_22c,
@TOTRICAVI AS TOTRICAVI,
@R_A AS R_A,
@R_A1 AS R_A1, @R_A2 AS R_A2, @R_A3 AS R_A3, @R_A4 AS R_A4, @R_A5 AS R_A5,
@R_C AS R_C,
@R_C15 AS R_C15,
@R_C15a AS R_C15a, @R_C15b AS R_C15b, @R_C15c AS R_C15c,
@R_C16 AS R_C16,
@R_C16a AS R_C16a,
@R_C16a1 AS R_C16a1, @R_C16a2 AS R_C16a2, @R_C16a3 AS R_C16a3, @R_C16a4 AS R_C16a4,
@R_C16b AS R_C16b,
@R_C16c AS R_C16c,
@R_C16d AS R_C16d,
@R_C16d1 AS R_C16d1, @R_C16d2 AS R_C16d2, @R_C16d3 AS R_C16d3, @R_C16d4 AS R_C16d4,
@R_C17bis AS R_C17bis,
@R_D AS R_D,
@R_D18 AS R_D18,
@R_D18a AS R_D18a, @R_D18b AS R_D18b, @R_D18c AS R_D18c,
@R_E AS R_E,
@R_E20 AS R_E20,
@R_E20a AS R_E20a, @R_E20b AS R_E20b, @R_E20c AS R_E20c,
@R_23 AS R_23
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

