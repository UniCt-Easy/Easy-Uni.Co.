if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_newpartitario_spesa_cassa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_newpartitario_spesa_cassa]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [rpt_newpartitario_spesa_cassa]
	@ayear int,
	@kind char(1),	-- @kind vale sempre S, prechè per C ed R c'è la stampa rpt_partitario_spesa_tutte_fasi
	@idupb	varchar(36),
	@nlevel tinyint,
	@start datetime,
	@stop datetime,
	@showupb char(1),
	@showchildupb char(1),
	@suppressifblank char(1),
	@flagnofficial	char(1),
	@idfin int
AS
BEGIN
--exec rpt_newpartitario_spesa_cassa 2005, 'S', '%',  3, {ts '2005-01-01 00:00:00'}, {ts '2005-12-31 00:00:00'}, 'S', 'N', 'S', 'N', NULL		
--exec rpt_newpartitario_spesa_cassa 2011, 'S', '%', 2, {ts '2011-01-01 00:00:00'}, {ts '2011-12-31 00:00:00'}, 'N', 'N', 'S', 'N', NULL		
CREATE TABLE #previousexpense
(
	idfin int,
	idupb varchar(36),
	initialprevision decimal(19,2),
	finvar decimal(19,2),
	cassaphase_amount decimal(19,2)
)
DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb

IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END	

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'


DECLARE @levelusable tinyint
SELECT 	@levelusable = MIN(nlevel)
FROM 	finlevel
WHERE 	flag&2 <> 0 AND ayear = @ayear

DECLARE @finphase tinyint
DECLARE @finname varchar(50)
SELECT  @finphase = appropriationphasecode FROM config WHERE 	ayear = @ayear
SELECT  @finname = description FROM expensephase WHERE nphase = @finphase

DECLARE @maxexpensephase tinyint 
DECLARE @phasecassa varchar(50)
SELECT  @maxexpensephase = MAX(nphase) FROM 	expensephase
SELECT  @phasecassa = description FROM expensephase WHERE nphase = @maxexpensephase


DECLARE @regphase tinyint 
SELECT  @regphase = expenseregphase FROM uniconfig


DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@nlevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@nlevel < @level_input ) AND (@idfin is not null)
BEGIN
	SET  @nlevel = @level_input
END

IF (@levelusable < @nlevel)
BEGIN	
	SET @levelusable = @nlevel
END
 
DECLARE @level varchar(50)
SELECT  @level = description 
	FROM    finlevel
	WHERE   nlevel = @nlevel AND ayear = @ayear

CREATE TABLE #expense
(
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	idfin int,
	rowkind	int,
	idmov int,
	nphase tinyint,
	operationdate datetime,
	operationkind varchar(55),
	idreg int,
	ymov int,
	nmov int,
	nofficial int,
	nsubmov int,
	ndoc int,
	description varchar(150),
    doc varchar(150),
	initialprevision decimal(19,2),
	finvar decimal(19,2),
	finphase_amount decimal(19,2),
	cassaphase_amount decimal(19,2),
	emessiondate datetime,
	printeddate datetime,
	trasmitteddate datetime,
	transactiondate datetime,
	annulmentdate datetime,
	annotations varchar(400),
	available decimal(19,2),
	hierarchy varchar (50)
)

DECLARE @firstday datetime
SET 	@firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)

DECLARE @cashvaliditykind       	int
SELECT  @cashvaliditykind = cashvaliditykind
FROM    config
WHERE   ayear = @ayear

DECLARE @previsionkind char(1) 
SELECT  @previsionkind =  
	 CASE 
		WHEN fin_kind IN (1,3) THEN 'C'
		WHEN fin_kind = 2 THEN 'S'
	 END
FROM  config 
WHERE config.ayear = @ayear

DECLARE @secprevisionkind    char(1) 
SELECT  @secprevisionkind  = 
	 CASE 
		WHEN fin_kind = 3 THEN 'S'
		ELSE NULL
	END
