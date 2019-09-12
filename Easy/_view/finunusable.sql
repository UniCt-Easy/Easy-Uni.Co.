-- CREAZIONE VISTA finunusable
IF EXISTS(select * from sysobjects where id = object_id(N'[finunusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finunusable]
GO







--Pino Rana, elaborazione del 10/08/2005 15:18:00
CREATE                                      VIEW finunusable
(
	idfin,
	ayear,
	finpart,
	codefin,
	nlevel,
	leveldescr,
	paridfin,
	printingorder,
	title,
	expiration,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	fin.idfin,
	fin.ayear,
	CASE
		WHEN ((fin.flag&1)=0) THEN 'E'
		WHEN ((fin.flag&1)=1) THEN 'S'
	END,
	fin.codefin,
	fin.nlevel,
	finlevel.description,
	fin.paridfin,
	fin.printingorder,
	fin.title,
	finlast.expiration,
	fin.cu, 
	fin.ct, 
	fin.lu,
	fin.lt 
	FROM fin (NOLOCK)
	JOIN finlevel (NOLOCK) 
	ON finlevel.ayear = fin.ayear
	AND finlevel.nlevel = fin.nlevel
	LEFT OUTER JOIN finlast (NOLOCK) 
	ON finlast.idfin = fin.idfin
	WHERE finlevel.flag&2 = 0
	OR finlast.idfin is null

GO

-- VERIFICA DI finunusable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'finunusable'
IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'finunusable' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','finunusable','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'codefin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'finunusable' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(50)','N','finunusable','S','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'finunusable' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','finunusable','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'finunusable' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','finunusable','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'expiration')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finunusable',denynull = 'N',format = '',col_len = '8',field = 'expiration',col_precision = '' where tablename = 'finunusable' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','S','System.DateTime','datetime','N','finunusable','N','','8','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'finpart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'finunusable',denynull = 'N',format = '',col_len = '1',field = 'finpart',col_precision = '' where tablename = 'finunusable' AND field = 'finpart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(1)','N','finunusable','N','','1','finpart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'idfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'finunusable' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','finunusable','S','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'leveldescr')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '50',field = 'leveldescr',col_precision = '' where tablename = 'finunusable' AND field = 'leveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(50)','N','finunusable','S','','50','leveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'finunusable' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','finunusable','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'finunusable' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','finunusable','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'nlevel')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'finunusable' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','tinyint','','N','System.Byte','tinyint','N','finunusable','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'paridfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finunusable',denynull = 'N',format = '',col_len = '4',field = 'paridfin',col_precision = '' where tablename = 'finunusable' AND field = 'paridfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','finunusable','N','','4','paridfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'printingorder')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '50',field = 'printingorder',col_precision = '' where tablename = 'finunusable' AND field = 'printingorder'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(50)','N','finunusable','S','','50','printingorder','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finunusable' AND field = 'title')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'finunusable',denynull = 'S',format = '',col_len = '150',field = 'title',col_precision = '' where tablename = 'finunusable' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(150)','N','finunusable','S','','150','title','')
GO

-- VERIFICA DI finunusable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'finunusable')
UPDATE customobject set isreal = 'N' where objectname = 'finunusable'
ELSE
INSERT INTO customobject (objectname, isreal) values('finunusable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

