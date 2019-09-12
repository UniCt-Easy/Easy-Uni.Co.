if exists (select * from dbo.sysobjects where id = object_id(N'[exp_consuntivo_es]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_consuntivo_es]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--  setuser 'amm'
--	exec exp_consuntivo_es '2015', {ts '2015-10-05 00:00:00.000'}, '0001', 'S', null, null, null, null, null
--	exec exp_consuntivo_es '2014', {ts '2014-12-31 00:00:00.000'}, null, 'S', null, null, null, null, null
CREATE    PROCEDURE [exp_consuntivo_es]
(
	@ayear smallint,
	@date datetime,
	@idupb varchar(36) = null,
	@showchildupb char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS
BEGIN
 
set @idupb = isnull(@idupb,'%')
-- SE vogliamo vedere anche i figli, @idupb diventa '0001%'
-- altrimenti resta '0001' o '%', se non c'è stata alcuna selezione
if (@showchildupb = 'S') 
begin
	set @idupb = @idupb+'%'
end 

DECLARE @levelusable tinyint -- Livello operativo per le voci di bilancio
SELECT @levelusable = MIN(nlevel) FROM finlevel WHERE (flag & 2)<>0 AND ayear = @ayear

 
DECLARE @finphaseexpense tinyint
SELECT @finphaseexpense = appropriationphasecode FROM config WHERE ayear = @ayear
IF @finphaseexpense IS NULL
BEGIN
	SELECT @finphaseexpense = expensefinphase FROM uniconfig
END

DECLARE @expense_regphase tinyint
SELECT @expense_regphase = expenseregphase FROM uniconfig

DECLARE @finphaseincome tinyint
SELECT @finphaseincome = assessmentphasecode FROM config WHERE ayear = @ayear
IF @finphaseincome IS NULL
BEGIN
	SELECT @finphaseincome = incomefinphase FROM uniconfig
END

DECLARE @income_regphase tinyint
SELECT @income_regphase = incomeregphase FROM uniconfig


DECLARE @fin_kind tinyint
SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear

CREATE TABLE #PREVISIONE_PRINCIPALE_INIZIALE(
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  
	
INSERT INTO #PREVISIONE_PRINCIPALE_INIZIALE( idupb,amount)  
SELECT U.idupb, SUM(isnull(U.prevision,0))
	FROM finyear U --> Lasciamo il totalizzatore, perchè totalizza i figli. Altrimenti dobbiamo distinguere tra capitoli e articoli
	JOIN upb 
		on upb.idupb = U.idupb	
	JOIN fin
		on U.idfin = fin.idfin	
WHERE (U.idupb like @idupb)
	AND ( fin.nlevel = @levelusable )
	AND fin.ayear = @ayear
	AND ( (fin.flag & 1)<>0 )--Parte spesa
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY U.idupb


CREATE TABLE #VAR_PREVISIONE_PRINCIPALE(
	idupb varchar(36),	
	amount decimal(19,2)
	)

INSERT INTO #VAR_PREVISIONE_PRINCIPALE( idupb, amount)  
SELECT D.idupb, sum(D.amount)
	FROM finvar V
	JOIN finvardetail D 	
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar	
	JOIN upb 
		on upb.idupb = D.idupb	
	JOIN fin
		on D.idfin = fin.idfin	
WHERE (D.idupb like @idupb)
	AND V.yvar = @ayear
	AND V.adate <= @date
	AND V.flagprevision = 'S'
	AND ((fin.flag & 1)<>0)--Parte spesa
	AND V.idfinvarstatus = 5 
	AND V.variationkind <> 5
	--AND ISNULL(V.official,'N') = 'S'
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY D.idupb

	
CREATE TABLE #PREVISIONE_PRINCIPALE_INIZIALE_ENTRATA(
	idupb varchar(36),	
	amount decimal(19,2)
	)  
	
INSERT INTO #PREVISIONE_PRINCIPALE_INIZIALE_ENTRATA( idupb, amount)  
SELECT U.idupb,sum(isnull(U.prevision,0))
	FROM finyear U --> Lasciamo il totalizzatore, perchè totalizza i figli. Altrimenti dobbiamo distinguere tra capitoli e articoli
	JOIN upb 
		on upb.idupb = U.idupb	
	JOIN fin
		on U.idfin = fin.idfin	
WHERE (U.idupb like @idupb)
	AND (fin.nlevel = @levelusable)
	AND  fin.ayear = @ayear
	AND ( (fin.flag &1)= 0 )--Parte entrata
	AND ( (fin.flag&16)= 0 )  --AVANZO
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY U.idupb


CREATE TABLE #VAR_PREVISIONE_PRINCIPALE_ENTRATA(
	idupb varchar(36),	
	amount decimal(19,2)
	)

