
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


-- CREAZIONE VISTA pettycashincomeview
IF EXISTS(select * from sysobjects where id = object_id(N'[pettycashincomeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pettycashincomeview]
GO





CREATE   VIEW pettycashincomeview 
(
	yoperation,
	noperation,
	idpettycash,
	pettycode,
	pettycash,
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
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	flag,
	idpayment,
	totflag,
	flagarrear,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	pettycashincome.yoperation,
	pettycashincome.noperation,
	pettycashincome.idpettycash,
	pettycash.pettycode,
	pettycash.description,
	income.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
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
	income.ymov,
	incomelast.npro,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount,
	incomeyear.amount,
	incometotal.curramount,
	incometotal.available,
	incomelast.flag, 
	income.idpayment,
	incometotal.flag,
	CASE
		when ((incometotal.flag & 1)=0) then 'C'
		when ((incometotal.flag & 1)=1) then 'R'
	End,
	income.expiration,
	income.adate,
	pettycashincome.cu,
	pettycashincome.ct,
	pettycashincome.lu,
	pettycashincome.lt
FROM pettycashincome
JOIN pettycash
	ON pettycash.idpettycash = pettycashincome.idpettycash
JOIN income
	ON pettycashincome.idinc = income.idinc
JOIN incomephase
	ON incomephase.nphase = income.nphase
JOIN incomeyear
	ON incomeyear.idinc = income.idinc
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
LEFT OUTER JOIN income parentincome
	ON parentincome.idinc = income.parentidinc
LEFT OUTER JOIN incomelast
	ON income.idinc = incomelast.idinc
LEFT OUTER JOIN incometotal incometotal_firstyear
	ON incometotal_firstyear.idinc = income.idinc
	AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting
	ON incomeyear_starting.idinc =incometotal_firstyear.idinc
	AND incomeyear_starting.ayear =incometotal_firstyear.ayear
LEFT OUTER JOIN fin
	ON fin.idfin = incomeyear.idfin
LEFT OUTER JOIN registry
	ON registry.idreg = income.idreg
LEFT OUTER JOIN manager
	ON manager.idman = income.idman
LEFT OUTER JOIN upb
	ON upb.idupb = incomeyear.idupb




GO

-- VERIFICA DI pettycashincomeview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pettycashincomeview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'adate')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','pettycashincomeview','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'amount')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'pettycashincomeview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','pettycashincomeview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'available')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '9',field = 'available',col_precision = '19' where tablename = 'pettycashincomeview' AND field = 'available'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','pettycashincomeview','N','','9','available','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'ayear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','pettycashincomeview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'ayearstartamount')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '9',field = 'ayearstartamount',col_precision = '19' where tablename = 'pettycashincomeview' AND field = 'ayearstartamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','pettycashincomeview','N','','9','ayearstartamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'codefin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','pettycashincomeview','N','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'codeupb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '50',field = 'codeupb',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'codeupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','pettycashincomeview','N','','50','codeupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','pettycashincomeview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','pettycashincomeview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'curramount')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '9',field = 'curramount',col_precision = '19' where tablename = 'pettycashincomeview' AND field = 'curramount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','pettycashincomeview','N','','9','curramount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(150)','N','pettycashincomeview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'doc')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(35)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '35',field = 'doc',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'doc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(35)','N','pettycashincomeview','N','','35','doc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'docdate')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '4',field = 'docdate',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'docdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','pettycashincomeview','N','','4','docdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'expiration')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','pettycashincomeview','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'finance')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '150',field = 'finance',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'finance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','pettycashincomeview','N','','150','finance','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'flag')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','S','System.Byte','tinyint','N','pettycashincomeview','N','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'flagarrear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '1',field = 'flagarrear',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'flagarrear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(1)','N','pettycashincomeview','N','','1','flagarrear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'idfin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','pettycashincomeview','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'idinc')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '4',field = 'idinc',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'idinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','pettycashincomeview','S','','4','idinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'idman')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','pettycashincomeview','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'idpayment')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '4',field = 'idpayment',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'idpayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','pettycashincomeview','N','','4','idpayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'idpettycash')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '4',field = 'idpettycash',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'idpettycash'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','pettycashincomeview','S','','4','idpettycash','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'idreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','pettycashincomeview','N','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'idupb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(36)','N','pettycashincomeview','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','pettycashincomeview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','pettycashincomeview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'manager')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','pettycashincomeview','N','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'nmov')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','pettycashincomeview','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'noperation')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '4',field = 'noperation',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'noperation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','pettycashincomeview','S','','4','noperation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'nphase')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','N','pettycashincomeview','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'npro')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '4',field = 'npro',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'npro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','pettycashincomeview','N','','4','npro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'parentidinc')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '4',field = 'parentidinc',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'parentidinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','pettycashincomeview','N','','4','parentidinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'parentnmov')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '4',field = 'parentnmov',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'parentnmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','pettycashincomeview','N','','4','parentnmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'parentymov')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '2',field = 'parentymov',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'parentymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','S','System.Int16','smallint','N','pettycashincomeview','N','','2','parentymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'pettycash')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '50',field = 'pettycash',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'pettycash'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','pettycashincomeview','S','','50','pettycash','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'pettycode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '20',field = 'pettycode',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'pettycode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','pettycashincomeview','N','','20','pettycode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'phase')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '50',field = 'phase',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'phase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','pettycashincomeview','S','','50','phase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'registry')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(100)','N','pettycashincomeview','N','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'totflag')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '1',field = 'totflag',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'totflag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','N','pettycashincomeview','S','','1','totflag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'upb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'N',format = '',col_len = '150',field = 'upb',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'upb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','pettycashincomeview','N','','150','upb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'ymov')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','pettycashincomeview','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'yoperation')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '2',field = 'yoperation',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'yoperation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','pettycashincomeview','S','','2','yoperation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'pettycashincomeview' AND field = 'ypro')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'pettycashincomeview',denynull = 'S',format = '',col_len = '2',field = 'ypro',col_precision = '' where tablename = 'pettycashincomeview' AND field = 'ypro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','pettycashincomeview','S','','2','ypro','')
GO

-- VERIFICA DI pettycashincomeview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pettycashincomeview')
UPDATE customobject set isreal = 'N' where objectname = 'pettycashincomeview'
ELSE
INSERT INTO customobject (objectname, isreal) values('pettycashincomeview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

