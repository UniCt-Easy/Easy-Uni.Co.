-- Aggiornamento tabella SORTINGLEVEL e tabelle dipendenti
-- Le tabelle dipendenti sono:

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortinglevel' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortinglevel] ADD flag smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [sortinglevel] ALTER COLUMN flag smallint NULL 
END
GO


-- Codifica - codekind (bit 0), flagusable (bit 1), flagrestart (bit 2)
-- codekind (N = 0; A = 1), flagusable (N = 0; S = 1), flagrestart (N = 0; S = 1)
UPDATE sortinglevel SET flag = 0
UPDATE sortinglevel SET flag = flag + 1 WHERE codekind = 'A'
UPDATE sortinglevel SET flag = flag + 2 WHERE flagusable = 'S'
UPDATE sortinglevel SET flag = flag + 4 WHERE flagrestart = 'S'
UPDATE sortinglevel SET flag = flag + 256* codelen 

GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortinglevel'
		and C.name ='codekind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortinglevel] DROP COLUMN codekind
	DELETE FROM columntypes WHERE tablename = 'sortinglevel' AND field = 'codekind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortinglevel'
		and C.name ='flagusable'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortinglevel] DROP COLUMN flagusable
	DELETE FROM columntypes WHERE tablename = 'sortinglevel' AND field = 'flagusable'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortinglevel'
		and C.name ='flagrestart'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortinglevel] DROP COLUMN flagrestart
	DELETE FROM columntypes WHERE tablename = 'sortinglevel' AND field = 'flagrestart'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortinglevel'
		and C.name ='codelen'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortinglevel] DROP COLUMN codelen
	DELETE FROM columntypes WHERE tablename = 'sortinglevel' AND field = 'codelen'
END
GO

ALTER TABLE [sortinglevel] ALTER COLUMN flag smallint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortinglevel' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.967'} WHERE tablename = 'sortinglevel' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortinglevel','flag','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-10-24 17:16:31.967'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.967'})
GO
