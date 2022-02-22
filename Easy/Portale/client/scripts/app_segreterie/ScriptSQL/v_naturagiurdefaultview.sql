
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


-- CREAZIONE VISTA naturagiurdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[naturagiurdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[naturagiurdefaultview]
GO

CREATE VIEW [dbo].[naturagiurdefaultview] AS 
SELECT CASE WHEN naturagiur.active = 'S' THEN 'Si' WHEN naturagiur.active = 'N' THEN 'No' END AS naturagiur_active,CASE WHEN naturagiur.flagforeign = 'S' THEN 'Si' WHEN naturagiur.flagforeign = 'N' THEN 'No' END AS naturagiur_flagforeign, naturagiur.idnaturagiur, naturagiur.lt AS naturagiur_lt, naturagiur.lu AS naturagiur_lu, naturagiur.sortcode AS naturagiur_sortcode, naturagiur.title,
 isnull('Titolo: ' + naturagiur.title + '; ','') as dropdown_title
FROM [dbo].naturagiur WITH (NOLOCK) 
WHERE  naturagiur.idnaturagiur IS NOT NULL 
GO

-- VERIFICA DI naturagiurdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'naturagiurdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','naturagiurdefaultview','nvarchar(210)','ASSISTENZA','dropdown_title','210','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','naturagiurdefaultview','int','ASSISTENZA','idnaturagiur','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','naturagiurdefaultview','varchar(2)','ASSISTENZA','naturagiur_active','2','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','naturagiurdefaultview','varchar(2)','ASSISTENZA','naturagiur_flagforeign','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','naturagiurdefaultview','datetime','ASSISTENZA','naturagiur_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','naturagiurdefaultview','varchar(64)','ASSISTENZA','naturagiur_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','naturagiurdefaultview','int','ASSISTENZA','naturagiur_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','naturagiurdefaultview','nvarchar(200)','ASSISTENZA','title','200','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI naturagiurdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'naturagiurdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'naturagiurdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('naturagiurdefaultview', 'N')
GO

-- GENERAZIONE DATI PER naturagiurdefaultview --
-- FINE GENERAZIONE SCRIPT --

