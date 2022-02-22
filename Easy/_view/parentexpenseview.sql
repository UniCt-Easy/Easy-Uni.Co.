
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


-- CREAZIONE VISTA parentexpenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[parentexpenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [parentexpenseview]
GO




CREATE     VIEW parentexpenseview
(
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idformerexpense,
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
	paymentadate,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idregistrypaymethod,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	iddeputy,
	deputy,
	refexternaldoc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	autocode,
	idclawback,
	clawback,
	clawbackref,
	nbill,
	idpay,
	txt,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expensechild.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idformerexpense,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	payment.adate,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idregistrypaymethod,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.iddeputy,  
	deputy.title,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	expense.autocode,
	expense.idclawback,
	clawback.description,
	clawback.clawbackref,
	expenselast.nbill,
	expenselast.idpay,
	expense.txt,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt
FROM expense
JOIN expense expensechild
	ON expense.idexp= expensechild.parentidexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expense.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON parentexpense.idexp = expense.parentidexp
LEFT OUTER JOIN expenselast 
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN registry deputy
	ON deputy.idreg = expenselast.iddeputy
LEFT OUTER JOIN clawback
	ON clawback.idclawback = expense.idclawback
LEFT OUTER JOIN expensetotal expensetotal_firstyear
  	ON expensetotal_firstyear.idexp = expense.idexp
  	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear



GO

-- VERIFICA DI parentexpenseview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'parentexpenseview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'adate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'parentexpenseview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','parentexpenseview','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'amount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'parentexpenseview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','parentexpenseview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'autocode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'autocode',col_precision = '' where tablename = 'parentexpenseview' AND field = 'autocode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','autocode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'autokind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '1',field = 'autokind',col_precision = '' where tablename = 'parentexpenseview' AND field = 'autokind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','parentexpenseview','N','','1','autokind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'available')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '9',field = 'available',col_precision = '19' where tablename = 'parentexpenseview' AND field = 'available'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','parentexpenseview','N','','9','available','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'parentexpenseview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','parentexpenseview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'ayearstartamount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '9',field = 'ayearstartamount',col_precision = '19' where tablename = 'parentexpenseview' AND field = 'ayearstartamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','parentexpenseview','N','','9','ayearstartamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'cc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(30)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '30',field = 'cc',col_precision = '' where tablename = 'parentexpenseview' AND field = 'cc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(30)','N','parentexpenseview','N','','30','cc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'cin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(2)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '2',field = 'cin',col_precision = '' where tablename = 'parentexpenseview' AND field = 'cin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(2)','N','parentexpenseview','N','','2','cin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'clawback')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '50',field = 'clawback',col_precision = '' where tablename = 'parentexpenseview' AND field = 'clawback'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','parentexpenseview','N','','50','clawback','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'clawbackref')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '20',field = 'clawbackref',col_precision = '' where tablename = 'parentexpenseview' AND field = 'clawbackref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','parentexpenseview','N','','20','clawbackref','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'codefin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'parentexpenseview' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','parentexpenseview','N','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'codeser')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '20',field = 'codeser',col_precision = '' where tablename = 'parentexpenseview' AND field = 'codeser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','parentexpenseview','N','','20','codeser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'codeupb')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '50',field = 'codeupb',col_precision = '' where tablename = 'parentexpenseview' AND field = 'codeupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','parentexpenseview','N','','50','codeupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'parentexpenseview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','parentexpenseview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'parentexpenseview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','parentexpenseview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'curramount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '9',field = 'curramount',col_precision = '19' where tablename = 'parentexpenseview' AND field = 'curramount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','parentexpenseview','N','','9','curramount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'deputy')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '100',field = 'deputy',col_precision = '' where tablename = 'parentexpenseview' AND field = 'deputy'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','parentexpenseview','N','','100','deputy','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'description')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'parentexpenseview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','parentexpenseview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'doc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(35)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '35',field = 'doc',col_precision = '' where tablename = 'parentexpenseview' AND field = 'doc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(35)','N','parentexpenseview','N','','35','doc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'docdate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'docdate',col_precision = '' where tablename = 'parentexpenseview' AND field = 'docdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','parentexpenseview','N','','4','docdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'expiration')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'parentexpenseview' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','parentexpenseview','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'finance')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '150',field = 'finance',col_precision = '' where tablename = 'parentexpenseview' AND field = 'finance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','parentexpenseview','N','','150','finance','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'flag')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'parentexpenseview' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','parentexpenseview','N','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'flagarrear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '1',field = 'flagarrear',col_precision = '' where tablename = 'parentexpenseview' AND field = 'flagarrear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(1)','N','parentexpenseview','N','','1','flagarrear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'iban')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '50',field = 'iban',col_precision = '' where tablename = 'parentexpenseview' AND field = 'iban'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','parentexpenseview','N','','50','iban','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idbank')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '20',field = 'idbank',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idbank'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','parentexpenseview','N','','20','idbank','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idcab')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '20',field = 'idcab',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idcab'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','parentexpenseview','N','','20','idcab','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idclawback')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idclawback',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idclawback'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','idclawback','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'iddeputy')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'iddeputy',col_precision = '' where tablename = 'parentexpenseview' AND field = 'iddeputy'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','iddeputy','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idexp')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '4',field = 'idexp',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','parentexpenseview','S','','4','idexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idformerexpense')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idformerexpense',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idformerexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','idformerexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idman')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idpay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idpay',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','idpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idpayment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idpayment',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idpayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','idpayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idpaymethod')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idpaymethod',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idpaymethod'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','idpaymethod','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idreg')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idregistrypaymethod')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idregistrypaymethod',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idregistrypaymethod'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','idregistrypaymethod','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idser')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'idser',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','idser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'idupb')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'parentexpenseview' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(36)','N','parentexpenseview','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'ivaamount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '9',field = 'ivaamount',col_precision = '19' where tablename = 'parentexpenseview' AND field = 'ivaamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','parentexpenseview','N','','9','ivaamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'kpay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'kpay',col_precision = '' where tablename = 'parentexpenseview' AND field = 'kpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','kpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'parentexpenseview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','parentexpenseview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'parentexpenseview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','parentexpenseview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'manager')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'parentexpenseview' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','parentexpenseview','N','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'nbill')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'nbill',col_precision = '' where tablename = 'parentexpenseview' AND field = 'nbill'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','nbill','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'nmov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'parentexpenseview' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','parentexpenseview','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'npay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'npay',col_precision = '' where tablename = 'parentexpenseview' AND field = 'npay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','npay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'nphase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'parentexpenseview' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','N','System.Byte','tinyint','N','parentexpenseview','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'parentidexp')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'parentidexp',col_precision = '' where tablename = 'parentexpenseview' AND field = 'parentidexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','parentidexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'parentnmov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'parentnmov',col_precision = '' where tablename = 'parentexpenseview' AND field = 'parentnmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','parentexpenseview','N','','4','parentnmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'parentymov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '2',field = 'parentymov',col_precision = '' where tablename = 'parentexpenseview' AND field = 'parentymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','parentexpenseview','N','','2','parentymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'paymentadate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '4',field = 'paymentadate',col_precision = '' where tablename = 'parentexpenseview' AND field = 'paymentadate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','parentexpenseview','N','','4','paymentadate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'paymentdescr')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '150',field = 'paymentdescr',col_precision = '' where tablename = 'parentexpenseview' AND field = 'paymentdescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','parentexpenseview','N','','150','paymentdescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'phase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '50',field = 'phase',col_precision = '' where tablename = 'parentexpenseview' AND field = 'phase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','parentexpenseview','S','','50','phase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'refexternaldoc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(5)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '5',field = 'refexternaldoc',col_precision = '' where tablename = 'parentexpenseview' AND field = 'refexternaldoc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(5)','N','parentexpenseview','N','','5','refexternaldoc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'registry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'parentexpenseview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','parentexpenseview','N','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'service')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '50',field = 'service',col_precision = '' where tablename = 'parentexpenseview' AND field = 'service'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','parentexpenseview','N','','50','service','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'servicestart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '8',field = 'servicestart',col_precision = '' where tablename = 'parentexpenseview' AND field = 'servicestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','parentexpenseview','N','','8','servicestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'servicestop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '8',field = 'servicestop',col_precision = '' where tablename = 'parentexpenseview' AND field = 'servicestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','parentexpenseview','N','','8','servicestop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'totflag')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '1',field = 'totflag',col_precision = '' where tablename = 'parentexpenseview' AND field = 'totflag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','parentexpenseview','N','','1','totflag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'txt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'text',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'text',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '16',field = 'txt',col_precision = '' where tablename = 'parentexpenseview' AND field = 'txt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','text','','S','System.String','text','N','parentexpenseview','N','','16','txt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'upb')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '150',field = 'upb',col_precision = '' where tablename = 'parentexpenseview' AND field = 'upb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','parentexpenseview','N','','150','upb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'ymov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'parentexpenseview',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'parentexpenseview' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','parentexpenseview','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'parentexpenseview' AND field = 'ypay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'parentexpenseview',denynull = 'N',format = '',col_len = '2',field = 'ypay',col_precision = '' where tablename = 'parentexpenseview' AND field = 'ypay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','parentexpenseview','N','','2','ypay','')
GO

-- VERIFICA DI parentexpenseview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'parentexpenseview')
UPDATE customobject set isreal = 'N' where objectname = 'parentexpenseview'
ELSE
INSERT INTO customobject (objectname, isreal) values('parentexpenseview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

