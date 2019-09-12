-- Aggiornamento tabella ASSETLOCATION e tabelle dipendenti
-- Le tabelle dipendenti sono: -

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrit� referenziale

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento) e Passo 2. (aggiunta delle colonne nelle tabelle referenziate)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetlocation' and C.name = 'idassetlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetlocation] ADD idassetlocation int NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetlocation' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetlocation] ALTER COLUMN start smalldatetime NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetlocation' and C.name = 'idassetlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetlocation
	SET idassetlocation = 1 +
		(SELECT COUNT(*)
		FROM assetlocation a2
		WHERE assetlocation.idasset = a2.idasset
			AND assetlocation.start < a2.start)
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono -

IF exists(SELECT * FROM sysconstraints where id=object_id('assetlocation') and constid=object_id('xpkassetlocation'))
BEGIN
	ALTER TABLE [assetlocation] drop constraint xpkassetlocation
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetlocation') and constid=object_id('PK_assetlocation'))
BEGIN
	ALTER TABLE [assetlocation] drop constraint PK_assetlocation
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetlocation
IF EXISTS (SELECT * FROM sysindexes where name='xi1assetlocation' and id=object_id('assetlocation'))
	drop index assetlocation.xi1assetlocation
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetlocation' and id=object_id('assetlocation'))
	drop index assetlocation.xi2assetlocation
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate - NON CI SONO CAMPI DA CANCELLARE

-- Passo 5. Creazione del nuovo campo (che avr� nome come il vecchio ma con tipo diverso) - NON SERVE

-- Tabelle interessate -

-- Passo 6. Valorizzazione nuovo campo - Gia fatto a priori

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetlocation' and C.name = 'idassetlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetlocation] ALTER COLUMN idassetlocation int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetlocation') and constid=object_id('xpkassetlocation'))
BEGIN
	ALTER TABLE [assetlocation] ADD CONSTRAINT xpkassetlocation PRIMARY KEY (idasset, idassetlocation)
END
GO


-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1assetlocation' and id=object_id('assetlocation'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetlocation ON assetlocation (idasset)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetlocation
	ON assetlocation (idasset)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetlocation' and id=object_id('assetlocation'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetlocation ON assetlocation (idlocation)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetlocation
	ON assetlocation (idlocation)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetlocation' AND field = 'idassetlocation')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-30 16:31:14.547'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-30 16:31:14.547'} WHERE tablename = 'assetlocation' AND field = 'idassetlocation'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetlocation','idassetlocation','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-30 16:31:14.547'},'''NINO''','NINO',{ts '2007-10-30 16:31:14.547'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetlocation' AND field = 'start')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smalldatetime',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-30 16:31:14.547'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-30 16:31:14.547'} WHERE tablename = 'assetlocation' AND field = 'start'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetlocation','start','N','smalldatetime','4',null,null,'System.DateTime','smalldatetime','S','',null,'N',{ts '2007-10-30 16:31:14.547'},'''NINO''','NINO',{ts '2007-10-30 16:31:14.547'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle


