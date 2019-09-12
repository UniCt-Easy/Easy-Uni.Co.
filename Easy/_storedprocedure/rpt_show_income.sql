if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_show_income]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_show_income]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--setuser'amministrazione'


CREATE  PROCEDURE [rpt_show_income]
(
	@nphase int,
	@ymov int,
	@nmov int,
	@ayear int,
	@date datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN

DECLARE @idinc int
DECLARE @ymovoriginal int
DECLARE @nmovoriginal int
DECLARE @amount decimal(19,2)
DECLARE @codeupb varchar(50)
DECLARE @upb  varchar(150)
DECLARE @codefin varchar(50)
DECLARE @fin varchar(150)
DECLARE @finphase varchar(50)
DECLARE @description varchar(150)

SELECT  @idinc = idinc
FROM 	income I
WHERE 	I.nphase = @nphase
AND	I.ymov   = @ymov
AND	I.nmov   = @nmov

print @idinc
CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))
IF @idinc IS NULL 
BEGIN
	SELECT value, amount, kind FROM  #situation
	RETURN
END

SELECT  @ymovoriginal = I.ymov, 
	@nmovoriginal = I.nmov, 
	@amount = IY_starting.amount, 
	@idinc  = I.idinc,
	@nphase = I.nphase,
	@codeupb = upb.codeupb,
	@upb 	 = upb.title,
	@codefin = fin.codefin,
	@fin 	 = fin.title,
	@finphase = finlevel.description,
	@description = I.description
FROM income I
JOIN incometotal IT_firstyear
  	ON IT_firstyear.idinc = I.idinc AND ((IT_firstyear.flag & 2) <> 0 )
JOIN incomeyear IY_starting
	ON IY_starting.idinc = IT_firstyear.idinc
  	AND IY_starting.ayear = IT_firstyear.ayear
JOIN upb 
	ON upb.idupb = IY_starting.idupb
JOIN fin
	ON fin.idfin = IY_starting.idfin
JOIN finlevel 
	ON fin.nlevel = finlevel.nlevel
	AND finlevel.ayear = IY_starting.ayear
WHERE I.idinc = @idinc
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

DECLARE @phase varchar(50)
SELECT @phase = description FROM incomephase WHERE nphase = @nphase

DECLARE	@departmentname varchar(150)
SET  @departmentname  = ISNULL( (SELECT TOP 1 paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				ORDER BY  ISNULL(stop, {d '2079-06-06'})
				),'Manca Cfg. Parametri Tutte le stampe')



INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
INSERT INTO #situation VALUES (@phase +' n° ' + CONVERT(char(10), @nmovoriginal) + ' del ' +
	CONVERT(char(6), @ymovoriginal), NULL, 'H')
INSERT INTO #situation VALUES ('Esercizio finanziario ' + CONVERT(char(4), @ayear), NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')

INSERT INTO #situation VALUES ('Descrizione: '+ @description, NULL, 'N')
INSERT INTO #situation VALUES ('UPB: ' +  @codeupb + space(1) + '(' + @upb + ')', NULL, 'N')
INSERT INTO #situation VALUES ('Bilancio: ' + @finphase + space(1) + @codefin + space(1) + '(' + @fin + ')', NULL, 'N')
INSERT INTO #situation VALUES ('', NULL, 'N')

INSERT INTO #situation VALUES ('1. Importo originale', @amount, '')


DECLARE @tot_var_prev_ayear decimal(19,2)
SELECT @tot_var_prev_ayear = SUM(amount) 
FROM incomevar
WHERE idinc = @idinc 
	AND yvar < @ayear
	AND adate <= @date

INSERT INTO #situation VALUES ('2. Variazioni esercizi precedenti', @tot_var_prev_ayear, '')

DECLARE @tot_var_curr_ayear decimal(19,2)
SELECT @tot_var_curr_ayear = SUM(amount) 
	FROM incomevar
	WHERE idinc = @idinc 
	AND yvar = @ayear
	AND adate <= @date

INSERT INTO #situation VALUES ('3. Variazioni esercizio corrente', @tot_var_curr_ayear, '')

