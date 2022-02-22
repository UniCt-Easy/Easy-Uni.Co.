
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


-- CREAZIONE VISTA progettocostosegsalview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettocostosegsalview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettocostosegsalview]
GO

CREATE VIEW [progettocostosegsalview] AS 
SELECT  progettocosto.amount AS progettocosto_amount, progettocosto.ct AS progettocosto_ct, progettocosto.cu AS progettocosto_cu, progettocosto.doc AS progettocosto_doc, progettocosto.docdate AS progettocosto_docdate,
 [dbo].contrattokind.title AS contrattokind_title, progettocosto.idcontrattokind AS progettocosto_idcontrattokind,
 expense.description AS expense_description, expense.ymov AS expense_ymov, expense.nmov AS expense_nmov, progettocosto.idexp,
 pettycash.description AS pettycash_description, pettycash.pettycode AS pettycash_pettycode, progettocosto.idpettycash, progettocosto.idprogetto, progettocosto.idprogettocosto,
 progettotipocosto.title AS progettotipocosto_title, progettocosto.idprogettotipocosto,
 entrydetail.description AS entrydetail_description, progettocosto.idrelated,
 rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, progettocosto.idrendicontattivitaprogetto,
 sal.start AS sal_start, sal.stop AS sal_stop, progettocosto.idsal AS progettocosto_idsal,
 workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, progettocosto.idworkpackage, progettocosto.lt AS progettocosto_lt, progettocosto.lu AS progettocosto_lu, progettocosto.noperation AS progettocosto_noperation, progettocosto.yoperation AS progettocosto_yoperation,
 isnull('Voce di costo: ' + progettotipocosto.title + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') as dropdown_title
FROM progettocosto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON progettocosto.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN expense WITH (NOLOCK) ON progettocosto.idexp = expense.idexp
LEFT OUTER JOIN pettycash WITH (NOLOCK) ON progettocosto.idpettycash = pettycash.idpettycash
LEFT OUTER JOIN progettotipocosto WITH (NOLOCK) ON progettocosto.idprogettotipocosto = progettotipocosto.idprogettotipocosto
LEFT OUTER JOIN entrydetail WITH (NOLOCK) ON progettocosto.idrelated = entrydetail.idrelated
LEFT OUTER JOIN rendicontattivitaprogetto WITH (NOLOCK) ON progettocosto.idrendicontattivitaprogetto = rendicontattivitaprogetto.idrendicontattivitaprogetto
LEFT OUTER JOIN sal WITH (NOLOCK) ON progettocosto.idsal = sal.idsal
LEFT OUTER JOIN workpackage WITH (NOLOCK) ON progettocosto.idworkpackage = workpackage.idworkpackage
WHERE  progettocosto.idprogetto IS NOT NULL  AND progettocosto.idprogettocosto IS NOT NULL  AND progettocosto.idprogettotipocosto IS NOT NULL  AND progettocosto.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI progettocostosegsalview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettocostosegsalview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocostosegsalview','nvarchar(4000)','ASSISTENZA','dropdown_title','4000','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','varchar(400)','ASSISTENZA','entrydetail_description','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','varchar(150)','ASSISTENZA','expense_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','int','ASSISTENZA','expense_nmov','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','smallint','ASSISTENZA','expense_ymov','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','int','ASSISTENZA','idexp','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','int','ASSISTENZA','idpettycash','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocostosegsalview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocostosegsalview','int','ASSISTENZA','idprogettocosto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','int','ASSISTENZA','idprogettotipocosto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','varchar(50)','ASSISTENZA','idrelated','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','int','ASSISTENZA','idrendicontattivitaprogetto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','int','ASSISTENZA','idworkpackage','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','varchar(50)','ASSISTENZA','pettycash_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','varchar(20)','ASSISTENZA','pettycash_pettycode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','decimal(9,2)','ASSISTENZA','progettocosto_amount','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocostosegsalview','datetime','ASSISTENZA','progettocosto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocostosegsalview','varchar(64)','ASSISTENZA','progettocosto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','varchar(35)','ASSISTENZA','progettocosto_doc','35','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','date','ASSISTENZA','progettocosto_docdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','int','ASSISTENZA','progettocosto_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','int','ASSISTENZA','progettocosto_idsal','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocostosegsalview','datetime','ASSISTENZA','progettocosto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocostosegsalview','varchar(64)','ASSISTENZA','progettocosto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','int','ASSISTENZA','progettocosto_noperation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','smallint','ASSISTENZA','progettocosto_yoperation','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','varchar(2048)','ASSISTENZA','progettotipocosto_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','varchar(max)','ASSISTENZA','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','date','ASSISTENZA','sal_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','date','ASSISTENZA','sal_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','nvarchar(2048)','ASSISTENZA','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocostosegsalview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettocostosegsalview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettocostosegsalview')
UPDATE customobject set isreal = 'N' where objectname = 'progettocostosegsalview'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettocostosegsalview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

