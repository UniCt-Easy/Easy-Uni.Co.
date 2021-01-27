
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


-- CREAZIONE VISTA locationview
IF EXISTS(select * from sysobjects where id = object_id(N'[locationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [locationview]
GO




CREATE VIEW locationview 
(
	idlocation,
	locationcode,
	newlocationcode,
	nlevel,
	leveldescr,
	paridlocation,
	description,
	idman,
	manager,
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
	location.idlocation,
	location.locationcode,
	location.newlocationcode,
	location.nlevel,
	locationlevel.description,
	location.paridlocation,
	location.description,
	location.idman,
	manager.title,
	location.active,
	location.idsor01,
	location.idsor02,
	location.idsor03,
	location.idsor04,
	location.idsor05,
	location.cu, 
	location.ct, 
	location.lu,
	location.lt 
FROM location
JOIN locationlevel
	ON locationlevel.nlevel = location.nlevel
LEFT OUTER JOIN manager
	ON manager.idman = location.idman









GO
