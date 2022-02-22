
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


-- CREAZIONE VISTA iscrizionebmisegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[iscrizionebmisegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[iscrizionebmisegview]
GO

CREATE VIEW [dbo].[iscrizionebmisegview] AS 
SELECT  iscrizionebmi.ct AS iscrizionebmi_ct, iscrizionebmi.cu AS iscrizionebmi_cu, iscrizionebmi.data AS iscrizionebmi_data, iscrizionebmi.idbandomi,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, iscrizionebmi.idiscrizione, iscrizionebmi.idiscrizionebmi,
 [dbo].registry.title AS registry_title, iscrizionebmi.idreg, iscrizionebmi.lt AS iscrizionebmi_lt, iscrizionebmi.lu AS iscrizionebmi_lu,(select top 1 idcefr_compasc 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_compasc,
						(select top 1 idcefr_complett 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_complett,
						(select top 1 idcefr_parlinter 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_parlinter,
						(select top 1 idcefr_parlprod 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_parlprod,
						(select top 1 idcefr_scritto 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_scritto,
						(select top 1 idnation 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idiscrizionebmi = iscrizionebmi.idiscrizionebmi
						 order by cefrlanglevel.idnation desc) as idnation,
 isnull('Identificativo: ' + [dbo].registry.title + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, iscrizionebmi.data, 103),'') + ' ' + isnull('Iscrizione: ' + CAST( [dbo].iscrizione.anno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Iscrizione: ' + CAST( [dbo].iscrizione.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Iscrizione: ' + [dbo].iscrizione.aa + '; ','') as dropdown_title
FROM [dbo].iscrizionebmi WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON iscrizionebmi.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON iscrizionebmi.idreg = [dbo].registry.idreg
WHERE  iscrizionebmi.idbandomi IS NOT NULL  AND iscrizionebmi.idiscrizionebmi IS NOT NULL  AND iscrizionebmi.idreg IS NOT NULL 
GO

-- VERIFICA DI iscrizionebmisegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'iscrizionebmisegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','int','','cefrlanglevel_idcefr_compasc','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','int','','cefrlanglevel_idcefr_complett','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','int','','cefrlanglevel_idcefr_parlinter','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','int','','cefrlanglevel_idcefr_parlprod','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','int','','cefrlanglevel_idcefr_scritto','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmisegview','nvarchar(336)','','dropdown_title','336','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmisegview','int','ASSISTENZA','idbandomi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','int','ASSISTENZA','idiscrizione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmisegview','int','ASSISTENZA','idiscrizionebmi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','int','','idnation','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmisegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','varchar(9)','','iscrizione_aa','9','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','int','ASSISTENZA','iscrizione_anno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','int','ASSISTENZA','iscrizione_iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmisegview','datetime','ASSISTENZA','iscrizionebmi_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmisegview','varchar(64)','ASSISTENZA','iscrizionebmi_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','datetime','ASSISTENZA','iscrizionebmi_data','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmisegview','datetime','ASSISTENZA','iscrizionebmi_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmisegview','varchar(64)','ASSISTENZA','iscrizionebmi_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmisegview','varchar(101)','','registry_title','101','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI iscrizionebmisegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'iscrizionebmisegview')
UPDATE customobject set isreal = 'N' where objectname = 'iscrizionebmisegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('iscrizionebmisegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

