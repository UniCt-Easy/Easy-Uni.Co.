
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_statopatrimoniale_dm2012]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_statopatrimoniale_dm2012]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser'amministrazione'
--exec rpt_statopatrimoniale_dm2012 2017, {ts '2017-01-01 00:00:00'}, {ts '2017-12-31 00:00:00'},'%','N',null,null,null,'S'
CREATE  PROCEDURE rpt_statopatrimoniale_dm2012
(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idupb		varchar(36),
	@showchildupb	char(1),
	@idsor1 int,
	@showidsor1child char(1), 
	@idsor2 int,
	@idsor3 int,
	@apertura   varchar(1),
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
	
-- Stato Patrimoniale Anno Precedente
DECLARE @firstdayPY datetime
DECLARE @lastdayPY datetime
SET @firstdayPY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear-1),105)
SET @lastdayPY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)

declare @ayearPrec int
set @ayearPrec = @ayear - 1

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


DECLARE @PY_A_AI_aI1 decimal(19,2)
SET @PY_A_AI_aI1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 1)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) 
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_AI_aI2 decimal(19,2)
SET @PY_A_AI_aI2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 2)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)  
	)
,0)

DECLARE @PY_A_AI_aI3 decimal(19,2)
SET @PY_A_AI_aI3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 3)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_AI_aI4 decimal(19,2)
SET @PY_A_AI_aI4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 4)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_AI_aI5 decimal(19,2)
SET @PY_A_AI_aI5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 5)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_AI decimal(19,2)
SET @PY_A_AI = @PY_A_AI_aI1 + @PY_A_AI_aI2 + @PY_A_AI_aI3 + @PY_A_AI_aI4 + @PY_A_AI_aI5


DECLARE @PY_A_AII_aII1 decimal(19,2)
SET @PY_A_AII_aII1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 1)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_AII_aII2 decimal(19,2)
SET @PY_A_AII_aII2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12)-- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 2)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_AII_aII3 decimal(19,2)
SET @PY_A_AII_aII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 3)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_AII_aII4 decimal(19,2)
SET @PY_A_AII_aII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 4)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_AII_aII5 decimal(19,2)
SET @PY_A_AII_aII5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12)-- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 5)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)


DECLARE @PY_A_AII_aII6 decimal(19,2)
SET @PY_A_AII_aII6 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 6)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_AII_aII7 decimal(19,2)
SET @PY_A_AII_aII7 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 7)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_AII decimal(19,2)
SET @PY_A_AII = @PY_A_AII_aII1 + @PY_A_AII_aII2 + @PY_A_AII_aII3 + @PY_A_AII_aII4 + @PY_A_AII_aII5 + @PY_A_AII_aII6 + @PY_A_AII_aII7

DECLARE @PY_A_AIII decimal(19,2)
SET @PY_A_AIII = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	) 
,0)


DECLARE @PY_A_A decimal(19,2)
SET @PY_A_A = @PY_A_AI + @PY_A_AII + @PY_A_AIII

DECLARE @PY_A_BI decimal(19,2)
SET @PY_A_BI = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) I'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)


DECLARE @PY_A_BII_bII1 decimal(19,2)
SET @PY_A_BII_bII1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 1)o','B) II 1)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

-- Solo la parte esigibile
DECLARE @PY_A_BII_bII1e decimal(19,2)
SET @PY_A_BII_bII1e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 1)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII2 decimal(19,2)
SET @PY_A_BII_bII2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 2)e','B) II 2)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

-- Solo la parte esigibile
DECLARE @PY_A_BII_bII2e decimal(19,2)
SET @PY_A_BII_bII2e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 2)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII3 decimal(19,2)
SET @PY_A_BII_bII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 3)e','B) II 3)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII3e decimal(19,2)
SET @PY_A_BII_bII3e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 3)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII4 decimal(19,2)
SET @PY_A_BII_bII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 4)e','B) II 4)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)


DECLARE @PY_A_BII_bII4e decimal(19,2)
SET @PY_A_BII_bII4e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 4)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII5 decimal(19,2)
SET @PY_A_BII_bII5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 5)e','B) II 5)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII5e decimal(19,2)
SET @PY_A_BII_bII5e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 5)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII6 decimal(19,2)
SET @PY_A_BII_bII6 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 6)e','B) II 6)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII6e decimal(19,2)
SET @PY_A_BII_bII6e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 6)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII7 decimal(19,2)
SET @PY_A_BII_bII7 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 7)e','B) II 7)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII7e decimal(19,2)
SET @PY_A_BII_bII7e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 7)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII8 decimal(19,2)
SET @PY_A_BII_bII8 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 8)e','B) II 8)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII8e decimal(19,2)
SET @PY_A_BII_bII8e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 8)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII9 decimal(19,2)
SET @PY_A_BII_bII9 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 9)e','B) II 9)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII_bII9e decimal(19,2)
SET @PY_A_BII_bII9e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 9)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BII decimal(19,2)
SET @PY_A_BII = @PY_A_BII_bII1 + @PY_A_BII_bII2  + @PY_A_BII_bII3  + @PY_A_BII_bII4  + @PY_A_BII_bII5  + @PY_A_BII_bII6  + @PY_A_BII_bII7  + @PY_A_BII_bII8  + @PY_A_BII_bII9 

