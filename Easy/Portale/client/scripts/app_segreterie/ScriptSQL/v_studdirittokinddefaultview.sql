
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
-- CREAZIONE VISTA studdirittokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[studdirittokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[studdirittokinddefaultview]
GO

CREATE VIEW [dbo].[studdirittokinddefaultview] AS SELECT CASE WHEN studdirittokind.active = 'S' THEN 'Si' WHEN studdirittokind.active = 'N' THEN 'No' END AS studdirittokind_active, studdirittokind.description AS studdirittokind_description, studdirittokind.idstuddirittokind, studdirittokind.lt AS studdirittokind_lt, studdirittokind.lu AS studdirittokind_lu, studdirittokind.sortorder AS studdirittokind_sortorder, studdirittokind.title, isnull('Tipologia: ' + studdirittokind.title + '; ','') as dropdown_title FROM [dbo].studdirittokind WITH (NOLOCK)  WHERE  studdirittokind.idstuddirittokind IS NOT NULL 
GO

-- VERIFICA DI studdirittokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'studdirittokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','studdirittokinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','studdirittokinddefaultview','int','ASSISTENZA','idstuddirittokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','studdirittokinddefaultview','varchar(2)','ASSISTENZA','studdirittokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','studdirittokinddefaultview','varchar(512)','ASSISTENZA','studdirittokind_description','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','studdirittokinddefaultview','datetime','ASSISTENZA','studdirittokind_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','studdirittokinddefaultview','varchar(64)','ASSISTENZA','studdirittokind_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','studdirittokinddefaultview','int','ASSISTENZA','studdirittokind_sortorder','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','studdirittokinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI studdirittokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'studdirittokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'studdirittokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('studdirittokinddefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

