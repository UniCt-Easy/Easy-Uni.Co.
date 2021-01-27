
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


-- CREAZIONE VISTA managerview
IF EXISTS(select * from sysobjects where id = object_id(N'[managerview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [managerview]
GO


--clear_table_info managerview

CREATE VIEW managerview 
(
	idman,
	title,
	iddivision,
	codedivision,
	division,
	email,
	phonenumber,
	userweb,
	passwordweb,
	active,
	financeactive,
	wantswarn,
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
	manager.idman,
	manager.title,
	manager.iddivision,
	division.codedivision,
	division.description,
	manager.email,
	manager.phonenumber,
	manager.userweb,
	manager.passwordweb,
	manager.active,
	manager.financeactive,
	manager.wantswarn,
	manager.idsor01,
	manager.idsor02,
	manager.idsor03,
	manager.idsor04,
	manager.idsor05,
	manager.cu, 
	manager.ct, 
	manager.lu,
	manager.lt 
FROM manager
LEFT OUTER JOIN division
	ON manager.iddivision = division.iddivision

GO

