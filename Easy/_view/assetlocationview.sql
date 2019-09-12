-- CREAZIONE VISTA assetlocationview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetlocationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetlocationview]
GO




CREATE VIEW [assetlocationview]
(
	idasset,
	start,
	idlocation,
	locationcode,
	location,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	assetlocation.idasset,
	assetlocation.start,
	assetlocation.idlocation,
	location.locationcode,
	location.description,
	assetlocation.cu,
	assetlocation.ct,
	assetlocation.lu,
	assetlocation.lt
FROM assetlocation
JOIN location
	ON location.idlocation = assetlocation.idlocation






GO

-- VERIFICA DI assetlocationview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetlocationview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'assetlocationview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'assetlocationview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'assetlocationview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','assetlocationview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetlocationview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'assetlocationview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'assetlocationview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','assetlocationview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetlocationview' AND field = 'idasset')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'assetlocationview',denynull = 'S',format = '',col_len = '4',field = 'idasset',col_precision = '' where tablename = 'assetlocationview' AND field = 'idasset'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetlocationview','S','','4','idasset','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetlocationview' AND field = 'idlocation')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'assetlocationview',denynull = 'S',format = '',col_len = '4',field = 'idlocation',col_precision = '' where tablename = 'assetlocationview' AND field = 'idlocation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetlocationview','S','','4','idlocation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetlocationview' AND field = 'location')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'assetlocationview',denynull = 'S',format = '',col_len = '150',field = 'location',col_precision = '' where tablename = 'assetlocationview' AND field = 'location'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','assetlocationview','S','','150','location','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetlocationview' AND field = 'locationcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'assetlocationview',denynull = 'S',format = '',col_len = '50',field = 'locationcode',col_precision = '' where tablename = 'assetlocationview' AND field = 'locationcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','assetlocationview','S','','50','locationcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetlocationview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'assetlocationview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'assetlocationview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','assetlocationview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetlocationview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'assetlocationview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'assetlocationview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','assetlocationview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetlocationview' AND field = 'start')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'assetlocationview',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'assetlocationview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','assetlocationview','S','','4','start','')
GO

-- VERIFICA DI assetlocationview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetlocationview')
UPDATE customobject set isreal = 'N' where objectname = 'assetlocationview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetlocationview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

