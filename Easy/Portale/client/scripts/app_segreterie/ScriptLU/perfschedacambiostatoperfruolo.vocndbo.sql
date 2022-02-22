
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


-- VERIFICA DI perfschedacambiostatoperfruolo IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfschedacambiostatoperfruolo'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedacambiostatoperfruolo','varchar(50)','Generator','idperfruolo','50','S','varchar','System.String','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedacambiostatoperfruolo','int','Generator','idperfschedacambiostato','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedacambiostatoperfruolo','datetime','Generator','ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedacambiostatoperfruolo','varchar(64)','Generator','cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedacambiostatoperfruolo','datetime','Generator','lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedacambiostatoperfruolo','varchar(64)','Generator','lu','64','S','varchar','System.String','','','','','N')
GO

-- VERIFICA DI perfschedacambiostatoperfruolo IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfschedacambiostatoperfruolo')
UPDATE customobject set isreal = 'S' where objectname = 'perfschedacambiostatoperfruolo'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfschedacambiostatoperfruolo', 'S')
GO
