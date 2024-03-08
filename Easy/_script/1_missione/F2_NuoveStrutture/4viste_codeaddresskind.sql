
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA payedtaxview
IF EXISTS(select * from sysobjects where id = object_id(N'[payedtaxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payedtaxview]
GO



--Pino Rana, elaborazione del 10/08/2005 15:18:05
CREATE   VIEW [payedtaxview]
(
	cf,
	address,
	cap,
	city,
	country,
	nation,
	location,
	idexp,
	nbracket,
	abatements,
	nphase,
	phase,
	ymov,
	nmov,
	idreg,
	registry,
	expensedescription,
	adate,
	idser,
	codeser,
	service,
	certificatekind,
	servicestart,
	servicestop,
	taxcode,
	taxref,
	description,
	taxkind,
	taxablegross,
	taxablenet,
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
	cu,
	ct,
	lu,
	lt
)
	AS SELECT     
	registry.cf, 
	registryaddress.address, 
	registryaddress.cap, 
	geo_city.title, 
	geo_country.province, 
	geo_nation.title, 
	registryaddress.location,
	expensetax.idexp, 
	expensetax.nbracket, 
	expensetax.abatements,
	expense.nphase, 
	expensephase.description, 
	expense.ymov, 
	expense.nmov, 
	expense.idreg, 
	registry.title, 
	expense.description, 
	expense.adate, 
	expenselast.idser, 
	service.codeser,
	service.description, 
	service.certificatekind, 
	expenselast.servicestart, 
	expenselast.servicestop, 
	expensetax.taxcode, 
	tax.taxref,
	tax.description, 
	tax.taxkind, 
	expensetax.taxablegross, 
	expensetax.taxablenet, 
	expensetax.employrate, 
	expensetax.employnumerator, 
	expensetax.employdenominator, 
	expensetax.employtax, 
	expensetax.adminrate, 
	expensetax.adminnumerator, 
	expensetax.admindenominator, 
	expensetax.admintax, 
	expensetax.competencydate, 
	CASE config.flagtaxcompetency
		WHEN 'M' THEN payment.adate 
		WHEN 'S' THEN payment.printdate
		WHEN 'T' THEN  paymenttransmission.transmissiondate
		WHEN 'E' THEN (SELECT MIN(banktransaction.transactiondate)
			FROM banktransaction 
			WHERE banktransaction.ypay=expense.ymov
			AND banktransaction.npay=expenselast.npay)
		-- data ultima fase di spesa
		WHEN 'U' THEN expense.adate 
		ELSE expensetax.competencydate
	END,
	expensetax.ytaxpay, 
	expensetax.ntaxpay,
	expensetax.cu, expensetax.ct, expensetax.lu, expensetax.lt
FROM    
     expensetax(NOLOCK) JOIN
     tax(NOLOCK) ON tax.taxcode = expensetax.taxcode JOIN
     expense(NOLOCK) ON expense.idexp = expensetax.idexp JOIN
     expenselast(NOLOCK) ON expense.idexp = expenselast.idexp JOIN
     config(NOLOCK) ON expense.ymov = config.ayear JOIN
     expensephase(NOLOCK) ON expensephase.nphase = expense.nphase LEFT OUTER JOIN
     payment(NOLOCK) ON payment.npay = expenselast.npay  AND payment.ypay = expense.ymov LEFT OUTER JOIN
     paymenttransmission(NOLOCK) ON paymenttransmission.ypaymenttransmission =  payment.ypaymenttransmission 
				 AND paymenttransmission.npaymenttransmission = payment.npaymenttransmission 
							LEFT OUTER JOIN
     registry(NOLOCK) ON registry.idreg = expense.idreg LEFT OUTER JOIN
     service(NOLOCK) ON service.idser = expenselast.idser left outer join
     registryaddress on registry.idreg = registryaddress.idreg left outer join
     geo_city on registryaddress.idcity = geo_city.idcity left outer join
     geo_country on geo_city.idcountry = geo_country.idcountry left outer join
     geo_nation on registryaddress.idnation = geo_nation.idnation
	     where (registryaddress.idaddresskind is null or registryaddress.idaddresskind = 
		(select top 1 idaddresskind 
		   from registryaddress ci
		   join address ON registryaddress.idaddresskind = address.idaddress
		  where ci.idreg = registry.idreg
	       order by case codeaddress
				when '07_SW_DOM' then 1
				when '07_SW_DEF' then 2
				else 3
			end
		) and registryaddress.start = 
		(	select max(start)
			from registryaddress ci2
			where ci2.idreg = registry.idreg
			and ci2.idaddresskind = registryaddress.idaddresskind
		))



GO

-- VERIFICA DI payedtaxview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'payedtaxview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'abatements')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'abatements',col_precision = '19' where tablename = 'payedtaxview' AND field = 'abatements'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payedtaxview','N','','9','abatements','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'adate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'payedtaxview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','payedtaxview','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'address')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '100',field = 'address',col_precision = '' where tablename = 'payedtaxview' AND field = 'address'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','payedtaxview','N','','100','address','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'admindenominator')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'admindenominator',col_precision = '19' where tablename = 'payedtaxview' AND field = 'admindenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payedtaxview','N','','9','admindenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'adminnumerator')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'adminnumerator',col_precision = '19' where tablename = 'payedtaxview' AND field = 'adminnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payedtaxview','N','','9','adminnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'adminrate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'adminrate',col_precision = '19' where tablename = 'payedtaxview' AND field = 'adminrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payedtaxview','N','','9','adminrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'admintax')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'admintax',col_precision = '19' where tablename = 'payedtaxview' AND field = 'admintax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payedtaxview','N','','9','admintax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'cap')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '20',field = 'cap',col_precision = '' where tablename = 'payedtaxview' AND field = 'cap'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','payedtaxview','N','','20','cap','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'certificatekind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '1',field = 'certificatekind',col_precision = '' where tablename = 'payedtaxview' AND field = 'certificatekind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','payedtaxview','N','','1','certificatekind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'cf')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(16)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '16',field = 'cf',col_precision = '' where tablename = 'payedtaxview' AND field = 'cf'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(16)','N','payedtaxview','N','','16','cf','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'city')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '65',field = 'city',col_precision = '' where tablename = 'payedtaxview' AND field = 'city'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','payedtaxview','N','','65','city','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'codeser')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '20',field = 'codeser',col_precision = '' where tablename = 'payedtaxview' AND field = 'codeser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','payedtaxview','N','','20','codeser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'competencydate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '4',field = 'competencydate',col_precision = '' where tablename = 'payedtaxview' AND field = 'competencydate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','payedtaxview','N','','4','competencydate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'country')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(2)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '2',field = 'country',col_precision = '' where tablename = 'payedtaxview' AND field = 'country'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(2)','N','payedtaxview','N','','2','country','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'payedtaxview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','payedtaxview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'payedtaxview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','payedtaxview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'datetaxpay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '4',field = 'datetaxpay',col_precision = '' where tablename = 'payedtaxview' AND field = 'datetaxpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','payedtaxview','N','','4','datetaxpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'description')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'payedtaxview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','payedtaxview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'employdenominator')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'employdenominator',col_precision = '19' where tablename = 'payedtaxview' AND field = 'employdenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payedtaxview','N','','9','employdenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'employnumerator')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'employnumerator',col_precision = '19' where tablename = 'payedtaxview' AND field = 'employnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payedtaxview','N','','9','employnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'employrate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'employrate',col_precision = '19' where tablename = 'payedtaxview' AND field = 'employrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payedtaxview','N','','9','employrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'employtax')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'employtax',col_precision = '19' where tablename = 'payedtaxview' AND field = 'employtax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payedtaxview','N','','9','employtax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'expensedescription')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '150',field = 'expensedescription',col_precision = '' where tablename = 'payedtaxview' AND field = 'expensedescription'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','payedtaxview','S','','150','expensedescription','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'idexp')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '4',field = 'idexp',col_precision = '' where tablename = 'payedtaxview' AND field = 'idexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','payedtaxview','S','','4','idexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'idreg')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'payedtaxview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','payedtaxview','N','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'idser')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '4',field = 'idser',col_precision = '' where tablename = 'payedtaxview' AND field = 'idser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','payedtaxview','N','','4','idser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'location')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '50',field = 'location',col_precision = '' where tablename = 'payedtaxview' AND field = 'location'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','payedtaxview','N','','50','location','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'payedtaxview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','payedtaxview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'payedtaxview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','payedtaxview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'nation')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '65',field = 'nation',col_precision = '' where tablename = 'payedtaxview' AND field = 'nation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','payedtaxview','N','','65','nation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'nbracket')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '4',field = 'nbracket',col_precision = '' where tablename = 'payedtaxview' AND field = 'nbracket'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','payedtaxview','S','','4','nbracket','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'nmov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'payedtaxview' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','payedtaxview','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'nphase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'payedtaxview' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','N','System.Byte','tinyint','N','payedtaxview','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'ntaxpay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '4',field = 'ntaxpay',col_precision = '' where tablename = 'payedtaxview' AND field = 'ntaxpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','payedtaxview','N','','4','ntaxpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'phase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '50',field = 'phase',col_precision = '' where tablename = 'payedtaxview' AND field = 'phase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','payedtaxview','S','','50','phase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'registry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'payedtaxview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','payedtaxview','N','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'service')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '50',field = 'service',col_precision = '' where tablename = 'payedtaxview' AND field = 'service'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','payedtaxview','N','','50','service','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'servicestart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '8',field = 'servicestart',col_precision = '' where tablename = 'payedtaxview' AND field = 'servicestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','payedtaxview','N','','8','servicestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'servicestop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '8',field = 'servicestop',col_precision = '' where tablename = 'payedtaxview' AND field = 'servicestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','payedtaxview','N','','8','servicestop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'taxablegross')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablegross',col_precision = '19' where tablename = 'payedtaxview' AND field = 'taxablegross'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payedtaxview','N','','9','taxablegross','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'taxablenet')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablenet',col_precision = '19' where tablename = 'payedtaxview' AND field = 'taxablenet'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payedtaxview','N','','9','taxablenet','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'payedtaxview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','payedtaxview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'taxkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '1',field = 'taxkind',col_precision = '' where tablename = 'payedtaxview' AND field = 'taxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','payedtaxview','N','','1','taxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'taxref')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'payedtaxview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','payedtaxview','S','','20','taxref','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'ymov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'payedtaxview',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'payedtaxview' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','payedtaxview','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'payedtaxview' AND field = 'ytaxpay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'payedtaxview',denynull = 'N',format = '',col_len = '2',field = 'ytaxpay',col_precision = '' where tablename = 'payedtaxview' AND field = 'ytaxpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','payedtaxview','N','','2','ytaxpay','')
GO

