
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
-- CREAZIONE VISTA tirociniostatodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tirociniostatodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tirociniostatodefaultview]
GO

CREATE VIEW [dbo].[tirociniostatodefaultview] AS SELECT CASE WHEN tirociniostato.active = 'S' THEN 'Si' WHEN tirociniostato.active = 'N' THEN 'No' END AS tirociniostato_active, tirociniostato.ct AS tirociniostato_ct, tirociniostato.cu AS tirociniostato_cu, tirociniostato.description AS tirociniostato_description, tirociniostato.idtirociniostato, tirociniostato.lt AS tirociniostato_lt, tirociniostato.lu AS tirociniostato_lu, tirociniostato.sortcode AS tirociniostato_sortcode, tirociniostato.title, isnull('Stato: ' + tirociniostato.title + '; ','') as dropdown_title FROM [dbo].tirociniostato WITH (NOLOCK)  WHERE  tirociniostato.idtirociniostato IS NOT NULL 
GO

-- VERIFICA DI tirociniostatodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tirociniostatodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniostatodefaultview','varchar(59)','ASSISTENZA','dropdown_title','59','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniostatodefaultview','int','ASSISTENZA','idtirociniostato','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniostatodefaultview','varchar(2)','ASSISTENZA','tirociniostato_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniostatodefaultview','datetime','ASSISTENZA','tirociniostato_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniostatodefaultview','varchar(64)','ASSISTENZA','tirociniostato_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniostatodefaultview','varchar(256)','ASSISTENZA','tirociniostato_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniostatodefaultview','datetime','ASSISTENZA','tirociniostato_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniostatodefaultview','varchar(64)','ASSISTENZA','tirociniostato_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniostatodefaultview','int','ASSISTENZA','tirociniostato_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniostatodefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tirociniostatodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tirociniostatodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'tirociniostatodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('tirociniostatodefaultview', 'N')
GO

-- GENERAZIONE DATI PER tirociniostatodefaultview --
-- FINE GENERAZIONE SCRIPT --

