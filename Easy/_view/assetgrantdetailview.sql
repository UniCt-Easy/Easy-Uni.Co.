
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


-- CREAZIONE VISTA assetgrantdetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetgrantdetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetgrantdetailview]
GO
 
--setuser 'amministrazione'
--select * from assetgrantdetailview
--clear_table_info 'assetgrantdetailview'
CREATE     VIEW [assetgrantdetailview]
(
	idasset,
	idpiece,
	ninventory,
	idinventory,
	inventory,
	codeinventory,
	idinventoryagency,
	inventoryagencydescription,
	idgrant,
	grantdescription,
	iddetail,
	idgrantload,
	ct,
	cu,
	lt,
	lu,
	ydetail,
	amount,
	codeinv,
	codeinvdescription
	
)
AS SELECT
	asset.idasset,
	asset.idpiece,
	asset.ninventory,
	inventory.idinventory,
	inventory.description,
	inventory.codeinventory,
	inventory.idinventoryagency,
	inventoryagency.description,
	assetgrantdetail.idgrant,
	assetgrant.description,
	assetgrantdetail.iddetail,
	assetgrantdetail.idgrantload,
	assetgrantdetail.ct,
	assetgrantdetail.cu,
	assetgrantdetail.lt,
	assetgrantdetail.lu,
	assetgrantdetail.ydetail,
	assetgrantdetail.amount,
	inventorytree.codeinv,
	inventorytree.description
	

FROM assetgrantdetail
JOIN assetgrant				ON assetgrantdetail.idasset = assetgrant.idasset and assetgrantdetail.idgrant = assetgrant.idgrant and assetgrantdetail.idpiece = assetgrant.idpiece
JOIN asset					ON asset.idasset = assetgrant.idasset and assetgrant.idpiece=asset.idpiece 
JOIN assetacquire		 	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventorytree 			ON inventorytree.idinv = assetacquire.idinv
JOIN inventory 				ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryagency		ON inventory.idinventoryagency = inventoryagency.idinventoryagency

GO
