
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
-- CREAZIONE VISTA pianostudiosegstudview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pianostudiosegstudview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[pianostudiosegstudview]
GO

CREATE VIEW [dbo].[pianostudiosegstudview] AS SELECT  pianostudio.aa, pianostudio.ct AS pianostudio_ct, pianostudio.cu AS pianostudio_cu, pianostudio.idcorsostudio, [dbo].didprog.title AS didprog_title, [dbo].annoaccademico.aa AS annoaccademico_aa, [dbo].sede.title AS sede_title, pianostudio.iddidprog, [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, annoaccademico_iscrizione.aa AS annoaccademico_iscrizione_aa, pianostudio.idiscrizione, pianostudio.idiscrizionebmi AS pianostudio_idiscrizionebmi, pianostudio.idpianostudio, [dbo].pianostudiostatus.title AS pianostudiostatus_title, pianostudio.idpianostudiostatus AS pianostudio_idpianostudiostatus, [dbo].registry.title AS registry_title, pianostudio.idreg, pianostudio.lt AS pianostudio_lt, pianostudio.lu AS pianostudio_lu, isnull('Anno accademico: ' + pianostudio.aa + '; ','') + ' ' + isnull('Codice Anno accademico: ' + [dbo].annoaccademico.aa + '; ','') + ' ' + isnull('Status: ' + [dbo].pianostudiostatus.title + '; ','') + ' ' + isnull('Codice Anno accademico: ' + annoaccademico_iscrizione.aa + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') as dropdown_title FROM [dbo].pianostudio WITH (NOLOCK)  LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON pianostudio.iddidprog = [dbo].didprog.iddidprog LEFT OUTER JOIN [dbo].annoaccademico WITH (NOLOCK) ON didprog.aa = [dbo].annoaccademico.aa LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON pianostudio.idiscrizione = [dbo].iscrizione.idiscrizione LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_iscrizione WITH (NOLOCK) ON iscrizione.aa = annoaccademico_iscrizione.aa LEFT OUTER JOIN [dbo].pianostudiostatus WITH (NOLOCK) ON pianostudio.idpianostudiostatus = [dbo].pianostudiostatus.idpianostudiostatus LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON pianostudio.idreg = [dbo].registry.idreg WHERE  pianostudio.idcorsostudio IS NOT NULL  AND pianostudio.iddidprog IS NOT NULL  AND pianostudio.idiscrizione IS NOT NULL  AND pianostudio.idpianostudio IS NOT NULL  AND pianostudio.idreg IS NOT NULL 
GO

-- VERIFICA DI pianostudiosegstudview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pianostudiosegstudview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','nvarchar(9)','','annoaccademico_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','nvarchar(9)','','annoaccademico_iscrizione_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','varchar(1024)','ASSISTENZA','didprog_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiosegstudview','nvarchar(1208)','ASSISTENZA','dropdown_title','1208','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiosegstudview','int','ASSISTENZA','idiscrizione','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiosegstudview','int','ASSISTENZA','idpianostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiosegstudview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','int','ASSISTENZA','iscrizione_anno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','int','ASSISTENZA','iscrizione_iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiosegstudview','datetime','ASSISTENZA','pianostudio_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiosegstudview','varchar(64)','ASSISTENZA','pianostudio_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','int','ASSISTENZA','pianostudio_idiscrizionebmi','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','int','ASSISTENZA','pianostudio_idpianostudiostatus','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiosegstudview','datetime','ASSISTENZA','pianostudio_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiosegstudview','varchar(64)','ASSISTENZA','pianostudio_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','varchar(50)','ASSISTENZA','pianostudiostatus_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiosegstudview','nvarchar(1024)','','sede_title','1024','N','nvarchar','System.String','','','','','N')
GO

-- VERIFICA DI pianostudiosegstudview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pianostudiosegstudview')
UPDATE customobject set isreal = 'N' where objectname = 'pianostudiosegstudview'
ELSE
INSERT INTO customobject (objectname, isreal) values('pianostudiosegstudview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

