
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_avanzo_ammin_effettivo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_avanzo_ammin_effettivo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [rpt_avanzo_ammin_effettivo]
  @ayear smallint,
  @date smalldatetime
AS
BEGIN

DECLARE @floatfund_01_jan_used decimal(19,2) 
SELECT @floatfund_01_jan_used = isnull((CONVERT(decimal(19,2), paramvalue)),0) 
FROM generalreportparameter 
WHERE idparam='ff_jan01'

DECLARE @aa_01_jan_used decimal(19,2) 
SELECT @aa_01_jan_used = isnull((CONVERT(decimal(19,2), paramvalue)),0) 
FROM generalreportparameter 
WHERE idparam='aa_jan01'

DECLARE @supposed_ff_01_jan_used decimal(19,2) 
SELECT @supposed_ff_01_jan_used = isnull((CONVERT(decimal(19,2), paramvalue)),0) 
FROM generalreportparameter 
WHERE idparam='supposed_ff_jan01'

DECLARE @supposed_aa_01_jan_used decimal(19,2) 
SELECT @supposed_aa_01_jan_used = isnull((CONVERT(decimal(19,2), paramvalue)),0) 
FROM generalreportparameter 
WHERE idparam='supposed_aa_jan01'

-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
DECLARE @floatfund_01_jan decimal(19,2)
IF (SELECT COUNT(*) FROM surplus WHERE ayear= @ayear) >0
	Begin
	SELECT @floatfund_01_jan = ISNULL(startfloatfund, 0)
	FROM surplus 
	WHERE ayear = @ayear 
	End
ELSE
	SET @floatfund_01_jan=0

DECLARE @proceeds_01_jan decimal(19,2)
SELECT @proceeds_01_jan = SUM(incometotal.curramount)
FROM incometotal
JOIN income
	ON income.idinc = incometotal.idinc
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro
JOIN proceedstransmission
	ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
WHERE incometotal.ayear = @ayear
	AND proceedstransmission.transmissiondate <= @date
	AND proceedstransmission.yproceedstransmission = @ayear

DECLARE @payments_01_jan decimal(19,2)
SELECT @payments_01_jan = SUM(expensetotal.curramount) 
FROM expensetotal
JOIN expenselast
	ON expensetotal.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
	AND paymenttransmission.transmissiondate <= @date
	AND paymenttransmission.ypaymenttransmission = @ayear
WHERE expensetotal.ayear = @ayear

DECLARE @floatfund_stilldate decimal(19,2)
SET @floatfund_stilldate = ISNULL(@floatfund_01_jan, 0) + ISNULL(@proceeds_01_jan, 0) - ISNULL(@payments_01_jan, 0)

DECLARE @assessmentphasecode tinyint
SELECT @assessmentphasecode = assessmentphasecode
FROM config
WHERE ayear = @ayear

IF @assessmentphasecode IS NULL
BEGIN
	SELECT @assessmentphasecode = incomefinphase
	FROM uniconfig
END

DECLARE @revenue decimal(19,2)
SELECT @revenue = SUM(incomeyear.amount)
FROM incometotal
JOIN incomeyear
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
JOIN income
	ON income.idinc = incometotal.idinc
WHERE incometotal.ayear = @ayear
	AND ((incometotal.flag & 1)=1)  -->  Residuo
	AND income.adate <= @date
	AND income.nphase = @assessmentphasecode

DECLARE @revenue_var decimal(19,2)
SELECT @revenue_var = SUM(incomevar.amount)
FROM incomevar
JOIN incomeyear
	ON incomeyear.idinc = incomevar.idinc
JOIN income
	ON income.idinc = incomeyear.idinc
JOIN incometotal
	ON incometotal.idinc = income.idinc
WHERE incomevar.yvar = @ayear
	AND incomevar.adate <= @date
	AND incomeyear.ayear = @ayear
	AND incometotal.ayear = @ayear
	AND ((incometotal.flag & 1)=1) 
	AND income.nphase = @assessmentphasecode

DECLARE @assessment_stilldate decimal(19,2)
SELECT @assessment_stilldate = SUM(incomeyear.amount) 
FROM incometotal
JOIN incomeyear
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
JOIN income
	ON income.idinc = incometotal.idinc
