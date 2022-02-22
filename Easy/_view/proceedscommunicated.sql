
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


-- CREAZIONE VISTA proceedscommunicated
IF EXISTS(select * from sysobjects where id = object_id(N'[proceedscommunicated]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [proceedscommunicated]
GO





CREATE   VIEW [proceedscommunicated]
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
	kproceedstransmission,
	yproceedstransmission,
	nproceedstransmission,
	doc,
	docdate,
	description,
	amount,
	curramount,
	totflag,
	flagarrear,
	flag,	
	autokind,
	idpayment,
	expiration,
	adate,
	printdate,
	competencydate,
	cu,
	ct,
	lu,
	lt,idfin,idupb
)
AS SELECT
	income.idinc,
	income.nphase,
	income.ymov,
	income.nmov,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	income.idreg,
	income.idman,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro, 
	proceedstransmission.kproceedstransmission,
	proceedstransmission.yproceedstransmission,
	proceedstransmission.nproceedstransmission,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount,
	incometotal.curramount,
	incometotal.flag, 
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 	
	incomelast.flag,
	income.autokind,
	income.idpayment,
	income.expiration,
	income.adate,
	proceeds.printdate,
	proceedstransmission.transmissiondate,
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
JOIN proceedstransmission
	ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
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

-- VERIFICA DI proceedscommunicated IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'proceedscommunicated'
IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'adate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','proceedscommunicated','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'amount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'proceedscommunicated' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','proceedscommunicated','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'autokind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '1',field = 'autokind',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'autokind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','S','System.Byte','tinyint','N','proceedscommunicated','N','','1','autokind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'competencydate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '4',field = 'competencydate',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'competencydate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedscommunicated','N','','4','competencydate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','proceedscommunicated','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','proceedscommunicated','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'curramount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '9',field = 'curramount',col_precision = '19' where tablename = 'proceedscommunicated' AND field = 'curramount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','proceedscommunicated','N','','9','curramount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(150)','N','proceedscommunicated','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'doc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(35)',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '35',field = 'doc',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'doc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(35)','N','proceedscommunicated','N','','35','doc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'docdate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '4',field = 'docdate',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'docdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedscommunicated','N','','4','docdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'expiration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedscommunicated','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'flag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','proceedscommunicated','S','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'flagarrear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '1',field = 'flagarrear',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'flagarrear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(1)','N','proceedscommunicated','N','','1','flagarrear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'idfin')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedscommunicated','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'idinc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '4',field = 'idinc',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'idinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedscommunicated','S','','4','idinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'idman')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedscommunicated','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'idpayment')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '4',field = 'idpayment',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'idpayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedscommunicated','N','','4','idpayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'idreg')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedscommunicated','N','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'idupb')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(36)','N','proceedscommunicated','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'kpro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '4',field = 'kpro',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'kpro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedscommunicated','S','','4','kpro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'kproceedstransmission')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '4',field = 'kproceedstransmission',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'kproceedstransmission'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedscommunicated','S','','4','kproceedstransmission','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','proceedscommunicated','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','proceedscommunicated','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'nmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedscommunicated','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'nphase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','proceedscommunicated','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'npro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '4',field = 'npro',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'npro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedscommunicated','S','','4','npro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'nproceedstransmission')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '4',field = 'nproceedstransmission',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'nproceedstransmission'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedscommunicated','S','','4','nproceedstransmission','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'parentidinc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '4',field = 'parentidinc',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'parentidinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedscommunicated','N','','4','parentidinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'parentnmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '4',field = 'parentnmov',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'parentnmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedscommunicated','N','','4','parentnmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'parentymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '2',field = 'parentymov',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'parentymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','proceedscommunicated','N','','2','parentymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'printdate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'N',format = '',col_len = '4',field = 'printdate',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'printdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedscommunicated','N','','4','printdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'totflag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '1',field = 'totflag',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'totflag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','proceedscommunicated','S','','1','totflag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'ymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','proceedscommunicated','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'ypro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '2',field = 'ypro',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'ypro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','proceedscommunicated','S','','2','ypro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedscommunicated' AND field = 'yproceedstransmission')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedscommunicated',denynull = 'S',format = '',col_len = '2',field = 'yproceedstransmission',col_precision = '' where tablename = 'proceedscommunicated' AND field = 'yproceedstransmission'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','proceedscommunicated','S','','2','yproceedstransmission','')
GO

-- VERIFICA DI proceedscommunicated IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'proceedscommunicated')
UPDATE customobject set isreal = 'N' where objectname = 'proceedscommunicated'
ELSE
INSERT INTO customobject (objectname, isreal) values('proceedscommunicated', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

