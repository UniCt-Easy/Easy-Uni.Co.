
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


-- Aggiornamento tabella CLAWBACK e tabelle dipendenti
-- Passo 0. Inserimento delle righe in CLAWBACK ove non eissta una riga nella tabella ma ci siano righe in CLAWBACKSETUP e EXPENSECLAWBACK
INSERT INTO clawback
(
	idclawback,
	description,
	ct, cu, lt, lu
)
SELECT DISTINCT idclawback, idclawback, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM clawbacksetup
WHERE NOT EXISTS(SELECT idclawback FROM clawback WHERE clawback.idclawback = clawbacksetup.idclawback)

INSERT INTO clawback
(
	idclawback,
	description,
	ct, cu, lt, lu
)
SELECT DISTINCT idclawback, idclawback, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM expenseclawback
WHERE NOT EXISTS(SELECT idclawback FROM clawback WHERE clawback.idclawback = expenseclawback.idclawback)
GO

DELETE FROM clawbacksorting WHERE NOT EXISTS(SELECT * FROM clawback WHERE clawback.idclawback = clawbacksorting.idclawback)
GO
-- Le tabelle dipendenti sono:
-- admpay_clawback, clawbacksetup, clawbacksorting, expense, expenseclawback, itinerationsetup

-- Passo 0bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expense]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expense]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawback' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawback] ADD idclawbackint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawback' and C.name = 'clawbackref' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawback] ADD clawbackref varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [clawback] ALTER COLUMN clawbackref varchar(20) NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_clawback' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_clawback] ADD idclawbackint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_clawback] ALTER COLUMN idclawbackint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksetup' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksetup] ADD idclawbackint int NULL
END
ELSE
BEGIN
	ALTER TABLE [clawbacksetup] ALTER COLUMN idclawbackint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksorting] ADD idclawbackint int NULL
END
ELSE
BEGIN
	ALTER TABLE [clawbacksorting] ALTER COLUMN idclawbackint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idclawbackint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expense] ALTER COLUMN idclawbackint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseclawback' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseclawback] ADD idclawbackint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseclawback] ALTER COLUMN idclawbackint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsetup' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsetup] ADD idclawbackint int NULL
END
ELSE
BEGIN
	ALTER TABLE [itinerationsetup] ALTER COLUMN idclawbackint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawback' and C.name = 'clawbackref' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawback SET clawbackref = idclawback
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_clawback' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_clawback SET idclawbackint = clawback.idclawbackint
	FROM clawback
	WHERE admpay_clawback.idclawback = clawback.idclawback
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksetup' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawbacksetup SET idclawbackint = clawback.idclawbackint
	FROM clawback
	WHERE clawbacksetup.idclawback = clawback.idclawback
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawbacksorting SET idclawbackint = clawback.idclawbackint
	FROM clawback
	WHERE clawbacksorting.idclawback = clawback.idclawback
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET idclawbackint = clawback.idclawbackint
	FROM clawback
	WHERE expense.idclawback = clawback.idclawback
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseclawback' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseclawback SET idclawbackint = clawback.idclawbackint
	FROM clawback
	WHERE expenseclawback.idclawback = clawback.idclawback
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsetup' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationsetup SET idclawbackint = clawback.idclawbackint
	FROM clawback
	WHERE itinerationsetup.idclawback = clawback.idclawback
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono clawback, admpay_clawback, clawbacksetup, clawbacksorting, expenseclawback
IF exists(SELECT * FROM sysconstraints where id=object_id('clawback') and constid=object_id('xpkclawback'))
BEGIN
	ALTER TABLE [clawback] drop constraint xpkclawback
END

IF exists(SELECT * FROM sysconstraints where id=object_id('clawback') and constid=object_id('PK_clawback'))
BEGIN
	ALTER TABLE [clawback] drop constraint PK_clawback
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('admpay_clawback') and constid=object_id('xpkadmpay_clawback'))
BEGIN
	ALTER TABLE [admpay_clawback] drop constraint xpkadmpay_clawback
END

IF exists(SELECT * FROM sysconstraints where id=object_id('admpay_clawback') and constid=object_id('PK_admpay_clawback'))
BEGIN
	ALTER TABLE [admpay_clawback] drop constraint PK_admpay_clawback
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('clawbacksetup') and constid=object_id('xpkclawbacksetup'))
BEGIN
	ALTER TABLE [clawbacksetup] drop constraint xpkclawbacksetup
END

