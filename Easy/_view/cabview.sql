-- CREAZIONE VISTA cabview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[cabview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[cabview]
GO



CREATE VIEW [DBO].cabview
(
	idbank,
	idcab,
	description,
	address,
	cap,
	country,
	cu,
	ct,
	lu,
	lt,
	location,
	idcity,
	city,
	active
)
AS SELECT
	cab.idbank,
	cab.idcab,
	cab.description,
	cab.address,
	cab.cap,
	geo_country.title,
	cab.cu,
	cab.ct,
	cab.lu,
	cab.lt,
	cab.location,
	cab.idcity,
	geo_city.title,
	cab.active
FROM cab 
LEFT OUTER JOIN geo_city
	ON cab.idcity = geo_city.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry


GO

-- VERIFICA DI cabview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'cabview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','N','System.String','char(1)','N','cabview','S','','1','active','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','cabview','N','','100','address','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','cabview','N','','20','cap','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','cabview','N','','65','city','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','cabview','N','','50','country','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','cabview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','cabview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','cabview','S','','50','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','cabview','S','','20','idbank','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','cabview','S','','20','idcab','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','cabview','N','','4','idcity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','cabview','N','','50','location','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','cabview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','cabview','S','','64','lu','')
GO

-- VERIFICA DI cabview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'cabview')
UPDATE customobject set isreal = 'N' where objectname = 'cabview'
ELSE
INSERT INTO customobject (objectname, isreal) values('cabview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

