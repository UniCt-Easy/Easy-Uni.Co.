-- CREAZIONE VISTA geo_cityfiscalview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_cityfiscalview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_cityfiscalview]
GO


CREATE VIEW [DBO].geo_cityfiscalview
(
	idcity,
	city,
	idcountry,
	provincecode,
	idregion,
	region,
	idfiscaltaxregion,
	newcity,
	oldcity,
	start,
	stop,
	lt,
	lu
)
AS SELECT
	geo_city.idcity,
	geo_city.title,
	geo_city.idcountry,
	geo_country.province,
	geo_country.idregion,
	geo_region.title,
	ISNULL(fc.idfiscaltaxregion, fr.idfiscaltaxregion),
	geo_city.newcity,
	geo_city.oldcity,
	geo_city.start,
	geo_city.stop,
	geo_city.lt,
	geo_city.lu
FROM geo_city
JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry
JOIN geo_region
	ON geo_region.idregion = geo_country.idregion
LEFT OUTER JOIN fiscaltaxregion fr
	ON fr.idregion = geo_region.idregion
LEFT OUTER JOIN fiscaltaxregion fc
	ON fc.idcountry = geo_city.idcountry


GO

-- VERIFICA DI geo_cityfiscalview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_cityfiscalview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(65)','N','geo_cityfiscalview','N','','65','city','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','geo_cityfiscalview','S','','4','idcity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','geo_cityfiscalview','N','','4','idcountry','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(5)','N','geo_cityfiscalview','N','','5','idfiscaltaxregion','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','geo_cityfiscalview','N','','4','idregion','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','geo_cityfiscalview','N','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(64)','N','geo_cityfiscalview','N','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','geo_cityfiscalview','N','','4','newcity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','geo_cityfiscalview','N','','4','oldcity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(2)','N','geo_cityfiscalview','N','','2','provincecode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','geo_cityfiscalview','N','','50','region','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_cityfiscalview','N','','4','start','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_cityfiscalview','N','','4','stop','')
GO

-- VERIFICA DI geo_cityfiscalview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_cityfiscalview')
UPDATE customobject set isreal = 'N' where objectname = 'geo_cityfiscalview'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_cityfiscalview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

