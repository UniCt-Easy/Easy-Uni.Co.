
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


-- CREAZIONE VISTA publicazkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[publicazkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[publicazkinddefaultview]
GO



CREATE VIEW [dbo].[publicazkinddefaultview] AS SELECT CASE WHEN publicazkind.active = 'S' THEN 'Si' WHEN publicazkind.active = 'N' THEN 'No' END AS publicazkind_active, publicazkind.ct AS publicazkind_ct, publicazkind.cu AS publicazkind_cu, publicazkind.idpublicazkind, publicazkind.lt AS publicazkind_lt, publicazkind.lu AS publicazkind_lu, publicazkind.sortcode AS publicazkind_sortcode, publicazkind.subtitle AS publicazkind_subtitle, publicazkind.title, isnull('Tipologia: ' + publicazkind.title + '; ','') + ' ' + isnull('Sotto-tipologia: ' + publicazkind.subtitle + '; ','') as dropdown_title FROM [dbo].publicazkind WITH (NOLOCK)  WHERE  publicazkind.idpublicazkind IS NOT NULL 

GO

-- VERIFICA DI publicazkinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'publicazkinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkinddefaultview','varchar(339)','ASSISTENZA','dropdown_title','339','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkinddefaultview','int','ASSISTENZA','idpublicazkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazkinddefaultview','varchar(2)','ASSISTENZA','publicazkind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkinddefaultview','datetime','ASSISTENZA','publicazkind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkinddefaultview','varchar(64)','ASSISTENZA','publicazkind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkinddefaultview','datetime','ASSISTENZA','publicazkind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkinddefaultview','varchar(64)','ASSISTENZA','publicazkind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazkinddefaultview','int','ASSISTENZA','publicazkind_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazkinddefaultview','varchar(256)','ASSISTENZA','publicazkind_subtitle','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazkinddefaultview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI publicazkinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'publicazkinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'publicazkinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('publicazkinddefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

