-- CREAZIONE VISTA geo_country_view
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_country_view]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_country_view]
GO

--Pino Rana, elaborazione del 10/08/2005 15:18:07
-- Inserire la CREATE VIEW qui--
CREATE                                   VIEW [DBO].[geo_country_view]
(
idcountry, 
province, 
title, 
oldcountry, 
newcountry, 
start, 
stop, 
idregion, 
region, 
regiondatestart, 
regiondatestop, 
oldregion, 
newregion, 
idnation, 
idcontinent, 
nation, 
nationdatestart, 
nationdatestop, 
oldnation, 
newnation
)
AS
SELECT     geo_country.idcountry, geo_country.province, 
                      geo_country.title, geo_country.oldcountry, geo_country.newcountry, 
                      geo_country.start, geo_country.stop, geo_region.idregion, 
                      geo_region.title AS regione, geo_region.start AS datainizioregione, geo_region.stop AS datafineregione, 
                      geo_region.oldregion, geo_region.newregion, geo_nation.idnation, geo_nation.idcontinent, 
                      geo_nation.title AS nazione, geo_nation.start AS datainizionazione, geo_nation.stop AS datafinenazione, 
                      geo_nation.oldnation, geo_nation.newnation
FROM       geo_country INNER JOIN
                      geo_region ON geo_country.idregion = geo_region.idregion INNER JOIN
                      geo_nation ON geo_region.idnation = geo_nation.idnation



GO

-- VERIFICA DI geo_country_view IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_country_view'
IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'idcontinent')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'idcontinent',col_precision = '' where tablename = 'geo_country_view' AND field = 'idcontinent'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_country_view','N','','4','idcontinent','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'idcountry')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_country_view',denynull = 'S',format = '',col_len = '4',field = 'idcountry',col_precision = '' where tablename = 'geo_country_view' AND field = 'idcountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','geo_country_view','S','','4','idcountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'idnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_country_view',denynull = 'S',format = '',col_len = '4',field = 'idnation',col_precision = '' where tablename = 'geo_country_view' AND field = 'idnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','geo_country_view','S','','4','idnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'idregion')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_country_view',denynull = 'S',format = '',col_len = '4',field = 'idregion',col_precision = '' where tablename = 'geo_country_view' AND field = 'idregion'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','geo_country_view','S','','4','idregion','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'nation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '65',field = 'nation',col_precision = '' where tablename = 'geo_country_view' AND field = 'nation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(65)','N','geo_country_view','N','','65','nation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'nationdatestart')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'nationdatestart',col_precision = '' where tablename = 'geo_country_view' AND field = 'nationdatestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_country_view','N','','4','nationdatestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'nationdatestop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'nationdatestop',col_precision = '' where tablename = 'geo_country_view' AND field = 'nationdatestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_country_view','N','','4','nationdatestop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'newcountry')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'newcountry',col_precision = '' where tablename = 'geo_country_view' AND field = 'newcountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_country_view','N','','4','newcountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'newnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'newnation',col_precision = '' where tablename = 'geo_country_view' AND field = 'newnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_country_view','N','','4','newnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'newregion')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'newregion',col_precision = '' where tablename = 'geo_country_view' AND field = 'newregion'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_country_view','N','','4','newregion','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'oldcountry')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'oldcountry',col_precision = '' where tablename = 'geo_country_view' AND field = 'oldcountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_country_view','N','','4','oldcountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'oldnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'oldnation',col_precision = '' where tablename = 'geo_country_view' AND field = 'oldnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_country_view','N','','4','oldnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'oldregion')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'oldregion',col_precision = '' where tablename = 'geo_country_view' AND field = 'oldregion'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_country_view','N','','4','oldregion','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'province')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(2)',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '2',field = 'province',col_precision = '' where tablename = 'geo_country_view' AND field = 'province'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(2)','N','geo_country_view','N','','2','province','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'region')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '50',field = 'region',col_precision = '' where tablename = 'geo_country_view' AND field = 'region'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(50)','N','geo_country_view','N','','50','region','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'regiondatestart')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'regiondatestart',col_precision = '' where tablename = 'geo_country_view' AND field = 'regiondatestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_country_view','N','','4','regiondatestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'regiondatestop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'regiondatestop',col_precision = '' where tablename = 'geo_country_view' AND field = 'regiondatestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_country_view','N','','4','regiondatestop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'start')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'geo_country_view' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_country_view','N','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'stop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'geo_country_view' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_country_view','N','','4','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_country_view' AND field = 'title')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'geo_country_view',denynull = 'N',format = '',col_len = '50',field = 'title',col_precision = '' where tablename = 'geo_country_view' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(50)','N','geo_country_view','N','','50','title','')
GO

-- VERIFICA DI geo_country_view IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_country_view')
UPDATE customobject set isreal = 'N' where objectname = 'geo_country_view'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_country_view', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

