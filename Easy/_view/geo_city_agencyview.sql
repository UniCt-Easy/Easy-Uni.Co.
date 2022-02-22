
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


-- CREAZIONE VISTA geo_city_agencyview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_city_agencyview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_city_agencyview]
GO


CREATE VIEW [DBO].[geo_city_agencyview]
(
	idcity, 
	title,
	provincecode,
	newcity,
	oldcity,
	idagency,
	agencyname,
	agencywebsite,
	idcode,
	version,
	codename,
	value,
	start,
	stop
)
AS
SELECT
	geo_city_agency.idcity,
	geo_city.title, 
	geo_country.province,
	geo_city.newcity,
	geo_city.oldcity,
	geo_city_agency.idagency, 
	geo_agency.title,
	geo_agency.website,
	geo_city_agency.idcode, 
	geo_city_agency.version,
	geo_code.codename,
	geo_city_agency.value,
	geo_city_agency.start, 
	geo_city_agency.stop
FROM geo_code
JOIN geo_city_agency
	ON geo_code.idagency = geo_city_agency.idagency
	AND geo_code.idcode = geo_city_agency.idcode
JOIN geo_city
	ON geo_city_agency.idcity = geo_city.idcity
JOIN geo_agency
	ON geo_code.idagency = geo_agency.idagency
LEFT OUTER JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry




GO

-- VERIFICA DI geo_city_agencyview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_city_agencyview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','geo_city_agencyview','N','','50','agencyname','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(60)','N','geo_city_agencyview','N','','60','agencywebsite','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','geo_city_agencyview','N','','50','codename','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','geo_city_agencyview','S','','4','idagency','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','geo_city_agencyview','S','','4','idcity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','geo_city_agencyview','S','','4','idcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','geo_city_agencyview','N','','4','newcity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','geo_city_agencyview','N','','4','oldcity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(2)','N','geo_city_agencyview','N','','2','provincecode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_city_agencyview','N','','4','start','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_city_agencyview','N','','4','stop','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(65)','N','geo_city_agencyview','N','','65','title','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','geo_city_agencyview','N','','20','value','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','geo_city_agencyview','S','','4','version','')
GO

-- VERIFICA DI geo_city_agencyview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_city_agencyview')
UPDATE customobject set isreal = 'N' where objectname = 'geo_city_agencyview'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_city_agencyview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

