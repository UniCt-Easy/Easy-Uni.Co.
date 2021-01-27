
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_avanzo_cassa_effettivo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_avanzo_cassa_effettivo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [rpt_avanzo_cassa_effettivo]
  @ayear smallint,
  @date smalldatetime
AS
BEGIN

IF ( (@ayear IS NULL)OR (@ayear = 0)) 
BEGIN
	DECLARE @zero decimal(19,2)
	SET @zero = 0
	SELECT 
		@zero AS floatfund_01_jan,
		@zero AS proceeds_01_jan,
		@zero AS payments_01_jan,
		@zero AS floatfund_stilldate,
		@zero AS proceeds_supposed,
		@zero AS proceeds_followingdate,
		@zero AS payments_supposed,
		@zero AS payments_followingdate,
		@zero AS assessment_supposedproceeds,
		@zero AS appropriation_supposedpayments,
		@zero AS floatfund_31_dec
	RETURN    
END


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
	SET @floatfund_01_jan = 0

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
JOIN expense
	ON expense.idexp = expensetotal.idexp
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
WHERE expensetotal.ayear = @ayear
	AND paymenttransmission.transmissiondate <= @date
	AND paymenttransmission.ypaymenttransmission = @ayear

DECLARE @floatfund_stilldate decimal(19,2)
SELECT @floatfund_stilldate = ISNULL(@floatfund_01_jan, 0) + ISNULL(@proceeds_01_jan, 0) - ISNULL(@payments_01_jan, 0)

DECLARE @incassidoc decimal(19,2)
SELECT @incassidoc = SUM(incometotal.curramount)
FROM incometotal
JOIN income
	ON income.idinc = incometotal.idinc
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro
WHERE incometotal.ayear = @ayear

-- Reversali da trasmettere al cassiere o trasmesse dopo la data
DECLARE @proceeds_supposed decimal(19,2)
SELECT @proceeds_supposed = ISNULL(@incassidoc, 0) - ISNULL(@proceeds_01_jan, 0)
DECLARE @proceeds_followingdate  decimal(19,2)
SELECT @proceeds_followingdate  = SUM(incometotal.curramount)
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
	AND proceedstransmission.transmissiondate > @date
	AND proceedstransmission.yproceedstransmission = @ayear

DECLARE @pagamentidoc decimal(19,2)
SELECT @pagamentidoc = SUM(expensetotal.curramount) 
FROM expensetotal
JOIN expense
	ON expense.idexp = expensetotal.idexp
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay
WHERE expensetotal.ayear = @ayear

-- Mandati da trasmettere al cassiere o trasmessi dopo la data
DECLARE @payments_supposed decimal(19,2)
SELECT @payments_supposed = ISNULL(@pagamentidoc, 0) - ISNULL(@payments_01_jan, 0)
DECLARE @payments_followingdate decimal(19,2)
SELECT @payments_followingdate = SUM(expensetotal.curramount) 
FROM expensetotal
JOIN expense
	ON expense.idexp = expensetotal.idexp
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
WHERE expensetotal.ayear = @ayear
	AND paymenttransmission.transmissiondate > @date
	AND paymenttransmission.ypaymenttransmission = @ayear

DECLARE @DEC_31 datetime
SET @DEC_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)

DECLARE @assessmentphasecode tinyint
SELECT @assessmentphasecode = assessmentphasecode
FROM config
WHERE ayear = @ayear

IF @assessmentphasecode IS NULL
BEGIN
	SELECT @assessmentphasecode = incomefinphase
	FROM uniconfig
END

-- Accertamenti senza scadenza o con scadenza entro il 31 dicembre
DECLARE @assessment_supposedproceeds decimal(19,2)	
SELECT @assessment_supposedproceeds = SUM(incometotal.available)
FROM incometotal
JOIN income
	ON income.idinc = incometotal.idinc
LEFT OUTER JOIN incomelast
	ON income.idinc = incomelast.idinc
left outer join proceeds on proceeds.kpro = incomelast.kpro
WHERE incometotal.ayear = @ayear
	AND income.nphase >= @assessmentphasecode
	--AND income.ypro IS NULL
	AND proceeds.npro IS NULL
	AND ( income.expiration IS NULL OR income.expiration <= @DEC_31)

DECLARE @appropriationphasecode tinyint
SELECT @appropriationphasecode = appropriationphasecode
FROM config
WHERE ayear = @ayear

IF @appropriationphasecode IS NULL
BEGIN
	SELECT @appropriationphasecode = expensefinphase
	FROM uniconfig
END

-- Impegni senza scadenza o con scadenza entro il 31 dicembre
DECLARE @appropriation_supposedpayments decimal(19,2)
SELECT @appropriation_supposedpayments = SUM(expensetotal.available)
FROM expensetotal
JOIN expense
	ON expense.idexp = expensetotal.idexp
LEFT OUTER JOIN expenselast
	ON expense.idexp = expenselast.idexp
left outer join payment on payment.kpay = expenselast.kpay
WHERE expensetotal.ayear = @ayear
	AND expense.nphase >= @appropriationphasecode
	--AND expense.ypay IS NULL
	AND payment.kpay IS NULL
	AND ( expense.expiration IS NULL OR expense.expiration <= @DEC_31 )

DECLARE @floatfund_31_dec decimal(19,2)
SELECT @floatfund_31_dec = ISNULL(@floatfund_stilldate,0)
              + ISNULL(@proceeds_supposed,0)
              + ISNULL(@assessment_supposedproceeds,0)
              - ISNULL(@payments_supposed,0)
              - ISNULL(@appropriation_supposedpayments,0)
SELECT 
	@floatfund_01_jan AS floatfund_01_jan,
	ISNULL(@floatfund_01_jan_used,0) AS floatfund_01_jan_used,
	ISNULL(@aa_01_jan_used,0) AS aa_01_jan_used,
	isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,		
	isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used,
	@proceeds_01_jan AS proceeds_01_jan,
	@payments_01_jan AS payments_01_jan,
	@floatfund_stilldate AS floatfund_stilldate,
	@proceeds_supposed AS proceeds_supposed,
	@proceeds_followingdate AS proceeds_followingdate,
	@payments_supposed AS payments_supposed,
	@payments_followingdate AS payments_followingdate,
	@assessment_supposedproceeds AS assessment_supposedproceeds,
	@appropriation_supposedpayments AS appropriation_supposedpayments,
	@floatfund_31_dec AS floatfund_31_dec
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
