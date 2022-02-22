
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


-- CREAZIONE VISTA rendicontattivitaprogettoorasegsalview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoorasegsalview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoorasegsalview]
GO

CREATE VIEW [rendicontattivitaprogettoorasegsalview] AS SELECT  rendicontattivitaprogettoora.ct AS rendicontattivitaprogettoora_ct, rendicontattivitaprogettoora.cu AS rendicontattivitaprogettoora_cu, rendicontattivitaprogettoora.data AS rendicontattivitaprogettoora_data, rendicontattivitaprogettoora.idrendicontattivitaprogetto, rendicontattivitaprogettoora.idrendicontattivitaprogettoora, sal.start AS sal_start, sal.stop AS sal_stop, rendicontattivitaprogettoora.idsal AS rendicontattivitaprogettoora_idsal, rendicontattivitaprogettoora.idworkpackage, rendicontattivitaprogettoora.lt AS rendicontattivitaprogettoora_lt, rendicontattivitaprogettoora.lu AS rendicontattivitaprogettoora_lu, rendicontattivitaprogettoora.ore AS rendicontattivitaprogettoora_ore, isnull('del ' + CONVERT(VARCHAR, rendicontattivitaprogettoora.data, 103),'') + ' ' + isnull('Numero di ore: ' + CAST( rendicontattivitaprogettoora.ore AS NVARCHAR(64)) + '; ','') as dropdown_title FROM rendicontattivitaprogettoora WITH (NOLOCK)  LEFT OUTER JOIN sal WITH (NOLOCK) ON rendicontattivitaprogettoora.idsal = sal.idsal WHERE  rendicontattivitaprogettoora.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogettoora.idrendicontattivitaprogettoora IS NOT NULL  AND rendicontattivitaprogettoora.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettoorasegsalview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoorasegsalview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegsalview','nvarchar(116)','ASSISTENZA','dropdown_title','116','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegsalview','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegsalview','int','ASSISTENZA','idrendicontattivitaprogettoora','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegsalview','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegsalview','datetime','ASSISTENZA','rendicontattivitaprogettoora_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegsalview','varchar(64)','ASSISTENZA','rendicontattivitaprogettoora_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoorasegsalview','date','ASSISTENZA','rendicontattivitaprogettoora_data','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoorasegsalview','int','ASSISTENZA','rendicontattivitaprogettoora_idsal','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegsalview','datetime','ASSISTENZA','rendicontattivitaprogettoora_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoorasegsalview','varchar(64)','ASSISTENZA','rendicontattivitaprogettoora_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoorasegsalview','int','ASSISTENZA','rendicontattivitaprogettoora_ore','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoorasegsalview','date','ASSISTENZA','sal_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoorasegsalview','date','ASSISTENZA','sal_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettoorasegsalview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoorasegsalview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoorasegsalview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoorasegsalview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

