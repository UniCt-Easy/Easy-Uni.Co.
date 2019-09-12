-- CREAZIONE VISTA csa_billview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_billview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_billview]
GO
--setuser 'amm'
--setuser'amministrazione'
--select * from csa_billview
CREATE       VIEW [csa_billview]
(
	idcsa_import,
	idcsa_bill,
	ybill,
	nbill,
	motive,
	adate,
	description,
	idreg,
	registry,
	amount,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	I.idcsa_import,
	A.idcsa_bill,
	B.ybill,
	B.nbill,
	B.motive,
	B.adate,
	I.description,
	A.idreg,
	R.title,
	A.amount,
	A.cu,
	A.ct,
	A.lu,
	A.lt
FROM csa_bill A
LEFT OUTER JOIN registry R
ON A.idreg = R.idreg
LEFT OUTER JOIN csa_import I
ON A.idcsa_import = I.idcsa_import
JOIN bill B
ON B.ybill = I.yimport
AND B.nbill = A.nbill
AND B.billkind = 'D'
GO
