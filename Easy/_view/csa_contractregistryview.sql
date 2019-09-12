-- CREAZIONE VISTA csa_contractregistryview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contractregistryview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contractregistryview]
GO

-- setuser'amministrazione'
-- clear_table_info'csa_contractregistryview'
-- select * from csa_contractregistryview
CREATE    VIEW [csa_contractregistryview]
(
	idcsa_contract,
	ayear ,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkind,
	contractkindcode,
	flagcr,
	idcsa_registry,
	extmatricula,
	idreg,
	title,
	cf
)
AS SELECT 

	CR.idcsa_contract,
	CR.ayear ,
	C.ycontract,
	C.ncontract,
	CK.idcsa_contractkind,
	CK.description,
	CK.contractkindcode,
	CK.flagcr,
	CR.idcsa_registry,
	CR.extmatricula,
	registry.idreg,
	registry.title,
	registry.cf
from csa_contractregistry CR
join csa_contract C
	on CR.idcsa_contract = C.idcsa_contract and CR.ayear = C.ayear
JOIN csa_contractkindyear CKY
	ON C.idcsa_contractkind = CKY.idcsa_contractkind
	AND CKY.ayear = C.ayear
JOIN csa_contractkind CK
	ON C.idcsa_contractkind = CK.idcsa_contractkind
left outer join registry
	on CR.idreg = registry.idreg
 
GO
