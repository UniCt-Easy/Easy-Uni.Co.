-- CREAZIONE VISTA provisiondetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[provisiondetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [provisiondetailview]
GO

 
-- select * from provisiondetailview
CREATE  VIEW provisiondetailview
(
	idprovision,
	rownum,
	detaildescription,
	amount,
	adate,
	description,
	idreg,
	registry,
	provisionadate,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	provisiondetail.idprovision,
	provisiondetail.rownum,
	provisiondetail.description,
	provisiondetail.amount,
	provisiondetail.adate,
	provision.description,
	provision.idreg,
	registry.title,
	provision.adate,
	provisiondetail.ct,
	provisiondetail.cu,
	provisiondetail.lt,
	provisiondetail.lu
FROM provisiondetail  
JOIN provision  
	ON provisiondetail.idprovision = provision.idprovision
LEFT OUTER JOIN registry
	ON provision.idreg = registry.idreg
GO
