-- CREAZIONE VISTA treasurerstartview
IF EXISTS(select * from sysobjects where id = object_id(N'[treasurerstartview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [treasurerstartview]
GO




--Pino Rana, elaborazione del 10/08/2005 15:18:08
CREATE                                VIEW treasurerstartview
	(
	idtreasurer,
	codetreasurer,
	treasurer,
	ayear,
	amount,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cu,
	ct,
	lu,
	lt
	)
	AS SELECT
	treasurerstart.idtreasurer,
	treasurer.codetreasurer,
	treasurer.description,
	treasurerstart.ayear,
	treasurerstart.amount,
	treasurer.idsor01,
	treasurer.idsor02,
	treasurer.idsor03,
	treasurer.idsor04,
	treasurer.idsor05,
	treasurerstart.cu,
	treasurerstart.ct,
	treasurerstart.lu,
	treasurerstart.lt
	FROM treasurerstart (NOLOCK)
	JOIN treasurer (NOLOCK)
	ON treasurerstart.idtreasurer = treasurer.idtreasurer






GO

-- VERIFICA DI treasurerstartview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'treasurerstartview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'treasurerstartview' AND field = 'amount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'treasurerstartview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'treasurerstartview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','treasurerstartview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'treasurerstartview' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'treasurerstartview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'treasurerstartview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','treasurerstartview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'treasurerstartview' AND field = 'codetreasurer')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'treasurerstartview',denynull = 'S',format = '',col_len = '20',field = 'codetreasurer',col_precision = '' where tablename = 'treasurerstartview' AND field = 'codetreasurer'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','treasurerstartview','S','','20','codetreasurer','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'treasurerstartview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'treasurerstartview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'treasurerstartview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','treasurerstartview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'treasurerstartview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'treasurerstartview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'treasurerstartview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','treasurerstartview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'treasurerstartview' AND field = 'idtreasurer')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'treasurerstartview',denynull = 'S',format = '',col_len = '4',field = 'idtreasurer',col_precision = '' where tablename = 'treasurerstartview' AND field = 'idtreasurer'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','treasurerstartview','S','','4','idtreasurer','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'treasurerstartview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'treasurerstartview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'treasurerstartview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','treasurerstartview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'treasurerstartview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'treasurerstartview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'treasurerstartview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','treasurerstartview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'treasurerstartview' AND field = 'treasurer')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'treasurerstartview',denynull = 'N',format = '',col_len = '150',field = 'treasurer',col_precision = '' where tablename = 'treasurerstartview' AND field = 'treasurer'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','treasurerstartview','N','','150','treasurer','')
GO

-- VERIFICA DI treasurerstartview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'treasurerstartview')
UPDATE customobject set isreal = 'N' where objectname = 'treasurerstartview'
ELSE
INSERT INTO customobject (objectname, isreal) values('treasurerstartview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