FROM config 
WHERE config.ayear = @ayear

IF (DATEDIFF(DAY,@start, @firstday) = 0)
BEGIN
	if(@previsionkind = 'S')
	Begin	
		INSERT INTO #expense
		(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			initialprevision
		)
		SELECT 
			isnull(finlink.idparent, fin.idfin),
			isnull(@fixedidupb,finyear.idupb),
			1,
			@firstday,
			'Prev.iniziale',
			SUM(finyear.prevision)		
		FROM finyear  
		JOIN fin
			ON finyear.idfin = fin.idfin
		left outer JOIN finlink
			ON finlink.idchild = finyear.idfin
			AND finlink.nlevel = @level_input--@nlevel
		WHERE isnull(@fixedidupb,finyear.idupb) like @idupb 
			and fin.ayear = @ayear
			AND ((fin.flag&1)<>0) 
			AND fin.nlevel =  @nlevel--@levelusable
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		GROUP BY isnull(@fixedidupb,finyear.idupb), isnull(finlink.idparent, fin.idfin)
	End
	if( @secprevisionkind = 'S')
		Begin
		INSERT INTO #expense
		(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			initialprevision
		)
		SELECT 
			isnull(finlink.idparent, fin.idfin),
			isnull(@fixedidupb,finyear.idupb),
			1,
			@firstday,
			'Prev.iniziale',
			SUM(finyear.secondaryprev)		
		FROM finyear  
		JOIN fin
			ON finyear.idfin = fin.idfin
		left outer JOIN finlink
			ON finlink.idchild = finyear.idfin
			AND finlink.nlevel = @level_input--@nlevel
		WHERE isnull(@fixedidupb,finyear.idupb) like @idupb 
			and fin.ayear = @ayear
			AND ((fin.flag&1)<>0) 
			AND fin.nlevel =  @nlevel--@levelusable
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		GROUP BY isnull(@fixedidupb,finyear.idupb), isnull(finlink.idparent, fin.idfin)
		End

END


IF (DATEDIFF(DAY,@start, @firstday) <> 0)
BEGIN
	if(@previsionkind = 'S')
	Begin	
			INSERT INTO #expense	
				(
				idfin,
				idupb,
				rowkind,
				operationdate,
				operationkind,
				initialprevision
				)
			SELECT isnull(finlink.idparent, finyear.idfin),
				   isnull(@fixedidupb, finyear.idupb),
					1,
					DATEADD(dd, -1, @start),
					'Tot.prec.',
				   SUM(finyear.prevision)
			FROM finyear
			JOIN fin
				ON finyear.idfin = fin.idfin
			left outer JOIN finlink
				ON finlink.idchild = finyear.idfin
				AND finlink.nlevel = @level_input
			WHERE isnull(@fixedidupb,finyear.idupb) like @idupb 
				AND fin.ayear = @ayear
				AND ((fin.flag&1)<>0) 
				AND fin.nlevel = @nlevel
				AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
			GROUP by isnull(@fixedidupb, finyear.idupb),isnull(finlink.idparent, finyear.idfin)
	End	
	if( @secprevisionkind = 'S')
		Begin
			INSERT INTO #expense	
				(
				idfin,
				idupb,
				rowkind,
				operationdate,
				operationkind,
				initialprevision
				)
			SELECT isnull(finlink.idparent, finyear.idfin),
				   isnull(@fixedidupb, finyear.idupb),
					1,
					DATEADD(dd, -1, @start),
					'Tot.prec.',
				   SUM(finyear.secondaryprev)
			FROM finyear
			JOIN fin
				ON finyear.idfin = fin.idfin
			left outer JOIN finlink
				ON finlink.idchild = finyear.idfin
				AND finlink.nlevel = @level_input
			WHERE isnull(@fixedidupb,finyear.idupb) like @idupb 
				AND fin.ayear = @ayear
				AND ((fin.flag&1)<>0) 
				AND fin.nlevel = @nlevel
				AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
			GROUP by isnull(@fixedidupb, finyear.idupb),isnull(finlink.idparent, finyear.idfin)
		End
			INSERT INTO #expense
			(
				idfin,
				idupb,
				rowkind,
				operationdate,
				operationkind,
				finvar
			)
			SELECT 
				isnull(finlink.idparent, finvardetail.idfin),
				isnull(@fixedidupb,finvardetail.idupb),
				1,
				DATEADD(dd, -1, @start),
				'Tot.prec.',
				SUM(finvardetail.amount)
			FROM finvardetail
			JOIN finvar
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			JOIN fin
				ON finvardetail.idfin = fin.idfin
			LEFT OUTER JOIN finlink
				ON finlink.idchild = finvardetail.idfin  
				AND finlink.nlevel = @nlevel	
			WHERE isnull(@fixedidupb,finvardetail.idupb) like @idupb 
				AND finvar.flagprevision ='S'
				AND finvar.idfinvarstatus = 5
				AND finvar.adate < @start
				AND ((fin.flag&1)<>0) 
				AND finvar.yvar = @ayear
				AND (@idfin IS NULL OR isnull(finlink.idparent, finvardetail.idfin) = @idfin)	
			GROUP by isnull(@fixedidupb,finvardetail.idupb),isnull(finlink.idparent, finvardetail.idfin)

			INSERT INTO #expense
				(
				idfin,
				idupb,
				rowkind,
				operationdate,
				operationkind,
				cassaphase_amount
				)
			SELECT 
				isnull(finlink.idparent, HPV.idfin),
				isnull(@fixedidupb,HPV.idupb),
				1,
				DATEADD(dd, -1, @start),
				'Tot.prec.',
				SUM(HPV.amount)
			FROM historypaymentview HPV
			left outer JOIN finlink
				ON finlink.idchild = HPV.idfin	
				AND finlink.nlevel = @nlevel
			WHERE HPV.competencydate < @start
				AND HPV.ymov = @ayear
				AND isnull(@fixedidupb,HPV.idupb) like @idupb 
				AND (@idfin IS NULL OR isnull(finlink.idparent, HPV.idfin) = @idfin)	
			GROUP by isnull(@fixedidupb,HPV.idupb),isnull(finlink.idparent, HPV.idfin)


	
			IF (@cashvaliditykind <> 4)
			BEGIN
				INSERT INTO #expense
					(
					idfin,
					idupb,
					rowkind,
					operationdate,
					operationkind,
					cassaphase_amount
					)
				SELECT 
					isnull(finlink.idparent, HPV.idfin),
					isnull(@fixedidupb,HPV.idupb),
					1,
					DATEADD(dd, -1, @start),
					'Tot.prec.',
					SUM(expensevar.amount)
				FROM expensevar
				JOIN historypaymentview HPV
					ON HPV.idexp = expensevar.idexp
				left outer JOIN finlink
					ON finlink.idchild = HPV.idfin	
					AND finlink.nlevel = @nlevel
				WHERE HPV.ymov = @ayear
					AND isnull(@fixedidupb,HPV.idupb) like @idupb 
					AND (@idfin IS NULL OR isnull(finlink.idparent, HPV.idfin) = @idfin)	
					AND expensevar.yvar = @ayear
					AND expensevar.adate < @start
					AND HPV.competencydate <= @start
					AND HPV.ymov = @ayear
				GROUP by isnull(@fixedidupb,HPV.idupb),isnull(finlink.idparent, HPV.idfin)

	END


END	

