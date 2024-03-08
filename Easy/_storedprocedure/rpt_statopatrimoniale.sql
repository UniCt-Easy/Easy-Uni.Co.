
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_statopatrimoniale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_statopatrimoniale]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [rpt_statopatrimoniale]
(
	@ayear int,
	@start datetime,
	@stop datetime
)
AS BEGIN
--setuser 'amm'
-- Stato Patrimoniale Anno Precedente
DECLARE @firstdayPY datetime
DECLARE @lastdayPY datetime
SET @firstdayPY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear-1),105)
SET @lastdayPY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)
DECLARE @sk_prec char(2)
SET @sk_prec = SUBSTRING(CONVERT(varchar(4),@ayear-1),3,2)

DECLARE @PY_A_A decimal(19,2)
SET @PY_A_A = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	--  ESCLUDO I CONTI D'ORDINE EW LE SCRITTURE DI EPILOGO
	AND entry.identrykind not in (6,11,12)	
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A0001')
,0)
DECLARE @PY_A_BI1 decimal(19,2)
SET @PY_A_BI1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) 
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200010001')
,0)
DECLARE @PY_A_BI2 decimal(19,2)
SET @PY_A_BI2 =
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) 
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200010002')
,0)
DECLARE @PY_A_BI3 decimal(19,2)
SET @PY_A_BI3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200010003')
,0)
DECLARE @PY_A_BI4 decimal(19,2)
SET @PY_A_BI4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000200010004')
,0)
DECLARE @PY_A_BI5 decimal(19,2)
SET @PY_A_BI5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000200010005')
,0)
DECLARE @PY_A_BI6 decimal(19,2)
SET @PY_A_BI6 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200010006')
,0)
DECLARE @PY_A_BI7 decimal(19,2)
SET @PY_A_BI7 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200010007')
,0)
DECLARE @PY_A_BI decimal(19,2)
SET @PY_A_BI = @PY_A_BI1 + @PY_A_BI2 + @PY_A_BI3 + @PY_A_BI4 + @PY_A_BI5 + @PY_A_BI6 + @PY_A_BI7
DECLARE @PY_A_BII1 decimal(19,2)
SET @PY_A_BII1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200020001')
,0)
DECLARE @PY_A_BII2 decimal(19,2)
SET @PY_A_BII2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200020002')
,0)
DECLARE @PY_A_BII3 decimal(19,2)
SET @PY_A_BII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200020003')
,0)

