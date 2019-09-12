-- CREAZIONE VISTA inventorytreeview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inventorytreeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[inventorytreeview]
GO
 
CREATE  VIEW [DBO].inventorytreeview
(
	idinv,
	codeinv,
	nlevel,
	leveldescr,
	paridinv,
	description, 
	idinv_lev1,
	codeinv_lev1,
	lookupcode,
	idaccmotiveunload,
	codemotiveunload,
	motiveunload,
	idaccmotiveload,
	codemotiveload,
	motiveload,
	cu, ct, lu, lt
)
AS SELECT 
	inventorytree.idinv,
	inventorytree.codeinv,
	inventorytree.nlevel,
	inventorysortinglevel.description, 
	inventorytree.paridinv,
	inventorytree.description, 
	i1.idinv,
	i1.codeinv,
	inventorytree.lookupcode,
	inventorytree.idaccmotiveunload,
	accmotiveunload.codemotive,
	accmotiveunload.title,
	inventorytree.idaccmotiveload,
	accmotiveload.codemotive,
	accmotiveload.title,
	inventorytree.cu,inventorytree.ct, inventorytree.lu, inventorytree.lt
FROM inventorytree
JOIN inventorysortinglevel
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
JOIN inventorytreelink ilk
	ON  ilk.idchild=inventorytree.idinv
	AND ilk.nlevel=1
JOIN inventorytree i1
	ON ilk.idparent= i1.idinv
LEFT OUTER JOIN accmotive accmotiveunload
	ON accmotiveunload.idaccmotive = inventorytree.idaccmotiveunload
LEFT OUTER JOIN accmotive accmotiveload
	ON accmotiveload.idaccmotive = inventorytree.idaccmotiveload



GO

 