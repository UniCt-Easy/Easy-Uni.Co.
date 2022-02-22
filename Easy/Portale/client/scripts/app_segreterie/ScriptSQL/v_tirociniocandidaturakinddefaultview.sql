
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
-- CREAZIONE VISTA tirociniocandidaturakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tirociniocandidaturakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tirociniocandidaturakinddefaultview]
GO

CREATE VIEW [dbo].[tirociniocandidaturakinddefaultview] AS SELECT CASE WHEN tirociniocandidaturakind.active = 'S' THEN 'Si' WHEN tirociniocandidaturakind.active = 'N' THEN 'No' END AS tirociniocandidaturakind_active, tirociniocandidaturakind.ct AS tirociniocandidaturakind_ct, tirociniocandidaturakind.cu AS tirociniocandidaturakind_cu, tirociniocandidaturakind.idtirociniocandidaturakind, tirociniocandidaturakind.lt AS tirociniocandidaturakind_lt, tirociniocandidaturakind.lu AS tirociniocandidaturakind_lu, tirociniocandidaturakind.sortcode AS tirociniocandidaturakind_sortcode, tirociniocandidaturakind.title, isnull('Tipologia: ' + tirociniocandidaturakind.title + '; ','') as dropdown_title FROM [dbo].tirociniocandidaturakind WITH (NOLOCK)  WHERE  tirociniocandidaturakind.idtirociniocandidaturakind IS NOT NULL 
GO

-- VERIFICA DI tirociniocandidaturakinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tirociniocandidaturakinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidaturakinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidaturakinddefaultview','int','ASSISTENZA','idtirociniocandidaturakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniocandidaturakinddefaultview','varchar(2)','ASSISTENZA','tirociniocandidaturakind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidaturakinddefaultview','datetime','ASSISTENZA','tirociniocandidaturakind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidaturakinddefaultview','varchar(64)','ASSISTENZA','tirociniocandidaturakind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidaturakinddefaultview','datetime','ASSISTENZA','tirociniocandidaturakind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidaturakinddefaultview','varchar(64)','ASSISTENZA','tirociniocandidaturakind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidaturakinddefaultview','int','ASSISTENZA','tirociniocandidaturakind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidaturakinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tirociniocandidaturakinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tirociniocandidaturakinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'tirociniocandidaturakinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('tirociniocandidaturakinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER tirociniocandidaturakinddefaultview --
-- FINE GENERAZIONE SCRIPT --

