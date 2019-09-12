-- CREAZIONE VISTA inventorytreeunusable
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inventorytreeunusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[inventorytreeunusable]
GO



CREATE VIEW [DBO].inventorytreeunusable 
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
WHERE (inventorysortinglevel.flag & 2 <> 2)
	OR inventorytree.idinv IN
		(SELECT paridinv FROM inventorytree
		WHERE paridinv IS NOT NULL)


GO

-- VERIFICA DI inventorytreeunusable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'inventorytreeunusable'
IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeunusable' AND field = 'codeinv')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'inventorytreeunusable',denynull = 'S',format = '',col_len = '50',field = 'codeinv',col_precision = '' where tablename = 'inventorytreeunusable' AND field = 'codeinv'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','inventorytreeunusable','S','','50','codeinv','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeunusable' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'inventorytreeunusable',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'inventorytreeunusable' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','inventorytreeunusable','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeunusable' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'inventorytreeunusable',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'inventorytreeunusable' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','inventorytreeunusable','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeunusable' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'inventorytreeunusable',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'inventorytreeunusable' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','inventorytreeunusable','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeunusable' AND field = 'idinv')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'inventorytreeunusable',denynull = 'S',format = '',col_len = '4',field = 'idinv',col_precision = '' where tablename = 'inventorytreeunusable' AND field = 'idinv'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','inventorytreeunusable','S','','4','idinv','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeunusable' AND field = 'leveldescr')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'inventorytreeunusable',denynull = 'S',format = '',col_len = '50',field = 'leveldescr',col_precision = '' where tablename = 'inventorytreeunusable' AND field = 'leveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','inventorytreeunusable','S','','50','leveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeunusable' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'inventorytreeunusable',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'inventorytreeunusable' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','inventorytreeunusable','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeunusable' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'inventorytreeunusable',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'inventorytreeunusable' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','inventorytreeunusable','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeunusable' AND field = 'nlevel')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'inventorytreeunusable',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'inventorytreeunusable' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','tinyint','','N','System.Byte','tinyint','N','inventorytreeunusable','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreeunusable' AND field = 'paridinv')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'inventorytreeunusable',denynull = 'N',format = '',col_len = '4',field = 'paridinv',col_precision = '' where tablename = 'inventorytreeunusable' AND field = 'paridinv'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','S','System.Int32','int','N','inventorytreeunusable','N','','4','paridinv','')
GO

-- VERIFICA DI inventorytreeunusable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'inventorytreeunusable')
UPDATE customobject set isreal = 'N' where objectname = 'inventorytreeunusable'
ELSE
INSERT INTO customobject (objectname, isreal) values('inventorytreeunusable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

