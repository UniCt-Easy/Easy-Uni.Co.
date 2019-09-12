-- CREAZIONE VISTA maintenanceview
IF EXISTS(select * from sysobjects where id = object_id(N'[maintenanceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [maintenanceview]
GO






CREATE   VIEW maintenanceview
(
	nmaintenance,
	idasset,
	idpiece,
	idmaintenancekind,
	codemaintenancekind,
	maintenancekind,
	idinventory,
	inventory,
	ninventory,
	loaddescription,
	description,
	amount,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	maintenance.nmaintenance,
	maintenance.idasset,
	maintenance.idpiece,-- <-
	maintenance.idmaintenancekind,
	maintenancekind.codemaintenancekind,
	maintenancekind.description,
	assetacquire.idinventory, 
	inventory.description,
	assetmain.ninventory, -- <- sa
	assetacquire.description,
	maintenance.description,
	maintenance.amount,
	maintenance.adate,
	maintenance.cu,
	maintenance.ct,
	maintenance.lu,
	maintenance.lt
FROM maintenance
JOIN asset
	ON asset.idasset = maintenance.idasset 
	and asset.idpiece = maintenance.idpiece
JOIN assetacquire
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN maintenancekind
	ON maintenancekind.idmaintenancekind = maintenance.idmaintenancekind
JOIN asset AS assetmain
ON (asset.idasset=assetmain.idasset)
WHERE (assetmain.idpiece = 1)







GO

-- VERIFICA DI maintenanceview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'maintenanceview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'adate')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'maintenanceview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','maintenanceview','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'amount')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'maintenanceview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'maintenanceview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','maintenanceview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'codemaintenancekind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '20',field = 'codemaintenancekind',col_precision = '' where tablename = 'maintenanceview' AND field = 'codemaintenancekind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','maintenanceview','S','','20','codemaintenancekind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'maintenanceview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','maintenanceview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'maintenanceview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','maintenanceview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'maintenanceview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(150)','N','maintenanceview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'idasset')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '4',field = 'idasset',col_precision = '' where tablename = 'maintenanceview' AND field = 'idasset'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','maintenanceview','S','','4','idasset','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'idinventory')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '4',field = 'idinventory',col_precision = '' where tablename = 'maintenanceview' AND field = 'idinventory'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','maintenanceview','S','','4','idinventory','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'idmaintenancekind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '4',field = 'idmaintenancekind',col_precision = '' where tablename = 'maintenanceview' AND field = 'idmaintenancekind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','maintenanceview','S','','4','idmaintenancekind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'idpiece')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '4',field = 'idpiece',col_precision = '' where tablename = 'maintenanceview' AND field = 'idpiece'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','maintenanceview','S','','4','idpiece','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'inventory')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '50',field = 'inventory',col_precision = '' where tablename = 'maintenanceview' AND field = 'inventory'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','maintenanceview','S','','50','inventory','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'loaddescription')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '150',field = 'loaddescription',col_precision = '' where tablename = 'maintenanceview' AND field = 'loaddescription'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(150)','N','maintenanceview','S','','150','loaddescription','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'maintenanceview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','maintenanceview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'maintenanceview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','maintenanceview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'maintenancekind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '50',field = 'maintenancekind',col_precision = '' where tablename = 'maintenanceview' AND field = 'maintenancekind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','maintenanceview','S','','50','maintenancekind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'ninventory')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'maintenanceview',denynull = 'N',format = '',col_len = '4',field = 'ninventory',col_precision = '' where tablename = 'maintenanceview' AND field = 'ninventory'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','maintenanceview','N','','4','ninventory','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'maintenanceview' AND field = 'nmaintenance')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'maintenanceview',denynull = 'S',format = '',col_len = '4',field = 'nmaintenance',col_precision = '' where tablename = 'maintenanceview' AND field = 'nmaintenance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','maintenanceview','S','','4','nmaintenance','')
GO

-- VERIFICA DI maintenanceview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'maintenanceview')
UPDATE customobject set isreal = 'N' where objectname = 'maintenanceview'
ELSE
INSERT INTO customobject (objectname, isreal) values('maintenanceview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

