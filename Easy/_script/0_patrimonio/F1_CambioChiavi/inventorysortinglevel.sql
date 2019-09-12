-- Aggiornamento tabella INVENTORYSORTINGLEVEL e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- inventorytree

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortinglevel' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortinglevel] ADD nlevelint tinyint NULL
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD nlevelint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [inventorytree] ALTER COLUMN nlevelint tinyint NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortinglevel' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorysortinglevel SET nlevelint = CONVERT(tinyint, nlevel)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorytree SET nlevelint = CONVERT(tinyint, nlevel)
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono inventorysortinglevel
IF exists(SELECT * FROM sysconstraints where id=object_id('inventorysortinglevel') and constid=object_id('xpkinventorysortinglevel'))
BEGIN
	ALTER TABLE [inventorysortinglevel] drop constraint xpkinventorysortinglevel
END

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorysortinglevel') and constid=object_id('PK_inventorysortinglevel'))
BEGIN
	ALTER TABLE [inventorysortinglevel] drop constraint PK_inventorysortinglevel
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2inventorytree' and id=object_id('inventorytree'))
	drop index inventorytree.xi2inventorytree
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorysortinglevel'
		and C.name ='nlevel'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorysortinglevel] DROP COLUMN nlevel
	DELETE FROM columntypes WHERE tablename = 'inventorysortinglevel' AND field = 'nlevel'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytree'
		and C.name ='nlevel'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytree] DROP COLUMN nlevel
	DELETE FROM columntypes WHERE tablename = 'inventorytree' AND field = 'nlevel'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortinglevel' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortinglevel] ADD nlevel tinyint NULL
END
ELSE
	ALTER TABLE [inventorysortinglevel] ALTER COLUMN nlevel tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD nlevel tinyint NULL
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN nlevel tinyint NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortinglevel' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorysortinglevel SET nlevel = nlevelint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorytree SET nlevel = nlevelint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortinglevel' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortinglevel] ALTER COLUMN nlevel tinyint NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ALTER COLUMN nlevel tinyint NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventorysortinglevel') and constid=object_id('xpkinventorysortinglevel'))
BEGIN
	ALTER TABLE [inventorysortinglevel] ADD CONSTRAINT xpkinventorysortinglevel PRIMARY KEY (nlevel)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2inventorytree' and id=object_id('inventorytree'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2inventorytree ON inventorytree (nlevel)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2inventorytree
	ON inventorytree (nlevel)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorysortinglevel' AND field = 'nlevel')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 16:13:44.217'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 16:13:44.217'} WHERE tablename = 'inventorysortinglevel' AND field = 'nlevel'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorysortinglevel','nlevel','S','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-23 16:13:44.217'},'''NINO''','NINO',{ts '2007-10-23 16:13:44.217'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorytree' AND field = 'nlevel')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 16:13:44.390'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 16:13:44.390'} WHERE tablename = 'inventorytree' AND field = 'nlevel'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorytree','nlevel','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-23 16:13:44.390'},'''NINO''','NINO',{ts '2007-10-23 16:13:44.390'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorysortinglevel'
		and C.name ='nlevelint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorysortinglevel] DROP COLUMN nlevelint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytree'
		and C.name ='nlevelint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytree] DROP COLUMN nlevelint
END
GO
