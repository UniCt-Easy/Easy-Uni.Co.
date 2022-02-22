
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


-- CREAZIONE VISTA progettocostosegprgview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettocostosegprgview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettocostosegprgview]
GO

CREATE VIEW [progettocostosegprgview] AS 
SELECT  progettocosto.amount AS progettocosto_amount, progettocosto.ct AS progettocosto_ct, progettocosto.cu AS progettocosto_cu, progettocosto.doc AS progettocosto_doc, progettocosto.docdate AS progettocosto_docdate,
 [dbo].contrattokind.title AS contrattokind_title, progettocosto.idcontrattokind AS progettocosto_idcontrattokind,
 expense.description AS expense_description, expense.ymov AS expense_ymov, expense.nmov AS expense_nmov, progettocosto.idexp,
 pettycash.description AS pettycash_description, pettycash.pettycode AS pettycash_pettycode, progettocosto.idpettycash, progettocosto.idprogetto, progettocosto.idprogettocosto,
 progettotipocosto.title AS progettotipocosto_title, progettocosto.idprogettotipocosto AS progettocosto_idprogettotipocosto,
 entrydetail.description AS entrydetail_description, progettocosto.idrelated,
 rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, progettocosto.idrendicontattivitaprogetto,
 sal.start AS sal_start, sal.stop AS sal_stop, progettocosto.idsal AS progettocosto_idsal,
 workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, progettocosto.idworkpackage, progettocosto.lt AS progettocosto_lt, progettocosto.lu AS progettocosto_lu, progettocosto.noperation AS progettocosto_noperation, progettocosto.yoperation AS progettocosto_yoperation,
 isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Voce di costo: ' + progettotipocosto.title + '; ','') + ' ' + isnull('Importo: ' + CAST( progettocosto.amount AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM progettocosto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON progettocosto.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN expense WITH (NOLOCK) ON progettocosto.idexp = expense.idexp
LEFT OUTER JOIN pettycash WITH (NOLOCK) ON progettocosto.idpettycash = pettycash.idpettycash
LEFT OUTER JOIN progettotipocosto WITH (NOLOCK) ON progettocosto.idprogettotipocosto = progettotipocosto.idprogettotipocosto
LEFT OUTER JOIN entrydetail WITH (NOLOCK) ON progettocosto.idrelated = entrydetail.idrelated
LEFT OUTER JOIN rendicontattivitaprogetto WITH (NOLOCK) ON progettocosto.idrendicontattivitaprogetto = rendicontattivitaprogetto.idrendicontattivitaprogetto
LEFT OUTER JOIN sal WITH (NOLOCK) ON progettocosto.idsal = sal.idsal
LEFT OUTER JOIN workpackage WITH (NOLOCK) ON progettocosto.idworkpackage = workpackage.idworkpackage
WHERE  progettocosto.idprogetto IS NOT NULL  AND progettocosto.idprogettocosto IS NOT NULL 
GO

