-- CREAZIONE VISTA [inventorysortingamortizationyearview]
IF EXISTS(select * from sysobjects where id = object_id(N'[inventorysortingamortizationyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW  [inventorysortingamortizationyearview]
GO

-- select * from inventorysortingamortizationyearview
CREATE  VIEW inventorysortingamortizationyearview
(
	ayear,
	idinv,
	codeinv,
	nlevel,
	leveldescr,
	paridinv,
	description, 
	idinv_lev1,
	codeinv_lev1,
	inventorytree_lev1,
	lookupcode,
	idinventoryamortization,
	inventoryamortization,
	codeinventoryamortization,
	official,
	ammort_sval,
	age,
	agemax,
	active,
	valuemin,
	valuemax,
	amortizationquota,
	idaccmotive,
	codemotive,
	motive,
	idaccmotiveunload,
	codemotiveunload,
	motiveunload,
	cu, ct, lu, lt
)
AS SELECT 
	inventorysortingamortizationyear.ayear,
	inventorytree.idinv,
	inventorytree.codeinv,
	inventorytree.nlevel,
	inventorysortinglevel.description, 
	inventorytree.paridinv,
	inventorytree.description, 
	i1.idinv,
	i1.codeinv,
	i1.description,
	inventorytree.lookupcode,
	inventorysortingamortizationyear.idinventoryamortization,
	inventoryamortization.description,
	inventoryamortization.codeinventoryamortization,
	CASE
		WHEN (inventoryamortization.flag&2) <> 0  THEN 'S'
		ELSE 'N'
	END,
	CASE
		WHEN  (inventoryamortization.flag&3) <> 0 THEN 'A'
		ELSE 'S'
	END,
	inventoryamortization.age,
	inventoryamortization.agemax,
	inventoryamortization.active,
	inventoryamortization.valuemin,
	inventoryamortization.valuemax,
	inventorysortingamortizationyear.amortizationquota,
	inventorysortingamortizationyear.idaccmotive,
	accmotive.codemotive,
	accmotive.title,
	inventorysortingamortizationyear.idaccmotiveunload,
	accmotiveunload.codemotive,
	accmotiveunload.title,
	inventorysortingamortizationyear.cu,inventorysortingamortizationyear.ct,
	inventorysortingamortizationyear.lu, inventorysortingamortizationyear.lt
FROM inventorysortingamortizationyear 
JOIN inventorytree
	ON inventorytree.idinv = inventorysortingamortizationyear.idinv
JOIN inventorysortinglevel
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
JOIN inventorytreelink ilk
	ON  ilk.idchild=inventorytree.idinv
	AND ilk.nlevel=1
JOIN inventorytree i1
	ON ilk.idparent= i1.idinv
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = inventorysortingamortizationyear.idinventoryamortization
LEFT OUTER JOIN accmotive
	ON accmotive.idaccmotive = inventorysortingamortizationyear.idaccmotive
LEFT OUTER JOIN accmotive as accmotiveunload
	ON accmotiveunload.idaccmotive  = inventorysortingamortizationyear.idaccmotiveunload

GO
