
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_statopatrimoniale_cdo_coordanal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_statopatrimoniale_cdo_coordanal]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser'amministrazione'
CREATE  PROCEDURE [rpt_statopatrimoniale_cdo_coordanal]
(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idupb		varchar(36),
	@showchildupb	char(1),
	@apertura   varchar(1),
	@showcoordanal char(1),-- Mostra figli
	@idsor1 int, -- può valere null o value
	@showidsor1child char(1) -- se S considera l'idsor + figli
)
AS BEGIN

--exec rpt_statopatrimoniale_cdo_coordanal 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '%','N','N','S',NULL,'N'
--exec rpt_statopatrimoniale_cdo_coordanal 2017, {ts '2017-01-01 00:00:00'}, {ts '2017-12-31 00:00:00'}, '%','N','N','N',NULL,'N'
-- Stato Patrimoniale Anno Precedente
DECLARE @firstdayPY datetime
DECLARE @lastdayPY datetime
SET @firstdayPY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear-1),105)
SET @lastdayPY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)


DECLARE @sk_prec char(2)
SET @sk_prec = SUBSTRING(CONVERT(varchar(4),@ayear-1),3,2)


-- Stato Patrimoniale Anno Corrente
DECLARE @sk char(2)
SET @sk = SUBSTRING(CONVERT(varchar(4),@ayear),3,2)

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END

DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal


DECLARE @Mostracoordianataanalitica1 char(1)
SELECT @Mostracoordianataanalitica1= isnull(paramvalue,'N') 
FROM reportadditionalparam WHERE paramname = 'Mostracoordianataanalitica1'
and reportname = 'statopatrimonialedm2014_new'

create table #ANALITICA1(_idsor1 int)
if ((@idsor1 is not null) and  @showidsor1child = 'N')
Begin
	insert into #ANALITICA1 select @idsor1
	
End	

if ((@idsor1 is not null ) and  @showidsor1child = 'S')
Begin
	insert into #ANALITICA1 (_idsor1)
	select distinct entrydetail.idsor1 
	from entrydetail 
	join entry 
		ON entry.yentry = entrydetail.yentry AND entry.nentry = entrydetail.nentry
	join sortinglink SLK1
		on SLK1.idchild = entrydetail.idsor1 
	where entry.adate BETWEEN @start AND @stop
		AND (entrydetail.idupb like @idupb  OR @idupb = '%')
		AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		and  (SLK1.idparent = @idsor1)
End	
print @Mostracoordianataanalitica1
if(@idsor1 is null AND @Mostracoordianataanalitica1 = 'S')
Begin
	insert into #ANALITICA1 (_idsor1)
	select distinct entrydetail.idsor1 
	from entrydetail 
	join entry 
		ON entry.yentry = entrydetail.yentry AND entry.nentry = entrydetail.nentry
	join sortinglink SLK1
		on SLK1.idchild = entrydetail.idsor1 
	where entry.adate BETWEEN @start AND @stop
		AND (entrydetail.idupb like @idupb  OR @idupb = '%')
		AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	 
end



CREATE TABLE #conti_d_ordine
	(
		idacc 		varchar(38), 
		code	varchar(50), 
		title		varchar(150), 
		printingordacc varchar(50), 
		py_totaledare decimal(19,2),
		py_totaleavere decimal(19,2),
		p_totaledare decimal(19,2),
		p_totaleavere decimal(19,2),
		_idsor1 int
	)


INSERT INTO #conti_d_ordine
(
		idacc, 
		code, 
		title, 
		printingordacc
)
SELECT
	idacc,
	codeacc,
	title,
	printingorder
FROM  account
WHERE ((account.flag&4)<> 0)
AND account.ayear = @ayear 

if(@idsor1 is null)
Begin
	UPDATE #conti_d_ordine
	SET   p_totaledare = -isnull((SELECT SUM(amount) 
						 FROM entrydetail  
						 JOIN entry on
						 entry.nentry = entrydetail.nentry and
						 entry.yentry = entrydetail.yentry 
						 WHERE  amount < 0 
							AND(entrydetail.idupb like @idupb  OR @idupb is null) AND
							 entrydetail.idacc = #conti_d_ordine.idacc and
							 entry.adate between @start and @stop
							 AND (@apertura ='N' or entry.identrykind=7)
							 ),0)

	UPDATE #conti_d_ordine
	SET   p_totaleavere =  isnull((SELECT SUM(amount) 
					 FROM entrydetail  
					 JOIN entry on
					 entry.nentry = entrydetail.nentry and
					 entry.yentry = entrydetail.yentry 
					 WHERE  amount > 0 
					 AND entrydetail.idacc = #conti_d_ordine.idacc 
					 AND  (entrydetail.idupb like @idupb  OR @idupb is null)
					 AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
					 AND entry.adate between @start and @stop
					 AND (@apertura ='N' or entry.identrykind=7)
					 ),0)

			     
	UPDATE #conti_d_ordine
	SET   py_totaledare = -isnull((SELECT SUM(amount) 
					 FROM entrydetail  
					 JOIN entry on
					 entry.nentry = entrydetail.nentry and
					 entry.yentry = entrydetail.yentry 
					 join accountlookup ON #conti_d_ordine.idacc = accountlookup.newidacc
					 WHERE  amount < 0 
					 AND  entrydetail.idacc = accountlookup.oldidacc
					 AND  (entrydetail.idupb like @idupb  OR @idupb is null)
					 AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
					 AND entry.adate between @firstdayPY and @lastdayPY
					 ),0)


	UPDATE #conti_d_ordine
	SET   py_totaleavere = isnull((SELECT SUM(amount) 
					 FROM entrydetail  
					 JOIN entry on
					 entry.nentry = entrydetail.nentry and
					 entry.yentry = entrydetail.yentry 
					 join accountlookup ON #conti_d_ordine.idacc = accountlookup.newidacc
					 WHERE  amount > 0 
					 AND  entrydetail.idacc = accountlookup.oldidacc
					 AND  (entrydetail.idupb like @idupb  OR @idupb is null)
					 AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
					 AND entry.adate between  @firstdayPY and @lastdayPY
					 ),0)
					 
	SELECT * FROM
	#conti_d_ordine
			     