WHERE incometotal.ayear = @ayear
	AND ((incometotal.flag & 1) = 0)
	AND income.nphase = @assessmentphasecode
	AND income.adate <= @date

DECLARE @var_assessment_stilldate decimal(19,2)
SELECT @var_assessment_stilldate = SUM(incomevar.amount) 
FROM incomevar
JOIN incomeyear
	ON incomeyear.idinc = incomevar.idinc
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
JOIN income
	ON income.idinc = incometotal.idinc
WHERE incomevar.yvar = @ayear
	AND incomevar.adate <= @date
	AND ((incometotal.flag & 1) = 0)
	AND incomeyear.ayear = @ayear
	AND income.nphase = @assessmentphasecode

DECLARE @appropriationphasecode tinyint
SELECT @appropriationphasecode = appropriationphasecode
FROM config
WHERE ayear = @ayear
IF @appropriationphasecode IS NULL
BEGIN
	SELECT @appropriationphasecode = expensefinphase
	FROM uniconfig
END

DECLARE @expenditure decimal(19,2)
SELECT @expenditure = SUM(expenseyear.amount)
FROM expensetotal
JOIN expenseyear
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
JOIN expense
	ON expense.idexp = expensetotal.idexp
WHERE expensetotal.ayear = @ayear
	AND ((expensetotal.flag & 1) = 1)
	AND expense.nphase = @appropriationphasecode
	AND expense.adate <= @date

DECLARE @expenditure_var decimal(19,2)
SELECT @expenditure_var = SUM(expensevar.amount)
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp
JOIN expense
	ON expense.idexp = expenseyear.idexp
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
WHERE expensevar.yvar = @ayear
	AND expensevar.adate <= @date
	AND expenseyear.ayear = @ayear
	AND ((expensetotal.flag & 1) = 1)
	AND expense.nphase = @appropriationphasecode

DECLARE @appropriation_stilldate decimal(19,2) 
SELECT @appropriation_stilldate = SUM(expenseyear.amount)
FROM expensetotal
JOIN expenseyear
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
JOIN expense
	ON expense.idexp = expensetotal.idexp
WHERE expensetotal.ayear = @ayear
	AND ((expensetotal.flag & 1) = 0)
	AND expense.nphase = @appropriationphasecode
	AND expense.adate <= @date

DECLARE @var_appropriation_stilldate decimal(19,2)
SELECT @var_appropriation_stilldate = SUM(expensevar.amount) 
FROM expensevar
JOIN expenseyear
	ON expenseyear.idexp = expensevar.idexp
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
JOIN expense
	ON expense.idexp = expenseyear.idexp
WHERE expensevar.yvar = @ayear
	AND expenseyear.ayear = @ayear
	AND expensevar.adate <= @date
	AND ((expensetotal.flag & 1) = 0)
	AND expense.nphase = @appropriationphasecode

DECLARE @competencyproceeds decimal(19,2)
SELECT @competencyproceeds = SUM(incometotal.curramount)
FROM incometotal
JOIN income
	ON income.idinc = incometotal.idinc
JOIN incomeyear
	ON incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro
JOIN proceedstransmission
	ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
WHERE incometotal.ayear = @ayear
	AND proceedstransmission.transmissiondate <= @date
	AND proceedstransmission.yproceedstransmission = @ayear
	AND ((incometotal.flag & 1) = 0)

DECLARE @residualproceeds decimal(19,2)
SELECT @residualproceeds = SUM(incometotal.curramount)
FROM incometotal
JOIN income
	ON income.idinc = incometotal.idinc
JOIN incomeyear
	ON incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro
JOIN proceedstransmission
	ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
WHERE incometotal.ayear = @ayear
	AND ((incometotal.flag & 1) = 1)
	AND proceedstransmission.transmissiondate <= @date
	AND proceedstransmission.yproceedstransmission = @ayear

DECLARE @competencypayments decimal(19,2)
SELECT @competencypayments = SUM(expensetotal.curramount) 
FROM expensetotal
JOIN expenseyear
	ON expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN expenselast
	ON expensetotal.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
