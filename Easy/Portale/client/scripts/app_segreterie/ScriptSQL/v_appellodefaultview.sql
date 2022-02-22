
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


-- CREAZIONE VISTA appellodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appellodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[appellodefaultview]
GO

CREATE VIEW [dbo].[appellodefaultview] AS 
SELECT  appello.aa, appello.basevoto AS appello_basevoto, appello.cftoend AS appello_cftoend, appello.ct AS appello_ct, appello.cu AS appello_cu, appello.description, appello.esteroend AS appello_esteroend, appello.esterostart AS appello_esterostart, appello.idappello,
 [dbo].appelloazionekind.title AS appelloazionekind_title, appello.idappelloazionekind AS appello_idappelloazionekind,
 [dbo].appellokind.title AS appellokind_title, appello.idappellokind AS appello_idappellokind,
 [dbo].sessionekind.title AS sessionekind_title, [dbo].sessione.idsessionekind AS sessione_idsessionekind, [dbo].sessione.start AS sessione_start, [dbo].sessione.stop AS sessione_stop, appello.idsessione,
 [dbo].studprenotkind.title AS studprenotkind_title, appello.idstudprenotkind AS appello_idstudprenotkind,CASE WHEN appello.lavoratori = 'S' THEN 'Si' WHEN appello.lavoratori = 'N' THEN 'No' END AS appello_lavoratori, appello.lt AS appello_lt, appello.lu AS appello_lu, appello.minanniiscr AS appello_minanniiscr, appello.minvoto AS appello_minvoto,CASE WHEN appello.passaggio = 'S' THEN 'Si' WHEN appello.passaggio = 'N' THEN 'No' END AS appello_passaggio, appello.penotend AS appello_penotend, appello.posti AS appello_posti, appello.prenotstart AS appello_prenotstart,CASE WHEN appello.prointermedia = 'S' THEN 'Si' WHEN appello.prointermedia = 'N' THEN 'No' END AS appello_prointermedia,CASE WHEN appello.publicato = 'S' THEN 'Si' WHEN appello.publicato = 'N' THEN 'No' END AS appello_publicato, appello.surmanestop AS appello_surmanestop, appello.surnamestart AS appello_surnamestart,
 isnull('Descrizione: ' + appello.description + '; ','') + ' ' + isnull('Anno accademico: ' + appello.aa + '; ','') as dropdown_title
FROM [dbo].appello WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].appelloazionekind WITH (NOLOCK) ON appello.idappelloazionekind = [dbo].appelloazionekind.idappelloazionekind
LEFT OUTER JOIN [dbo].appellokind WITH (NOLOCK) ON appello.idappellokind = [dbo].appellokind.idappellokind
LEFT OUTER JOIN [dbo].sessione WITH (NOLOCK) ON appello.idsessione = [dbo].sessione.idsessione
LEFT OUTER JOIN [dbo].sessionekind WITH (NOLOCK) ON [dbo].sessione.idsessionekind = [dbo].sessionekind.idsessionekind
LEFT OUTER JOIN [dbo].studprenotkind WITH (NOLOCK) ON appello.idstudprenotkind = [dbo].studprenotkind.idstudprenotkind
WHERE  appello.idappello IS NOT NULL 
GO

-- VERIFICA DI appellodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'appellodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','int','ASSISTENZA','appello_basevoto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','decimal(9,2)','ASSISTENZA','appello_cftoend','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellodefaultview','datetime','ASSISTENZA','appello_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellodefaultview','varchar(64)','ASSISTENZA','appello_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','date','ASSISTENZA','appello_esteroend','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','date','ASSISTENZA','appello_esterostart','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','int','ASSISTENZA','appello_idappelloazionekind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','int','ASSISTENZA','appello_idappellokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','int','ASSISTENZA','appello_idstudprenotkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(2)','ASSISTENZA','appello_lavoratori','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellodefaultview','datetime','ASSISTENZA','appello_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellodefaultview','varchar(64)','ASSISTENZA','appello_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','int','ASSISTENZA','appello_minanniiscr','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','int','ASSISTENZA','appello_minvoto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(2)','ASSISTENZA','appello_passaggio','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','datetime','ASSISTENZA','appello_penotend','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','int','ASSISTENZA','appello_posti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','datetime','ASSISTENZA','appello_prenotstart','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(2)','ASSISTENZA','appello_prointermedia','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(2)','ASSISTENZA','appello_publicato','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(50)','ASSISTENZA','appello_surmanestop','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(50)','ASSISTENZA','appello_surnamestart','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(50)','ASSISTENZA','appelloazionekind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(50)','ASSISTENZA','appellokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(1024)','ASSISTENZA','description','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellodefaultview','varchar(1068)','ASSISTENZA','dropdown_title','1068','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appellodefaultview','int','ASSISTENZA','idappello','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','int','ASSISTENZA','idsessione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','int','','sessione_idsessionekind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','date','ASSISTENZA','sessione_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','date','ASSISTENZA','sessione_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(50)','','sessionekind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appellodefaultview','varchar(50)','ASSISTENZA','studprenotkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI appellodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'appellodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'appellodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('appellodefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

