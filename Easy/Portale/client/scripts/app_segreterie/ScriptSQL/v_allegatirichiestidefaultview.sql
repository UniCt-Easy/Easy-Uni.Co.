
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


-- CREAZIONE VISTA allegatirichiestidefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[allegatirichiestidefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[allegatirichiestidefaultview]
GO

CREATE VIEW [dbo].[allegatirichiestidefaultview] AS 
SELECT CASE WHEN allegatirichiesti.active = 'S' THEN 'Si' WHEN allegatirichiesti.active = 'N' THEN 'No' END AS allegatirichiesti_active, allegatirichiesti.ct AS allegatirichiesti_ct, allegatirichiesti.cu AS allegatirichiesti_cu, allegatirichiesti.idallegatirichiesti, allegatirichiesti.lt AS allegatirichiesti_lt, allegatirichiesti.lu AS allegatirichiesti_lu, allegatirichiesti.sortcode AS allegatirichiesti_sortcode, allegatirichiesti.title,
 isnull('Titolo: ' + allegatirichiesti.title + '; ','') as dropdown_title
FROM [dbo].allegatirichiesti WITH (NOLOCK) 
WHERE  allegatirichiesti.idallegatirichiesti IS NOT NULL 
GO

-- VERIFICA DI allegatirichiestidefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'allegatirichiestidefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','allegatirichiestidefaultview','varchar(2)','ASSISTENZA','allegatirichiesti_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiestidefaultview','datetime','ASSISTENZA','allegatirichiesti_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiestidefaultview','varchar(64)','ASSISTENZA','allegatirichiesti_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiestidefaultview','datetime','ASSISTENZA','allegatirichiesti_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiestidefaultview','varchar(64)','ASSISTENZA','allegatirichiesti_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiestidefaultview','int','ASSISTENZA','allegatirichiesti_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiestidefaultview','varchar(max)','ASSISTENZA','dropdown_title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiestidefaultview','int','ASSISTENZA','idallegatirichiesti','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiestidefaultview','varchar(max)','ASSISTENZA','title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI allegatirichiestidefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'allegatirichiestidefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'allegatirichiestidefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('allegatirichiestidefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

