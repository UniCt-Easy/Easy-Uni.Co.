-- CREAZIONE VISTA epexpview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicemandateview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicemandateview]
GO

--clear_table_info'invoicemandateview'
--select * from invoicemandateview
CREATE    VIEW [invoicemandateview]
(
	idmankind,yman,nman,
	idinvkind,yinv,ninv	
)
AS
SELECT distinct
	idmankind,yman,nman,
	idinvkind,yinv,ninv
FROM invoicedetail 
	where idmankind is not null


GO


 