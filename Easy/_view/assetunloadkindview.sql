
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


-- CREAZIONE VISTA assetunloadkindview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetunloadkindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetunloadkindview]
GO




CREATE VIEW assetunloadkindview 
(
	idassetunloadkind,
	description,
	idinventory,
	inventory,
	startnumber,
	flag,
	flaglinear,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	assetunloadkind.idassetunloadkind,
	assetunloadkind.description,
	assetunloadkind.idinventory,
	inventory.description,
 	assetunloadkind.startnumber,
	assetunloadkind.flag,
	CASE
		WHEN assetunloadkind.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetunloadkind.active,
	assetunloadkind.idsor01,
	assetunloadkind.idsor02,
	assetunloadkind.idsor03,
	assetunloadkind.idsor04,
	assetunloadkind.idsor05,
	assetunloadkind.cu,
	assetunloadkind.ct,
	assetunloadkind.lu,
	assetunloadkind.lt
FROM assetunloadkind
JOIN inventory
	ON inventory.idinventory = assetunloadkind.idinventory

GO