DECLARE @PY_A_BII4 decimal(19,2)
SET @PY_A_BII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200020004')
,0)
DECLARE @PY_A_BII5 decimal(19,2)
SET @PY_A_BII5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200020005')
,0)
DECLARE @PY_A_BII decimal(19,2)
SET @PY_A_BII = @PY_A_BII1 + @PY_A_BII2 + @PY_A_BII3 + @PY_A_BII4 + @PY_A_BII5
DECLARE @PY_A_BIII1a decimal(19,2)
SET @PY_A_BIII1a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A0002000300010001')
,0)
DECLARE @PY_A_BIII1b decimal(19,2)
SET @PY_A_BIII1b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A0002000300010002')
,0)
DECLARE @PY_A_BIII1c decimal(19,2)
SET @PY_A_BIII1c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A0002000300010003')
,0)
DECLARE @PY_A_BIII1d decimal(19,2)
SET @PY_A_BIII1d = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A0002000300010004')
,0)
DECLARE @PY_A_BIII1 decimal(19,2)
SET @PY_A_BIII1 = @PY_A_BIII1a + @PY_A_BIII1b + @PY_A_BIII1c + @PY_A_BIII1d
DECLARE @PY_A_BIII2a decimal(19,2)
SET @PY_A_BIII2a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A0002000300020001')
,0)
DECLARE @PY_A_BIII2b decimal(19,2)
SET @PY_A_BIII2b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A0002000300020002')
,0)
DECLARE @PY_A_BIII2c decimal(19,2)
SET @PY_A_BIII2c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A0002000300020003')
,0)
DECLARE @PY_A_BIII2d decimal(19,2)
SET @PY_A_BIII2d = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A0002000300020004')
,0)
DECLARE @PY_A_BIII2 decimal(19,2)
SET @PY_A_BIII2 = @PY_A_BIII2a + @PY_A_BIII2b + @PY_A_BIII2c + @PY_A_BIII2d
DECLARE @PY_A_BIII3 decimal(19,2)
SET @PY_A_BIII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200030003')
,0)
DECLARE @PY_A_BIII4 decimal(19,2)
SET @PY_A_BIII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000200030004')
,0)
DECLARE @PY_A_BIII decimal(19,2)
SET @PY_A_BIII = @PY_A_BIII1 + @PY_A_BIII2 + @PY_A_BIII3 + @PY_A_BIII4
DECLARE @PY_A_B decimal(19,2)
SET @PY_A_B = @PY_A_BI + @PY_A_BII + @PY_A_BIII
DECLARE @PY_A_CI1 decimal(19,2)
SET @PY_A_CI1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000300010001')
,0)
DECLARE @PY_A_CI2 decimal(19,2)
SET @PY_A_CI2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000300010002')
,0)
DECLARE @PY_A_CI3 decimal(19,2)
SET @PY_A_CI3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000300010003')
,0)
DECLARE @PY_A_CI4 decimal(19,2)
SET @PY_A_CI4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000300010004')
,0)
DECLARE @PY_A_CI5 decimal(19,2)
SET @PY_A_CI5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000300010005')
,0)
DECLARE @PY_A_CI decimal(19,2)
SET @PY_A_CI = @PY_A_CI1 + @PY_A_CI2 + @PY_A_CI3 + @PY_A_CI4 + @PY_A_CI5
DECLARE @PY_A_CII1 decimal(19,2)
SET @PY_A_CII1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.idpatrimony = @sk_prec + 'A000300020001')
,0)
DECLARE @PY_A_CII2 decimal(19,2)
SET @PY_A_CII2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300020002')
,0)
DECLARE @PY_A_CII3 decimal(19,2)
SET @PY_A_CII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300020003')
,0)
DECLARE @PY_A_CII4 decimal(19,2)
SET @PY_A_CII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300020004')
,0)

