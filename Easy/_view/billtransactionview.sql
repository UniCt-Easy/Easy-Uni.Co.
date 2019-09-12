-- CREAZIONE VISTA banktransactionview
IF EXISTS(select * from sysobjects where id = object_id(N'[billtransactionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [billtransactionview]
GO

--setuser 'amm'
--select * from billtransactionview
CREATE  VIEW billtransactionview 
(
	ybilltran,
	nbilltran,
	nbill,
	amount,
	adate,
	kind,
	kpay,
	ypay,
	npay,
	idpay,
	kpro,
	ypro,
	npro,
	idpro,
	income,
	idinc,
	yinc,
	ninc,
	expense,
	idexp,
	yexp,
	nexp,
	idbankimport,
	registry,
	ct,
	cu,
	lt,
	lu
)
AS SELECT 
	billtransaction.ybilltran,
	billtransaction.nbilltran,
	billtransaction.nbill,
	billtransaction.amount,
	billtransaction.adate,
	billtransaction.kind,
	payment.kpay,
	payment.ypay,
	payment.npay,
	EL.idpay,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	IL.idpro,
	CASE
		WHEN billtransaction.kind = 'C'
		THEN IT.curramount
		ELSE NULL
	END,
	IL.idinc,
	income.ymov,
	income.nmov,
	CASE
		WHEN billtransaction.kind = 'D'
		THEN ET.curramount
		ELSE NULL
	END,
	EL.idexp,
	expense.ymov,
	expense.nmov,
	billtransaction.idbankimport,
	registry.title,
	billtransaction.ct,
	billtransaction.cu,
	billtransaction.lt,
	billtransaction.lu
	FROM billtransaction
left outer join expenselast EL on EL.nbill=billtransaction.nbill and billtransaction.kind = 'D'
LEFT OUTER JOIN expense		ON expense.idexp = EL.idexp and expense.ymov=billtransaction.ybilltran
LEFT OUTER JOIN expensetotal ET		ON ET.idexp = expense.idexp and ET.ayear=expense.ymov
LEFT OUTER JOIN payment 	ON payment.kpay = EL.kpay and expense.idexp is not null
left outer join incomelast IL on IL.nbill=billtransaction.nbill and billtransaction.kind = 'C'
LEFT OUTER JOIN income		ON income.idinc = IL.idinc and income.ymov=billtransaction.ybilltran
LEFT OUTER JOIN incometotal IT		ON IT.idinc = IL.idinc and IT.ayear=income.ymov
LEFT OUTER JOIN proceeds	ON proceeds.kpro = IL.kpro and income.idinc is not null
left outer join registry on registry.idreg=ISNULL(expense.idreg,income.idreg)


GO
