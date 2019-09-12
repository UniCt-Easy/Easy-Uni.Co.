----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
-- Script che crea i campi flag, travasa il contenuto dei vecchi campi nei nuovi e cancella i vecchi campi
-- Tab. payment:-----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' 
and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [payment] ALTER COLUMN flag tinyint NULL 
END
GO

--sp_help payment

-- Tab. proceeds:

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [proceeds] ALTER COLUMN flag tinyint NULL 
END
GO

--sp_help proceeds

--select * from payment
--select * from proceeds

-- Codifica payment - kind (bit 0,1,2)
-- kind (C = 1; R = 2; M = 4)
UPDATE payment  SET flag = 0
UPDATE payment  SET flag = flag + 1 WHERE kind = 'C'
UPDATE payment  SET flag = flag + 2 WHERE kind = 'R'
UPDATE payment  SET flag = flag + 4 WHERE kind = 'M'
GO

-- Codifica proceeds - kind (bit 0 e bit 1 e bit 2); autokind (bit 3)
-- kind (C = 1; R = 2; M = 4) autokind (I = 0; F = 1)
UPDATE proceeds SET flag = 0
UPDATE proceeds SET flag = flag + 1 WHERE kind = 'C'
UPDATE proceeds SET flag = flag + 2 WHERE kind = 'R'
UPDATE proceeds SET flag = flag + 4 WHERE kind = 'M'
UPDATE proceeds SET flag = flag + 8 WHERE accountkind = 'F'
GO

--select * from payment
--select * from proceeds


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='kind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN kind
	DELETE FROM columntypes WHERE tablename = 'payment' AND field = 'kind'
END
GO
--select * from payment

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='kind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN kind
	DELETE FROM columntypes WHERE tablename = 'proceeds' AND field = 'kind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='accountkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN accountkind
	DELETE FROM columntypes WHERE tablename = 'proceeds' AND field = 'accountkind'
END
GO

ALTER TABLE [payment] ALTER COLUMN flag tinyint NOT NULL 
GO

ALTER TABLE [proceeds] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceeds' AND field = 'flag')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceeds',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'proceeds' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','N','System.Byte','tinyint','N','proceeds','S','','1','flag','')
GO


IF exists(SELECT * FROM columntypes WHERE tablename = 'payment' AND field = 'flag')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'payment',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'payment' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','N','System.Byte','tinyint','N','payment','S','','1','flag','')
GO


-- SELECT * FROM payment1
-- SELECT * FROM proceeds1
-- SELECT * INTO payment1   FROM payment
-- SELECT * INTO proceeds1  FROM proceeds 
-- DROP TABLE payment1
-- DROP TABLE proceeds1
-- CLEAR_TABLE_INFO payment 
-- CLEAR_TABLE_INFO proceeds 
