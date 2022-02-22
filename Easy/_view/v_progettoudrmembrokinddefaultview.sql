
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
-- CREAZIONE VISTA progettoudrmembrokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoudrmembrokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettoudrmembrokinddefaultview]
GO

CREATE VIEW [dbo].[progettoudrmembrokinddefaultview] AS SELECT CASE WHEN progettoudrmembrokind.active = 'S' THEN 'Si' WHEN progettoudrmembrokind.active = 'N' THEN 'No' END AS progettoudrmembrokind_active, progettoudrmembrokind.ct AS progettoudrmembrokind_ct, progettoudrmembrokind.cu AS progettoudrmembrokind_cu, progettoudrmembrokind.description AS progettoudrmembrokind_description, progettoudrmembrokind.idprogettoudrmembrokind, progettoudrmembrokind.lt AS progettoudrmembrokind_lt, progettoudrmembrokind.lu AS progettoudrmembrokind_lu, progettoudrmembrokind.sortcode AS progettoudrmembrokind_sortcode, progettoudrmembrokind.title, isnull('Tipo di membro: ' + progettoudrmembrokind.title + '; ','') as dropdown_title FROM [dbo].progettoudrmembrokind WITH (NOLOCK)  WHERE  progettoudrmembrokind.idprogettoudrmembrokind IS NOT NULL 
GO

-- VERIFICA DI progettoudrmembrokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettoudrmembrokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudrmembrokinddefaultview','varchar(68)','','dropdown_title','68','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudrmembrokinddefaultview','int','','idprogettoudrmembrokind','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembrokinddefaultview','varchar(2)','','progettoudrmembrokind_active','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudrmembrokinddefaultview','datetime','','progettoudrmembrokind_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudrmembrokinddefaultview','varchar(64)','','progettoudrmembrokind_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembrokinddefaultview','varchar(2048)','','progettoudrmembrokind_description','2048','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudrmembrokinddefaultview','datetime','','progettoudrmembrokind_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudrmembrokinddefaultview','varchar(64)','','progettoudrmembrokind_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembrokinddefaultview','int','','progettoudrmembrokind_sortcode','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembrokinddefaultview','varchar(50)','','title','50','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI progettoudrmembrokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettoudrmembrokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'progettoudrmembrokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettoudrmembrokinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER progettoudrmembrokinddefaultview --
-- FINE GENERAZIONE SCRIPT --

