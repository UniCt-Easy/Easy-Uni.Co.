
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
-- CREAZIONE VISTA dichiarsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiarsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiarsegview]
GO

CREATE VIEW [dbo].[dichiarsegview] AS SELECT  dichiar.aa, dichiar.ct AS dichiar_ct, dichiar.cu AS dichiar_cu, dichiar.date AS dichiar_date, dichiar.extension AS dichiar_extension, dichiar.iddichiar, [dbo].dichiarkind.title AS dichiarkind_title, dichiar.iddichiarkind, dichiar.idreg, dichiar.lt AS dichiar_lt, dichiar.lu AS dichiar_lu, dichiar.protanno AS dichiar_protanno, dichiar.protnumero AS dichiar_protnumero, isnull('Tipologia: ' + [dbo].dichiarkind.title + '; ','') + ' ' + isnull('Anno Accademico: ' + dichiar.aa + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, dichiar.date, 103),'') as dropdown_title FROM [dbo].dichiar WITH (NOLOCK)  LEFT OUTER JOIN [dbo].dichiarkind WITH (NOLOCK) ON dichiar.iddichiarkind = [dbo].dichiarkind.iddichiarkind WHERE  dichiar.iddichiar IS NOT NULL  AND dichiar.idreg IS NOT NULL 
GO

-- VERIFICA DI dichiarsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiarsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarsegview','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','datetime','ASSISTENZA','dichiar_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','varchar(64)','ASSISTENZA','dichiar_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','date','ASSISTENZA','dichiar_date','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarsegview','varchar(200)','ASSISTENZA','dichiar_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','datetime','ASSISTENZA','dichiar_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','varchar(64)','ASSISTENZA','dichiar_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarsegview','int','ASSISTENZA','dichiar_protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarsegview','int','ASSISTENZA','dichiar_protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarsegview','varchar(50)','ASSISTENZA','dichiarkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','varchar(127)','ASSISTENZA','dropdown_title','127','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','int','ASSISTENZA','iddichiar','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','int','ASSISTENZA','iddichiarkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiarsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiarsegview')
UPDATE customobject set isreal = 'N' where objectname = 'dichiarsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiarsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

