
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


-- CREAZIONE VISTA epexpview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoiceestimateview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoiceestimateview]
GO

--clear_table_info'invoiceestimateview'
--select * from invoiceestimateview
CREATE    VIEW [invoiceestimateview]
(
	idestimkind,yestim,nestim,
	idinvkind,yinv,ninv	
)
AS
SELECT distinct
	idestimkind,yestim,nestim,
	idinvkind,yinv,ninv
FROM invoicedetail 
	where idestimkind is not null


GO


 