INSERT INTO #VAR_PREVISIONE_PRINCIPALE_ENTRATA( idupb, amount)  
SELECT D.idupb, sum(D.amount)
	FROM finvar V
	JOIN finvardetail D 	
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar	
	JOIN upb 
		on upb.idupb = D.idupb	
	JOIN fin
		on D.idfin = fin.idfin	
WHERE (D.idupb like @idupb)
	AND V.yvar = @ayear
	AND V.adate <= @date
	AND V.flagprevision = 'S'
	AND ( (fin.flag & 1) = 0 )--Parte entrata
	AND ( (fin.flag&16)= 0 )  --AVANZO
	AND V.idfinvarstatus = 5 
	AND V.variationkind <> 5
	--AND ISNULL(V.official,'N') = 'S'
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY D.idupb

--CREATE TABLE #PICCOLE_SPESE(
--	idupb varchar(36),	
--	idfin int, 
--	amount decimal(19,2)
--	)  

--INSERT INTO #PICCOLE_SPESE( idupb, amount)  
--SELECT  operation.idupb, SUM(operation.amount)
--	FROM  pettycashoperation operation
--	JOIN upb 
--		on upb.idupb = operation.idupb	
--WHERE (operation.idupb like @idupb)
--		AND operation.yoperation = @ayear
--		AND operation.adate	<= @date
--		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
--		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
--		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
--		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
--		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
--		AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
--							WHERE restoreop.yrestore = operation.yrestore
--								AND restoreop.nrestore = operation.nrestore
--								AND restoreop.idpettycash = operation.idpettycash)
--GROUP BY  operation.idupb
--	PRINT '#PICCOLE_SPESE'
CREATE TABLE #IMPEGNI_COMP(
	idupb varchar(36),	
	amount decimal(19,2)
	)  

INSERT INTO #IMPEGNI_COMP( idupb, amount) 
SELECT  idupb,   SUM(amount) 
FROM
	(
		SELECT  EY.idupb,  ISNULL(EY.amount,0) AS amount
		FROM expense E
		JOIN expenseyear EY
			ON EY.idexp = E.idexp
		JOIN expensetotal ET
			ON ET.idexp = EY.idexp
			AND ET.ayear = EY.ayear
		JOIN upb 
			on upb.idupb = EY.idupb	
	WHERE (EY.idupb like @idupb)
			AND E.adate <= @date
			AND EY.ayear = @ayear
			AND E.nphase = @finphaseexpense	
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	UNION ALL
		SELECT  EY.idupb,ISNULL(EV.amount,0) as amount
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN expense E
			ON EY.idexp = E.idexp
		JOIN expensetotal ET
			ON ET.idexp = EY.idexp
			AND ET.ayear = EY.ayear
		JOIN upb 
			on upb.idupb = EY.idupb	
	WHERE (EY.idupb like @idupb)
			AND EY.ayear = @ayear
			AND EV.adate <= @date
			AND EV.yvar = @ayear
			AND E.nphase = @finphaseexpense	
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	) AS Impegni
GROUP BY idupb 

	

CREATE TABLE #IMPEGNI_COMP_CREDITORE(
	idupb varchar(36),	
	amount decimal(19,2)
	)  

