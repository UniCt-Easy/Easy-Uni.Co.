
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA workpackagesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[workpackagesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [workpackagesegview]
GO

CREATE VIEW [workpackagesegview] AS SELECT  workpackage.acronimo AS workpackage_acronimo, workpackage.ct AS workpackage_ct, workpackage.cu AS workpackage_cu, workpackage.description AS workpackage_description, workpackage.idprogetto, [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, workpackage.idstruttura AS workpackage_idstruttura, workpackage.idworkpackage, workpackage.lt AS workpackage_lt, workpackage.lu AS workpackage_lu, workpackage.raggruppamento, workpackage.title AS workpackage_title, isnull('Raggruppamento: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Titolo: ' + workpackage.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].strutturakind.title + '; ','') as dropdown_title FROM workpackage WITH (NOLOCK)  LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON workpackage.idstruttura = [dbo].struttura.idstruttura LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind WHERE  workpackage.idprogetto IS NOT NULL  AND workpackage.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI workpackagesegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'workpackagesegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','nvarchar(4000)','ASSISTENZA','dropdown_title','4000','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','varchar(1024)','','struttura_title','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','workpackage_acronimo','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','datetime','ASSISTENZA','workpackage_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','varchar(64)','ASSISTENZA','workpackage_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(max)','ASSISTENZA','workpackage_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','int','','workpackage_idstruttura','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','datetime','ASSISTENZA','workpackage_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','varchar(64)','ASSISTENZA','workpackage_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI workpackagesegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'workpackagesegview')
UPDATE customobject set isreal = 'N' where objectname = 'workpackagesegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('workpackagesegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --
