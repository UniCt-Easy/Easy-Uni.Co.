
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
-- CREAZIONE VISTA atecodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[atecodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[atecodefaultview]
GO

CREATE VIEW [dbo].[atecodefaultview] AS SELECT  ateco.codice, ateco.idateco, ateco.lt AS ateco_lt, ateco.lu AS ateco_lu, ateco.title AS ateco_title, isnull('Codice: ' + ateco.codice + '; ','') + ' ' + isnull('Titolo: ' + ateco.title + '; ','') as dropdown_title FROM [dbo].ateco WITH (NOLOCK)  WHERE  ateco.idateco IS NOT NULL 
GO

-- VERIFICA DI atecodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'atecodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','atecodefaultview','datetime','ASSISTENZA','ateco_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','atecodefaultview','varchar(64)','ASSISTENZA','ateco_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','atecodefaultview','varchar(255)','ASSISTENZA','ateco_title','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','atecodefaultview','varchar(50)','ASSISTENZA','codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','atecodefaultview','varchar(326)','ASSISTENZA','dropdown_title','326','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','atecodefaultview','int','ASSISTENZA','idateco','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI atecodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'atecodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'atecodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('atecodefaultview', 'N')
GO

-- GENERAZIONE DATI PER atecodefaultview --
-- FINE GENERAZIONE SCRIPT --

