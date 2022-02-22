
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


-- Aggiornamento tabella CURRENCY e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- estimate, invoice, itinerationrefund, mandate, registrypaymethod

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO currency (idcurrency, description, ct, cu, lt, lu)
SELECT DISTINCT idcurrency, idcurrency, GETDATE(), 'SA', GETDATE(), 'SA'
FROM estimate e
WHERE NOT EXISTS(SELECT * FROM currency k WHERE k.idcurrency = e.idcurrency)
AND idcurrency IS NOT NULL
GO

INSERT INTO currency (idcurrency, description, ct, cu, lt, lu)
SELECT DISTINCT idcurrency, idcurrency, GETDATE(), 'SA', GETDATE(), 'SA'
FROM invoice e
WHERE NOT EXISTS(SELECT * FROM currency k WHERE k.idcurrency = e.idcurrency)
AND idcurrency IS NOT NULL
GO

INSERT INTO currency (idcurrency, description, ct, cu, lt, lu)
SELECT DISTINCT idcurrency, idcurrency, GETDATE(), 'SA', GETDATE(), 'SA'
FROM itinerationrefund e
WHERE NOT EXISTS(SELECT * FROM currency k WHERE k.idcurrency = e.idcurrency)
AND idcurrency IS NOT NULL
GO

INSERT INTO currency (idcurrency, description, ct, cu, lt, lu)
SELECT DISTINCT idcurrency, idcurrency, GETDATE(), 'SA', GETDATE(), 'SA'
FROM mandate e
WHERE NOT EXISTS(SELECT * FROM currency k WHERE k.idcurrency = e.idcurrency)
AND idcurrency IS NOT NULL
GO

INSERT INTO currency (idcurrency, description, ct, cu, lt, lu)
SELECT DISTINCT idcurrency, idcurrency, GETDATE(), 'SA', GETDATE(), 'SA'
FROM registrypaymethod e
WHERE NOT EXISTS(SELECT * FROM currency k WHERE k.idcurrency = e.idcurrency)
AND idcurrency IS NOT NULL
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ADD idcurrencyint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'codecurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ADD codecurrency varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [currency] ALTER COLUMN codecurrency varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimate] ADD idcurrencyint int NULL
END
ELSE
BEGIN
	ALTER TABLE [estimate] ALTER COLUMN idcurrencyint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoice] ADD idcurrencyint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoice] ALTER COLUMN idcurrencyint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefund] ADD idcurrencyint int NULL
END
ELSE
BEGIN
	ALTER TABLE [itinerationrefund] ALTER COLUMN idcurrencyint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandate] ADD idcurrencyint int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandate] ALTER COLUMN idcurrencyint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrypaymethod] ADD idcurrencyint int NULL
END
ELSE
BEGIN
	ALTER TABLE [registrypaymethod] ALTER COLUMN idcurrencyint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'codecurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE currency SET codecurrency = idcurrency
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimate SET idcurrencyint = currency.idcurrencyint
	FROM currency
	WHERE currency.idcurrency = estimate.idcurrency
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoice SET idcurrencyint = currency.idcurrencyint
	FROM currency
	WHERE currency.idcurrency = invoice.idcurrency
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationrefund SET idcurrencyint = currency.idcurrencyint
	FROM currency
	WHERE currency.idcurrency = itinerationrefund.idcurrency
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandate SET idcurrencyint = currency.idcurrencyint
	FROM currency
	WHERE currency.idcurrency = mandate.idcurrency
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idcurrencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrypaymethod SET idcurrencyint = currency.idcurrencyint
	FROM currency
	WHERE currency.idcurrency = registrypaymethod.idcurrency
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono currency
IF exists(SELECT * FROM sysconstraints where id=object_id('currency') and constid=object_id('xpkcurrency'))
BEGIN
	ALTER TABLE [currency] drop constraint xpkcurrency
END

IF exists(SELECT * FROM sysconstraints where id=object_id('currency') and constid=object_id('PK_currency'))
BEGIN
	ALTER TABLE [currency] drop constraint PK_currency
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono invoice, itinerationrefund, mandate
IF EXISTS (SELECT * FROM sysindexes where name='xi7invoice' and id=object_id('invoice'))
	drop index invoice.xi7invoice
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3itinerationrefund' and id=object_id('itinerationrefund'))
	drop index itinerationrefund.xi3itinerationrefund
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3mandate' and id=object_id('mandate'))
	drop index mandate.xi3mandate
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'currency'
		and C.name ='idcurrency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [currency] DROP COLUMN idcurrency
	DELETE FROM columntypes WHERE tablename = 'currency' AND field = 'idcurrency'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimate'
		and C.name ='idcurrency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimate] DROP COLUMN idcurrency
	DELETE FROM columntypes WHERE tablename = 'estimate' AND field = 'idcurrency'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoice'
		and C.name ='idcurrency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoice] DROP COLUMN idcurrency
	DELETE FROM columntypes WHERE tablename = 'invoice' AND field = 'idcurrency'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationrefund'
		and C.name ='idcurrency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationrefund] DROP COLUMN idcurrency
	DELETE FROM columntypes WHERE tablename = 'itinerationrefund' AND field = 'idcurrency'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandate'
		and C.name ='idcurrency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandate] DROP COLUMN idcurrency
	DELETE FROM columntypes WHERE tablename = 'mandate' AND field = 'idcurrency'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrypaymethod'
		and C.name ='idcurrency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrypaymethod] DROP COLUMN idcurrency
	DELETE FROM columntypes WHERE tablename = 'registrypaymethod' AND field = 'idcurrency'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate currency e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ADD idcurrency int NULL 
