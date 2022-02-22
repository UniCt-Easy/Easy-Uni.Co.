
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


-- CREAZIONE VISTA itinerationtaxview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationtaxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationtaxview]
GO


CREATE  VIEW itinerationtaxview
(
	iditineration,
	yitineration,
	nitineration,
	taxcode,
	description,
	taxref,
	taxkind,
	taxablenumerator,
	taxabledenominator,
	adminrate,
 	adminnumerator,
  	admindenominator,
	employrate,
  	employnumerator,
  	employdenominator,
	admintax,
	employtax,
	taxable,
	flagunabatable, 
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	itinerationtax.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itinerationtax.taxcode,
	tax.description,
	tax.taxref,
	tax.taxkind,
	itinerationtax.taxablenumerator,
	itinerationtax.taxabledenominator,
	itinerationtax.adminrate,
  	itinerationtax.adminnumerator,
  	itinerationtax.admindenominator,
	itinerationtax.employrate,
  	itinerationtax.employnumerator,
  	itinerationtax.employdenominator,
	itinerationtax.admintax,
	itinerationtax.employtax,
	itinerationtax.taxable,
	tax.flagunabatable, 
	itinerationtax.cu,
	itinerationtax.ct,
	itinerationtax.lu,
	itinerationtax.lt
FROM itinerationtax
JOIN tax
	ON tax.taxcode = itinerationtax.taxcode
JOIN itineration
	ON itineration.iditineration = itinerationtax.iditineration

GO

-- VERIFICA DI itinerationtaxview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'itinerationtaxview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'admindenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'admindenominator',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'admindenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','S','System.Decimal','decimal(19,8)','N','itinerationtaxview','N','','9','admindenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'adminnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'adminnumerator',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'adminnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','S','System.Decimal','decimal(19,8)','N','itinerationtaxview','N','','9','adminnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'adminrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'adminrate',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'adminrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','S','System.Decimal','decimal(19,8)','N','itinerationtaxview','N','','9','adminrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'admintax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'admintax',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'admintax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','itinerationtaxview','N','','9','admintax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','itinerationtaxview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','itinerationtaxview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','itinerationtaxview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'employdenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'employdenominator',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'employdenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','itinerationtaxview','N','','9','employdenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'employnumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'employnumerator',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'employnumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','S','System.Decimal','decimal(19,8)','N','itinerationtaxview','N','','9','employnumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'employrate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'employrate',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'employrate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','S','System.Decimal','decimal(19,8)','N','itinerationtaxview','N','','9','employrate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'employtax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'employtax',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'employtax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','itinerationtaxview','N','','9','employtax','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'flagunabatable')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '1',field = 'flagunabatable',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'flagunabatable'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','char','','S','System.String','char(1)','N','itinerationtaxview','N','','1','flagunabatable','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'iditineration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '4',field = 'iditineration',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'iditineration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','itinerationtaxview','S','','4','iditineration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','itinerationtaxview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','itinerationtaxview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'nitineration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '4',field = 'nitineration',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'nitineration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','itinerationtaxview','S','','4','nitineration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'taxable')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'taxable',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'taxable'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','itinerationtaxview','N','','9','taxable','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'taxabledenominator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'taxabledenominator',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'taxabledenominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','S','System.Decimal','decimal(19,8)','N','itinerationtaxview','N','','9','taxabledenominator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'taxablenumerator')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'N',format = '',col_len = '9',field = 'taxablenumerator',col_precision = '19' where tablename = 'itinerationtaxview' AND field = 'taxablenumerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','S','System.Decimal','decimal(19,8)','N','itinerationtaxview','N','','9','taxablenumerator','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','itinerationtaxview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'taxkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '2',field = 'taxkind',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'taxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','itinerationtaxview','S','','2','taxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'taxref')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(20)','N','itinerationtaxview','S','','20','taxref','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationtaxview' AND field = 'yitineration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'itinerationtaxview',denynull = 'S',format = '',col_len = '2',field = 'yitineration',col_precision = '' where tablename = 'itinerationtaxview' AND field = 'yitineration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','itinerationtaxview','S','','2','yitineration','')
GO

-- VERIFICA DI itinerationtaxview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'itinerationtaxview')
UPDATE customobject set isreal = 'N' where objectname = 'itinerationtaxview'
ELSE
INSERT INTO customobject (objectname, isreal) values('itinerationtaxview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

