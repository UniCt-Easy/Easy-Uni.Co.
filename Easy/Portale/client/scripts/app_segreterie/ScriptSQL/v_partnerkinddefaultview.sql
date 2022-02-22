
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


-- CREAZIONE VISTA partnerkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[partnerkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[partnerkinddefaultview]
GO

CREATE VIEW [dbo].[partnerkinddefaultview] AS 
SELECT CASE WHEN partnerkind.active = 'S' THEN 'Si' WHEN partnerkind.active = 'N' THEN 'No' END AS partnerkind_active, partnerkind.description AS partnerkind_description, partnerkind.idpartnerkind, partnerkind.sortcode AS partnerkind_sortcode, partnerkind.title,
 isnull('Tipologia: ' + partnerkind.title + '; ','') as dropdown_title
FROM [dbo].partnerkind WITH (NOLOCK) 
WHERE  partnerkind.idpartnerkind IS NOT NULL 
GO

-- VERIFICA DI partnerkinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'partnerkinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','partnerkinddefaultview','varchar(2061)','ASSISTENZA','dropdown_title','2061','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','partnerkinddefaultview','int','ASSISTENZA','idpartnerkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','partnerkinddefaultview','varchar(2)','ASSISTENZA','partnerkind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','partnerkinddefaultview','varchar(max)','ASSISTENZA','partnerkind_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','partnerkinddefaultview','int','ASSISTENZA','partnerkind_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','partnerkinddefaultview','varchar(2048)','ASSISTENZA','title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI partnerkinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'partnerkinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'partnerkinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('partnerkinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER partnerkinddefaultview --
-- FINE GENERAZIONE SCRIPT --

