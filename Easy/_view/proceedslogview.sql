-- CREAZIONE VISTA proceedslogview
IF EXISTS(select * from sysobjects where id = object_id(N'[proceedslogview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [proceedslogview]
GO


CREATE VIEW proceedslogview
(
	idinc,
	nphase,
	ymov,
	nmov,
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
	flag, 
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
 incomeyear_starting.amount,-- income.amount,
   incomelast.flag,--income.fulfilled, income.autokind,
  --- income.idproceeds,
  income.idpayment,
  income.expiration,
  income.adate,
	CASE config.cashvaliditykind  
		WHEN 1 THEN proceeds.adate 
		WHEN 2 THEN proceeds.printdate
		WHEN 4 THEN	( SELECT MIN(banktransaction.transactiondate)
				FROM banktransaction
				WHERE banktransaction.kpro=incomelast.kpro
				)
		ELSE proceedstransmission.transmissiondate --3
	END,
  income.cu,
  income.ct,
  income.lu,
  income.lt
FROM income
JOIN incomelast
	ON income.idinc = incomelast.idinc
LEFT OUTER JOIN config
	ON config.ayear = income.ymov
LEFT OUTER JOIN income parentincome (NOLOCK)
	ON parentincome.idinc = income.parentidinc
LEFT OUTER JOIN proceeds(NOLOCK) 
	ON proceeds.kpro = incomelast.kpro
LEFT OUTER JOIN proceedstransmission(NOLOCK) 
	ON proceedstransmission.kproceedstransmission =  proceeds.kproceedstransmission 
LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
		ON incometotal_firstyear.idinc = income.idinc
		AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
--WHERE income.nphase = (SELECT MAX(nphase) FROM incomephase)












GO

-- VERIFICA DI proceedslogview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'proceedslogview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'adate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'proceedslogview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','proceedslogview','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'amount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'proceedslogview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','proceedslogview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'competencydate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '4',field = 'competencydate',col_precision = '' where tablename = 'proceedslogview' AND field = 'competencydate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedslogview','N','','4','competencydate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'proceedslogview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','proceedslogview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'proceedslogview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','proceedslogview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'proceedslogview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(150)','N','proceedslogview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'doc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(35)',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '35',field = 'doc',col_precision = '' where tablename = 'proceedslogview' AND field = 'doc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(35)','N','proceedslogview','N','','35','doc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'docdate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '4',field = 'docdate',col_precision = '' where tablename = 'proceedslogview' AND field = 'docdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedslogview','N','','4','docdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'expiration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'proceedslogview' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedslogview','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'flag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'proceedslogview' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','proceedslogview','S','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'idinc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '4',field = 'idinc',col_precision = '' where tablename = 'proceedslogview' AND field = 'idinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedslogview','S','','4','idinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'idman')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'proceedslogview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedslogview','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'idpayment')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '4',field = 'idpayment',col_precision = '' where tablename = 'proceedslogview' AND field = 'idpayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedslogview','N','','4','idpayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'idreg')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'proceedslogview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedslogview','N','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'kpro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '4',field = 'kpro',col_precision = '' where tablename = 'proceedslogview' AND field = 'kpro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedslogview','N','','4','kpro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'proceedslogview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','proceedslogview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'proceedslogview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','proceedslogview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'nmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'proceedslogview' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedslogview','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'nphase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'proceedslogview' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','proceedslogview','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'npro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '4',field = 'npro',col_precision = '' where tablename = 'proceedslogview' AND field = 'npro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedslogview','N','','4','npro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'parentidinc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '4',field = 'parentidinc',col_precision = '' where tablename = 'proceedslogview' AND field = 'parentidinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedslogview','N','','4','parentidinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'parentnmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '4',field = 'parentnmov',col_precision = '' where tablename = 'proceedslogview' AND field = 'parentnmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedslogview','N','','4','parentnmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'parentymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '2',field = 'parentymov',col_precision = '' where tablename = 'proceedslogview' AND field = 'parentymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','proceedslogview','N','','2','parentymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'ymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedslogview',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'proceedslogview' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','proceedslogview','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedslogview' AND field = 'ypro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedslogview',denynull = 'N',format = '',col_len = '2',field = 'ypro',col_precision = '' where tablename = 'proceedslogview' AND field = 'ypro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','proceedslogview','N','','2','ypro','')
GO

-- VERIFICA DI proceedslogview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'proceedslogview')
UPDATE customobject set isreal = 'N' where objectname = 'proceedslogview'
ELSE
INSERT INTO customobject (objectname, isreal) values('proceedslogview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

