-- CREAZIONE VISTA csa_agencyview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_agencyview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_agencyview]
GO
 

CREATE       VIEW [csa_agencyview]
(
	idcsa_agency,
	ente,
	description,
	idreg,
	registry,
	isinternal,
	flag,
	annualpayment,
	nobill,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	A.idcsa_agency,
	A.ente,
	A.description,
	A.idreg,
	R.title,
	A.isinternal,
	A.flag, 
	CASE	WHEN (ISNULL(A.flag,0) & 1 <> 0) THEN 'S' ELSE 'N' END,
	CASE	WHEN (ISNULL(A.flag,0) & 2 <> 0) THEN 'S' ELSE 'N' END,
	A.cu,
	A.ct,
	A.lu,
	A.lt
FROM csa_agency A
LEFT OUTER JOIN registry R
ON A.idreg = R.idreg



GO

-- 