DECLARE @PY_A_CII4bis decimal(19,2)
SET @PY_A_CII4bis = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300020005')
,0)
DECLARE @PY_A_CII4ter decimal(19,2)
SET @PY_A_CII4ter = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300020006')
,0)
--DECLARE @PY_A_CII4 decimal(19,2) --maria
--SET @PY_A_CII4 = @PY_A_CII4bis + @PY_A_CII4ter
DECLARE @PY_A_CII5 decimal(19,2)
SET @PY_A_CII5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300020007')
,0)
DECLARE @PY_A_CII decimal(19,2)
SET @PY_A_CII = @PY_A_CII1 + @PY_A_CII2 + @PY_A_CII3 + @PY_A_CII4 + @PY_A_CII4bis + @PY_A_CII4ter + @PY_A_CII5 --maria
DECLARE @PY_A_CIII1 decimal(19,2)
SET @PY_A_CIII1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300030001')
,0)
DECLARE @PY_A_CIII2 decimal(19,2)
SET @PY_A_CIII2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300030002')
,0)
DECLARE @PY_A_CIII3 decimal(19,2)
SET @PY_A_CIII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300030003')
,0)
DECLARE @PY_A_CIII4 decimal(19,2)
SET @PY_A_CIII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300030004')
,0)
DECLARE @PY_A_CIII5 decimal(19,2)
SET @PY_A_CIII5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300030005')
,0)
DECLARE @PY_A_CIII6 decimal(19,2)
SET @PY_A_CIII6 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300030006')
,0)
DECLARE @PY_A_CIII decimal(19,2)
SET @PY_A_CIII = @PY_A_CIII1 + @PY_A_CIII2 + @PY_A_CIII3 + @PY_A_CIII4 + @PY_A_CIII5 + @PY_A_CIII6
DECLARE @PY_A_CIV1 decimal(19,2)
SET @PY_A_CIV1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300040001')
,0)
DECLARE @PY_A_CIV2 decimal(19,2)
SET @PY_A_CIV2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300040002')
,0)
DECLARE @PY_A_CIV3 decimal(19,2)
SET @PY_A_CIV3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A000300040003')
,0)
DECLARE @PY_A_CIV decimal(19,2)
SET @PY_A_CIV = @PY_A_CIV1 + @PY_A_CIV2 + @PY_A_CIV3
DECLARE @PY_A_C decimal(19,2)
SET @PY_A_C = @PY_A_CI + @PY_A_CII + @PY_A_CIII + @PY_A_CIV
DECLARE @PY_A_D decimal(19,2)
SET @PY_A_D = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'A0004')
,0)
DECLARE @PY_TOTATTIVO decimal(19,2)
SET @PY_TOTATTIVO = @PY_A_A + @PY_A_B + @PY_A_C + @PY_A_D
-------------------------------------------------------------------------
-----------------------  	PASSIVO          ------------------------
-------------------------------------------------------------------------
DECLARE @PY_P_AI decimal(19,2)
SET @PY_P_AI = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P00010001')
,0)
DECLARE @PY_P_AII decimal(19,2)
SET @PY_P_AII = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P00010002')
,0)
DECLARE @PY_P_AIII decimal(19,2)
SET @PY_P_AIII = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P00010003')
,0)
DECLARE @PY_P_AIV decimal(19,2)
SET @PY_P_AIV = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P00010004')
,0)
DECLARE @PY_P_AV decimal(19,2)
SET @PY_P_AV = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P00010005')
,0)
DECLARE @PY_P_AVI decimal(19,2)
SET @PY_P_AVI = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P00010006')
,0)
DECLARE @PY_P_AVII decimal(19,2)
SET @PY_P_AVII = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P00010007')
,0)
DECLARE @PY_P_AVIII decimal(19,2)
SET @PY_P_AVIII = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P00010008')
,0)
/*DECLARE @PY_P_AIX decimal(19,2)
SET @PY_P_AIX = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND patrimony.idpatrimony = @sk_prec + 'P00010009')
,0)*/
DECLARE @PY_P_A decimal(19,2)
SET @PY_P_A = @PY_P_AI + @PY_P_AII + @PY_P_AIII + @PY_P_AIV + @PY_P_AV + @PY_P_AVI + @PY_P_AVII + @PY_P_AVIII  -- + @PY_P_AIX
DECLARE @PY_P_B1 decimal(19,2)
SET @PY_P_B1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000200010001')
,0)
DECLARE @PY_P_B2 decimal(19,2)
SET @PY_P_B2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000200010002')
,0)
DECLARE @PY_P_B3 decimal(19,2)
SET @PY_P_B3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000200010003')
,0)
DECLARE @PY_P_B decimal(19,2)
SET @PY_P_B = @PY_P_B1 + @PY_P_B2 + @PY_P_B3
DECLARE @PY_P_C decimal(19,2)
SET @PY_P_C = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P0003')
,0)
DECLARE @PY_P_D1 decimal(19,2)
SET @PY_P_D1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010001')
,0)
DECLARE @PY_P_D2 decimal(19,2)
SET @PY_P_D2 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010002')
,0)
DECLARE @PY_P_D3 decimal(19,2)
SET @PY_P_D3 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010003')
,0)
DECLARE @PY_P_D4 decimal(19,2)
SET @PY_P_D4 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010004')
,0)
DECLARE @PY_P_D5 decimal(19,2)
SET @PY_P_D5 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010005')
,0)
DECLARE @PY_P_D6 decimal(19,2)
SET @PY_P_D6 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010006')
,0)
DECLARE @PY_P_D7 decimal(19,2)
SET @PY_P_D7 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010007')
,0)
DECLARE @PY_P_D8 decimal(19,2)
SET @PY_P_D8 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010008')
,0)
DECLARE @PY_P_D9 decimal(19,2)
SET @PY_P_D9 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010009')
,0)
DECLARE @PY_P_D10 decimal(19,2)
SET @PY_P_D10 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010010')
,0)
DECLARE @PY_P_D11 decimal(19,2)
SET @PY_P_D11 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010011')
,0)
DECLARE @PY_P_D12 decimal(19,2)
SET @PY_P_D12 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010012')
,0)
DECLARE @PY_P_D13 decimal(19,2)
SET @PY_P_D13 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010013')
,0)
DECLARE @PY_P_D14 decimal(19,2)
SET @PY_P_D14 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P000400010014')
,0)
DECLARE @PY_P_D decimal(19,2)
SET @PY_P_D = @PY_P_D1 + @PY_P_D2 + @PY_P_D3 + @PY_P_D4 + @PY_P_D5 + @PY_P_D6 + @PY_P_D7 + @PY_P_D8 + @PY_P_D9 + @PY_P_D10 + @PY_P_D11 + @PY_P_D12 + @PY_P_D13 + @PY_P_D14
DECLARE @PY_P_E decimal(19,2)
SET @PY_P_E =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk_prec + 'P0005')
,0)
DECLARE @PY_TOTPASSIVO decimal(19,2)
SET @PY_TOTPASSIVO = @PY_P_A + @PY_P_B + @PY_P_C + @PY_P_D + @PY_P_E

