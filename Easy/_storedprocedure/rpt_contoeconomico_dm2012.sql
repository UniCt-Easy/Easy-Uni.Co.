
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_contoeconomico_dm2012]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_contoeconomico_dm2012]
GO
	
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE  PROCEDURE [rpt_contoeconomico_dm2012]
--setuser 'amministrazione'
--exec rpt_contoeconomico_dm2012 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '0001','S',null,'N',null,null
	
	(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idupb		varchar(36),
	@showchildupb	char(1),
	@idsor1 int,
	@showidsor1child char(1),
	@idsor2 int,
	@idsor3 int ,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
	)
	AS BEGIN
	DECLARE @idupboriginal varchar(36)
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
	BEGIN
	SET @idupb=@idupb+'%'
	END
	-- Conto Economico Anno Precedente
	DECLARE @firstdayPY datetime
	DECLARE @lastdayPY datetime
	SET @firstdayPY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear-1),105)
	SET @lastdayPY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)
	
	declare @sortcode1 varchar(50)
	set @sortcode1 = null
	if(@idsor1 is not null and @showidsor1child='S'	)
	Begin
		set @sortcode1 = ( select sortcode from sorting where idsor = @idsor1 )
	End
	
	declare @titlecode1 varchar(200)
	set @titlecode1 = (select description  + '-' + sortcode from sorting where idsor = @idsor1 )

	CREATE TABLE #sortinglink1
	(
		idchild int 
	)

	-- Valuta se considerare i figli o meno dell'idsor
IF (@showidsor1child = 'S')
BEGIN
	INSERT INTO #sortinglink1
	SELECT idchild from sortinglink 
	WHERE  idparent = @idsor1
END

	declare @ayearPrec int
	set @ayearPrec = @ayear - 1
	-- Sezione COSTI
	
	-->	B) VIII - COSTI DEL PERSONALE
	DECLARE @PY_C_BVIII1a decimal(19,2)
	SET @PY_C_BVIII1a =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
