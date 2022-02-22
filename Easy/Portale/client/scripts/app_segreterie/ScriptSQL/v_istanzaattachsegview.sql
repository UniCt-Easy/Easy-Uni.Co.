
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
-- CREAZIONE VISTA istanzaattachsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzaattachsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzaattachsegview]
GO

CREATE VIEW [dbo].[istanzaattachsegview] AS SELECT  istanzaattach.ct AS istanzaattach_ct, istanzaattach.cu AS istanzaattach_cu, [dbo].attach.attachment AS attach_attachment, [dbo].attach.counter AS attach_counter, [dbo].attach.ct AS attach_ct, [dbo].attach.cu AS attach_cu, [dbo].attach.filename AS attach_filename, [dbo].attach.hash AS attach_hash, [dbo].attach.idattach AS attach_idattach, [dbo].attach.lt AS attach_lt, [dbo].attach.lu AS attach_lu, [dbo].attach.size AS attach_size, istanzaattach.idattach, istanzaattach.idistanza, istanzaattach.idistanzakind, istanzaattach.idreg, istanzaattach.lt AS istanzaattach_lt, istanzaattach.lu AS istanzaattach_lu FROM [dbo].istanzaattach WITH (NOLOCK)  LEFT OUTER JOIN [dbo].attach WITH (NOLOCK) ON istanzaattach.idattach = [dbo].attach.idattach WHERE  istanzaattach.idattach IS NOT NULL  AND istanzaattach.idistanza IS NOT NULL  AND istanzaattach.idistanzakind =9 AND istanzaattach.idistanzakind IS NOT NULL  AND istanzaattach.idreg IS NOT NULL 
GO

-- VERIFICA DI istanzaattachsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'istanzaattachsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzaattachsegview','image','ASSISTENZA','attach_attachment','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzaattachsegview','int','ASSISTENZA','attach_counter','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzaattachsegview','datetime','ASSISTENZA','attach_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzaattachsegview','varchar(64)','ASSISTENZA','attach_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzaattachsegview','varchar(512)','ASSISTENZA','attach_filename','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzaattachsegview','varchar(max)','ASSISTENZA','attach_hash','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzaattachsegview','int','ASSISTENZA','attach_idattach','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzaattachsegview','datetime','ASSISTENZA','attach_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzaattachsegview','varchar(64)','ASSISTENZA','attach_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzaattachsegview','bigint','ASSISTENZA','attach_size','8','N','bigint','System.Int64','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzaattachsegview','int','ASSISTENZA','idattach','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzaattachsegview','int','ASSISTENZA','idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzaattachsegview','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzaattachsegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzaattachsegview','datetime','ASSISTENZA','istanzaattach_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzaattachsegview','varchar(64)','ASSISTENZA','istanzaattach_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzaattachsegview','datetime','ASSISTENZA','istanzaattach_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzaattachsegview','varchar(64)','ASSISTENZA','istanzaattach_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI istanzaattachsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'istanzaattachsegview')
UPDATE customobject set isreal = 'N' where objectname = 'istanzaattachsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('istanzaattachsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

