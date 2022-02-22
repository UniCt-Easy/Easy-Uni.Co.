
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
-- CREAZIONE VISTA esonerodisabilview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[esonerodisabilview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[esonerodisabilview]
GO

CREATE VIEW [dbo].[esonerodisabilview] AS SELECT  esonero.aa,CASE WHEN esonero.applunavolta = 'S' THEN 'Si' WHEN esonero.applunavolta = 'N' THEN 'No' END AS esonero_applunavolta, esonero.ct AS esonero_ct, esonero.cu AS esonero_cu, esonero.description AS esonero_description, [dbo].costoscontodef.title AS costoscontodef_title, esonero.idcostoscontodef, esonero.idesonero, [dbo].esoneroanskind.title AS esoneroanskind_title, [dbo].esoneroanskind.description AS esoneroanskind_description, esonero.idesoneroanskind AS esonero_idesoneroanskind, esonero.lt AS esonero_lt, esonero.lu AS esonero_lu,CASE WHEN esonero.retroattivo = 'S' THEN 'Si' WHEN esonero.retroattivo = 'N' THEN 'No' END AS esonero_retroattivo,CASE WHEN esonero.soloconisee = 'S' THEN 'Si' WHEN esonero.soloconisee = 'N' THEN 'No' END AS esonero_soloconisee, esonero.title, esonero_disabil.ct AS esonero_disabil_ct, esonero_disabil.cu AS esonero_disabil_cu, esonero_disabil.idesonero AS esonero_disabil_idesonero, esonero_disabil.lt AS esonero_disabil_lt, esonero_disabil.lu AS esonero_disabil_lu, esonero_disabil.percmax AS esonero_disabil_percmax, esonero_disabil.percmin AS esonero_disabil_percmin, isnull('Denominazione: ' + esonero.title + '; ','') as dropdown_title FROM [dbo].esonero WITH (NOLOCK)  INNER JOIN esonero_disabil WITH (NOLOCK) ON esonero.idesonero = esonero_disabil.idesonero LEFT OUTER JOIN [dbo].costoscontodef WITH (NOLOCK) ON esonero.idcostoscontodef = [dbo].costoscontodef.idcostoscontodef LEFT OUTER JOIN [dbo].esoneroanskind WITH (NOLOCK) ON esonero.idesoneroanskind = [dbo].esoneroanskind.idesoneroanskind WHERE  esonero.idesonero IS NOT NULL  AND esonero_disabil.idesonero IS NOT NULL 
GO

-- VERIFICA DI esonerodisabilview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'esonerodisabilview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodisabilview','nvarchar(2024)','ASSISTENZA','costoscontodef_title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','varchar(67)','ASSISTENZA','dropdown_title','67','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodisabilview','varchar(2)','ASSISTENZA','esonero_applunavolta','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','datetime','ASSISTENZA','esonero_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','varchar(64)','ASSISTENZA','esonero_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodisabilview','varchar(256)','ASSISTENZA','esonero_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','datetime','ASSISTENZA','esonero_disabil_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','varchar(64)','ASSISTENZA','esonero_disabil_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','int','ASSISTENZA','esonero_disabil_idesonero','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','datetime','ASSISTENZA','esonero_disabil_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','varchar(64)','ASSISTENZA','esonero_disabil_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodisabilview','decimal(9,2)','ASSISTENZA','esonero_disabil_percmax','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodisabilview','decimal(9,2)','ASSISTENZA','esonero_disabil_percmin','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodisabilview','int','ASSISTENZA','esonero_idesoneroanskind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','datetime','ASSISTENZA','esonero_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','varchar(64)','ASSISTENZA','esonero_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodisabilview','varchar(2)','ASSISTENZA','esonero_retroattivo','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodisabilview','varchar(2)','ASSISTENZA','esonero_soloconisee','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodisabilview','varchar(256)','ASSISTENZA','esoneroanskind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonerodisabilview','varchar(50)','ASSISTENZA','esoneroanskind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','int','ASSISTENZA','idcostoscontodef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','int','ASSISTENZA','idesonero','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonerodisabilview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI esonerodisabilview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'esonerodisabilview')
UPDATE customobject set isreal = 'N' where objectname = 'esonerodisabilview'
ELSE
INSERT INTO customobject (objectname, isreal) values('esonerodisabilview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

