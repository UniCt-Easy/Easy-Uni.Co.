-- CREAZIONE VISTA sortingyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingyearview]
GO




CREATE        VIEW [sortingyearview]
	(
	codesorkind,
	idsorkind,
	sortingkind,
	idsor,
	sortcode,
	nlevel,
	leveldescr,
	paridsor,
	description,
	printingorder,
	ayear,
	incomeprevision,
	expenseprevision,
	totexpensevariation,
	totincomevariation,
	totexpense,
	totincome,
	currentincomeprevision,
	currentexpenseprevision,
	availableincomeprevision,
	availableexpenseprevision,
	idman,
	manager,
	start,
	stop,
	cu, 
	ct, 
	lu, 
	lt,
	defaultn1, 
	defaultn2,
	defaultn3, 
	defaultn4, 
	defaultn5, 
	defaults1, 
	defaults2, 
	defaults3, 
	defaults4, 
	defaults5, 
	flagnodate,
	movkind
	)
	AS SELECT
	sortingkind.codesorkind,
  	sorting.idsorkind,
	sortingkind.description,
	sorting.idsor,
	sorting.sortcode,
	sorting.nlevel,
	sortinglevel.description,
	sorting.paridsor,
	sorting.description,
	sorting.printingorder,
	accountingyear.ayear,
	sortingprev.incomeprevision,
	sortingprev.expenseprevision,
	sortedmovementtotal.totexpensevariation,
	sortedmovementtotal.totincomevariation,
	sortedmovementtotal.totexpense,
	sortedmovementtotal.totalincome,
	ISNULL(sortingprev.incomeprevision,0) + 
	ISNULL(sortedmovementtotal.totincomevariation,0),
	ISNULL(sortingprev.expenseprevision,0) + 
	ISNULL(sortedmovementtotal.totexpensevariation,0),
	ISNULL(sortingprev.incomeprevision,0) + 
	ISNULL(sortedmovementtotal.totincomevariation,0) -
	ISNULL(sortedmovementtotal.totalincome,0),
	ISNULL(sortingprev.expenseprevision,0) + 
	ISNULL(sortedmovementtotal.totexpensevariation,0) - 
	ISNULL(sortedmovementtotal.totexpense,0),
	manager.idman,
	manager.title,
	sorting.start,
	sorting.stop,
	sorting.cu, 
	sorting.ct, 
	sorting.lu,
	sorting.lt, 
	sorting.defaultn1, 
	sorting.defaultn2,
	sorting.defaultn3, 
	sorting.defaultn4, 
	sorting.defaultn5, 
	sorting.defaults1, 
	sorting.defaults2, 
	sorting.defaults3, 
	sorting.defaults4, 
	sorting.defaults5, 
	sorting.flagnodate,
	sorting.movkind
FROM sorting
JOIN sortingkind
 ON sortingkind.idsorkind = sorting.idsorkind
CROSS JOIN accountingyear
JOIN sortinglevel
 ON sortinglevel.nlevel = sorting.nlevel
 AND sortinglevel.idsorkind = sorting.idsorkind
LEFT OUTER JOIN sortingprev
 ON sortingprev.idsor = sorting.idsor
 AND sortingprev.ayear = accountingyear.ayear
LEFT OUTER JOIN sortedmovementtotal
 ON  sortedmovementtotal.idsor = sorting.idsor
 AND sortedmovementtotal.ayear = accountingyear.ayear
LEFT OUTER JOIN managersorting
 ON managersorting.idsor = sorting.idsor
LEFT OUTER JOIN manager
 ON manager.idman = managersorting.idman




--sp_help sortedmovementtotal
--sp_help managersorting




GO

