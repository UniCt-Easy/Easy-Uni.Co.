
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


-- CREAZIONE VISTA edificioseg_childview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[edificioseg_childview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[edificioseg_childview]
GO



CREATE VIEW [dbo].[edificioseg_childview] AS SELECT  edificio.address AS edificio_address, edificio.cap AS edificio_cap, edificio.code AS edificio_code, edificio.ct AS edificio_ct, edificio.cu AS edificio_cu, [dbo].geo_city.title AS geo_city_title, edificio.idcity, edificio.idedificio, [dbo].geo_nation.title AS geo_nation_title, edificio.idnation, edificio.idsede, edificio.latitude AS edificio_latitude, edificio.location AS edificio_location, edificio.longitude AS edificio_longitude, edificio.lt AS edificio_lt, edificio.lu AS edificio_lu, edificio.title, isnull('Denominazione: ' + edificio.title + '; ','') as dropdown_title FROM [dbo].edificio WITH (NOLOCK)  LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON edificio.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON edificio.idnation = [dbo].geo_nation.idnation WHERE  edificio.idedificio IS NOT NULL  AND edificio.idsede IS NOT NULL 

GO

-- VERIFICA DI edificioseg_childview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'edificioseg_childview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificioseg_childview','varchar(1041)','ASSISTENZA','dropdown_title','1041','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','varchar(100)','ASSISTENZA','edificio_address','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','varchar(20)','ASSISTENZA','edificio_cap','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','varchar(128)','ASSISTENZA','edificio_code','128','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificioseg_childview','datetime','ASSISTENZA','edificio_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificioseg_childview','varchar(64)','ASSISTENZA','edificio_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','float','ASSISTENZA','edificio_latitude','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','varchar(20)','ASSISTENZA','edificio_location','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','float','ASSISTENZA','edificio_longitude','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificioseg_childview','datetime','ASSISTENZA','edificio_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificioseg_childview','varchar(64)','ASSISTENZA','edificio_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','varchar(65)','ASSISTENZA','geo_city_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificioseg_childview','int','ASSISTENZA','idedificio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','edificioseg_childview','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','edificioseg_childview','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI edificioseg_childview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'edificioseg_childview')
UPDATE customobject set isreal = 'N' where objectname = 'edificioseg_childview'
ELSE
INSERT INTO customobject (objectname, isreal) values('edificioseg_childview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --
