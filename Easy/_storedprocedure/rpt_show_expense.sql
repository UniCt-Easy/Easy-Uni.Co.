if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_show_expense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_show_expense]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amm'
--setuser'amministrazione'

-- select * from expense where ymov=2016
-- rpt_show_expense 1,2016,1,2016, '31-12-2016'
-- rpt_show_expense 31313,2016,1,2016, '31-12-2016'

CREATE           PROCEDURE rpt_show_expense
(
	--@idexp int,
	@nphase int,
	@ymov int,
	@nmov int,
	@ayear int,
	@date datetime ,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN
---exec rpt_show_expense 2,2014,3996,2014,{ts '2014-12-31 01:02:03'}
DECLARE @ymovoriginal int
DECLARE @nmovoriginal int
DECLARE @idexp int
DECLARE @amount decimal(19,2)
--DECLARE @nphase tinyint
DECLARE @codeupb varchar(50)
DECLARE @upb  varchar(150)
DECLARE @codefin varchar(50)
DECLARE @fin varchar(150)
DECLARE @finphase varchar(50)
DECLARE @description varchar(150)
DECLARE @idreg int
DECLARE @adate smalldatetime
declare @lu varchar(64)
DECLARE @idfin int

SELECT  @idexp = idexp
FROM 	expense E
WHERE 	E.nphase = @nphase
AND	E.ymov   = @ymov
AND	E.nmov   = @nmov

--print @idexp
CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1), rowtype varchar(50))
IF @idexp IS NULL 
BEGIN
	
	SELECT value, amount, kind,'.' as rowtype FROM #situation
	RETURN
END

SELECT  @ymovoriginal 	 = E.ymov, 
	@nmovoriginal 	 = E.nmov, 
	@amount  = EY_starting.amount, 
	@idexp   = E.idexp,
	@codeupb = upb.codeupb,
	@upb 	 = upb.title,
	@codefin = fin.codefin,
	@fin 	 = fin.title,
	@idfin	 = EY.idfin,
	@finphase = finlevel.description,
	@description = E.description,
	@lu = E.lu,
	@adate = adate
FROM expense E
join expenseyear EY
	ON E.idexp = EY.idexp
JOIN upb 
	ON upb.idupb = EY.idupb
JOIN fin
	ON fin.idfin = EY.idfin
JOIN finlevel 
	ON fin.nlevel = finlevel.nlevel
	AND finlevel.ayear = EY.ayear
LEFT OUTER JOIN expensetotal ET_firstyear
  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear EY_starting
	ON EY_starting.idexp = ET_firstyear.idexp
  	AND EY_starting.ayear = ET_firstyear.ayear
WHERE E.idexp = @idexp
	and EY.ayear = @ayear
	/*
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	*/

IF (@codeupb IS NULL)
BEGIN
	
	SELECT value, amount, kind,'.' as rowtype FROM #situation
	RETURN
END
declare @idsor int
declare @idsorkind int
declare @idacc varchar(38)
declare @codeacc varchar(50)
declare @account varchar(150)
-- Se la voce di bilancio è associata al un solo codice di classificazione associata al Piano dei Conti
if (select count(finsorting.idsor) from finsorting 
	join sorting
		on finsorting.idsor = sorting.idsor
	join sortingkind
		on sortingkind.idsorkind = sorting.idsorkind
	where finsorting.idfin = @idfin and (sortingkind.flag&4)<>0) = 1
Begin
	-- nella stampa mostriamo la voce del piano dei conti classificata con quella voce di classifiazione
	select @idsor = finsorting.idsor from finsorting 
	join sorting
		on finsorting.idsor = sorting.idsor
	join sortingkind
		on sortingkind.idsorkind = sorting.idsorkind
	where finsorting.idfin = @idfin and (sortingkind.flag&4)<>0
	
	select @idacc = idacc from accountsorting where idsor = @idsor
	select @codeacc = codeacc,@account = title from account where idacc = @idacc
End

DECLARE @nfinphase tinyint
SELECT @nfinphase = appropriationphasecode
FROM config
WHERE ayear = @ayear
IF @nfinphase IS NULL
BEGIN
	SELECT @nfinphase = expensefinphase FROM uniconfig
END
declare @appunti varchar(800)
select @appunti = txt from expense where idexp = @idexp

declare @cupcode varchar(15)
declare @cigcode varchar(10)
select @idreg = idreg,
		@cupcode = cupcode, 
		@cigcode = cigcode
FROM expense E
JOIN expenselink ELK
	ON E.idexp = ELK.idparent
WHERE E.nphase = (select expenseregphase from uniconfig)
	AND ELK.idchild = @idexp 

declare @registry varchar(100)
select @registry = title from registry where idreg = @idreg

