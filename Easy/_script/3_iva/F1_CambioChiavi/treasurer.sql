
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


-- Aggiornamento tabella TREASURER e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- payment, paymenttransmission, proceeds, proceedstransmission, treasurerstart

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO treasurer (idtreasurer, description, flagdefault, ct, cu, lt, lu)
SELECT DISTINCT idtreasurer, idtreasurer, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM payment e
WHERE NOT EXISTS(SELECT * FROM treasurer k WHERE k.idtreasurer = e.idtreasurer)
AND e.idtreasurer IS NOT NULL

INSERT INTO treasurer (idtreasurer, description, flagdefault, ct, cu, lt, lu)
SELECT DISTINCT idtreasurer, idtreasurer, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM paymenttransmission e
WHERE NOT EXISTS(SELECT * FROM treasurer k WHERE k.idtreasurer = e.idtreasurer)
AND e.idtreasurer IS NOT NULL

INSERT INTO treasurer (idtreasurer, description, flagdefault, ct, cu, lt, lu)
SELECT DISTINCT idtreasurer, idtreasurer, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM proceeds e
WHERE NOT EXISTS(SELECT * FROM treasurer k WHERE k.idtreasurer = e.idtreasurer)
AND e.idtreasurer IS NOT NULL

INSERT INTO treasurer (idtreasurer, description, flagdefault, ct, cu, lt, lu)
SELECT DISTINCT idtreasurer, idtreasurer, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM proceedstransmission e
WHERE NOT EXISTS(SELECT * FROM treasurer k WHERE k.idtreasurer = e.idtreasurer)
AND e.idtreasurer IS NOT NULL

INSERT INTO treasurer (idtreasurer, description, flagdefault, ct, cu, lt, lu)
SELECT DISTINCT idtreasurer, idtreasurer, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM treasurerstart e
WHERE NOT EXISTS(SELECT * FROM treasurer k WHERE k.idtreasurer = e.idtreasurer)

-- Passo 0.bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_proceeds]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_proceeds]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [treasurer] ADD idtreasurerint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'codetreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [treasurer] ADD codetreasurer varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [treasurer] ALTER COLUMN codetreasurer varchar(20) NULL
END
GO
-- payment, paymenttransmission, proceeds, proceedstransmission, treasurerstart
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD idtreasurerint int NULL
END
ELSE
BEGIN
	ALTER TABLE [payment] ALTER COLUMN idtreasurerint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [paymenttransmission] ADD idtreasurerint int NULL
END
ELSE
BEGIN
	ALTER TABLE [paymenttransmission] ALTER COLUMN idtreasurerint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ADD idtreasurerint int NULL
END
ELSE
BEGIN
	ALTER TABLE [proceeds] ALTER COLUMN idtreasurerint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedstransmission] ADD idtreasurerint int NULL
END
ELSE
BEGIN
	ALTER TABLE [proceedstransmission] ALTER COLUMN idtreasurerint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurerstart' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [treasurerstart] ADD idtreasurerint int NULL
END
ELSE
BEGIN
	ALTER TABLE [treasurerstart] ALTER COLUMN idtreasurerint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'codetreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE treasurer SET codetreasurer = idtreasurer
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET idtreasurerint = treasurer.idtreasurerint
	FROM treasurer
	WHERE treasurer.idtreasurer = payment.idtreasurer
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE paymenttransmission SET idtreasurerint = treasurer.idtreasurerint
	FROM treasurer
	WHERE treasurer.idtreasurer = paymenttransmission.idtreasurer
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceeds SET idtreasurerint = treasurer.idtreasurerint
	FROM treasurer
	WHERE treasurer.idtreasurer = proceeds.idtreasurer
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceedstransmission SET idtreasurerint = treasurer.idtreasurerint
	FROM treasurer
	WHERE treasurer.idtreasurer = proceedstransmission.idtreasurer
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurerstart' and C.name = 'idtreasurerint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE treasurerstart SET idtreasurerint = treasurer.idtreasurerint
	FROM treasurer
	WHERE treasurer.idtreasurer = treasurerstart.idtreasurer
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono ivakind
IF exists(SELECT * FROM sysconstraints where id=object_id('treasurer') and constid=object_id('xpktreasurer'))
BEGIN
	ALTER TABLE [treasurer] drop constraint xpktreasurer