End
Else
Begin
	insert into #conti_d_ordine(
			idacc, 
			code, 
			title, 
			printingordacc,
			_idsor1,
			p_totaledare)
	SELECT 	account.idacc, account.codeacc, account.title, account.printingorder,
			entrydetail.idsor1, 
			-SUM(amount) 
	FROM entrydetail  
	JOIN entry on
		entry.nentry = entrydetail.nentry and entry.yentry = entrydetail.yentry 
	join account 
		on entrydetail.idacc = account.idacc
	join #ANALITICA1
		on #ANALITICA1._idsor1 = entrydetail.idsor1
	WHERE  amount < 0 
		AND(entrydetail.idupb like @idupb  OR @idupb is null)
		and entrydetail.idsor1 = #ANALITICA1._idsor1 
		AND entrydetail.idacc = account.idacc and
		entry.adate between @start and @stop
		AND (@apertura ='N' or entry.identrykind=7)
		and  ((account.flag&4)<> 0)AND account.ayear = @ayear 
	group by account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1

	insert into #conti_d_ordine(
			idacc, 
			code, 
			title, 
			printingordacc,
			_idsor1,
			p_totaleavere)
	SELECT	account.idacc, account.codeacc, account.title, account.printingorder,
			entrydetail.idsor1, 
			SUM(amount) 
	FROM entrydetail  
	JOIN entry on
		entry.nentry = entrydetail.nentry and entry.yentry = entrydetail.yentry 
	join account 
		on entrydetail.idacc = account.idacc
	join #ANALITICA1
		on #ANALITICA1._idsor1 = entrydetail.idsor1
	WHERE  amount > 0 
		AND(entrydetail.idupb like @idupb  OR @idupb is null) 
		and entrydetail.idsor1 = #ANALITICA1._idsor1 
		AND entrydetail.idacc = account.idacc and
		entry.adate between @start and @stop
		AND (@apertura ='N' or entry.identrykind=7)
		 AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		and  ((account.flag&4)<> 0)AND account.ayear = @ayear 
	group by account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1					     

	insert into #conti_d_ordine(
			idacc, 
			code, 
			title, 
			printingordacc,
			_idsor1,
			py_totaledare )
	SELECT	account.idacc, account.codeacc, account.title, account.printingorder,
		entrydetail.idsor1, 
		-  SUM(amount) 
	FROM entrydetail  
	JOIN entry on
		entry.nentry = entrydetail.nentry and
		entry.yentry = entrydetail.yentry 
	join account 
		on entrydetail.idacc = account.idacc
	join #ANALITICA1
		on #ANALITICA1._idsor1 = entrydetail.idsor1
	 join accountlookup ON entrydetail.idacc = accountlookup.oldidacc AND accountlookup.newidacc= account.idacc
	WHERE  amount < 0 
		and entrydetail.idsor1 = #ANALITICA1._idsor1 
		AND  (entrydetail.idupb like @idupb  OR @idupb is null)
		AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND entry.adate between @firstdayPY and @lastdayPY
		and  ((account.flag&4)<> 0)
	group by account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1

	insert into #conti_d_ordine(
			idacc, 
			code, 
			title, 
			printingordacc,
			_idsor1,
			py_totaleavere )
	SELECT	account.idacc, account.codeacc, account.title, account.printingorder,
		entrydetail.idsor1, 
		 SUM(amount) 
	FROM entrydetail  
	JOIN entry on
		entry.nentry = entrydetail.nentry and
		entry.yentry = entrydetail.yentry 
	join account 
		on entrydetail.idacc = account.idacc
	join #ANALITICA1
		on #ANALITICA1._idsor1 = entrydetail.idsor1
	join accountlookup ON entrydetail.idacc = accountlookup.oldidacc AND accountlookup.newidacc= account.idacc
	WHERE  amount > 0 
		and entrydetail.idsor1 = #ANALITICA1._idsor1 
		AND  (entrydetail.idupb like @idupb  OR @idupb is null)
		AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND entry.adate between @firstdayPY and @lastdayPY
		and  ((account.flag&4)<> 0)
	group by account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1


	if(@idsor1 is not null and @showidsor1child =  'S' and @showcoordanal = 'N')
		update #conti_d_ordine set _idsor1 = @idsor1

	SELECT 
		idacc	, 
		code, 
		title, 
		printingordacc , 
		SUM(py_totaledare)  AS py_totaledare,
		SUM(py_totaleavere) AS py_totaleavere,
		SUM(p_totaledare) AS p_totaledare,
		SUM(p_totaleavere) AS p_totaleavere,
		_idsor1 
	FROM #conti_d_ordine			
	group by idacc, code, title, printingordacc , _idsor1
End

			     

 
 




END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--exec rpt_statopatrimoniale_cdo_coordanal 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '%','N','N','S',2033,'S'