IF exists(SELECT * FROM sysconstraints where id=object_id('clawbacksetup') and constid=object_id('PK_clawbacksetup'))
BEGIN
	ALTER TABLE [clawbacksetup] drop constraint PK_clawbacksetup
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('clawbacksorting') and constid=object_id('xpkclawbacksorting'))
BEGIN
	ALTER TABLE [clawbacksorting] drop constraint xpkclawbacksorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('clawbacksorting') and constid=object_id('PK_clawbacksorting'))
BEGIN
	ALTER TABLE [clawbacksorting] drop constraint PK_clawbacksorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseclawback') and constid=object_id('xpkexpenseclawback'))
BEGIN
	ALTER TABLE [expenseclawback] drop constraint xpkexpenseclawback
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseclawback') and constid=object_id('PK_expenseclawback'))
BEGIN
	ALTER TABLE [expenseclawback] drop constraint PK_expenseclawback
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono clawbacksetup, expenseclawback
IF EXISTS (SELECT * FROM sysindexes where name='xi1clawbacksetup' and id=object_id('clawbacksetup'))
	drop index clawbacksetup.xi1clawbacksetup

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseclawback' and id=object_id('expenseclawback'))
	drop index expenseclawback.xi2expenseclawback

IF EXISTS (SELECT * FROM sysindexes where name='xi2itinerationsetup' and id=object_id('itinerationsetup'))
	drop index itinerationsetup.xi2itinerationsetup
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawback'
		and C.name ='idclawback'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawback] DROP COLUMN idclawback
	DELETE FROM columntypes WHERE tablename = 'clawback' AND field = 'idclawback'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_clawback'
		and C.name ='idclawback'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_clawback] DROP COLUMN idclawback
	DELETE FROM columntypes WHERE tablename = 'admpay_clawback' AND field = 'idclawback'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawbacksetup'
		and C.name ='idclawback'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawbacksetup] DROP COLUMN idclawback
	DELETE FROM columntypes WHERE tablename = 'clawbacksetup' AND field = 'idclawback'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawbacksorting'
		and C.name ='idclawback'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawbacksorting] DROP COLUMN idclawback
	DELETE FROM columntypes WHERE tablename = 'clawbacksorting' AND field = 'idclawback'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idclawback'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idclawback
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idclawback'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseclawback'
		and C.name ='idclawback'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseclawback] DROP COLUMN idclawback
	DELETE FROM columntypes WHERE tablename = 'expenseclawback' AND field = 'idclawback'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationsetup'
		and C.name ='idclawback'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationsetup] DROP COLUMN idclawback
	DELETE FROM columntypes WHERE tablename = 'itinerationsetup' AND field = 'idclawback'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate clawback e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawback' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawback] ADD idclawback int NULL 
END
ELSE
	ALTER TABLE [clawback] ALTER COLUMN idclawback int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_clawback' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_clawback] ADD idclawback int NULL 
END
ELSE
	ALTER TABLE [admpay_clawback] ALTER COLUMN idclawback int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksetup' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksetup] ADD idclawback int NULL 
END
ELSE
	ALTER TABLE [clawbacksetup] ALTER COLUMN idclawback int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksorting] ADD idclawback int NULL 
END
ELSE
	ALTER TABLE [clawbacksorting] ALTER COLUMN idclawback int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idclawback int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idclawback int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseclawback' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseclawback] ADD idclawback int NULL 
END
ELSE
	ALTER TABLE [expenseclawback] ALTER COLUMN idclawback int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsetup' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsetup] ADD idclawback int NULL 
END
ELSE
	ALTER TABLE [itinerationsetup] ALTER COLUMN idclawback int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawback' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawback SET idclawback = idclawbackint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_clawback' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_clawback SET idclawback = idclawbackint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksetup' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawbacksetup SET idclawback = idclawbackint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawbacksorting SET idclawback = idclawbackint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET idclawback = idclawbackint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseclawback' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseclawback SET idclawback = idclawbackint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsetup' and C.name = 'idclawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationsetup SET idclawback = idclawbackint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawback' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawback] ALTER COLUMN idclawback int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_clawback' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_clawback] ALTER COLUMN idclawback int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksetup' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksetup] ALTER COLUMN idclawback int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksorting] ALTER COLUMN idclawback int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseclawback' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseclawback] ALTER COLUMN idclawback int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CE NE SONO)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('clawback') and constid=object_id('xpkclawback'))
BEGIN
	ALTER TABLE [clawback] ADD CONSTRAINT xpkclawback PRIMARY KEY (idclawback)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('clawback') and constid=object_id('ukclawback'))
BEGIN
	ALTER TABLE [clawback] ADD CONSTRAINT ukclawback UNIQUE (clawbackref)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('admpay_clawback') and constid=object_id('xpkadmpay_clawback'))
