
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
-- CREAZIONE VISTA registryprogfinsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryprogfinsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryprogfinsegview]
GO

CREATE VIEW [dbo].[registryprogfinsegview] AS SELECT  registryprogfin.code AS registryprogfin_code, registryprogfin.ct AS registryprogfin_ct, registryprogfin.cu AS registryprogfin_cu, registryprogfin.description AS registryprogfin_description, registryprogfin.idreg, registryprogfin.idregistryprogfin, registryprogfin.lt AS registryprogfin_lt, registryprogfin.lu AS registryprogfin_lu, registryprogfin.title, isnull('Titolo: ' + registryprogfin.title + '; ','') + ' ' + isnull('Codice identificativo: ' + registryprogfin.code + '; ','') as dropdown_title FROM [dbo].registryprogfin WITH (NOLOCK)  WHERE  registryprogfin.idreg IS NOT NULL  AND registryprogfin.idregistryprogfin IS NOT NULL 
GO

-- VERIFICA DI registryprogfinsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryprogfinsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinsegview','nvarchar(4000)','ASSISTENZA','dropdown_title','4000','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinsegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinsegview','int','ASSISTENZA','idregistryprogfin','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryprogfinsegview','nvarchar(2048)','ASSISTENZA','registryprogfin_code','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinsegview','datetime','ASSISTENZA','registryprogfin_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinsegview','varchar(64)','ASSISTENZA','registryprogfin_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryprogfinsegview','nvarchar(max)','ASSISTENZA','registryprogfin_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinsegview','datetime','ASSISTENZA','registryprogfin_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinsegview','varchar(64)','ASSISTENZA','registryprogfin_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryprogfinsegview','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registryprogfinsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryprogfinsegview')
UPDATE customobject set isreal = 'N' where objectname = 'registryprogfinsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryprogfinsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