WHERE expensetotal.ayear = @ayear
	AND ((expensetotal.flag & 1) = 0)
	AND paymenttransmission.transmissiondate <= @date
	AND paymenttransmission.ypaymenttransmission = @ayear

DECLARE @residualpayments decimal(19,2)
SELECT @residualpayments = SUM(expensetotal.curramount) 
FROM expensetotal
JOIN expenseyear
	ON expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN expenselast
	ON expensetotal.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
WHERE expensetotal.ayear = @ayear
	AND ((expensetotal.flag & 1) = 1)
	AND paymenttransmission.transmissiondate <= @date
	AND paymenttransmission.ypaymenttransmission = @ayear

DECLARE @creditsurplus_stilldate decimal(19,2)
SET @creditsurplus_stilldate = ISNULL(@floatfund_stilldate , 0)
	+ ISNULL(@assessment_stilldate , 0)
	+ ISNULL(@var_assessment_stilldate , 0)
	+ ISNULL(@revenue, 0)
	+ ISNULL(@revenue_var, 0)
	- ISNULL(@appropriation_stilldate, 0)
	- ISNULL(@var_appropriation_stilldate, 0)
	- ISNULL(@expenditure, 0)
	- ISNULL(@expenditure_var, 0)
	- ISNULL(@proceeds_01_jan, 0)
	+ ISNULL(@payments_01_jan, 0)

DECLARE @assessment_31_dec decimal(19,2)
SELECT @assessment_31_dec = SUM(incometotal.curramount)
FROM incometotal
JOIN income
	ON income.idinc = incometotal.idinc
WHERE incometotal.ayear = @ayear
	AND income.nphase = @assessmentphasecode
	AND income.adate > @date

DECLARE @appropriation_31_dec decimal(19,2)
SELECT @appropriation_31_dec = SUM(expensetotal.curramount)
FROM expensetotal
JOIN expense
	ON expense.idexp = expensetotal.idexp
WHERE expensetotal.ayear = @ayear
	AND expense.nphase = @appropriationphasecode
	AND expense.adate > @date

DECLARE @creditsurplus_31_dec decimal(19,2)
SET @creditsurplus_31_dec = ISNULL(@creditsurplus_stilldate, 0) + ISNULL(@assessment_31_dec, 0) - ISNULL(@appropriation_31_dec, 0)
SELECT 
	ISNULL(@floatfund_01_jan, 0) AS floatfund_01_jan,
	ISNULL(@floatfund_01_jan_used,0) AS floatfund_01_jan_used,
	ISNULL(@aa_01_jan_used,0) AS aa_01_jan_used,
	isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,		
	isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used,
	ISNULL(@proceeds_01_jan, 0) AS proceeds_01_jan,
	ISNULL(@payments_01_jan, 0) AS payments_01_jan,
	ISNULL(@floatfund_stilldate, 0) AS floatfund_stilldate,				
	ISNULL(@revenue, 0) AS revenue,
	ISNULL(@revenue_var, 0) AS revenue_var,
	ISNULL(@expenditure, 0) AS expenditure,
	ISNULL(@expenditure_var, 0) AS expenditure_var,
	ISNULL(@competencyproceeds, 0) AS competencyproceeds,
	ISNULL(@residualproceeds, 0) AS residualproceeds,
	ISNULL(@competencypayments, 0) AS competencypayments,
	ISNULL(@residualpayments, 0) AS residualpayments,
	ISNULL(@assessment_stilldate, 0) AS assessment_stilldate,
	ISNULL(@var_assessment_stilldate, 0) AS var_assessment_stilldate,
	ISNULL(@appropriation_stilldate, 0) AS appropriation_stilldate,
	ISNULL(@var_appropriation_stilldate, 0) AS var_appropriation_stilldate,
	ISNULL(@creditsurplus_stilldate, 0) AS creditsurplus_stilldate,
	ISNULL(@assessment_31_dec, 0) AS assessment_31_dec,
	ISNULL(@appropriation_31_dec, 0) AS appropriation_31_dec,
	ISNULL(@creditsurplus_31_dec, 0) AS creditsurplus_31_dec
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