DECLARE @PY_P_AIX decimal(19,2)
SET @PY_P_AIX = @PY_TOTATTIVO - @PY_TOTPASSIVO
--Calcolo utile/perdita di esercizio --maria
SET @PY_P_A = @PY_P_A + @PY_P_AIX
SET @PY_TOTPASSIVO = @PY_TOTPASSIVO +  @PY_P_AIX 

-- Stato Patrimoniale Anno Corrente
DECLARE @sk char(2)
SET @sk = SUBSTRING(CONVERT(varchar(4),@ayear),3,2)

DECLARE @A_A decimal(19,2)
SET @A_A= 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A0001')
,0)
DECLARE @A_BI1 decimal(19,2)
SET @A_BI1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200010001')
,0)
DECLARE @A_BI2 decimal(19,2)
SET @A_BI2 =
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200010002')
,0)
DECLARE @A_BI3 decimal(19,2)
SET @A_BI3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200010003')
,0)
DECLARE @A_BI4 decimal(19,2)
SET @A_BI4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200010004')
,0)
DECLARE @A_BI5 decimal(19,2)
SET @A_BI5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200010005')
,0)
DECLARE @A_BI6 decimal(19,2)
SET @A_BI6 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200010006')
,0)
DECLARE @A_BI7 decimal(19,2)
SET @A_BI7 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200010007')
,0)
DECLARE @A_BI decimal(19,2)
SET @A_BI = @A_BI1 + @A_BI2 + @A_BI3 + @A_BI4 + @A_BI5 + @A_BI6 + @A_BI7
DECLARE @A_BII1 decimal(19,2)
SET @A_BII1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200020001')
,0)
DECLARE @A_BII2 decimal(19,2)
SET @A_BII2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200020002')
,0)
DECLARE @A_BII3 decimal(19,2)
SET @A_BII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200020003')
,0)

