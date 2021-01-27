
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


-- CREAZIONE VISTA inventorykindview
IF EXISTS(select * from sysobjects where id = object_id(N'[inventorykindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [inventorykindview]
GO

CREATE VIEW inventorykindview
(
	idinventorykind,
	codeinventorykind,
	description,
	flag,
	idinv_allow,
	codeinv_allow,
	inventorytree_allow,
	idinv_deny,
	codeinv_deny,
	inventorytree_deny,
	ct, cu, lt, lu
)
AS SELECT
	inventorykind.idinventorykind,
	inventorykind.codeinventorykind,
	inventorykind.description,
	inventorykind.flag,
	inventorykind.idinv_allow,
	it_allow.codeinv,
	it_allow.description,
	inventorykind.idinv_deny,
	it_deny.codeinv,
	it_deny.description,
	inventorykind.ct, inventorykind.cu, inventorykind.lt, inventorykind.lu
FROM inventorykind
LEFT OUTER JOIN inventorytree it_allow
	ON inventorykind.idinv_allow = it_allow.idinv
LEFT OUTER JOIN inventorytree it_deny
	ON inventorykind.idinv_deny = it_deny.idinv

GO

-- VERIFICA DI inventorykindview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'inventorykindview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'codeinv_allow')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'inventorykindview',denynull = 'N',format = '',col_len = '50',field = 'codeinv_allow',col_precision = '' where tablename = 'inventorykindview' AND field = 'codeinv_allow'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','inventorykindview','N','','50','codeinv_allow','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'codeinv_deny')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'inventorykindview',denynull = 'N',format = '',col_len = '50',field = 'codeinv_deny',col_precision = '' where tablename = 'inventorykindview' AND field = 'codeinv_deny'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','inventorykindview','N','','50','codeinv_deny','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'codeinventorykind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'inventorykindview',denynull = 'S',format = '',col_len = '20',field = 'codeinventorykind',col_precision = '' where tablename = 'inventorykindview' AND field = 'codeinventorykind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','inventorykindview','S','','20','codeinventorykind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'inventorykindview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'inventorykindview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','inventorykindview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'inventorykindview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'inventorykindview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','inventorykindview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'inventorykindview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'inventorykindview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','inventorykindview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'flag')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'inventorykindview',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'inventorykindview' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','N','inventorykindview','S','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'idinv_allow')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'inventorykindview',denynull = 'N',format = '',col_len = '4',field = 'idinv_allow',col_precision = '' where tablename = 'inventorykindview' AND field = 'idinv_allow'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','inventorykindview','N','','4','idinv_allow','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'idinv_deny')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'inventorykindview',denynull = 'N',format = '',col_len = '4',field = 'idinv_deny',col_precision = '' where tablename = 'inventorykindview' AND field = 'idinv_deny'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','inventorykindview','N','','4','idinv_deny','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'idinventorykind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'inventorykindview',denynull = 'S',format = '',col_len = '4',field = 'idinventorykind',col_precision = '' where tablename = 'inventorykindview' AND field = 'idinventorykind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','inventorykindview','S','','4','idinventorykind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'inventorytree_allow')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'inventorykindview',denynull = 'N',format = '',col_len = '150',field = 'inventorytree_allow',col_precision = '' where tablename = 'inventorykindview' AND field = 'inventorytree_allow'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','inventorykindview','N','','150','inventorytree_allow','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'inventorytree_deny')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'inventorykindview',denynull = 'N',format = '',col_len = '150',field = 'inventorytree_deny',col_precision = '' where tablename = 'inventorykindview' AND field = 'inventorytree_deny'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','inventorykindview','N','','150','inventorytree_deny','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'inventorykindview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'inventorykindview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','inventorykindview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorykindview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'inventorykindview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'inventorykindview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','inventorykindview','S','','64','lu','')
GO

-- VERIFICA DI inventorykindview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'inventorykindview')
UPDATE customobject set isreal = 'N' where objectname = 'inventorykindview'
ELSE
INSERT INTO customobject (objectname, isreal) values('inventorykindview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

