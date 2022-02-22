
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


-- CREAZIONE VISTA sessionedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sessionedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sessionedefaultview]
GO

CREATE VIEW [dbo].[sessionedefaultview] AS 
SELECT  sessione.ct AS sessione_ct, sessione.cu AS sessione_cu,
 [dbo].appellokind.title AS appellokind_title, sessione.idappellokind AS sessione_idappellokind, sessione.idsessione,
 [dbo].sessionekind.title AS sessionekind_title, sessione.idsessionekind, sessione.lt AS sessione_lt, sessione.lu AS sessione_lu, sessione.start AS sessione_start, sessione.stop AS sessione_stop,
 isnull('Tipologia: ' + [dbo].sessionekind.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, sessione.start, 103),'') + ' ' + isnull('al ' + CONVERT(VARCHAR, sessione.stop, 103),'') as dropdown_title
FROM [dbo].sessione WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].appellokind WITH (NOLOCK) ON sessione.idappellokind = [dbo].appellokind.idappellokind
LEFT OUTER JOIN [dbo].sessionekind WITH (NOLOCK) ON sessione.idsessionekind = [dbo].sessionekind.idsessionekind
WHERE  sessione.idsessione IS NOT NULL 
GO

-- VERIFICA DI sessionedefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sessionedefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sessionedefaultview','varchar(50)','ASSISTENZA','appellokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionedefaultview','varchar(132)','ASSISTENZA','dropdown_title','132','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionedefaultview','int','ASSISTENZA','idsessione','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sessionedefaultview','int','ASSISTENZA','idsessionekind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionedefaultview','datetime','ASSISTENZA','sessione_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionedefaultview','varchar(64)','ASSISTENZA','sessione_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sessionedefaultview','int','ASSISTENZA','sessione_idappellokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionedefaultview','datetime','ASSISTENZA','sessione_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionedefaultview','varchar(64)','ASSISTENZA','sessione_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sessionedefaultview','date','ASSISTENZA','sessione_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sessionedefaultview','date','ASSISTENZA','sessione_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sessionedefaultview','varchar(50)','ASSISTENZA','sessionekind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sessionedefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sessionedefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'sessionedefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sessionedefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