-- VERIFICA DI sortingyearview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sortingyearview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'availableexpenseprevision')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(21,2)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '13',field = 'availableexpenseprevision',col_precision = '21' where tablename = 'sortingyearview' AND field = 'availableexpenseprevision'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(21,2)','N','sortingyearview','N','','13','availableexpenseprevision','21')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'availableincomeprevision')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(21,2)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '13',field = 'availableincomeprevision',col_precision = '21' where tablename = 'sortingyearview' AND field = 'availableincomeprevision'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(21,2)','N','sortingyearview','N','','13','availableincomeprevision','21')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'sortingyearview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','sortingyearview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'sortingyearview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','sortingyearview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'sortingyearview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','sortingyearview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'sortingyearview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','sortingyearview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'currentexpenseprevision')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(20,2)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '13',field = 'currentexpenseprevision',col_precision = '20' where tablename = 'sortingyearview' AND field = 'currentexpenseprevision'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(20,2)','N','sortingyearview','N','','13','currentexpenseprevision','20')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'currentincomeprevision')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(20,2)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '13',field = 'currentincomeprevision',col_precision = '20' where tablename = 'sortingyearview' AND field = 'currentincomeprevision'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(20,2)','N','sortingyearview','N','','13','currentincomeprevision','20')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'defaultn1')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(23,6)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '13',field = 'defaultn1',col_precision = '23' where tablename = 'sortingyearview' AND field = 'defaultn1'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(23,6)','N','sortingyearview','N','','13','defaultn1','23')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'defaultn2')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(23,6)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '13',field = 'defaultn2',col_precision = '23' where tablename = 'sortingyearview' AND field = 'defaultn2'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(23,6)','N','sortingyearview','N','','13','defaultn2','23')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'defaultn3')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(23,6)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '13',field = 'defaultn3',col_precision = '23' where tablename = 'sortingyearview' AND field = 'defaultn3'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(23,6)','N','sortingyearview','N','','13','defaultn3','23')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'defaultn4')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(23,6)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '13',field = 'defaultn4',col_precision = '23' where tablename = 'sortingyearview' AND field = 'defaultn4'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(23,6)','N','sortingyearview','N','','13','defaultn4','23')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'defaultn5')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(23,6)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '13',field = 'defaultn5',col_precision = '23' where tablename = 'sortingyearview' AND field = 'defaultn5'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(23,6)','N','sortingyearview','N','','13','defaultn5','23')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'defaults1')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '20',field = 'defaults1',col_precision = '' where tablename = 'sortingyearview' AND field = 'defaults1'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','sortingyearview','N','','20','defaults1','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'defaults2')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '20',field = 'defaults2',col_precision = '' where tablename = 'sortingyearview' AND field = 'defaults2'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','sortingyearview','N','','20','defaults2','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'defaults3')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '20',field = 'defaults3',col_precision = '' where tablename = 'sortingyearview' AND field = 'defaults3'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','sortingyearview','N','','20','defaults3','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'defaults4')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '20',field = 'defaults4',col_precision = '' where tablename = 'sortingyearview' AND field = 'defaults4'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','sortingyearview','N','','20','defaults4','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'defaults5')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '20',field = 'defaults5',col_precision = '' where tablename = 'sortingyearview' AND field = 'defaults5'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','sortingyearview','N','','20','defaults5','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'description')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '200',field = 'description',col_precision = '' where tablename = 'sortingyearview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(200)','N','sortingyearview','S','','200','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'expenseprevision')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '9',field = 'expenseprevision',col_precision = '19' where tablename = 'sortingyearview' AND field = 'expenseprevision'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','sortingyearview','N','','9','expenseprevision','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'flagnodate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '1',field = 'flagnodate',col_precision = '' where tablename = 'sortingyearview' AND field = 'flagnodate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','sortingyearview','N','','1','flagnodate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'idman')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'sortingyearview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','sortingyearview','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'idsor')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'sortingyearview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','sortingyearview','S','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'sortingyearview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','sortingyearview','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'incomeprevision')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '9',field = 'incomeprevision',col_precision = '19' where tablename = 'sortingyearview' AND field = 'incomeprevision'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','sortingyearview','N','','9','incomeprevision','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'leveldescr')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '50',field = 'leveldescr',col_precision = '' where tablename = 'sortingyearview' AND field = 'leveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','sortingyearview','S','','50','leveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'sortingyearview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','sortingyearview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'sortingyearview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','sortingyearview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'manager')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'sortingyearview' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','sortingyearview','N','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'movkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '1',field = 'movkind',col_precision = '' where tablename = 'sortingyearview' AND field = 'movkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','sortingyearview','N','','1','movkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'nlevel')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'sortingyearview' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','N','System.Byte','tinyint','N','sortingyearview','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'paridsor')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '4',field = 'paridsor',col_precision = '' where tablename = 'sortingyearview' AND field = 'paridsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','sortingyearview','N','','4','paridsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'printingorder')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '50',field = 'printingorder',col_precision = '' where tablename = 'sortingyearview' AND field = 'printingorder'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','sortingyearview','N','','50','printingorder','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'sortcode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '50',field = 'sortcode',col_precision = '' where tablename = 'sortingyearview' AND field = 'sortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','sortingyearview','S','','50','sortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'sortingkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingyearview',denynull = 'S',format = '',col_len = '50',field = 'sortingkind',col_precision = '' where tablename = 'sortingyearview' AND field = 'sortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','sortingyearview','S','','50','sortingkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '2',field = 'start',col_precision = '' where tablename = 'sortingyearview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','sortingyearview','N','','2','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'stop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '2',field = 'stop',col_precision = '' where tablename = 'sortingyearview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','sortingyearview','N','','2','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'totexpense')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '9',field = 'totexpense',col_precision = '19' where tablename = 'sortingyearview' AND field = 'totexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','sortingyearview','N','','9','totexpense','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'totexpensevariation')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '9',field = 'totexpensevariation',col_precision = '19' where tablename = 'sortingyearview' AND field = 'totexpensevariation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','sortingyearview','N','','9','totexpensevariation','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'totincome')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '9',field = 'totincome',col_precision = '19' where tablename = 'sortingyearview' AND field = 'totincome'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','sortingyearview','N','','9','totincome','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingyearview' AND field = 'totincomevariation')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'sortingyearview',denynull = 'N',format = '',col_len = '9',field = 'totincomevariation',col_precision = '19' where tablename = 'sortingyearview' AND field = 'totincomevariation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','sortingyearview','N','','9','totincomevariation','19')
GO

-- VERIFICA DI sortingyearview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sortingyearview')
UPDATE customobject set isreal = 'N' where objectname = 'sortingyearview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sortingyearview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

