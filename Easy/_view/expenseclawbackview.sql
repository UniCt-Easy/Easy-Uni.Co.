-- CREAZIONE VISTA expenseclawbackview
IF EXISTS(select * from sysobjects where id = object_id(N'[expenseclawbackview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenseclawbackview]
GO

CREATE VIEW expenseclawbackview 
(
	idexp,
	idclawback,
	description,
	clawbackref,
	amount,
	rateableallowance,
	fiscaltaxcode,
	identifying_marks,
	code,
	tiporiga,
	rifb_month,
	rifb_year,
	rifa_month,
	rifa_year,
	rifa,
	idunifiedclawback,
	idf24ep,
	flagf24ep,
	transmissiondate,
	desctiporiga,
	rifa_monthname,
	rifb_monthname,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	EC.idexp,
	EC.idclawback,
	C.description,
	C.clawbackref,
	EC.amount,
	EC.amount,
	EC.fiscaltaxcode,
	EC.identifying_marks,
	EC.code,
	EC.tiporiga,
	EC.rifb_month,
	EC.rifb_year,
	EC.rifa_month,
	EC.rifa_year,
	EC.rifa,
	EC.idunifiedclawback,
	EC.idf24ep,
	C.flagf24ep,
	PT.transmissiondate, 
	LK.description,
	M1.title,
	M2.title,
	EC.cu,
	EC.ct,
	EC.lu,
	EC.lt
FROM expenseclawback EC
JOIN clawback C
	ON C.idclawback = EC.idclawback
JOIN expenselast EL 
	ON  EC.idexp=EL.idexp
LEFT OUTER JOIN payment P
	ON P.kpay = EL.kpay
JOIN paymenttransmission PT
	ON PT.kpaymenttransmission =  P.kpaymenttransmission
LEFT OUTER JOIN lookup_tiporigaf24ep LK
	ON LK.tiporiga = EC.tiporiga
LEFT OUTER JOIN monthname M1
	ON M1.code = EC.rifa_month
LEFT OUTER JOIN monthname M2
	ON M2.code = EC.rifb_month





GO
