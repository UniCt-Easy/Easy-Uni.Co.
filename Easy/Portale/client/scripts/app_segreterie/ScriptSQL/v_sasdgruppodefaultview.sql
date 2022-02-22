
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


-- CREAZIONE VISTA sasdgruppodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasdgruppodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sasdgruppodefaultview]
GO

CREATE VIEW [dbo].[sasdgruppodefaultview] AS 
SELECT  sasdgruppo.ct AS sasdgruppo_ct, sasdgruppo.cu AS sasdgruppo_cu, sasdgruppo.idsasdgruppo,
 [dbo].tipoattform.title AS tipoattform_title, [dbo].tipoattform.description AS tipoattform_description, sasdgruppo.idtipoattform, sasdgruppo.lt AS sasdgruppo_lt, sasdgruppo.lu AS sasdgruppo_lu, sasdgruppo.title,
 isnull('Gruppo: ' + sasdgruppo.title + '; ','') as dropdown_title
FROM [dbo].sasdgruppo WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].tipoattform WITH (NOLOCK) ON sasdgruppo.idtipoattform = [dbo].tipoattform.idtipoattform
WHERE  sasdgruppo.idsasdgruppo IS NOT NULL  AND sasdgruppo.idtipoattform IS NOT NULL 
GO

-- VERIFICA DI sasdgruppodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sasdgruppodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdgruppodefaultview','varchar(60)','ASSISTENZA','dropdown_title','60','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdgruppodefaultview','int','ASSISTENZA','idsasdgruppo','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdgruppodefaultview','int','ASSISTENZA','idtipoattform','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdgruppodefaultview','datetime','ASSISTENZA','sasdgruppo_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdgruppodefaultview','varchar(64)','ASSISTENZA','sasdgruppo_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdgruppodefaultview','datetime','ASSISTENZA','sasdgruppo_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdgruppodefaultview','varchar(64)','ASSISTENZA','sasdgruppo_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasdgruppodefaultview','varchar(256)','ASSISTENZA','tipoattform_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasdgruppodefaultview','varchar(1)','ASSISTENZA','tipoattform_title','1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasdgruppodefaultview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sasdgruppodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sasdgruppodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'sasdgruppodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sasdgruppodefaultview', 'N')
GO

-- GENERAZIONE DATI PER sasdgruppodefaultview --
-- FINE GENERAZIONE SCRIPT --

