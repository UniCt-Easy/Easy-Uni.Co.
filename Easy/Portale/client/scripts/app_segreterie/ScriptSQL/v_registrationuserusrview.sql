
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


-- CREAZIONE VISTA registrationuserusrview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuserusrview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrationuserusrview]
GO

CREATE VIEW [dbo].[registrationuserusrview] AS 
SELECT  registrationuser.idregistrationuser, registrationuser.surname, registrationuser.forename AS registrationuser_forename, registrationuser.cf AS registrationuser_cf, registrationuser.esercizio AS registrationuser_esercizio, registrationuser.email AS registrationuser_email, registrationuser.login AS registrationuser_login, registrationuser.usertype,
 [dbo].registrationuserstatus.title AS registrationuserstatus_title, registrationuser.idregistrationuserstatus AS registrationuser_idregistrationuserstatus, registrationuser.matricola AS registrationuser_matricola, registrationuser.userkind AS registrationuser_userkind,
 isnull('Cognome: ' + registrationuser.surname + '; ','') + ' ' + isnull('Nome: ' + registrationuser.forename + '; ','') + ' ' + isnull('Codice fiscale: ' + registrationuser.cf + '; ','') as dropdown_title
FROM [dbo].registrationuser WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registrationuserstatus WITH (NOLOCK) ON registrationuser.idregistrationuserstatus = [dbo].registrationuserstatus.idregistrationuserstatus
WHERE  registrationuser.idregistrationuser IS NOT NULL 
GO

-- VERIFICA DI registrationuserusrview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrationuserusrview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrationuserusrview','varchar(154)','ASSISTENZA','dropdown_title','154','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrationuserusrview','int','ASSISTENZA','idregistrationuser','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','varchar(16)','ASSISTENZA','registrationuser_cf','16','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','varchar(1024)','ASSISTENZA','registrationuser_email','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','int','ASSISTENZA','registrationuser_esercizio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','varchar(49)','ASSISTENZA','registrationuser_forename','49','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','int','','registrationuser_idregistrationuserstatus','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','varchar(60)','ASSISTENZA','registrationuser_login','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','varchar(50)','ASSISTENZA','registrationuser_matricola','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','int','ASSISTENZA','registrationuser_userkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','varchar(64)','','registrationuserstatus_title','64','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','varchar(50)','ASSISTENZA','surname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserusrview','varchar(50)','','usertype','50','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI registrationuserusrview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrationuserusrview')
UPDATE customobject set isreal = 'N' where objectname = 'registrationuserusrview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrationuserusrview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

