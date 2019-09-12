-- CREAZIONE VISTA historyproceedsview
IF EXISTS(select * from sysobjects where id = object_id(N'[historyproceedsview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [historyproceedsview]
GO


CREATE    VIEW historyproceedsview
(
	idinc,
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
	totflag,
	flagarrear,
	kpro,
	ypro,
	npro,
	idfin,idupb,
	idtreasurer,
	codetreasurer
)
AS
SELECT 
	income.idinc, 
	config.ayear, 
	income.nmov, 
	income.adate,
	income.idreg, 
	income.idman, 
	income.doc, 
	income.docdate, 
	income.description, 
	proceeds.adate, 
	--income.amount, 
	incomeyear.amount,
	incometotal.curramount, 
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	--incomeyear.flagarrear, 
	proceeds.kpro,
	proceeds.ypro, 
	proceeds.npro, 
	incomeyear.idfin,
	incomeyear.idupb,	
	proceeds.idtreasurer,
	treasurer.codetreasurer
FROM config	
JOIN income
	ON income.ymov = config.ayear
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND config.ayear= incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = config.ayear
JOIN treasurer
	ON treasurer.idtreasurer = proceeds.idtreasurer
WHERE  config.cashvaliditykind = 1 --emitted

UNION ALL

SELECT 
	income.idinc, 
	config.ayear, 
	income.nmov, 
	income.adate,
	income.idreg,
	income.idman, 
	income.doc, 
	income.docdate, 
	income.description, 
	proceeds.printdate, 
	incomeyear.amount,
	--income.amount, 
	incometotal.curramount, 
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	--incomeyear.flagarrear, 
	proceeds.kpro,
	proceeds.ypro, 
	proceeds.npro, 
	incomeyear.idfin,
	incomeyear.idupb,	
	proceeds.idtreasurer,
	treasurer.codetreasurer
FROM config	
JOIN income
	ON income.ymov = config.ayear
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND config.ayear = incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = config.ayear
JOIN treasurer
	ON treasurer.idtreasurer = proceeds.idtreasurer
WHERE  config.cashvaliditykind = 2 --printed

UNION ALL


SELECT 
	income.idinc, 
	config.ayear, 
	income.nmov, 
	income.adate,
	income.idreg, 
	income.idman, 
	income.doc, 
	income.docdate, 
	income.description, 
	proceedstransmission.transmissiondate, 
	incomeyear.amount,
	--income.amount, 
	incometotal.curramount, 
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	--incomeyear.flagarrear, 	
	proceeds.kpro,
	proceeds.ypro, 
	proceeds.npro, 
	incomeyear.idfin,
	incomeyear.idupb,	
	proceeds.idtreasurer,
	treasurer.codetreasurer
FROM config	
JOIN income
	ON income.ymov = config.ayear
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN proceedstransmission 
	ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND config.ayear = incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = config.ayear
JOIN treasurer
	ON treasurer.idtreasurer = proceeds.idtreasurer
WHERE  config.cashvaliditykind = 3 --comm


UNION ALL
SELECT 
	income.idinc, 
	config.ayear, 
	income.nmov, 
	income.adate,
	income.idreg, 
	income.idman, 
	income.doc, 
	income.docdate, 
	income.description, 
	banktransaction.transactiondate, 
	banktransaction.amount, 
	banktransaction.amount,
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	--incomeyear.flagarrear, 
	proceeds.kpro,
	proceeds.ypro, 
	proceeds.npro, 
	incomeyear.idfin,
	incomeyear.idupb,	
	proceeds.idtreasurer,
	treasurer.codetreasurer
FROM config
JOIN income
	ON income.ymov = config.ayear 
JOIN incomelast
	ON income.idinc = incomelast.idinc 
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN proceedstransmission 
	ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND config.ayear = incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = config.ayear
JOIN banktransaction
	ON banktransaction.idinc = income.idinc
JOIN treasurer
	ON treasurer.idtreasurer = proceeds.idtreasurer
WHERE  config.cashvaliditykind = 4 -- bankt

GO
