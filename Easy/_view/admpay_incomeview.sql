
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA admpay_incomeview
IF EXISTS(select * from sysobjects where id = object_id(N'[admpay_incomeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [admpay_incomeview]
GO




CREATE   VIEW admpay_incomeview
(
	yadmpay,
	nadmpay,
	nincome,
	nassessment,
	idreg,
	registry,
	description,
	amount,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	admpay_income.yadmpay,
	admpay_income.nadmpay,
	admpay_income.nincome,
	admpay_income.nassessment,
	admpay_income.idreg,
	registry.title, 
	admpay_income.description,
	admpay_income.amount,
	admpay_income.cu,
	admpay_income.ct,
	admpay_income.lu,
	admpay_income.lt
FROM admpay_income
LEFT OUTER JOIN registry
	ON registry.idreg = admpay_income.idreg



GO

-- VERIFICA DI admpay_incomeview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'admpay_incomeview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'amount')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'admpay_incomeview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','N','System.Decimal','decimal(19,2)','N','admpay_incomeview','S','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','admpay_incomeview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(68)',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '68',field = 'cu',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(68)','N','admpay_incomeview','S','','68','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(150)','N','admpay_incomeview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'idreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','admpay_incomeview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','admpay_incomeview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(68)',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '68',field = 'lu',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(68)','N','admpay_incomeview','S','','68','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'nadmpay')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '4',field = 'nadmpay',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'nadmpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','admpay_incomeview','S','','4','nadmpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'nassessment')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '4',field = 'nassessment',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'nassessment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','admpay_incomeview','S','','4','nassessment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'nincome')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '4',field = 'nincome',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'nincome'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','admpay_incomeview','S','','4','nincome','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'registry')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'N',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(100)','N','admpay_incomeview','N','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_incomeview' AND field = 'yadmpay')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_incomeview',denynull = 'S',format = '',col_len = '4',field = 'yadmpay',col_precision = '' where tablename = 'admpay_incomeview' AND field = 'yadmpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','admpay_incomeview','S','','4','yadmpay','')
GO

-- VERIFICA DI admpay_incomeview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'admpay_incomeview')
UPDATE customobject set isreal = 'N' where objectname = 'admpay_incomeview'
ELSE
INSERT INTO customobject (objectname, isreal) values('admpay_incomeview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

