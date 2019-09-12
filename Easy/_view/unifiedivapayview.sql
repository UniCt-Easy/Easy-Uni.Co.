-- CREAZIONE VISTA unifiedivapayview
IF EXISTS(select * from sysobjects where id = object_id(N'[unifiedivapayview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [unifiedivapayview]
GO


CREATE  VIEW unifiedivapayview
(
yunifiedivapay,
nunifiedivapay,
iddepartment,
department,
assesmentdate,
creditamount,
creditamountdeferred,
debitamount,
debitamountdeferred,
paymentamount,
refundamount,
paymentkind,
start,
stop,
paymentdetails,
mixed,
prorata,
dateivapay,
ct,
cu,
lt,
lu
)
AS SELECT
unifiedivapay.yunifiedivapay,
unifiedivapay.nunifiedivapay,
unifiedivapay.iddepartment,
department.description,
unifiedivapay.assesmentdate,
unifiedivapay.creditamount,
unifiedivapay.creditamountdeferred,
unifiedivapay.debitamount,
unifiedivapay.debitamountdeferred,
unifiedivapay.paymentamount,
unifiedivapay.refundamount,
unifiedivapay.paymentkind,
unifiedivapay.start,
unifiedivapay.stop,
unifiedivapay.paymentdetails,
unifiedivapay.mixed,
unifiedivapay.prorata,
unifiedivapay.dateivapay,
unifiedivapay.ct,
unifiedivapay.cu,
unifiedivapay.lt,
unifiedivapay.lu
FROM unifiedivapay
JOIN department
ON unifiedivapay.iddepartment = department.iddepartment



GO

-- VERIFICA DI unifiedivapayview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'unifiedivapayview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'assesmentdate')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '8',field = 'assesmentdate',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'assesmentdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','S','System.DateTime','datetime','N','unifiedivapayview','N','','8','assesmentdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'creditamount')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '9',field = 'creditamount',col_precision = '19' where tablename = 'unifiedivapayview' AND field = 'creditamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapayview','N','','9','creditamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'creditamountdeferred')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '9',field = 'creditamountdeferred',col_precision = '19' where tablename = 'unifiedivapayview' AND field = 'creditamountdeferred'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapayview','N','','9','creditamountdeferred','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'ct')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','unifiedivapayview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'cu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','unifiedivapayview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'dateivapay')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '8',field = 'dateivapay',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'dateivapay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','S','System.DateTime','datetime','N','unifiedivapayview','N','','8','dateivapay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'debitamount')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '9',field = 'debitamount',col_precision = '19' where tablename = 'unifiedivapayview' AND field = 'debitamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapayview','N','','9','debitamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'debitamountdeferred')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '9',field = 'debitamountdeferred',col_precision = '19' where tablename = 'unifiedivapayview' AND field = 'debitamountdeferred'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapayview','N','','9','debitamountdeferred','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'department')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '50',field = 'department',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'department'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','unifiedivapayview','S','','50','department','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'iddepartment')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '4',field = 'iddepartment',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'iddepartment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','unifiedivapayview','S','','4','iddepartment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','unifiedivapayview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','unifiedivapayview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'mixed')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '9',field = 'mixed',col_precision = '19' where tablename = 'unifiedivapayview' AND field = 'mixed'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','unifiedivapayview','N','','9','mixed','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'nunifiedivapay')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '4',field = 'nunifiedivapay',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'nunifiedivapay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','unifiedivapayview','S','','4','nunifiedivapay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'paymentamount')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '9',field = 'paymentamount',col_precision = '19' where tablename = 'unifiedivapayview' AND field = 'paymentamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapayview','N','','9','paymentamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'paymentdetails')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '150',field = 'paymentdetails',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'paymentdetails'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(150)','N','unifiedivapayview','N','','150','paymentdetails','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'paymentkind')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '1',field = 'paymentkind',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'paymentkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','N','System.String','char(1)','N','unifiedivapayview','S','','1','paymentkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'prorata')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '9',field = 'prorata',col_precision = '19' where tablename = 'unifiedivapayview' AND field = 'prorata'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','unifiedivapayview','N','','9','prorata','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'refundamount')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'N',format = '',col_len = '9',field = 'refundamount',col_precision = '19' where tablename = 'unifiedivapayview' AND field = 'refundamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapayview','N','','9','refundamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'start')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','unifiedivapayview','S','','8','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'stop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '8',field = 'stop',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','unifiedivapayview','S','','8','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapayview' AND field = 'yunifiedivapay')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'unifiedivapayview',denynull = 'S',format = '',col_len = '4',field = 'yunifiedivapay',col_precision = '' where tablename = 'unifiedivapayview' AND field = 'yunifiedivapay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','unifiedivapayview','S','','4','yunifiedivapay','')
GO

-- VERIFICA DI unifiedivapayview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'unifiedivapayview')
UPDATE customobject set isreal = 'N' where objectname = 'unifiedivapayview'
ELSE
INSERT INTO customobject (objectname, isreal) values('unifiedivapayview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

