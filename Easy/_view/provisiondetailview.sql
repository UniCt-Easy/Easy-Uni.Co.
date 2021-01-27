
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


-- CREAZIONE VISTA provisiondetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[provisiondetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [provisiondetailview]
GO

 
-- select * from provisiondetailview
CREATE  VIEW provisiondetailview
(
	idprovision,
	rownum,
	detaildescription,
	amount,
	adate,
	description,
	idreg,
	registry,
	provisionadate,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	provisiondetail.idprovision,
	provisiondetail.rownum,
	provisiondetail.description,
	provisiondetail.amount,
	provisiondetail.adate,
	provision.description,
	provision.idreg,
	registry.title,
	provision.adate,
	provisiondetail.ct,
	provisiondetail.cu,
	provisiondetail.lt,
	provisiondetail.lu
FROM provisiondetail  
JOIN provision  
	ON provisiondetail.idprovision = provision.idprovision
LEFT OUTER JOIN registry
	ON provision.idreg = registry.idreg
GO
