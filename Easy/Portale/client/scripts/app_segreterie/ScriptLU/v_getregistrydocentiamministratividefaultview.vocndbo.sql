
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


-- VERIFICA DI getregistrydocentiamministratividefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getregistrydocentiamministratividefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getregistrydocentiamministratividefaultview','varchar(241)','ASSISTENZA','dropdown_title','241','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getregistrydocentiamministratividefaultview','varchar(16)','ASSISTENZA','getregistrydocentiamministrativi_cf','16','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getregistrydocentiamministratividefaultview','varchar(50)','ASSISTENZA','getregistrydocentiamministrativi_contratto','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getregistrydocentiamministratividefaultview','varchar(40)','','getregistrydocentiamministrativi_extmatricula','40','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getregistrydocentiamministratividefaultview','varchar(50)','ASSISTENZA','getregistrydocentiamministrativi_forename','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getregistrydocentiamministratividefaultview','varchar(101)','ASSISTENZA','getregistrydocentiamministrativi_istituto','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getregistrydocentiamministratividefaultview','varchar(50)','ASSISTENZA','getregistrydocentiamministrativi_ssd','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getregistrydocentiamministratividefaultview','varchar(1024)','ASSISTENZA','getregistrydocentiamministrativi_struttura','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getregistrydocentiamministratividefaultview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getregistrydocentiamministratividefaultview','varchar(50)','ASSISTENZA','surname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI getregistrydocentiamministratividefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getregistrydocentiamministratividefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'getregistrydocentiamministratividefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getregistrydocentiamministratividefaultview', 'N')
GO