--	Variazioni di previsione
	INSERT INTO #expense
		(
		idfin,
		idupb,
		rowkind,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nofficial,
		description,
		finvar
		)
	SELECT 
		isnull(finlink.idparent, fin.idfin),
		isnull(@fixedidupb,finvardetail.idupb),
		2,
		finvar.adate,
		'Var.prev.',
		finvar.yvar,
		finvar.nvar,
		CASE finvar.official
			WHEN 'S' THEN finvar.nofficial
			ELSE NULL
		END,
		finvar.description,
		finvardetail.amount
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	left outer JOIN finlink
		ON finlink.idchild = finvardetail.idfin	
		AND finlink.nlevel = @level_input
	JOIN fin
		ON fin.idfin = finvardetail.idfin
	WHERE finvar.flagprevision = 'S'	
		AND finvar.adate BETWEEN @start AND @stop
		AND fin.ayear = @ayear
		AND isnull(@fixedidupb, finvardetail.idupb) like @idupb 
		AND ((fin.flag&1)<>0) 
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	

-- Movimenti di spesa / fase cassa
INSERT INTO #expense
		(
		idfin,
		idmov,
		idupb,
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		ndoc,
		description,
		doc,
		idreg,
		cassaphase_amount
		)
SELECT 
	isnull(FL1.idparent, fin.idfin),
	HPV.idexp,
	isnull(@fixedidupb,HPV.idupb),
	15,
	@maxexpensephase,
	HPV.competencydate,
	@phasecassa,
	HPV.ymov,
	HPV.nmov,
	HPV.npay,
	HPV.description,
	CASE
		WHEN HPV.doc IS NOT NULL AND 
			HPV.docdate IS NULL THEN
			'Pag. ' + HPV.doc
		WHEN HPV.doc IS NOT NULL AND
			HPV.docdate IS NOT NULL THEN
			'Pag. ' + HPV.doc + 
			' del ' + CONVERT(varchar(20), HPV.docdate, 105)
		ELSE
			(NULL)
	END,
	HPV.idreg,
	HPV.amount
FROM historypaymentview HPV
left outer JOIN finlink
	ON finlink.idchild = HPV.idfin	
	AND finlink.nlevel = @level_input
left outer JOIN finlink FL1
	ON FL1.idchild = HPV.idfin	
	AND FL1.nlevel = @nlevel
JOIN fin
	ON fin.idfin = FL1.idparent
WHERE HPV.competencydate BETWEEN @start AND @stop
	AND isnull(@fixedidupb, HPV.idupb) like @idupb 
	AND HPV.ymov = @ayear
	AND fin.ayear = @ayear
	AND ((fin.flag&1)<>0) -- Spesa
	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)

-- Variazione ai Movimenti di spesa / fase cassa
IF (@cashvaliditykind <> 4)
BEGIN
	INSERT INTO #expense
		(
		idfin,
		idmov,
		idupb, 
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nsubmov,
		ndoc,
		description,
		doc,
		idreg,
		cassaphase_amount
		)
	SELECT 
		isnull(FL1.idparent, fin.idfin),
		expense.idexp,
		isnull(@fixedidupb,HPV.idupb),
		20,
		expense.nphase,
		expensevar.adate,
		'Var.' + @phasecassa,
		expense.ymov,
		expense.nmov,
		expensevar.nvar,
		HPV.npay,
		expensevar.description,
		CASE
			WHEN expensevar.doc IS NOT NULL AND 
				expensevar.docdate IS NULL THEN
				'Pag. ' + expensevar.doc
			WHEN expensevar.doc IS NOT NULL AND
				expensevar.docdate IS NOT NULL THEN
				'Pag. ' + expensevar.doc + 
				' del ' + CONVERT(varchar(20), expensevar.docdate, 105)
			ELSE
		(NULL)
		END,
		expense.idreg,
		expensevar.amount
		FROM expensevar
		JOIN historypaymentview HPV
			ON HPV.idexp = expensevar.idexp
		JOIN expense
			ON expense.idexp = expensevar.idexp
		left outer JOIN finlink
			ON finlink.idchild = HPV.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = HPV.idfin	
			AND FL1.nlevel = @nlevel
		JOIN fin
		ON fin.idfin = FL1.idparent
		WHERE expensevar.yvar = @ayear
		AND expensevar.adate BETWEEN @start AND @stop
		AND isnull(expensevar.autokind,'') <>'22' 
		AND isnull(@fixedidupb, HPV.idupb) like @idupb 
		AND HPV.ymov = @ayear
		AND fin.ayear = @ayear
		AND ((fin.flag&1)<>0) -- Spesa
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin) 
		AND HPV.competencydate BETWEEN @start AND @stop
		AND HPV.ymov = @ayear