DECLARE @PY_A_BIIe decimal(19,2)
SET @PY_A_BIIe = @PY_A_BII_bII1e + @PY_A_BII_bII2e  + @PY_A_BII_bII3e  + @PY_A_BII_bII4e  + @PY_A_BII_bII5e  + @PY_A_BII_bII6e  + @PY_A_BII_bII7e  + @PY_A_BII_bII8e  + @PY_A_BII_bII9e 

DECLARE @PY_A_BIII decimal(19,2)
SET @PY_A_BIII = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) III'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)


DECLARE @PY_A_BIV_bIV1 decimal(19,2)
SET @PY_A_BIV_bIV1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) IV 1)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BIV_bIV2 decimal(19,2)
SET @PY_A_BIV_bIV2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) IV 2)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_BIV decimal(19,2)
SET @PY_A_BIV = @PY_A_BIV_bIV1 + @PY_A_BIV_bIV2

DECLARE @PY_A_B decimal(19,2)
SET @PY_A_B = @PY_A_BI + @PY_A_BII + @PY_A_BIII + @PY_A_BIV


-- Ratei
DECLARE @PY_A_C_c1 decimal(19,2)
SET @PY_A_C_c1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND ((patrimony.codepatrimony = 'C) c1)' and @ayearPrec <> 2017) OR (patrimony.codepatrimony = 'C) c2)' AND @ayearPrec = 2017))
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_C_c2 decimal(19,2)
SET @PY_A_C_c2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'C) c2)' AND @ayearPrec < 2017
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_C decimal(19,2)
SET @PY_A_C = @PY_A_C_c1 + @PY_A_C_c2 


DECLARE @PY_A_D_d1 decimal(19,2)
SET @PY_A_D_d1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND ((patrimony.codepatrimony = 'd 1)' and @ayearPrec > 2017) OR (patrimony.codepatrimony = 'C) c1)' AND @ayearPrec = 2017))
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_A_D decimal(19,2)
SET @PY_A_D = @PY_A_D_d1  



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
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)



DECLARE @PY_P_AII_aII1 decimal(19,2)
SET @PY_P_AII_aII1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 1)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_AII_aII2 decimal(19,2)
SET @PY_P_AII_aII2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 2)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)



DECLARE @PY_P_AII_aII3 decimal(19,2)
SET @PY_P_AII_aII3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 3)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)



DECLARE @PY_P_AII decimal(19,2)
SET @PY_P_AII = @PY_P_AII_aII1 + @PY_P_AII_aII2 + @PY_P_AII_aII3


DECLARE @PY_P_AIII_aIII1 decimal(19,2)
SET @PY_P_AIII_aIII1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 1)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_AIII_aIII2 decimal(19,2)
SET @PY_P_AIII_aIII2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 2)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)



DECLARE @PY_P_AIII_aIII3 decimal(19,2)
SET @PY_P_AIII_aIII3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 3)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)


DECLARE @PY_P_AIII decimal(19,2)
SET @PY_P_AIII = @PY_P_AIII_aIII1 + @PY_P_AIII_aIII2 + @PY_P_AIII_aIII3


DECLARE @PY_P_A decimal(19,2)
SET @PY_P_A = @PY_P_AI + @PY_P_AII + @PY_P_AIII

DECLARE @PY_P_B decimal(19,2)
SET @PY_P_B = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

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
	LEFT OUTER JOIN upb
	ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'C)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d1 decimal(19,2)
SET @PY_P_D_d1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 1)e','D) 1)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d1o decimal(19,2)
SET @PY_P_D_d1o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 1)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d2 decimal(19,2)
SET @PY_P_D_d2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 2)e','D) 2)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d2o decimal(19,2)
SET @PY_P_D_d2o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 2)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d3 decimal(19,2)
SET @PY_P_D_d3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 3)e','D) 3)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)


DECLARE @PY_P_D_d3o decimal(19,2)
SET @PY_P_D_d3o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER  JOIN upb
	 ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 3)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d4 decimal(19,2)
SET @PY_P_D_d4 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 4)e','D) 4)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d4o decimal(19,2)
SET @PY_P_D_d4o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 4)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d5 decimal(19,2)
SET @PY_P_D_d5 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 5)e','D) 5)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d5o decimal(19,2)
SET @PY_P_D_d5o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 5)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d6 decimal(19,2)
SET @PY_P_D_d6 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 6)e','D) 6)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d6o decimal(19,2)
SET @PY_P_D_d6o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 6)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d7 decimal(19,2)
SET @PY_P_D_d7 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 7)e','D) 7)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)


