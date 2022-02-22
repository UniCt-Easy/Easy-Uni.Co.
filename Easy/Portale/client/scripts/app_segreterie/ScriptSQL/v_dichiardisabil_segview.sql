
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
-- CREAZIONE VISTA dichiardisabil_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiardisabil_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiardisabil_segview]
GO

CREATE VIEW [dbo].[dichiardisabil_segview] AS SELECT  dichiar.aa, dichiar.ct AS dichiar_ct, dichiar.cu AS dichiar_cu, dichiar.date AS dichiar_date, dichiar.extension AS dichiar_extension, dichiar.iddichiar, dichiar.iddichiarkind AS dichiar_iddichiarkind, [dbo].registry.title AS registry_title, dichiar.idreg, dichiar.lt AS dichiar_lt, dichiar.lu AS dichiar_lu, dichiar.protanno AS dichiar_protanno, dichiar.protnumero AS dichiar_protnumero, dichiar_disabil.ct AS dichiar_disabil_ct, dichiar_disabil.cu AS dichiar_disabil_cu, dichiar_disabil.iddichiar AS dichiar_disabil_iddichiar, [dbo].dichiardisabilkind.title AS dichiardisabilkind_title, [dbo].dichiardisabilkind.specification AS dichiardisabilkind_specification, dichiar_disabil.iddichiardisabilkind AS dichiar_disabil_iddichiardisabilkind, [dbo].dichiardisabilsuppkind.title AS dichiardisabilsuppkind_title, dichiar_disabil.iddichiardisabilsuppkind AS dichiar_disabil_iddichiardisabilsuppkind, dichiar_disabil.idreg AS dichiar_disabil_idreg, dichiar_disabil.lt AS dichiar_disabil_lt, dichiar_disabil.lu AS dichiar_disabil_lu, dichiar_disabil.percentuale AS dichiar_disabil_percentuale,CASE WHEN dichiar_disabil.permanente = 'S' THEN 'Si' WHEN dichiar_disabil.permanente = 'N' THEN 'No' END AS dichiar_disabil_permanente, dichiar_disabil.scadenza AS dichiar_disabil_scadenza FROM [dbo].dichiar WITH (NOLOCK)  INNER JOIN dichiar_disabil WITH (NOLOCK) ON dichiar.iddichiar = dichiar_disabil.iddichiar AND dichiar.idreg = dichiar_disabil.idreg LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON dichiar.idreg = [dbo].registry.idreg LEFT OUTER JOIN [dbo].dichiardisabilkind WITH (NOLOCK) ON dichiar_disabil.iddichiardisabilkind = [dbo].dichiardisabilkind.iddichiardisabilkind LEFT OUTER JOIN [dbo].dichiardisabilsuppkind WITH (NOLOCK) ON dichiar_disabil.iddichiardisabilsuppkind = [dbo].dichiardisabilsuppkind.iddichiardisabilsuppkind WHERE  dichiar.iddichiar IS NOT NULL  AND dichiar.iddichiarkind = 4 AND dichiar.idreg IS NOT NULL  AND dichiar_disabil.iddichiar IS NOT NULL  AND dichiar_disabil.idreg IS NOT NULL 
GO

-- VERIFICA DI dichiardisabil_segview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiardisabil_segview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','datetime','ASSISTENZA','dichiar_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','varchar(64)','ASSISTENZA','dichiar_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','date','ASSISTENZA','dichiar_date','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','datetime','ASSISTENZA','dichiar_disabil_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','varchar(64)','ASSISTENZA','dichiar_disabil_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','int','ASSISTENZA','dichiar_disabil_iddichiar','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','int','ASSISTENZA','dichiar_disabil_iddichiardisabilkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','int','ASSISTENZA','dichiar_disabil_iddichiardisabilsuppkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','int','ASSISTENZA','dichiar_disabil_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','datetime','ASSISTENZA','dichiar_disabil_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','varchar(64)','ASSISTENZA','dichiar_disabil_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','float','ASSISTENZA','dichiar_disabil_percentuale','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','varchar(2)','ASSISTENZA','dichiar_disabil_permanente','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','date','ASSISTENZA','dichiar_disabil_scadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','varchar(200)','ASSISTENZA','dichiar_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','int','ASSISTENZA','dichiar_iddichiarkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','datetime','ASSISTENZA','dichiar_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','varchar(64)','ASSISTENZA','dichiar_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','int','ASSISTENZA','dichiar_protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','int','ASSISTENZA','dichiar_protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','varchar(50)','ASSISTENZA','dichiardisabilkind_specification','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','varchar(50)','ASSISTENZA','dichiardisabilkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','varchar(50)','ASSISTENZA','dichiardisabilsuppkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','int','ASSISTENZA','iddichiar','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiardisabil_segview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiardisabil_segview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiardisabil_segview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiardisabil_segview')
UPDATE customobject set isreal = 'N' where objectname = 'dichiardisabil_segview'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiardisabil_segview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

