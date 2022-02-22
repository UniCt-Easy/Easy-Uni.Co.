
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


-- CREAZIONE VISTA settoreercsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[settoreercsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[settoreercsegview]
GO



CREATE VIEW [dbo].[settoreercsegview] AS SELECT CASE WHEN settoreerc.active = 'S' THEN 'Si' WHEN settoreerc.active = 'N' THEN 'No' END AS settoreerc_active, settoreerc.ct AS settoreerc_ct, settoreerc.cu AS settoreerc_cu, settoreerc.description AS settoreerc_description, settoreerc.idsettoreerc, settoreerc.lt AS settoreerc_lt, settoreerc.lu AS settoreerc_lu, settoreerc.sortcode AS settoreerc_sortcode, settoreerc.title, isnull('Titolo: ' + settoreerc.title + '; ','') as dropdown_title FROM [dbo].settoreerc WITH (NOLOCK)  WHERE  settoreerc.idsettoreerc IS NOT NULL 

GO

-- VERIFICA DI settoreercsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'settoreercsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','settoreercsegview','nvarchar(2058)','ASSISTENZA','dropdown_title','2058','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','settoreercsegview','int','ASSISTENZA','idsettoreerc','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','varchar(2)','ASSISTENZA','settoreerc_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','datetime','ASSISTENZA','settoreerc_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','varchar(64)','ASSISTENZA','settoreerc_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','nvarchar(2048)','ASSISTENZA','settoreerc_description','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','datetime','ASSISTENZA','settoreerc_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','varchar(64)','ASSISTENZA','settoreerc_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','int','ASSISTENZA','settoreerc_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI settoreercsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'settoreercsegview')
UPDATE customobject set isreal = 'N' where objectname = 'settoreercsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('settoreercsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

