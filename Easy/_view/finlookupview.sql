-- CREAZIONE VISTA finlookupview
IF EXISTS(select * from sysobjects where id = object_id(N'[finlookupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finlookupview]
GO



--Pino Rana, elaborazione del 10/08/2005 15:18:02
CREATE                                  VIEW finlookupview 
	(
	oldidfin,
	oldayear,
	oldpartfin,
	oldcodefin,
	oldtitle,
	newidfin,
	newayear,
	newpartfin,
	newfincode,
	newtitle,
	cu, 
	ct, 
	lu, 
	lt
	)
	AS SELECT
	finlookup.oldidfin,
	oldbilancio.ayear,
	--oldbilancio.finpart,
	CASE
		WHEN ((oldbilancio.flag&1)=0) THEN 'E'
		WHEN ((oldbilancio.flag&1)=1) THEN 'S'
	END,
	oldbilancio.codefin,
	oldbilancio.title,
	finlookup.newidfin,
	newbilancio.ayear,
	--newbilancio.finpart,
	CASE
		WHEN ((newbilancio.flag&1)=0) THEN 'E'
		WHEN ((newbilancio.flag&1)=1) THEN 'S'
	END,
	newbilancio.codefin,
	newbilancio.title,
	finlookup.cu,
	finlookup.ct,
	finlookup.lu,
	finlookup.lt
	FROM finlookup (NOLOCK)
	JOIN fin oldbilancio (NOLOCK)
	ON oldbilancio.idfin = finlookup.oldidfin
	JOIN fin newbilancio (NOLOCK)
	ON newbilancio.idfin = finlookup.newidfin






GO

-- VERIFICA DI finlookupview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'finlookupview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'finlookupview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','finlookupview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'finlookupview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','finlookupview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'finlookupview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','finlookupview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'finlookupview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','finlookupview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'newayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '2',field = 'newayear',col_precision = '' where tablename = 'finlookupview' AND field = 'newayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','finlookupview','S','','2','newayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'newfincode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '50',field = 'newfincode',col_precision = '' where tablename = 'finlookupview' AND field = 'newfincode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(50)','N','finlookupview','S','','50','newfincode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'newidfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '4',field = 'newidfin',col_precision = '' where tablename = 'finlookupview' AND field = 'newidfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','finlookupview','S','','4','newidfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'newpartfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'finlookupview',denynull = 'N',format = '',col_len = '1',field = 'newpartfin',col_precision = '' where tablename = 'finlookupview' AND field = 'newpartfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(1)','N','finlookupview','N','','1','newpartfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'newtitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '150',field = 'newtitle',col_precision = '' where tablename = 'finlookupview' AND field = 'newtitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(150)','N','finlookupview','S','','150','newtitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'oldayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '2',field = 'oldayear',col_precision = '' where tablename = 'finlookupview' AND field = 'oldayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','finlookupview','S','','2','oldayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'oldcodefin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '50',field = 'oldcodefin',col_precision = '' where tablename = 'finlookupview' AND field = 'oldcodefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(50)','N','finlookupview','S','','50','oldcodefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'oldidfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '4',field = 'oldidfin',col_precision = '' where tablename = 'finlookupview' AND field = 'oldidfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','finlookupview','S','','4','oldidfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'oldpartfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'finlookupview',denynull = 'N',format = '',col_len = '1',field = 'oldpartfin',col_precision = '' where tablename = 'finlookupview' AND field = 'oldpartfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(1)','N','finlookupview','N','','1','oldpartfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlookupview' AND field = 'oldtitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'finlookupview',denynull = 'S',format = '',col_len = '150',field = 'oldtitle',col_precision = '' where tablename = 'finlookupview' AND field = 'oldtitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(150)','N','finlookupview','S','','150','oldtitle','')
GO

-- VERIFICA DI finlookupview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'finlookupview')
UPDATE customobject set isreal = 'N' where objectname = 'finlookupview'
ELSE
INSERT INTO customobject (objectname, isreal) values('finlookupview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