DECLARE @PY_P_D_d7o decimal(19,2)
SET @PY_P_D_d7o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 7)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d8 decimal(19,2)
SET @PY_P_D_d8 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 8)e','D) 8)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d8o decimal(19,2)
SET @PY_P_D_d8o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 8)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d9 decimal(19,2)
SET @PY_P_D_d9 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 9)e','D) 9)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d9o decimal(19,2)
SET @PY_P_D_d9o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 9)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d10 decimal(19,2)
SET @PY_P_D_d10 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 10)e','D) 10)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d10o decimal(19,2)
SET @PY_P_D_d10o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 10)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d11 decimal(19,2)
SET @PY_P_D_d11 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 11)e','D) 11)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d11o decimal(19,2)
SET @PY_P_D_d11o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 11)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d12 decimal(19,2)
SET @PY_P_D_d12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 12)e','D) 12)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D_d12o decimal(19,2)
SET @PY_P_D_d12o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 12)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_D decimal(19,2)
SET @PY_P_D = @PY_P_D_d1 + @PY_P_D_d2 + @PY_P_D_d3 + @PY_P_D_d4 + @PY_P_D_d5+ @PY_P_D_d6 + @PY_P_D_d7 + @PY_P_D_d8 + @PY_P_D_d9 + @PY_P_D_d10 + @PY_P_D_d11 + @PY_P_D_d12

DECLARE @PY_P_Do decimal(19,2)
SET @PY_P_Do = @PY_P_D_d1o + @PY_P_D_d2o + @PY_P_D_d3o + @PY_P_D_d4o + @PY_P_D_d5o + @PY_P_D_d6o + @PY_P_D_d7o + @PY_P_D_d8o + @PY_P_D_d9o + @PY_P_D_d10o + @PY_P_D_d11o + @PY_P_D_d12o

DECLARE @PY_P_E_e1 decimal(19,2)
SET @PY_P_E_e1 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND ((patrimony.codepatrimony = 'E) e1)' and @ayearPrec <> 2017) OR (patrimony.codepatrimony = 'E) e2)' AND @ayearPrec = 2017))
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_E_e2 decimal(19,2)
SET @PY_P_E_e2 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND ((patrimony.codepatrimony = 'E) e2)' and @ayearPrec <> 2017) OR (patrimony.codepatrimony = 'E) e3)' AND @ayearPrec = 2017))
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_E_e3 decimal(19,2)
SET @PY_P_E_e3 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'E) e3)' AND @ayearPrec < 2017
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)


DECLARE @PY_P_E decimal(19,2)
SET @PY_P_E = @PY_P_E_e1 + @PY_P_E_e2 + @PY_P_E_e3

--"F)	Risconti passivi per progetti e ricerche in corso"
--"f 1)	Risconti passivi per progetti e ricerche finanziate e co-finanziate in corso"


DECLARE @PY_P_F_f1 decimal(19,2)
SET @PY_P_F_f1 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND ((patrimony.codepatrimony = 'f 1)' and @ayearPrec > 2017) OR (patrimony.codepatrimony = 'E) e1)' AND @ayearPrec = 2017))
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayearPrec 
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	)
,0)

DECLARE @PY_P_F decimal(19,2)
SET @PY_P_F = @PY_P_F_f1  

DECLARE @PY_TOTPASSIVO decimal(19,2)
SET @PY_TOTPASSIVO = @PY_P_A + @PY_P_B + @PY_P_C + @PY_P_D + @PY_P_E + @PY_P_F

/* DA CONTROLLARE : mancano nella struttura del fil .pdf

DECLARE @PY_P_AIX decimal(19,2)
SET @PY_P_AIX = @PY_TOTATTIVO - @PY_TOTPASSIVO	

--Calcolo utile/perdita di esercizio 
SET @PY_P_A = @PY_P_A + @PY_P_AIX
SET @PY_TOTPASSIVO = @PY_TOTPASSIVO +  @PY_P_AIX 

*/

-- Stato Patrimoniale Anno Corrente
--setuser'amministrazione' 

