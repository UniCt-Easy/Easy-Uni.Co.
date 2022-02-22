
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


-- CREAZIONE VISTA assetusageview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetusageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetusageview]
GO



CREATE VIEW assetusageview
(
	nassetacquire,
	idassetusagekind,
	codeassetusagekind,
	assetusagekind,
	usagequota,
	transmitted,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	assetusage.nassetacquire,
	assetusage.idassetusagekind,
	assetusagekind.codeassetusagekind,
	assetusagekind.description,
	assetusage.usagequota,
	assetusage.transmitted,
	assetusage.cu,
	assetusage.ct,
	assetusage.lu,
	assetusage.lt
FROM assetusage
JOIN assetusagekind
	ON assetusage.idassetusagekind = assetusagekind.idassetusagekind








GO

-- VERIFICA DI assetusageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetusageview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'assetusageview' AND field = 'assetusagekind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'assetusageview',denynull = 'S',format = '',col_len = '50',field = 'assetusagekind',col_precision = '' where tablename = 'assetusageview' AND field = 'assetusagekind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','assetusageview','S','','50','assetusagekind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetusageview' AND field = 'codeassetusagekind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'assetusageview',denynull = 'S',format = '',col_len = '20',field = 'codeassetusagekind',col_precision = '' where tablename = 'assetusageview' AND field = 'codeassetusagekind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(20)','N','assetusageview','S','','20','codeassetusagekind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetusageview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'assetusageview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'assetusageview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','assetusageview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetusageview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'assetusageview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'assetusageview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','assetusageview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetusageview' AND field = 'idassetusagekind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'assetusageview',denynull = 'S',format = '',col_len = '4',field = 'idassetusagekind',col_precision = '' where tablename = 'assetusageview' AND field = 'idassetusagekind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetusageview','S','','4','idassetusagekind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetusageview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'assetusageview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'assetusageview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','assetusageview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetusageview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'assetusageview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'assetusageview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','assetusageview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetusageview' AND field = 'nassetacquire')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'assetusageview',denynull = 'S',format = '',col_len = '4',field = 'nassetacquire',col_precision = '' where tablename = 'assetusageview' AND field = 'nassetacquire'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetusageview','S','','4','nassetacquire','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetusageview' AND field = 'transmitted')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'assetusageview',denynull = 'N',format = '',col_len = '1',field = 'transmitted',col_precision = '' where tablename = 'assetusageview' AND field = 'transmitted'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','char','','S','System.String','char(1)','N','assetusageview','N','','1','transmitted','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetusageview' AND field = 'usagequota')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'assetusageview',denynull = 'N',format = '',col_len = '9',field = 'usagequota',col_precision = '19' where tablename = 'assetusageview' AND field = 'usagequota'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','8','decimal','','S','System.Decimal','decimal(19,8)','N','assetusageview','N','','9','usagequota','19')
GO

-- VERIFICA DI assetusageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetusageview')
UPDATE customobject set isreal = 'N' where objectname = 'assetusageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetusageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

