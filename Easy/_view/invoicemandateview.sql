
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicemandateview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicemandateview]
GO

--clear_table_info'invoicemandateview'
--select * from invoicemandateview
CREATE    VIEW [invoicemandateview]
(
	idmankind,yman,nman,
	idinvkind,yinv,ninv	
)
AS
SELECT distinct
	idmankind,yman,nman,
	idinvkind,yinv,ninv
FROM invoicedetail 
	where idmankind is not null


GO


 
