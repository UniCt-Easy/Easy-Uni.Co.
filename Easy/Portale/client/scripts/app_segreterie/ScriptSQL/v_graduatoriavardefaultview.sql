
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
-- CREAZIONE VISTA graduatoriavardefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[graduatoriavardefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[graduatoriavardefaultview]
GO

CREATE VIEW [dbo].[graduatoriavardefaultview] AS SELECT CASE WHEN graduatoriavar.active = 'S' THEN 'Si' WHEN graduatoriavar.active = 'N' THEN 'No' END AS graduatoriavar_active, graduatoriavar.ct AS graduatoriavar_ct, graduatoriavar.cu AS graduatoriavar_cu, graduatoriavar.description AS graduatoriavar_description, graduatoriavar.idgraduatoriavar, graduatoriavar.lt AS graduatoriavar_lt, graduatoriavar.lu AS graduatoriavar_lu, graduatoriavar.sortcode AS graduatoriavar_sortcode, graduatoriavar.title, isnull('Titolo: ' + graduatoriavar.title + '; ','') as dropdown_title FROM [dbo].graduatoriavar WITH (NOLOCK)  WHERE  graduatoriavar.idgraduatoriavar IS NOT NULL 
GO

-- VERIFICA DI graduatoriavardefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'graduatoriavardefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavardefaultview','varchar(60)','ASSISTENZA','dropdown_title','60','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriavardefaultview','varchar(2)','ASSISTENZA','graduatoriavar_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavardefaultview','datetime','ASSISTENZA','graduatoriavar_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavardefaultview','varchar(64)','ASSISTENZA','graduatoriavar_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriavardefaultview','varchar(256)','ASSISTENZA','graduatoriavar_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavardefaultview','datetime','ASSISTENZA','graduatoriavar_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavardefaultview','varchar(64)','ASSISTENZA','graduatoriavar_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriavardefaultview','int','ASSISTENZA','graduatoriavar_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriavardefaultview','int','ASSISTENZA','idgraduatoriavar','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriavardefaultview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI graduatoriavardefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'graduatoriavardefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'graduatoriavardefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('graduatoriavardefaultview', 'N')
GO

-- GENERAZIONE DATI PER graduatoriavardefaultview --
-- FINE GENERAZIONE SCRIPT --

