
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
-- CREAZIONE VISTA ccnldefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ccnldefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ccnldefaultview]
GO

CREATE VIEW [dbo].[ccnldefaultview] AS SELECT CASE WHEN ccnl.active = 'S' THEN 'Si' WHEN ccnl.active = 'N' THEN 'No' END AS ccnl_active, ccnl.area AS ccnl_area, ccnl.contraenti AS ccnl_contraenti, ccnl.ct AS ccnl_ct, ccnl.cu AS ccnl_cu, ccnl.decorrenza AS ccnl_decorrenza, ccnl.idccnl, ccnl.lt AS ccnl_lt, ccnl.lu AS ccnl_lu, ccnl.scadec AS ccnl_scadec, ccnl.scadenza AS ccnl_scadenza, ccnl.sortcode AS ccnl_sortcode, ccnl.stipula AS ccnl_stipula, ccnl.title, isnull('Denominazione: ' + ccnl.title + '; ','') as dropdown_title FROM [dbo].ccnl WITH (NOLOCK)  WHERE  ccnl.idccnl IS NOT NULL 
GO

-- VERIFICA DI ccnldefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'ccnldefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ccnldefaultview','varchar(2)','ASSISTENZA','ccnl_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','nvarchar(50)','ASSISTENZA','ccnl_area','50','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','nvarchar(1050)','ASSISTENZA','ccnl_contraenti','1050','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','datetime','ASSISTENZA','ccnl_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','nvarchar(64)','ASSISTENZA','ccnl_cu','64','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ccnldefaultview','date','ASSISTENZA','ccnl_decorrenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','datetime','ASSISTENZA','ccnl_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','nvarchar(64)','ASSISTENZA','ccnl_lu','64','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ccnldefaultview','date','ASSISTENZA','ccnl_scadec','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ccnldefaultview','date','ASSISTENZA','ccnl_scadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','int','ASSISTENZA','ccnl_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','date','ASSISTENZA','ccnl_stipula','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','nvarchar(167)','ASSISTENZA','dropdown_title','167','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','int','ASSISTENZA','idccnl','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ccnldefaultview','nvarchar(150)','ASSISTENZA','title','150','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI ccnldefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'ccnldefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'ccnldefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('ccnldefaultview', 'N')
GO

-- GENERAZIONE DATI PER ccnldefaultview --
-- FINE GENERAZIONE SCRIPT --

