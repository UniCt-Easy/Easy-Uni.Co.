-- Aggiornamento tabella PAYMENT e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- banktransaction, expenselast, payment_bank

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DELETE FROM banktransaction WHERE NOT EXISTS
	(SELECT * FROM payment k
	WHERE k.ypay = banktransaction.ypay
		AND k.npay = banktransaction.npay)
GO

DELETE FROM payment_bank WHERE NOT EXISTS
	(SELECT * FROM payment k
	WHERE k.ypay = payment_bank.ypay
		AND k.npay = payment_bank.npay)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento) e Passo 2. (aggiunta delle colonne nelle tabelle referenziate)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'kpayint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD kpayint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'kpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD kpay int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'kpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransaction] ADD kpay int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'kpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD kpay int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'kpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD kpay int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'kpayint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET kpay = kpayint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'kpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE banktransaction SET kpay = payment.kpay
	FROM payment
	WHERE banktransaction.ypay = payment.ypay AND banktransaction.npay = payment.npay
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'kpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment_bank SET kpay = payment.kpay
	FROM payment
	WHERE payment_bank.ypay = payment.ypay AND payment_bank.npay = payment.npay
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'kpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenselast SET kpay = payment.kpay
	FROM payment
	JOIN expense
		ON expense.ymov = payment.ypay
	WHERE expense.idexp = expenselast.idexp AND expenselast.npay = payment.npay
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono payment, payment_bank
IF exists(SELECT * FROM sysconstraints where id=object_id('payment') and constid=object_id('xpkpayment'))
BEGIN
	ALTER TABLE [payment] drop constraint xpkpayment
END

IF exists(SELECT * FROM sysconstraints where id=object_id('payment') and constid=object_id('PK_payment'))
BEGIN
	ALTER TABLE [payment] drop constraint PK_payment
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('payment_bank') and constid=object_id('xpkpayment_bank'))
BEGIN
	ALTER TABLE [payment_bank] drop constraint xpkpayment_bank
END

IF exists(SELECT * FROM sysconstraints where id=object_id('payment_bank') and constid=object_id('PK_payment_bank'))
BEGIN
	ALTER TABLE [payment_bank] drop constraint PK_payment_bank
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono payment, expenselast, itinerationtax
IF EXISTS (SELECT * FROM sysindexes where name='xi2banktransaction' and id=object_id('banktransaction'))
	drop index banktransaction.xi2banktransaction
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenselast' and id=object_id('expenselast'))
	drop index expenselast.xi1expenselast
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6expenselast' and id=object_id('expenselast'))
	drop index expenselast.xi6expenselast
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransaction'
		and C.name ='ypay'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransaction] DROP COLUMN ypay
	DELETE FROM columntypes WHERE tablename = 'banktransaction' AND field = 'ypay'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransaction'
		and C.name ='npay'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransaction] DROP COLUMN npay
	DELETE FROM columntypes WHERE tablename = 'banktransaction' AND field = 'npay'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment_bank'
		and C.name ='ypay'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment_bank] DROP COLUMN ypay
	DELETE FROM columntypes WHERE tablename = 'payment_bank' AND field = 'ypay'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment_bank'
		and C.name ='npay'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment_bank] DROP COLUMN npay
	DELETE FROM columntypes WHERE tablename = 'payment_bank' AND field = 'npay'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenselast'
		and C.name ='npay'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenselast] DROP COLUMN npay
	DELETE FROM columntypes WHERE tablename = 'expenselast' AND field = 'npay'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso) - NON SERVE
-- Tabelle interessate -

-- Passo 6. Valorizzazione nuovo campo - Gia fatto a priori

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'kpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ALTER COLUMN kpay int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'kpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ALTER COLUMN kpay int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('payment') and constid=object_id('xpkpayment'))
BEGIN
	ALTER TABLE [payment] ADD CONSTRAINT xpkpayment PRIMARY KEY (kpay)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('payment') and constid=object_id('ukpayment'))
BEGIN
	ALTER TABLE [payment] ADD CONSTRAINT ukpayment UNIQUE (ypay, npay)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('payment_bank') and constid=object_id('xpkpayment_bank'))
BEGIN
	ALTER TABLE [payment_bank] ADD CONSTRAINT xpkpayment_bank PRIMARY KEY (kpay, idpay)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi7payment' and id=object_id('payment'))
BEGIN
	CREATE NONCLUSTERED INDEX xi7payment ON payment (ypay, npay)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi7payment
	ON payment (ypay, npay)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2banktransaction' and id=object_id('banktransaction'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2banktransaction ON banktransaction (kpay)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2banktransaction
	ON banktransaction (kpay)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1payment_bank' and id=object_id('payment_bank'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1payment_bank ON payment_bank (kpay)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1payment_bank
	ON payment_bank (kpay)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenselast' and id=object_id('expenselast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenselast ON expenselast (kpay, idpay)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenselast
	ON expenselast (kpay, idpay)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi6expenselast' and id=object_id('expenselast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi6expenselast ON expenselast (kpay)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi6expenselast
	ON expenselast (kpay)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'banktransaction' AND field = 'kpay')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-03 12:44:23.590'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:44:23.590'} WHERE tablename = 'banktransaction' AND field = 'kpay'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('banktransaction','kpay','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-12-03 12:44:23.590'},'''NINO''','NINO',{ts '2007-12-03 12:44:23.590'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenselast' AND field = 'kpay')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-03 12:44:33.183'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:44:33.183'} WHERE tablename = 'expenselast' AND field = 'kpay'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expenselast','kpay','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-12-03 12:44:33.183'},'''NINO''','NINO',{ts '2007-12-03 12:44:33.183'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payment' AND field = 'kpay')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 12:44:32.357'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:44:32.357'} WHERE tablename = 'payment' AND field = 'kpay'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('payment','kpay','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 12:44:32.357'},'''NINO''','NINO',{ts '2007-12-03 12:44:32.357'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payment' AND field = 'npay')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 12:44:32.323'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:44:32.323'} WHERE tablename = 'payment' AND field = 'npay'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('payment','npay','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 12:44:32.323'},'''NINO''','NINO',{ts '2007-12-03 12:44:32.323'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payment' AND field = 'ypay')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 12:44:32.340'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:44:32.340'} WHERE tablename = 'payment' AND field = 'ypay'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('payment','ypay','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 12:44:32.340'},'''NINO''','NINO',{ts '2007-12-03 12:44:32.340'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payment_bank' AND field = 'kpay')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 12:44:24.277'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:44:24.277'} WHERE tablename = 'payment_bank' AND field = 'kpay'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('payment_bank','kpay','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 12:44:24.277'},'''NINO''','NINO',{ts '2007-12-03 12:44:24.277'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='kpayint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN kpayint
END
GO

