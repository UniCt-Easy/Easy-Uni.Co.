
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


-- CREAZIONE VISTA bandodssegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandodssegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[bandodssegview]
GO

CREATE VIEW [dbo].[bandodssegview] AS 
SELECT  bandods.aa, bandods.ct AS bandods_ct, bandods.cu AS bandods_cu, bandods.description AS bandods_description, bandods.fondo AS bandods_fondo, bandods.idbandods, bandods.lt AS bandods_lt, bandods.lu AS bandods_lu, bandods.title,
 isnull('Titolo: ' + bandods.title + '; ','') as dropdown_title
FROM [dbo].bandods WITH (NOLOCK) 
WHERE  bandods.idbandods IS NOT NULL 
GO

-- VERIFICA DI bandodssegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'bandodssegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandodssegview','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodssegview','datetime','ASSISTENZA','bandods_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodssegview','varchar(64)','ASSISTENZA','bandods_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandodssegview','varchar(max)','ASSISTENZA','bandods_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandodssegview','varchar(1024)','ASSISTENZA','bandods_fondo','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodssegview','datetime','ASSISTENZA','bandods_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodssegview','varchar(64)','ASSISTENZA','bandods_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodssegview','varchar(1034)','ASSISTENZA','dropdown_title','1034','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodssegview','int','ASSISTENZA','idbandods','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandodssegview','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI bandodssegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'bandodssegview')
UPDATE customobject set isreal = 'N' where objectname = 'bandodssegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('bandodssegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

