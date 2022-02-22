
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


-- VERIFICA DI restrictedfunction IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'restrictedfunction'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunction','int','SARA','idrestrictedfunction','4','S','int','System.Int32','','','''SARA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunction','datetime','SARA','ct','8','S','datetime','System.DateTime','','','''SARA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunction','varchar(64)','SARA','cu','64','S','varchar','System.String','','','''SARA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunction','varchar(100)','SARA','description','100','S','varchar','System.String','','','''SARA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunction','datetime','SARA','lt','8','S','datetime','System.DateTime','','','''SARA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunction','varchar(64)','SARA','lu','64','S','varchar','System.String','','','''SARA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunction','varchar(50)','SARA','variablename','50','S','varchar','System.String','','','''SARA''','','N')
GO

-- VERIFICA DI restrictedfunction IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'restrictedfunction')
UPDATE customobject set isreal = 'S' where objectname = 'restrictedfunction'
ELSE
INSERT INTO customobject (objectname, isreal) values('restrictedfunction', 'S')
GO
