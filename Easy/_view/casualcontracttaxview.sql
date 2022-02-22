
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


-- CREAZIONE VISTA casualcontracttaxview
IF EXISTS(select * from sysobjects where id = object_id(N'[casualcontracttaxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [casualcontracttaxview]
GO





CREATE VIEW [casualcontracttaxview]
(
	taxcode,
	description,
	taxref,
	ycon,
	ncon,
	adminrate,
	employrate,
	taxablegross,
	taxablenet,
	admindenominator,
	employdenominator,
	taxabledenominator,
	adminnumerator,
	employnumerator,
	taxablenumerator,
	admintax,
	employtax,
	employtaxgross,
	taxkind
)
AS SELECT
	COPR.taxcode,
	TR.description,
	TR.taxref,
	COPR.ycon,
	COPR.ncon,
	COPR.adminrate,
	COPR.employrate,
	COPR.taxablegross,
	COPR.taxablenet,
	COPR.admindenominator,
	COPR.employdenominator,
	COPR.taxabledenominator,
	COPR.adminnumerator,
	COPR.employnumerator,
	COPR.taxablenumerator,
	COPR.admintax,
	COPR.employtax,
	COPR.employtaxgross,
	TR.taxkind
FROM casualcontracttax COPR
JOIN tax TR
	ON COPR.taxcode = TR.taxcode







GO

-- VERIFICA DI casualcontracttaxview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'casualcontracttaxview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'admindenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'admindenominator',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'admindenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxview','N','','9','admindenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'adminnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'adminnumerator',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'adminnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxview','N','','9','adminnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'adminrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'adminrate',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'adminrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxview','N','','9','adminrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'admintax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'admintax',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'admintax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxview','N','','9','admintax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'casualcontracttaxview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','casualcontracttaxview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'employdenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'employdenominator',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'employdenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxview','N','','9','employdenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'employnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'employnumerator',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'employnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxview','N','','9','employnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'employrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'employrate',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'employrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxview','N','','9','employrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'employtax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'employtax',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'employtax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxview','N','','9','employtax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'employtaxgross')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'employtaxgross',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'employtaxgross'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxview','N','','9','employtaxgross','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'ncon')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'S',format = '',col_len = '4',field = 'ncon',col_precision = '' where tablename = 'casualcontracttaxview' AND field = 'ncon'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','casualcontracttaxview','S','','4','ncon','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'taxabledenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'taxabledenominator',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'taxabledenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxview','N','','9','taxabledenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'taxablegross')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablegross',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'taxablegross'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxview','N','','9','taxablegross','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'taxablenet')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablenet',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'taxablenet'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','casualcontracttaxview','N','','9','taxablenet','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'taxablenumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablenumerator',col_precision = '19' where tablename = 'casualcontracttaxview' AND field = 'taxablenumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','casualcontracttaxview','N','','9','taxablenumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'casualcontracttaxview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','casualcontracttaxview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'taxkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'S',format = '',col_len = '2',field = 'taxkind',col_precision = '' where tablename = 'casualcontracttaxview' AND field = 'taxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','casualcontracttaxview','S','','2','taxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'taxref')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'casualcontracttaxview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(20)','N','casualcontracttaxview','S','','20','taxref','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'casualcontracttaxview' AND field = 'ycon')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'casualcontracttaxview',denynull = 'S',format = '',col_len = '4',field = 'ycon',col_precision = '' where tablename = 'casualcontracttaxview' AND field = 'ycon'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','casualcontracttaxview','S','','4','ycon','')
GO

-- VERIFICA DI casualcontracttaxview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'casualcontracttaxview')
UPDATE customobject set isreal = 'N' where objectname = 'casualcontracttaxview'
ELSE
INSERT INTO customobject (objectname, isreal) values('casualcontracttaxview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

