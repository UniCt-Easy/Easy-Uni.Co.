
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


-- CREAZIONE VISTA ec_productview
IF EXISTS(select * from sysobjects where id = object_id(N'[ec_productview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ec_productview]
GO


CREATE VIEW [ec_productview]
AS
select s.idstore, scd.idshowcase, scd.idlist, scd.title, scd.unitprice, scd.idivakind, ik.rate, l.insinfo, paymentexpiring, l.descrforuser,
scd.idupb, scd.idestimkind, competencystart, competencystop, Idinvkind, idupb_iva, idsor1, idsor2, idsor3
from showcasedetail scd
inner join showcase sc on scd.idshowcase = sc.idshowcase
inner join store s on sc.idstore = s.idstore
inner join ivakind ik on scd.idivakind = ik.idivakind
inner join list l on scd.idlist = l.idlist
where s.virtual = 'S'

GO
-- FINE GENERAZIONE SCRIPT --
