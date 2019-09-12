-- CREAZIONE VISTA electronicinvoiceview
IF EXISTS(select * from sysobjects where id = object_id(N'[electronicinvoiceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [electronicinvoiceview]
GO

-- select * from  [electronicinvoiceview]
CREATE VIEW [electronicinvoiceview]
AS
SELECT  
	electronicinvoice.nelectronicinvoice,
	electronicinvoice.yelectronicinvoice,
	electronicinvoice.idtreasurer,
	treasurer.departmentname_fe,
	registry.idreg,
	registry.title as registry,
	electronicinvoice.idsor01,
	electronicinvoice.idsor02,
	electronicinvoice.idsor03,
	electronicinvoice.idsor04,
	electronicinvoice.idsor05,
	electronicinvoice.ipa_ven_emittente,
	electronicinvoice.rifamm_ven_emittente,
	electronicinvoice.ipa_ven_cliente,
	electronicinvoice.rifamm_ven_cliente,
	electronicinvoice.email_ven_cliente,
	electronicinvoice.pec_ven_cliente
FROM electronicinvoice 
LEFT OUTER JOIN registry 
	ON electronicinvoice.idreg = registry.idreg
LEFT OUTER JOIN treasurer
	ON electronicinvoice.idtreasurer = treasurer.idtreasurer



	

GO
