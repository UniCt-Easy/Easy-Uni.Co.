
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


-- CREAZIONE VISTA requisitosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[requisitosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[requisitosegview]
GO

CREATE VIEW [dbo].[requisitosegview] AS 
SELECT CASE WHEN requisito.active = 'S' THEN 'Si' WHEN requisito.active = 'N' THEN 'No' END AS requisito_active, requisito.ct AS requisito_ct, requisito.cu AS requisito_cu, requisito.idrequisito, requisito.lt AS requisito_lt, requisito.lu AS requisito_lu, requisito.sortcode AS requisito_sortcode, requisito.title,
 isnull('Titolo: ' + requisito.title + '; ','') as dropdown_title
FROM [dbo].requisito WITH (NOLOCK) 
WHERE  requisito.idrequisito IS NOT NULL 
GO

-- VERIFICA DI requisitosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'requisitosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','requisitosegview','varchar(max)','ASSISTENZA','dropdown_title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','requisitosegview','int','ASSISTENZA','idrequisito','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','requisitosegview','varchar(2)','ASSISTENZA','requisito_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','requisitosegview','datetime','ASSISTENZA','requisito_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','requisitosegview','varchar(64)','ASSISTENZA','requisito_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','requisitosegview','datetime','ASSISTENZA','requisito_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','requisitosegview','varchar(64)','ASSISTENZA','requisito_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','requisitosegview','int','ASSISTENZA','requisito_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','requisitosegview','varchar(max)','ASSISTENZA','title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI requisitosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'requisitosegview')
UPDATE customobject set isreal = 'N' where objectname = 'requisitosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('requisitosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