-- VERIFICA DI payedtaxview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'payedtaxview')
UPDATE customobject set isreal = 'N' where objectname = 'payedtaxview'
ELSE
INSERT INTO customobject (objectname, isreal) values('payedtaxview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


-- CREAZIONE VISTA registryaddressview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryaddressview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryaddressview]
GO


--Pino Rana, elaborazione del 10/08/2005 15:17:44
-- Inserire la CREATE VIEW qui--
CREATE  VIEW [DBO].[registryaddressview]
(
idreg,
registry,
start,
stop,
idaddresskind,
codeaddress,
addresskind,
officename,
address,
idcity,
city,
location,
active,
annotations,
ct,
cu,
lt,
lu,
cap,
flagforeign,
idnation,
nation
)
AS
SELECT     
	registryaddress.idreg, 
	registry.title, 
	registryaddress.start, 
	registryaddress.stop, 
	registryaddress.idaddresskind, 
	address.codeaddress,
	address.description AS descrtipoindirizzo,
	registryaddress.officename, 
	registryaddress.address, 
	registryaddress.idcity, 
	geo_city.title AS comune, 
	registryaddress.location, 
	registryaddress.active, 
	registryaddress.annotations, 
	registryaddress.ct, 
	registryaddress.cu, 
	registryaddress.lt, 
	registryaddress.lu, 
	registryaddress.cap,
	registryaddress.flagforeign,
	registryaddress.idnation,
	geo_nation.title
