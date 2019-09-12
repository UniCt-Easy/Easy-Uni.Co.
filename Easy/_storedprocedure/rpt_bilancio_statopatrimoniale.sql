if OBJECTPROPERTY(object_id('rpt_bilancio_statopatrimoniale'), 'IsProcedure') = 1
	drop procedure rpt_bilancio_statopatrimoniale
go

CREATE  PROCEDURE [rpt_bilancio_statopatrimoniale]
	@ayear			int,
	@start			datetime,
	@stop			datetime,
	@nlevel 		varchar(1),
	@filteraccount 		varchar(50),
	@idsor1			varchar(36),
	@showchildsor1 		char(1),
	@idsor2			varchar(36),
	@showchildsor2 		char(1),
	@idsor3			varchar(36),
	@showchildsor3 		char(1)
	AS
	BEGIN
	CREATE TABLE #bilanciostatopatrimoniale
		(
		idacc1 		varchar(38), 
		code1		varchar(50), 
		title1		varchar(150), 
		printingordacc1 varchar(50), 
		idacc2	 	varchar(38), 
		code2		varchar(50), 
		title2		varchar(150), 
		printingordacc2 varchar(50), 
		idacc3	 	varchar(38), 
		code3		varchar(50), 
		title3		varchar(150), 
		printingordacc3 varchar(50), 
		idacc4	 	varchar(38), 
		code4		varchar(50), 
		title4		varchar(150), 
		printingordacc4 varchar(50), 
		idacc5	 	varchar(38), 
		code5		varchar(50), 
		title5		varchar(150), 
		printingordacc5 varchar(50), 
		idacc	 	varchar(38), 
		dare 		float,
		avere 		float 				
	)
DECLARE @idsortingkind1 varchar(20)
DECLARE @idsortingkind2 varchar(20)
DECLARE @idsortingkind3 varchar(20)
SELECT  @idsortingkind1 = idsortingkind1,
	@idsortingkind2 = idsortingkind2,
	@idsortingkind3 = idsortingkind3
FROM  config WHERE ayear = @ayear
-- Valuta se considerare i figli o meno dell'idsor
	IF (@showchildsor1 = 'S') set @idsor1 = @idsor1+'%' 
	IF (@showchildsor2 = 'S') set @idsor2 = @idsor2+'%' 
	IF (@showchildsor3 = 'S') set @idsor3 = @idsor3+'%' 
-- Se ho scelto un livello sotostante del livello operativo utilizzo quello, 
-- altrimenti userò il I liv.operativo
	DECLARE @levelusable	varchar(20)
	SELECT @levelusable = MIN(nlevel)
		FROM accountlevel
		WHERE flagusable = 'S'	AND ayear = @ayear
	IF @levelusable < @nlevel
		SELECT @levelusable = @nlevel
	
