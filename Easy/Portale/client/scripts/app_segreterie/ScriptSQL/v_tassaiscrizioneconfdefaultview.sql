
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
-- CREAZIONE VISTA tassaiscrizioneconfdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tassaiscrizioneconfdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tassaiscrizioneconfdefaultview]
GO

CREATE VIEW [dbo].[tassaiscrizioneconfdefaultview] AS SELECT  tassaiscrizioneconf.aa, tassaiscrizioneconf.aamax, tassaiscrizioneconf.aamin, tassaiscrizioneconf.annofcmax AS tassaiscrizioneconf_annofcmax, tassaiscrizioneconf.annofcmin AS tassaiscrizioneconf_annofcmin, tassaiscrizioneconf.annomax AS tassaiscrizioneconf_annomax, tassaiscrizioneconf.annomin AS tassaiscrizioneconf_annomin, tassaiscrizioneconf.codice_corsostudio AS tassaiscrizioneconf_codice_corsostudio, tassaiscrizioneconf.codice_didprog AS tassaiscrizioneconf_codice_didprog, tassaiscrizioneconf.codice_didprogcurr AS tassaiscrizioneconf_codice_didprogcurr, tassaiscrizioneconf.codice_didprogori AS tassaiscrizioneconf_codice_didprogori,CASE WHEN tassaiscrizioneconf.corsisingoli = 'S' THEN 'Si' WHEN tassaiscrizioneconf.corsisingoli = 'N' THEN 'No' END AS tassaiscrizioneconf_corsisingoli, tassaiscrizioneconf.ct AS tassaiscrizioneconf_ct, tassaiscrizioneconf.cu AS tassaiscrizioneconf_cu, [dbo].costoscontodef.title AS costoscontodef_title, tassaiscrizioneconf.idcostoscontodef, tassaiscrizioneconf.idtassaiscrizioneconf, tassaiscrizioneconf.lt AS tassaiscrizioneconf_lt, tassaiscrizioneconf.lu AS tassaiscrizioneconf_lu, tassaiscrizioneconf.title, isnull('Title: ' + tassaiscrizioneconf.title + '; ','') as dropdown_title FROM [dbo].tassaiscrizioneconf WITH (NOLOCK)  LEFT OUTER JOIN [dbo].costoscontodef WITH (NOLOCK) ON tassaiscrizioneconf.idcostoscontodef = [dbo].costoscontodef.idcostoscontodef WHERE  tassaiscrizioneconf.idtassaiscrizioneconf IS NOT NULL 
GO

-- VERIFICA DI tassaiscrizioneconfdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tassaiscrizioneconfdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconfdefaultview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','varchar(9)','ASSISTENZA','aamax','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','varchar(9)','ASSISTENZA','aamin','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','nvarchar(2024)','ASSISTENZA','costoscontodef_title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconfdefaultview','varchar(2033)','ASSISTENZA','dropdown_title','2033','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','int','ASSISTENZA','idcostoscontodef','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconfdefaultview','int','ASSISTENZA','idtassaiscrizioneconf','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','int','ASSISTENZA','tassaiscrizioneconf_annofcmax','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','int','ASSISTENZA','tassaiscrizioneconf_annofcmin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','int','ASSISTENZA','tassaiscrizioneconf_annomax','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','int','ASSISTENZA','tassaiscrizioneconf_annomin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','varchar(50)','ASSISTENZA','tassaiscrizioneconf_codice_corsostudio','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','varchar(50)','ASSISTENZA','tassaiscrizioneconf_codice_didprog','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','varchar(50)','ASSISTENZA','tassaiscrizioneconf_codice_didprogcurr','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','varchar(50)','ASSISTENZA','tassaiscrizioneconf_codice_didprogori','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconfdefaultview','varchar(2)','ASSISTENZA','tassaiscrizioneconf_corsisingoli','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconfdefaultview','datetime','ASSISTENZA','tassaiscrizioneconf_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconfdefaultview','varchar(64)','ASSISTENZA','tassaiscrizioneconf_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconfdefaultview','datetime','ASSISTENZA','tassaiscrizioneconf_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconfdefaultview','varchar(64)','ASSISTENZA','tassaiscrizioneconf_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconfdefaultview','varchar(2024)','ASSISTENZA','title','2024','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tassaiscrizioneconfdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tassaiscrizioneconfdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'tassaiscrizioneconfdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('tassaiscrizioneconfdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

