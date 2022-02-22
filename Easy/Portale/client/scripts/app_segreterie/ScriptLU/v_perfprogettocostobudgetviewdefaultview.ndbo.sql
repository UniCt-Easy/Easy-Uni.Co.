
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


-- CREAZIONE VISTA perfprogettocostobudgetviewdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[perfprogettocostobudgetviewdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [perfprogettocostobudgetviewdefaultview]
GO

CREATE VIEW [perfprogettocostobudgetviewdefaultview] AS 
SELECT  perfprogettocostobudgetview.amount AS perfprogettocostobudgetview_amount, perfprogettocostobudgetview.amount2 AS perfprogettocostobudgetview_amount2, perfprogettocostobudgetview.amount3 AS perfprogettocostobudgetview_amount3, perfprogettocostobudgetview.amount4 AS perfprogettocostobudgetview_amount4, perfprogettocostobudgetview.amount5 AS perfprogettocostobudgetview_amount5, perfprogettocostobudgetview.annotation AS perfprogettocostobudgetview_annotation, perfprogettocostobudgetview.ct AS perfprogettocostobudgetview_ct, perfprogettocostobudgetview.cu AS perfprogettocostobudgetview_cu, perfprogettocostobudgetview.description, perfprogettocostobudgetview.idacc AS perfprogettocostobudgetview_idacc, perfprogettocostobudgetview.idaccmotive AS perfprogettocostobudgetview_idaccmotive, perfprogettocostobudgetview.idcostpartition AS perfprogettocostobudgetview_idcostpartition, perfprogettocostobudgetview.idinv AS perfprogettocostobudgetview_idinv, perfprogettocostobudgetview.idsor1 AS perfprogettocostobudgetview_idsor1, perfprogettocostobudgetview.idsor2 AS perfprogettocostobudgetview_idsor2, perfprogettocostobudgetview.idsor3 AS perfprogettocostobudgetview_idsor3, perfprogettocostobudgetview.idupb AS perfprogettocostobudgetview_idupb, perfprogettocostobudgetview.lt AS perfprogettocostobudgetview_lt, perfprogettocostobudgetview.lu AS perfprogettocostobudgetview_lu, perfprogettocostobudgetview.nvar, perfprogettocostobudgetview.prevcassa AS perfprogettocostobudgetview_prevcassa, perfprogettocostobudgetview.rownum,CASE WHEN perfprogettocostobudgetview.underwritingkind = 'S' THEN 'Si' WHEN perfprogettocostobudgetview.underwritingkind = 'N' THEN 'No' END AS perfprogettocostobudgetview_underwritingkind, perfprogettocostobudgetview.underwritingkind_desc AS perfprogettocostobudgetview_underwritingkind_desc, perfprogettocostobudgetview.yvar,
 isnull('Descrizione: ' + perfprogettocostobudgetview.description + '; ','') + ' ' + isnull('Annotazioni: ' + perfprogettocostobudgetview.annotation + '; ','') as dropdown_title
FROM perfprogettocostobudgetview WITH (NOLOCK) 
WHERE  perfprogettocostobudgetview.nvar IS NOT NULL  AND perfprogettocostobudgetview.rownum IS NOT NULL  AND perfprogettocostobudgetview.yvar IS NOT NULL 
GO

