
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


-- CREAZIONE VISTA sasdintegrandiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasdintegrandiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sasdintegrandiview]
GO

CREATE VIEW [dbo].[sasdintegrandiview] AS 
SELECT  sasd.codice, sasd.codice_old AS sasd_codice_old,
 [dbo].areadidattica.title AS areadidattica_title, sasd.idareadidattica, sasd.idsasd, sasd.lt AS sasd_lt, sasd.lu AS sasd_lu, sasd.title AS sasd_title,
 isnull('Codice: ' + sasd.codice + '; ','') + ' ' + isnull('Denominazione: ' + sasd.title + '; ','') as dropdown_title
FROM [dbo].sasd WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].areadidattica WITH (NOLOCK) ON sasd.idareadidattica = [dbo].areadidattica.idareadidattica
WHERE  sasd.idsasd IS NOT NULL 
GO

-- VERIFICA DI sasdintegrandiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sasdintegrandiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasdintegrandiview','varchar(100)','ASSISTENZA','areadidattica_title','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdintegrandiview','varchar(50)','ASSISTENZA','codice','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdintegrandiview','varchar(333)','ASSISTENZA','dropdown_title','333','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasdintegrandiview','int','ASSISTENZA','idareadidattica','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdintegrandiview','int','ASSISTENZA','idsasd','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasdintegrandiview','varchar(4)','ASSISTENZA','sasd_codice_old','4','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasdintegrandiview','datetime','ASSISTENZA','sasd_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sasdintegrandiview','varchar(64)','ASSISTENZA','sasd_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdintegrandiview','varchar(255)','ASSISTENZA','sasd_title','255','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sasdintegrandiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sasdintegrandiview')
UPDATE customobject set isreal = 'N' where objectname = 'sasdintegrandiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sasdintegrandiview', 'N')
GO

-- GENERAZIONE DATI PER sasdintegrandiview --
-- FINE GENERAZIONE SCRIPT --

