-- CREAZIONE VISTA payment_bankview
IF EXISTS(select * from sysobjects where id = object_id(N'[payment_bankview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payment_bankview]
GO



CREATE  VIEW payment_bankview
(
	ypay,
	npay,
	idpay,
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
	payment.ypay,
	payment.npay,
	PB.idpay,
	PB.idreg,
	R.title,
	PB.description,
	PB.amount,
	PB.ct,
	PB.cu,
	PB.lt,
	PB.lu
FROM payment_bank PB
JOIN payment
	ON PB.kpay = payment.kpay
JOIN registry R
	ON R.idreg = PB.idreg





GO

-- VERIFICA DI payment_bankview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'payment_bankview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'amount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'payment_bankview',denynull = 'S',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'payment_bankview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','N','System.Decimal','decimal(19,2)','N','payment_bankview','S','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'payment_bankview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'payment_bankview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','payment_bankview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'payment_bankview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'payment_bankview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','payment_bankview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'payment_bankview',denynull = 'N',format = '',col_len = '200',field = 'description',col_precision = '' where tablename = 'payment_bankview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(200)','N','payment_bankview','N','','200','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'idpay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'payment_bankview',denynull = 'S',format = '',col_len = '4',field = 'idpay',col_precision = '' where tablename = 'payment_bankview' AND field = 'idpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','payment_bankview','S','','4','idpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'idreg')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'payment_bankview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'payment_bankview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','payment_bankview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'payment_bankview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'payment_bankview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','payment_bankview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'payment_bankview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'payment_bankview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','payment_bankview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'npay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'payment_bankview',denynull = 'S',format = '',col_len = '4',field = 'npay',col_precision = '' where tablename = 'payment_bankview' AND field = 'npay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','payment_bankview','S','','4','npay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'registry')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'payment_bankview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'payment_bankview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(100)','N','payment_bankview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payment_bankview' AND field = 'ypay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'payment_bankview',denynull = 'S',format = '',col_len = '2',field = 'ypay',col_precision = '' where tablename = 'payment_bankview' AND field = 'ypay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','payment_bankview','S','','2','ypay','')
GO

-- VERIFICA DI payment_bankview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'payment_bankview')
UPDATE customobject set isreal = 'N' where objectname = 'payment_bankview'
ELSE
INSERT INTO customobject (objectname, isreal) values('payment_bankview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

