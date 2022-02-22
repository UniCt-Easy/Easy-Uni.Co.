
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
-- CREAZIONE VISTA dichiaraltrititoli_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiaraltrititoli_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiaraltrititoli_segview]
GO

CREATE VIEW [dbo].[dichiaraltrititoli_segview] AS SELECT  dichiar.aa, dichiar.ct AS dichiar_ct, dichiar.cu AS dichiar_cu, dichiar.date AS dichiar_date, dichiar.extension AS dichiar_extension, dichiar.iddichiar, dichiar.iddichiarkind AS dichiar_iddichiarkind, [dbo].registry.title AS registry_title, dichiar.idreg, dichiar.lt AS dichiar_lt, dichiar.lu AS dichiar_lu, dichiar.protanno AS dichiar_protanno, dichiar.protnumero AS dichiar_protnumero, dichiar_altrititoli.ct AS dichiar_altrititoli_ct, dichiar_altrititoli.cu AS dichiar_altrititoli_cu, dichiar_altrititoli.dataottenimento AS dichiar_altrititoli_dataottenimento, dichiar_altrititoli.iddichiar AS dichiar_altrititoli_iddichiar, dichiar_altrititoli.idreg AS dichiar_altrititoli_idreg, dichiar_altrititoli.lt AS dichiar_altrititoli_lt, dichiar_altrititoli.lu AS dichiar_altrititoli_lu, dichiar_altrititoli.rilasciatoda AS dichiar_altrititoli_rilasciatoda, dichiar_altrititoli.title AS dichiar_altrititoli_title, isnull('Titolo: ' + dichiar_altrititoli.title + '; ','') as dropdown_title FROM [dbo].dichiar WITH (NOLOCK)  INNER JOIN dichiar_altrititoli WITH (NOLOCK) ON dichiar.iddichiar = dichiar_altrititoli.iddichiar AND dichiar.idreg = dichiar_altrititoli.idreg LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON dichiar.idreg = [dbo].registry.idreg WHERE  dichiar.iddichiar IS NOT NULL  AND dichiar.iddichiarkind = 2 AND dichiar.idreg IS NOT NULL  AND dichiar_altrititoli.iddichiar IS NOT NULL  AND dichiar_altrititoli.idreg IS NOT NULL 
GO

-- VERIFICA DI dichiaraltrititoli_segview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiaraltrititoli_segview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiaraltrititoli_segview','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','datetime','ASSISTENZA','dichiar_altrititoli_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','varchar(64)','ASSISTENZA','dichiar_altrititoli_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiaraltrititoli_segview','date','ASSISTENZA','dichiar_altrititoli_dataottenimento','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','int','ASSISTENZA','dichiar_altrititoli_iddichiar','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','int','ASSISTENZA','dichiar_altrititoli_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','datetime','ASSISTENZA','dichiar_altrititoli_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','varchar(64)','ASSISTENZA','dichiar_altrititoli_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiaraltrititoli_segview','varchar(1024)','ASSISTENZA','dichiar_altrititoli_rilasciatoda','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiaraltrititoli_segview','varchar(1024)','ASSISTENZA','dichiar_altrititoli_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','datetime','ASSISTENZA','dichiar_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','varchar(64)','ASSISTENZA','dichiar_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','date','ASSISTENZA','dichiar_date','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiaraltrititoli_segview','varchar(200)','ASSISTENZA','dichiar_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','int','ASSISTENZA','dichiar_iddichiarkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','datetime','ASSISTENZA','dichiar_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','varchar(64)','ASSISTENZA','dichiar_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiaraltrititoli_segview','int','ASSISTENZA','dichiar_protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiaraltrititoli_segview','int','ASSISTENZA','dichiar_protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','varchar(1034)','ASSISTENZA','dropdown_title','1034','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','int','ASSISTENZA','iddichiar','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrititoli_segview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiaraltrititoli_segview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiaraltrititoli_segview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiaraltrititoli_segview')
UPDATE customobject set isreal = 'N' where objectname = 'dichiaraltrititoli_segview'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiaraltrititoli_segview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

