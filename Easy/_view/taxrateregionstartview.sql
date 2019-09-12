-- CREAZIONE VISTA taxrateregionstartview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxrateregionstartview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[taxrateregionstartview]
GO





CREATE         VIEW [DBO].[taxrateregionstartview]
AS
SELECT DISTINCT 
a1.taxcode,
tax.taxref,
a1.idregion,
a1.idtaxrateregionstart,
c1.title as region,
a1.start,
a1.enforcement
FROM taxrateregionstart a1
JOIN geo_region c1
ON a1.idregion = c1.idregion
JOIN tax
ON tax.taxcode = a1.taxcode





GO

-- VERIFICA DI taxrateregionstartview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'taxrateregionstartview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregionstartview' AND field = 'enforcement')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'taxrateregionstartview',denynull = 'N',format = '',col_len = '1',field = 'enforcement',col_precision = '' where tablename = 'taxrateregionstartview' AND field = 'enforcement'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','char','','S','System.String','char(1)','N','taxrateregionstartview','N','','1','enforcement','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregionstartview' AND field = 'idregion')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxrateregionstartview',denynull = 'S',format = '',col_len = '4',field = 'idregion',col_precision = '' where tablename = 'taxrateregionstartview' AND field = 'idregion'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','taxrateregionstartview','S','','4','idregion','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregionstartview' AND field = 'idtaxrateregionstart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxrateregionstartview',denynull = 'S',format = '',col_len = '4',field = 'idtaxrateregionstart',col_precision = '' where tablename = 'taxrateregionstartview' AND field = 'idtaxrateregionstart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','taxrateregionstartview','S','','4','idtaxrateregionstart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregionstartview' AND field = 'region')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxrateregionstartview',denynull = 'N',format = '',col_len = '50',field = 'region',col_precision = '' where tablename = 'taxrateregionstartview' AND field = 'region'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(50)','N','taxrateregionstartview','N','','50','region','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregionstartview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxrateregionstartview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'taxrateregionstartview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','taxrateregionstartview','S','','8','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregionstartview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxrateregionstartview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'taxrateregionstartview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','taxrateregionstartview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregionstartview' AND field = 'taxref')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'taxrateregionstartview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'taxrateregionstartview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(20)','N','taxrateregionstartview','S','','20','taxref','')
GO

-- VERIFICA DI taxrateregionstartview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'taxrateregionstartview')
UPDATE customobject set isreal = 'N' where objectname = 'taxrateregionstartview'
ELSE
INSERT INTO customobject (objectname, isreal) values('taxrateregionstartview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

