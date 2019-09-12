-- CREAZIONE VISTA paymentlogview
IF EXISTS(select * from sysobjects where id = object_id(N'[paymentlogview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [paymentlogview]
GO



CREATE  VIEW paymentlogview
(
	idexp,
	nphase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	autokind,
	idpayment,
	expiration,
	adate,
	competencydate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idreg,
	expense.idman,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	CASE config.taxvaliditykind 
		WHEN 1 THEN payment.adate 
		WHEN 2 THEN payment.printdate
		WHEN 4 THEN ( SELECT MIN(banktransaction.transactiondate )
				FROM banktransaction
				WHERE banktransaction.kpay = expenselast.kpay)
		ELSE	paymenttransmission.transmissiondate
	END,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt
FROM expense
JOIN expenselast
	ON expense.idexp = expenselast.idexp
LEFT OUTER JOIN config
ON config.ayear = expense.ymov
LEFT OUTER JOIN expense parentexpense
	ON parentexpense.idexp = expense.parentidexp
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission =  payment.kpaymenttransmission 
LEFT OUTER JOIN expensetotal expensetotal_firstyear
		ON expensetotal_firstyear.idexp = expense.idexp
		AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
		AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser




GO

-- VERIFICA DI paymentlogview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'paymentlogview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'adate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'paymentlogview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','paymentlogview','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'amount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'paymentlogview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','paymentlogview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'autokind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '1',field = 'autokind',col_precision = '' where tablename = 'paymentlogview' AND field = 'autokind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','S','System.Byte','tinyint','N','paymentlogview','N','','1','autokind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'cc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(30)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '30',field = 'cc',col_precision = '' where tablename = 'paymentlogview' AND field = 'cc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(30)','N','paymentlogview','N','','30','cc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'cin')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(2)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '2',field = 'cin',col_precision = '' where tablename = 'paymentlogview' AND field = 'cin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(2)','N','paymentlogview','N','','2','cin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'codeser')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '20',field = 'codeser',col_precision = '' where tablename = 'paymentlogview' AND field = 'codeser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(20)','N','paymentlogview','N','','20','codeser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'competencydate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'competencydate',col_precision = '' where tablename = 'paymentlogview' AND field = 'competencydate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','paymentlogview','N','','4','competencydate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'paymentlogview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','paymentlogview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'paymentlogview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','paymentlogview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'paymentlogview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(150)','N','paymentlogview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'doc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(35)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '35',field = 'doc',col_precision = '' where tablename = 'paymentlogview' AND field = 'doc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(35)','N','paymentlogview','N','','35','doc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'docdate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'docdate',col_precision = '' where tablename = 'paymentlogview' AND field = 'docdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','paymentlogview','N','','4','docdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'expiration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'paymentlogview' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','paymentlogview','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'flag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'paymentlogview' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','paymentlogview','S','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'iban')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '50',field = 'iban',col_precision = '' where tablename = 'paymentlogview' AND field = 'iban'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(50)','N','paymentlogview','N','','50','iban','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'idbank')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '20',field = 'idbank',col_precision = '' where tablename = 'paymentlogview' AND field = 'idbank'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(20)','N','paymentlogview','N','','20','idbank','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'idcab')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '20',field = 'idcab',col_precision = '' where tablename = 'paymentlogview' AND field = 'idcab'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(20)','N','paymentlogview','N','','20','idcab','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'idexp')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '4',field = 'idexp',col_precision = '' where tablename = 'paymentlogview' AND field = 'idexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','paymentlogview','S','','4','idexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'idman')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'paymentlogview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentlogview','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'idpayment')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'idpayment',col_precision = '' where tablename = 'paymentlogview' AND field = 'idpayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentlogview','N','','4','idpayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'idpaymethod')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'idpaymethod',col_precision = '' where tablename = 'paymentlogview' AND field = 'idpaymethod'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentlogview','N','','4','idpaymethod','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'idreg')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'paymentlogview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentlogview','N','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'idser')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'idser',col_precision = '' where tablename = 'paymentlogview' AND field = 'idser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentlogview','N','','4','idser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'ivaamount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '9',field = 'ivaamount',col_precision = '19' where tablename = 'paymentlogview' AND field = 'ivaamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','paymentlogview','N','','9','ivaamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'kpay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'kpay',col_precision = '' where tablename = 'paymentlogview' AND field = 'kpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentlogview','N','','4','kpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'paymentlogview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','paymentlogview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'paymentlogview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','paymentlogview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'nmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'paymentlogview' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','paymentlogview','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'npay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'npay',col_precision = '' where tablename = 'paymentlogview' AND field = 'npay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentlogview','N','','4','npay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'nphase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'paymentlogview' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','paymentlogview','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'parentidexp')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'parentidexp',col_precision = '' where tablename = 'paymentlogview' AND field = 'parentidexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentlogview','N','','4','parentidexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'parentnmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '4',field = 'parentnmov',col_precision = '' where tablename = 'paymentlogview' AND field = 'parentnmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentlogview','N','','4','parentnmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'parentymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '2',field = 'parentymov',col_precision = '' where tablename = 'paymentlogview' AND field = 'parentymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','paymentlogview','N','','2','parentymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'paymentdescr')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '150',field = 'paymentdescr',col_precision = '' where tablename = 'paymentlogview' AND field = 'paymentdescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(150)','N','paymentlogview','N','','150','paymentdescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'service')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '50',field = 'service',col_precision = '' where tablename = 'paymentlogview' AND field = 'service'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(50)','N','paymentlogview','N','','50','service','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'servicestart')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '8',field = 'servicestart',col_precision = '' where tablename = 'paymentlogview' AND field = 'servicestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','S','System.DateTime','datetime','N','paymentlogview','N','','8','servicestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'servicestop')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '8',field = 'servicestop',col_precision = '' where tablename = 'paymentlogview' AND field = 'servicestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','S','System.DateTime','datetime','N','paymentlogview','N','','8','servicestop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'ymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'paymentlogview',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'paymentlogview' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','paymentlogview','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentlogview' AND field = 'ypay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'paymentlogview',denynull = 'N',format = '',col_len = '2',field = 'ypay',col_precision = '' where tablename = 'paymentlogview' AND field = 'ypay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','paymentlogview','N','','2','ypay','')
GO

-- VERIFICA DI paymentlogview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'paymentlogview')
UPDATE customobject set isreal = 'N' where objectname = 'paymentlogview'
ELSE
INSERT INTO customobject (objectname, isreal) values('paymentlogview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

