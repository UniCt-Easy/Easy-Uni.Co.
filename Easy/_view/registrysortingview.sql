-- CREAZIONE VISTA registrysortingview
IF EXISTS(select * from sysobjects where id = object_id(N'[registrysortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [registrysortingview]
GO



CREATE VIEW [registrysortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	quota,
	sortcode,
	sorting,
	idreg,
	registry,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	registrysorting.idsor,
	registrysorting.quota,
	sorting.sortcode,
	sorting.description,
	registrysorting.idreg,
	registry.title,
	registrysorting.cu,
	registrysorting.ct,
	registrysorting.lu,
	registrysorting.lt
FROM registrysorting 
JOIN sorting 
	ON sorting.idsor = registrysorting.idsor
JOIN sortingkind 
	ON sortingkind.idsorkind = sorting.idsorkind
JOIN registry 
	ON registrysorting.idreg = registry.idreg



GO

-- VERIFICA DI registrysortingview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrysortingview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'registrysortingview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','registrysortingview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'registrysortingview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','registrysortingview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'registrysortingview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','registrysortingview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'idreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'registrysortingview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','registrysortingview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'idsor')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'registrysortingview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','registrysortingview','S','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'registrysortingview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','registrysortingview','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'registrysortingview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','registrysortingview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'registrysortingview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','registrysortingview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'quota')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'float',defaultvalue = '',allownull = 'S',systemtype = 'System.Double',sqldeclaration = 'float',iskey = 'N',tablename = 'registrysortingview',denynull = 'N',format = '',col_len = '8',field = 'quota',col_precision = '' where tablename = 'registrysortingview' AND field = 'quota'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','float','','S','System.Double','float','N','registrysortingview','N','','8','quota','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'registry')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'registrysortingview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(100)','N','registrysortingview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'sortcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '50',field = 'sortcode',col_precision = '' where tablename = 'registrysortingview' AND field = 'sortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','registrysortingview','S','','50','sortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'sorting')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '200',field = 'sorting',col_precision = '' where tablename = 'registrysortingview' AND field = 'sorting'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(200)','N','registrysortingview','S','','200','sorting','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrysortingview' AND field = 'sortingkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrysortingview',denynull = 'S',format = '',col_len = '50',field = 'sortingkind',col_precision = '' where tablename = 'registrysortingview' AND field = 'sortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','registrysortingview','S','','50','sortingkind','')
GO

-- VERIFICA DI registrysortingview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrysortingview')
UPDATE customobject set isreal = 'N' where objectname = 'registrysortingview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrysortingview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

