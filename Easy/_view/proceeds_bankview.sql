-- CREAZIONE VISTA proceeds_bankview
IF EXISTS(select * from sysobjects where id = object_id(N'[proceeds_bankview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [proceeds_bankview]
GO




CREATE  VIEW proceeds_bankview
(
	kpro,
	ypro,
	npro,
	idpro,
	idreg,
	registry,
	description,
	amount,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	PB.idpro,
	PB.idreg,
	R.title,
	PB.description,
	PB.amount,
	PB.ct,
	PB.cu,
	PB.lt,
	PB.lu
FROM proceeds_bank PB
JOIN proceeds 
	ON proceeds.kpro = PB.kpro
JOIN registry R
	ON R.idreg = PB.idreg







GO

-- VERIFICA DI proceeds_bankview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'proceeds_bankview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'amount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'proceeds_bankview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','N','System.Decimal','decimal(19,2)','N','proceeds_bankview','S','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','proceeds_bankview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','proceeds_bankview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'N',format = '',col_len = '200',field = 'description',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(200)','N','proceeds_bankview','N','','200','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'idpro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '4',field = 'idpro',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'idpro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceeds_bankview','S','','4','idpro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'idreg')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceeds_bankview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'kpro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '4',field = 'kpro',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'kpro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceeds_bankview','S','','4','kpro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','proceeds_bankview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','proceeds_bankview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'npro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '4',field = 'npro',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'npro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceeds_bankview','S','','4','npro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'registry')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(100)','N','proceeds_bankview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds_bankview' AND field = 'ypro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceeds_bankview',denynull = 'S',format = '',col_len = '2',field = 'ypro',col_precision = '' where tablename = 'proceeds_bankview' AND field = 'ypro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','proceeds_bankview','S','','2','ypro','')
GO

-- VERIFICA DI proceeds_bankview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'proceeds_bankview')
UPDATE customobject set isreal = 'N' where objectname = 'proceeds_bankview'
ELSE
INSERT INTO customobject (objectname, isreal) values('proceeds_bankview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

