-- CREAZIONE VISTA syssegments
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[syssegments]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[syssegments]
GO

CREATE VIEW syssegments (segment, name, status) AS
	SELECT  0, 'system'     , 0  UNION
	SELECT	1, 'default'    , 1  UNION
	SELECT	2, 'logsegment' , 0

GO

-- VERIFICA DI syssegments IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'syssegments'
IF exists(SELECT * FROM columntypes WHERE tablename = 'syssegments' AND field = 'name')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(10)',iskey = 'N',tablename = 'syssegments',denynull = 'S',format = '',col_len = '10',field = 'name',col_precision = '' where tablename = 'syssegments' AND field = 'name'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(10)','N','syssegments','S','','10','name','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'syssegments' AND field = 'segment')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'syssegments',denynull = 'S',format = '',col_len = '4',field = 'segment',col_precision = '' where tablename = 'syssegments' AND field = 'segment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','syssegments','S','','4','segment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'syssegments' AND field = 'status')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'syssegments',denynull = 'S',format = '',col_len = '4',field = 'status',col_precision = '' where tablename = 'syssegments' AND field = 'status'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','syssegments','S','','4','status','')
GO

-- VERIFICA DI syssegments IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'syssegments')
UPDATE customobject set isreal = 'N' where objectname = 'syssegments'
ELSE
INSERT INTO customobject (objectname, isreal) values('syssegments', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

