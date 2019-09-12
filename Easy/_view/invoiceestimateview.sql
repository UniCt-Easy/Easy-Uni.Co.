-- CREAZIONE VISTA epexpview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoiceestimateview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoiceestimateview]
GO

--clear_table_info'invoiceestimateview'
--select * from invoiceestimateview
CREATE    VIEW [invoiceestimateview]
(
	idestimkind,yestim,nestim,
	idinvkind,yinv,ninv	
)
AS
SELECT distinct
	idestimkind,yestim,nestim,
	idinvkind,yinv,ninv
FROM invoicedetail 
	where idestimkind is not null


GO


 