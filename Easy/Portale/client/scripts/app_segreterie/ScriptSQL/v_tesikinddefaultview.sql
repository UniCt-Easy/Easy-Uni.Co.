
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA tesikinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tesikinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tesikinddefaultview]
GO

CREATE VIEW [dbo].[tesikinddefaultview] AS 
SELECT CASE WHEN tesikind.active = 'S' THEN 'Si' WHEN tesikind.active = 'N' THEN 'No' END AS tesikind_active, tesikind.ct AS tesikind_ct, tesikind.cu AS tesikind_cu, tesikind.description AS tesikind_description, tesikind.idtesikind, tesikind.lt AS tesikind_lt, tesikind.lu AS tesikind_lu, tesikind.sortcode AS tesikind_sortcode, tesikind.title,
 isnull('Tipologia: ' + tesikind.title + '; ','') as dropdown_title
FROM [dbo].tesikind WITH (NOLOCK) 
WHERE  tesikind.active = 'S' AND tesikind.idtesikind IS NOT NULL 
GO

-- VERIFICA DI tesikinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tesikinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tesikinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tesikinddefaultview','int','ASSISTENZA','idtesikind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tesikinddefaultview','varchar(2)','ASSISTENZA','tesikind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tesikinddefaultview','datetime','ASSISTENZA','tesikind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tesikinddefaultview','varchar(64)','ASSISTENZA','tesikind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tesikinddefaultview','varchar(256)','ASSISTENZA','tesikind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tesikinddefaultview','datetime','ASSISTENZA','tesikind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tesikinddefaultview','varchar(64)','ASSISTENZA','tesikind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tesikinddefaultview','int','ASSISTENZA','tesikind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tesikinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tesikinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tesikinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'tesikinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('tesikinddefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --
