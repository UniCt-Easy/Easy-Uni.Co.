-- CREAZIONE VISTA inventorytreesortingview
IF EXISTS(select * from sysobjects where id = object_id(N'[inventorytreesortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [inventorytreesortingview]
GO




CREATE VIEW [inventorytreesortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	codeinv,
	sorting,
	idinv,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	inventorytreesorting.idsor,
	sorting.sortcode,
	sorting.description,
	inventorytreesorting.idinv,
	inventorytreesorting.cu,
	inventorytreesorting.ct,
	inventorytreesorting.lu,
	inventorytreesorting.lt
FROM inventorytreesorting
JOIN sorting
	ON sorting.idsor = inventorytreesorting.idinv
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind


GO

-- VERIFICA DI inventorytreesortingview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'inventorytreesortingview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'codeinv')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '50',field = 'codeinv',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'codeinv'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','inventorytreesortingview','S','','50','codeinv','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','inventorytreesortingview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','inventorytreesortingview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','inventorytreesortingview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'idinv')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '4',field = 'idinv',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'idinv'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','inventorytreesortingview','S','','4','idinv','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'idsor')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','inventorytreesortingview','S','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','inventorytreesortingview','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','inventorytreesortingview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','inventorytreesortingview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'sorting')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '200',field = 'sorting',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'sorting'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(200)','N','inventorytreesortingview','S','','200','sorting','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'inventorytreesortingview' AND field = 'sortingkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'inventorytreesortingview',denynull = 'S',format = '',col_len = '50',field = 'sortingkind',col_precision = '' where tablename = 'inventorytreesortingview' AND field = 'sortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','inventorytreesortingview','S','','50','sortingkind','')
GO

-- VERIFICA DI inventorytreesortingview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'inventorytreesortingview')
UPDATE customobject set isreal = 'N' where objectname = 'inventorytreesortingview'
ELSE
INSERT INTO customobject (objectname, isreal) values('inventorytreesortingview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

