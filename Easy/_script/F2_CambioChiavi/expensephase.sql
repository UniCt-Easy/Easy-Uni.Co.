/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿-- Aggiornamento tabella EXPENSEPHASE e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- expense, expenseyear, sortingkind, finsetup, upbexpensetotal, expensesetup

-- Passo 0.bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expense]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expense]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expenseyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expenseyear]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensephase' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensephase] ADD nphaseint tinyint NULL
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD nphaseint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [expense] ALTER COLUMN nphaseint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseyear] ADD nphaseint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseyear] ALTER COLUMN nphaseint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'nphaseexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingkind] ADD nphaseexpenseint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingkind] ALTER COLUMN nphaseexpenseint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsetup' and C.name = 'appropriationphasecodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsetup] ADD appropriationphasecodeint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [finsetup] ALTER COLUMN appropriationphasecodeint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbexpensetotal' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbexpensetotal] ADD nphaseint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [upbexpensetotal] ALTER COLUMN nphaseint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesetup' and C.name = 'expensephaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesetup] ADD expensephaseint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [expensesetup] ALTER COLUMN expensephaseint tinyint NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensephase' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensephase SET nphaseint = CONVERT(tinyint, nphase)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET nphaseint = CONVERT(tinyint, nphase)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseyear SET nphaseint = CONVERT(tinyint, nphase)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'nphaseexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingkind SET nphaseexpenseint = CONVERT(tinyint, nphaseexpense)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsetup' and C.name = 'appropriationphasecodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finsetup SET appropriationphasecodeint = CONVERT(tinyint, appropriationphasecode)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbexpensetotal' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbexpensetotal SET nphaseint = CONVERT(tinyint, nphase)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesetup' and C.name = 'expensephaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesetup SET expensephaseint = CONVERT(tinyint, expensephase)
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono finlevel
IF exists(SELECT * FROM sysconstraints where id=object_id('expensephase') and constid=object_id('xpkexpensephase'))
BEGIN
	ALTER TABLE [expensephase] drop constraint xpkexpensephase
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expensephase') and constid=object_id('PK_expensephase'))
BEGIN
	ALTER TABLE [expensephase] drop constraint PK_expensephase
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expense') and constid=object_id('UQ_1_expense'))
BEGIN
	ALTER TABLE [expense] drop constraint UQ_1_expense
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('upbexpensetotal') and constid=object_id('xpkupbexpensetotal'))
BEGIN
	ALTER TABLE [upbexpensetotal] drop constraint xpkupbexpensetotal
END

IF exists(SELECT * FROM sysconstraints where id=object_id('upbexpensetotal') and constid=object_id('PK_upbexpensetotal'))
BEGIN
	ALTER TABLE [upbexpensetotal] drop constraint PK_upbexpensetotal
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1expense' and id=object_id('expense'))
	drop index expense.xi1expense
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_expense' and id=object_id('expense'))
	drop index expense.UQ_1_expense
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5expenseyear' and id=object_id('expenseyear'))
	drop index expenseyear.xi5expenseyear
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2sortingkind' and id=object_id('sortingkind'))
	drop index sortingkind.xi2sortingkind
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensesetup' and id=object_id('expensesetup'))
	drop index expensesetup.xi1expensesetup
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensephase'
		and C.name ='nphase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensephase] DROP COLUMN nphase
	DELETE FROM columntypes WHERE tablename = 'expensephase' AND field = 'nphase'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='nphase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN nphase
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'nphase'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseyear'
		and C.name ='nphase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseyear] DROP COLUMN nphase
	DELETE FROM columntypes WHERE tablename = 'expenseyear' AND field = 'nphase'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingkind'
		and C.name ='nphaseexpense'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingkind] DROP COLUMN nphaseexpense
	DELETE FROM columntypes WHERE tablename = 'sortingkind' AND field = 'nphaseexpense'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finsetup'
		and C.name ='appropriationphasecode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finsetup] DROP COLUMN appropriationphasecode
	DELETE FROM columntypes WHERE tablename = 'finsetup' AND field = 'appropriationphasecode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbexpensetotal'
		and C.name ='nphase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbexpensetotal] DROP COLUMN nphase
	DELETE FROM columntypes WHERE tablename = 'upbexpensetotal' AND field = 'nphase'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesetup'
		and C.name ='expensephase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesetup] DROP COLUMN expensephase
	DELETE FROM columntypes WHERE tablename = 'expensesetup' AND field = 'expensephase'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensephase' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensephase] ADD nphase tinyint NULL
END
ELSE
	ALTER TABLE [expensephase] ALTER COLUMN nphase tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD nphase tinyint NULL
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN nphase tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseyear] ADD nphase tinyint NULL
END
ELSE
	ALTER TABLE [expenseyear] ALTER COLUMN nphase tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'nphaseexpense' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingkind] ADD nphaseexpense tinyint NULL
END
ELSE
	ALTER TABLE [sortingkind] ALTER COLUMN nphaseexpense tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbexpensetotal' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbexpensetotal] ADD nphase tinyint NULL
