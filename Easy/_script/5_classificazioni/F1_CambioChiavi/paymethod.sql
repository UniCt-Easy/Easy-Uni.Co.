-- Aggiornamento tabella paymethod e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- registrypaymethod
-- expenselast

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO paymethod (idpaymethod,active,allowdeputy,ct,cu,description,flagpaymentadvice,footerpaymentadvice,lt,lu,methodbankcode) 
SELECT DISTINCT idpaymethod,'N','N',getdate(),'SA',idpaymethod,'N',null,getdate(),'SA',null
FROM registrypaymethod e
WHERE NOT EXISTS(SELECT * FROM paymethod k WHERE k.idpaymethod = e.idpaymethod)
AND e.idpaymethod IS NOT NULL

INSERT INTO paymethod (idpaymethod,active,allowdeputy,ct,cu,description,flagpaymentadvice,footerpaymentadvice,lt,lu,methodbankcode) 
SELECT DISTINCT idpaymethod,'N','N',getdate(),'SA',idpaymethod,'N',null,getdate(),'SA',null
FROM expenselast e
WHERE NOT EXISTS(SELECT * FROM paymethod k WHERE k.idpaymethod = e.idpaymethod)
AND e.idpaymethod IS NOT NULL

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymethod' and C.name = 'idpaymethodint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [paymethod] ADD idpaymethodint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idpaymethodint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrypaymethod] ADD idpaymethodint int NULL
END
ELSE
BEGIN
	ALTER TABLE [registrypaymethod] ALTER COLUMN idpaymethodint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idpaymethodint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD idpaymethodint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expenselast] ALTER COLUMN idpaymethodint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idpaymethodint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrypaymethod SET idpaymethodint = paymethod.idpaymethodint
	FROM paymethod
	WHERE paymethod.idpaymethod = registrypaymethod.idpaymethod
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idpaymethodint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenselast SET idpaymethodint = paymethod.idpaymethodint
	FROM paymethod
	WHERE paymethod.idpaymethod = expenselast.idpaymethod
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono paymethod
IF exists(SELECT * FROM sysconstraints where id=object_id('paymethod') and constid=object_id('xpkpaymethod'))
BEGIN
	ALTER TABLE [paymethod] drop constraint xpkpaymethod
END
go

IF exists(SELECT * FROM sysconstraints where id=object_id('paymethod') and constid=object_id('PK_paymethod'))
BEGIN
	ALTER TABLE [paymethod] drop constraint PK_paymethod
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono registrypaymethod ed expenselast
IF EXISTS (SELECT * FROM sysindexes where name='xi2registrypaymethod' and id=object_id('registrypaymethod'))
	drop index registrypaymethod.xi2registrypaymethod
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7expenselast' and id=object_id('expenselast'))
	drop index expenselast.xi7expenselast
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'paymethod'
		and C.name ='idpaymethod'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [paymethod] DROP COLUMN idpaymethod
	DELETE FROM columntypes WHERE tablename = 'paymethod' AND field = 'idpaymethod'
END
go

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrypaymethod'
		and C.name ='idpaymethod'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrypaymethod] DROP COLUMN idpaymethod
	DELETE FROM columntypes WHERE tablename = 'registrypaymethod' AND field = 'idpaymethod'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenselast'
		and C.name ='idpaymethod'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenselast] DROP COLUMN idpaymethod
	DELETE FROM columntypes WHERE tablename = 'expenselast' AND field = 'idpaymethod'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymethod' and C.name = 'idpaymethod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [paymethod] ADD idpaymethod int NULL 
END
ELSE
	ALTER TABLE [paymethod] ALTER COLUMN idpaymethod int NULL
go

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idpaymethod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrypaymethod] ADD idpaymethod int NULL 
END
ELSE
	ALTER TABLE [registrypaymethod] ALTER COLUMN idpaymethod int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idpaymethod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD idpaymethod int NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN idpaymethod int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymethod' and C.name = 'idpaymethod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE paymethod SET idpaymethod = idpaymethodint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idpaymethod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrypaymethod SET idpaymethod = idpaymethodint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idpaymethod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenselast SET idpaymethod = idpaymethodint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymethod' and C.name = 'idpaymethod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [paymethod] ALTER COLUMN idpaymethod int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave NON CI SONO CAMPI NON CHIAVE

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('paymethod') and constid=object_id('xpkpaymethod'))
BEGIN
	ALTER TABLE [paymethod] ADD CONSTRAINT xpkpaymethod PRIMARY KEY (idpaymethod)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2registrypaymethod' and id=object_id('registrypaymethod'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2registrypaymethod ON registrypaymethod (idpaymethod)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2registrypaymethod
	ON registrypaymethod (idpaymethod)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7expenselast' and id=object_id('expenselast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi7expenselast ON expenselast (idpaymethod)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi7expenselast
	ON expenselast (idpaymethod)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registrypaymethod' AND field = 'idpaymethod')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 10:09:10.640'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 10:09:10.640'} WHERE tablename = 'registrypaymethod' AND field = 'idpaymethod'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registrypaymethod','idpaymethod','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 10:09:10.640'},'''NINO''','NINO',{ts '2007-11-20 10:09:10.640'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenselast' AND field = 'idpaymethod')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 10:09:10.640'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 10:09:10.640'} WHERE tablename = 'expenselast' AND field = 'idpaymethod'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expenselast','idpaymethod','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 10:09:10.640'},'''NINO''','NINO',{ts '2007-11-20 10:09:10.640'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'paymethod' AND field = 'idpaymethod')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 10:09:11.110'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 10:09:11.110'} WHERE tablename = 'paymethod' AND field = 'idpaymethod'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('paymethod','idpaymethod','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-20 10:09:11.110'},'''NINO''','NINO',{ts '2007-11-20 10:09:11.110'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'paymethod'
		and C.name ='idpaymethodint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [paymethod] DROP COLUMN idpaymethodint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrypaymethod'
		and C.name ='idpaymethodint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrypaymethod] DROP COLUMN idpaymethodint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenselast'
		and C.name ='idpaymethodint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenselast] DROP COLUMN idpaymethodint
END
GO