--SELECT @apertura,amount,entry.*,entrydetail.*
--	FROM entrydetail
--	JOIN entry
--	ON entry.yentry = entrydetail.yentry
--	AND entry.nentry = entrydetail.nentry
--	JOIN account
--	ON account.idacc = entrydetail.idacc
--	LEFT OUTER JOIN upb
--    ON upb.idupb  = entrydetail.idupb 
--	JOIN patrimony
--	ON patrimony.idpatrimony = account.idpatrimony
--	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
--	WHERE entry.adate BETWEEN @start AND @stop
--	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
--	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
--	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
--	AND patrimony.codepatrimony = 'A) I 1)'
--	and patrimony.patpart ='A'
--	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
--	AND patrimony.ayear = @ayear
--	--AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
--	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
--	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
--	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
--	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
--	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' ))

	
DECLARE @A_AI_aI1 decimal(19,2)
SET @A_AI_aI1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 1)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_AI_aI2 decimal(19,2)
SET @A_AI_aI2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 2)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_AI_aI3 decimal(19,2)
SET @A_AI_aI3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 3)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_AI_aI4 decimal(19,2)
SET @A_AI_aI4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 4)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_AI_aI5 decimal(19,2)
SET @A_AI_aI5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 5)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_AI decimal(19,2)
SET @A_AI = @A_AI_aI1 + @A_AI_aI2 + @A_AI_aI3 + @A_AI_aI4 + @A_AI_aI5


DECLARE @A_AII_aII1 decimal(19,2)
SET @A_AII_aII1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate  BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 1)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)
	

DECLARE @A_AII_aII2 decimal(19,2)
SET @A_AII_aII2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 2)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_AII_aII3 decimal(19,2)
SET @A_AII_aII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 3)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_AII_aII4 decimal(19,2)
SET @A_AII_aII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 4)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_AII_aII5 decimal(19,2)
SET @A_AII_aII5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 5)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)


DECLARE @A_AII_aII6 decimal(19,2)
SET @A_AII_aII6 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 6)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_AII_aII7 decimal(19,2)
SET @A_AII_aII7 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 7)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_AII decimal(19,2)
SET @A_AII = @A_AII_aII1 + @A_AII_aII2 + @A_AII_aII3 + @A_AII_aII4 + @A_AII_aII5 + @A_AII_aII6 + @A_AII_aII7

DECLARE @A_AIII decimal(19,2)
SET @A_AIII = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)


DECLARE @A_A decimal(19,2)
SET @A_A = @A_AI + @A_AII + @A_AIII

DECLARE @A_BI decimal(19,2)
SET @A_BI = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) I'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)


DECLARE @A_BII_bII1 decimal(19,2)
SET @A_BII_bII1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 1)e','B) II 1)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII1e decimal(19,2)
SET @A_BII_bII1e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 1)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII2 decimal(19,2)
SET @A_BII_bII2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 2)e','B) II 2)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)
DECLARE @A_BII_bII2e decimal(19,2)
SET @A_BII_bII2e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 2)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII3 decimal(19,2)
SET @A_BII_bII3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 3)e','B) II 3)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)
DECLARE @A_BII_bII3e decimal(19,2)
SET @A_BII_bII3e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 3)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII4 decimal(19,2)
SET @A_BII_bII4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 4)e','B) II 4)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII4e decimal(19,2)
SET @A_BII_bII4e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 4)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII5 decimal(19,2)
SET @A_BII_bII5 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 5)e','B) II 5)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII5e decimal(19,2)
SET @A_BII_bII5e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 5)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII6 decimal(19,2)
SET @A_BII_bII6 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 6)e','B) II 6)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII6e decimal(19,2)
SET @A_BII_bII6e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 6)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII7 decimal(19,2)
SET @A_BII_bII7 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 7)e','B) II 7)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII7e decimal(19,2)
SET @A_BII_bII7e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 7)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)
DECLARE @A_BII_bII8 decimal(19,2)
SET @A_BII_bII8 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 8)e','B) II 8)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII8e decimal(19,2)
SET @A_BII_bII8e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 8)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII9 decimal(19,2)
SET @A_BII_bII9 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 9)e','B) II 9)o')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII_bII9e decimal(19,2)
SET @A_BII_bII9e = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 9)e')
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BII decimal(19,2)
SET @A_BII = @A_BII_bII1 + @A_BII_bII2  + @A_BII_bII3  + @A_BII_bII4  + @A_BII_bII5  + @A_BII_bII6  + @A_BII_bII7  + @A_BII_bII8  + @A_BII_bII9 

DECLARE @A_BIIe decimal(19,2)
SET @A_BIIe = @A_BII_bII1e + @A_BII_bII2e  + @A_BII_bII3e  + @A_BII_bII4e  + @A_BII_bII5e  + @A_BII_bII6e  + @A_BII_bII7e  + @A_BII_bII8e  + @A_BII_bII9e

DECLARE @A_BIII decimal(19,2)
SET @A_BIII = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) III'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)


DECLARE @A_BIV_bIV1 decimal(19,2)
SET @A_BIV_bIV1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) IV 1)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BIV_bIV2 decimal(19,2)
SET @A_BIV_bIV2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) IV 2)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_BIV decimal(19,2)
SET @A_BIV = @A_BIV_bIV1 + @A_BIV_bIV2

DECLARE @A_B decimal(19,2)
SET @A_B = @A_BI + @A_BII + @A_BIII + @A_BIV


-- Ratei
DECLARE @A_C_c1 decimal(19,2)
SET @A_C_c1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'C) c1)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_C_c2 decimal(19,2)
SET @A_C_c2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'C) c2)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_C decimal(19,2)
SET @A_C = @A_C_c1 + @A_C_c2 

DECLARE @A_D_d1 decimal(19,2)
SET @A_D_d1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'd 1)'
	and patrimony.patpart ='A'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @A_D decimal(19,2)
SET @A_D = @A_D_d1  

DECLARE @TOTATTIVO decimal(19,2)
SET @TOTATTIVO = @A_A + @A_B + @A_C + @A_D



-------------------------------------------------------------------------
-----------------------  	PASSIVO          ----------------------------
-------------------------------------------------------------------------

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
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)



DECLARE @P_AII_aII1 decimal(19,2)
SET @P_AII_aII1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 1)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_AII_aII2 decimal(19,2)
SET @P_AII_aII2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 2)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)



DECLARE @P_AII_aII3 decimal(19,2)
SET @P_AII_aII3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 3)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)



DECLARE @P_AII decimal(19,2)
SET @P_AII = @P_AII_aII1 + @P_AII_aII2 + @P_AII_aII3


DECLARE @P_AIII_aIII1 decimal(19,2)
SET @P_AIII_aIII1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 1)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_AIII_aIII2 decimal(19,2)
SET @P_AIII_aIII2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 2)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)



DECLARE @P_AIII_aIII3 decimal(19,2)
SET @P_AIII_aIII3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 3)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)


DECLARE @P_AIII decimal(19,2)
SET @P_AIII = @P_AIII_aIII1 + @P_AIII_aIII2 + @P_AIII_aIII3


DECLARE @P_A decimal(19,2)
SET @P_A = @P_AI + @P_AII + @P_AIII

DECLARE @P_B decimal(19,2)
SET @P_B = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

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
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'C)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d1 decimal(19,2)
SET @P_D_d1 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 1)e','D) 1)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d1o decimal(19,2)
SET @P_D_d1o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 1)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d2 decimal(19,2)
SET @P_D_d2 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 2)e','D) 2)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d2o decimal(19,2)
SET @P_D_d2o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 2)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d3 decimal(19,2)
SET @P_D_d3 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 3)e','D) 3)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d3o decimal(19,2)
SET @P_D_d3o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 3)o')
	and patrimony.patpart ='P'
	AND (@idsor01 IS NULL OR  entry.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  entry.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  entry.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  entry.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  entry.idsor05 = @idsor05) 
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d4 decimal(19,2)
SET @P_D_d4 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 4)e','D) 4)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d4o decimal(19,2)
SET @P_D_d4o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 4)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d5 decimal(19,2)
SET @P_D_d5 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 5)e','D) 5)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d5o decimal(19,2)
SET @P_D_d5o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 5)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d6 decimal(19,2)
SET @P_D_d6 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 6)e','D) 6)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d6o decimal(19,2)
SET @P_D_d6o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 6)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d7 decimal(19,2)
SET @P_D_d7 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 7)e','D) 7)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d7o decimal(19,2)
SET @P_D_d7o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 7)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d8 decimal(19,2)
SET @P_D_d8 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 8)e','D) 8)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d8o decimal(19,2)
SET @P_D_d8o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 8)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d9 decimal(19,2)
SET @P_D_d9 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 9)e','D) 9)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)
DECLARE @P_D_d9o decimal(19,2)
SET @P_D_d9o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 9)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d10 decimal(19,2)
SET @P_D_d10 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 10)e','D) 10)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d10o decimal(19,2)
SET @P_D_d10o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 10)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d11 decimal(19,2)
SET @P_D_d11 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 11)e','D) 11)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d11o decimal(19,2)
SET @P_D_d11o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 11)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d12 decimal(19,2)
SET @P_D_d12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 12)e','D) 12)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D_d12o decimal(19,2)
SET @P_D_d12o = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 12)o')
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_D decimal(19,2)
SET @P_D = @P_D_d1 + @P_D_d2 + @P_D_d3 + @P_D_d4 + @P_D_d5+ @P_D_d6 + @P_D_d7 + @P_D_d8 + @P_D_d9 + @P_D_d10 + @P_D_d11 + @P_D_d12

DECLARE @P_Do decimal(19,2)
SET @P_Do = @P_D_d1o + @P_D_d2o + @P_D_d3o + @P_D_d4o + @P_D_d5o + @P_D_d6o + @P_D_d7o + @P_D_d8o + @P_D_d9o + @P_D_d10o + @P_D_d11o + @P_D_d12o