declare @ymovprec int
declare @nmovprec int
declare @nphaseprec tinyint
select @ymovprec = PAR.ymov,
	   @nmovprec = PAR.nmov,
	   @nphaseprec = PAR.nphase
from expense PAR
join expense E
	on E.parentidexp = PAR.idexp
where E.idexp = @idexp
declare @phaseprec varchar(50)
select @phaseprec = description from expensephase where nphase = @nphaseprec



DECLARE @phase varchar(50)
SELECT  @phase = description FROM expensephase WHERE nphase = @nphase

DECLARE	@departmentname varchar(150)
SET  @departmentname  = ISNULL( (SELECT TOP 1 paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				ORDER BY  ISNULL(stop, {d '2079-06-06'})
				),'Manca Cfg. Parametri Tutte le stampe')

declare @MostraAnagrafica varchar(50)
declare @MostraAppunti varchar(50)
declare @MostraUltimoOperatore varchar(50)
declare @MostraContoEP varchar(50)
select @MostraAnagrafica = paramvalue from reportadditionalparam where paramname = 'MostraAnagrafica' and reportname='show_expense'
select @MostraAppunti = paramvalue from reportadditionalparam where paramname = 'MostraAppunti' and reportname='show_expense'
select @MostraUltimoOperatore = paramvalue from reportadditionalparam where paramname = 'MostraUltimoOperatore' and reportname='show_expense'
select @MostraContoEP = paramvalue from reportadditionalparam where paramname = 'MostraContoEP' and reportname='show_expense'

--INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H',null)
INSERT INTO #situation VALUES (@phase + ' n° '  + CONVERT(char(10), @nmovoriginal) +  ' del ' + CONVERT(char(4), @ymovoriginal) +' Data contabile ' + CONVERT(char(8),@adate,3)
	, NULL, 'H',null)
--INSERT INTO #situation VALUES ('Data contabile ' + CONVERT(char(8),@adate,3) , NULL, 'N')
INSERT INTO #situation VALUES ('Esercizio finanziario ' + CONVERT(char(4), @ayear), NULL, 'H',null)

INSERT INTO #situation VALUES ('Fase precedente ' + ltrim(rtrim(CONVERT(char(50), @phaseprec)))+ ' n.'+ltrim(rtrim(CONVERT(char(10), @nmovprec)))+ '/'+CONVERT(char(4), @ymovprec), NULL, 'H','faseprecedente')


INSERT INTO #situation VALUES ('', NULL, 'N',null)

if(@MostraAnagrafica = 'S')
begin
	INSERT INTO #situation VALUES ('Anagrafica: ' + @registry , NULL, 'N',null)
end

INSERT INTO #situation VALUES ('Descrizione: '+ @description, NULL, 'N',null)
INSERT INTO #situation VALUES ('UPB: ' +  @codeupb + space(1) + '(' + @upb + ')', NULL, 'N',null)
INSERT INTO #situation VALUES ('Bilancio: ' + @finphase + space(1) + @codefin + space(1) + '(' + @fin + ')', NULL, 'N',null)
if( @cigcode is not null)
Begin
	INSERT INTO #situation VALUES ('CIG: ' + convert(varchar(10),@cigcode), NULL, 'N',null)
end

if(@cupcode is not null)
Begin
	INSERT INTO #situation VALUES ('CUP: ' + convert(varchar(10),@cupcode), NULL, 'N',null)
end

	
--INSERT INTO #situation VALUES ('CUP: ' + @cupcode , NULL, 'N')
if(@MostraContoEP='S')
begin
	INSERT INTO #situation VALUES ('Conto E/P: ' + @codeacc + '-' + @account, NULL, 'N',null)
end

INSERT INTO #situation VALUES ('', NULL, 'N',null)

INSERT INTO #situation VALUES ('1. Importo originale', @amount, '',null)

DECLARE @tot_var_prev_ayear decimal(19,2)
SELECT @tot_var_prev_ayear = SUM(amount) 
FROM expensevar
WHERE idexp = @idexp 
AND yvar < @ayear
	AND adate <= @date

INSERT INTO #situation VALUES ('2. Variazioni Esercizi Prec.', @tot_var_prev_ayear, '',null)
DECLARE @tot_var_curr_ayear decimal(19,2)
SELECT @tot_var_curr_ayear = SUM(amount)
FROM expensevar
WHERE idexp = @idexp 
	AND yvar = @ayear
	AND adate <= @date

INSERT INTO #situation VALUES ('3. Variazioni Esercizio Corr.', @tot_var_curr_ayear, '',null)
DECLARE @tot_amount decimal(19,2)
SELECT @tot_amount = ISNULL(@amount, 0) + ISNULL(@tot_var_prev_ayear, 0) + ISNULL(@tot_var_curr_ayear, 0)
INSERT INTO #situation VALUES ('4. Importo comprensivo delle variazioni (1 + 2 + 3)', @tot_amount, 'S',null)

