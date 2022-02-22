
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
-- CREAZIONE VISTA progettoactivitykinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoactivitykinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettoactivitykinddefaultview]
GO

CREATE VIEW [dbo].[progettoactivitykinddefaultview] AS SELECT CASE WHEN progettoactivitykind.active = 'S' THEN 'Si' WHEN progettoactivitykind.active = 'N' THEN 'No' END AS progettoactivitykind_active, progettoactivitykind.ct AS progettoactivitykind_ct, progettoactivitykind.cu AS progettoactivitykind_cu, progettoactivitykind.description AS progettoactivitykind_description, progettoactivitykind.idprogettoactivitykind, progettoactivitykind.lt AS progettoactivitykind_lt, progettoactivitykind.lu AS progettoactivitykind_lu, progettoactivitykind.sortcode AS progettoactivitykind_sortcode, progettoactivitykind.title, isnull('Tipologia: ' + progettoactivitykind.title + '; ','') as dropdown_title FROM [dbo].progettoactivitykind WITH (NOLOCK)  WHERE  progettoactivitykind.idprogettoactivitykind IS NOT NULL 
GO

-- VERIFICA DI progettoactivitykinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettoactivitykinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoactivitykinddefaultview','nvarchar(2061)','ASSISTENZA','dropdown_title','2061','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoactivitykinddefaultview','int','ASSISTENZA','idprogettoactivitykind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoactivitykinddefaultview','varchar(2)','ASSISTENZA','progettoactivitykind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoactivitykinddefaultview','datetime','ASSISTENZA','progettoactivitykind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoactivitykinddefaultview','varchar(64)','ASSISTENZA','progettoactivitykind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoactivitykinddefaultview','nvarchar(max)','ASSISTENZA','progettoactivitykind_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoactivitykinddefaultview','datetime','ASSISTENZA','progettoactivitykind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoactivitykinddefaultview','varchar(64)','ASSISTENZA','progettoactivitykind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoactivitykinddefaultview','int','ASSISTENZA','progettoactivitykind_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoactivitykinddefaultview','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettoactivitykinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettoactivitykinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'progettoactivitykinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettoactivitykinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER progettoactivitykinddefaultview --
-- FINE GENERAZIONE SCRIPT --