END



-- costruisce la gerarchia del movimento per creare l'ordinamento nel report
UPDATE #expense 
SET 
	hierarchy = convert(varchar(4),E1.ymov) + '/' + Replicate('0',6-len(convert(varchar(6),E1.nmov)))+ 
		    convert(varchar(6),E1.nmov)
FROM expense
JOIN expenselink EL1
	ON EL1.idchild = expense.idexp  AND EL1.nlevel = 1
LEFT OUTER JOIN expenselink EL2
	ON EL2.idchild = expense.idexp  AND EL2.nlevel = 2
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expense.idexp  AND EL3.nlevel = 3
LEFT OUTER JOIN expenselink EL4
	ON EL4.idchild = expense.idexp  AND EL4.nlevel = 4
LEFT OUTER JOIN expenselink EL5
	ON EL5.idchild = expense.idexp  AND EL4.nlevel = 5
LEFT OUTER JOIN expense E1
	ON E1.idexp = EL1.idparent
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
LEFT OUTER JOIN expense E4
	ON E4.idexp = EL4.idparent
LEFT OUTER JOIN expense E5
	ON E5.idexp = EL5.idparent
WHERE  EL1.idchild = #expense.idmov



UPDATE #expense
	SET 	emessiondate = paymentview.adate,
		printeddate = 	paymentview.printdate,
		trasmitteddate = paymentview.transmissiondate,	
		transactiondate = paymentperformed.competencydate,
		annulmentdate = paymentview.annulmentdate
	FROM paymentview
	LEFT OUTER JOIN banktransaction
		ON banktransaction.kpay=paymentview.kpay	
		AND (banktransaction.kind='D' OR banktransaction.kind IS NULL)
	LEFT OUTER JOIN  paymentperformed 
		ON paymentperformed.npay=paymentview.npay
		AND paymentperformed.ypay=paymentview.ypay
	WHERE #expense.ndoc = paymentview.npay and paymentview.ypay=@ayear



IF (@suppressifblank = 'N') 
BEGIN
--se ho scelto di vedere l'upb inserisco le coppie upb/bilancio altrimenti inserisco solo il bilanico non utilizzato
	IF ( (@showupb <>'S') and (@idupboriginal = '%'))
	Begin
		INSERT INTO #expense 
			(
				idfin,
				rowkind
				)
		SELECT 
			fin.idfin,
			1
		FROM fin 
		JOIN finlink
			ON finlink.idchild = fin.idfin	
			AND finlink.nlevel = @level_input
		WHERE  fin.ayear = @ayear
			AND ((fin.flag&1) <>0 ) -- Spesa
			AND fin.nlevel = @nlevel
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			and not exists (SELECT *
				FROM #expense
				WHERE fin.idfin = #expense.idfin )
		End
	Else
		Begin
		INSERT INTO #expense 
			(
				idfin,
				idupb,
				codeupb,
				upb,
				upbprintingorder,
				rowkind
				)
		SELECT 
			fin.idfin,
			upb.idupb,
			codeupb,
			upb.title,
			upb.printingorder,
			1
		FROM fin CROSS JOIN upb 
		left outer JOIN finlink
			ON finlink.idchild = fin.idfin	
			AND finlink.nlevel = @level_input
		WHERE (upb.idupb like @idupb )
			AND fin.ayear = @ayear
			AND ((fin.flag&1)<>0) -- Spesa
			AND fin.nlevel = @nlevel
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			and not exists (SELECT *
				FROM #expense
				WHERE upb.idupb = #expense.idupb 
				AND fin.idfin = #expense.idfin )
		End

END

-- se ho scelto di nascondere le voci di bilancio non utilizzate:
-- cancello le righe che hanno valori pari a zero 
-- per cui non esistono variazioni di previzioni (rowkind=2) o movimenti di entrata (rowkind >= 3 )  
IF (@suppressifblank = 'S') AND @nlevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #expense WHERE 
		ISNULL(initialprevision,0)=0 AND 
		ISNULL(finvar,0)=0 AND 
		ISNULL(cassaphase_amount,0)=0 AND
		NOT EXISTS (select * from  #expense i
				where #expense.idupb = i.idupb AND 
				      #expense.idfin=i.idfin AND 
					i.rowkind>1)
END


IF (@showupb ='S') 
BEGIN
	SELECT #expense.idfin,
		idmov,
		@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		U.codeupb,#expense.idupb,U.title as upb,U.printingorder as upbprintingorder,rowkind,
		nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,
		REG.title as registry,	
		isnull(sum(initialprevision),0) as initialprevision,
		isnull(sum(finvar),0) as finvar,
		--isnull(sum(finphase_amount),0) as finphase_amount,
		isnull(sum(available),0) as available,
		isnull(sum(cassaphase_amount),0) as cassaphase_amount,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@finname as finname,	
		@phasecassa as phasecassa,
		hierarchy
 	FROM #expense	
	JOIN fin F
		ON F.idfin = #expense.idfin
	JOIN upb U
		ON U.idupb = #expense.idupb	
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #expense.idreg	
	GROUP BY U.codeupb,#expense.idupb,U.title,U.printingorder,
		hierarchy,
		F.printingorder,#expense.idfin,idmov,F.codefin,F.title,
		rowkind,nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,ndoc,description,doc,
		annotations,REG.title,emessiondate,printeddate			,
		trasmitteddate,transactiondate,annulmentdate
	ORDER BY U.upbprintingorder ASC, F.printingorder ASC,hierarchy ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
END


IF (@showupb ='N')
BEGIN
		declare 	@codeupb varchar(50)
		declare		@upb varchar(150)
		declare		@upbprintingorder varchar(50)
		declare		@ext_idupb varchar(50)

		if (@idupboriginal='%')
		begin
			set @codeupb= null
			set @upb= null
			set @upbprintingorder= null
			set @ext_idupb= null
		end
		else
		begin
			SET @upbprintingorder =
				(SELECT TOP 1 printingorder
				FROM upb
				WHERE idupb = @idupboriginal)
			SET  @upb =
				(SELECT TOP 1 title
				FROM upb
				WHERE idupb = @idupboriginal)
			SET  @ext_idupb =	@idupboriginal
			SET  @codeupb =
				(SELECT TOP 1 codeupb
				FROM upb	
				WHERE idupb = @idupboriginal)
		end

	SELECT 
		#expense.idfin,
		idmov,
		@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		@codeupb as codeupb,
		@ext_idupb as idupb,
		@upb as upb,
		@upbprintingorder as upbprintingorder,	
		rowkind,
		nphase,
		operationdate,
		operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,
		REG.title as registry,	
		isnull(sum(initialprevision),0) as initialprevision,
		isnull(sum(finvar),0) as finvar	,
		--isnull(sum(finphase_amount),0) as finphase_amount,
		isnull(sum(available),0) as available,
		isnull(sum(cassaphase_amount),0) as cassaphase_amount,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@finname as finname,	
		@phasecassa as phasecassa,
		hierarchy
	FROM #expense
	JOIN fin F
		ON F.idfin = #expense.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #expense.idreg  
	GROUP BY hierarchy,
		F.printingorder,#expense.idfin,idmov,F.codefin,F.title,
		rowkind,nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,ndoc,description,doc,
		annotations,REG.title,emessiondate,printeddate			,
		trasmitteddate,transactiondate,annulmentdate
	ORDER BY upbprintingorder ASC, finprintingorder ASC,hierarchy ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