END
ELSE
	ALTER TABLE [currency] ALTER COLUMN idcurrency int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimate] ADD idcurrency int NULL 
END
ELSE
	ALTER TABLE [estimate] ALTER COLUMN idcurrency int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoice] ADD idcurrency int NULL 
END
ELSE
	ALTER TABLE [invoice] ALTER COLUMN idcurrency int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefund] ADD idcurrency int NULL 
END
ELSE
	ALTER TABLE [itinerationrefund] ALTER COLUMN idcurrency int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandate] ADD idcurrency int NULL 
END
ELSE
	ALTER TABLE [mandate] ALTER COLUMN idcurrency int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrypaymethod] ADD idcurrency int NULL 
END
ELSE
	ALTER TABLE [registrypaymethod] ALTER COLUMN idcurrency int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE currency SET idcurrency = idcurrencyint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimate SET idcurrency = idcurrencyint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoice SET idcurrency = idcurrencyint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationrefund SET idcurrency = idcurrencyint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandate SET idcurrency = idcurrencyint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrypaymethod' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrypaymethod SET idcurrency = idcurrencyint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ALTER COLUMN idcurrency int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('currency') and constid=object_id('xpkcurrency'))
BEGIN
	ALTER TABLE [currency] ADD CONSTRAINT xpkcurrency PRIMARY KEY (idcurrency)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('currency') and constid=object_id('ukivaregisterkind'))
BEGIN
	ALTER TABLE [currency] ADD CONSTRAINT ukcurrency UNIQUE (codecurrency)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1currency' and id=object_id('currency'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1currency ON currency (codecurrency)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1currency
	ON currency (codecurrency)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi3mandate' and id=object_id('mandate'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3mandate ON mandate (idcurrency)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3mandate
	ON mandate (idcurrency)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1estimate' and id=object_id('estimate'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1estimate ON estimate (idcurrency)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1estimate
	ON estimate (idcurrency)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi7invoice' and id=object_id('invoice'))
BEGIN
	CREATE NONCLUSTERED INDEX xi7invoice ON invoice (idcurrency)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi7invoice
	ON invoice (idcurrency)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi3itinerationrefund' and id=object_id('itinerationrefund'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3itinerationrefund ON itinerationrefund (idcurrency)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3itinerationrefund
	ON itinerationrefund (idcurrency)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'currency' AND field = 'codecurrency')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 09:40:41.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 09:40:41.530'} WHERE tablename = 'currency' AND field = 'codecurrency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('currency','codecurrency','N','varchar','20',null,null,'System.String','varchar(20)','S','',null,'N',{ts '2007-11-20 09:40:41.530'},'''NINO''','NINO',{ts '2007-11-20 09:40:41.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'currency' AND field = 'idcurrency')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 09:40:41.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 09:40:41.530'} WHERE tablename = 'currency' AND field = 'idcurrency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('currency','idcurrency','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-20 09:40:41.530'},'''NINO''','NINO',{ts '2007-11-20 09:40:41.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimate' AND field = 'idcurrency')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 09:40:40.860'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 09:40:40.860'} WHERE tablename = 'estimate' AND field = 'idcurrency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('estimate','idcurrency','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 09:40:40.860'},'''NINO''','NINO',{ts '2007-11-20 09:40:40.860'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoice' AND field = 'idcurrency')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 09:40:50.687'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 09:40:50.687'} WHERE tablename = 'invoice' AND field = 'idcurrency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoice','idcurrency','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 09:40:50.687'},'''NINO''','NINO',{ts '2007-11-20 09:40:50.687'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationrefund' AND field = 'idcurrency')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 09:40:38.203'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 09:40:38.203'} WHERE tablename = 'itinerationrefund' AND field = 'idcurrency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationrefund','idcurrency','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 09:40:38.203'},'''NINO''','NINO',{ts '2007-11-20 09:40:38.203'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandate' AND field = 'idcurrency')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 09:40:39.047'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 09:40:39.047'} WHERE tablename = 'mandate' AND field = 'idcurrency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('mandate','idcurrency','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 09:40:39.047'},'''NINO''','NINO',{ts '2007-11-20 09:40:39.047'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registrypaymethod' AND field = 'idcurrency')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 09:40:37.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 09:40:37.577'} WHERE tablename = 'registrypaymethod' AND field = 'idcurrency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registrypaymethod','idcurrency','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 09:40:37.577'},'''NINO''','NINO',{ts '2007-11-20 09:40:37.577'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'currency'
		and C.name ='idcurrencyint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [currency] DROP COLUMN idcurrencyint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimate'
		and C.name ='idcurrencyint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimate] DROP COLUMN idcurrencyint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoice'
		and C.name ='idcurrencyint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoice] DROP COLUMN idcurrencyint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationrefund'
		and C.name ='idcurrencyint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationrefund] DROP COLUMN idcurrencyint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandate'
		and C.name ='idcurrencyint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandate] DROP COLUMN idcurrencyint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrypaymethod'
		and C.name ='idcurrencyint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrypaymethod] DROP COLUMN idcurrencyint
END
GO
