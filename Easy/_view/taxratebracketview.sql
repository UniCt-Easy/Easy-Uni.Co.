
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


-- CREAZIONE VISTA taxratebracketview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxratebracketview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[taxratebracketview]
GO





CREATE     VIEW [DBO].taxratebracketview 
(
	taxcode,
	tax,
	taxref,
	idtaxratestart,
	nbracket,
	start,
	taxkind,
	minamount,
	maxamount,
	taxablenumerator,
	taxabledenominator,
	adminrate,
	adminnumerator,
	admindenominator,
	employrate,
	employnumerator,
	employdenominator,
	lu,
	lt
)
AS SELECT
	B.taxcode,
	T.description,
	T.taxref,
	B.idtaxratestart,
	B.nbracket,
	S.start,
	T.taxkind,
	B.minamount,
	B.maxamount,
	B.taxablenumerator,
	B.taxabledenominator,
	B.adminrate,
	B.adminnumerator,
	B.admindenominator,
	B.employrate,
	B.employnumerator,
	B.employdenominator,
	B.lu,
	B.lt
FROM taxratebracket B
JOIN taxratestart S
	ON B.taxcode = S.taxcode
	AND B.idtaxratestart = S.idtaxratestart
JOIN tax T
	ON T.taxcode = B.taxcode






GO

-- VERIFICA DI taxratebracketview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'taxratebracketview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'admindenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '9',field = 'admindenominator',col_precision = '19' where tablename = 'taxratebracketview' AND field = 'admindenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','N','System.Decimal','decimal(19,8)','N','taxratebracketview','S','','9','admindenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'adminnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '9',field = 'adminnumerator',col_precision = '19' where tablename = 'taxratebracketview' AND field = 'adminnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','N','System.Decimal','decimal(19,8)','N','taxratebracketview','S','','9','adminnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'adminrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '9',field = 'adminrate',col_precision = '19' where tablename = 'taxratebracketview' AND field = 'adminrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','N','System.Decimal','decimal(19,8)','N','taxratebracketview','S','','9','adminrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'employdenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '9',field = 'employdenominator',col_precision = '19' where tablename = 'taxratebracketview' AND field = 'employdenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','N','System.Decimal','decimal(19,8)','N','taxratebracketview','S','','9','employdenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'employnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '9',field = 'employnumerator',col_precision = '19' where tablename = 'taxratebracketview' AND field = 'employnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','N','System.Decimal','decimal(19,8)','N','taxratebracketview','S','','9','employnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'employrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '9',field = 'employrate',col_precision = '19' where tablename = 'taxratebracketview' AND field = 'employrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','N','System.Decimal','decimal(19,8)','N','taxratebracketview','S','','9','employrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'idtaxratestart')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '4',field = 'idtaxratestart',col_precision = '' where tablename = 'taxratebracketview' AND field = 'idtaxratestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','taxratebracketview','S','','4','idtaxratestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'taxratebracketview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','taxratebracketview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'taxratebracketview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','taxratebracketview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'maxamount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'N',format = '',col_len = '9',field = 'maxamount',col_precision = '19' where tablename = 'taxratebracketview' AND field = 'maxamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','taxratebracketview','N','','9','maxamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'minamount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'N',format = '',col_len = '9',field = 'minamount',col_precision = '19' where tablename = 'taxratebracketview' AND field = 'minamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','taxratebracketview','N','','9','minamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'nbracket')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '2',field = 'nbracket',col_precision = '' where tablename = 'taxratebracketview' AND field = 'nbracket'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','taxratebracketview','S','','2','nbracket','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'start')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'taxratebracketview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','taxratebracketview','S','','8','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'tax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '50',field = 'tax',col_precision = '' where tablename = 'taxratebracketview' AND field = 'tax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','taxratebracketview','S','','50','tax','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'taxabledenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '9',field = 'taxabledenominator',col_precision = '19' where tablename = 'taxratebracketview' AND field = 'taxabledenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','N','System.Decimal','decimal(19,8)','N','taxratebracketview','S','','9','taxabledenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'taxablenumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '9',field = 'taxablenumerator',col_precision = '19' where tablename = 'taxratebracketview' AND field = 'taxablenumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','N','System.Decimal','decimal(19,8)','N','taxratebracketview','S','','9','taxablenumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'taxratebracketview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','taxratebracketview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'taxkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '2',field = 'taxkind',col_precision = '' where tablename = 'taxratebracketview' AND field = 'taxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','taxratebracketview','S','','2','taxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratebracketview' AND field = 'taxref')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'taxratebracketview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'taxratebracketview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(20)','N','taxratebracketview','S','','20','taxref','')
GO

-- VERIFICA DI taxratebracketview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'taxratebracketview')
UPDATE customobject set isreal = 'N' where objectname = 'taxratebracketview'
ELSE
INSERT INTO customobject (objectname, isreal) values('taxratebracketview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