BEGIN
	ALTER TABLE [admpay_clawback] ADD CONSTRAINT xpkadmpay_clawback PRIMARY KEY (yadmpay, nadmpay, nexpense, idclawback)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('clawbacksetup') and constid=object_id('xpkclawbacksetup'))
BEGIN
	ALTER TABLE [clawbacksetup] ADD CONSTRAINT xpkclawbacksetup PRIMARY KEY (idclawback, ayear)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('clawbacksorting') and constid=object_id('xpkclawbacksorting'))
BEGIN
	ALTER TABLE [clawbacksorting] ADD CONSTRAINT xpkclawbacksorting PRIMARY KEY (idclawback, idsorkind, idsor)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expenseclawback') and constid=object_id('xpkexpenseclawback'))
BEGIN
	ALTER TABLE [expenseclawback] ADD CONSTRAINT xpkexpenseclawback PRIMARY KEY (idexp, idclawback)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1clawbacksetup' and id=object_id('clawbacksetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1clawbacksetup ON clawbacksetup (idclawback)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1clawbacksetup
	ON clawbacksetup (idclawback)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseclawback' and id=object_id('expenseclawback'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenseclawback ON expenseclawback (idclawback)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenseclawback
	ON expenseclawback (idclawback)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2itinerationsetup' and id=object_id('itinerationsetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2itinerationsetup ON itinerationsetup (idclawback)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2itinerationsetup
	ON itinerationsetup (idclawback)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_clawback' AND field = 'idclawback')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:09.920'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:09.920'} WHERE tablename = 'admpay_clawback' AND field = 'idclawback'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('admpay_clawback','idclawback','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:09.920'},'''NINO''','NINO',{ts '2006-10-12 10:22:09.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'clawback' AND field = 'idclawback')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:03.827'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-12 10:22:09.920'} WHERE tablename = 'clawback' AND field = 'idclawback'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('clawback','idclawback','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:03.827'},'''NINO''','SA',{ts '2006-10-12 10:22:09.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'clawback' AND field = 'clawbackref')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = '',col_scale = '',systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:03.827'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-12 10:22:09.920'} WHERE tablename = 'clawback' AND field = 'clawbackref'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('clawback','clawbackref','N','varchar','20','','','System.String','varchar(20)','N','','','S',{ts '2006-10-12 10:22:03.827'},'''NINO''','SA',{ts '2006-10-12 10:22:09.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'clawbacksetup' AND field = 'idclawback')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:55.360'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:09.920'} WHERE tablename = 'clawbacksetup' AND field = 'idclawback'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('clawbacksetup','idclawback','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:55.360'},'''NINO''','NINO',{ts '2006-10-12 10:22:09.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'clawbacksorting' AND field = 'idclawback')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-01-17 11:15:11.267'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-10-12 10:22:09.920'} WHERE tablename = 'clawbacksorting' AND field = 'idclawback'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('clawbacksorting','idclawback','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-01-17 11:15:11.267'},'''SARA''','SA',{ts '2006-10-12 10:22:09.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expense' AND field = 'idclawback')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-05-12 11:53:33.327'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:09.920'} WHERE tablename = 'expense' AND field = 'idclawback'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expense','idclawback','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-05-12 11:53:33.327'},'''SA''','NINO',{ts '2006-10-12 10:22:09.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseclawback' AND field = 'idclawback')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:07.797'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-12 10:22:09.920'} WHERE tablename = 'expenseclawback' AND field = 'idclawback'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expenseclawback','idclawback','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:07.797'},'''NINO''','SA',{ts '2006-10-12 10:22:09.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationsetup' AND field = 'idclawback')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-05-12 11:53:30.890'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:09.920'} WHERE tablename = 'itinerationsetup' AND field = 'idclawback'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('itinerationsetup','idclawback','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-05-12 11:53:30.890'},'''SA''','NINO',{ts '2006-10-12 10:22:09.920'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawback'
		and C.name ='idclawbackint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawback] DROP COLUMN idclawbackint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_clawback'
		and C.name ='idclawbackint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_clawback] DROP COLUMN idclawbackint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawbacksetup'
		and C.name ='idclawbackint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawbacksetup] DROP COLUMN idclawbackint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawbacksorting'
		and C.name ='idclawbackint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawbacksorting] DROP COLUMN idclawbackint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idclawbackint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idclawbackint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseclawback'
		and C.name ='idclawbackint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseclawback] DROP COLUMN idclawbackint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationsetup'
		and C.name ='idclawbackint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationsetup] DROP COLUMN idclawbackint
END
GO
