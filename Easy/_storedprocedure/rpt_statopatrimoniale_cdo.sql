if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_statopatrimoniale_cdo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_statopatrimoniale_cdo]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [rpt_statopatrimoniale_cdo]
(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idupb		varchar(36),
	@showchildupb	char(1),
	@apertura   varchar(1),
	@idsor1 int, -- può valere null o value
	@showidsor1child char(1) -- se S considera l'idsor + figli
)
AS BEGIN
-- exec rpt_statopatrimoniale_cdo 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '%','N','N',2033,'N'
set @idsor1 = null --DA VALUTARE
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
		and  SLK1.idparent = @idsor1
End	

if(@idsor1 is null)
Begin
		insert into #ANALITICA1 
		select null
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
		printingordacc,
		_idsor1
)
SELECT
	idacc,
	codeacc,
	title,
	printingorder,
	null--#ANALITICA1._idsor1*/
FROM  account
	--CROSS JOIN #ANALITICA1 
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
					 WHERE  amount < 0 
					 AND entrydetail.idacc =  @sk_prec + SUBSTRING(#conti_d_ordine.idacc, 3,LEN(#conti_d_ordine.idacc) -2) 
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
					 WHERE  amount > 0 
					 AND entrydetail.idacc =  @sk_prec + SUBSTRING(#conti_d_ordine.idacc, 3,LEN(#conti_d_ordine.idacc) -2) 
					 AND  (entrydetail.idupb like @idupb  OR @idupb is null)
					 AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
					 AND entry.adate between  @firstdayPY and @lastdayPY
					 ),0)
			     
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
	WHERE  amount < 0 
		and entrydetail.idsor1 = #ANALITICA1._idsor1 
		AND entrydetail.idacc =  @sk_prec + SUBSTRING(account.idacc, 3,LEN(account.idacc) -2) 
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
	WHERE  amount > 0 
		and entrydetail.idsor1 = #ANALITICA1._idsor1 
		AND entrydetail.idacc =  @sk_prec + SUBSTRING(account.idacc, 3,LEN(account.idacc) -2) 
		AND  (entrydetail.idupb like @idupb  OR @idupb is null)
		AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND entry.adate between @firstdayPY and @lastdayPY
		and  ((account.flag&4)<> 0)
	group by account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1

End

			     

 
 

SELECT * FROM
#conti_d_ordine



END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


exec rpt_statopatrimoniale_cdo 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '%','N','N',2033,'N'