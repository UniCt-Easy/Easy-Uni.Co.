-- CREAZIONE VISTA taxview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxview]
GO



CREATE   VIEW taxview 
(
	taxcode,
	taxref,
	active,
	appliancebasis,
	description,
	fiscaltaxcode,
	fiscaltaxcodecredit,
	flagunabatable,
	geoappliance,
	idaccmotive_cost,
	idaccmotive_debit,
	idaccmotive_pay,
	taxablecode,
	taxkind,
	maintaxcode,
	maintaxref,
	maintaxdescription,
	insuranceagencycode,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	tax.taxcode,
	tax.taxref,
	tax.active,
	tax.appliancebasis,
	tax.description,
	tax.fiscaltaxcode,
	tax.fiscaltaxcodecredit,
	tax.flagunabatable,
	tax.geoappliance,
	tax.idaccmotive_cost,
	tax.idaccmotive_debit,
	tax.idaccmotive_pay,
	tax.taxablecode,
	tax.taxkind,
	tax.maintaxcode,
	ISNULL(maintax.taxref,tax.taxref),
	ISNULL(maintax.description,tax.description),
	tax.insuranceagencycode,
	tax.ct,
	tax.cu,
	tax.lt,
	tax.lu
FROM tax
LEFT OUTER JOIN tax maintax
ON tax.maintaxcode = maintax.taxcode

GO 