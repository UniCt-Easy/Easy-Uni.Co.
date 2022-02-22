
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


-- CREAZIONE VISTA accordoscambiomidettazsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accordoscambiomidettazsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accordoscambiomidettazsegview]
GO

CREATE VIEW [dbo].[accordoscambiomidettazsegview] AS 
SELECT  accordoscambiomidettaz.ct AS accordoscambiomidettaz_ct, accordoscambiomidettaz.cu AS accordoscambiomidettaz_cu, accordoscambiomidettaz.idaccordoscambiomi, accordoscambiomidettaz.idaccordoscambiomidettaz,
 registry_registry_aziendeaziende.title AS registryaziende_title, accordoscambiomidettaz.idreg_aziende, accordoscambiomidettaz.lt AS accordoscambiomidettaz_lt, accordoscambiomidettaz.lu AS accordoscambiomidettaz_lu, accordoscambiomidettaz.numstud AS accordoscambiomidettaz_numstud, accordoscambiomidettaz.stipula AS accordoscambiomidettaz_stipula, accordoscambiomidettaz.stop AS accordoscambiomidettaz_stop
FROM [dbo].accordoscambiomidettaz WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON accordoscambiomidettaz.idreg_aziende = registry_aziendeaziende.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registry_registry_aziendeaziende.idreg
WHERE  accordoscambiomidettaz.idaccordoscambiomi IS NOT NULL  AND accordoscambiomidettaz.idaccordoscambiomidettaz IS NOT NULL  AND accordoscambiomidettaz.idreg_aziende IS NOT NULL 
GO

-- VERIFICA DI accordoscambiomidettazsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accordoscambiomidettazsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettazsegview','datetime','ASSISTENZA','accordoscambiomidettaz_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettazsegview','varchar(64)','ASSISTENZA','accordoscambiomidettaz_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettazsegview','datetime','ASSISTENZA','accordoscambiomidettaz_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettazsegview','varchar(64)','ASSISTENZA','accordoscambiomidettaz_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettazsegview','int','ASSISTENZA','accordoscambiomidettaz_numstud','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettazsegview','date','ASSISTENZA','accordoscambiomidettaz_stipula','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettazsegview','date','ASSISTENZA','accordoscambiomidettaz_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettazsegview','int','ASSISTENZA','idaccordoscambiomi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettazsegview','int','ASSISTENZA','idaccordoscambiomidettaz','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettazsegview','int','ASSISTENZA','idreg_aziende','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettazsegview','varchar(101)','ASSISTENZA','registryaziende_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI accordoscambiomidettazsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accordoscambiomidettazsegview')
UPDATE customobject set isreal = 'N' where objectname = 'accordoscambiomidettazsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('accordoscambiomidettazsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

