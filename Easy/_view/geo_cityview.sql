-- CREAZIONE VISTA geo_cityview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_cityview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_cityview]
GO


/*Pino Rana, elaborazione del 10/08/2005 15:18:07
 Inserire la CREATE VIEW qui--
*/
CREATE  VIEW [DBO].geo_cityview
AS
SELECT     geo_city.idcity, geo_city.title, geo_city.oldcity, geo_city.newcity, geo_city.start, geo_city.stop, geo_country.idcountry, 
                      geo_country.province AS provincecode, geo_country.title AS country, geo_country.oldcountry, geo_country.newcountry, 
                      geo_country.start AS countrydatestart, geo_country.stop AS countrydatestop, geo_region.idregion, geo_region.title AS region, 
                      geo_region.start AS regiondatestart, geo_region.stop AS regiondatestop, geo_region.oldregion, geo_region.newregion, 
                      geo_nation.idnation, geo_nation.idcontinent, geo_nation.title AS nation, geo_nation.start AS nationdatestart, 
                      geo_nation.stop AS nationdatestop, geo_nation.oldnation, geo_nation.newnation
FROM         geo_city LEFT OUTER  JOIN
                      geo_country ON geo_city.idcountry = geo_country.idcountry LEFT OUTER JOIN
                      geo_region ON geo_country.idregion = geo_region.idregion LEFT OUTER JOIN
                      geo_nation ON geo_region.idnation = geo_nation.idnation



GO

-- VERIFICA DI geo_cityview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_cityview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'country')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '50',field = 'country',col_precision = '' where tablename = 'geo_cityview' AND field = 'country'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(50)','N','geo_cityview','N','','50','country','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'countrydatestart')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'countrydatestart',col_precision = '' where tablename = 'geo_cityview' AND field = 'countrydatestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_cityview','N','','4','countrydatestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'countrydatestop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'countrydatestop',col_precision = '' where tablename = 'geo_cityview' AND field = 'countrydatestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_cityview','N','','4','countrydatestop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'idcity')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'S',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'geo_cityview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','geo_cityview','S','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'idcontinent')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'idcontinent',col_precision = '' where tablename = 'geo_cityview' AND field = 'idcontinent'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','idcontinent','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'idcountry')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'S',format = '',col_len = '4',field = 'idcountry',col_precision = '' where tablename = 'geo_cityview' AND field = 'idcountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','geo_cityview','S','','4','idcountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'idnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'idnation',col_precision = '' where tablename = 'geo_cityview' AND field = 'idnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','idnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'idregion')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'idregion',col_precision = '' where tablename = 'geo_cityview' AND field = 'idregion'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','idregion','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'nation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '65',field = 'nation',col_precision = '' where tablename = 'geo_cityview' AND field = 'nation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(65)','N','geo_cityview','N','','65','nation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'nationdatestart')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'nationdatestart',col_precision = '' where tablename = 'geo_cityview' AND field = 'nationdatestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_cityview','N','','4','nationdatestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'nationdatestop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'nationdatestop',col_precision = '' where tablename = 'geo_cityview' AND field = 'nationdatestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_cityview','N','','4','nationdatestop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'newcity')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'newcity',col_precision = '' where tablename = 'geo_cityview' AND field = 'newcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','newcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'newcountry')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'newcountry',col_precision = '' where tablename = 'geo_cityview' AND field = 'newcountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','newcountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'newnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'newnation',col_precision = '' where tablename = 'geo_cityview' AND field = 'newnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','newnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'newregion')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'newregion',col_precision = '' where tablename = 'geo_cityview' AND field = 'newregion'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','newregion','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'oldcity')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'oldcity',col_precision = '' where tablename = 'geo_cityview' AND field = 'oldcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','oldcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'oldcountry')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'oldcountry',col_precision = '' where tablename = 'geo_cityview' AND field = 'oldcountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','oldcountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'oldnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'oldnation',col_precision = '' where tablename = 'geo_cityview' AND field = 'oldnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','oldnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'oldregion')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'oldregion',col_precision = '' where tablename = 'geo_cityview' AND field = 'oldregion'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_cityview','N','','4','oldregion','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'provincecode')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(2)',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '2',field = 'provincecode',col_precision = '' where tablename = 'geo_cityview' AND field = 'provincecode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(2)','N','geo_cityview','N','','2','provincecode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'region')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '50',field = 'region',col_precision = '' where tablename = 'geo_cityview' AND field = 'region'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(50)','N','geo_cityview','N','','50','region','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'regiondatestart')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'regiondatestart',col_precision = '' where tablename = 'geo_cityview' AND field = 'regiondatestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_cityview','N','','4','regiondatestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'regiondatestop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'regiondatestop',col_precision = '' where tablename = 'geo_cityview' AND field = 'regiondatestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_cityview','N','','4','regiondatestop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'start')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'geo_cityview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_cityview','N','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'stop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'geo_cityview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_cityview','N','','4','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_cityview' AND field = 'title')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'geo_cityview',denynull = 'N',format = '',col_len = '65',field = 'title',col_precision = '' where tablename = 'geo_cityview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(65)','N','geo_cityview','N','','65','title','')
GO

-- VERIFICA DI geo_cityview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_cityview')
UPDATE customobject set isreal = 'N' where objectname = 'geo_cityview'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_cityview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

