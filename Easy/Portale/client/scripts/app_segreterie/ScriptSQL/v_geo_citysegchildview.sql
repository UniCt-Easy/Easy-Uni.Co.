
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
-- CREAZIONE VISTA geo_citysegchildview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_citysegchildview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_citysegchildview]
GO

CREATE VIEW [dbo].[geo_citysegchildview] AS SELECT  geo_city.idcity, geo_city.idcountry AS geo_city_idcountry, geo_city.lt AS geo_city_lt, geo_city.lu AS geo_city_lu, geo_city_1.title AS geo_city_1_title, geo_city.newcity, geo_city_2.title AS geo_city_2_title, geo_city.oldcity, geo_city.start AS geo_city_start, geo_city.stop AS geo_city_stop, geo_city.title, isnull('Denominazione: ' + geo_city.title + '; ','') as dropdown_title FROM [dbo].geo_city WITH (NOLOCK)  LEFT OUTER JOIN [dbo].geo_city AS geo_city_1 WITH (NOLOCK) ON geo_city.newcity = geo_city_1.idcity LEFT OUTER JOIN [dbo].geo_city AS geo_city_2 WITH (NOLOCK) ON geo_city.oldcity = geo_city_2.idcity WHERE  geo_city.idcity IS NOT NULL 
GO

-- VERIFICA DI geo_citysegchildview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_citysegchildview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_citysegchildview','varchar(82)','ASSISTENZA','dropdown_title','82','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_citysegchildview','varchar(65)','ASSISTENZA','geo_city_1_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_citysegchildview','varchar(65)','ASSISTENZA','geo_city_2_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_citysegchildview','int','ASSISTENZA','geo_city_idcountry','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_citysegchildview','datetime','ASSISTENZA','geo_city_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_citysegchildview','varchar(64)','ASSISTENZA','geo_city_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_citysegchildview','date','ASSISTENZA','geo_city_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_citysegchildview','date','ASSISTENZA','geo_city_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_citysegchildview','int','ASSISTENZA','idcity','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_citysegchildview','int','ASSISTENZA','newcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_citysegchildview','int','ASSISTENZA','oldcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_citysegchildview','varchar(65)','ASSISTENZA','title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI geo_citysegchildview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_citysegchildview')
UPDATE customobject set isreal = 'N' where objectname = 'geo_citysegchildview'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_citysegchildview', 'N')
GO

-- GENERAZIONE DATI PER geo_citysegchildview --
-- FINE GENERAZIONE SCRIPT --