DECLARE @P_E_e1 decimal(19,2)
SET @P_E_e1 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'E) e1)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_E_e2 decimal(19,2)
SET @P_E_e2 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'E) e2)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_E_e3 decimal(19,2)
SET @P_E_e3 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'E) e3)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' )))
,0)

DECLARE @P_E decimal(19,2)
SET @P_E = @P_E_e1 + @P_E_e2 + @P_E_e3


--"F)	Risconti passivi per progetti e ricerche in corso"
--"f 1)	Risconti passivi per progetti e ricerche finanziate e co-finanziate in corso"

DECLARE @P_F_f1 decimal(19,2)
SET @P_F_f1 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	LEFT OUTER JOIN upb
    ON upb.idupb  = entrydetail.idupb 
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'f 1)'
	and patrimony.patpart ='P'
	AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL ) AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear
	AND (@idsor01 IS NULL OR  upb.idsor01 = @idsor01) 
	AND (@idsor02 IS NULL OR  upb.idsor02 = @idsor02) 
	AND (@idsor03 IS NULL OR  upb.idsor03 = @idsor03) 
	AND (@idsor04 IS NULL OR  upb.idsor04 = @idsor04) 
	AND (@idsor05 IS NULL OR  upb.idsor05 = @idsor05) 
	AND ((@apertura ='S' AND entry.identrykind=7) OR (@apertura ='N' ))
	)
,0)

DECLARE @P_F decimal(19,2)
SET @P_F = @P_F_f1  

DECLARE @TOTPASSIVO decimal(19,2)
SET @TOTPASSIVO = @P_A + @P_B + @P_C + @P_D + @P_E + @P_F



-------------------------------------------------
--Calcolo utile/perdita di esercizio
/*
DECLARE @P_AIX decimal(19,2)
SET @P_AIX = @TOTATTIVO - @TOTPASSIVO
SET @P_A = @P_A + @P_AIX
SET @TOTPASSIVO = @TOTPASSIVO +  @P_AIX 
*/
-------------------------------------------------
DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal


SELECT
@ayear			AS ayear      ,
@idupboriginal	as   idupb          ,
@codeupb	    as	 codeupb	    ,
@title		    as	 upb		    ,
@PY_A_AI_aI1  	as	 PY_A_AI_aI1  	,
@PY_A_AI_aI2  	as	 PY_A_AI_aI2  	,
@PY_A_AI_aI3  	as	 PY_A_AI_aI3  	,
@PY_A_AI_aI4  	as	 PY_A_AI_aI4  	,
@PY_A_AI_aI5  	as	 PY_A_AI_aI5  	,
@PY_A_AI  	as	 PY_A_AI  	,
@PY_A_AII_aII1  	as	 PY_A_AII_aII1  	,
@PY_A_AII_aII2  	as	 PY_A_AII_aII2  	,
@PY_A_AII_aII3  	as	 PY_A_AII_aII3  	,
@PY_A_AII_aII4  	as	 PY_A_AII_aII4  	,
@PY_A_AII_aII5  	as	 PY_A_AII_aII5  	,
@PY_A_AII_aII6  	as	 PY_A_AII_aII6  	,
@PY_A_AII_aII7  	as	 PY_A_AII_aII7  	,
@PY_A_AII  	as	 PY_A_AII  	,
@PY_A_AIII  	as	 PY_A_AIII  	,
@PY_A_A  	as	 PY_A_A  	,
@PY_A_BI  	as	 PY_A_BI  	,

@PY_A_BII_bII1  	as	 PY_A_BII_bII1  	,
@PY_A_BII_bII2  	as	 PY_A_BII_bII2  	,
@PY_A_BII_bII3  	as	 PY_A_BII_bII3  	,
@PY_A_BII_bII4  	as	 PY_A_BII_bII4  	,
@PY_A_BII_bII5  	as	 PY_A_BII_bII5  	,
@PY_A_BII_bII6  	as	 PY_A_BII_bII6  	,
@PY_A_BII_bII7  	as	 PY_A_BII_bII7  	,
@PY_A_BII_bII8  	as	 PY_A_BII_bII8  	,
@PY_A_BII_bII9  	as	 PY_A_BII_bII9  	,
@PY_A_BII  	as	 PY_A_BII  	,

@PY_A_BII_bII1e  	as	 PY_A_BII_bII1e  	,--> crediti esigibili entro l'anno
@PY_A_BII_bII2e  	as	 PY_A_BII_bII2e  	,
@PY_A_BII_bII3e  	as	 PY_A_BII_bII3e  	,
@PY_A_BII_bII4e  	as	 PY_A_BII_bII4e  	,
@PY_A_BII_bII5e  	as	 PY_A_BII_bII5e  	,
@PY_A_BII_bII6e  	as	 PY_A_BII_bII6e  	,
@PY_A_BII_bII7e  	as	 PY_A_BII_bII7e  	,
@PY_A_BII_bII8e  	as	 PY_A_BII_bII8e  	,
@PY_A_BII_bII9e  	as	 PY_A_BII_bII9e  	,
@PY_A_BIIe  	as	 PY_A_BIIe  	,

