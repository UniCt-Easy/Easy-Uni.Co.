-- CREAZIONE VISTA taxratecitystartview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxratecitystartview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[taxratecitystartview]
GO




CREATE   VIEW [DBO].[taxratecitystartview]
AS
SELECT DISTINCT 
a1.taxcode,
tax.taxref,
a1.idcity,
a1.idtaxratecitystart,
c1.title as city,
p1.idcountry,
p1.title as country,
a1.start,
a1.enforcement,
a1.annotations
FROM taxratecitystart a1
JOIN geo_city c1
ON a1.idcity = c1.idcity
JOIN geo_country p1
ON c1.idcountry = p1.idcountry
JOIN tax
ON tax.taxcode = a1.taxcode




GO

-- VERIFICA DI taxratecitystartview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'taxratecitystartview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratecitystartview' AND field = 'annotations')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(400)',iskey = 'N',tablename = 'taxratecitystartview',denynull = 'N',format = '',col_len = '400',field = 'annotations',col_precision = '' where tablename = 'taxratecitystartview' AND field = 'annotations'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(400)','N','taxratecitystartview','N','','400','annotations','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratecitystartview' AND field = 'city')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'taxratecitystartview',denynull = 'N',format = '',col_len = '65',field = 'city',col_precision = '' where tablename = 'taxratecitystartview' AND field = 'city'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(65)','N','taxratecitystartview','N','','65','city','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratecitystartview' AND field = 'country')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxratecitystartview',denynull = 'N',format = '',col_len = '50',field = 'country',col_precision = '' where tablename = 'taxratecitystartview' AND field = 'country'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','taxratecitystartview','N','','50','country','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratecitystartview' AND field = 'enforcement')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'taxratecitystartview',denynull = 'N',format = '',col_len = '1',field = 'enforcement',col_precision = '' where tablename = 'taxratecitystartview' AND field = 'enforcement'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(1)','N','taxratecitystartview','N','','1','enforcement','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratecitystartview' AND field = 'idcity')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxratecitystartview',denynull = 'S',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'taxratecitystartview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','taxratecitystartview','S','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratecitystartview' AND field = 'idcountry')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxratecitystartview',denynull = 'S',format = '',col_len = '4',field = 'idcountry',col_precision = '' where tablename = 'taxratecitystartview' AND field = 'idcountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','taxratecitystartview','S','','4','idcountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratecitystartview' AND field = 'idtaxratecitystart')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxratecitystartview',denynull = 'S',format = '',col_len = '4',field = 'idtaxratecitystart',col_precision = '' where tablename = 'taxratecitystartview' AND field = 'idtaxratecitystart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','taxratecitystartview','S','','4','idtaxratecitystart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratecitystartview' AND field = 'start')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxratecitystartview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'taxratecitystartview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','taxratecitystartview','S','','8','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratecitystartview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxratecitystartview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'taxratecitystartview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','taxratecitystartview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxratecitystartview' AND field = 'taxref')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'taxratecitystartview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'taxratecitystartview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','taxratecitystartview','S','','20','taxref','')
GO

-- VERIFICA DI taxratecitystartview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'taxratecitystartview')
UPDATE customobject set isreal = 'N' where objectname = 'taxratecitystartview'
ELSE
INSERT INTO customobject (objectname, isreal) values('taxratecitystartview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

