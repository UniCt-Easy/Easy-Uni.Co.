
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


-- CREAZIONE VISTA convenzionesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[convenzionesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[convenzionesegview]
GO

CREATE VIEW [dbo].[convenzionesegview] AS 
SELECT  convenzione.ct AS convenzione_ct, convenzione.cu AS convenzione_cu, convenzione.idconvenzione,
 [dbo].registry.title AS registry_title, convenzione.idreg, convenzione.lt AS convenzione_lt, convenzione.lu AS convenzione_lu, convenzione.start AS convenzione_start, convenzione.stop AS convenzione_stop, convenzione.title, convenzione.url AS convenzione_url,
 isnull('Titolo: ' + convenzione.title + '; ','') as dropdown_title
FROM [dbo].convenzione WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON convenzione.idreg = [dbo].registry.idreg
WHERE  convenzione.idconvenzione IS NOT NULL  AND convenzione.idreg IS NOT NULL 
GO

-- VERIFICA DI convenzionesegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'convenzionesegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzionesegview','datetime','ASSISTENZA','convenzione_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzionesegview','varchar(64)','ASSISTENZA','convenzione_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzionesegview','datetime','ASSISTENZA','convenzione_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzionesegview','varchar(64)','ASSISTENZA','convenzione_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','convenzionesegview','date','ASSISTENZA','convenzione_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','convenzionesegview','date','ASSISTENZA','convenzione_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','convenzionesegview','varchar(512)','ASSISTENZA','convenzione_url','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzionesegview','varchar(266)','ASSISTENZA','dropdown_title','266','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzionesegview','int','ASSISTENZA','idconvenzione','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzionesegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','convenzionesegview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','convenzionesegview','varchar(256)','ASSISTENZA','title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI convenzionesegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'convenzionesegview')
UPDATE customobject set isreal = 'N' where objectname = 'convenzionesegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('convenzionesegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

