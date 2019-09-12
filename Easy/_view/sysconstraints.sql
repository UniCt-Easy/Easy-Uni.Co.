-- CREAZIONE VISTA sysconstraints
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sysconstraints]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sysconstraints]
GO

CREATE VIEW sysconstraints AS SELECT
	constid = convert(int, id),
	id = convert(int, parent_obj),
	colid = convert(smallint, info),
	spare1 = convert(tinyint, 0),
	status = convert(int,
			CASE xtype
				WHEN 'PK' THEN 1 WHEN 'UQ' THEN 2 WHEN 'F' THEN 3
				WHEN 'C' THEN 4 WHEN 'D' THEN 5 ELSE 0 END
			+ CASE WHEN info != 0			-- CNST_COLUMN / CNST_TABLE
					THEN (16) ELSE (32) END
			+ CASE WHEN (status & 16)!=0	-- CNST_CLINDEX
					THEN (512) ELSE 0 END
			+ CASE WHEN (status & 32)!=0	-- CNST_NCLINDEX
					THEN (1024) ELSE 0 END
			+ (2048)						-- CNST_NOTDEFERRABLE
			+ CASE WHEN (status & 256)!=0	-- CNST_DISABLE
					THEN (16384) ELSE 0 END
			+ CASE WHEN (status & 512)!=0	-- CNST_ENABLE
					THEN (32767) ELSE 0 END
			+ CASE WHEN (status & 4)!=0		-- CNST_NONAME
					THEN (131072) ELSE 0 END
			+ CASE WHEN (status & 1)!=0		-- CNST_NEW
					THEN (1048576) ELSE 0 END
			+ CASE WHEN (status & 1024)!=0	-- CNST_REPL
					THEN (2097152) ELSE 0 END),
	actions = convert(int,  4096),
	error = convert(int, 0)
FROM sysobjects WHERE xtype in ('C', 'F', 'PK', 'UQ', 'D')
					AND (status & 64) = 0

GO

-- VERIFICA DI sysconstraints IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sysconstraints'
IF exists(SELECT * FROM columntypes WHERE tablename = 'sysconstraints' AND field = 'actions')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sysconstraints',denynull = 'N',format = '',col_len = '4',field = 'actions',col_precision = '' where tablename = 'sysconstraints' AND field = 'actions'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','sysconstraints','N','','4','actions','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sysconstraints' AND field = 'colid')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sysconstraints',denynull = 'N',format = '',col_len = '2',field = 'colid',col_precision = '' where tablename = 'sysconstraints' AND field = 'colid'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smallint','','S','System.Int16','smallint','N','sysconstraints','N','','2','colid','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sysconstraints' AND field = 'constid')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sysconstraints',denynull = 'N',format = '',col_len = '4',field = 'constid',col_precision = '' where tablename = 'sysconstraints' AND field = 'constid'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','sysconstraints','N','','4','constid','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sysconstraints' AND field = 'error')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sysconstraints',denynull = 'N',format = '',col_len = '4',field = 'error',col_precision = '' where tablename = 'sysconstraints' AND field = 'error'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','sysconstraints','N','','4','error','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sysconstraints' AND field = 'id')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sysconstraints',denynull = 'N',format = '',col_len = '4',field = 'id',col_precision = '' where tablename = 'sysconstraints' AND field = 'id'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','sysconstraints','N','','4','id','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sysconstraints' AND field = 'spare1')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'sysconstraints',denynull = 'N',format = '',col_len = '1',field = 'spare1',col_precision = '' where tablename = 'sysconstraints' AND field = 'spare1'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','tinyint','','S','System.Byte','tinyint','N','sysconstraints','N','','1','spare1','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sysconstraints' AND field = 'status')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sysconstraints',denynull = 'N',format = '',col_len = '4',field = 'status',col_precision = '' where tablename = 'sysconstraints' AND field = 'status'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','sysconstraints','N','','4','status','')
GO

-- VERIFICA DI sysconstraints IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sysconstraints')
UPDATE customobject set isreal = 'N' where objectname = 'sysconstraints'
ELSE
INSERT INTO customobject (objectname, isreal) values('sysconstraints', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

