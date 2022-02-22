
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
-- CREAZIONE VISTA costoscontodefkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[costoscontodefkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[costoscontodefkinddefaultview]
GO

CREATE VIEW [dbo].[costoscontodefkinddefaultview] AS SELECT CASE WHEN costoscontodefkind.active = 'S' THEN 'Si' WHEN costoscontodefkind.active = 'N' THEN 'No' END AS costoscontodefkind_active, costoscontodefkind.ct AS costoscontodefkind_ct, costoscontodefkind.cu AS costoscontodefkind_cu, costoscontodefkind.description AS costoscontodefkind_description, costoscontodefkind.idcostoscontodefkind, costoscontodefkind.lt AS costoscontodefkind_lt, costoscontodefkind.lu AS costoscontodefkind_lu, costoscontodefkind.sortcode AS costoscontodefkind_sortcode, costoscontodefkind.title, isnull('Tipologia: ' + costoscontodefkind.title + '; ','') as dropdown_title FROM [dbo].costoscontodefkind WITH (NOLOCK)  WHERE  costoscontodefkind.idcostoscontodefkind IS NOT NULL 
GO

-- VERIFICA DI costoscontodefkinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'costoscontodefkinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefkinddefaultview','varchar(2)','ASSISTENZA','costoscontodefkind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefkinddefaultview','datetime','ASSISTENZA','costoscontodefkind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefkinddefaultview','varchar(64)','ASSISTENZA','costoscontodefkind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefkinddefaultview','varchar(256)','ASSISTENZA','costoscontodefkind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefkinddefaultview','datetime','ASSISTENZA','costoscontodefkind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefkinddefaultview','varchar(64)','ASSISTENZA','costoscontodefkind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefkinddefaultview','int','ASSISTENZA','costoscontodefkind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefkinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefkinddefaultview','int','ASSISTENZA','idcostoscontodefkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefkinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI costoscontodefkinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'costoscontodefkinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'costoscontodefkinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('costoscontodefkinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER costoscontodefkinddefaultview --
-- FINE GENERAZIONE SCRIPT --

