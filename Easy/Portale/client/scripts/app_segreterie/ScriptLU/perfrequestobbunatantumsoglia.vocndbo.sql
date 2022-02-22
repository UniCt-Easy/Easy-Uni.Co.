
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


-- VERIFICA DI perfrequestobbunatantumsoglia IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfrequestobbunatantumsoglia'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','int','Generator','idperfrequestobbunatantum','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','int','Generator','idperfrequestobbunatantumsoglia','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','datetime','Generator','ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','varchar(64)','Generator','cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbunatantumsoglia','varchar(50)','Generator','idperfsogliakind','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','datetime','Generator','lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','varchar(64)','Generator','lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbunatantumsoglia','decimal(19,2)','Generator','percentuale','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbunatantumsoglia','decimal(19,2)','Generator','valorenumerico','9','N','decimal','System.Decimal','','2','','19','N')
GO

-- VERIFICA DI perfrequestobbunatantumsoglia IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfrequestobbunatantumsoglia')
UPDATE customobject set isreal = 'S' where objectname = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfrequestobbunatantumsoglia', 'S')
GO
