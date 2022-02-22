
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


--[DBO]--
-- CREAZIONE VISTA dichiardisabil_seganagstuview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiardisabil_seganagstuview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiardisabil_seganagstuview]
GO

CREATE VIEW [dbo].[dichiardisabil_seganagstuview] AS SELECT  dichiar.aa, dichiar.ct AS dichiar_ct, dichiar.cu AS dichiar_cu, dichiar.date AS dichiar_date, dichiar.extension AS dichiar_extension, dichiar.iddichiar, dichiarkind.title AS dichiarkind_title, dichiar.iddichiarkind AS dichiar_iddichiarkind, dichiar.idreg, dichiar.lt AS dichiar_lt, dichiar.lu AS dichiar_lu, dichiar.protanno AS dichiar_protanno, dichiar.protnumero AS dichiar_protnumero, dichiar_disabil.ct AS dichiar_disabil_ct, dichiar_disabil.cu AS dichiar_disabil_cu, dichiar_disabil.iddichiar AS dichiar_disabil_iddichiar, dichiardisabilkind.title AS dichiardisabilkind_title, dichiar_disabil.iddichiardisabilkind AS dichiar_disabil_iddichiardisabilkind, dichiardisabilsuppkind.title AS dichiardisabilsuppkind_title, dichiar_disabil.iddichiardisabilsuppkind AS dichiar_disabil_iddichiardisabilsuppkind, dichiar_disabil.idreg AS dichiar_disabil_idreg, dichiar_disabil.lt AS dichiar_disabil_lt, dichiar_disabil.lu AS dichiar_disabil_lu, dichiar_disabil.percentuale AS dichiar_disabil_percentuale,CASE WHEN dichiar_disabil.permanente = 'S' THEN 'Si' WHEN dichiar_disabil.permanente = 'N' THEN 'No' END AS dichiar_disabil_permanente, dichiar_disabil.scadenza AS dichiar_disabil_scadenza FROM dichiar WITH (NOLOCK)  INNER JOIN dichiar_disabil WITH (NOLOCK) ON dichiar.iddichiar = dichiar_disabil.iddichiar AND dichiar.idreg = dichiar_disabil.idreg LEFT OUTER JOIN dichiarkind WITH (NOLOCK) ON dichiar.iddichiarkind = dichiarkind.iddichiarkind LEFT OUTER JOIN dichiardisabilkind WITH (NOLOCK) ON dichiar_disabil.iddichiardisabilkind = dichiardisabilkind.iddichiardisabilkind LEFT OUTER JOIN dichiardisabilsuppkind WITH (NOLOCK) ON dichiar_disabil.iddichiardisabilsuppkind = dichiardisabilsuppkind.iddichiardisabilsuppkind WHERE  dichiar.iddichiar IS NOT NULL  AND dichiar.idreg IS NOT NULL  AND dichiar_disabil.iddichiar IS NOT NULL  AND dichiar_disabil.idreg IS NOT NULL 
GO

-- VERIFICA DI dichiardisabil_seganagstuview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiardisabil_seganagstuview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','date','ASSISTENZA','dichiar_ct','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','varchar(64)','ASSISTENZA','dichiar_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','date','ASSISTENZA','dichiar_date','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','datetime','ASSISTENZA','dichiar_disabil_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','varchar(64)','ASSISTENZA','dichiar_disabil_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','int','ASSISTENZA','dichiar_disabil_iddichiar','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','int','ASSISTENZA','dichiar_disabil_iddichiardisabilkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','int','ASSISTENZA','dichiar_disabil_iddichiardisabilsuppkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','int','ASSISTENZA','dichiar_disabil_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','datetime','ASSISTENZA','dichiar_disabil_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','varchar(64)','ASSISTENZA','dichiar_disabil_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','float','ASSISTENZA','dichiar_disabil_percentuale','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','varchar(2)','ASSISTENZA','dichiar_disabil_permanente','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','date','ASSISTENZA','dichiar_disabil_scadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','varchar(200)','ASSISTENZA','dichiar_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','int','ASSISTENZA','dichiar_iddichiarkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','date','ASSISTENZA','dichiar_lt','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','varchar(64)','ASSISTENZA','dichiar_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','int','ASSISTENZA','dichiar_protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','int','ASSISTENZA','dichiar_protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','varchar(50)','ASSISTENZA','dichiardisabilkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','varchar(50)','ASSISTENZA','dichiardisabilsuppkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_seganagstuview','varchar(50)','ASSISTENZA','dichiarkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','int','ASSISTENZA','iddichiar','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_seganagstuview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiardisabil_seganagstuview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiardisabil_seganagstuview')
UPDATE customobject set isreal = 'N' where objectname = 'dichiardisabil_seganagstuview'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiardisabil_seganagstuview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