END
ELSE
	ALTER TABLE [upbexpensetotal] ALTER COLUMN nphase tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsetup' and C.name = 'appropriationphasecode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsetup] ADD appropriationphasecode tinyint NULL
END
ELSE
	ALTER TABLE [finsetup] ALTER COLUMN appropriationphasecode tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesetup' and C.name = 'expensephase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesetup] ADD expensephase tinyint NULL
END
ELSE
	ALTER TABLE [expensesetup] ALTER COLUMN expensephase tinyint NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensephase' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensephase SET nphase = nphaseint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET nphase = nphaseint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseyear SET nphase = nphaseint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'nphaseexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingkind SET nphaseexpense = nphaseexpenseint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbexpensetotal' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbexpensetotal SET nphase = nphaseint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsetup' and C.name = 'appropriationphasecodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finsetup SET appropriationphasecode = appropriationphasecodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesetup' and C.name = 'expensephaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesetup SET expensephase = expensephaseint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensephase' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensephase] ALTER COLUMN nphase tinyint NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbexpensetotal' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbexpensetotal] ALTER COLUMN nphase tinyint NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ALTER COLUMN nphase tinyint NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensephase') and constid=object_id('xpkexpensephase'))
BEGIN
	ALTER TABLE [expensephase] ADD CONSTRAINT xpkexpensephase PRIMARY KEY (nphase)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('upbexpensetotal') and constid=object_id('xpkupbexpensetotal'))
BEGIN
	ALTER TABLE [upbexpensetotal] ADD CONSTRAINT xpkupbexpensetotal PRIMARY KEY (idupb, idfin, nphase)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expense') and constid=object_id('uq1expense'))
BEGIN
	ALTER TABLE [expense] ADD CONSTRAINT uq1expense UNIQUE (nphase, ymov, nmov)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1expense' and id=object_id('expense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expense ON expense (nphase)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expense
	ON expense (nphase)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5expenseyear' and id=object_id('expenseyear'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5expenseyear ON expenseyear (nphase)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5expenseyear
	ON expenseyear (nphase)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2sortingkind' and id=object_id('sortingkind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2sortingkind ON sortingkind (nphaseexpense)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2sortingkind
	ON sortingkind (nphaseexpense)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensesetup' and id=object_id('expensephase'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensesetup ON expensesetup (expensephase)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensesetup
	ON expensesetup (expensephase)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expense' AND field = 'nphase')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:33.483'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'expense' AND field = 'nphase'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expense','nphase','N','int','1','','','System.Byte','int','N','','','S',{ts '2007-05-12 11:53:33.483'},'''SA''','NINO',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensephase' AND field = 'nphase')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:53.907'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'expensephase' AND field = 'nphase'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensephase','nphase','S','int','1','','','System.Byte','int','N','','','S',{ts '2006-10-12 10:21:53.907'},'''NINO''','SA',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseyear' AND field = 'nphase')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:02.077'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'expenseyear' AND field = 'nphase'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expenseyear','nphase','N','int','1','','','System.Byte','int','S','','','N',{ts '2006-10-12 10:22:02.077'},'''NINO''','SA',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finsetup' AND field = 'appropriationphasecode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-03-23 14:27:40.920'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'finsetup' AND field = 'appropriationphasecode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('finsetup','appropriationphasecode','N','int','1','','','System.Byte','int','S','','','N',{ts '2007-03-23 14:27:40.920'},'''SARA''','NINO',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingkind' AND field = 'nphaseexpense')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:16.327'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'sortingkind' AND field = 'nphaseexpense'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('sortingkind','nphaseexpense','N','int','1','','','System.Byte','int','S','','','N',{ts '2006-10-12 10:22:16.327'},'''NINO''','SA',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'upbexpensetotal' AND field = 'nphase')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:11.877'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'upbexpensetotal' AND field = 'nphase'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('upbexpensetotal','nphase','S','int','1','','','System.Byte','int','N','','','S',{ts '2006-10-12 10:22:11.877'},'''NINO''','SA',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensesetup' AND field = 'expensephase')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-09 10:48:40.530'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'expensesetup' AND field = 'expensephase'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensesetup','expensephase','N','tinyint','1','','','System.Byte','tinyint','S','','','N',{ts '2006-10-09 10:48:40.530'},'''SARA''','NINO',{ts '2007-05-12 11:53:33.483'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensephase'
		and C.name ='nphaseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensephase] DROP COLUMN nphaseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='nphaseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN nphaseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseyear'
		and C.name ='nphaseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseyear] DROP COLUMN nphaseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingkind'
		and C.name ='nphaseexpenseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingkind] DROP COLUMN nphaseexpenseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbexpensetotal'
		and C.name ='nphaseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbexpensetotal] DROP COLUMN nphaseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finsetup'
		and C.name ='appropriationphasecodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finsetup] DROP COLUMN appropriationphasecodeint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesetup'
		and C.name ='expensephaseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesetup] DROP COLUMN expensephaseint
END
GO
	