-- CREAZIONE VISTA profservicetaxview
IF EXISTS(select * from sysobjects where id = object_id(N'[profservicetaxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [profservicetaxview]
GO





CREATE VIEW [profservicetaxview]
(
	taxcode,
	description,
	taxref,
	ycon,
	ncon,
	adminrate,
	employrate,
	taxablegross,
	taxablenet,
	admindenominator,
	employdenominator,
	taxabledenominator,
	adminnumerator,
	employnumerator,
	taxablenumerator,
	admintax,
	employtax,
	employtaxgross,
	taxkind
)
AS SELECT
	COPR.taxcode,
	TR.description,
	TR.taxref,
	COPR.ycon,
	COPR.ncon,
	COPR.adminrate,
	COPR.employrate,
	COPR.taxablegross,
	COPR.taxablenet,
	COPR.admindenominator,
	COPR.employdenominator,
	COPR.taxabledenominator,
	COPR.adminnumerator,
	COPR.employnumerator,
	COPR.taxablenumerator,
	COPR.admintax,
	COPR.employtax,
	COPR.employtaxgross,
	TR.taxkind
FROM profservicetax COPR
JOIN tax TR
	ON COPR.taxcode = TR.taxcode









GO

-- VERIFICA DI profservicetaxview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'profservicetaxview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'admindenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'admindenominator',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'admindenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','profservicetaxview','N','','9','admindenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'adminnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'adminnumerator',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'adminnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','profservicetaxview','N','','9','adminnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'adminrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'adminrate',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'adminrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','profservicetaxview','N','','9','adminrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'admintax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'admintax',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'admintax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','profservicetaxview','N','','9','admintax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'profservicetaxview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','profservicetaxview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'employdenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'employdenominator',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'employdenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','profservicetaxview','N','','9','employdenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'employnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'employnumerator',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'employnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','profservicetaxview','N','','9','employnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'employrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'employrate',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'employrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','profservicetaxview','N','','9','employrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'employtax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'employtax',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'employtax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','profservicetaxview','N','','9','employtax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'employtaxgross')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'employtaxgross',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'employtaxgross'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','profservicetaxview','N','','9','employtaxgross','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'ncon')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'profservicetaxview',denynull = 'S',format = '',col_len = '4',field = 'ncon',col_precision = '' where tablename = 'profservicetaxview' AND field = 'ncon'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','profservicetaxview','S','','4','ncon','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'taxabledenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'taxabledenominator',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'taxabledenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','profservicetaxview','N','','9','taxabledenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'taxablegross')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablegross',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'taxablegross'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','profservicetaxview','N','','9','taxablegross','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'taxablenet')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablenet',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'taxablenet'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','profservicetaxview','N','','9','taxablenet','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'taxablenumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablenumerator',col_precision = '19' where tablename = 'profservicetaxview' AND field = 'taxablenumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','profservicetaxview','N','','9','taxablenumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'profservicetaxview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'profservicetaxview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','profservicetaxview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'taxkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'profservicetaxview',denynull = 'S',format = '',col_len = '2',field = 'taxkind',col_precision = '' where tablename = 'profservicetaxview' AND field = 'taxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','profservicetaxview','S','','2','taxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'taxref')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'profservicetaxview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'profservicetaxview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(20)','N','profservicetaxview','S','','20','taxref','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'profservicetaxview' AND field = 'ycon')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'profservicetaxview',denynull = 'S',format = '',col_len = '4',field = 'ycon',col_precision = '' where tablename = 'profservicetaxview' AND field = 'ycon'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','profservicetaxview','S','','4','ycon','')
GO

-- VERIFICA DI profservicetaxview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'profservicetaxview')
UPDATE customobject set isreal = 'N' where objectname = 'profservicetaxview'
ELSE
INSERT INTO customobject (objectname, isreal) values('profservicetaxview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --
