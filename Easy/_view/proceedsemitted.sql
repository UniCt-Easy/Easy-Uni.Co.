-- CREAZIONE VISTA proceedsemitted
IF EXISTS(select * from sysobjects where id = object_id(N'[proceedsemitted]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [proceedsemitted]
GO






CREATE   VIEW [proceedsemitted]
(
	idinc,
	nphase,
	ymov,
	nmov,
	--ycreation,
	parentidinc,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	curramount,
	totflag,
	flagarrear,
	flag,
	autokind,
	--idproceeds,
	idpayment,
	expiration,
	adate,
	competencydate,
	cu,
	ct,
	lu,
	lt,
	idfin,idupb
)
AS SELECT
	income.idinc,
	income.nphase,
	income.ymov,
	income.nmov,
	--income.ycreation,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	income.idreg,
	income.idman,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount, --income.amount,
	incometotal.curramount,
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	incomelast.flag,
	income.autokind,
	--income.idproceeds,
	income.idpayment,
	income.expiration,
	income.adate,
	proceeds.adate, 
	income.cu,
	income.ct,
	income.lu,
	income.lt,
	incomeyear.idfin,
	incomeyear.idupb
FROM income
JOIN incomelast
	ON incomelast.idinc = income.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND income.ymov = incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
LEFT OUTER JOIN income parentincome
	ON income.parentidinc = parentincome.idinc
LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
	ON incometotal_firstyear.idinc = income.idinc
	AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
	AND incomeyear_starting.ayear = incometotal_firstyear.ayear




GO

-- VERIFICA DI proceedsemitted IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'proceedsemitted'
IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'adate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'proceedsemitted' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','proceedsemitted','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'amount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'proceedsemitted' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','proceedsemitted','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'autokind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '1',field = 'autokind',col_precision = '' where tablename = 'proceedsemitted' AND field = 'autokind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','S','System.Byte','tinyint','N','proceedsemitted','N','','1','autokind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'competencydate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '4',field = 'competencydate',col_precision = '' where tablename = 'proceedsemitted' AND field = 'competencydate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','proceedsemitted','S','','4','competencydate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'proceedsemitted' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','proceedsemitted','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'proceedsemitted' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','proceedsemitted','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'curramount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '9',field = 'curramount',col_precision = '19' where tablename = 'proceedsemitted' AND field = 'curramount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','proceedsemitted','N','','9','curramount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'proceedsemitted' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(150)','N','proceedsemitted','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'doc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(35)',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '35',field = 'doc',col_precision = '' where tablename = 'proceedsemitted' AND field = 'doc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(35)','N','proceedsemitted','N','','35','doc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'docdate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '4',field = 'docdate',col_precision = '' where tablename = 'proceedsemitted' AND field = 'docdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedsemitted','N','','4','docdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'expiration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'proceedsemitted' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedsemitted','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'flag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'proceedsemitted' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','proceedsemitted','S','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'flagarrear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '1',field = 'flagarrear',col_precision = '' where tablename = 'proceedsemitted' AND field = 'flagarrear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(1)','N','proceedsemitted','N','','1','flagarrear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'idfin')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'proceedsemitted' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedsemitted','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'idinc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '4',field = 'idinc',col_precision = '' where tablename = 'proceedsemitted' AND field = 'idinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedsemitted','S','','4','idinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'idman')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'proceedsemitted' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedsemitted','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'idpayment')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '4',field = 'idpayment',col_precision = '' where tablename = 'proceedsemitted' AND field = 'idpayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedsemitted','N','','4','idpayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'idreg')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'proceedsemitted' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedsemitted','N','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'idupb')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'proceedsemitted' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(36)','N','proceedsemitted','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'kpro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '4',field = 'kpro',col_precision = '' where tablename = 'proceedsemitted' AND field = 'kpro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedsemitted','S','','4','kpro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'proceedsemitted' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','proceedsemitted','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'proceedsemitted' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','proceedsemitted','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'nmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'proceedsemitted' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedsemitted','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'nphase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'proceedsemitted' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','proceedsemitted','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'npro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '4',field = 'npro',col_precision = '' where tablename = 'proceedsemitted' AND field = 'npro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedsemitted','S','','4','npro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'parentidinc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '4',field = 'parentidinc',col_precision = '' where tablename = 'proceedsemitted' AND field = 'parentidinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedsemitted','N','','4','parentidinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'parentnmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '4',field = 'parentnmov',col_precision = '' where tablename = 'proceedsemitted' AND field = 'parentnmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedsemitted','N','','4','parentnmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'parentymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedsemitted',denynull = 'N',format = '',col_len = '2',field = 'parentymov',col_precision = '' where tablename = 'proceedsemitted' AND field = 'parentymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','proceedsemitted','N','','2','parentymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'totflag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '1',field = 'totflag',col_precision = '' where tablename = 'proceedsemitted' AND field = 'totflag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','proceedsemitted','S','','1','totflag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'ymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'proceedsemitted' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','proceedsemitted','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedsemitted' AND field = 'ypro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedsemitted',denynull = 'S',format = '',col_len = '2',field = 'ypro',col_precision = '' where tablename = 'proceedsemitted' AND field = 'ypro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','proceedsemitted','S','','2','ypro','')
GO

-- VERIFICA DI proceedsemitted IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'proceedsemitted')
UPDATE customobject set isreal = 'N' where objectname = 'proceedsemitted'
ELSE
INSERT INTO customobject (objectname, isreal) values('proceedsemitted', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

