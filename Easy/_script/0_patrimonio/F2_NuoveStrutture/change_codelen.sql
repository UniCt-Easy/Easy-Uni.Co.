IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortinglevel' and C.name = 'codelen' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortinglevel] ALTER COLUMN codelen tinyint NOT NULL 
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortinglevel' and C.name = 'codelen' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationlevel] ALTER COLUMN codelen tinyint NOT NULL 
END
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorysortinglevel' AND field = 'codelen')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-25 09:18:45.187'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-25 09:18:45.187'} WHERE tablename = 'inventorysortinglevel' AND field = 'codelen'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorysortinglevel','codelen','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-25 09:18:45.187'},'''NINO''','NINO',{ts '2007-10-25 09:18:45.187'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'locationlevel' AND field = 'codelen')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-25 09:18:36.627'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-25 09:18:36.627'} WHERE tablename = 'locationlevel' AND field = 'codelen'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('locationlevel','codelen','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-25 09:18:36.627'},'''NINO''','NINO',{ts '2007-10-25 09:18:36.627'})
GO