DECLARE @A_BII4 decimal(19,2)
SET @A_BII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200020004')
,0)
DECLARE @A_BII5 decimal(19,2)
SET @A_BII5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200020005')
,0)
DECLARE @A_BII decimal(19,2)
SET @A_BII = @A_BII1 + @A_BII2 + @A_BII3 + @A_BII4 + @A_BII5
DECLARE @A_BIII1a decimal(19,2)
SET @A_BIII1a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A0002000300010001')
,0)
DECLARE @A_BIII1b decimal(19,2)
SET @A_BIII1b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A0002000300010002')
,0)
DECLARE @A_BIII1c decimal(19,2)
SET @A_BIII1c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A0002000300010003')
,0)
DECLARE @A_BIII1d decimal(19,2)
SET @A_BIII1d = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A0002000300010004')
,0)
DECLARE @A_BIII1 decimal(19,2)
SET @A_BIII1 = @A_BIII1a + @A_BIII1b + @A_BIII1c + @A_BIII1d
DECLARE @A_BIII2a decimal(19,2)
SET @A_BIII2a = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A0002000300020001')
,0)
DECLARE @A_BIII2b decimal(19,2)
SET @A_BIII2b = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A0002000300020002')
,0)
DECLARE @A_BIII2c decimal(19,2)
SET @A_BIII2c = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A0002000300020003')
,0)
DECLARE @A_BIII2d decimal(19,2)
SET @A_BIII2d = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A0002000300020004')
,0)
DECLARE @A_BIII2 decimal(19,2)
SET @A_BIII2 = @A_BIII2a + @A_BIII2b + @A_BIII2c + @A_BIII2d
DECLARE @A_BIII3 decimal(19,2)
SET @A_BIII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200030003')
,0)
DECLARE @A_BIII4 decimal(19,2)
SET @A_BIII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000200030004')
,0)
DECLARE @A_BIII decimal(19,2)
SET @A_BIII = @A_BIII1 + @A_BIII2 + @A_BIII3 + @A_BIII4
DECLARE @A_B decimal(19,2)
SET @A_B = @A_BI + @A_BII + @A_BIII
DECLARE @A_CI1 decimal(19,2)
SET @A_CI1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.idpatrimony = @sk + 'A000300010001')
,0)
DECLARE @A_CI2 decimal(19,2)
SET @A_CI2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300010002')
,0)
DECLARE @A_CI3 decimal(19,2)
SET @A_CI3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300010003')
,0)
DECLARE @A_CI4 decimal(19,2)
SET @A_CI4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300010004')
,0)
DECLARE @A_CI5 decimal(19,2)
SET @A_CI5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300010005')
,0)
DECLARE @A_CI decimal(19,2)
SET @A_CI = @A_CI1 + @A_CI2 + @A_CI3 + @A_CI4 + @A_CI5
DECLARE @A_CII1 decimal(19,2)
SET @A_CII1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300020001')
,0)
DECLARE @A_CII2 decimal(19,2)
SET @A_CII2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300020002')
,0)
DECLARE @A_CII3 decimal(19,2)
SET @A_CII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300020003')
,0)

DECLARE @A_CII4 decimal(19,2)
SET @A_CII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300020004')
,0)
DECLARE @A_CII4bis decimal(19,2)
SET @A_CII4bis = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300020005')
,0)
DECLARE @A_CII4ter decimal(19,2)
SET @A_CII4ter = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300020006')
,0)

