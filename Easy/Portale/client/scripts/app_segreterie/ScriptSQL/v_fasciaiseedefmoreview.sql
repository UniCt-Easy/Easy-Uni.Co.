
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


-- CREAZIONE VISTA fasciaiseedefmoreview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[fasciaiseedefmoreview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[fasciaiseedefmoreview]
GO

CREATE VIEW [dbo].[fasciaiseedefmoreview] AS 
SELECT  fasciaiseedef.ct AS fasciaiseedef_ct, fasciaiseedef.cu AS fasciaiseedef_cu, fasciaiseedef.idcostoscontodef, fasciaiseedef.idfasciaisee, fasciaiseedef.idfasciaiseedef, fasciaiseedef.lt AS fasciaiseedef_lt, fasciaiseedef.lu AS fasciaiseedef_lu,
 isnull('Fascia ISEE: ' + fasciaiseedef.idfasciaisee + '; ','') as dropdown_title
FROM [dbo].fasciaiseedef WITH (NOLOCK) 
WHERE  fasciaiseedef.idcostoscontodef IS NOT NULL  AND fasciaiseedef.idfasciaiseedef IS NOT NULL 
GO

-- VERIFICA DI fasciaiseedefmoreview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'fasciaiseedefmoreview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fasciaiseedefmoreview','varchar(65)','ASSISTENZA','dropdown_title','65','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fasciaiseedefmoreview','datetime','ASSISTENZA','fasciaiseedef_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fasciaiseedefmoreview','varchar(64)','ASSISTENZA','fasciaiseedef_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fasciaiseedefmoreview','datetime','ASSISTENZA','fasciaiseedef_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fasciaiseedefmoreview','varchar(64)','ASSISTENZA','fasciaiseedef_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fasciaiseedefmoreview','int','ASSISTENZA','idcostoscontodef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fasciaiseedefmoreview','varchar(50)','ASSISTENZA','idfasciaisee','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fasciaiseedefmoreview','int','ASSISTENZA','idfasciaiseedef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI fasciaiseedefmoreview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'fasciaiseedefmoreview')
UPDATE customobject set isreal = 'N' where objectname = 'fasciaiseedefmoreview'
ELSE
INSERT INTO customobject (objectname, isreal) values('fasciaiseedefmoreview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

