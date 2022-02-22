
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


--[DBO]--
-- CREAZIONE VISTA esonerodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[esonerodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[esonerodefaultview]
GO

CREATE VIEW [dbo].[esonerodefaultview] AS SELECT  esonero.aa,CASE WHEN esonero.applunavolta = 'S' THEN 'Si' WHEN esonero.applunavolta = 'N' THEN 'No' END AS esonero_applunavolta, esonero.ct AS esonero_ct, esonero.cu AS esonero_cu, esonero.description AS esonero_description, [dbo].costoscontodef.title AS costoscontodef_title, esonero.idcostoscontodef, esonero.idesonero, [dbo].esoneroanskind.title AS esoneroanskind_title, [dbo].esoneroanskind.description AS esoneroanskind_description, esonero.idesoneroanskind AS esonero_idesoneroanskind, esonero.lt AS esonero_lt, esonero.lu AS esonero_lu,CASE WHEN esonero.retroattivo = 'S' THEN 'Si' WHEN esonero.retroattivo = 'N' THEN 'No' END AS esonero_retroattivo,CASE WHEN esonero.soloconisee = 'S' THEN 'Si' WHEN esonero.soloconisee = 'N' THEN 'No' END AS esonero_soloconisee, esonero.title, isnull('Denominazione: ' + esonero.title + '; ','') as dropdown_title FROM [dbo].esonero WITH (NOLOCK)  LEFT OUTER JOIN [dbo].costoscontodef WITH (NOLOCK) ON esonero.idcostoscontodef = [dbo].costoscontodef.idcostoscontodef LEFT OUTER JOIN [dbo].esoneroanskind WITH (NOLOCK) ON esonero.idesoneroanskind = [dbo].esoneroanskind.idesoneroanskind WHERE  esonero.idesonero IS NOT NULL 
GO

-- VERIFICA DI esonerodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'esonerodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodefaultview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodefaultview','nvarchar(2024)','ASSISTENZA','costoscontodef_title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodefaultview','varchar(67)','ASSISTENZA','dropdown_title','67','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodefaultview','varchar(2)','ASSISTENZA','esonero_applunavolta','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodefaultview','datetime','ASSISTENZA','esonero_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodefaultview','varchar(64)','ASSISTENZA','esonero_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodefaultview','varchar(256)','ASSISTENZA','esonero_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodefaultview','int','ASSISTENZA','esonero_idesoneroanskind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodefaultview','datetime','ASSISTENZA','esonero_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodefaultview','varchar(64)','ASSISTENZA','esonero_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodefaultview','varchar(2)','ASSISTENZA','esonero_retroattivo','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodefaultview','varchar(2)','ASSISTENZA','esonero_soloconisee','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodefaultview','varchar(256)','ASSISTENZA','esoneroanskind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodefaultview','varchar(50)','ASSISTENZA','esoneroanskind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodefaultview','int','ASSISTENZA','idcostoscontodef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodefaultview','int','ASSISTENZA','idesonero','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI esonerodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'esonerodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'esonerodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('esonerodefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