DECLARE @maxphase int
SELECT @maxphase = MAX(nphase) FROM expensephase

DECLARE @tot_pettycashop decimal(19,2)
SET @tot_pettycashop = 
ISNULL(
	(SELECT SUM(exp_op.amount)
	FROM pettycashoperation exp_op
	WHERE yoperation = @ayear
	AND idexp = @idexp
	AND (flag&8)<>0
	AND adate <= @date
	AND NOT EXISTS(
		SELECT * FROM pettycashoperation restore_op
		WHERE restore_op.yrestore = exp_op.yrestore
		AND restore_op.nrestore = exp_op.nrestore
		AND restore_op.idpettycash = exp_op.idpettycash
		AND restore_op.adate <= @date)
	)
,0)
DECLARE @availableText varchar(150)
SET @availableText = '10. Importo Disponibile (4 - '
IF (@tot_pettycashop <> 0)
BEGIN
	INSERT INTO #situation VALUES('5. Totale Op. Fondo Economale non reintegrate', @tot_pettycashop, '',null)
	SET @availableText = @availableText + '5 - '
END
SET @availableText = @availableText + '6 - 7 - 8 - 9)'
INSERT INTO #situation VALUES ('', NULL, 'N',null)
WHILE @nphase < @maxphase
BEGIN
	SELECT @nphase = @nphase + 1
	
	SELECT @phase = description 
	FROM expensephase
	WHERE nphase = @nphase
	
	DECLARE @tot_mov_prev_ayear decimal(19,2)
	SELECT @tot_mov_prev_ayear =  SUM(EY_starting.amount)--SUM(E.amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  
	JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.nphase = @nphase 
		AND ELK.idparent = @idexp 
		-- AND ELK.nlevel = @nphase
		AND E.ymov < @ayear
		AND E.adate <= @date

	INSERT INTO #situation VALUES ('6. Totale movimenti (' + @phase + ') eserc. precedenti', @tot_mov_prev_ayear, '',null)

	DECLARE @tot_mov_curr_ayear decimal(19,2)
	SELECT @tot_mov_curr_ayear = SUM(EY_starting.amount)--SUM(amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild 
	JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.nphase = @nphase --AND ELK.nlevel = @nphase 
		AND ELK.idparent = @idexp 
		AND E.ymov = @ayear
		AND E.adate <= @date
	
	INSERT INTO #situation VALUES ('7. Totale movimenti (' + @phase + ') eserc. corrente', @tot_mov_curr_ayear, '',null)
	
	SELECT @tot_var_prev_ayear = SUM(expensevar.amount) 
	FROM expensevar 
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN expenselink 
		ON expense.idexp = expenselink.idchild  
	WHERE expenselink.idparent = @idexp  
		--AND expenselink.nlevel = @nphase 
		AND expense.nphase = @nphase
		AND expensevar.yvar < @ayear
		AND expensevar.adate <= @date
	
	INSERT INTO #situation VALUES ('8. Totale variazioni (' + @phase + ') eserc. precedenti', @tot_var_prev_ayear, '',null)

	SELECT @tot_var_curr_ayear = SUM(expensevar.amount)
	FROM expensevar
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN expenselink 
		ON expense.idexp = expenselink.idchild  
	WHERE expenselink.idparent = @idexp  
		--AND expenselink.nlevel = @nphase 
		AND expense.nphase = @nphase
		AND expensevar.yvar = @ayear
		AND expensevar.adate <= @date

	INSERT INTO #situation VALUES ('9. Totale variazioni (' + @phase + ') eserc. corrente', @tot_var_curr_ayear, '',null)
	DECLARE @available decimal(19,2)
	SET @available = 
		ISNULL(@tot_amount, 0) - 
		ISNULL(@tot_mov_curr_ayear, 0) - 
		ISNULL(@tot_mov_prev_ayear, 0) -
		ISNULL(@tot_var_prev_ayear, 0) - 
		ISNULL(@tot_var_curr_ayear, 0) -
		ISNULL(@tot_pettycashop, 0)
	INSERT INTO #situation VALUES (@availableText, @available, 'S',null)
	--INSERT INTO #situation VALUES ('', NULL, 'N')
END 

if(@MostraAppunti='S')
begin
	INSERT INTO #situation VALUES ('Annotazioni: ' + @appunti , NULL, 'N','annotazioni')
end

if(@MostraUltimoOperatore='S')
begin
	INSERT INTO #situation VALUES ('VISTO OPERATORE: ' + @lu , NULL, 'N','operatore')
end
SELECT value, amount, kind,isnull(rowtype,'.') as rowtype FROM #situation
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

