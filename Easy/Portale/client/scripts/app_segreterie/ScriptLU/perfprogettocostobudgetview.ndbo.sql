
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


-- CREAZIONE VISTA perfprogettocostobudgetview
IF EXISTS(select * from sysobjects where id = object_id(N'[perfprogettocostobudgetview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [perfprogettocostobudgetview]
GO


CREATE VIEW [perfprogettocostobudgetview]
AS
SELECT        nvar, yvar, rownum, amount, amount2, amount3, amount4, amount5, annotation,  accountvardetailview.ct,  accountvardetailview.cu, accountvardetailview.description,  accountvardetailview.idacc, idaccmotive, idupb,  accountvardetailview.lt,  accountvardetailview.lu, idsor1, idsor2, idsor3, idcostpartition, underwritingkind, prevcassa, idinv,  underwritingkind_desc
FROM            accountvardetailview 
INNER JOIN accmotivedetail ON  accountvardetailview.idacc = accmotivedetail.idacc



GO