INSERT INTO #IMPEGNI_COMP_CREDITORE( idupb, amount) 
SELECT  idupb,   SUM(amount) 
FROM
	(
SELECT  EY.idupb,  ISNULL(EY.amount,0) AS amount
		FROM expense E
		JOIN expenseyear EY
			ON EY.idexp = E.idexp
		JOIN expensetotal ET
			ON ET.idexp = EY.idexp
			AND ET.ayear = EY.ayear
		JOIN upb 
			on upb.idupb = EY.idupb	
 
	WHERE (EY.idupb like @idupb)
			AND E.adate <= @date
			AND EY.ayear = @ayear
			AND E.nphase = @expense_regphase	
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	UNION ALL
		SELECT  EY.idupb,ISNULL(EV.amount,0) as amount
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN expense E
			ON EY.idexp = E.idexp
		JOIN expensetotal ET
			ON ET.idexp = EY.idexp
			AND ET.ayear = EY.ayear
		JOIN upb 
			on upb.idupb = EY.idupb	
	WHERE (EY.idupb like @idupb)
			AND EY.ayear = @ayear
			AND EV.adate <= @date
			AND EV.yvar = @ayear
			AND E.nphase = @expense_regphase	
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	) AS Impegni
GROUP BY idupb 


CREATE TABLE #ACCERTAMENTI_COMP(
	idupb varchar(36),	
	amount decimal(19,2)
	)  

INSERT INTO #ACCERTAMENTI_COMP( idupb, amount) 
SELECT idupb,SUM(amount) 
FROM
	(SELECT EY.idupb, ISNULL(EY.amount,0) AS amount
		FROM income E
		JOIN incomeyear EY
			ON EY.idinc = E.idinc
		JOIN incometotal ET
			ON ET.idinc = EY.idinc
			AND ET.ayear = EY.ayear
		JOIN upb 
			on upb.idupb = EY.idupb	
	WHERE (EY.idupb like @idupb)
			AND E.adate <= @date
			AND EY.ayear = @ayear
			AND E.nphase = @finphaseincome
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	UNION ALL
		SELECT EY.idupb,ISNULL(EV.amount,0) as amount
		FROM incomevar EV
		JOIN incomeyear EY
			ON EY.idinc = EV.idinc
		JOIN income E
			ON EY.idinc = E.idinc
		JOIN incometotal ET
			ON ET.idinc = EY.idinc
			AND ET.ayear = EY.ayear
		JOIN upb 
			on upb.idupb = EY.idupb	
	WHERE (EY.idupb like @idupb)
			AND EV.adate <= @date
			AND EV.yvar = @ayear
			AND EY.ayear = @ayear
			AND E.nphase = @finphaseincome
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	) AS Accertamenti
GROUP BY idupb



CREATE TABLE #ACCERTAMENTI_COMP_CREDITORE(
	idupb varchar(36),	
	amount decimal(19,2)
	)  

INSERT INTO #ACCERTAMENTI_COMP_CREDITORE( idupb, amount) 
SELECT idupb,SUM(amount) 
FROM
	(SELECT EY.idupb, ISNULL(EY.amount,0) AS amount
		FROM income E
		JOIN incomeyear EY
			ON EY.idinc = E.idinc
		JOIN incometotal ET
			ON ET.idinc = EY.idinc
			AND ET.ayear = EY.ayear
		JOIN upb 
			on upb.idupb = EY.idupb	
	WHERE (EY.idupb like @idupb)
			AND E.adate <= @date
			AND EY.ayear = @ayear
			AND E.nphase = @income_regphase
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	UNION ALL
		SELECT EY.idupb,ISNULL(EV.amount,0) as amount
		FROM incomevar EV
		JOIN incomeyear EY
			ON EY.idinc = EV.idinc
		JOIN income E
			ON EY.idinc = E.idinc
		JOIN incometotal ET
			ON ET.idinc = EY.idinc
			AND ET.ayear = EY.ayear
		JOIN upb 
			on upb.idupb = EY.idupb	
	WHERE (EY.idupb like @idupb)
			AND EV.adate <= @date
			AND EV.yvar = @ayear
			AND EY.ayear = @ayear
			AND E.nphase = @income_regphase
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	) AS Accertamenti
GROUP BY idupb


