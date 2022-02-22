
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


-- CREAZIONE VISTA casualcontracttaxbracketview
IF EXISTS(select * from sysobjects where id = object_id(N'[casualcontracttaxbracketview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [casualcontracttaxbracketview]
GO



CREATE  VIEW [casualcontracttaxbracketview]
(
	taxcode,
	description,
	taxref,
	ycon,
	ncon,
	nbracket,
	adminrate,
	employrate,
	taxablegross,
	deduction,
	totaltaxablenet,
	taxablenet,
	admindenominator,
	employdenominator,
	taxabledenominator,
	adminnumerator,
	employnumerator,
	taxablenumerator,
	totaladmintax,
	totalemploytax,
	admintax,
	employtax,
	employtaxgross,
	taxkind,
	lu,
	lt
)
AS SELECT
	CCT.taxcode,
	TR.description,
	TR.taxref,
	CCT.ycon,
	CCT.ncon,
	CCTB.nbracket,
	CCTB.adminrate,
	CCTB.employrate,
	CCT.taxablegross,
	CCT.deduction,
	CCT.taxablenet,
	CCTB.taxable,
	CCT.admindenominator,
	CCT.employdenominator,
	CCT.taxabledenominator,
	CCT.adminnumerator,
	CCT.employnumerator,
	CCT.taxablenumerator,
	CCT.admintax,
	CCT.employtax,
	CCTB.admintax,
	CCTB.employtax,
	CCT.employtaxgross,
	TR.taxkind,
	CCTB.lu,
	CCTB.lt
FROM casualcontracttaxbracket CCTB
JOIN casualcontracttax CCT
	ON CCTB.taxcode = CCT.taxcode
	AND CCTB.ycon = CCT.ycon
	AND CCTB.ncon = CCT.ncon
JOIN tax TR
	ON CCT.taxcode = TR.taxcode




GO

-- VERIFICA DI casualcontracttaxbracketview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'casualcontracttaxbracketview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'admindenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'admindenominator',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'admindenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxbracketview','N','','9','admindenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'adminnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'adminnumerator',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'adminnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxbracketview','N','','9','adminnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'adminrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'adminrate',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'adminrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxbracketview','N','','9','adminrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'admintax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'admintax',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'admintax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxbracketview','N','','9','admintax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'deduction')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'deduction',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'deduction'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxbracketview','N','','9','deduction','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'casualcontracttaxbracketview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','casualcontracttaxbracketview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'employdenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'employdenominator',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'employdenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxbracketview','N','','9','employdenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'employnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'employnumerator',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'employnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxbracketview','N','','9','employnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'employrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'employrate',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'employrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxbracketview','N','','9','employrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'employtax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'employtax',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'employtax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxbracketview','N','','9','employtax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'employtaxgross')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'employtaxgross',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'employtaxgross'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxbracketview','N','','9','employtaxgross','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'casualcontracttaxbracketview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','casualcontracttaxbracketview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'casualcontracttaxbracketview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','casualcontracttaxbracketview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'nbracket')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'S',format = '',col_len = '4',field = 'nbracket',col_precision = '' where tablename = 'casualcontracttaxbracketview' AND field = 'nbracket'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','casualcontracttaxbracketview','S','','4','nbracket','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'ncon')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'S',format = '',col_len = '4',field = 'ncon',col_precision = '' where tablename = 'casualcontracttaxbracketview' AND field = 'ncon'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','casualcontracttaxbracketview','S','','4','ncon','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'taxabledenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'taxabledenominator',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'taxabledenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxbracketview','N','','9','taxabledenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'taxablegross')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'taxablegross',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'taxablegross'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxbracketview','N','','9','taxablegross','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'taxablenet')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'taxablenet',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'taxablenet'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxbracketview','N','','9','taxablenet','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'taxablenumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'taxablenumerator',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'taxablenumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxbracketview','N','','9','taxablenumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'casualcontracttaxbracketview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','casualcontracttaxbracketview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'taxkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'S',format = '',col_len = '2',field = 'taxkind',col_precision = '' where tablename = 'casualcontracttaxbracketview' AND field = 'taxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','casualcontracttaxbracketview','S','','2','taxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'taxref')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'casualcontracttaxbracketview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(20)','N','casualcontracttaxbracketview','S','','20','taxref','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'totaladmintax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'totaladmintax',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'totaladmintax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxbracketview','N','','9','totaladmintax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'totalemploytax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'totalemploytax',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'totalemploytax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxbracketview','N','','9','totalemploytax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'totaltaxablenet')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'N',format = '',col_len = '9',field = 'totaltaxablenet',col_precision = '19' where tablename = 'casualcontracttaxbracketview' AND field = 'totaltaxablenet'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxbracketview','N','','9','totaltaxablenet','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxbracketview' AND field = 'ycon')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'casualcontracttaxbracketview',denynull = 'S',format = '',col_len = '4',field = 'ycon',col_precision = '' where tablename = 'casualcontracttaxbracketview' AND field = 'ycon'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','casualcontracttaxbracketview','S','','4','ycon','')
GO

-- VERIFICA DI casualcontracttaxbracketview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'casualcontracttaxbracketview')
UPDATE customobject set isreal = 'N' where objectname = 'casualcontracttaxbracketview'
ELSE
INSERT INTO customobject (objectname, isreal) values('casualcontracttaxbracketview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

