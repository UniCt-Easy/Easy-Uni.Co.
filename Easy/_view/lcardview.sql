
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


-- CREAZIONE VISTA lcardview
IF EXISTS(select * from sysobjects where id = object_id(N'[lcardview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [lcardview]
GO



--clear_table_info'lcard'
create  VIEW [lcardview](
	idlcard,
	title,
	description,
	ystart,
	ystop,
	active,
	idman,
	manager,
	idstore,
	store,
	extcode,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	lt,
	lu
)
AS
SELECT
	lcard.idlcard,
	lcard.title,
	lcard.description,
	lcard.ystart,
	lcard.ystop,
	lcard.active,
	lcard.idman,
	manager.title,
	lcard.idstore,
	store.description,
	lcard.extcode,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05,
	lcard.lt,
	lcard.lu
FROM lcard
JOIN store
	ON lcard.idstore = store.idstore
JOIN manager
	ON lcard.idman = manager.idman

GO

