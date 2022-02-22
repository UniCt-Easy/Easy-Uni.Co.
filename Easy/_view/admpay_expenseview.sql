
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


-- CREAZIONE VISTA admpay_expenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[admpay_expenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [admpay_expenseview]
GO






CREATE   VIEW admpay_expenseview
(
	yadmpay,
	nadmpay,
	nexpense,
	nappropriation,
	idreg,
	registry,
	idser,
	service,
	codeser, 
	start,
	stop,
	description,
	amount,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
admpay_expense.yadmpay,
admpay_expense.nadmpay,
admpay_expense.nexpense,
admpay_expense.nappropriation,
admpay_expense.idreg,
registry.title,
admpay_expense.idser,
service.description,
service.codeser,
admpay_expense.start,
admpay_expense.stop,
admpay_expense.description,
admpay_expense.amount,
admpay_expense.cu,
admpay_expense.ct,
admpay_expense.lu,
admpay_expense.lt
FROM admpay_expense
LEFT OUTER JOIN registry
	ON registry.idreg = admpay_expense.idreg
LEFT OUTER JOIN service
	ON service.idser = admpay_expense.idser







GO

-- VERIFICA DI admpay_expenseview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'admpay_expenseview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'amount')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'admpay_expenseview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','N','System.Decimal','decimal(19,2)','N','admpay_expenseview','S','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'codeser')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'N',format = '',col_len = '20',field = 'codeser',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'codeser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','admpay_expenseview','N','','20','codeser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','admpay_expenseview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','admpay_expenseview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(150)','N','admpay_expenseview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'idreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','admpay_expenseview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'idser')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'N',format = '',col_len = '4',field = 'idser',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'idser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','admpay_expenseview','N','','4','idser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','admpay_expenseview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','admpay_expenseview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'nadmpay')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '4',field = 'nadmpay',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'nadmpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','admpay_expenseview','S','','4','nadmpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'nappropriation')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '4',field = 'nappropriation',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'nappropriation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','admpay_expenseview','S','','4','nappropriation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'nexpense')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '4',field = 'nexpense',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'nexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','admpay_expenseview','S','','4','nexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'registry')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'N',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(100)','N','admpay_expenseview','N','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'service')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'N',format = '',col_len = '50',field = 'service',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'service'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','admpay_expenseview','N','','50','service','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'start')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'N',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','admpay_expenseview','N','','8','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'stop')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'N',format = '',col_len = '8',field = 'stop',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','admpay_expenseview','N','','8','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_expenseview' AND field = 'yadmpay')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_expenseview',denynull = 'S',format = '',col_len = '4',field = 'yadmpay',col_precision = '' where tablename = 'admpay_expenseview' AND field = 'yadmpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','admpay_expenseview','S','','4','yadmpay','')
GO

-- VERIFICA DI admpay_expenseview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'admpay_expenseview')
UPDATE customobject set isreal = 'N' where objectname = 'admpay_expenseview'
ELSE
INSERT INTO customobject (objectname, isreal) values('admpay_expenseview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

