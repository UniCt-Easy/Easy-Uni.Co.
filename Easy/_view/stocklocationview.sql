
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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



-- CREAZIONE VISTA stocklocationview
IF EXISTS(select * from sysobjects where id = object_id(N'[stocklocationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stocklocationview]
GO


CREATE       VIEW [stocklocationview] 
(
	idstocklocation,
	stocklocationcode,
	nlevel,
	leveldescr,
	paridstocklocation,
	description,
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
	stocklocation.idstocklocation,
	stocklocation.stocklocationcode,
	stocklocation.nlevel,
	stocklocationlevel.description,
	stocklocation.paridstocklocation,
	stocklocation.description,
	stocklocation.active,
	stocklocation.idsor01,
	stocklocation.idsor02,
	stocklocation.idsor03,
	stocklocation.idsor04,
	stocklocation.idsor05,
	stocklocation.cu, 
	stocklocation.ct, 
	stocklocation.lu,
	stocklocation.lt 
FROM stocklocation
JOIN stocklocationlevel
	ON stocklocationlevel.nlevel = stocklocation.nlevel









GO
