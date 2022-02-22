
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


-- CREAZIONE VISTA titolokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[titolokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[titolokinddefaultview]
GO

CREATE VIEW [dbo].[titolokinddefaultview] AS 
SELECT CASE WHEN titolokind.active = 'S' THEN 'Si' WHEN titolokind.active = 'N' THEN 'No' END AS titolokind_active, titolokind.idtitolokind, titolokind.lt AS titolokind_lt, titolokind.lu AS titolokind_lu, titolokind.sortcode AS titolokind_sortcode, titolokind.title,
 isnull('Tipologia: ' + titolokind.title + '; ','') as dropdown_title
FROM [dbo].titolokind WITH (NOLOCK) 
WHERE  titolokind.idtitolokind IS NOT NULL 
GO

-- VERIFICA DI titolokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'titolokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','titolokinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','titolokinddefaultview','int','ASSISTENZA','idtitolokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','titolokinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','titolokinddefaultview','varchar(2)','ASSISTENZA','titolokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','titolokinddefaultview','datetime','ASSISTENZA','titolokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','titolokinddefaultview','varchar(64)','ASSISTENZA','titolokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','titolokinddefaultview','int','ASSISTENZA','titolokind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI titolokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'titolokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'titolokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('titolokinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER titolokinddefaultview --
-- FINE GENERAZIONE SCRIPT --