--	left outer join sortinglink SLK1
				--on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND	 (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) a)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) 
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BVIII1b decimal(19,2)
	SET @PY_C_BVIII1b =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) b)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BVIII1c decimal(19,2)
	SET @PY_C_BVIII1c =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) c)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BVIII1d decimal(19,2)
	SET @PY_C_BVIII1d =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) d)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BVIII1e decimal(19,2)
	SET @PY_C_BVIII1e =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) e)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BVIII2 decimal(19,2)
	SET @PY_C_BVIII2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BVIII decimal(19,2)
	SET @PY_C_BVIII = @PY_C_BVIII1a + @PY_C_BVIII1b + @PY_C_BVIII1c +@PY_C_BVIII1d + @PY_C_BVIII1e + @PY_C_BVIII2
	
	
	--> B) IX - COSTI DELLA GESTIONE CORRENTE
	DECLARE @PY_C_BIX1 decimal(19,2)
	SET @PY_C_BIX1 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 1)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BIX2 decimal(19,2)
	SET @PY_C_BIX2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BIX3 decimal(19,2)
	SET @PY_C_BIX3 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 3)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BIX4 decimal(19,2)
	SET @PY_C_BIX4 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 4)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BIX5 decimal(19,2)
	SET @PY_C_BIX5 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 5)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @PY_C_BIX6 decimal(19,2)
	SET @PY_C_BIX6 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 6)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BIX7 decimal(19,2)
	SET @PY_C_BIX7 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 7)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @PY_C_BIX8 decimal(19,2)
	SET @PY_C_BIX8 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12)  -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 8)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @PY_C_BIX9 decimal(19,2)
	SET @PY_C_BIX9 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 9)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BIX10 decimal(19,2)
	SET @PY_C_BIX10 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 10)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BIX11 decimal(19,2)
	SET @PY_C_BIX11 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 11)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @PY_C_BIX12 decimal(19,2)
	SET @PY_C_BIX12 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 12)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	
	
	DECLARE @PY_C_BIX decimal(19,2)
	SET @PY_C_BIX = @PY_C_BIX1 + @PY_C_BIX2 + @PY_C_BIX3 + @PY_C_BIX4 + @PY_C_BIX5 + @PY_C_BIX6
	+ @PY_C_BIX7 + @PY_C_BIX8 + @PY_C_BIX9+ @PY_C_BIX10 + @PY_C_BIX11 + @PY_C_BIX12
	
	-->	B) X - AMMORTAMENTI E SVALUTAZIONI
	
	DECLARE @PY_C_BX1 decimal(19,2)
	SET @PY_C_BX1 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 1)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BX2 decimal(19,2)
	SET @PY_C_BX2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BX3 decimal(19,2)
	SET @PY_C_BX3 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 3)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BX4 decimal(19,2)
	SET @PY_C_BX4 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 4)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_BX decimal(19,2)
	SET @PY_C_BX = @PY_C_BX1 + @PY_C_BX2 + @PY_C_BX3 + @PY_C_BX4
	
	--> B) XI - ACCANTONAMENTI PER RISCHI E ONERI
	DECLARE @PY_C_BXI decimal(19,2)
	SET @PY_C_BXI =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) XI'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--> B) XII - ONERI DIVERSI DI GESTIONE
	DECLARE @PY_C_BXII decimal(19,2)
	SET @PY_C_BXII =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) XII'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	
	
	DECLARE @PY_C_B decimal(19,2)
	SET @PY_C_B = @PY_C_BVIII + @PY_C_BIX + @PY_C_BX + @PY_C_BXI + @PY_C_BXII
	
	--> C - PROVENTI E ONERI FINANZIARI
	
	DECLARE @PY_C_C2 decimal(19,2)
	SET @PY_C_C2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	
	DECLARE @PY_C_C3 decimal(19,2)
	SET @PY_C_C3 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 3)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	
	DECLARE @PY_C_C decimal(19,2)
	
	SET @PY_C_C = @PY_C_C2 + @PY_C_C3
	
	-->  D - RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
	DECLARE @PY_C_D2 decimal(19,2)
	SET @PY_C_D2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'D) 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	
	DECLARE @PY_C_D decimal(19,2)
	
	--- il valore viene mostrato positivo in stampa
	SET @PY_C_D = @PY_C_D2
	
	--> E - PROVENTI E ONERI STRAORDINARI
	DECLARE @PY_C_E2 decimal(19,2)
	SET @PY_C_E2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'E) 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_C_E decimal(19,2)
	
	--- il valore viene mostrato positivo in stampa
	SET @PY_C_E = @PY_C_E2
	
	--> F - IMPOSTE SUL REDDITO DELL'ESERCIZIO CORRENTI, DIFFERITE, ANTICIPATE
	DECLARE @PY_C_F decimal(19,2)
	SET @PY_C_F =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'F)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_TOTCOSTI decimal(19,2)
	SET @PY_TOTCOSTI = @PY_C_BVIII + @PY_C_BIX + @PY_C_BX +  @PY_C_BXI  + @PY_C_BXII +
	@PY_C_C + @PY_C_D + @PY_C_E + @PY_C_F -->
	-- Sezione RICAVI
	--> A) I - PROVENTI PROPRI
	
	-- Sono costi che si desidera visualizzare col segno negativo.15333
	SET @PY_C_F = - @PY_C_F

	DECLARE @PY_R_AI1 decimal(19,2)
	SET @PY_R_AI1 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 1)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_R_AI2 decimal(19,2)
	SET @PY_R_AI2 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 2)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_R_AI3 decimal(19,2)
	SET @PY_R_AI3 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 3)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_R_AI decimal(19,2)
	SET @PY_R_AI = @PY_R_AI1 + @PY_R_AI2 + @PY_R_AI3
	
	--> A) II - CONTRIBUTI
	DECLARE @PY_R_AII1 decimal(19,2)
	SET @PY_R_AII1 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 1)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @PY_R_AII2 decimal(19,2)
	SET @PY_R_AII2 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 2)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @PY_R_AII3 decimal(19,2)
	SET @PY_R_AII3 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 3)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_R_AII4 decimal(19,2)
	SET @PY_R_AII4 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 4)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_R_AII5 decimal(19,2)
	SET @PY_R_AII5 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 5)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @PY_R_AII6 decimal(19,2)
	SET @PY_R_AII6 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 6)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_R_AII7 decimal(19,2)
	SET @PY_R_AII7 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 7)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_R_AII decimal(19,2)
	SET @PY_R_AII = @PY_R_AII1 + @PY_R_AII2 + @PY_R_AII3 + @PY_R_AII4 + @PY_R_AII5 + @PY_R_AII6 + @PY_R_AII7
	
	--> A) III - PROVENTI PER ATTIVITA’ ASSISTENZIALE E SERVIZIO SANITARIO NAZIONALE
	DECLARE @PY_R_AIII decimal(19,2)
	SET @PY_R_AIII =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) III'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--> A) IV  - PROVENTI PER LA GESTIONE DIRETTA INTERVENTI DIRITTO ALLO STUDIO
	DECLARE @PY_R_AIV decimal(19,2)
	SET @PY_R_AIV =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) IV'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--> A) V - ALTRI PROVENTI
	DECLARE @PY_R_AV decimal(19,2)
	SET @PY_R_AV =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) V'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--> A) VI VARIAZIONE LAVORI IN CORSO
	DECLARE @PY_R_AVI decimal(19,2)
	SET @PY_R_AVI =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) VI'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--> A) VII - INCREMENTO IMMOBILIZZAZIONI PER LAVORI INTERNI
	DECLARE @PY_R_AVII decimal(19,2)
	SET @PY_R_AVII =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) VII'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_R_A decimal(19,2)
	SET @PY_R_A = @PY_R_AI + @PY_R_AII + @PY_R_AIII + @PY_R_AIV + @PY_R_AV + @PY_R_AVI + @PY_R_AVII
	
	
	--> C - PROVENTI E ONERI FINANZIARI
	DECLARE @PY_R_C1 decimal(19,2)
	SET @PY_R_C1 =
	ISNULL(
	(SELECT SUM(amount)  --> RIMOSSO IL SEGNO MENO
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 1)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_R_C3 decimal(19,2)
	SET @PY_R_C3 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 3)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	) -- tre
	,0)
	
	DECLARE @PY_R_C decimal(19,2)
	SET @PY_R_C = @PY_R_C1 + @PY_R_C3
	
	--> D - RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
	DECLARE @PY_R_D1 decimal(19,2)
	SET @PY_R_D1 =
	ISNULL(
	(SELECT SUM(amount)				--> RIMOSSO IL SEGNO MENO
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'D) 1)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	
	DECLARE @PY_R_D decimal(19,2)
	SET @PY_R_D = @PY_R_D1
	
	--> E - PROVENTI E ONERI STRAORDINARI
	DECLARE @PY_R_E1 decimal(19,2)
	SET @PY_R_E1 =
	ISNULL(
	(SELECT SUM(amount)			--> RIMOSSO IL SEGNO MENO
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'E) 1)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @PY_R_E decimal(19,2)
	SET @PY_R_E = @PY_R_E1
	
	DECLARE @PY_TOTRICAVI decimal(19,2)
	SET @PY_TOTRICAVI = @PY_R_AI + @PY_R_AII + @PY_R_AIII + @PY_R_AIV + @PY_R_AV +@PY_R_AVI + @PY_R_AVII
	+ @PY_R_C + @PY_R_D + @PY_R_E
	
	-- Conto Economico Anno Corrente
	
	-- Sezione COSTI
	
	-->	B) VIII - COSTI DEL PERSONALE
	DECLARE @C_BVIII1a decimal(19,2)
	SET @C_BVIII1a =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) a)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BVIII1b decimal(19,2)
	SET @C_BVIII1b =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) b)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BVIII1c decimal(19,2)
	SET @C_BVIII1c =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) c)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BVIII1d decimal(19,2)
	SET @C_BVIII1d =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) d)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BVIII1e decimal(19,2)
	SET @C_BVIII1e =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) e)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BVIII2 decimal(19,2)
	SET @C_BVIII2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BVIII decimal(19,2)
	SET @C_BVIII = @C_BVIII1a + @C_BVIII1b + @C_BVIII1c +@C_BVIII1d + @C_BVIII1e + @C_BVIII2
	
	
	--> B) IX - COSTI DELLA GESTIONE CORRENTE
	DECLARE @C_BIX1 decimal(19,2)
	SET @C_BIX1 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 1)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BIX2 decimal(19,2)
	SET @C_BIX2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BIX3 decimal(19,2)
	SET @C_BIX3 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 3)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BIX4 decimal(19,2)
	SET @C_BIX4 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 4)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BIX5 decimal(19,2)
	SET @C_BIX5 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 5)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @C_BIX6 decimal(19,2)
	SET @C_BIX6 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 6)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BIX7 decimal(19,2)
	SET @C_BIX7 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 7)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @C_BIX8 decimal(19,2)
	SET @C_BIX8 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 8)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @C_BIX9 decimal(19,2)
	SET @C_BIX9 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 9)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BIX10 decimal(19,2)
	SET @C_BIX10 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 10)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	
	DECLARE @C_BIX11 decimal(19,2)
	SET @C_BIX11 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 11)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @C_BIX12 decimal(19,2)
	SET @C_BIX12 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 12)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	
	
	DECLARE @C_BIX decimal(19,2)
	SET @C_BIX = @C_BIX1 + @C_BIX2 + @C_BIX3 + @C_BIX4 + @C_BIX5 + @C_BIX6
	+ @C_BIX7 + @C_BIX8 + @C_BIX9+ @C_BIX10 + @C_BIX11 + @C_BIX12
	
	-->	B) X - AMMORTAMENTI E SVALUTAZIONI
	
	DECLARE @C_BX1 decimal(19,2)
	SET @C_BX1 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 1)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BX2 decimal(19,2)
	SET @C_BX2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BX3 decimal(19,2)
	SET @C_BX3 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 3)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BX4 decimal(19,2)
	SET @C_BX4 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 4)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_BX decimal(19,2)
	SET @C_BX = @C_BX1 + @C_BX2 + @C_BX3 + @C_BX4
	
	--> B) XI - ACCANTONAMENTI PER RISCHI E ONERI
	DECLARE @C_BXI decimal(19,2)
	SET @C_BXI =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) XI'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--> B) XII - ONERI DIVERSI DI GESTIONE
	DECLARE @C_BXII decimal(19,2)
	SET @C_BXII =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) XII'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	
	
	DECLARE @C_B decimal(19,2)
	SET @C_B = @C_BVIII + @C_BIX + @C_BX + @C_BXI + @C_BXII
	
	--> C - PROVENTI E ONERI FINANZIARI
	DECLARE @C_C2 decimal(19,2)
	SET @C_C2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_C3 decimal(19,2)
	SET @C_C3 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 3)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_C decimal(19,2)
	SET @C_C = @C_C2 + @C_C3
	
	-->  D - RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
	DECLARE @C_D2 decimal(19,2)
	SET @C_D2 =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'D) 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	
	DECLARE @C_D decimal(19,2)
	SET @C_D = @C_D2
	
	--> E - PROVENTI E ONERI STRAORDINARI
	DECLARE @C_E2 decimal(19,2)
	SET @C_E2=
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'E) 2)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @C_E decimal(19,2)
	SET @C_E = @C_E2
	
	--> F - IMPOSTE SUL REDDITO DELL'ESERCIZIO CORRENTI, DIFFERITE, ANTICIPATE
	DECLARE @C_F decimal(19,2)
	SET @C_F =
	ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount =  'F)'
	AND placcount.placcpart = 'C'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)

	DECLARE @TOTCOSTI decimal(19,2)
	SET @TOTCOSTI = @C_BVIII + @C_BIX + @C_BX +  @C_BXI  + @C_BXII +
	@C_C + @C_D + @C_E + @C_F

	-- Sono costi che si desidera visualizzare col segno negativo.15333
	SET @C_F = - @C_F
		
	-- Sezione RICAVI
	--> A) I - PROVENTI PROPRI
	
	DECLARE @R_AI1 decimal(19,2)
	SET @R_AI1 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 1)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @R_AI2 decimal(19,2)
	SET @R_AI2 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 2)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @R_AI3 decimal(19,2)
	SET @R_AI3 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 3)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @R_AI decimal(19,2)
	SET @R_AI = @R_AI1 + @R_AI2 + @R_AI3
	
	--> A) II - CONTRIBUTI
	DECLARE @R_AII1 decimal(19,2)
	SET @R_AII1 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 1)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @R_AII2 decimal(19,2)
	SET @R_AII2 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 2)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @R_AII3 decimal(19,2)
	SET @R_AII3 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 3)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @R_AII4 decimal(19,2)
	SET @R_AII4 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 4)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--SELECT amount,entry.*, entrydetail.*,upb.idsor01
	--FROM entrydetail
	--JOIN entry
	--ON entry.yentry = entrydetail.yentry
	--AND entry.nentry = entrydetail.nentry
	--JOIN account
	--ON account.idacc = entrydetail.idacc
	--left outer JOIN upb
	--ON upb.idupb  = entrydetail.idupb
	--JOIN placcount
	--ON placcount.idplaccount = account.idplaccount
	---- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	--WHERE entry.adate BETWEEN @start AND @stop
	--AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	--AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	--AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	--AND placcount.codeplaccount = 'A) II 5)'
	--AND placcount.placcpart = 'R'
	--AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	--AND placcount.ayear = @ayear
	----AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	--AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	--AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	--AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	--AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


	DECLARE @R_AII5 decimal(19,2)
	SET @R_AII5 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 5)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @R_AII6 decimal(19,2)
	SET @R_AII6 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 6)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @R_AII7 decimal(19,2)
	SET @R_AII7 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 7)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @R_AII decimal(19,2)
	SET @R_AII = @R_AII1 + @R_AII2 + @R_AII3 + @R_AII4 + @R_AII5 + @R_AII6 + @R_AII7
	
	--> A) III - PROVENTI PER ATTIVITA’ ASSISTENZIALE E SERVIZIO SANITARIO NAZIONALE
	DECLARE @R_AIII decimal(19,2)
	SET @R_AIII =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) III'
	AND placcount.placcpart = 'R'
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--> A) IV  - PROVENTI PER LA GESTIONE DIRETTA INTERVENTI DIRITTO ALLO STUDIO
	DECLARE @R_AIV decimal(19,2)
	SET @R_AIV =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) IV'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--> A) V - ALTRI PROVENTI
	DECLARE @R_AV decimal(19,2)
	SET @R_AV =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) V'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--> A) VI VARIAZIONE LAVORI IN CORSO
	DECLARE @R_AVI decimal(19,2)
	SET @R_AVI =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) VI'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	--> A) VII - INCREMENTO IMMOBILIZZAZIONI PER LAVORI INTERNI
	DECLARE @R_AVII decimal(19,2)
	SET @R_AVII =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) VII'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @R_A decimal(19,2)
	SET @R_A = @R_AI + @R_AII + @R_AIII + @R_AIV + @R_AV + @R_AVI + @R_AVII
	
	
	--> C - PROVENTI E ONERI FINANZIARI
	DECLARE @R_C1 decimal(19,2)
	SET @R_C1 =
	ISNULL(
	(SELECT SUM(amount)			--> RIMOSSO IL SEGNO MENO
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 1)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @R_C3 decimal(19,2)
	SET @R_C3 =
	ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 3)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	
	DECLARE @R_C decimal(19,2)
	SET @R_C = @R_C1 + @R_C3
	
	--> D - RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
	DECLARE @R_D1 decimal(19,2)
	SET @R_D1 =
	ISNULL(
	(SELECT SUM(amount)				--> RIMOSSO IL SEGNO MENO
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'D) 1)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @R_D decimal(19,2)
	SET @R_D = @R_D1
	---qua
	--> E - PROVENTI E ONERI STRAORDINARI
	DECLARE @R_E1 decimal(19,2)
	SET @R_E1 =
	ISNULL(
	(SELECT SUM(amount)				--> RIMOSSO IL SEGNO MENO
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	left outer JOIN upb
	ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'E) 1)'
	AND placcount.placcpart = 'R'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR @idsor1 IS NULL) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	)
	,0)
	DECLARE @R_E decimal(19,2)
	SET @R_E = @R_E1
	
	DECLARE @TOTRICAVI decimal(19,2)
	SET @TOTRICAVI = @R_AI + @R_AII + @R_AIII + @R_AIV + @R_AV +@R_AVI + @R_AVII
	+ @R_C + @R_D + @R_E
	
	
	DECLARE @codeupb	varchar(50)
	DECLARE @title		varchar(150)
	
	SELECT	@codeupb = codeupb,
	@title = title
	FROM	upb
	WHERE	idupb = @idupboriginal
	-- Sono costi che si desidera visualizzare col segno negativo.15333
	set @PY_C_C2 = - @PY_C_C2
	set @C_C2 = - @C_C2
	set @PY_C_D = - @PY_C_D
	set @C_D = - @C_D
	set @C_E = -@C_E
	set @PY_C_E = -@PY_C_E
	SELECT
	@ayear				  AS ayear         ,
	@idupboriginal		  as idupb         ,
	@codeupb				  as codeupb	   ,
	@title				  as upb		   ,
	@PY_C_BVIII1a  		  as PY_C_BVIII1a  ,
	@PY_C_BVIII1b  		  as PY_C_BVIII1b  ,
	@PY_C_BVIII1c  		  as PY_C_BVIII1c  ,
	@PY_C_BVIII1d  		  as PY_C_BVIII1d  ,
	@PY_C_BVIII1e  		  as PY_C_BVIII1e  ,
	@PY_C_BVIII2  		  as PY_C_BVIII2  ,
	@PY_C_BVIII  		  as PY_C_BVIII  ,
	@PY_C_BIX1  		  as PY_C_BIX1  ,
	@PY_C_BIX2  		  as PY_C_BIX2  ,
	@PY_C_BIX3  		  as PY_C_BIX3  ,
	@PY_C_BIX4  		  as PY_C_BIX4  ,
	@PY_C_BIX5  		  as PY_C_BIX5  ,
	@PY_C_BIX6  		  as PY_C_BIX6  ,
	@PY_C_BIX7  		  as PY_C_BIX7  ,
	@PY_C_BIX8  		  as PY_C_BIX8  ,
	@PY_C_BIX9  		  as PY_C_BIX9  ,
	@PY_C_BIX10  		  as PY_C_BIX10  ,
	@PY_C_BIX11  		  as PY_C_BIX11  ,
	@PY_C_BIX12  		  as PY_C_BIX12  ,
	@PY_C_BIX  		  as PY_C_BIX  ,
	@PY_C_BX1  		  as PY_C_BX1  ,
	@PY_C_BX2  		  as PY_C_BX2  ,
	@PY_C_BX3  		  as PY_C_BX3  ,
	@PY_C_BX4  		  as PY_C_BX4  ,
	@PY_C_BX  		  as PY_C_BX  ,
	@PY_C_BXI  		  as PY_C_BXI  ,
	@PY_C_BXII  		  as PY_C_BXII  ,
	@PY_C_B  		  as PY_C_B  ,
	@PY_C_C2  		  as PY_C_C2	,
	@PY_C_C3  		  as PY_C_C3  ,
	@PY_C_C  		  as PY_C_C  ,
	@PY_C_D2  		  as PY_C_D2  ,
	@PY_C_D  		  as PY_C_D  ,
	@PY_C_E2  		  as PY_C_E2  ,
	@PY_C_E  		  as PY_C_E  ,
	@PY_C_F  		  as PY_C_F  ,
	@PY_TOTCOSTI  		  as PY_TOTCOSTI  ,
	@PY_R_AI1  		  as PY_R_AI1  ,
	@PY_R_AI2  		  as PY_R_AI2  ,
	@PY_R_AI3  		  as PY_R_AI3  ,
	@PY_R_AI  		  as PY_R_AI  ,
	@PY_R_AII1  		  as PY_R_AII1 ,
	@PY_R_AII2  		  as PY_R_AII2  ,
	@PY_R_AII3  		  as PY_R_AII3  ,
	@PY_R_AII4  		  as PY_R_AII4  ,
	@PY_R_AII5  		  as PY_R_AII5  ,
	@PY_R_AII6  		  as PY_R_AII6  ,
	@PY_R_AII7  		  as PY_R_AII7  ,
	@PY_R_AII  		  as PY_R_AII  ,
	@PY_R_AIII  		  as PY_R_AIII  ,
	@PY_R_AIV  		  as PY_R_AIV  ,
	@PY_R_AV  		  as PY_R_AV  ,
	@PY_R_AVI  		  as PY_R_AVI  ,
	@PY_R_AVII  		  as PY_R_AVII  ,
	@PY_R_A  		  as PY_R_A  ,
	@PY_R_C1  		  as PY_R_C1  ,
	@PY_R_C3  		  as PY_R_C3  ,
	@PY_R_C  		  as PY_R_C  ,
	@PY_R_D1  		  as PY_R_D1  ,
	@PY_R_D  		  as PY_R_D  ,
	@PY_R_E1  		  as PY_R_E1  ,
	@PY_R_E  		  as PY_R_E  ,
	@PY_TOTRICAVI  		  as PY_TOTRICAVI  ,
	
	@C_BVIII1a  	   as C_BVIII1a  	,
	@C_BVIII1b  	   as C_BVIII1b  	,
	@C_BVIII1c  	   as C_BVIII1c  	,
	@C_BVIII1d  	   as C_BVIII1d  	,
	@C_BVIII1e  	   as C_BVIII1e  	,
	@C_BVIII2  	   as C_BVIII2  	,
	@C_BVIII  	   as C_BVIII  	,
	@C_BIX1  	   as C_BIX1  	,
	@C_BIX2  	   as C_BIX2  	,
	@C_BIX3  	   as C_BIX3  	,
	@C_BIX4  	   as C_BIX4  	,
	@C_BIX5  	   as C_BIX5  	,
	@C_BIX6  	   as C_BIX6  	,
	@C_BIX7  	   as C_BIX7  	,
	@C_BIX8  	   as C_BIX8  	,
	@C_BIX9  	   as C_BIX9  	,
	@C_BIX11  	   as C_BIX11,
	@C_BIX10  	   as C_BIX10 ,
	@C_BIX12  	   as C_BIX12  	,
	@C_BIX  	   as C_BIX  	,
	@C_BX1  	   as C_BX1  	,
	@C_BX2  	   as C_BX2  	,
	@C_BX3  	   as C_BX3  	,
	@C_BX4  	   as C_BX4  	,
	@C_BX  	   as C_BX  	,
	@C_BXI  	   as C_BXI  	,
	@C_BXII  	   as C_BXII  	,
	@C_B  	   as C_B  	,
	@C_C2  	   as C_C2  ,
	@C_C3  	   as C_C3  ,
	@C_C  	   as C_C  	,
	@C_D2  	   as C_D2  ,
	@C_D  	   as C_D  	,
	@C_E2  	   as C_E2  ,
	@C_E  	   as C_E  	,
	@C_F  	   as C_F  	,
	@TOTCOSTI    as TOTCOSTI ,
	@R_AI1  	   as R_AI1  	,
	@R_AI2  	   as R_AI2  	,
	@R_AI3  	   as R_AI3  	,
	@R_AI  	   as R_AI  	,
	@R_AII1  	   as R_AII1  	,
	@R_AII2  	   as R_AII2  	,
	@R_AII3  	   as R_AII3  	,
	@R_AII4  	   as R_AII4  	,
	@R_AII5  	   as R_AII5  	,
	@R_AII6  	   as R_AII6  	,
	@R_AII7  	   as R_AII7  	,
	@R_AII  	   as R_AII  	,
	@R_AIII  	   as R_AIII  	,
	@R_AIV  	   as R_AIV  	,
	@R_AV  	   as R_AV  	,
	@R_AVI  	   as R_AVI  	,
	@R_AVII  	   as R_AVII  	,
	@R_A  	   as R_A  	,
	@R_C1  	   as R_C1  ,
	@R_C3  	   as R_C3  ,
	@R_C  	   as R_C  	,
	@R_D1  	   as R_D1  ,
	@R_D  	   as R_D  	,
	@R_E1  	   as R_E1  ,
	@R_E  	   as R_E  	,
	@TOTRICAVI  	   as TOTRICAVI ,
	case when @sortcode1 is null then  ( select sortcode from sorting where idsor = @idsor1 ) else @sortcode1 end as sortcode1,
	@titlecode1 	as titlecode1
	
	
	
	
	
	
	
	END

GO
