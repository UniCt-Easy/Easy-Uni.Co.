-- CREAZIONE VISTA taxpaymentpartsetupview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxpaymentpartsetupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxpaymentpartsetupview]
GO





CREATE VIEW taxpaymentpartsetupview 
	(
  taxcode,
  taxref,
  taxkind,
  ayear,
  idreg,
  registry,
  percentage,
	cu,
	ct,
	lu,
	lt
  )
  AS SELECT
  taxpaymentpartsetup.taxcode,
  tax.taxref,
  tax.description,
  taxpaymentpartsetup.ayear,
  taxpaymentpartsetup.idreg,
  registry.title,
	taxpaymentpartsetup.percentage,
  taxpaymentpartsetup.cu,
  taxpaymentpartsetup.ct,
  taxpaymentpartsetup.lu,
  taxpaymentpartsetup.lt
  FROM taxpaymentpartsetup (NOLOCK)
JOIN tax (NOLOCK)
  ON tax.taxcode = taxpaymentpartsetup.taxcode
  JOIN registry (NOLOCK)
  ON registry.idreg = taxpaymentpartsetup.idreg










GO

-- VERIFICA DI taxpaymentpartsetupview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'taxpaymentpartsetupview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'ayear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'taxpaymentpartsetupview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','taxpaymentpartsetupview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'taxpaymentpartsetupview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','taxpaymentpartsetupview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'taxpaymentpartsetupview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','taxpaymentpartsetupview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'idreg')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'taxpaymentpartsetupview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','taxpaymentpartsetupview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'taxpaymentpartsetupview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','datetime','','N','System.DateTime','datetime','N','taxpaymentpartsetupview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'taxpaymentpartsetupview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(64)','N','taxpaymentpartsetupview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'percentage')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'N',format = '',col_len = '9',field = 'percentage',col_precision = '19' where tablename = 'taxpaymentpartsetupview' AND field = 'percentage'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','8','decimal','','S','System.Decimal','decimal(19,8)','N','taxpaymentpartsetupview','N','','9','percentage','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'registry')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'taxpaymentpartsetupview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(100)','N','taxpaymentpartsetupview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'taxpaymentpartsetupview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','taxpaymentpartsetupview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'taxkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'S',format = '',col_len = '50',field = 'taxkind',col_precision = '' where tablename = 'taxpaymentpartsetupview' AND field = 'taxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','taxpaymentpartsetupview','S','','50','taxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxpaymentpartsetupview' AND field = 'taxref')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'taxpaymentpartsetupview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'taxpaymentpartsetupview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(20)','N','taxpaymentpartsetupview','S','','20','taxref','')
GO

-- VERIFICA DI taxpaymentpartsetupview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'taxpaymentpartsetupview')
UPDATE customobject set isreal = 'N' where objectname = 'taxpaymentpartsetupview'
ELSE
INSERT INTO customobject (objectname, isreal) values('taxpaymentpartsetupview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

