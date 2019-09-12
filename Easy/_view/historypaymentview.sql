-- CREAZIONE VISTA historypaymentview
IF EXISTS(select * from sysobjects where id = object_id(N'[historypaymentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [historypaymentview]
GO



CREATE     VIEW [historypaymentview]
(
	idexp,
	ymov,
	nmov,
	adate,
	idreg,
	idman,
	doc,
	docdate,
	description,
	competencydate,
	amount,
	curramount,
	--employtaxamount,
	--admintaxamount,
	--clawbackamount,
	totflag,
	flagarrear,
	kpay,
	ypay,
	npay,
	idfin,idupb,
	idtreasurer,
	codetreasurer
)
AS
SELECT  expense.idexp, 
	config.ayear, 
	expense.nmov, 
	expense.adate,
	expense.idreg, 
	expense.idman, 
	expense.doc, 
	expense.docdate, 
	expense.description, 
	payment.adate, 
	expenseyear.amount, 
	expensetotal.curramount, --expense.employtaxamount, expense.admintaxamount, expense.clawbackamount,
	expensetotal.flag, 
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	payment.kpay,
	payment.ypay, 
	payment.npay, 
	expenseyear.idfin,
	expenseyear.idupb,
	payment.idtreasurer,
	treasurer.codetreasurer
FROM config
JOIN expense
	ON expense.ymov = config.ayear
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay 
JOIN expenseyear 
	ON expense.idexp = expenseyear.idexp
	AND config.ayear = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = config.ayear
JOIN treasurer
	ON treasurer.idtreasurer = payment.idtreasurer
WHERE  config.cashvaliditykind = 1  --EMITTED

UNION ALL

SELECT 
	expense.idexp, 
	config.ayear, 
	expense.nmov, 
	expense.adate,
	expense.idreg, 
	expense.idman, 
	expense.doc, 
	expense.docdate, 
	expense.description, 
	payment.printdate, 
	expenseyear.amount, 
	expensetotal.curramount, --expense.employtaxamount, expense.admintaxamount, expense.clawbackamount,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	--expenseyear.flagarrear, 
	payment.kpay,
	payment.ypay, 
	payment.npay,  
	expenseyear.idfin,
	expenseyear.idupb,
	payment.idtreasurer,
	treasurer.codetreasurer
FROM  config
JOIN expense
	ON expense.ymov = config.ayear
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay 
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp 
	AND expenseyear.ayear = config.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = config.ayear
JOIN treasurer
	ON treasurer.idtreasurer = payment.idtreasurer
WHERE config.cashvaliditykind = 2   --PAYMENT PRINTED

UNION  ALL
SELECT  expense.idexp, 
	config.ayear ,--P.ymov, 
	expense.nmov,
	expense.adate, 
	expense.idreg, 
	expense.idman, 
	expense.doc, 
	expense.docdate, 
	expense.description, 
	paymenttransmission.transmissiondate, 
	expenseyear.amount,
	expensetotal.curramount, --expense.employtaxamount, expense.admintaxamount, expense.clawbackamount,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	--expenseyear.flagarrear, 
	payment.kpay,
	payment.ypay, 
	payment.npay, 
	expenseyear.idfin,
	expenseyear.idupb,
	payment.idtreasurer,
	treasurer.codetreasurer
FROM config
JOIN expense
	ON expense.ymov = config.ayear
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay 
JOIN paymenttransmission 
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND config.ayear = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = config.ayear
JOIN treasurer
	ON treasurer.idtreasurer = payment.idtreasurer
WHERE config.cashvaliditykind = 3 -- PAYMENT COMMUNICATED

UNION ALL
SELECT 
	expense.idexp, 
	config.ayear, 
	expense.nmov, 
	expense.adate,
	expense.idreg, 
	expense.idman, 
	expense.doc, 
	expense.docdate, 
	expense.description, 
	banktransaction.transactiondate, 
	banktransaction.amount, 
	banktransaction.amount, --expense.employtaxamount, expense.admintaxamount, expense.clawbackamount,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	--expenseyear.flagarrear, 
	payment.kpay,
	payment.ypay, 
	payment.npay, 
	expenseyear.idfin,
	expenseyear.idupb,
	payment.idtreasurer,
	treasurer.codetreasurer
FROM  config 
JOIN expense
	ON expense.ymov = config.ayear
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay 
JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND config.ayear = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = config.ayear
JOIN banktransaction
	ON banktransaction.idexp = expense.idexp
	AND banktransaction.yban = config.ayear       
JOIN treasurer
	ON treasurer.idtreasurer = payment.idtreasurer	 
WHERE  config.cashvaliditykind = 4  --PERFORMED



GO
