
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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