DECLARE @tot_amount decimal(19,2)
SELECT @tot_amount = 
	ISNULL(@amount, 0) + 
	ISNULL(@tot_var_prev_ayear, 0) + 
	ISNULL(@tot_var_curr_ayear, 0)

INSERT INTO #situation VALUES ('4. Importo comprensivo delle variazioni (1 + 2 + 3)', @tot_amount, 'S')

DECLARE @maxphase tinyint
SELECT @maxphase = MAX(nphase) FROM incomephase

INSERT INTO #situation VALUES ('', NULL, 'N')
WHILE @nphase < @maxphase
BEGIN
	SELECT @nphase = @nphase + 1
	SELECT @phase = description
	FROM incomephase
	WHERE nphase = @nphase

	DECLARE @tot_mov_prev_ayear decimal(19,2)
	SELECT @tot_mov_prev_ayear = SUM(IY_starting.amount)--SUM(E.amount) 
	FROM income I
	JOIN incomelink ILK
		ON I.idinc = ILK.idchild  
	JOIN incometotal IT_firstyear
	  	ON IT_firstyear.idinc = I.idinc AND ((IT_firstyear.flag & 2) <> 0 )
	JOIN incomeyear IY_starting
		ON IY_starting.idinc = IT_firstyear.idinc
	  	AND IY_starting.ayear = IT_firstyear.ayear
	WHERE I.nphase = @nphase 
		AND ILK.idparent = @idinc 
		AND I.ymov < @ayear
		AND I.adate <= @date

	INSERT INTO #situation VALUES ('5. Totale movimenti (' + @phase +
		') eserc. precedenti', @tot_mov_prev_ayear, '')

	DECLARE @tot_mov_curr_ayear decimal(19,2)
	SELECT @tot_mov_curr_ayear = SUM(IY_starting.amount)--SUM(amount) 
	FROM income I
	JOIN incomelink ILK
		ON I.idinc = ILK.idchild 
	JOIN incometotal IT_firstyear
	  	ON IT_firstyear.idinc = I.idinc AND ((IT_firstyear.flag & 2) <> 0 )
	JOIN incomeyear IY_starting
		ON IY_starting.idinc = IT_firstyear.idinc
	  	AND IY_starting.ayear =IT_firstyear.ayear
	WHERE I.nphase = @nphase  
		AND ILK.idparent = @idinc 
		AND I.ymov = @ayear
		AND I.adate <= @date

	INSERT INTO #situation VALUES ('6. Totale movimenti (' + @phase +
		') eserc. corrente', @tot_mov_curr_ayear, '')

	SELECT @tot_var_prev_ayear = SUM(incomevar.amount) 
	FROM incomevar
	JOIN income
		ON income.idinc = incomevar.idinc
	JOIN incomelink 
		ON income.idinc = incomelink.idchild  
	WHERE incomelink.idparent = @idinc 
		AND incomevar.yvar < @ayear
		AND income.nphase = @nphase
		AND incomevar.adate <= @date

	INSERT INTO #situation VALUES ('7. Totale variazioni (' + @phase +
		') eserc. precedenti', @tot_var_prev_ayear, '')

	SELECT @tot_var_curr_ayear = SUM(incomevar.amount) 
	FROM incomevar
	JOIN income
		ON income.idinc = incomevar.idinc
	JOIN incomelink 
		ON income.idinc = incomelink.idchild  
	WHERE incomelink.idparent = @idinc  
		AND incomevar.yvar = @ayear
		AND incomevar.adate <= @date
		AND income.nphase = @nphase

	INSERT INTO #situation VALUES ('8. Totale variazioni (' + @phase +
		') eserc. corrente', @tot_var_curr_ayear, '')
	DECLARE @available decimal(19,2)
	SET @available = 
		ISNULL(@tot_amount, 0) - 
		ISNULL(@tot_mov_curr_ayear, 0) - 
		ISNULL(@tot_mov_prev_ayear, 0) -
		ISNULL(@tot_var_prev_ayear, 0) - 
	 	ISNULL(@tot_var_curr_ayear, 0)
	INSERT INTO #situation VALUES ('9. Importo disponibile (4 - 5 - 6 - 7 - 8)', @available, 'S')
END

SELECT value, amount, kind FROM #situation
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 