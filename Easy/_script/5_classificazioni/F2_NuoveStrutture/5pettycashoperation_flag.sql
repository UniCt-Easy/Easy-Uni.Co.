-- Aggiornamento tabella PETTYCASHOPERATION e tabelle dipendenti
-- Le tabelle dipendenti sono:

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperation] ALTER COLUMN flag tinyint NULL 
END
GO

-- Codifica - A (bit 0), R (bit 1), C (bit 2), S (bit 3), flagdocument (bit 4)
-- A (N = 0; S = 1); R (N = 0; S = 1); C (N = 0; S = 1); S (N = 0; S = 1); flagdocument (N = 0; D = 1)
UPDATE pettycashoperation SET flag = 0
UPDATE pettycashoperation SET flag = flag + 1 WHERE kind = 'A'
UPDATE pettycashoperation SET flag = flag + 2 WHERE kind = 'R'
UPDATE pettycashoperation SET flag = flag + 4 WHERE kind = 'C'
UPDATE pettycashoperation SET flag = flag + 8 WHERE kind = 'S'
UPDATE pettycashoperation SET flag = flag + 16 WHERE ISNULL(flagdocumented,'D') = 'D'

GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name ='kind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN kind
	DELETE FROM columntypes WHERE tablename = 'pettycashoperation' AND field = 'kind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name ='flagdocumented'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN flagdocumented
	DELETE FROM columntypes WHERE tablename = 'pettycashoperation' AND field = 'flagdocumented'
END
GO

ALTER TABLE [pettycashoperation] ALTER COLUMN flag tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperation' AND field = 'flag')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.967'} WHERE tablename = 'pettycashoperation' AND field = 'flag'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('pettycashoperation','flag','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:31.967'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.967'})
GO