-- Calcola la lunghezza del filtro in base ad nlevel		
	--DECLARE @filteraccount varchar(20)
	SET @filteraccount = RTRIM(@filteraccount) PRINT @filteraccount
	IF @filteraccount = ''
		SELECT @filteraccount = NULL
	
	DECLARE @lenfilter integer
	SET @lenfilter = DATALENGTH(RTRIM(ISNULL(@filteraccount,''))) PRINT @lenfilter
	
	DECLARE @newnlevel integer
	SET @newnlevel = (CONVERT(int, @nlevel)*4)+2  PRINT @newnlevel
	DECLARE @nlevel1 integer SET @nlevel1 = 6
	DECLARE @nlevel2 integer SET @nlevel2 = 10
	DECLARE @nlevel3 integer SET @nlevel3 = 14
	DECLARE @nlevel4 integer SET @nlevel4 = 18
	DECLARE @nlevel5 integer SET @nlevel5 = 22
	INSERT INTO #bilanciostatopatrimoniale
      		(
		idacc1,
		idacc2,
		idacc3,
		idacc4,
		idacc5,
		idacc,
		dare,		-->		-
		avere		-->		+ 
		)
		SELECT 
			SUBSTRING(account.idacc, 1, @nlevel1),
			SUBSTRING(account.idacc, 1, @nlevel2),
			SUBSTRING(account.idacc, 1, @nlevel3),
			SUBSTRING(account.idacc, 1, @nlevel4),
			SUBSTRING(account.idacc, 1, @nlevel5),
			SUBSTRING(account.idacc, 1, @newnlevel),  			
			case when (amount <0) then amount
						else 0
			end,
			case when amount >0 then amount 
						else 0
			end
		 FROM entry
			JOIN entrydetail
			ON entry.yentry  = entrydetail.yentry 
			AND entry.nentry = entrydetail.nentry 
			JOIN account
			ON account.idacc = entrydetail.idacc
			LEFT OUTER JOIN sorting S1
			 on entrydetail.idsor1 = S1.idsor  and 
			 S1.idsorkind = @idsortingkind1 
			LEFT OUTER JOIN sorting S2
			 on entrydetail.idsor2 = S2.idsor  and 
			 S2.idsorkind = @idsortingkind2 
			LEFT OUTER JOIN sorting S3
			 on entrydetail.idsor3 = S3.idsor and 
			 S3.idsorkind = @idsortingkind3 
			WHERE entry.yentry = @ayear				
			and (entry.adate BETWEEN @start AND @stop)
			and (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilter) = @filteraccount)
			and (account.nlevel = @levelusable)
			and (ISNULL(entrydetail.idsor1,'') LIKE @idsor1)
			and (ISNULL(entrydetail.idsor2,'') LIKE @idsor2)
			and (ISNULL(entrydetail.idsor3,'') LIKE @idsor3)
	END
  
	update #bilanciostatopatrimoniale set code1	= codeacc ,
				title1	= title ,
				printingordacc1 = printingorder
				from account 
				where #bilanciostatopatrimoniale.idacc1 = account.idacc 
	if (@nlevel >2)
		update #bilanciostatopatrimoniale set code2	= codeacc ,
				title2	= title ,
				printingordacc2 = printingorder
				from account 
				where #bilanciostatopatrimoniale.idacc2 = account.idacc
		else update #bilanciostatopatrimoniale 
				set idacc2 = null
				
	if (@nlevel >3)
		update #bilanciostatopatrimoniale set code3	= codeacc ,
				title3	= title ,
				printingordacc3 = printingorder
				from account 
				where #bilanciostatopatrimoniale.idacc3 = account.idacc
		else update #bilanciostatopatrimoniale
				set idacc3 = null
			
	if (@nlevel >4 )
		update #bilanciostatopatrimoniale set code4	= codeacc ,
				title4	= title ,
				printingordacc4 = printingorder
				from account 
				where #bilanciostatopatrimoniale.idacc4 = account.idacc
		else update #bilanciostatopatrimoniale
				set idacc4 = null
	if (@nlevel >5 )
		update #bilanciostatopatrimoniale set code5	= codeacc ,
				title5	= title ,
				printingordacc5 = printingorder
				from account 
				where #bilanciostatopatrimoniale.idacc5 = account.idacc
		else update #bilanciostatopatrimoniale
				set idacc5 = null
				
	SELECT  
	idacc1, 
	code1,	
	title1,	
	printingordacc1,	
	idacc2, 
	code2,	
	title2,	
	printingordacc2,	
	idacc3, 
	code3,	
	title3,	
	printingordacc3,	
	idacc4, 
	code4,	
	title4,	
	printingordacc4,	
	idacc5, 
	code5,	
	title5,	
	printingordacc5,	
	account.codeacc as 'codeaccount' 	,
	#bilanciostatopatrimoniale.idacc	 		,
	account.title as 'titleaccount'  	,
	account.printingorder			,	
	sum(isnull(dare,0.0)) as 'dare'	,
	sum(isnull(avere,0.0)) as 'avere'
	FROM #bilanciostatopatrimoniale 
	join account 
	on #bilanciostatopatrimoniale.idacc = account.idacc
	GROUP BY #bilanciostatopatrimoniale.idacc,account.codeacc,account.printingorder,account.title,account.idacc,
	idacc1,code1,title1,printingordacc1,idacc2,code2,title2,printingordacc2,idacc3,code3,title3,printingordacc3,idacc4,code4,title4,printingordacc4,idacc5,code5,title5,printingordacc5
ORDER BY account.printingorder,account.codeacc
	