@PY_A_BIII  	as	 PY_A_BIII  	,
@PY_A_BIV_bIV1  	as	 PY_A_BIV_bIV1  	,
@PY_A_BIV_bIV2  	as	 PY_A_BIV_bIV2  	,
@PY_A_BIV  	as	 PY_A_BIV  	,
@PY_A_B  	as	 PY_A_B  	,
@PY_A_C_c1  	as	 PY_A_C_c1  	,
@PY_A_C_c2  	as	 PY_A_C_c2  	,
@PY_A_C  		as	 PY_A_C  		,
@PY_A_D_d1  	as	 PY_A_D_d1		,  
@PY_A_D 		as	 PY_A_D			, 
@PY_TOTATTIVO  	as	 PY_TOTATTIVO  	,
@PY_P_AI  	as	 PY_P_AI  	,
@PY_P_AII_aII1  	as	 PY_P_AII_aII1  	,
@PY_P_AII_aII2  	as	 PY_P_AII_aII2  	,
@PY_P_AII_aII3  	as	 PY_P_AII_aII3  	,
@PY_P_AII  	as	 PY_P_AII  	,
@PY_P_AIII_aIII1  	as	 PY_P_AIII_aIII1  	,
@PY_P_AIII_aIII2  	as	 PY_P_AIII_aIII2  	,
@PY_P_AIII_aIII3  	as	 PY_P_AIII_aIII3  	,
@PY_P_AIII  	as	 PY_P_AIII  	,
@PY_P_A  	as	 PY_P_A  	,
@PY_P_B  	as	 PY_P_B  	,
@PY_P_C  	as	 PY_P_C  	,

@PY_P_D_d1   	as	 PY_P_D_d1   	,
@PY_P_D_d2   	as	 PY_P_D_d2   	,
@PY_P_D_d3   	as	 PY_P_D_d3   	,
@PY_P_D_d4   	as	 PY_P_D_d4   	,
@PY_P_D_d5   	as	 PY_P_D_d5   	,
@PY_P_D_d6   	as	 PY_P_D_d6   	,
@PY_P_D_d7   	as	 PY_P_D_d7   	,
@PY_P_D_d8   	as	 PY_P_D_d8   	,
@PY_P_D_d9  	as	 PY_P_D_d9   	,
@PY_P_D_d10   	as	 PY_P_D_d10   	,
@PY_P_D_d11   	as	 PY_P_D_d11   	,
@PY_P_D_d12   	as	 PY_P_D_d12   	,
@PY_P_D   	as	 PY_P_D   	,

@PY_P_D_d1o  	as	 PY_P_D_d1o  	,
@PY_P_D_d2o  	as	 PY_P_D_d2o  	,
@PY_P_D_d3o  	as	 PY_P_D_d3o  	,
@PY_P_D_d4o  	as	 PY_P_D_d4o  	,
@PY_P_D_d5o  	as	 PY_P_D_d5o  	,
@PY_P_D_d6o  	as	 PY_P_D_d6o  	,
@PY_P_D_d7o  	as	 PY_P_D_d7o  	,
@PY_P_D_d8o  	as	 PY_P_D_d8o  	,
@PY_P_D_d9o 	as	 PY_P_D_d9o  	,
@PY_P_D_d10o  	as	 PY_P_D_d10o  	,
@PY_P_D_d11o  	as	 PY_P_D_d11o  	,
@PY_P_D_d12o  	as	 PY_P_D_d12o  	,
@PY_P_Do  		as	 PY_P_Do  		,

@PY_P_E_e1  	as	 PY_P_E_e1  	,
@PY_P_E_e2  	as	 PY_P_E_e2  	,
@PY_P_E_e3  	as	 PY_P_E_e3  	,
@PY_P_F_f1  	as	 PY_P_F_f1		,
@PY_TOTPASSIVO  as	 PY_TOTPASSIVO  ,
			
			
@A_AI_aI1  	as	A_AI_aI1  	,
@A_AI_aI2  	as	A_AI_aI2  	,
@A_AI_aI3  	as	A_AI_aI3  	,
@A_AI_aI4  	as	A_AI_aI4  	,
@A_AI_aI5  	as	A_AI_aI5  	,
@A_AI  		as	A_AI  	,
@A_AII_aII1  	as	A_AII_aII1  	,
@A_AII_aII2  	as	A_AII_aII2  	,
@A_AII_aII3  	as	A_AII_aII3  	,
@A_AII_aII4  	as	A_AII_aII4  	,
@A_AII_aII5  	as	A_AII_aII5  	,
@A_AII_aII6  	as	A_AII_aII6  	,
@A_AII_aII7  	as	A_AII_aII7  	,
@A_AII  	as	A_AII  	,
@A_AIII  	as	A_AIII  	,
@A_A  	as	A_A  	,
@A_BI  	as	A_BI  	,

