-- CREAZIONE VISTA reductionruledetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[reductionruledetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[reductionruledetailview]
GO


CREATE VIEW DBO.reductionruledetailview
(
	idreductionrule,
	iddetail,
	start,
	idreduction,
	reduction,
	reductionpercentage,
	ct, cu, lt, lu
)
AS SELECT 
	DET.idreductionrule,
	DET.iddetail,
	F.start,
	DET.idreduction,
	R.description,
	DET.reductionpercentage,
	DET.ct, DET.cu, DET.lt, DET.lu
FROM reductionruledetail DET
JOIN reductionrule F
	ON F.idreductionrule = DET.idreductionrule
JOIN reduction R
	ON R.idreduction = DET.idreduction


GO

-- VERIFICA DI reductionruledetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'reductionruledetailview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'reductionruledetailview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'reductionruledetailview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'reductionruledetailview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','datetime','','N','System.DateTime','datetime','N','reductionruledetailview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'reductionruledetailview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'reductionruledetailview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'reductionruledetailview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','N','System.String','varchar(64)','N','reductionruledetailview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'reductionruledetailview' AND field = 'iddetail')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'reductionruledetailview',denynull = 'S',format = '',col_len = '4',field = 'iddetail',col_precision = '' where tablename = 'reductionruledetailview' AND field = 'iddetail'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','int','','N','System.Int32','int','N','reductionruledetailview','S','','4','iddetail','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'reductionruledetailview' AND field = 'idreduction')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'reductionruledetailview',denynull = 'S',format = '',col_len = '20',field = 'idreduction',col_precision = '' where tablename = 'reductionruledetailview' AND field = 'idreduction'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','N','System.String','varchar(20)','N','reductionruledetailview','S','','20','idreduction','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'reductionruledetailview' AND field = 'idreductionrule')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'reductionruledetailview',denynull = 'S',format = '',col_len = '4',field = 'idreductionrule',col_precision = '' where tablename = 'reductionruledetailview' AND field = 'idreductionrule'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','int','','N','System.Int32','int','N','reductionruledetailview','S','','4','idreductionrule','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'reductionruledetailview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'reductionruledetailview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'reductionruledetailview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','datetime','','N','System.DateTime','datetime','N','reductionruledetailview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'reductionruledetailview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'reductionruledetailview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'reductionruledetailview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','N','System.String','varchar(64)','N','reductionruledetailview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'reductionruledetailview' AND field = 'reduction')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'reductionruledetailview',denynull = 'S',format = '',col_len = '50',field = 'reduction',col_precision = '' where tablename = 'reductionruledetailview' AND field = 'reduction'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','N','System.String','varchar(50)','N','reductionruledetailview','S','','50','reduction','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'reductionruledetailview' AND field = 'reductionpercentage')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'reductionruledetailview',denynull = 'S',format = '',col_len = '9',field = 'reductionpercentage',col_precision = '19' where tablename = 'reductionruledetailview' AND field = 'reductionpercentage'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','N','System.Decimal','decimal(19,6)','N','reductionruledetailview','S','','9','reductionpercentage','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'reductionruledetailview' AND field = 'start')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'reductionruledetailview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'reductionruledetailview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','datetime','','N','System.DateTime','datetime','N','reductionruledetailview','S','','8','start','')
GO

-- VERIFICA DI reductionruledetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'reductionruledetailview')
UPDATE customobject set isreal = 'N' where objectname = 'reductionruledetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('reductionruledetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

