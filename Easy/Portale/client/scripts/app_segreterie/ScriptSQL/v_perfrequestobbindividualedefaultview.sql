
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


-- CREAZIONE VISTA perfrequestobbindividualedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfrequestobbindividualedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfrequestobbindividualedefaultview]
GO

CREATE VIEW [dbo].[perfrequestobbindividualedefaultview] AS 
SELECT  perfrequestobbindividuale.ct AS perfrequestobbindividuale_ct, perfrequestobbindividuale.cu AS perfrequestobbindividuale_cu, perfrequestobbindividuale.description AS perfrequestobbindividuale_description, perfrequestobbindividuale.idperfrequestobbindividuale,
 [dbo].registry.title AS registry_title, perfrequestobbindividuale.idreg,CASE WHEN perfrequestobbindividuale.inserito = 'S' THEN 'Si' WHEN perfrequestobbindividuale.inserito = 'N' THEN 'No' END AS perfrequestobbindividuale_inserito, perfrequestobbindividuale.lt AS perfrequestobbindividuale_lt, perfrequestobbindividuale.lu AS perfrequestobbindividuale_lu, perfrequestobbindividuale.peso AS perfrequestobbindividuale_peso, perfrequestobbindividuale.title,
 [dbo].year.year AS year_year, perfrequestobbindividuale.year AS perfrequestobbindividuale_year,
 isnull('Titolo obiettivo: ' + perfrequestobbindividuale.title + '; ','') as dropdown_title
FROM [dbo].perfrequestobbindividuale WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON perfrequestobbindividuale.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].year WITH (NOLOCK) ON perfrequestobbindividuale.year = [dbo].year.year
WHERE  perfrequestobbindividuale.idperfrequestobbindividuale IS NOT NULL  AND perfrequestobbindividuale.idreg IS NOT NULL 
GO

-- VERIFICA DI perfrequestobbindividualedefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfrequestobbindividualedefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbindividualedefaultview','varchar(1044)','ASSISTENZA','dropdown_title','1044','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbindividualedefaultview','int','ASSISTENZA','idperfrequestobbindividuale','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbindividualedefaultview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbindividualedefaultview','datetime','','perfrequestobbindividuale_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbindividualedefaultview','varchar(64)','','perfrequestobbindividuale_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbindividualedefaultview','varchar(max)','ASSISTENZA','perfrequestobbindividuale_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbindividualedefaultview','varchar(2)','ASSISTENZA','perfrequestobbindividuale_inserito','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbindividualedefaultview','datetime','','perfrequestobbindividuale_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbindividualedefaultview','varchar(64)','','perfrequestobbindividuale_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbindividualedefaultview','decimal(19,2)','ASSISTENZA','perfrequestobbindividuale_peso','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbindividualedefaultview','int','','perfrequestobbindividuale_year','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbindividualedefaultview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbindividualedefaultview','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbindividualedefaultview','int','ASSISTENZA','year_year','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI perfrequestobbindividualedefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfrequestobbindividualedefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'perfrequestobbindividualedefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfrequestobbindividualedefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

