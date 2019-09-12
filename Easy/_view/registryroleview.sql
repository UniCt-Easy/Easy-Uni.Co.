-- CREAZIONE VISTA registryroleview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryroleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryroleview]
GO



--Pino Rana, elaborazione del 10/08/2005 15:17:45

CREATE                                   VIEW [DBO].registryroleview
AS
SELECT     registryrole.idreg, 
	   registryrole.idrole, registryrole.start, registryrole.ct, 
                      registryrole.cu, registryrole.stop, registryrole.active, registryrole.lt, registryrole.lu, 
                      registryrole.txt, registry.title as registry, role.description AS role
FROM       registryrole INNER JOIN
                      role ON registryrole.idrole = role.idrole  INNER JOIN
                      registry ON registryrole.idreg = registry.idreg





GO

-- VERIFICA DI registryroleview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryroleview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'active')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'registryroleview' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','registryroleview','N','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'registryroleview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registryroleview','N','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'registryroleview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registryroleview','N','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'idreg')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryroleview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'registryroleview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','registryroleview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'idrole')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(5)',iskey = 'N',tablename = 'registryroleview',denynull = 'S',format = '',col_len = '5',field = 'idrole',col_precision = '' where tablename = 'registryroleview' AND field = 'idrole'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(5)','N','registryroleview','S','','5','idrole','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'registryroleview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registryroleview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'registryroleview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registryroleview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'registry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registryroleview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'registryroleview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(100)','N','registryroleview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'role')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'registryroleview',denynull = 'S',format = '',col_len = '150',field = 'role',col_precision = '' where tablename = 'registryroleview' AND field = 'role'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','registryroleview','S','','150','role','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registryroleview',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'registryroleview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','registryroleview','S','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'stop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'registryroleview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','registryroleview','N','','4','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'txt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'text',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'text',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '16',field = 'txt',col_precision = '' where tablename = 'registryroleview' AND field = 'txt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','text','','S','System.String','text','N','registryroleview','N','','16','txt','')
GO

-- VERIFICA DI registryroleview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryroleview')
UPDATE customobject set isreal = 'N' where objectname = 'registryroleview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryroleview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

