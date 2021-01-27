
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


-- CREAZIONE VISTA webpaymentview
IF EXISTS(select * from sysobjects where id = object_id(N'[webpaymentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [webpaymentview]
GO



-- clear_table_info'webpaymentview'
-- select * from webpaymentview
-- sp_help webpaymentview

CREATE  VIEW [webpaymentview] as
(
	select P.idwebpayment as idwebpayment,
		   P.ywebpayment as ywebpayment,
		   P.nwebpayment as nwebpayment,
		   R.idreg,
		   R.forename as forename,
		   R.surname  as surname,
		   R.cf as cf,
		   P.idcustomuser as idcustomuser,
		   P.idwebpaymentstatus,
		   PS.description as webpaymentstatus,
		   P.adate 
	from webpayment P
	join registry R
		on P.idreg = R.idreg
	join webpaymentstatus PS
		on P.idwebpaymentstatus = PS.idwebpaymentstatus

)


GO