@A_BII_bII1  	as	A_BII_bII1  	,
@A_BII_bII2  	as	A_BII_bII2  	,
@A_BII_bII3  	as	A_BII_bII3  	,
@A_BII_bII4  	as	A_BII_bII4  	,
@A_BII_bII5  	as	A_BII_bII5  	,
@A_BII_bII6  	as	A_BII_bII6  	,
@A_BII_bII7  	as	A_BII_bII7  	,
@A_BII_bII8  	as	A_BII_bII8  	,
@A_BII_bII9  	as	A_BII_bII9  	,
@A_BII  		as	A_BII  			,
@A_BII_bII1e  	as	A_BII_bII1e  	,--> crediti esigibili entro l'anno
@A_BII_bII2e  	as	A_BII_bII2e 	,
@A_BII_bII3e  	as	A_BII_bII3e		,
@A_BII_bII4e  	as	A_BII_bII4e  	,
@A_BII_bII5e  	as	A_BII_bII5e  	,
@A_BII_bII6e  	as	A_BII_bII6e  	,
@A_BII_bII7e  	as	A_BII_bII7e  	,
@A_BII_bII8e  	as	A_BII_bII8e  	,
@A_BII_bII9e  	as	A_BII_bII9e  	,
@A_BIIe  	as	A_BIIe  	,

@A_BIII  	as	A_BIII  	,
@A_BIV_bIV1  	as	A_BIV_bIV1  	,
@A_BIV_bIV2  	as	A_BIV_bIV2  	,
@A_BIV  	as	A_BIV  	,
@A_B  	as	A_B  	,
@A_C_c1  	as	A_C_c1  	,
@A_C_c2  	as	A_C_c2  	,
@A_C  		as	A_C  	,
@A_D_d1 		as	 A_D_d1	,		
@A_D 		as	 A_D			, 
@TOTATTIVO  	as	TOTATTIVO  	,
@P_AI  	as	P_AI  	,
@P_AII_aII1  	as	P_AII_aII1  	,
@P_AII_aII2  	as	P_AII_aII2  	,
@P_AII_aII3  	as	P_AII_aII3  	,
@P_AII  	as	P_AII  	,
@P_AIII_aIII1  	as	P_AIII_aIII1  	,
@P_AIII_aIII2  	as	P_AIII_aIII2  	,
@P_AIII_aIII3  	as	P_AIII_aIII3  	,
@P_AIII  	as	P_AIII  	,
@P_A  	as	P_A  	,
@P_B  	as	P_B  	,
@P_C  	as	P_C  	,

@P_D_d1  	as	P_D_d1  	,
@P_D_d2  	as	P_D_d2  	,
@P_D_d3  	as	P_D_d3  	,
@P_D_d4  	as	P_D_d4  	,
@P_D_d5  	as	P_D_d5  	,
@P_D_d6  	as	P_D_d6  	,
@P_D_d7  	as	P_D_d7  	,
@P_D_d8  	as	P_D_d8  	,
@P_D_d9  	as	P_D_d9  	,
@P_D_d10  	as	P_D_d10  	,
@P_D_d11  	as	P_D_d11  	,
@P_D_d12  	as	P_D_d12  	,
@P_D  	as	P_D  	,

@P_D_d1o  	as	P_D_d1o  	,
@P_D_d2o  	as	P_D_d2o  	,
@P_D_d3o  	as	P_D_d3o  	,
@P_D_d4o  	as	P_D_d4o  	,
@P_D_d5o  	as	P_D_d5o  	,
@P_D_d6o  	as	P_D_d6o  	,
@P_D_d7o  	as	P_D_d7o  	,
@P_D_d8o  	as	P_D_d8o  	,
@P_D_d9o  	as	P_D_d9o  	,
@P_D_d10o  	as	P_D_d10o  	,
@P_D_d11o  	as	P_D_d11o  	,
@P_D_d12o  	as	P_D_d12o  	,
@P_Do  	as	P_Do  	,


@P_E_e1  	as	P_E_e1  	,
@P_E_e2  	as	P_E_e2  	,
@P_E_e3  	as	P_E_e3  	,
@P_F_f1  	as	P_F_f1		,
	
@TOTPASSIVO  	as	TOTPASSIVO ,
  	case when @sortcode1 is null then  ( select sortcode from sorting where idsor = @idsor1 ) else @sortcode1 end as sortcode1,
 @titlecode1 	as titlecode1 	 
		
		
		
		
		

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

