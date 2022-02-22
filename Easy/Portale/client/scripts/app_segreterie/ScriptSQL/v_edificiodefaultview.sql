
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


-- CREAZIONE VISTA edificiodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[edificiodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[edificiodefaultview]
GO

CREATE VIEW [dbo].[edificiodefaultview] AS 
SELECT  edificio.address AS edificio_address, edificio.cap AS edificio_cap, edificio.code AS edificio_code, edificio.ct AS edificio_ct, edificio.cu AS edificio_cu,
 [dbo].geo_city.title AS geo_city_title, edificio.idcity, edificio.idedificio,
 [dbo].geo_nation.title AS geo_nation_title, edificio.idnation,
 [dbo].sede.title AS sede_title, edificio.idsede, edificio.latitude AS edificio_latitude, edificio.location AS edificio_location, edificio.longitude AS edificio_longitude, edificio.lt AS edificio_lt, edificio.lu AS edificio_lu, edificio.title,
 isnull('Denominazione: ' + edificio.title + '; ','') as dropdown_title
FROM [dbo].edificio WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON edificio.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON edificio.idnation = [dbo].geo_nation.idnation
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON edificio.idsede = [dbo].sede.idsede
WHERE  edificio.idedificio IS NOT NULL  AND edificio.idsede IS NOT NULL 
GO

-- VERIFICA DI edificiodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'edificiodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificiodefaultview','varchar(1041)','ASSISTENZA','dropdown_title','1041','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','varchar(100)','ASSISTENZA','edificio_address','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','varchar(20)','ASSISTENZA','edificio_cap','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','varchar(128)','ASSISTENZA','edificio_code','128','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificiodefaultview','datetime','ASSISTENZA','edificio_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificiodefaultview','varchar(64)','ASSISTENZA','edificio_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','float','ASSISTENZA','edificio_latitude','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','varchar(20)','ASSISTENZA','edificio_location','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','float','ASSISTENZA','edificio_longitude','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificiodefaultview','datetime','ASSISTENZA','edificio_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificiodefaultview','varchar(64)','ASSISTENZA','edificio_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','varchar(65)','ASSISTENZA','geo_city_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificiodefaultview','int','ASSISTENZA','idedificio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificiodefaultview','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','nvarchar(1024)','ASSISTENZA','sede_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificiodefaultview','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI edificiodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'edificiodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'edificiodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('edificiodefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