END

IF exists(SELECT * FROM sysconstraints where id=object_id('treasurer') and constid=object_id('PK_treasurer'))
BEGIN
	ALTER TABLE [treasurer] drop constraint PK_treasurer
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('treasurerstart') and constid=object_id('xpktreasurerstart'))
BEGIN
	ALTER TABLE [treasurerstart] drop constraint xpktreasurerstart
END

IF exists(SELECT * FROM sysconstraints where id=object_id('treasurerstart') and constid=object_id('PK_treasurerstart'))
BEGIN
	ALTER TABLE [treasurerstart] drop constraint PK_treasurerstart
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono payment, paymenttransmission, proceeds, proceedstransmission
IF EXISTS (SELECT * FROM sysindexes where name='xi2payment' and id=object_id('payment'))
	drop index payment.xi2payment
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2paymenttransmission' and id=object_id('paymenttransmission'))
	drop index paymenttransmission.xi2paymenttransmission
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2proceeds' and id=object_id('proceeds'))
	drop index proceeds.xi2proceeds
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2proceedstransmission' and id=object_id('proceedstransmission'))
	drop index proceedstransmission.xi2proceedstransmission
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1treasurerstart' and id=object_id('treasurerstart'))
	drop index treasurerstart.xi1treasurerstart
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'treasurer'
		and C.name ='idtreasurer'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [treasurer] DROP COLUMN idtreasurer
	DELETE FROM columntypes WHERE tablename = 'treasurer' AND field = 'idtreasurer'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='idtreasurer'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN idtreasurer
	DELETE FROM columntypes WHERE tablename = 'payment' AND field = 'idtreasurer'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'paymenttransmission'
		and C.name ='idtreasurer'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [paymenttransmission] DROP COLUMN idtreasurer
	DELETE FROM columntypes WHERE tablename = 'paymenttransmission' AND field = 'idtreasurer'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='idtreasurer'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN idtreasurer
	DELETE FROM columntypes WHERE tablename = 'proceeds' AND field = 'idtreasurer'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceedstransmission'
		and C.name ='idtreasurer'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceedstransmission] DROP COLUMN idtreasurer
	DELETE FROM columntypes WHERE tablename = 'proceedstransmission' AND field = 'idtreasurer'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'treasurerstart'
		and C.name ='idtreasurer'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [treasurerstart] DROP COLUMN idtreasurer
	DELETE FROM columntypes WHERE tablename = 'treasurerstart' AND field = 'idtreasurer'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [treasurer] ADD idtreasurer int NULL 
END
ELSE
	ALTER TABLE [treasurer] ALTER COLUMN idtreasurer int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD idtreasurer int NULL 
END
ELSE
	ALTER TABLE [payment] ALTER COLUMN idtreasurer int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [paymenttransmission] ADD idtreasurer int NULL 
END
ELSE
	ALTER TABLE [paymenttransmission] ALTER COLUMN idtreasurer int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ADD idtreasurer int NULL 
END
ELSE
	ALTER TABLE [proceeds] ALTER COLUMN idtreasurer int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedstransmission] ADD idtreasurer int NULL 
END
ELSE
	ALTER TABLE [proceedstransmission] ALTER COLUMN idtreasurer int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurerstart' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [treasurerstart] ADD idtreasurer int NULL 
END
ELSE
	ALTER TABLE [treasurerstart] ALTER COLUMN idtreasurer int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE treasurer SET idtreasurer = idtreasurerint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET idtreasurer = idtreasurerint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE paymenttransmission SET idtreasurer = idtreasurerint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceeds SET idtreasurer = idtreasurerint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceedstransmission SET idtreasurer = idtreasurerint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE treasurerstart SET idtreasurer = idtreasurerint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [treasurer] ALTER COLUMN idtreasurer int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurerstart' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [treasurerstart] ALTER COLUMN idtreasurer int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'treasurer' and C.name = 'codetreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [treasurer] ALTER COLUMN codetreasurer varchar(20) NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('treasurer') and constid=object_id('xpktreasurer'))
