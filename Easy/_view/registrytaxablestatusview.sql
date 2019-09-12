-- CREAZIONE VISTA registrytaxablestatusview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrytaxablestatusview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrytaxablestatusview]
GO


--Pino Rana, elaborazione del 10/08/2005 15:18:07
-- Inserire la ALTER  VIEW qui--
CREATE                                    VIEW [DBO].[registrytaxablestatusview]
	(
	idreg,
	registry, 
	start,
  supposedincome,
	active,
	cu, 
	ct, 
	lu,
	lt
	)
	AS SELECT
	registrytaxablestatus.idreg, 
	registry.title, 
	registrytaxablestatus.start, 
	registrytaxablestatus.supposedincome, 
	registrytaxablestatus.active,
	registrytaxablestatus.cu, 
	registrytaxablestatus.ct, 
	registrytaxablestatus.lu,
	registrytaxablestatus.lt
	FROM registrytaxablestatus (NOLOCK)
	JOIN registry (NOLOCK)
	ON registrytaxablestatus.idreg = registry.idreg




GO

-- VERIFICA DI registrytaxablestatusview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrytaxablestatusview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'registrytaxablestatusview' AND field = 'active')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registrytaxablestatusview',denynull = 'N',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'registrytaxablestatusview' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','registrytaxablestatusview','N','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrytaxablestatusview' AND field = 'ct')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registrytaxablestatusview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'registrytaxablestatusview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','registrytaxablestatusview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrytaxablestatusview' AND field = 'cu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registrytaxablestatusview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'registrytaxablestatusview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','registrytaxablestatusview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrytaxablestatusview' AND field = 'idreg')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registrytaxablestatusview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'registrytaxablestatusview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','registrytaxablestatusview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrytaxablestatusview' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registrytaxablestatusview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'registrytaxablestatusview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','registrytaxablestatusview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrytaxablestatusview' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registrytaxablestatusview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'registrytaxablestatusview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','registrytaxablestatusview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrytaxablestatusview' AND field = 'registry')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registrytaxablestatusview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'registrytaxablestatusview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(100)','N','registrytaxablestatusview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrytaxablestatusview' AND field = 'start')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registrytaxablestatusview',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'registrytaxablestatusview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','registrytaxablestatusview','S','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrytaxablestatusview' AND field = 'supposedincome')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'registrytaxablestatusview',denynull = 'N',format = '',col_len = '9',field = 'supposedincome',col_precision = '19' where tablename = 'registrytaxablestatusview' AND field = 'supposedincome'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','registrytaxablestatusview','N','','9','supposedincome','19')
GO

-- VERIFICA DI registrytaxablestatusview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrytaxablestatusview')
UPDATE customobject set isreal = 'N' where objectname = 'registrytaxablestatusview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrytaxablestatusview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

