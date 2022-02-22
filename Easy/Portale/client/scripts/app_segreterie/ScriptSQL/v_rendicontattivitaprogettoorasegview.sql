
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


-- CREAZIONE VISTA rendicontattivitaprogettoorasegview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoorasegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoorasegview]
GO

CREATE VIEW [rendicontattivitaprogettoorasegview] AS 
SELECT  rendicontattivitaprogettoora.ct AS rendicontattivitaprogettoora_ct, rendicontattivitaprogettoora.cu AS rendicontattivitaprogettoora_cu, rendicontattivitaprogettoora.data AS rendicontattivitaprogettoora_data, rendicontattivitaprogettoora.idrendicontattivitaprogetto, rendicontattivitaprogettoora.idrendicontattivitaprogettoora,
 sal.start AS sal_start, sal.stop AS sal_stop, rendicontattivitaprogettoora.idsal AS rendicontattivitaprogettoora_idsal, rendicontattivitaprogettoora.idworkpackage, rendicontattivitaprogettoora.lt AS rendicontattivitaprogettoora_lt, rendicontattivitaprogettoora.lu AS rendicontattivitaprogettoora_lu, rendicontattivitaprogettoora.ore AS rendicontattivitaprogettoora_ore,
 isnull('del ' + CONVERT(VARCHAR, rendicontattivitaprogettoora.data, 103),'') + ' ' + isnull('Numero di ore: ' + CAST( rendicontattivitaprogettoora.ore AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM rendicontattivitaprogettoora WITH (NOLOCK) 
LEFT OUTER JOIN sal WITH (NOLOCK) ON rendicontattivitaprogettoora.idsal = sal.idsal
WHERE  rendicontattivitaprogettoora.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogettoora.idrendicontattivitaprogettoora IS NOT NULL  AND rendicontattivitaprogettoora.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettoorasegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoorasegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegview','nvarchar(116)','ASSISTENZA','dropdown_title','116','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegview','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegview','int','ASSISTENZA','idrendicontattivitaprogettoora','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegview','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegview','datetime','ASSISTENZA','rendicontattivitaprogettoora_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegview','varchar(64)','ASSISTENZA','rendicontattivitaprogettoora_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoorasegview','date','ASSISTENZA','rendicontattivitaprogettoora_data','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoorasegview','int','','rendicontattivitaprogettoora_idsal','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegview','datetime','ASSISTENZA','rendicontattivitaprogettoora_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegview','varchar(64)','ASSISTENZA','rendicontattivitaprogettoora_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoorasegview','int','ASSISTENZA','rendicontattivitaprogettoora_ore','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoorasegview','date','ASSISTENZA','sal_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoorasegview','date','ASSISTENZA','sal_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettoorasegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoorasegview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoorasegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoorasegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

