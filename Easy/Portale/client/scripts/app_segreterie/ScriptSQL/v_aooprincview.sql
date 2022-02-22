
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
-- CREAZIONE VISTA aooprincview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[aooprincview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[aooprincview]
GO

CREATE VIEW [dbo].[aooprincview] AS SELECT  aoo.codiceaooipa AS aoo_codiceaooipa, aoo.ct AS aoo_ct, aoo.cu AS aoo_cu, aoo.idaoo, aoo.idreg AS aoo_idreg, [dbo].sede.title AS sede_title, aoo.idsede, aoo.lt AS aoo_lt, aoo.lu AS aoo_lu, aoo.title, isnull('Denominazione: ' + aoo.title + '; ','') as dropdown_title FROM [dbo].aoo WITH (NOLOCK)  LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON aoo.idsede = [dbo].sede.idsede WHERE  aoo.idaoo IS NOT NULL 
GO

-- VERIFICA DI aooprincview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'aooprincview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','aooprincview','varchar(50)','ASSISTENZA','aoo_codiceaooipa','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aooprincview','datetime','ASSISTENZA','aoo_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aooprincview','varchar(64)','ASSISTENZA','aoo_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','aooprincview','int','ASSISTENZA','aoo_idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aooprincview','datetime','ASSISTENZA','aoo_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aooprincview','varchar(64)','ASSISTENZA','aoo_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aooprincview','varchar(1041)','ASSISTENZA','dropdown_title','1041','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aooprincview','int','ASSISTENZA','idaoo','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','aooprincview','int','ASSISTENZA','idsede','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','aooprincview','nvarchar(1024)','ASSISTENZA','sede_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aooprincview','varchar(1024)','ASSISTENZA','title','1024','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI aooprincview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'aooprincview')
UPDATE customobject set isreal = 'N' where objectname = 'aooprincview'
ELSE
INSERT INTO customobject (objectname, isreal) values('aooprincview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

