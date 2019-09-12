-- CREAZIONE VISTA taxpayexpenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxpayexpenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxpayexpenseview]
GO


CREATE   VIEW taxpayexpenseview 
(
	ytaxpay,
	ntaxpay,
	taxcode,
	taxref,
	taxdescription,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	autokind,
	idpayment,
	totflag,
	flagarrear,
	expiration,
	adate,
	txt,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	taxpayexpense.ytaxpay,
	taxpayexpense.ntaxpay,
	taxpayexpense.taxcode,
	tax.taxref,
	tax.description,
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman, 
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
  	expense.autokind,
	expense.idpayment,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.expiration,
	expense.adate,
	expense.txt,
	taxpayexpense.cu,
	taxpayexpense.ct,
	taxpayexpense.lu,
	taxpayexpense.lt
FROM taxpayexpense
JOIN expense 
	ON taxpayexpense.idexp = expense.idexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear 
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expenselast
	ON expense.idexp = expenselast.idexp
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN expense parentexpense
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN tax
	ON tax.taxcode = taxpayexpense.taxcode



GO

-- VERIFICA DI taxpayexpenseview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'taxpayexpenseview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'adate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','taxpayexpenseview','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'amount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'taxpayexpenseview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','taxpayexpenseview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'autokind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '1',field = 'autokind',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'autokind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','S','System.Byte','tinyint','N','taxpayexpenseview','N','','1','autokind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'available')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '9',field = 'available',col_precision = '19' where tablename = 'taxpayexpenseview' AND field = 'available'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','taxpayexpenseview','N','','9','available','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'ayear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','taxpayexpenseview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'ayearstartamount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '9',field = 'ayearstartamount',col_precision = '19' where tablename = 'taxpayexpenseview' AND field = 'ayearstartamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','taxpayexpenseview','N','','9','ayearstartamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'cc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(30)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '30',field = 'cc',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'cc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(30)','N','taxpayexpenseview','N','','30','cc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'cin')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(2)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '2',field = 'cin',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'cin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(2)','N','taxpayexpenseview','N','','2','cin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'codefin')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(50)','N','taxpayexpenseview','N','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'codeupb')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '50',field = 'codeupb',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'codeupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(50)','N','taxpayexpenseview','N','','50','codeupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','taxpayexpenseview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','taxpayexpenseview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'curramount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '9',field = 'curramount',col_precision = '19' where tablename = 'taxpayexpenseview' AND field = 'curramount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','taxpayexpenseview','N','','9','curramount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(150)','N','taxpayexpenseview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'doc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(35)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '35',field = 'doc',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'doc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(35)','N','taxpayexpenseview','N','','35','doc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'docdate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'docdate',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'docdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','taxpayexpenseview','N','','4','docdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'expiration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','taxpayexpenseview','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'finance')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '150',field = 'finance',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'finance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(150)','N','taxpayexpenseview','N','','150','finance','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'flag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','S','System.Byte','tinyint','N','taxpayexpenseview','N','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'flagarrear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '1',field = 'flagarrear',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'flagarrear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(1)','N','taxpayexpenseview','N','','1','flagarrear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'iban')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '50',field = 'iban',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'iban'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(50)','N','taxpayexpenseview','N','','50','iban','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'idbank')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '20',field = 'idbank',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'idbank'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(20)','N','taxpayexpenseview','N','','20','idbank','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'idcab')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '20',field = 'idcab',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'idcab'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(20)','N','taxpayexpenseview','N','','20','idcab','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'idexp')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '4',field = 'idexp',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'idexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','taxpayexpenseview','S','','4','idexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'idfin')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','taxpayexpenseview','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'idman')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','taxpayexpenseview','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'idpayment')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idpayment',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'idpayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','taxpayexpenseview','N','','4','idpayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'idpaymethod')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idpaymethod',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'idpaymethod'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','taxpayexpenseview','N','','4','idpaymethod','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'idreg')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','taxpayexpenseview','N','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'idser')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idser',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'idser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','taxpayexpenseview','N','','4','idser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'idupb')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(36)','N','taxpayexpenseview','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'ivaamount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '9',field = 'ivaamount',col_precision = '19' where tablename = 'taxpayexpenseview' AND field = 'ivaamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','taxpayexpenseview','N','','9','ivaamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'kpay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'kpay',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'kpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','taxpayexpenseview','N','','4','kpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','taxpayexpenseview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','taxpayexpenseview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'manager')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(150)','N','taxpayexpenseview','N','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'nmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','taxpayexpenseview','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'npay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'npay',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'npay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','taxpayexpenseview','N','','4','npay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'nphase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','taxpayexpenseview','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'ntaxpay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '4',field = 'ntaxpay',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'ntaxpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','taxpayexpenseview','S','','4','ntaxpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'parentidexp')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'parentidexp',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'parentidexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','taxpayexpenseview','N','','4','parentidexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'parentnmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '4',field = 'parentnmov',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'parentnmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','taxpayexpenseview','N','','4','parentnmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'parentymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '2',field = 'parentymov',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'parentymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','taxpayexpenseview','N','','2','parentymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'paymentdescr')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '150',field = 'paymentdescr',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'paymentdescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(150)','N','taxpayexpenseview','N','','150','paymentdescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'phase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '50',field = 'phase',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'phase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','taxpayexpenseview','S','','50','phase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'registry')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(100)','N','taxpayexpenseview','N','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'service')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '50',field = 'service',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'service'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(50)','N','taxpayexpenseview','N','','50','service','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'servicestart')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '8',field = 'servicestart',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'servicestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','S','System.DateTime','datetime','N','taxpayexpenseview','N','','8','servicestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'servicestop')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '8',field = 'servicestop',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'servicestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','S','System.DateTime','datetime','N','taxpayexpenseview','N','','8','servicestop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','taxpayexpenseview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'taxdescription')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '50',field = 'taxdescription',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'taxdescription'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(50)','N','taxpayexpenseview','N','','50','taxdescription','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'taxref')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(20)','N','taxpayexpenseview','N','','20','taxref','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'totflag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '1',field = 'totflag',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'totflag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','S','System.Byte','tinyint','N','taxpayexpenseview','N','','1','totflag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'txt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'text',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'text',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '16',field = 'txt',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'txt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','text','','S','System.String','text','N','taxpayexpenseview','N','','16','txt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'upb')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '150',field = 'upb',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'upb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(150)','N','taxpayexpenseview','N','','150','upb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'ymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','taxpayexpenseview','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'ypay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'N',format = '',col_len = '2',field = 'ypay',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'ypay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','taxpayexpenseview','N','','2','ypay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpayexpenseview' AND field = 'ytaxpay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'taxpayexpenseview',denynull = 'S',format = '',col_len = '2',field = 'ytaxpay',col_precision = '' where tablename = 'taxpayexpenseview' AND field = 'ytaxpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','taxpayexpenseview','S','','2','ytaxpay','')
GO

-- VERIFICA DI taxpayexpenseview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'taxpayexpenseview')
UPDATE customobject set isreal = 'N' where objectname = 'taxpayexpenseview'
ELSE
INSERT INTO customobject (objectname, isreal) values('taxpayexpenseview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

