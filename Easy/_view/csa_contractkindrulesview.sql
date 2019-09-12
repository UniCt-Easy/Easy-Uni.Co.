-- CREAZIONE VISTA csa_contractkindrulesview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contractkindrulesview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contractkindrulesview]
GO



--setuser 'amministrazione'

--select * from csa_contractkindrulesview


CREATE    VIEW [csa_contractkindrulesview]
(
	idcsa_contractkind,
	idcsa_rule,
	capitolocsa,
	ruolocsa,
	ayear,
	description,
	contractkindcode,
	flagcr,
	flagkeepalive,
	active,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	C.idcsa_contractkind,
	R.idcsa_rule,
	R.capitolocsa,
	R.ruolocsa,
	R.ayear,
	C.description,
	C.contractkindcode,
	C.flagcr,
	C.flagkeepalive,
	C.active,
	R.cu,
	R.ct,
	R.lu,
	R.lt
FROM csa_contractkindrules R
JOIN csa_contractkind C				ON C.idcsa_contractkind = R.idcsa_contractkind
JOIN csa_contractkindyear CY		ON C.idcsa_contractkind = CY.idcsa_contractkind AND R.ayear=CY.ayear


GO
