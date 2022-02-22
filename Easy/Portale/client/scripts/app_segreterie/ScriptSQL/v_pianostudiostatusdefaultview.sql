
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
-- CREAZIONE VISTA pianostudiostatusdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pianostudiostatusdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[pianostudiostatusdefaultview]
GO

CREATE VIEW [dbo].[pianostudiostatusdefaultview] AS SELECT CASE WHEN pianostudiostatus.active = 'S' THEN 'Si' WHEN pianostudiostatus.active = 'N' THEN 'No' END AS pianostudiostatus_active, pianostudiostatus.description AS pianostudiostatus_description, pianostudiostatus.idpianostudiostatus, pianostudiostatus.lt AS pianostudiostatus_lt, pianostudiostatus.lu AS pianostudiostatus_lu, pianostudiostatus.sortcode AS pianostudiostatus_sortcode, pianostudiostatus.title, isnull('Stato: ' + pianostudiostatus.title + '; ','') as dropdown_title FROM [dbo].pianostudiostatus WITH (NOLOCK)  WHERE  pianostudiostatus.idpianostudiostatus IS NOT NULL 
GO

-- VERIFICA DI pianostudiostatusdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pianostudiostatusdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatusdefaultview','varchar(59)','ASSISTENZA','dropdown_title','59','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatusdefaultview','int','ASSISTENZA','idpianostudiostatus','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiostatusdefaultview','varchar(2)','ASSISTENZA','pianostudiostatus_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiostatusdefaultview','nvarchar(256)','ASSISTENZA','pianostudiostatus_description','256','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatusdefaultview','datetime','ASSISTENZA','pianostudiostatus_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatusdefaultview','varchar(64)','ASSISTENZA','pianostudiostatus_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatusdefaultview','int','ASSISTENZA','pianostudiostatus_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatusdefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI pianostudiostatusdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pianostudiostatusdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'pianostudiostatusdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('pianostudiostatusdefaultview', 'N')
GO

-- GENERAZIONE DATI PER pianostudiostatusdefaultview --
-- FINE GENERAZIONE SCRIPT --

