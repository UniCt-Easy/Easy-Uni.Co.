-- CREAZIONE VISTA patrimonylookupview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[patrimonylookupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[patrimonylookupview]
GO



--Pino Rana, elaborazione del 10/08/2005 15:18:02
CREATE  VIEW [dbo].[patrimonylookupview] 
	(
	oldidpatrimony,
	oldayear,
	oldcodepatrimony,
	oldtitle,
	oldpatpart,
	newidpatrimony,
	newayear,
	newcodepatrimony,
	newtitle,
	newpatpart,
	cu, 
	ct, 
	lu, 
	lt
	)
	AS SELECT
	patrimonylookup.oldidpatrimony,
	oldstatopat.ayear,
	oldstatopat.codepatrimony,
	oldstatopat.title,
	oldstatopat.patpart,
	patrimonylookup.newidpatrimony,
	newstatopat.ayear,
	newstatopat.codepatrimony,
	newstatopat.title,
	newstatopat.patpart,
	patrimonylookup.cu,
	patrimonylookup.ct,
	patrimonylookup.lu,
	patrimonylookup.lt
	FROM patrimonylookup (NOLOCK)
	JOIN patrimony oldstatopat (NOLOCK)
	ON oldstatopat.idpatrimony = patrimonylookup.oldidpatrimony
	JOIN patrimony newstatopat (NOLOCK)
	ON newstatopat.idpatrimony = patrimonylookup.newidpatrimony




GO

-- VERIFICA DI patrimonylookupview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'patrimonylookupview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','patrimonylookupview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','patrimonylookupview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','patrimonylookupview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','patrimonylookupview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'newayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '2',field = 'newayear',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'newayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','patrimonylookupview','S','','2','newayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'newcodepatrimony')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '50',field = 'newcodepatrimony',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'newcodepatrimony'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','patrimonylookupview','S','','50','newcodepatrimony','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'newidpatrimony')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(31)',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '31',field = 'newidpatrimony',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'newidpatrimony'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(31)','N','patrimonylookupview','S','','31','newidpatrimony','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'newpatpart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '1',field = 'newpatpart',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'newpatpart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','N','System.String','char(1)','N','patrimonylookupview','S','','1','newpatpart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'newtitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '200',field = 'newtitle',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'newtitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(200)','N','patrimonylookupview','S','','200','newtitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'oldayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '2',field = 'oldayear',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'oldayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','patrimonylookupview','S','','2','oldayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'oldcodepatrimony')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '50',field = 'oldcodepatrimony',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'oldcodepatrimony'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','patrimonylookupview','S','','50','oldcodepatrimony','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'oldidpatrimony')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(31)',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '31',field = 'oldidpatrimony',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'oldidpatrimony'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(31)','N','patrimonylookupview','S','','31','oldidpatrimony','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'oldpatpart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '1',field = 'oldpatpart',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'oldpatpart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','N','System.String','char(1)','N','patrimonylookupview','S','','1','oldpatpart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonylookupview' AND field = 'oldtitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'patrimonylookupview',denynull = 'S',format = '',col_len = '200',field = 'oldtitle',col_precision = '' where tablename = 'patrimonylookupview' AND field = 'oldtitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(200)','N','patrimonylookupview','S','','200','oldtitle','')
GO

-- VERIFICA DI patrimonylookupview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'patrimonylookupview')
UPDATE customobject set isreal = 'N' where objectname = 'patrimonylookupview'
ELSE
INSERT INTO customobject (objectname, isreal) values('patrimonylookupview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

