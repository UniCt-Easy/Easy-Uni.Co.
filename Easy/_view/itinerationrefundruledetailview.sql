-- CREAZIONE VISTA itinerationrefundruledetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[itinerationrefundruledetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[itinerationrefundruledetailview]
GO




CREATE VIEW DBO.itinerationrefundruledetailview
(
	iditinerationrefundrule,
	ruledescr,
	iddetail,
	start,
	iditinerationrefundkindgroup,
	itinerationrefundkindgroup,
	idposition,
	codeposition,
	position,
	minincomeclass,
	maxincomeclass,
	flag_italy,
	flag_eu,
	flag_extraeu,
	nhour_min,
	nhour_max,
	limit,
	advancepercentage,
	ct, cu, lt, lu
)
AS SELECT 
	DET.iditinerationrefundrule,
	F.description,
	DET.iddetail,
	F.start,
	DET.iditinerationrefundkindgroup,
	G.description,
	DET.idposition,
	P.codeposition,
	P.description,
	DET.minincomeclass,
	DET.maxincomeclass,
	DET.flag_italy,
	DET.flag_eu,
	DET.flag_extraeu,
	DET.nhour_min,
	DET.nhour_max,
	DET.limit,
	DET.advancepercentage,
	DET.ct, DET.cu, DET.lt, DET.lu
FROM itinerationrefundruledetail DET
JOIN itinerationrefundrule F
	ON F.iditinerationrefundrule = DET.iditinerationrefundrule
JOIN position P
	ON P.idposition = DET.idposition
JOIN itinerationrefundkindgroup G
	ON G.iditinerationrefundkindgroup = DET.iditinerationrefundkindgroup




GO

-- VERIFICA DI itinerationrefundruledetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'itinerationrefundruledetailview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'advancepercentage')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '9',field = 'advancepercentage',col_precision = '19' where tablename = 'itinerationrefundruledetailview' AND field = 'advancepercentage'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','N','System.Decimal','decimal(19,6)','N','itinerationrefundruledetailview','S','','9','advancepercentage','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'codeposition')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '20',field = 'codeposition',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'codeposition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','itinerationrefundruledetailview','S','','20','codeposition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','itinerationrefundruledetailview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','itinerationrefundruledetailview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'flag_eu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '1',field = 'flag_eu',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'flag_eu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','N','System.String','char(1)','N','itinerationrefundruledetailview','S','','1','flag_eu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'flag_extraeu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '1',field = 'flag_extraeu',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'flag_extraeu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','N','System.String','char(1)','N','itinerationrefundruledetailview','S','','1','flag_extraeu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'flag_italy')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '1',field = 'flag_italy',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'flag_italy'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','N','System.String','char(1)','N','itinerationrefundruledetailview','S','','1','flag_italy','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'iddetail')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '4',field = 'iddetail',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'iddetail'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','itinerationrefundruledetailview','S','','4','iddetail','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'iditinerationrefundkindgroup')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '4',field = 'iditinerationrefundkindgroup',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'iditinerationrefundkindgroup'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','itinerationrefundruledetailview','S','','4','iditinerationrefundkindgroup','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'iditinerationrefundrule')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '4',field = 'iditinerationrefundrule',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'iditinerationrefundrule'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','itinerationrefundruledetailview','S','','4','iditinerationrefundrule','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'idposition')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '4',field = 'idposition',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'idposition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','itinerationrefundruledetailview','S','','4','idposition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'itinerationrefundkindgroup')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '100',field = 'itinerationrefundkindgroup',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'itinerationrefundkindgroup'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(100)','N','itinerationrefundruledetailview','S','','100','itinerationrefundkindgroup','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'limit')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'N',format = '',col_len = '9',field = 'limit',col_precision = '19' where tablename = 'itinerationrefundruledetailview' AND field = 'limit'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','itinerationrefundruledetailview','N','','9','limit','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','itinerationrefundruledetailview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','itinerationrefundruledetailview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'maxincomeclass')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '4',field = 'maxincomeclass',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'maxincomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','itinerationrefundruledetailview','S','','4','maxincomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'minincomeclass')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '4',field = 'minincomeclass',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'minincomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','itinerationrefundruledetailview','S','','4','minincomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'nhour_max')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'N',format = '',col_len = '4',field = 'nhour_max',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'nhour_max'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','itinerationrefundruledetailview','N','','4','nhour_max','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'nhour_min')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'N',format = '',col_len = '4',field = 'nhour_min',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'nhour_min'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','itinerationrefundruledetailview','N','','4','nhour_min','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'position')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '50',field = 'position',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'position'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','itinerationrefundruledetailview','S','','50','position','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'ruledescr')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '100',field = 'ruledescr',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'ruledescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(100)','N','itinerationrefundruledetailview','S','','100','ruledescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundruledetailview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationrefundruledetailview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'itinerationrefundruledetailview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','itinerationrefundruledetailview','S','','8','start','')
GO

-- VERIFICA DI itinerationrefundruledetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'itinerationrefundruledetailview')
UPDATE customobject set isreal = 'N' where objectname = 'itinerationrefundruledetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('itinerationrefundruledetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

