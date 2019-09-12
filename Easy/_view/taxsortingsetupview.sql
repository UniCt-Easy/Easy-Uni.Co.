-- CREAZIONE VISTA taxsortingsetupview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxsortingsetupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxsortingsetupview]
GO


 --select * from [taxsortingsetupview]


CREATE VIEW [taxsortingsetupview]
(
	ayear,
	idautotaxsor,
	taxcode,
	taxref, 
	descrritenuta,
	idser,
	codeser,
	service,
	flaginherit,
	idsorkind,
	codesorkind,
	sortingkind,
	idsor_employproc,
	sortcode_employproc,
	sorting_employproc,
	idsor_adminproc,
	sortcode_adminproc,
	sorting_adminproc,
	idsor_adminpay,
	sortcode_adminpay,
	sorting_adminpay,
	idsor_taxpay,
	sortcode_taxpay,
	sorting_taxpay,	
	idsor_employpay,
	sortcode_employpay,
	sorting_employpay,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	taxsortingsetup.ayear,
	taxsortingsetup.idautotaxsor,
	taxsortingsetup.taxcode,
	tax.taxref,
	tax.description,
	taxsortingsetup.idser,
	service.codeser,
	service.description,
	taxsortingsetup.flaginherit,
	taxsortingsetup.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	taxsortingsetup.idsor_employproc,
	CM_employproc.sortcode,
	CM_employproc.description,
	taxsortingsetup.idsor_adminproc,
	CM_adminproc.sortcode,
	CM_adminproc.description,
	taxsortingsetup.idsor_adminpay,
	CM_adminpay.sortcode,
	CM_adminpay.description,
	taxsortingsetup.idsor_taxpay,
	CM_taxpay.sortcode,
	CM_taxpay.description,
	taxsortingsetup.idsor_employpay,
	CM_employpay.sortcode,
	CM_employpay.description,
	taxsortingsetup.cu,
	taxsortingsetup.ct,
	taxsortingsetup.lu,
	taxsortingsetup.lt
FROM taxsortingsetup
LEFT OUTER JOIN tax
	ON taxsortingsetup.taxcode = tax.taxcode
LEFT OUTER JOIN service
	ON taxsortingsetup.idser = service.idser
LEFT OUTER JOIN sortingkind
	ON taxsortingsetup.idsorkind = sortingkind.idsorkind
LEFT OUTER JOIN sorting CM_employproc
	ON taxsortingsetup.idsorkind = CM_employproc.idsorkind
	AND taxsortingsetup.idsor_employproc = CM_employproc.idsor
LEFT OUTER JOIN sorting CM_adminproc
	ON taxsortingsetup.idsorkind = CM_adminproc.idsorkind
	AND taxsortingsetup.idsor_adminproc = CM_adminproc.idsor
LEFT OUTER JOIN sorting CM_adminpay
	ON taxsortingsetup.idsorkind = CM_adminpay.idsorkind
	AND taxsortingsetup.idsor_adminpay = CM_adminpay.idsor
LEFT OUTER JOIN sorting CM_taxpay
	ON taxsortingsetup.idsorkind = CM_taxpay.idsorkind
	AND taxsortingsetup.idsor_taxpay = CM_taxpay.idsor
LEFT OUTER JOIN sorting CM_employpay
	ON taxsortingsetup.idsorkind = CM_employpay.idsorkind
	AND taxsortingsetup.idsor_employpay = CM_employpay.idsor

GO

 