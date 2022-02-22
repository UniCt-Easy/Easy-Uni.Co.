
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


