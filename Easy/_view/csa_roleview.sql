-- CREAZIONE VISTA csa_roleview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_roleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_roleview]
GO

CREATE    VIEW [csa_roleview]
(
	ruoloCSA,
	idreg,
	registry,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivecredit,
	codemotivecredit,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	C.ruoloCSA,
	C.idreg,
	R.title,
	C.idaccmotivedebit,
	accmotivedebit.codemotive,
	C.idaccmotivecredit,
	accmotivecredit.codemotive,
	C.cu,
	C.ct,
	C.lu,
	C.lt
FROM csa_role C 
LEFT OUTER JOIN registry R 
	ON R.idreg=C.idreg
LEFT OUTER JOIN accmotive accmotivedebit
	ON C.idaccmotivedebit = accmotivedebit.idaccmotive
LEFT OUTER JOIN accmotive accmotivecredit
	ON C.idaccmotivecredit = accmotivecredit.idaccmotive

GO

