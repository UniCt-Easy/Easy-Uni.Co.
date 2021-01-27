
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


-- CREAZIONE VISTA expensetaxview
IF EXISTS(select * from sysobjects where id = object_id(N'[expensetaxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expensetaxview]
GO


CREATE       VIEW [expensetaxview]
(
	idexp,
	taxcode,
	nbracket,
	description,
	taxkind,
	taxablegross,
	taxablenet,
	taxableoriginal,
	taxref,
	exemptionquota,
	abatements,
	taxablenumerator,
	taxabledenominator,
	employrate,
	employnumerator,
	employdenominator,
	employtax,
	adminrate,
	adminnumerator,
	admindenominator,
	admintax,
	competencydate,
	datetaxpay,
	ytaxpay,
	ntaxpay,
	idaccmotive_debit,
	idaccmotive_pay,
	idcity,
	city,
	provincecode,
	idfiscaltaxregion,
	fiscaltaxregion,
	idinc,
	yincmov,
	nincmov,
	ayear,
	idtreasurer,
	treasurer,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expensetax.idexp,
	expensetax.taxcode,
	expensetax.nbracket,
	tax.description,
	tax.taxkind,
	expensetax.taxablegross,
	expensetax.taxablenet,
	expensetax.taxablegross,-- A cosa serve questo campo???
	tax.taxref,
	expensetax.exemptionquota,
	expensetax.abatements,
	expensetax.taxablenumerator,
	expensetax.taxabledenominator,
	expensetax.employrate,
	expensetax.employnumerator,
	expensetax.employdenominator,
	expensetax.employtax,
	expensetax.adminrate,
	expensetax.adminnumerator,
	expensetax.admindenominator,
	expensetax.admintax,
	expensetax.competencydate,
	CASE config.taxvaliditykind 
		-- data ultima fase di spesa
		WHEN '2' THEN expense.adate 
		WHEN '3' THEN payment.adate 
		WHEN '4' THEN payment.printdate
		WHEN '5' THEN  paymenttransmission.transmissiondate
		WHEN '6' THEN (SELECT MIN(banktransaction.transactiondate)
			FROM banktransaction 
			WHERE banktransaction.kpay=expenselast.kpay)
		ELSE expensetax.competencydate
	END,
	expensetax.ytaxpay,
	expensetax.ntaxpay,
	case when tax2.idser is null then tax1.idaccmotive_debit else tax2.idaccmotive_debit end,
	case when tax2.idser is null then tax1.idaccmotive_pay else tax2.idaccmotive_pay end,
	expensetax.idcity,
	geo_city.title,
	geo_country.province,
	expensetax.idfiscaltaxregion,
	fiscaltaxregion.title,
	expensetax.idinc,
	income.ymov,
	income.nmov,
	expensetax.ayear,
	payment.idtreasurer,
	treasurer.description,
	expensetax.cu,
	expensetax.ct,
	expensetax.lu,
	expensetax.lt
FROM expensetax
JOIN tax 	ON tax.taxcode = expensetax.taxcode
JOIN expense 	ON expensetax.idexp = expense.idexp
JOIN expenselast	ON expense.idexp = expenselast.idexp 
JOIN config 	ON expense.ymov = config.ayear
LEFT OUTER JOIN payment 	ON payment.kpay = expenselast.kpay  
LEFT OUTER JOIN treasurer	ON treasurer.idtreasurer = payment.idtreasurer
LEFT OUTER JOIN paymenttransmission 	ON paymenttransmission.kpaymenttransmission =  payment.kpaymenttransmission 
LEFT OUTER JOIN geo_city 	ON geo_city.idcity = expensetax.idcity
LEFT OUTER JOIN geo_country 	ON geo_country.idcountry = geo_city.idcountry
LEFT OUTER JOIN fiscaltaxregion 	ON fiscaltaxregion.idfiscaltaxregion = expensetax.idfiscaltaxregion
LEFT OUTER JOIN income 	ON income.idinc = expensetax.idinc
LEFT OUTER JOIN taxmotiveyear tax1 on tax1.taxcode= expensetax.taxcode and tax1.idser is null and tax1.ayear=expense.ymov
LEFT OUTER JOIN taxmotiveyear tax2 on tax2.taxcode= expensetax.taxcode and tax2.idser =expenselast.idser and tax2.ayear=expense.ymov






GO

-- VERIFICA DI expensetaxview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'expensetaxview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'abatements')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'abatements',col_precision = '19' where tablename = 'expensetaxview' AND field = 'abatements'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxview','N','','9','abatements','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'admindenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'admindenominator',col_precision = '19' where tablename = 'expensetaxview' AND field = 'admindenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxview','N','','9','admindenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'adminnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'adminnumerator',col_precision = '19' where tablename = 'expensetaxview' AND field = 'adminnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxview','N','','9','adminnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'adminrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'adminrate',col_precision = '19' where tablename = 'expensetaxview' AND field = 'adminrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxview','N','','9','adminrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'admintax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'admintax',col_precision = '19' where tablename = 'expensetaxview' AND field = 'admintax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxview','N','','9','admintax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'competencydate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '4',field = 'competencydate',col_precision = '' where tablename = 'expensetaxview' AND field = 'competencydate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','expensetaxview','N','','4','competencydate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'expensetaxview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'expensetaxview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','expensetaxview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'expensetaxview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'expensetaxview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','expensetaxview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'datetaxpay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '4',field = 'datetaxpay',col_precision = '' where tablename = 'expensetaxview' AND field = 'datetaxpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','expensetaxview','N','','4','datetaxpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'expensetaxview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'expensetaxview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','expensetaxview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'employdenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'employdenominator',col_precision = '19' where tablename = 'expensetaxview' AND field = 'employdenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxview','N','','9','employdenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'employnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'employnumerator',col_precision = '19' where tablename = 'expensetaxview' AND field = 'employnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxview','N','','9','employnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'employrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'employrate',col_precision = '19' where tablename = 'expensetaxview' AND field = 'employrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxview','N','','9','employrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'employtax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'employtax',col_precision = '19' where tablename = 'expensetaxview' AND field = 'employtax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxview','N','','9','employtax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'exemptionquota')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'exemptionquota',col_precision = '19' where tablename = 'expensetaxview' AND field = 'exemptionquota'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxview','N','','9','exemptionquota','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'idaccmotive_debit')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '36',field = 'idaccmotive_debit',col_precision = '' where tablename = 'expensetaxview' AND field = 'idaccmotive_debit'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(36)','N','expensetaxview','N','','36','idaccmotive_debit','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'idaccmotive_pay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '36',field = 'idaccmotive_pay',col_precision = '' where tablename = 'expensetaxview' AND field = 'idaccmotive_pay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(36)','N','expensetaxview','N','','36','idaccmotive_pay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'idexp')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expensetaxview',denynull = 'S',format = '',col_len = '4',field = 'idexp',col_precision = '' where tablename = 'expensetaxview' AND field = 'idexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','expensetaxview','S','','4','idexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'expensetaxview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'expensetaxview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','expensetaxview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'expensetaxview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'expensetaxview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','expensetaxview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'nbracket')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expensetaxview',denynull = 'S',format = '',col_len = '4',field = 'nbracket',col_precision = '' where tablename = 'expensetaxview' AND field = 'nbracket'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','expensetaxview','S','','4','nbracket','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'ntaxpay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '4',field = 'ntaxpay',col_precision = '' where tablename = 'expensetaxview' AND field = 'ntaxpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','expensetaxview','N','','4','ntaxpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'taxabledenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'taxabledenominator',col_precision = '19' where tablename = 'expensetaxview' AND field = 'taxabledenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxview','N','','9','taxabledenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'taxablegross')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablegross',col_precision = '19' where tablename = 'expensetaxview' AND field = 'taxablegross'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxview','N','','9','taxablegross','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'taxablenet')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablenet',col_precision = '19' where tablename = 'expensetaxview' AND field = 'taxablenet'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxview','N','','9','taxablenet','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'taxablenumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablenumerator',col_precision = '19' where tablename = 'expensetaxview' AND field = 'taxablenumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxview','N','','9','taxablenumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'taxableoriginal')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '9',field = 'taxableoriginal',col_precision = '19' where tablename = 'expensetaxview' AND field = 'taxableoriginal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxview','N','','9','taxableoriginal','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expensetaxview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'expensetaxview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','expensetaxview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'taxkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'expensetaxview',denynull = 'S',format = '',col_len = '2',field = 'taxkind',col_precision = '' where tablename = 'expensetaxview' AND field = 'taxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','expensetaxview','S','','2','taxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'taxref')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'expensetaxview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'expensetaxview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(20)','N','expensetaxview','S','','20','taxref','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetaxview' AND field = 'ytaxpay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'expensetaxview',denynull = 'N',format = '',col_len = '2',field = 'ytaxpay',col_precision = '' where tablename = 'expensetaxview' AND field = 'ytaxpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','expensetaxview','N','','2','ytaxpay','')
GO

-- VERIFICA DI expensetaxview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'expensetaxview')
UPDATE customobject set isreal = 'N' where objectname = 'expensetaxview'
ELSE
INSERT INTO customobject (objectname, isreal) values('expensetaxview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