DECLARE @A_CII5 decimal(19,2)
SET @A_CII5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300020007')
,0)
DECLARE @A_CII decimal(19,2)
SET @A_CII = @A_CII1 + @A_CII2 + @A_CII3 + @A_CII4 + @A_CII4bis + @A_CII4ter + @A_CII5
DECLARE @A_CIII1 decimal(19,2)
SET @A_CIII1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300030001')
,0)
DECLARE @A_CIII2 decimal(19,2)
SET @A_CIII2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO	
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300030002')
,0)
DECLARE @A_CIII3 decimal(19,2)
SET @A_CIII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO 	
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300030003')
,0)
DECLARE @A_CIII4 decimal(19,2)
SET @A_CIII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO	
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300030004')
,0)
DECLARE @A_CIII5 decimal(19,2)
SET @A_CIII5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300030005')
,0)
DECLARE @A_CIII6 decimal(19,2)
SET @A_CIII6 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300030006')
,0)
DECLARE @A_CIII decimal(19,2)
SET @A_CIII = @A_CIII1 + @A_CIII2 + @A_CIII3 + @A_CIII4 + @A_CIII5 + @A_CIII6
DECLARE @A_CIV1 decimal(19,2)
SET @A_CIV1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300040001')
,0)
DECLARE @A_CIV2 decimal(19,2)
SET @A_CIV2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300040002')
,0)
DECLARE @A_CIV3 decimal(19,2)
SET @A_CIV3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A000300040003')
,0)
DECLARE @A_CIV decimal(19,2)
SET @A_CIV = @A_CIV1 + @A_CIV2 + @A_CIV3
DECLARE @A_C decimal(19,2)
SET @A_C = @A_CI + @A_CII + @A_CIII + @A_CIV
DECLARE @A_D decimal(19,2)
SET @A_D = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'A0004')
,0)
DECLARE @TOTATTIVO decimal(19,2)
SET @TOTATTIVO = @A_A + @A_B + @A_C + @A_D
DECLARE @P_AI decimal(19,2)
SET @P_AI = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P00010001')
,0)
DECLARE @P_AII decimal(19,2)
SET @P_AII = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P00010002')
,0)
DECLARE @P_AIII decimal(19,2)
SET @P_AIII = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P00010003')
,0)
DECLARE @P_AIV decimal(19,2)
SET @P_AIV = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P00010004')
,0)
DECLARE @P_AV decimal(19,2)
SET @P_AV = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P00010005')
,0)
DECLARE @P_AVI decimal(19,2)
SET @P_AVI = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P00010006')
,0)
DECLARE @P_AVII decimal(19,2)
SET @P_AVII = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P00010007')
,0)
DECLARE @P_AVIII decimal(19,2)
SET @P_AVIII = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P00010008')
,0)
/*DECLARE @P_AIX decimal(19,2)
SET @P_AIX = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND patrimony.idpatrimony = @sk + 'P00010009')
,0)*/
DECLARE @P_A decimal(19,2)
SET @P_A = @P_AI + @P_AII + @P_AIII + @P_AIV + @P_AV + @P_AVI + @P_AVII + @P_AVIII -- + @P_AIX
DECLARE @P_B1 decimal(19,2)
SET @P_B1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000200010001')
,0)
DECLARE @P_B2 decimal(19,2)
SET @P_B2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000200010002')
,0)
DECLARE @P_B3 decimal(19,2)
SET @P_B3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000200010003')
,0)
DECLARE @P_B decimal(19,2)
SET @P_B = @P_B1 + @P_B2 + @P_B3
DECLARE @P_C decimal(19,2)
SET @P_C = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P0003')
,0)
DECLARE @P_D1 decimal(19,2)
SET @P_D1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010001')
,0)
DECLARE @P_D2 decimal(19,2)
SET @P_D2 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010002')
,0)
DECLARE @P_D3 decimal(19,2)
SET @P_D3 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010003')
,0)
DECLARE @P_D4 decimal(19,2)
SET @P_D4 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010004')
,0)
DECLARE @P_D5 decimal(19,2)
SET @P_D5 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010005')
,0)
DECLARE @P_D6 decimal(19,2)
SET @P_D6 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010006')
,0)
DECLARE @P_D7 decimal(19,2)
SET @P_D7 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010007')
,0)
DECLARE @P_D8 decimal(19,2)
SET @P_D8 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010008')
,0)
DECLARE @P_D9 decimal(19,2)
SET @P_D9 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010009')
,0)
DECLARE @P_D10 decimal(19,2)
SET @P_D10 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010010')
,0)
DECLARE @P_D11 decimal(19,2)
SET @P_D11 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010011')
,0)
DECLARE @P_D12 decimal(19,2)
SET @P_D12 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010012')
,0)
DECLARE @P_D13 decimal(19,2)
SET @P_D13 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010013')
,0)
DECLARE @P_D14 decimal(19,2)
SET @P_D14 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P000400010014')
,0)
DECLARE @P_D decimal(19,2)
SET @P_D = @P_D1 + @P_D2 + @P_D3 + @P_D4 + @P_D5 + @P_D6 + @P_D7 + @P_D8 + @P_D9 + @P_D10 + @P_D11 + @P_D12 + @P_D13 + @P_D14
DECLARE @P_E decimal(19,2)
SET @P_E =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)
	AND patrimony.idpatrimony = @sk + 'P0005')
,0)
/*DECLARE @P_AIX decimal(19,2)
SET @P_AIX = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND patrimony.idpatrimony = @sk + 'P00010009')
,0)*/

