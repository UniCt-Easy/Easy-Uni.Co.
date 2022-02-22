
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


-- VERIFICA DI perfschedacambiostatodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfschedacambiostatodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','varchar(50)','','idperfruolo','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedacambiostatodefaultview','int','ASSISTENZA','idperfschedacambiostato','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','varchar(50)','','perfruolo_idperfruolo','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','varchar(50)','','perfschedacambiostato_idperfruolo_mail','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','int','ASSISTENZA','perfschedacambiostato_idperfschedastatus','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','int','ASSISTENZA','perfschedacambiostato_idperfschedastatus_to','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','varchar(1024)','ASSISTENZA','perfschedastatus_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','varchar(1024)','','perfschedastatusto_title','1024','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI perfschedacambiostatodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfschedacambiostatodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'perfschedacambiostatodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfschedacambiostatodefaultview', 'N')
GO