FROM         registryaddress INNER JOIN
                      address ON registryaddress.idaddresskind = address.idaddress INNER JOIN
                      registry ON registryaddress.idreg = registry.idreg LEFT OUTER JOIN
                      geo_city ON registryaddress.idcity = geo_city.idcity LEFT OUTER JOIN
                      geo_nation ON registryaddress.idnation = geo_nation.idnation




GO

-- VERIFICA DI registryaddressview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryaddressview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'active')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'registryaddressview' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','registryaddressview','N','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'address')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '100',field = 'address',col_precision = '' where tablename = 'registryaddressview' AND field = 'address'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','registryaddressview','N','','100','address','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'addresskind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(60)',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '60',field = 'addresskind',col_precision = '' where tablename = 'registryaddressview' AND field = 'addresskind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(60)','N','registryaddressview','S','','60','addresskind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'annotations')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(400)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '400',field = 'annotations',col_precision = '' where tablename = 'registryaddressview' AND field = 'annotations'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(400)','N','registryaddressview','N','','400','annotations','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'cap')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '20',field = 'cap',col_precision = '' where tablename = 'registryaddressview' AND field = 'cap'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','registryaddressview','N','','20','cap','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'city')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '65',field = 'city',col_precision = '' where tablename = 'registryaddressview' AND field = 'city'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','registryaddressview','N','','65','city','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'codeaddress')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '20',field = 'codeaddress',col_precision = '' where tablename = 'registryaddressview' AND field = 'codeaddress'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','registryaddressview','S','','20','codeaddress','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'registryaddressview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registryaddressview','N','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'registryaddressview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registryaddressview','N','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'flagforeign')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '1',field = 'flagforeign',col_precision = '' where tablename = 'registryaddressview' AND field = 'flagforeign'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','registryaddressview','N','','1','flagforeign','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'idaddresskind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '4',field = 'idaddresskind',col_precision = '' where tablename = 'registryaddressview' AND field = 'idaddresskind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','registryaddressview','S','','4','idaddresskind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'idcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'registryaddressview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','registryaddressview','N','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'idnation')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '4',field = 'idnation',col_precision = '' where tablename = 'registryaddressview' AND field = 'idnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','registryaddressview','N','','4','idnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'idreg')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'registryaddressview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','registryaddressview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'location')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '50',field = 'location',col_precision = '' where tablename = 'registryaddressview' AND field = 'location'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','registryaddressview','N','','50','location','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'registryaddressview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registryaddressview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'registryaddressview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registryaddressview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'nation')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '65',field = 'nation',col_precision = '' where tablename = 'registryaddressview' AND field = 'nation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','registryaddressview','N','','65','nation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'officename')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '50',field = 'officename',col_precision = '' where tablename = 'registryaddressview' AND field = 'officename'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','registryaddressview','N','','50','officename','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'registry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'registryaddressview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(100)','N','registryaddressview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'registryaddressview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','registryaddressview','S','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'stop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'registryaddressview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','registryaddressview','N','','4','stop','')
GO

-- VERIFICA DI registryaddressview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryaddressview')
UPDATE customobject set isreal = 'N' where objectname = 'registryaddressview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryaddressview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

