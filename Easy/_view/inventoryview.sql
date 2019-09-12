-- CREAZIONE VISTA inventoryview
IF EXISTS(select * from sysobjects where id = object_id(N'[inventoryview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [inventoryview]
GO



CREATE VIEW inventoryview 
(
	idinventory,
	codeinventory,
	description,
	idinventoryagency,
	inventoryagency,
	idinventorykind,
	inventorykind,
	startnumber,
	flag,
	flagmixed,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	active,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	inventory.idinventory,
	inventory.codeinventory,
	inventory.description,
	inventory.idinventoryagency,
	inventoryagency.description,
	inventory.idinventorykind,
	inventorykind.description,
	inventory.startnumber,
	inventory.flag,
	CASE
		WHEN inventory.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	inventory.idsor01,
	inventory.idsor02,
	inventory.idsor03,
	inventory.idsor04,
	inventory.idsor05,
	inventory.active,
	inventory.cu,
	inventory.ct,
	inventory.lu,
	inventory.lt
FROM inventory
JOIN inventoryagency
	ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind
	ON inventorykind.idinventorykind = inventory.idinventorykind



GO