CREATE TABLE #IMPEGNI_RESIDUI(
	idupb varchar(36),	
	amount decimal(19,2)
	)  

INSERT INTO #IMPEGNI_RESIDUI(idupb, amount)
	SELECT
		EY.idupb, 
		SUM(EY.amount)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	WHERE  E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @finphaseexpense
		AND (EY.idupb  like @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
	GROUP BY EY.idupb


CREATE TABLE #VAR_IMPEGNI_RESIDUI(
	idupb varchar(36),	
	amount decimal(19,2)
	)  

INSERT INTO #VAR_IMPEGNI_RESIDUI(idupb, amount)
	SELECT
		EY.idupb,
		SUM(EV.amount)
	FROM expensevar EV
	JOIN expense E
		ON EV.idexp = E.idexp
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND EV.adate <= @date 
		AND ( (ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @finphaseexpense
		AND (EY.idupb LIKE @idupb)		
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY EY.idupb



CREATE TABLE #IMPEGNI_RESIDUI_CREDITORE(
	idupb varchar(36),	
	amount decimal(19,2)
	)  		
-- Sono i movimenti residui con l'anagrafica valorizzata.
INSERT INTO #IMPEGNI_RESIDUI_CREDITORE(idupb, amount)
	SELECT
		EY.idupb, 
		SUM(EY.amount)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	WHERE  E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @expense_regphase -- > Residui calcolati sulla fase dell'Anagrafica 
		AND (EY.idupb  like @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
	GROUP BY EY.idupb

CREATE TABLE #VAR_IMPEGNI_RESIDUI_CREDITORE(
	idupb varchar(36),	
	amount decimal(19,2)
	)  

INSERT INTO #VAR_IMPEGNI_RESIDUI_CREDITORE(idupb, amount)
	SELECT
		EY.idupb,
		SUM(EV.amount)
	FROM expensevar EV
	JOIN expense E
		ON EV.idexp = E.idexp
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND EV.adate <= @date 
		AND ( (ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @expense_regphase -- > Var. Residui calcolati sulla fase dell'Anagrafica 
		AND (EY.idupb LIKE @idupb)		
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY EY.idupb

-------------------------------------------------------------------
-------------------------------------------------------------------
-------------------------------------------------------------------
CREATE TABLE #ACCERTAMENTI_RESIDUI(
	idupb varchar(36),	
	amount decimal(19,2)
	)  

INSERT INTO #ACCERTAMENTI_RESIDUI(idupb, amount)
	SELECT
		EY.idupb,
		SUM(EY.amount)
	FROM income E
	JOIN incomeyear EY
		ON EY.idinc = E.idinc
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN incometotal ET
		ON ET.idinc = EY.idinc
		AND ET.ayear = EY.ayear
	WHERE  E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @finphaseincome
		AND (EY.idupb  like @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
	GROUP BY EY.idupb

		
CREATE TABLE #VAR_ACCERTAMENTI_RESIDUI(
	idupb varchar(36),	
	amount decimal(19,2)
	)  

INSERT INTO #VAR_ACCERTAMENTI_RESIDUI(idupb, amount)
	SELECT
		EY.idupb,
		SUM(EV.amount)
	FROM incomevar EV
	JOIN income E
		ON EV.idinc = E.idinc
	JOIN incomeyear EY
		ON EY.idinc = EV.idinc
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN incometotal ET
		ON ET.idinc = EY.idinc
		AND ET.ayear = EY.ayear
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND EV.adate <= @date 
		AND ((ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @finphaseincome
		AND (EY.idupb LIKE @idupb)		
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY EY.idupb



--------------------------------------------------------------------------------
CREATE TABLE #ACCERTAMENTI_RESIDUI_CREDITORE(
	idupb varchar(36),	
	amount decimal(19,2)
	)  
-- Sono i movimenti residui con l'anagrafica valorizzata.
INSERT INTO #ACCERTAMENTI_RESIDUI_CREDITORE(idupb, amount)
	SELECT
		EY.idupb,
		SUM(EY.amount)
	FROM income E
	JOIN incomeyear EY
		ON EY.idinc = E.idinc
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN incometotal ET
		ON ET.idinc = EY.idinc
		AND ET.ayear = EY.ayear
	WHERE  E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @income_regphase -- > Residui calcolati sulla fase dell'Anagrafica 
		AND (EY.idupb  like @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
	GROUP BY EY.idupb

		
CREATE TABLE #VAR_ACCERTAMENTI_RESIDUI_CREDITORE(
	idupb varchar(36),	
	amount decimal(19,2)
	)  

INSERT INTO #VAR_ACCERTAMENTI_RESIDUI_CREDITORE(idupb, amount)
	SELECT
		EY.idupb,
		SUM(EV.amount)
	FROM incomevar EV
	JOIN income E
		ON EV.idinc = E.idinc
	JOIN incomeyear EY
		ON EY.idinc = EV.idinc
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN incometotal ET
		ON ET.idinc = EY.idinc
		AND ET.ayear = EY.ayear
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND EV.adate <= @date 
		AND ((ET.flag & 1) <> 0) -- Residuo
		AND E.nphase = @income_regphase -- > Residui calcolati sulla fase dell'Anagrafica 
		AND (EY.idupb LIKE @idupb)		
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY EY.idupb




CREATE TABLE #PAGAMENTI(
	idupb varchar(36),	
	amount decimal(19,2),
	flagarrear char(1)
	)  

 
INSERT INTO #PAGAMENTI( idupb,amount, flagarrear)  
select idupb,sum(amount),flagarrear FROM
(
select  HPV.idupb,ISNULL(HPV.amount,0) as amount,HPV.flagarrear AS flagarrear
	from historypaymentview HPV
	join upb 
		on upb.idupb = HPV.idupb	
where  (HPV.idupb like @idupb )
		and HPV.ymov = @ayear
		AND HPV.competencydate <= @date
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
UNION ALL
	SELECT HPV.idupb,
			ISNULL(EV.amount,0) as amount,
			HPV.flagarrear AS flagarrear
		FROM expensevar EV
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		join upb 
			on upb.idupb = HPV.idupb
		WHERE (HPV.idupb like @idupb )
			AND HPV.ymov = @ayear
			 AND EV.yvar = @ayear
			AND EV.adate <= @date
			AND HPV.competencydate <= @date 
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

) as Pagamenti
GROUP BY idupb,flagarrear




CREATE TABLE #INCASSI(
	idupb varchar(36),	
	amount decimal(19,2),
	flagarrear char(1)
	)  

 
INSERT INTO #INCASSI( idupb,amount, flagarrear)  
select idupb,sum(amount),flagarrear FROM
(
select  HPV.idupb,ISNULL(HPV.amount,0) as amount,HPV.flagarrear AS flagarrear
	from historyproceedsview HPV
	join upb 
		on upb.idupb = HPV.idupb	
where  (HPV.idupb like @idupb )
		and HPV.ymov = @ayear
		AND HPV.competencydate <= @date
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
UNION ALL
	SELECT HPV.idupb,
			ISNULL(EV.amount,0) as amount,
			HPV.flagarrear AS flagarrear
		FROM incomevar EV
		JOIN historyproceedsview HPV
			ON HPV.idinc = EV.idinc
		join upb 
			on upb.idupb = HPV.idupb
		WHERE (HPV.idupb like @idupb )
			AND HPV.ymov = @ayear
			 AND EV.yvar = @ayear
			AND EV.adate <= @date
			AND HPV.competencydate <= @date 
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

) as Pagamenti
GROUP BY idupb,flagarrear



--select sum(amount) from #PREVISIONE_PRINCIPALE_INIZIALE
--select sum(amount) from #VAR_PREVISIONE_PRINCIPALE
--select sum(amount) from #IMPEGNI_COMP 
--select * from #IMPEGNI_COMP ORDER BY idupb,AMOUNT
--
--select sum(amount) from #PREVISIONE_PRINCIPALE_INIZIALE_ENTRATA
--select sum(amount) from #VAR_PREVISIONE_PRINCIPALE_ENTRATA
--select sum(amount) from #ACCERTAMENTI_COMP 
--select * from #PAGAMENTI
--select * from #INCASSI
 ;with UWT(idupb) 
	 as 
	 (
		SELECT idupb FROM  #PREVISIONE_PRINCIPALE_INIZIALE 
		UNION 
		SELECT idupb FROM  #VAR_PREVISIONE_PRINCIPALE
		UNION 
		SELECT idupb FROM  #IMPEGNI_COMP 
		UNION 
		SELECT idupb FROM  #IMPEGNI_RESIDUI 
		UNION 
		SELECT idupb FROM  #VAR_IMPEGNI_RESIDUI 
		UNION 
		SELECT idupb FROM  #IMPEGNI_RESIDUI_CREDITORE 
		UNION 
		SELECT idupb FROM  #VAR_IMPEGNI_RESIDUI_CREDITORE 
		UNION 
		SELECT idupb FROM #PREVISIONE_PRINCIPALE_INIZIALE_ENTRATA 
		UNION 
		SELECT idupb FROM #VAR_PREVISIONE_PRINCIPALE_ENTRATA 
		UNION 
		SELECT idupb FROM #ACCERTAMENTI_COMP 
		UNION 
		SELECT idupb FROM #ACCERTAMENTI_RESIDUI 
		UNION 
		SELECT idupb FROM #VAR_ACCERTAMENTI_RESIDUI 
		UNION 
		SELECT idupb FROM #ACCERTAMENTI_RESIDUI_CREDITORE 
		UNION 
		SELECT idupb FROM #VAR_ACCERTAMENTI_RESIDUI_CREDITORE  
		UNION 
		SELECT idupb FROM #PAGAMENTI
		UNION 
		SELECT idupb FROM #INCASSI
		UNION
		SELECT idupb FROM #ACCERTAMENTI_COMP_CREDITORE
		UNION
		SELECT idupb from #IMPEGNI_COMP_CREDITORE
	 )
 

	SELECT 
			upb.codeupb as 'Cod.UPB',
			upb.title as 'UPB',
			upb.start as 'Data inizio UPB',
			upb.stop as 'Data fine UPB',
			isnull(PPI.amount,0) + isnull(VPI.amount,0)  - isnull(ImpComp.amount,0)
			as 'Previsione Disponibile di USCITA attuale',
		   isnull(PPIE.amount,0) + isnull(VPIE.amount,0)  - isnull(AccComp.amount,0)
			as 'Previsione Disponibile di ENTRATA attuale',
			isnull(ImpRes.amount,0) as 'Totale Impegni Residui al 01/01',
			isnull(VarImpRes.amount,0) as 'Totale Var. Impegni Residui',
			isnull(AccRes.amount,0) as 'Totale Accertamenti Residui al 01/01',
			isnull(VarAccRes.amount,0) as 'Totale Var. Accertamenti  Residui',
			isnull(ImpComp.amount,0) + isnull(ImpRes.amount,0) + isnull(VarImpRes.amount,0) 
			- isnull(Pagamenti_C.amount,0) - isnull(Pagamenti_R.amount,0) as 'Totale Residui Passivi al termine dell''esercizio',
			isnull(AccComp.amount,0) + isnull(AccRes.amount,0) + isnull(VarAccRes.amount,0) 
			- isnull(Incassi_C.amount,0) - isnull(Incassi_R.amount,0) as 'Totale Residui Attivi al termine dell''esercizio',
			--9. Avanzo di amministrazione della coppia UPB/voce di bilancio dato dalla seguente formula prendendo i precedenti punti ( 3 - 4 + 6 - 8 )
			isnull(PPI.amount,0) + isnull(VPI.amount,0)  - isnull(ImpComp.amount,0)  -
			(isnull(PPIE.amount,0) + isnull(VPIE.amount,0)  - isnull(AccComp.amount,0)) +
			isnull(VarAccRes.amount,0) - isnull(VarImpRes.amount,0) as 'Avanzo di amministrazione ',
			
			(
				isnull(PPI.amount,0) + isnull(VPI.amount,0)  - isnull(ImpComp.amount,0)  -
			    (isnull(PPIE.amount,0) + isnull(VPIE.amount,0)  - isnull(AccComp.amount,0)) +
			    isnull(VarAccRes.amount,0) - isnull(VarImpRes.amount,0) 
			) -- Avanzo Amm. 
			
			+
			(
			isnull(ImpComp.amount,0) + isnull(ImpRes.amount,0) + isnull(VarImpRes.amount,0) 
			- isnull(Pagamenti_C.amount,0) - isnull(Pagamenti_R.amount,0)
			) -- Tot. Residui passivi
			
			-
			
			(
			isnull(AccComp.amount,0) + isnull(AccRes.amount,0) + isnull(VarAccRes.amount,0) 
			- isnull(Incassi_C.amount,0) - isnull(Incassi_R.amount,0)
			) -- Tot. Residui attivi
			
			
			as 'Avanzo di cassa',
			/*Residui Propri = Impegni Comp.Creditore + Impegni Res.Creditore - Pagamenti Comp. - Pagamenti Residui.	*/
 			isnull(ImpCompCreditore.amount,0) + isnull(ImpResCreditore.amount,0) + isnull(VarImpResCreditore.amount,0)
			- isnull(Pagamenti_C.amount,0) - isnull(Pagamenti_R.amount,0) as 'Totale Residui Passivi "Propri" al termine dell''esercizio',
			/*Residui ImPropri = Residui fine esercio - Residui Propri.		*/
			isnull(ImpComp.amount,0) 
			+ isnull(ImpRes.amount,0) + isnull(VarImpRes.amount,0) 
			- isnull(Pagamenti_C.amount,0) - isnull(Pagamenti_R.amount,0)
			/* Residui Propri */
			- (isnull(ImpCompCreditore.amount,0) + isnull(ImpResCreditore.amount,0) + isnull(VarImpResCreditore.amount,0)- isnull(Pagamenti_C.amount,0) - isnull(Pagamenti_R.amount,0) )
			as 'Totale Residui Passivi "Impropri" al termine dell''esercizio',

			/*Residui Propri = Accertamenti Comp.Creditore + Accertamenti Res.Creditore - Pagamenti Comp. - Pagamenti Residui.	*/
 			isnull(AccCompCreditore.amount,0) + isnull(AccResCreditore.amount,0) + isnull(VarAccResCreditore.amount,0)
			- isnull(Incassi_C.amount,0) - isnull(Incassi_R.amount,0)
				as 'Totale Residui Attivi "Propri" al termine dell''esercizio',
			/*Residui ImPropri = Residui fine esercio - Residui Propri.		*/
			isnull(AccComp.amount,0) 
			+ isnull(AccRes.amount,0) + isnull(VarAccRes.amount,0) 
			- isnull(Incassi_C.amount,0) - isnull(Incassi_R.amount,0)
			/* Residui Propri */
			- (isnull(AccCompCreditore.amount,0) + isnull(AccResCreditore.amount,0) + isnull(VarAccResCreditore.amount,0)- isnull(Incassi_C.amount,0) - isnull(Incassi_R.amount,0) )
				as 'Totale Residui Attivi "Impropri" al termine dell''esercizio'
	FROM  UWT U
	JOIN upb on upb.idupb = U.idupb
	LEFT OUTER JOIN #PREVISIONE_PRINCIPALE_INIZIALE PPI
		ON  PPI.idupb = U.idupb 
	LEFT OUTER JOIN #VAR_PREVISIONE_PRINCIPALE VPI
		ON  VPI.idupb = U.idupb 
	----------------------------------------------------------------------
	----------------------------------------------------------------------
	LEFT OUTER JOIN #IMPEGNI_COMP ImpComp
		ON  ImpComp.idupb = U.idupb
	LEFT OUTER JOIN #IMPEGNI_RESIDUI ImpRes
		ON  ImpRes.idupb = U.idupb 
	LEFT OUTER JOIN	#VAR_IMPEGNI_RESIDUI VarImpRes
		ON  VarImpRes.idupb = U.idupb 
	----------------------------------------------------------------------
	----------------------------------------------------------------------
	LEFT OUTER JOIN #IMPEGNI_RESIDUI_CREDITORE ImpResCreditore	
		ON  ImpResCreditore.idupb = U.idupb 
	LEFT OUTER JOIN	#VAR_IMPEGNI_RESIDUI_CREDITORE VarImpResCreditore
		ON  VarImpResCreditore.idupb = U.idupb
	LEFT OUTER JOIN #IMPEGNI_COMP_CREDITORE ImpCompCreditore
		ON  ImpCompCreditore.idupb = U.idupb
	----------------------------------------------------------------------
	----------------------------------------------------------------------
	LEFT OUTER JOIN #PREVISIONE_PRINCIPALE_INIZIALE_ENTRATA PPIE
		ON  PPIE.idupb = U.idupb
	LEFT OUTER JOIN #VAR_PREVISIONE_PRINCIPALE_ENTRATA VPIE
		ON  VPIE.idupb = U.idupb  

	LEFT OUTER JOIN #ACCERTAMENTI_COMP AccComp
		ON  AccComp.idupb = U.idupb  
	LEFT OUTER JOIN #ACCERTAMENTI_RESIDUI AccRes
		ON  AccRes.idupb = U.idupb 
	LEFT OUTER JOIN	#VAR_ACCERTAMENTI_RESIDUI VarAccRes
		ON  VarAccRes.idupb = U.idupb 

	LEFT OUTER JOIN #ACCERTAMENTI_COMP_CREDITORE AccCompCreditore
		ON  AccCompCreditore.idupb = U.idupb  
	LEFT OUTER JOIN #ACCERTAMENTI_RESIDUI_CREDITORE AccResCreditore
		ON  AccResCreditore.idupb = U.idupb 
	LEFT OUTER JOIN	#VAR_ACCERTAMENTI_RESIDUI_CREDITORE VarAccResCreditore
		ON  VarAccResCreditore.idupb = U.idupb 


	LEFT OUTER JOIN	#PAGAMENTI Pagamenti_C
		ON  Pagamenti_C.idupb = U.idupb  AND Pagamenti_C.flagarrear = 'C'
	LEFT OUTER JOIN	#PAGAMENTI Pagamenti_R
		ON  Pagamenti_R.idupb = U.idupb  AND Pagamenti_R.flagarrear = 'R'
	LEFT OUTER JOIN	#INCASSI Incassi_C
		ON  Incassi_C.idupb = U.idupb  AND Incassi_C.flagarrear = 'C'
	LEFT OUTER JOIN	#INCASSI Incassi_R
		ON  Incassi_R.idupb = U.idupb  AND Incassi_R.flagarrear = 'R'
-- where upb.active = 'S' or upb.active is null
 
	--ORDER BY  U.codeupb 
 
	--drop table #PREVISIONE_PRINCIPALE_INIZIALE
	--drop table #VAR_PREVISIONE_PRINCIPALE
	--drop table #PICCOLE_SPESE 
	--drop table #IMPEGNI_COMP 
	--drop table #IMPEGNI_RESIDUI 
	--drop table #ACCERTAMENTI_COMP 
	--drop table #ACCERTAMENTI_RESIDUI 
 
END

GO
 







SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




  
  