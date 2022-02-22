
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
-- CREAZIONE VISTA iscrizionebmiattachsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[iscrizionebmiattachsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[iscrizionebmiattachsegview]
GO

CREATE VIEW [dbo].[iscrizionebmiattachsegview] AS SELECT  iscrizionebmiattach.ct AS iscrizionebmiattach_ct, iscrizionebmiattach.cu AS iscrizionebmiattach_cu, allegatirichiesti.title AS allegatirichiesti_title, iscrizionebmiattach.idallegatirichiesti, attach.filename AS attach_filename, iscrizionebmiattach.idattach, iscrizionebmiattach.idbandomi, iscrizionebmi.idreg AS iscrizionebmi_idreg, iscrizionebmi.idbandomi AS iscrizionebmi_idbandomi, iscrizionebmi.idiscrizionebmi AS iscrizionebmi_idiscrizionebmi, iscrizionebmiattach.idiscrizionebmi, iscrizionebmiattach.idreg, iscrizionebmiattach.lt AS iscrizionebmiattach_lt, iscrizionebmiattach.lu AS iscrizionebmiattach_lu FROM iscrizionebmiattach WITH (NOLOCK)  LEFT OUTER JOIN allegatirichiesti WITH (NOLOCK) ON iscrizionebmiattach.idallegatirichiesti = allegatirichiesti.idallegatirichiesti LEFT OUTER JOIN attach WITH (NOLOCK) ON iscrizionebmiattach.idattach = attach.idattach LEFT OUTER JOIN iscrizionebmi WITH (NOLOCK) ON iscrizionebmiattach.idiscrizionebmi = iscrizionebmi.idiscrizionebmi WHERE  iscrizionebmiattach.idattach IS NOT NULL  AND iscrizionebmiattach.idbandomi IS NOT NULL  AND iscrizionebmiattach.idiscrizionebmi IS NOT NULL  AND iscrizionebmiattach.idreg IS NOT NULL 
GO

-- VERIFICA DI iscrizionebmiattachsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'iscrizionebmiattachsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmiattachsegview','varchar(max)','ASSISTENZA','allegatirichiesti_title','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmiattachsegview','varchar(512)','ASSISTENZA','attach_filename','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmiattachsegview','int','ASSISTENZA','idallegatirichiesti','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmiattachsegview','int','ASSISTENZA','idattach','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmiattachsegview','int','ASSISTENZA','idbandomi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmiattachsegview','int','ASSISTENZA','idiscrizionebmi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmiattachsegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmiattachsegview','int','ASSISTENZA','iscrizionebmi_idbandomi','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmiattachsegview','int','ASSISTENZA','iscrizionebmi_idiscrizionebmi','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionebmiattachsegview','int','ASSISTENZA','iscrizionebmi_idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmiattachsegview','datetime','ASSISTENZA','iscrizionebmiattach_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmiattachsegview','varchar(64)','ASSISTENZA','iscrizionebmiattach_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmiattachsegview','datetime','ASSISTENZA','iscrizionebmiattach_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionebmiattachsegview','varchar(64)','ASSISTENZA','iscrizionebmiattach_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI iscrizionebmiattachsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'iscrizionebmiattachsegview')
UPDATE customobject set isreal = 'N' where objectname = 'iscrizionebmiattachsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('iscrizionebmiattachsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