BEGIN
	ALTER TABLE [treasurer] ADD CONSTRAINT xpktreasurer PRIMARY KEY (idtreasurer)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('treasurer') and constid=object_id('uktreasurer'))
BEGIN
	ALTER TABLE [treasurer] ADD CONSTRAINT uktreasurer UNIQUE (codetreasurer)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('treasurerstart') and constid=object_id('xpktreasurerstart'))
BEGIN
	ALTER TABLE [treasurerstart] ADD CONSTRAINT xpktreasurerstart PRIMARY KEY (idtreasurer, ayear)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2treasurer' and id=object_id('treasurer'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2treasurer ON treasurer (codetreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2treasurer
	ON treasurer (codetreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2payment' and id=object_id('payment'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2payment ON payment (idtreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2payment
	ON payment (idtreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2paymenttransmission' and id=object_id('paymenttransmission'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2paymenttransmission ON paymenttransmission (idtreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2paymenttransmission
	ON paymenttransmission (idtreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2proceeds' and id=object_id('proceeds'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2proceeds ON proceeds (idtreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2proceeds
	ON proceeds (idtreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2proceedstransmission' and id=object_id('proceedstransmission'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2proceedstransmission ON proceedstransmission (idtreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2proceedstransmission
	ON proceedstransmission (idtreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1treasurerstart' and id=object_id('treasurerstart'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1treasurerstart ON treasurerstart (idtreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1treasurerstart
	ON treasurerstart (idtreasurer)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payment' AND field = 'idtreasurer')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 12:10:26.000'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 12:10:26.000'} WHERE tablename = 'payment' AND field = 'idtreasurer'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('payment','idtreasurer','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 12:10:26.000'},'''NINO''','NINO',{ts '2007-11-20 12:10:26.000'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'paymenttransmission' AND field = 'idtreasurer')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 12:10:26.217'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 12:10:26.217'} WHERE tablename = 'paymenttransmission' AND field = 'idtreasurer'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('paymenttransmission','idtreasurer','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 12:10:26.217'},'''NINO''','NINO',{ts '2007-11-20 12:10:26.217'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceeds' AND field = 'idtreasurer')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 12:10:29.077'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 12:10:29.077'} WHERE tablename = 'proceeds' AND field = 'idtreasurer'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('proceeds','idtreasurer','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 12:10:29.077'},'''NINO''','NINO',{ts '2007-11-20 12:10:29.077'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceedstransmission' AND field = 'idtreasurer')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 12:10:29.407'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 12:10:29.407'} WHERE tablename = 'proceedstransmission' AND field = 'idtreasurer'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('proceedstransmission','idtreasurer','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 12:10:29.407'},'''NINO''','NINO',{ts '2007-11-20 12:10:29.407'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'treasurer' AND field = 'codetreasurer')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 12:10:21.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 12:10:21.420'} WHERE tablename = 'treasurer' AND field = 'codetreasurer'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('treasurer','codetreasurer','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-20 12:10:21.420'},'''NINO''','NINO',{ts '2007-11-20 12:10:21.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'treasurer' AND field = 'idtreasurer')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 12:10:21.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 12:10:21.420'} WHERE tablename = 'treasurer' AND field = 'idtreasurer'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('treasurer','idtreasurer','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-20 12:10:21.420'},'''NINO''','NINO',{ts '2007-11-20 12:10:21.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'treasurerstart' AND field = 'idtreasurer')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 12:10:21.780'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 12:10:21.780'} WHERE tablename = 'treasurerstart' AND field = 'idtreasurer'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('treasurerstart','idtreasurer','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-20 12:10:21.780'},'''NINO''','NINO',{ts '2007-11-20 12:10:21.780'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'treasurer'
		and C.name ='idtreasurerint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [treasurer] DROP COLUMN idtreasurerint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='idtreasurerint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN idtreasurerint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'paymenttransmission'
		and C.name ='idtreasurerint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [paymenttransmission] DROP COLUMN idtreasurerint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='idtreasurerint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN idtreasurerint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceedstransmission'
		and C.name ='idtreasurerint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceedstransmission] DROP COLUMN idtreasurerint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'treasurerstart'
		and C.name ='idtreasurerint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [treasurerstart] DROP COLUMN idtreasurerint
END
GO
