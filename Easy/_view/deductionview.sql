-- CREAZIONE VISTA deductionview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[deductionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[deductionview]
GO


--Pino Rana, elaborazione del 10/08/2005 15:18:06
CREATE                                    VIEW [DBO].deductionview
AS
SELECT     deduction.iddeduction, deductioncode.ayear, deductioncode.code AS deductioncode,--codicededuzione, 
			deduction.calculationkind, 
                      deduction.taxablecode, deduction.description, deductioncode.longdescription, deduction.validitystart, 
                      deduction.validitystop, deduction.evaluatesp, deduction.evaluationorder, 
                      deductioncode.description AS deductiontitle,--desccodicededuzione,
			 deductioncode.exemption, deductioncode.maximal, 
                      deductioncode.rate, deduction.flagdeductibleexpense
FROM         deduction INNER JOIN
                      deductioncode ON deduction.iddeduction = deductioncode.iddeduction INNER JOIN
                      taxablekind ON deduction.taxablecode = taxablekind.taxablecode AND 
                      deductioncode.ayear = taxablekind.ayear



GO

-- VERIFICA DI deductionview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'deductionview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'ayear')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'deductionview',denynull = 'S',format = '',col_len = '4',field = 'ayear',col_precision = '' where tablename = 'deductionview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','deductionview','S','','4','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'calculationkind')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'deductionview',denynull = 'S',format = '',col_len = '1',field = 'calculationkind',col_precision = '' where tablename = 'deductionview' AND field = 'calculationkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','N','System.String','char(1)','N','deductionview','S','','1','calculationkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'deductioncode')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'deductionview',denynull = 'N',format = '',col_len = '20',field = 'deductioncode',col_precision = '' where tablename = 'deductionview' AND field = 'deductioncode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(20)','N','deductionview','N','','20','deductioncode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'deductiontitle')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'deductionview',denynull = 'N',format = '',col_len = '200',field = 'deductiontitle',col_precision = '' where tablename = 'deductionview' AND field = 'deductiontitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(200)','N','deductionview','N','','200','deductiontitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'description')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'deductionview',denynull = 'S',format = '',col_len = '200',field = 'description',col_precision = '' where tablename = 'deductionview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(200)','N','deductionview','S','','200','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'evaluatesp')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'deductionview',denynull = 'S',format = '',col_len = '50',field = 'evaluatesp',col_precision = '' where tablename = 'deductionview' AND field = 'evaluatesp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','deductionview','S','','50','evaluatesp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'evaluationorder')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'deductionview',denynull = 'N',format = '',col_len = '4',field = 'evaluationorder',col_precision = '' where tablename = 'deductionview' AND field = 'evaluationorder'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','deductionview','N','','4','evaluationorder','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'exemption')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'deductionview',denynull = 'N',format = '',col_len = '9',field = 'exemption',col_precision = '19' where tablename = 'deductionview' AND field = 'exemption'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','deductionview','N','','9','exemption','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'flagdeductibleexpense')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'deductionview',denynull = 'S',format = '',col_len = '1',field = 'flagdeductibleexpense',col_precision = '' where tablename = 'deductionview' AND field = 'flagdeductibleexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','N','System.String','char(1)','N','deductionview','S','','1','flagdeductibleexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'iddeduction')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'deductionview',denynull = 'S',format = '',col_len = '4',field = 'iddeduction',col_precision = '' where tablename = 'deductionview' AND field = 'iddeduction'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','deductionview','S','','4','iddeduction','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'longdescription')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'text',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'text',iskey = 'N',tablename = 'deductionview',denynull = 'N',format = '',col_len = '16',field = 'longdescription',col_precision = '' where tablename = 'deductionview' AND field = 'longdescription'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','text','','S','System.String','text','N','deductionview','N','','16','longdescription','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'maximal')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'deductionview',denynull = 'N',format = '',col_len = '9',field = 'maximal',col_precision = '19' where tablename = 'deductionview' AND field = 'maximal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','deductionview','N','','9','maximal','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'rate')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'deductionview',denynull = 'N',format = '',col_len = '9',field = 'rate',col_precision = '19' where tablename = 'deductionview' AND field = 'rate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','deductionview','N','','9','rate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'taxablecode')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'deductionview',denynull = 'S',format = '',col_len = '20',field = 'taxablecode',col_precision = '' where tablename = 'deductionview' AND field = 'taxablecode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(20)','N','deductionview','S','','20','taxablecode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'validitystart')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'deductionview',denynull = 'N',format = '',col_len = '8',field = 'validitystart',col_precision = '' where tablename = 'deductionview' AND field = 'validitystart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','S','System.DateTime','datetime','N','deductionview','N','','8','validitystart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'deductionview' AND field = 'validitystop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'deductionview',denynull = 'N',format = '',col_len = '8',field = 'validitystop',col_precision = '' where tablename = 'deductionview' AND field = 'validitystop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','S','System.DateTime','datetime','N','deductionview','N','','8','validitystop','')
GO

-- VERIFICA DI deductionview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'deductionview')
UPDATE customobject set isreal = 'N' where objectname = 'deductionview'
ELSE
INSERT INTO customobject (objectname, isreal) values('deductionview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

