
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
-- CREAZIONE VISTA tassacsingconfdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tassacsingconfdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tassacsingconfdefaultview]
GO



CREATE VIEW [dbo].[tassacsingconfdefaultview] AS SELECT  tassacsingconf.aa, tassacsingconf.costomax AS tassacsingconf_costomax, tassacsingconf.ct AS tassacsingconf_ct, tassacsingconf.cu AS tassacsingconf_cu, [dbo].costoscontodef.title AS costoscontodef_title, tassacsingconf.idcostoscontodef, costoscontodef2.title AS costoscontodef2_title, tassacsingconf.idcostoscontodef_2, costoscontodefsconto.title AS costoscontodefsconto_title, tassacsingconf.idcostoscontodef_sconto, tassacsingconf.idtassacsingconf, tassacsingconf.lt AS tassacsingconf_lt, tassacsingconf.lu AS tassacsingconf_lu, tassacsingconf.numerosconto AS tassacsingconf_numerosconto, isnull('Costo: ' + [dbo].costoscontodef.title + '; ','') as dropdown_title FROM [dbo].tassacsingconf WITH (NOLOCK)  LEFT OUTER JOIN [dbo].costoscontodef WITH (NOLOCK) ON tassacsingconf.idcostoscontodef = [dbo].costoscontodef.idcostoscontodef LEFT OUTER JOIN [dbo].costoscontodef AS costoscontodef2 WITH (NOLOCK) ON tassacsingconf.idcostoscontodef_2 = costoscontodef2.idcostoscontodef LEFT OUTER JOIN [dbo].costoscontodef AS costoscontodefsconto WITH (NOLOCK) ON tassacsingconf.idcostoscontodef_sconto = costoscontodefsconto.idcostoscontodef WHERE  tassacsingconf.idtassacsingconf IS NOT NULL 

GO

-- VERIFICA DI tassacsingconfdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tassacsingconfdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconfdefaultview','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconfdefaultview','nvarchar(2024)','ASSISTENZA','costoscontodef_title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconfdefaultview','nvarchar(2024)','ASSISTENZA','costoscontodef2_title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconfdefaultview','nvarchar(2024)','ASSISTENZA','costoscontodefsconto_title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconfdefaultview','nvarchar(2033)','ASSISTENZA','dropdown_title','2033','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconfdefaultview','int','ASSISTENZA','idcostoscontodef','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconfdefaultview','int','ASSISTENZA','idcostoscontodef_2','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconfdefaultview','int','ASSISTENZA','idcostoscontodef_sconto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconfdefaultview','int','ASSISTENZA','idtassacsingconf','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconfdefaultview','decimal(9,2)','ASSISTENZA','tassacsingconf_costomax','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconfdefaultview','datetime','ASSISTENZA','tassacsingconf_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconfdefaultview','varchar(64)','ASSISTENZA','tassacsingconf_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconfdefaultview','datetime','ASSISTENZA','tassacsingconf_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconfdefaultview','varchar(64)','ASSISTENZA','tassacsingconf_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconfdefaultview','int','ASSISTENZA','tassacsingconf_numerosconto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tassacsingconfdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tassacsingconfdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'tassacsingconfdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('tassacsingconfdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

