
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


-- CREAZIONE VISTA assetloadkindview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetloadkindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetloadkindview]
GO



CREATE VIEW assetloadkindview 
(
	idassetloadkind,
	description,
	idinventory,
	inventory,
	startnumber,
	flag,
	flaglinear,
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
	assetloadkind.idassetloadkind,
	assetloadkind.description,
	assetloadkind.idinventory,
	inventory.description,
	assetloadkind.startnumber,
	assetloadkind.flag, 
	CASE
		WHEN assetloadkind.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetloadkind.idsor01,
	assetloadkind.idsor02,
	assetloadkind.idsor03,
	assetloadkind.idsor04,
	assetloadkind.idsor05,
	assetloadkind.cu,
	assetloadkind.ct,
	assetloadkind.lu,
	assetloadkind.lt
FROM assetloadkind
JOIN inventory
	ON inventory.idinventory = assetloadkind.idinventory






GO
