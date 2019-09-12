-- CREAZIONE VISTA taxregionsetupview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxregionsetupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxregionsetupview]
GO




CREATE                                          VIEW [taxregionsetupview]
	(
	taxcode,
	taxref,
	taxkind,
	ayear,
	autoid,
	kind,
	idplace,
	place,
	regionalagency,
	regionalagencytitle,
	cu,
	ct,
	lu,
	lt
  )
  AS SELECT
  taxregionsetup.taxcode,
  tax.taxref,
  tax.description,
  taxregionsetup.ayear,
  taxregionsetup.autoid,
  taxregionsetup.kind,
  taxregionsetup.idplace,
  CASE 
	WHEN (taxregionsetup.kind = 'R') THEN geo_region.title
	WHEN (taxregionsetup.kind = 'P') THEN geo_country.title
	WHEN (taxregionsetup.kind = 'E') THEN geo_nation.title
  END,
  taxregionsetup.regionalagency,
  registry.title,
  taxregionsetup.cu,
  taxregionsetup.ct,
  taxregionsetup.lu,
  taxregionsetup.lt
  FROM taxregionsetup (NOLOCK)
  JOIN tax (NOLOCK)
  ON tax.taxcode = taxregionsetup.taxcode
  LEFT OUTER JOIN registry (NOLOCK)
  ON registry.idreg = taxregionsetup.regionalagency
  LEFT OUTER JOIN geo_region (NOLOCK)
  ON geo_region.idregion = taxregionsetup.idplace
  LEFT OUTER JOIN geo_country (NOLOCK)
  ON geo_country.idcountry = taxregionsetup.idplace
  LEFT OUTER JOIN geo_nation (NOLOCK)
  ON geo_nation.idnation = taxregionsetup.idplace









GO

-- VERIFICA DI taxregionsetupview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'taxregionsetupview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'autoid')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'S',format = '',col_len = '4',field = 'autoid',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'autoid'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','taxregionsetupview','S','','4','autoid','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','taxregionsetupview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','taxregionsetupview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','taxregionsetupview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'idplace')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'N',format = '',col_len = '4',field = 'idplace',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'idplace'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','taxregionsetupview','N','','4','idplace','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'kind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'N',format = '',col_len = '1',field = 'kind',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'kind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','char','','S','System.String','char(1)','N','taxregionsetupview','N','','1','kind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','taxregionsetupview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','taxregionsetupview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'place')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'N',format = '',col_len = '65',field = 'place',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'place'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(65)','N','taxregionsetupview','N','','65','place','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'regionalagency')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'N',format = '',col_len = '4',field = 'regionalagency',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'regionalagency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','taxregionsetupview','N','','4','regionalagency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'regionalagencytitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'N',format = '',col_len = '100',field = 'regionalagencytitle',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'regionalagencytitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(100)','N','taxregionsetupview','N','','100','regionalagencytitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','taxregionsetupview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'taxkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'S',format = '',col_len = '50',field = 'taxkind',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'taxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(50)','N','taxregionsetupview','S','','50','taxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxregionsetupview' AND field = 'taxref')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'taxregionsetupview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'taxregionsetupview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(20)','N','taxregionsetupview','S','','20','taxref','')
GO

-- VERIFICA DI taxregionsetupview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'taxregionsetupview')
UPDATE customobject set isreal = 'N' where objectname = 'taxregionsetupview'
ELSE
INSERT INTO customobject (objectname, isreal) values('taxregionsetupview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

