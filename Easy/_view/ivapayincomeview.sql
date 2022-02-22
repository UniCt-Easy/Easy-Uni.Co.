
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


-- CREAZIONE VISTA ivapayincomeview
IF EXISTS(select * from sysobjects where id = object_id(N'[ivapayincomeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ivapayincomeview]
GO





CREATE  VIEW [ivapayincomeview]
	(
	yivapay,
	nivapay,
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	parentidinc,
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
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	unpartitioned,
	flag,
	totflag,
	flagarrear,
  	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
	)
	AS SELECT
	ivapayincome.yivapay,
	ivapayincome.nivapay,
	ivapayincome.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	--income.ycreation,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	incomeyear.ayear,
	incomeyear.idfin,
	fin.codefin,
	fin.title,
	incomeyear.idupb,
	upb.codeupb,
	upb.title,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	--income.ypro,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	--income.amount,
	incomeyear_starting.amount,
	--incometotal.amount,
	incomeyear.amount,
	incometotal.curramount,
	incometotal.available,
	ISNULL(incometotal.curramount,0)-ISNULL(incometotal.partitioned,0),
	--income.fulfilled,
	incomelast.flag,
	incometotal.flag,
	--incomeyear.flagarrear,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	income.autokind,
	--income.idproceeds,
	income.idpayment,
	income.expiration,
	income.adate,
	ivapayincome.cu,
	ivapayincome.ct,
	ivapayincome.lu,
	ivapayincome.lt
	FROM ivapayincome (NOLOCK)
	JOIN income (NOLOCK)
	ON income.idinc = ivapayincome.idinc
	JOIN incomephase (NOLOCK)
	ON incomephase.nphase = income.nphase
	JOIN incomeyear (NOLOCK)
	ON incomeyear.idinc = income.idinc
	JOIN incometotal (NOLOCK)
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN fin (NOLOCK)
	ON fin.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb (NOLOCK)
	ON upb.idupb = incomeyear.idupb
	LEFT OUTER JOIN registry (NOLOCK)
	ON registry.idreg = income.idreg
	LEFT OUTER JOIN manager (NOLOCK)
	ON manager.idman = income.idman
	LEFT OUTER JOIN incomelast  (NOLOCK)
	ON income.idinc = incomelast.idinc
	LEFT OUTER JOIN proceeds  (NOLOCK)
	ON proceeds.kpro = incomelast.kpro
	LEFT OUTER JOIN income parentincome (NOLOCK)
	ON income.parentidinc = parentincome.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  	ON incometotal_firstyear.idinc = income.idinc
  	AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  	AND incomeyear_starting.ayear = incometotal_firstyear.ayear

GO

-- VERIFICA DI ivapayincomeview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'ivapayincomeview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'adate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','ivapayincomeview','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'amount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'ivapayincomeview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','ivapayincomeview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'autokind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '1',field = 'autokind',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'autokind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','S','System.Byte','tinyint','N','ivapayincomeview','N','','1','autokind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'available')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '9',field = 'available',col_precision = '19' where tablename = 'ivapayincomeview' AND field = 'available'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','ivapayincomeview','N','','9','available','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'ayear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','ivapayincomeview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'ayearstartamount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '9',field = 'ayearstartamount',col_precision = '19' where tablename = 'ivapayincomeview' AND field = 'ayearstartamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','ivapayincomeview','N','','9','ayearstartamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'codefin')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(50)','N','ivapayincomeview','N','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'codeupb')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '50',field = 'codeupb',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'codeupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(50)','N','ivapayincomeview','N','','50','codeupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','ivapayincomeview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','ivapayincomeview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'curramount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '9',field = 'curramount',col_precision = '19' where tablename = 'ivapayincomeview' AND field = 'curramount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','ivapayincomeview','N','','9','curramount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(150)','N','ivapayincomeview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'doc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(35)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '35',field = 'doc',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'doc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(35)','N','ivapayincomeview','N','','35','doc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'docdate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '4',field = 'docdate',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'docdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','ivapayincomeview','N','','4','docdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'expiration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','ivapayincomeview','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'finance')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '150',field = 'finance',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'finance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(150)','N','ivapayincomeview','N','','150','finance','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'flag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','S','System.Byte','tinyint','N','ivapayincomeview','N','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'flagarrear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '1',field = 'flagarrear',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'flagarrear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(1)','N','ivapayincomeview','N','','1','flagarrear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'idfin')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','ivapayincomeview','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'idinc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '4',field = 'idinc',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'idinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','ivapayincomeview','S','','4','idinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'idman')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','ivapayincomeview','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'idpayment')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '4',field = 'idpayment',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'idpayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','ivapayincomeview','N','','4','idpayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'idreg')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','ivapayincomeview','N','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'idupb')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(36)','N','ivapayincomeview','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'kpro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '4',field = 'kpro',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'kpro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','ivapayincomeview','N','','4','kpro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','ivapayincomeview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','ivapayincomeview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'manager')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(150)','N','ivapayincomeview','N','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'nivapay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '4',field = 'nivapay',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'nivapay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','ivapayincomeview','S','','4','nivapay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'nmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','ivapayincomeview','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'nphase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','ivapayincomeview','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'npro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '4',field = 'npro',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'npro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','ivapayincomeview','N','','4','npro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'parentidinc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '4',field = 'parentidinc',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'parentidinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','ivapayincomeview','N','','4','parentidinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'parentnmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '4',field = 'parentnmov',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'parentnmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','ivapayincomeview','N','','4','parentnmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'parentymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '2',field = 'parentymov',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'parentymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','ivapayincomeview','N','','2','parentymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'phase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '50',field = 'phase',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'phase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','ivapayincomeview','S','','50','phase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'registry')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(100)','N','ivapayincomeview','N','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'totflag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '1',field = 'totflag',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'totflag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','ivapayincomeview','S','','1','totflag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'unpartitioned')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(20,2)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '13',field = 'unpartitioned',col_precision = '20' where tablename = 'ivapayincomeview' AND field = 'unpartitioned'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(20,2)','N','ivapayincomeview','N','','13','unpartitioned','20')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'upb')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '150',field = 'upb',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'upb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(150)','N','ivapayincomeview','N','','150','upb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'yivapay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '4',field = 'yivapay',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'yivapay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','ivapayincomeview','S','','4','yivapay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'ymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','ivapayincomeview','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'ivapayincomeview' AND field = 'ypro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'ivapayincomeview',denynull = 'N',format = '',col_len = '2',field = 'ypro',col_precision = '' where tablename = 'ivapayincomeview' AND field = 'ypro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','ivapayincomeview','N','','2','ypro','')
GO

-- VERIFICA DI ivapayincomeview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'ivapayincomeview')
UPDATE customobject set isreal = 'N' where objectname = 'ivapayincomeview'
ELSE
INSERT INTO customobject (objectname, isreal) values('ivapayincomeview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

