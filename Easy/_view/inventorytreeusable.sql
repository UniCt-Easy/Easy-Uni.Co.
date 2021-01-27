
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


-- CREAZIONE VISTA inventorytreeusable
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inventorytreeusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[inventorytreeusable]
GO



CREATE VIEW [DBO].inventorytreeusable 
(
	idinv,
	codeinv,
	nlevel,
	leveldescr,
	paridinv,
	description,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	inventorytree.idinv,
	inventorytree.codeinv,
	inventorytree.nlevel,
	inventorysortinglevel.description,
	inventorytree.paridinv,
	inventorytree.description,
	inventorytree.cu, 
	inventorytree.ct, 
	inventorytree.lu,
	inventorytree.lt 
FROM inventorytree
JOIN inventorysortinglevel
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
WHERE (inventorysortinglevel.flag & 2 <> 0)
	AND inventorytree.idinv NOT IN
		(SELECT paridinv FROM inventorytree
		WHERE paridinv IS NOT NULL)






GO

-- VERIFICA DI inventorytreeusable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'inventorytreeusable'
IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeusable' AND field = 'codeinv')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'inventorytreeusable',denynull = 'S',format = '',col_len = '50',field = 'codeinv',col_precision = '' where tablename = 'inventorytreeusable' AND field = 'codeinv'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','inventorytreeusable','S','','50','codeinv','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeusable' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'inventorytreeusable',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'inventorytreeusable' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','inventorytreeusable','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeusable' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'inventorytreeusable',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'inventorytreeusable' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','inventorytreeusable','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeusable' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'inventorytreeusable',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'inventorytreeusable' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','inventorytreeusable','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeusable' AND field = 'idinv')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'inventorytreeusable',denynull = 'S',format = '',col_len = '4',field = 'idinv',col_precision = '' where tablename = 'inventorytreeusable' AND field = 'idinv'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','inventorytreeusable','S','','4','idinv','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeusable' AND field = 'leveldescr')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'inventorytreeusable',denynull = 'S',format = '',col_len = '50',field = 'leveldescr',col_precision = '' where tablename = 'inventorytreeusable' AND field = 'leveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','inventorytreeusable','S','','50','leveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeusable' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'inventorytreeusable',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'inventorytreeusable' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','inventorytreeusable','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeusable' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'inventorytreeusable',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'inventorytreeusable' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','inventorytreeusable','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeusable' AND field = 'nlevel')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'inventorytreeusable',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'inventorytreeusable' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','tinyint','','N','System.Byte','tinyint','N','inventorytreeusable','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeusable' AND field = 'paridinv')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'inventorytreeusable',denynull = 'N',format = '',col_len = '4',field = 'paridinv',col_precision = '' where tablename = 'inventorytreeusable' AND field = 'paridinv'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','S','System.Int32','int','N','inventorytreeusable','N','','4','paridinv','')
GO

-- VERIFICA DI inventorytreeusable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'inventorytreeusable')
UPDATE customobject set isreal = 'N' where objectname = 'inventorytreeusable'
ELSE
INSERT INTO customobject (objectname, isreal) values('inventorytreeusable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

