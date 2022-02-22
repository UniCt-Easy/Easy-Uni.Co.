
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
-- CREAZIONE VISTA geo_countrysegchildview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_countrysegchildview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_countrysegchildview]
GO

CREATE VIEW [dbo].[geo_countrysegchildview] AS SELECT  geo_country.idcountry, geo_country.idregion AS geo_country_idregion, geo_country.lt AS geo_country_lt, geo_country.lu AS geo_country_lu, geo_country_1.title AS geo_country_1_title, geo_country.newcountry, geo_country_2.title AS geo_country_2_title, geo_country.oldcountry, geo_country.province AS geo_country_province, geo_country.start AS geo_country_start, geo_country.stop AS geo_country_stop, geo_country.title, isnull('Denominazione: ' + geo_country.title + '; ','') as dropdown_title FROM [dbo].geo_country WITH (NOLOCK)  LEFT OUTER JOIN [dbo].geo_country AS geo_country_1 WITH (NOLOCK) ON geo_country.newcountry = geo_country_1.idcountry LEFT OUTER JOIN [dbo].geo_country AS geo_country_2 WITH (NOLOCK) ON geo_country.oldcountry = geo_country_2.idcountry WHERE  geo_country.idcountry IS NOT NULL 
GO

-- VERIFICA DI geo_countrysegchildview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_countrysegchildview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_countrysegchildview','varchar(67)','ASSISTENZA','dropdown_title','67','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','varchar(50)','ASSISTENZA','geo_country_1_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','varchar(50)','ASSISTENZA','geo_country_2_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','int','ASSISTENZA','geo_country_idregion','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','datetime','ASSISTENZA','geo_country_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','varchar(64)','ASSISTENZA','geo_country_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','char(2)','ASSISTENZA','geo_country_province','2','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','date','ASSISTENZA','geo_country_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','date','ASSISTENZA','geo_country_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_countrysegchildview','int','ASSISTENZA','idcountry','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','int','ASSISTENZA','newcountry','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','int','ASSISTENZA','oldcountry','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_countrysegchildview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI geo_countrysegchildview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_countrysegchildview')
UPDATE customobject set isreal = 'N' where objectname = 'geo_countrysegchildview'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_countrysegchildview', 'N')
GO

-- GENERAZIONE DATI PER geo_countrysegchildview --
-- FINE GENERAZIONE SCRIPT --

