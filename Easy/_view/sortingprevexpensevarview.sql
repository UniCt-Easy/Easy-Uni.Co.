-- CREAZIONE VISTA sortingprevexpensevarview
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingprevexpensevarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingprevexpensevarview]
GO



CREATE VIEW sortingprevexpensevarview
(
	yvar,
	nvar,
	idsorkind,
	codesorkind,
	idsor,
	sortcode,
	sorting,
	ayear,
	description,
	amount,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sortingprevexpensevar.yvar,
	sortingprevexpensevar.nvar,
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingprevexpensevar.idsor,
	sorting.sortcode,
	sorting.description,
	sortingprevexpensevar.ayear,
	sortingprevexpensevar.description,
	sortingprevexpensevar.amount,
	sortingprevexpensevar.adate,
	sortingprevexpensevar.cu,
	sortingprevexpensevar.ct,
	sortingprevexpensevar.lu,
	sortingprevexpensevar.lt
FROM sortingprevexpensevar 
JOIN sorting 
	ON sortingprevexpensevar.idsor = sorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind


GO

-- VERIFICA DI sortingprevexpensevarview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sortingprevexpensevarview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'adate')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'N',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','sortingprevexpensevarview','N','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'amount')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'sortingprevexpensevarview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','sortingprevexpensevarview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'ayear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'N',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','S','System.Int16','smallint','N','sortingprevexpensevarview','N','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','sortingprevexpensevarview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','sortingprevexpensevarview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','sortingprevexpensevarview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'N',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','sortingprevexpensevarview','N','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'idsor')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'N',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingprevexpensevarview','N','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingprevexpensevarview','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','sortingprevexpensevarview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','sortingprevexpensevarview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'nvar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'S',format = '',col_len = '4',field = 'nvar',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'nvar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingprevexpensevarview','S','','4','nvar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'sortcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'S',format = '',col_len = '50',field = 'sortcode',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'sortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','sortingprevexpensevarview','S','','50','sortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'sorting')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'S',format = '',col_len = '200',field = 'sorting',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'sorting'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(200)','N','sortingprevexpensevarview','S','','200','sorting','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevexpensevarview' AND field = 'yvar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingprevexpensevarview',denynull = 'S',format = '',col_len = '2',field = 'yvar',col_precision = '' where tablename = 'sortingprevexpensevarview' AND field = 'yvar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','sortingprevexpensevarview','S','','2','yvar','')
GO

-- VERIFICA DI sortingprevexpensevarview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sortingprevexpensevarview')
UPDATE customobject set isreal = 'N' where objectname = 'sortingprevexpensevarview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sortingprevexpensevarview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

