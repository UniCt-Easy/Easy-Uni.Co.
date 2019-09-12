-- CREAZIONE VISTA finusable
IF EXISTS(select * from sysobjects where id = object_id(N'[finusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finusable]
GO







--Pino Rana, elaborazione del 10/08/2005 15:18:00
CREATE                                      VIEW finusable
(
	idfin,
	ayear,
	flag,
	finpart,
	codefin,
	paridfin,
	nlevel,
	idman,
	manager,
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
	fin.flag,
	CASE
		WHEN ((fin.flag&1)=0) THEN 'E'
		WHEN ((fin.flag&1)=1) THEN 'S'
	END,
	fin.codefin,
	fin.paridfin,
	fin.nlevel,
	finlast.idman,
	manager.title,
	fin.printingorder,
	fin.title,
	finlast.expiration,
	fin.cu, 
	fin.ct, 
	fin.lu,
	fin.lt 
	FROM fin (NOLOCK)
	JOIN finlevel (NOLOCK)				ON finlevel.ayear = fin.ayear	AND finlevel.nlevel = fin.nlevel
	JOIN finlast (NOLOCK)				ON fin.idfin = finlast.idfin
	LEFT OUTER JOIN manager (NOLOCK)	ON manager.idman = finlast.idman
	WHERE finlevel.flag&2 <> 0









GO

-- VERIFICA DI finusable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'finusable'
IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'finusable' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','finusable','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'codefin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'finusable' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(50)','N','finusable','S','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'finusable' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','finusable','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'finusable' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','finusable','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'expiration')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finusable',denynull = 'N',format = '',col_len = '8',field = 'expiration',col_precision = '' where tablename = 'finusable' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','S','System.DateTime','datetime','N','finusable','N','','8','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'finpart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'finusable',denynull = 'N',format = '',col_len = '1',field = 'finpart',col_precision = '' where tablename = 'finusable' AND field = 'finpart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(1)','N','finusable','N','','1','finpart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'flag')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'finusable' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','tinyint','','N','System.Byte','tinyint','N','finusable','S','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'idfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'finusable' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','finusable','S','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'idman')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finusable',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'finusable' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','finusable','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'finusable' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','finusable','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'finusable' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','finusable','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'manager')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'finusable',denynull = 'N',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'finusable' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(150)','N','finusable','N','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'nlevel')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'finusable' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','tinyint','','N','System.Byte','tinyint','N','finusable','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'paridfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finusable',denynull = 'N',format = '',col_len = '4',field = 'paridfin',col_precision = '' where tablename = 'finusable' AND field = 'paridfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','finusable','N','','4','paridfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'printingorder')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '50',field = 'printingorder',col_precision = '' where tablename = 'finusable' AND field = 'printingorder'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(50)','N','finusable','S','','50','printingorder','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finusable' AND field = 'title')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'finusable',denynull = 'S',format = '',col_len = '150',field = 'title',col_precision = '' where tablename = 'finusable' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(150)','N','finusable','S','','150','title','')
GO

-- VERIFICA DI finusable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'finusable')
UPDATE customobject set isreal = 'N' where objectname = 'finusable'
ELSE
INSERT INTO customobject (objectname, isreal) values('finusable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

