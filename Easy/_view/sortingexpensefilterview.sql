-- CREAZIONE VISTA sortingexpensefilterview
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingexpensefilterview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingexpensefilterview]
GO



CREATE VIEW [sortingexpensefilterview]
(
	codefin,finance,
	codeupb,upb,
	regsortingkind, 
	registrysortcode, 
	registrykind, 
	manager, 
	sortingkind, 
	sortingcode, 
	sorting,
	ayear,
	idautosort,
	idsorkind,
	codesorkind,
	idsorkindreg,
	codesorkindreg,
	ct,
	cu,
	jointolessspecifics,
	idfin,
	idsor,
	idsorreg,
	lt,
	lu,
	idman,
	idupb
)
AS
SELECT     	
	fin.codefin, fin.title,
	upb.codeupb, upb.title, 
	t2.description, 
	c2.sortcode, 
	c2.description, 
	manager.title,
	sortingkind.description,
	sorting.sortcode,
	sorting.description,
	A.ayear,
	A.idautosort,
	sorting.idsorkind,
	sortingkind.codesorkind,
	c2.idsorkind,
	t2.codesorkind,
	A.ct,
	A.cu,
	A.jointolessspecifics,
	A.idfin,
	A.idsor,
	A.idsorreg,
	A.lt,
	A.lu,
	A.idman,
	A.idupb
FROM sortingexpensefilter A 
JOIN sortingkind
	ON A.idsorkind = sortingkind.idsorkind
LEFT OUTER JOIN sorting
	ON A.idsor = sorting.idsor
LEFT OUTER JOIN sortingkind t2
	ON A.idsorkind = t2.idsorkind
LEFT OUTER JOIN sorting c2
	ON A.idsorreg = c2.idsor
LEFT OUTER JOIN fin
	ON fin.idfin = A.idfin  and fin.ayear = A.ayear
LEFT OUTER JOIN upb
	ON upb.idupb = A.idupb
LEFT OUTER JOIN manager
	ON A.idman = manager.idman

GO

-- VERIFICA DI sortingexpensefilterview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sortingexpensefilterview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'ayear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'S',format = '',col_len = '4',field = 'ayear',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingexpensefilterview','S','','4','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'codefin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingexpensefilterview','N','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','sortingexpensefilterview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'codesorkindreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '20',field = 'codesorkindreg',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'codesorkindreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','sortingexpensefilterview','N','','20','codesorkindreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'codeupb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '50',field = 'codeupb',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'codeupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingexpensefilterview','N','','50','codeupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','sortingexpensefilterview','N','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(64)','N','sortingexpensefilterview','N','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'finance')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '150',field = 'finance',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'finance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','sortingexpensefilterview','N','','150','finance','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'idautosort')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'S',format = '',col_len = '4',field = 'idautosort',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'idautosort'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingexpensefilterview','S','','4','idautosort','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'idfin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingexpensefilterview','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'idman')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingexpensefilterview','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'idsor')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'S',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingexpensefilterview','S','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingexpensefilterview','N','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'idsorkindreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '4',field = 'idsorkindreg',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'idsorkindreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingexpensefilterview','N','','4','idsorkindreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'idsorreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '4',field = 'idsorreg',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'idsorreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingexpensefilterview','N','','4','idsorreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'idupb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(36)','N','sortingexpensefilterview','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'jointolessspecifics')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'S',format = '',col_len = '1',field = 'jointolessspecifics',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'jointolessspecifics'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','N','System.String','char(1)','N','sortingexpensefilterview','S','','1','jointolessspecifics','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','sortingexpensefilterview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(64)','N','sortingexpensefilterview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'manager')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','sortingexpensefilterview','N','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'registrykind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '200',field = 'registrykind',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'registrykind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(200)','N','sortingexpensefilterview','N','','200','registrykind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'registrysortcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '50',field = 'registrysortcode',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'registrysortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingexpensefilterview','N','','50','registrysortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'regsortingkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '50',field = 'regsortingkind',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'regsortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingexpensefilterview','N','','50','regsortingkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'sorting')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '200',field = 'sorting',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'sorting'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(200)','N','sortingexpensefilterview','N','','200','sorting','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'sortingcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '50',field = 'sortingcode',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'sortingcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingexpensefilterview','N','','50','sortingcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'sortingkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'S',format = '',col_len = '50',field = 'sortingkind',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'sortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','sortingexpensefilterview','S','','50','sortingkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingexpensefilterview' AND field = 'upb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'sortingexpensefilterview',denynull = 'N',format = '',col_len = '150',field = 'upb',col_precision = '' where tablename = 'sortingexpensefilterview' AND field = 'upb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','sortingexpensefilterview','N','','150','upb','')
GO

-- VERIFICA DI sortingexpensefilterview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sortingexpensefilterview')
UPDATE customobject set isreal = 'N' where objectname = 'sortingexpensefilterview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sortingexpensefilterview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

