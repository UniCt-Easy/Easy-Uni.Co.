-- CREAZIONE VISTA foreigngroupruledetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[foreigngroupruledetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[foreigngroupruledetailview]
GO




CREATE VIEW DBO.foreigngroupruledetailview
(
	idforeigngrouprule,
	iddetail,
	start,
	idposition,
	codeposition,
	position,
	minincomeclass,
	maxincomeclass,
	foreigngroupnumber,
	ct, cu, lt, lu
)
AS SELECT 
	DET.idforeigngrouprule,
	DET.iddetail,
	F.start,
	DET.idposition,
	P.codeposition,
	P.description,
	DET.minincomeclass,
	DET.maxincomeclass,
	DET.foreigngroupnumber,
	DET.ct, DET.cu, DET.lt, DET.lu
FROM foreigngroupruledetail DET
JOIN foreigngrouprule F
	ON F.idforeigngrouprule = DET.idforeigngrouprule
JOIN position P
	ON P.idposition = DET.idposition




GO

-- VERIFICA DI foreigngroupruledetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'foreigngroupruledetailview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'codeposition')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '20',field = 'codeposition',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'codeposition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','foreigngroupruledetailview','S','','20','codeposition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','foreigngroupruledetailview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','foreigngroupruledetailview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'foreigngroupnumber')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '2',field = 'foreigngroupnumber',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'foreigngroupnumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','foreigngroupruledetailview','S','','2','foreigngroupnumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'iddetail')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '4',field = 'iddetail',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'iddetail'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreigngroupruledetailview','S','','4','iddetail','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'idforeigngrouprule')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '4',field = 'idforeigngrouprule',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'idforeigngrouprule'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreigngroupruledetailview','S','','4','idforeigngrouprule','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'idposition')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '4',field = 'idposition',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'idposition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreigngroupruledetailview','S','','4','idposition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','foreigngroupruledetailview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','foreigngroupruledetailview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'maxincomeclass')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '4',field = 'maxincomeclass',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'maxincomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreigngroupruledetailview','S','','4','maxincomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'minincomeclass')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '4',field = 'minincomeclass',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'minincomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreigngroupruledetailview','S','','4','minincomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'position')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '50',field = 'position',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'position'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','foreigngroupruledetailview','S','','50','position','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreigngroupruledetailview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'foreigngroupruledetailview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'foreigngroupruledetailview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','foreigngroupruledetailview','S','','8','start','')
GO

-- VERIFICA DI foreigngroupruledetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'foreigngroupruledetailview')
UPDATE customobject set isreal = 'N' where objectname = 'foreigngroupruledetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('foreigngroupruledetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

