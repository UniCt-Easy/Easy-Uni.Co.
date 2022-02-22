
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


-- VERIFICA DI settoreercsegprogview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'settoreercsegprogview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','settoreercsegprogview','nvarchar(2058)','ASSISTENZA','dropdown_title','2058','S','nvarchar','System.String','','0','''ASSISTENZA''','0','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','settoreercsegprogview','int','ASSISTENZA','idsettoreerc','4','S','int','System.Int32','','0','''ASSISTENZA''','0','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegprogview','varchar(2)','ASSISTENZA','settoreerc_active','2','N','varchar','System.String','','0','''ASSISTENZA''','0','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegprogview','datetime','ASSISTENZA','settoreerc_ct','8','N','datetime','System.DateTime','','0','''ASSISTENZA''','0','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegprogview','varchar(64)','ASSISTENZA','settoreerc_cu','64','N','varchar','System.String','','0','''ASSISTENZA''','0','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegprogview','nvarchar(2048)','ASSISTENZA','settoreerc_description','2048','N','nvarchar','System.String','','0','''ASSISTENZA''','0','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegprogview','datetime','ASSISTENZA','settoreerc_lt','8','N','datetime','System.DateTime','','0','''ASSISTENZA''','0','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegprogview','varchar(64)','ASSISTENZA','settoreerc_lu','64','N','varchar','System.String','','0','''ASSISTENZA''','0','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegprogview','int','ASSISTENZA','settoreerc_sortcode','4','N','int','System.Int32','','0','''ASSISTENZA''','0','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegprogview','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','0','''ASSISTENZA''','0','N')
GO

-- VERIFICA DI settoreercsegprogview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'settoreercsegprogview')
UPDATE customobject set isreal = 'N' where objectname = 'settoreercsegprogview'
ELSE
INSERT INTO customobject (objectname, isreal) values('settoreercsegprogview', 'N')
GO
