
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


-- CREAZIONE VISTA servicetaxview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[servicetaxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[servicetaxview]
GO
 
 

CREATE VIEW [DBO].servicetaxview
(
	taxcode,
	tax,
	taxref,
	idser, 
	servicedescription,
	codeser,
	servicecode770,
	cu,
	ct,
	lu, 
	lt,
	appliancebasis,
	geoappliance, 
	taxablecode,
	taxkind,
	module
)
AS
SELECT
	servicetax.taxcode,
	tax.description,
	tax.taxref,
	servicetax.idser, 
	service.description,
	service.codeser,
	servicecode770,
	servicetax.cu,
	servicetax.ct,
	servicetax.lu, 
	servicetax.lt,
	tax.appliancebasis,
	tax.geoappliance, 
	tax.taxablecode,
	tax.taxkind,
	service.module
FROM servicetax
JOIN tax
	ON tax.taxcode = servicetax.taxcode
JOIN service
	ON service.idser = servicetax.idser


GO

-- VERIFICA DI servicetaxview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'servicetaxview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'appliancebasis')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'servicetaxview',denynull = 'N',format = '',col_len = '1',field = 'appliancebasis',col_precision = '' where tablename = 'servicetaxview' AND field = 'appliancebasis'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','char','','S','System.String','char(1)','N','servicetaxview','N','','1','appliancebasis','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'codeser')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '20',field = 'codeser',col_precision = '' where tablename = 'servicetaxview' AND field = 'codeser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(20)','N','servicetaxview','S','','20','codeser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'servicetaxview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','servicetaxview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'servicetaxview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','servicetaxview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'geoappliance')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'servicetaxview',denynull = 'N',format = '',col_len = '1',field = 'geoappliance',col_precision = '' where tablename = 'servicetaxview' AND field = 'geoappliance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','char','','S','System.String','char(1)','N','servicetaxview','N','','1','geoappliance','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'idser')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '4',field = 'idser',col_precision = '' where tablename = 'servicetaxview' AND field = 'idser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','servicetaxview','S','','4','idser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'servicetaxview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','servicetaxview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'servicetaxview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','servicetaxview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'module')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(15)',iskey = 'N',tablename = 'servicetaxview',denynull = 'N',format = '',col_len = '15',field = 'module',col_precision = '' where tablename = 'servicetaxview' AND field = 'module'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(15)','N','servicetaxview','N','','15','module','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'servicedescription')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '50',field = 'servicedescription',col_precision = '' where tablename = 'servicetaxview' AND field = 'servicedescription'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','servicetaxview','S','','50','servicedescription','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'tax')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '50',field = 'tax',col_precision = '' where tablename = 'servicetaxview' AND field = 'tax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','servicetaxview','S','','50','tax','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'taxablecode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'servicetaxview',denynull = 'N',format = '',col_len = '20',field = 'taxablecode',col_precision = '' where tablename = 'servicetaxview' AND field = 'taxablecode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(20)','N','servicetaxview','N','','20','taxablecode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'servicetaxview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','servicetaxview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'taxkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '2',field = 'taxkind',col_precision = '' where tablename = 'servicetaxview' AND field = 'taxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','servicetaxview','S','','2','taxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'servicetaxview' AND field = 'taxref')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'servicetaxview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'servicetaxview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(20)','N','servicetaxview','S','','20','taxref','')
GO

-- VERIFICA DI servicetaxview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'servicetaxview')
UPDATE customobject set isreal = 'N' where objectname = 'servicetaxview'
ELSE
INSERT INTO customobject (objectname, isreal) values('servicetaxview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

