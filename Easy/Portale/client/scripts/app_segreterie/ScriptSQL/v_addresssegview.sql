
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA addresssegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[addresssegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[addresssegview]
GO

CREATE VIEW [dbo].[addresssegview] AS 
SELECT CASE WHEN address.active = 'S' THEN 'Si' WHEN address.active = 'N' THEN 'No' END AS address_active, address.codeaddress AS address_codeaddress, address.description, address.idaddress, address.lt AS address_lt, address.lu AS address_lu,
 isnull('Descrizione: ' + address.description + '; ','') as dropdown_title
FROM [dbo].address WITH (NOLOCK) 
WHERE  address.active = 'S' AND address.idaddress IS NOT NULL 
GO

-- VERIFICA DI addresssegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'addresssegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','addresssegview','varchar(2)','ASSISTENZA','address_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','addresssegview','varchar(20)','ASSISTENZA','address_codeaddress','20','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','addresssegview','datetime','ASSISTENZA','address_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','addresssegview','varchar(64)','ASSISTENZA','address_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','addresssegview','varchar(60)','ASSISTENZA','description','60','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','addresssegview','varchar(75)','ASSISTENZA','dropdown_title','75','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','addresssegview','int','ASSISTENZA','idaddress','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI addresssegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'addresssegview')
UPDATE customobject set isreal = 'N' where objectname = 'addresssegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('addresssegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --
