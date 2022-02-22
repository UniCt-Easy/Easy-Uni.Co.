
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
-- CREAZIONE VISTA appelloerogataview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appelloerogataview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[appelloerogataview]
GO

CREATE VIEW [dbo].[appelloerogataview] AS SELECT  appello.aa, appello.basevoto AS appello_basevoto, appello.cftoend AS appello_cftoend, appello.ct AS appello_ct, appello.cu AS appello_cu, appello.description, appello.esteroend AS appello_esteroend, appello.esterostart AS appello_esterostart, appello.idappello, [dbo].appelloazionekind.title AS appelloazionekind_title, appello.idappelloazionekind AS appello_idappelloazionekind, [dbo].appellokind.title AS appellokind_title, appello.idappellokind AS appello_idappellokind, [dbo].sessionekind.title AS sessionekind_title, [dbo].sessione.start AS sessione_start, [dbo].sessione.stop AS sessione_stop, appello.idsessione, [dbo].studprenotkind.title AS studprenotkind_title, appello.idstudprenotkind AS appello_idstudprenotkind,CASE WHEN appello.lavoratori = 'S' THEN 'Si' WHEN appello.lavoratori = 'N' THEN 'No' END AS appello_lavoratori, appello.lt AS appello_lt, appello.lu AS appello_lu, appello.minanniiscr AS appello_minanniiscr, appello.minvoto AS appello_minvoto,CASE WHEN appello.passaggio = 'S' THEN 'Si' WHEN appello.passaggio = 'N' THEN 'No' END AS appello_passaggio, appello.penotend AS appello_penotend, appello.posti AS appello_posti, appello.prenotstart AS appello_prenotstart,CASE WHEN appello.prointermedia = 'S' THEN 'Si' WHEN appello.prointermedia = 'N' THEN 'No' END AS appello_prointermedia,CASE WHEN appello.publicato = 'S' THEN 'Si' WHEN appello.publicato = 'N' THEN 'No' END AS appello_publicato, appello.surmanestop AS appello_surmanestop, appello.surnamestart AS appello_surnamestart, isnull('Descrizione: ' + appello.description + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].sessionekind.title + '; ','') + ' ' + isnull('Anno accademico: ' + appello.aa + '; ','') as dropdown_title FROM [dbo].appello WITH (NOLOCK)  LEFT OUTER JOIN [dbo].appelloazionekind WITH (NOLOCK) ON appello.idappelloazionekind = [dbo].appelloazionekind.idappelloazionekind LEFT OUTER JOIN [dbo].appellokind WITH (NOLOCK) ON appello.idappellokind = [dbo].appellokind.idappellokind LEFT OUTER JOIN [dbo].sessione WITH (NOLOCK) ON appello.idsessione = [dbo].sessione.idsessione LEFT OUTER JOIN [dbo].sessionekind WITH (NOLOCK) ON sessione.idsessionekind = [dbo].sessionekind.idsessionekind LEFT OUTER JOIN [dbo].studprenotkind WITH (NOLOCK) ON appello.idstudprenotkind = [dbo].studprenotkind.idstudprenotkind WHERE  appello.idappello IS NOT NULL 
GO

-- VERIFICA DI appelloerogataview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'appelloerogataview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','int','ASSISTENZA','appello_basevoto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','decimal(9,2)','ASSISTENZA','appello_cftoend','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloerogataview','datetime','ASSISTENZA','appello_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloerogataview','varchar(64)','ASSISTENZA','appello_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','date','ASSISTENZA','appello_esteroend','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','date','ASSISTENZA','appello_esterostart','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','int','ASSISTENZA','appello_idappelloazionekind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','int','ASSISTENZA','appello_idappellokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','int','ASSISTENZA','appello_idstudprenotkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(2)','ASSISTENZA','appello_lavoratori','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloerogataview','datetime','','appello_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloerogataview','varchar(64)','','appello_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','int','','appello_minanniiscr','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','int','','appello_minvoto','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(2)','','appello_passaggio','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','datetime','','appello_penotend','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','int','','appello_posti','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','datetime','','appello_prenotstart','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(2)','','appello_prointermedia','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(2)','','appello_publicato','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(50)','','appello_surmanestop','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(50)','','appello_surnamestart','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(50)','','appelloazionekind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(50)','','appellokind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(1024)','','description','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloerogataview','varchar(1142)','','dropdown_title','1142','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','appelloerogataview','int','','idappello','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','int','','idsessione','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','date','','sessione_start','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','date','','sessione_stop','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(50)','','sessionekind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','appelloerogataview','varchar(50)','','studprenotkind_title','50','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI appelloerogataview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'appelloerogataview')
UPDATE customobject set isreal = 'N' where objectname = 'appelloerogataview'
ELSE
INSERT INTO customobject (objectname, isreal) values('appelloerogataview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

