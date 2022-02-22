
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
-- CREAZIONE VISTA inventorytreesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inventorytreesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[inventorytreesegview]
GO

CREATE VIEW [dbo].[inventorytreesegview] AS SELECT  inventorytree.codeinv, inventorytree.ct AS inventorytree_ct, inventorytree.cu AS inventorytree_cu, inventorytree.description AS inventorytree_description, inventorytree.idaccmotivediscount AS inventorytree_idaccmotivediscount, [dbo].accmotive.codemotive AS accmotive_codemotive, [dbo].accmotive.title AS accmotive_title, inventorytree.idaccmotiveload, inventorytree.idaccmotivetransfer AS inventorytree_idaccmotivetransfer, inventorytree.idaccmotiveunload AS inventorytree_idaccmotiveunload, inventorytree.idinv, inventorytree.lookupcode AS inventorytree_lookupcode, inventorytree.lt AS inventorytree_lt, inventorytree.lu AS inventorytree_lu, inventorytree.nlevel AS inventorytree_nlevel, inventorytreeparent.codeinv AS inventorytreeparent_codeinv, inventorytreeparent.description AS inventorytreeparent_description, inventorytree.paridinv, inventorytree.rtf AS inventorytree_rtf, inventorytree.txt AS inventorytree_txt, isnull('Codice: ' + inventorytree.codeinv + '; ','') + ' ' + isnull('Denominazione: ' + inventorytree.description + '; ','') as dropdown_title FROM [dbo].inventorytree WITH (NOLOCK)  LEFT OUTER JOIN [dbo].accmotive WITH (NOLOCK) ON inventorytree.idaccmotiveload = [dbo].accmotive.idaccmotive LEFT OUTER JOIN [dbo].inventorytree AS inventorytreeparent WITH (NOLOCK) ON inventorytree.paridinv = inventorytreeparent.idinv WHERE  inventorytree.idinv IS NOT NULL 
GO

-- VERIFICA DI inventorytreesegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'inventorytreesegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','varchar(50)','','accmotive_codemotive','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','varchar(150)','','accmotive_title','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytreesegview','varchar(50)','','codeinv','50','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytreesegview','varchar(228)','ASSISTENZA','dropdown_title','228','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','varchar(36)','','idaccmotiveload','36','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytreesegview','int','ASSISTENZA','idinv','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytreesegview','datetime','ASSISTENZA','inventorytree_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytreesegview','varchar(64)','ASSISTENZA','inventorytree_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytreesegview','varchar(150)','','inventorytree_description','150','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','varchar(36)','ASSISTENZA','inventorytree_idaccmotivediscount','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','varchar(36)','ASSISTENZA','inventorytree_idaccmotivetransfer','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','varchar(36)','ASSISTENZA','inventorytree_idaccmotiveunload','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','varchar(50)','ASSISTENZA','inventorytree_lookupcode','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytreesegview','datetime','ASSISTENZA','inventorytree_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytreesegview','varchar(64)','ASSISTENZA','inventorytree_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytreesegview','tinyint','ASSISTENZA','inventorytree_nlevel','1','S','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','image','ASSISTENZA','inventorytree_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','text','ASSISTENZA','inventorytree_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','varchar(50)','ASSISTENZA','inventorytreeparent_codeinv','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','varchar(150)','ASSISTENZA','inventorytreeparent_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytreesegview','int','ASSISTENZA','paridinv','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI inventorytreesegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'inventorytreesegview')
UPDATE customobject set isreal = 'N' where objectname = 'inventorytreesegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('inventorytreesegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

