-- CREAZIONE VISTA mandatelinked
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatelinked]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatelinked]
GO




-- setuser 'amm' 
-- select * from mandatelinked
-- clear_table_info 'mandatelinked'
CREATE                                 VIEW [mandatelinked]
(
	ayear,
	idmankind, yman, nman, mankind,
	idmandatestatus,mandatestatus,
	idreg, registry, registryreference, idman, 
	manager,	
	description, deliveryexpiration, deliveryaddress, paymentexpiring, 
	idexpirationkind, idcurrency, 	codecurrency, currency,
	exchangerate, doc, docdate, adate, officiallyprinted,
	isrequest,
	cu, ct, lu, lt,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	accountingyear.ayear,
	mandate.idmankind, mandate.yman, mandate.nman, mandatekind.description,
	mandate.idmandatestatus,mandatestatus.description,
	mandate.idreg, registry.title, mandate.registryreference, mandate.idman, 
	manager.title,
	mandate.description, deliveryexpiration,
	deliveryaddress, paymentexpiring, 
	idexpirationkind, mandate.idcurrency, currency.codecurrency,
	currency.description,
	mandate.exchangerate, mandate.doc, 
	mandate.docdate, adate, officiallyprinted,
	mandatekind.isrequest,
	mandate.cu, mandate.ct, mandate.lu, mandate.lt,
	mandate.idsor01,	mandate.idsor02,	mandate.idsor03,	mandate.idsor04,	mandate.idsor05
FROM mandate (NOLOCK)
JOIN mandatekind (NOLOCK)	ON mandatekind.idmankind = mandate.idmankind
LEFT OUTER JOIN registry (NOLOCK)		ON registry.idreg = mandate.idreg
LEFT OUTER JOIN currency (NOLOCK)		ON currency.idcurrency = mandate.idcurrency
LEFT OUTER JOIN manager (NOLOCK)		ON manager.idman = mandate.idman
LEFT OUTER JOIN mandatestatus (NOLOCK)	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
CROSS JOIN accountingyear (NOLOCK)	
WHERE EXISTS (SELECT * 
	        FROM expensemandate AS MM 
		JOIN expenseyear II
		  ON II.idexp=MM.idexp
		 AND MM.idmankind = mandate.idmankind
		 AND MM.yman=mandate.yman
		 AND MM.nman=mandate.nman
		 WHERE  II.ayear = accountingyear.ayear)			


GO
