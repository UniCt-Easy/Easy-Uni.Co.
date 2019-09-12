-- Aggiornamento tabella EXPIRATIONKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- estimate, mandate, invoice, registrypaymethod

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expirationkind' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expirationkind] ADD idexpirationkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [expirationkind] ALTER COLUMN idexpirationkindint smallint NULL
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimate] ADD idexpirationkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [estimate] ALTER COLUMN idexpirationkindint smallint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoice] ADD idexpirationkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [invoice] ALTER COLUMN idexpirationkindint smallint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrypaymethod] ADD idexpirationkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [registrypaymethod] ALTER COLUMN idexpirationkindint smallint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandate] ADD idexpirationkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [mandate] ALTER COLUMN idexpirationkindint smallint NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expirationkind' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expirationkind SET idexpirationkindint = CONVERT(smallint, idexpirationkind)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimate SET idexpirationkindint = CONVERT(smallint, idexpirationkind)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandate SET idexpirationkindint = CONVERT(smallint, idexpirationkind)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoice SET idexpirationkindint = CONVERT(smallint, idexpirationkind)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrypaymethod SET idexpirationkindint = CONVERT(smallint, idexpirationkind)
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono inventorysortinglevel
IF exists(SELECT * FROM sysconstraints where id=object_id('expirationkind') and constid=object_id('xpkexpirationkind'))
BEGIN
	ALTER TABLE [expirationkind] drop constraint xpkexpirationkind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expirationkind') and constid=object_id('PK_expirationkind'))
BEGIN
	ALTER TABLE [expirationkind] drop constraint PK_expirationkind
END
GO

-- Passo 4.2: Indici NON CI SONO INDICI

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expirationkind'
		and C.name ='idexpirationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expirationkind] DROP COLUMN idexpirationkind
	DELETE FROM columntypes WHERE tablename = 'expirationkind' AND field = 'idexpirationkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimate'
		and C.name ='idexpirationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimate] DROP COLUMN idexpirationkind
	DELETE FROM columntypes WHERE tablename = 'estimate' AND field = 'idexpirationkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandate'
		and C.name ='idexpirationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandate] DROP COLUMN idexpirationkind
	DELETE FROM columntypes WHERE tablename = 'mandate' AND field = 'idexpirationkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoice'
		and C.name ='idexpirationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoice] DROP COLUMN idexpirationkind
	DELETE FROM columntypes WHERE tablename = 'invoice' AND field = 'idexpirationkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrypaymethod'
		and C.name ='idexpirationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrypaymethod] DROP COLUMN idexpirationkind
	DELETE FROM columntypes WHERE tablename = 'registrypaymethod' AND field = 'idexpirationkind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expirationkind' and C.name = 'idexpirationkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expirationkind] ADD idexpirationkind smallint NULL
END
ELSE
	ALTER TABLE [expirationkind] ALTER COLUMN idexpirationkind smallint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idexpirationkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimate] ADD idexpirationkind smallint NULL
END
ELSE
	ALTER TABLE [estimate] ALTER COLUMN idexpirationkind smallint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idexpirationkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandate] ADD idexpirationkind smallint NULL
END
ELSE
	ALTER TABLE [mandate] ALTER COLUMN idexpirationkind smallint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idexpirationkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoice] ADD idexpirationkind smallint NULL
END
ELSE
	ALTER TABLE [invoice] ALTER COLUMN idexpirationkind smallint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idexpirationkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrypaymethod] ADD idexpirationkind smallint NULL
END
ELSE
	ALTER TABLE [registrypaymethod] ALTER COLUMN idexpirationkind smallint NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expirationkind' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expirationkind SET idexpirationkind = idexpirationkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimate SET idexpirationkind = idexpirationkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandate SET idexpirationkind = idexpirationkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoice SET idexpirationkind = idexpirationkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idexpirationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrypaymethod SET idexpirationkind = idexpirationkindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expirationkind' and C.name = 'idexpirationkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expirationkind] ALTER COLUMN idexpirationkind smallint NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave NON CI SONO CAMPI NON CHIAVE DA IMPOSTARE A NOT NULL

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expirationkind') and constid=object_id('xpkexpirationkind'))
BEGIN
	ALTER TABLE [expirationkind] ADD CONSTRAINT xpkexpirationkind PRIMARY KEY (idexpirationkind)
END
GO

-- Passo 8.2: Indici NON CI SONO INDICI

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimate' AND field = 'idexpirationkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-26 15:31:10.187'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 15:31:10.187'} WHERE tablename = 'estimate' AND field = 'idexpirationkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('estimate','idexpirationkind','N','smallint','2',null,null,'System.Int16','smallint','S','',null,'N',{ts '2007-11-26 15:31:10.187'},'''NINO''','NINO',{ts '2007-11-26 15:31:10.187'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expirationkind' AND field = 'idexpirationkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-26 15:31:15.157'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 15:31:15.157'} WHERE tablename = 'expirationkind' AND field = 'idexpirationkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expirationkind','idexpirationkind','S','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-11-26 15:31:15.157'},'''NINO''','NINO',{ts '2007-11-26 15:31:15.157'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoice' AND field = 'idexpirationkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-26 15:31:19.750'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 15:31:19.750'} WHERE tablename = 'invoice' AND field = 'idexpirationkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoice','idexpirationkind','N','smallint','2',null,null,'System.Int16','smallint','S','',null,'N',{ts '2007-11-26 15:31:19.750'},'''NINO''','NINO',{ts '2007-11-26 15:31:19.750'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandate' AND field = 'idexpirationkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-26 15:31:08.733'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 15:31:08.733'} WHERE tablename = 'mandate' AND field = 'idexpirationkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('mandate','idexpirationkind','N','smallint','2',null,null,'System.Int16','smallint','S','',null,'N',{ts '2007-11-26 15:31:08.733'},'''NINO''','NINO',{ts '2007-11-26 15:31:08.733'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registrypaymethod' AND field = 'idexpirationkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-26 15:31:07.297'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 15:31:07.297'} WHERE tablename = 'registrypaymethod' AND field = 'idexpirationkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registrypaymethod','idexpirationkind','N','smallint','2',null,null,'System.Int16','smallint','S','',null,'N',{ts '2007-11-26 15:31:07.297'},'''NINO''','NINO',{ts '2007-11-26 15:31:07.297'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expirationkind'
		and C.name ='idexpirationkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expirationkind] DROP COLUMN idexpirationkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoice'
		and C.name ='idexpirationkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoice] DROP COLUMN idexpirationkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimate'
		and C.name ='idexpirationkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimate] DROP COLUMN idexpirationkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandate'
		and C.name ='idexpirationkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandate] DROP COLUMN idexpirationkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrypaymethod'
		and C.name ='idexpirationkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrypaymethod] DROP COLUMN idexpirationkindint
END
GO
