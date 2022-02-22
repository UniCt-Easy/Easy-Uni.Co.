
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


-- CREAZIONE VISTA ec_showcasedetaillistview
IF EXISTS(select * from sysobjects where id = object_id(N'[ec_showcasedetaillistview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ec_showcasedetaillistview]
GO


CREATE VIEW [ec_showcasedetaillistview]
AS
SELECT unitprice, store.idstore, showcasedetail.idestimkind, showcasedetail.idupb, paymentexpiring, showcasedetail.idivakind, showcasedetail.idinvkind, unitprice * rate as tax, showcasedetail.idlist
FROM 			store
inner join 			showcase on store.idstore = showcase.idstore
inner join 			showcasedetail on showcase.idshowcase = showcasedetail.idshowcase
inner join 			ivakind on showcasedetail.idivakind = ivakind.idivakind

GO
-- FINE GENERAZIONE SCRIPT --