DECLARE @TOTPASSIVO decimal(19,2)
SET @TOTPASSIVO = @P_A + @P_B + @P_C + @P_D + @P_E
--Calcolo utile/perdita di esercizio
DECLARE @P_AIX decimal(19,2)
SET @P_AIX = @TOTATTIVO - @TOTPASSIVO
SET @P_A = @P_A + @P_AIX
SET @TOTPASSIVO = @TOTPASSIVO +  @P_AIX 
SELECT
@ayear AS ayear,
@PY_TOTATTIVO AS PY_TOTATTIVO,
@PY_A_A AS PY_A_A,
@PY_A_B AS PY_A_B,
@PY_A_BI AS PY_A_BI,
@PY_A_BI1 AS PY_A_BI1, @PY_A_BI2 AS PY_A_BI2, @PY_A_BI3 AS PY_A_BI3, @PY_A_BI4 AS PY_A_BI4,
@PY_A_BI5 AS PY_A_BI5, @PY_A_BI6 AS PY_A_BI6, @PY_A_BI7 AS PY_A_BI7,
@PY_A_BII AS PY_A_BII,
@PY_A_BII1 AS PY_A_BII1, @PY_A_BII2 AS PY_A_BII2, @PY_A_BII3 AS PY_A_BII3, @PY_A_BII4 AS PY_A_BII4, @PY_A_BII5 AS PY_A_BII5,
@PY_A_BIII AS PY_A_BIII,
@PY_A_BIII1 AS PY_A_BIII1,
@PY_A_BIII1a AS PY_A_BIII1a, @PY_A_BIII1b AS PY_A_BIII1b, @PY_A_BIII1c AS PY_A_BIII1c, @PY_A_BIII1d AS PY_A_BIII1d,
@PY_A_BIII2 AS PY_A_BIII2,
@PY_A_BIII2a AS PY_A_BIII2a, @PY_A_BIII2b AS PY_A_BIII2b, @PY_A_BIII2c AS PY_A_BIII2c, @PY_A_BIII2d AS PY_A_BIII2d,
@PY_A_BIII3 AS PY_A_BIII3,
@PY_A_BIII4 AS PY_A_BIII4,
@PY_A_C AS PY_A_C,
@PY_A_CI AS PY_A_CI,
@PY_A_CI1 AS PY_A_CI1, @PY_A_CI2 AS PY_A_CI2, @PY_A_CI3 AS PY_A_CI3, @PY_A_CI4 AS PY_A_CI4, @PY_A_CI5 AS PY_A_CI5,
@PY_A_CII AS PY_A_CII,
@PY_A_CII1 AS PY_A_CII1, @PY_A_CII2 AS PY_A_CII2, @PY_A_CII3 AS PY_A_CII3,
@PY_A_CII4 AS PY_A_CII4, @PY_A_CII4bis AS PY_A_CII4bis, @PY_A_CII4ter AS PY_A_CII4ter, @PY_A_CII5 AS PY_A_CII5,
@PY_A_CIII AS PY_A_CIII,
@PY_A_CIII1 AS PY_A_CIII1, @PY_A_CIII2 AS PY_A_CIII2, @PY_A_CIII3 AS PY_A_CIII3,
@PY_A_CIII4 AS PY_A_CIII4, @PY_A_CIII5 AS PY_A_CIII5, @PY_A_CIII6 AS PY_A_CIII6,
@PY_A_CIV AS PY_A_CIV,
@PY_A_CIV1 AS PY_A_CIV1, @PY_A_CIV2 AS PY_A_CIV2, @PY_A_CIV3 AS PY_A_CIV3,
@PY_A_D AS PY_A_D,
@PY_TOTPASSIVO AS PY_TOTPASSIVO,
@PY_P_A AS PY_P_A,
@PY_P_AI AS PY_P_AI, @PY_P_AII AS PY_P_AII, @PY_P_AIII AS PY_P_AIII, @PY_P_AIV AS PY_P_AIV, @PY_P_AV AS PY_P_AV,
@PY_P_AVI AS PY_P_AVI, @PY_P_AVII AS PY_P_AVII, @PY_P_AVIII AS PY_P_AVIII, @PY_P_AIX AS PY_P_AIX,
@PY_P_B AS PY_P_B,
@PY_P_B1 AS PY_P_B1, @PY_P_B2 AS PY_P_B2, @PY_P_B3 AS PY_P_B3,
@PY_P_C AS PY_P_C,
@PY_P_D AS PY_P_D,
@PY_P_D1 AS PY_P_D1, @PY_P_D2 AS PY_P_D2, @PY_P_D3 AS PY_P_D3, @PY_P_D4 AS PY_P_D4, @PY_P_D5 AS PY_P_D5,
@PY_P_D6 AS PY_P_D6, @PY_P_D7 AS PY_P_D7, @PY_P_D8 AS PY_P_D8, @PY_P_D9 AS PY_P_D9, @PY_P_D10 AS PY_P_D10,
@PY_P_D11 AS PY_P_D11, @PY_P_D12 AS PY_P_D12, @PY_P_D13 AS PY_P_D13, @PY_P_D14 AS PY_P_D14,
@PY_P_E AS PY_P_E,
@TOTATTIVO AS TOTATTIVO,
@A_A AS A_A,
@A_B AS A_B,
@A_BI AS A_BI,
@A_BI1 AS A_BI1, @A_BI2 AS A_BI2, @A_BI3 AS A_BI3, @A_BI4 AS A_BI4, @A_BI5 AS A_BI5, @A_BI6 AS A_BI6, @A_BI7 AS A_BI7,
@A_BII AS A_BII,
@A_BII1 AS A_BII1, @A_BII2 AS A_BII2, @A_BII3 AS A_BII3, @A_BII4 AS A_BII4, @A_BII5 AS A_BII5,
@A_BIII AS A_BIII,
@A_BIII1 AS A_BIII1,
@A_BIII1a AS A_BIII1a, @A_BIII1b AS A_BIII1b, @A_BIII1c AS A_BIII1c, @A_BIII1d AS A_BIII1d,
@A_BIII2 AS A_BIII2,
@A_BIII2a AS A_BIII2a, @A_BIII2b AS A_BIII2b, @A_BIII2c AS A_BIII2c, @A_BIII2d AS A_BIII2d,
@A_BIII3 AS A_BIII3,
@A_BIII4 AS A_BIII4,
@A_C AS A_C,
@A_CI AS A_CI,
@A_CI1 AS A_CI1, @A_CI2 AS A_CI2, @A_CI3 AS A_CI3, @A_CI4 AS A_CI4, @A_CI5 AS A_CI5,
@A_CII AS A_CII,
@A_CII1 AS A_CII1, @A_CII2 AS A_CII2, @A_CII3 AS A_CII3,
@A_CII4 AS A_CII4, @A_CII4bis AS A_CII4bis, @A_CII4ter AS A_CII4ter, @A_CII5 AS A_CII5,
@A_CIII AS A_CIII,
@A_CIII1 AS A_CIII1, @A_CIII2 AS A_CIII2, @A_CIII3 AS A_CIII3,
@A_CIII4 AS A_CIII4, @A_CIII5 AS A_CIII5, @A_CIII6 AS A_CIII6,
@A_CIV AS A_CIV,
@A_CIV1 AS A_CIV1, @A_CIV2 AS A_CIV2, @A_CIV3 AS A_CIV3,
@A_D AS A_D,
@TOTPASSIVO AS TOTPASSIVO,
@P_A AS P_A,
@P_AI AS P_AI, @P_AII AS P_AII, @P_AIII AS P_AIII, @P_AIV AS P_AIV, @P_AV AS P_AV, @P_AVI AS P_AVI, @P_AVII AS P_AVII,
@P_AVIII AS P_AVIII, @P_AIX AS P_AIX,
@P_B AS P_B,
@P_B1 AS P_B1, @P_B2 AS P_B2, @P_B3 AS P_B3,
@P_C AS P_C,
@P_D AS P_D,
@P_D1 AS P_D1, @P_D2 AS P_D2, @P_D3 AS P_D3, @P_D4 AS P_D4, @P_D5 AS P_D5, @P_D6 AS P_D6, @P_D7 AS P_D7,
@P_D8 AS P_D8, @P_D9 AS P_D9, @P_D10 AS P_D10, @P_D11 AS P_D11, @P_D12 AS P_D12, @P_D13 AS P_D13, @P_D14 AS P_D14,
@P_E AS P_E
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


