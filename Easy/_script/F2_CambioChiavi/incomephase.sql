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

﻿-- Aggiornamento tabella INCOMEPHASE e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- income, incomeyear, sortingkind, finsetup, upbincometotal, incomesetup

-- Passo 0.bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_income]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_income]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_incomeyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_incomeyear]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomephase' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomephase] ADD nphaseint tinyint NULL
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD nphaseint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [income] ALTER COLUMN nphaseint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeyear] ADD nphaseint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [incomeyear] ALTER COLUMN nphaseint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'nphaseincomeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingkind] ADD nphaseincomeint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingkind] ALTER COLUMN nphaseincomeint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsetup' and C.name = 'assessmentphasecodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsetup] ADD assessmentphasecodeint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [finsetup] ALTER COLUMN assessmentphasecodeint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbincometotal' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbincometotal] ADD nphaseint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [upbincometotal] ALTER COLUMN nphaseint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesetup' and C.name = 'incomephaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesetup] ADD incomephaseint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [incomesetup] ALTER COLUMN incomephaseint tinyint NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomephase' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomephase SET nphaseint = CONVERT(tinyint, nphase)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE income SET nphaseint = CONVERT(tinyint, nphase)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeyear SET nphaseint = CONVERT(tinyint, nphase)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'nphaseexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingkind SET nphaseincomeint = CONVERT(tinyint, nphaseincome)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsetup' and C.name = 'assessmentphasecodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finsetup SET assessmentphasecodeint = CONVERT(tinyint, assessmentphasecode)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbincometotal' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbincometotal SET nphaseint = CONVERT(tinyint, nphase)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesetup' and C.name = 'incomephaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesetup SET incomephaseint = CONVERT(tinyint, incomephase)
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono finlevel
IF exists(SELECT * FROM sysconstraints where id=object_id('incomephase') and constid=object_id('xpkincomephase'))
BEGIN
	ALTER TABLE [incomephase] drop constraint xpkincomephase
END

IF exists(SELECT * FROM sysconstraints where id=object_id('incomephase') and constid=object_id('PK_incomephase'))
BEGIN
	ALTER TABLE [incomephase] drop constraint PK_incomephase
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('income') and constid=object_id('UQ_1_income'))
BEGIN
	ALTER TABLE [income] drop constraint UQ_1_income
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('upbincometotal') and constid=object_id('xpkupbincometotal'))
BEGIN
	ALTER TABLE [upbincometotal] drop constraint xpkupbincometotal
END

IF exists(SELECT * FROM sysconstraints where id=object_id('upbincometotal') and constid=object_id('PK_upbincometotal'))
BEGIN
	ALTER TABLE [upbincometotal] drop constraint PK_upbincometotal
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1income' and id=object_id('income'))
	drop index income.xi1income
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_income' and id=object_id('income'))
	drop index income.UQ_1_income
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5incomeyear' and id=object_id('incomeyear'))
	drop index incomeyear.xi5incomeyear
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingkind' and id=object_id('sortingkind'))
	drop index sortingkind.xi1sortingkind
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomephase'
		and C.name ='nphase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomephase] DROP COLUMN nphase
	DELETE FROM columntypes WHERE tablename = 'incomephase' AND field = 'nphase'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='nphase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN nphase
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'nphase'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeyear'
		and C.name ='nphase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeyear] DROP COLUMN nphase
	DELETE FROM columntypes WHERE tablename = 'incomeyear' AND field = 'nphase'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingkind'
		and C.name ='nphaseincome'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingkind] DROP COLUMN nphaseincome
	DELETE FROM columntypes WHERE tablename = 'sortingkind' AND field = 'nphaseincome'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finsetup'
		and C.name ='assessmentphasecode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finsetup] DROP COLUMN assessmentphasecode
	DELETE FROM columntypes WHERE tablename = 'finsetup' AND field = 'assessmentphasecode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbincometotal'
		and C.name ='nphase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbincometotal] DROP COLUMN nphase
	DELETE FROM columntypes WHERE tablename = 'upbincometotal' AND field = 'nphase'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesetup'
		and C.name ='incomephase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesetup] DROP COLUMN incomephase
	DELETE FROM columntypes WHERE tablename = 'incomesetup' AND field = 'incomephase'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomephase' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomephase] ADD nphase tinyint NULL
END
ELSE
	ALTER TABLE [incomephase] ALTER COLUMN nphase tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD nphase tinyint NULL
END
ELSE
	ALTER TABLE [income] ALTER COLUMN nphase tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeyear] ADD nphase tinyint NULL
END
ELSE
	ALTER TABLE [incomeyear] ALTER COLUMN nphase tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'nphaseincome' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingkind] ADD nphaseincome tinyint NULL
END
ELSE
	ALTER TABLE [sortingkind] ALTER COLUMN nphaseincome tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbincometotal' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbincometotal] ADD nphase tinyint NULL
END
ELSE
	ALTER TABLE [upbincometotal] ALTER COLUMN nphase tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsetup' and C.name = 'assessmentphasecode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsetup] ADD assessmentphasecode tinyint NULL
END
ELSE
	ALTER TABLE [finsetup] ALTER COLUMN assessmentphasecode tinyint NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesetup' and C.name = 'incomephase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesetup] ADD incomephase tinyint NULL
END
ELSE
	ALTER TABLE [incomesetup] ALTER COLUMN incomephase tinyint NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomephase' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomephase SET nphase = nphaseint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE income SET nphase = nphaseint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeyear SET nphase = nphaseint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'nphaseincomeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingkind SET nphaseincome = nphaseincomeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbincometotal' and C.name = 'nphaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbincometotal SET nphase = nphaseint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsetup' and C.name = 'assessmentphasecodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finsetup SET assessmentphasecode = assessmentphasecodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesetup' and C.name = 'incomephaseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesetup SET incomephase = incomephaseint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomephase' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomephase] ALTER COLUMN nphase tinyint NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbincometotal' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbincometotal] ALTER COLUMN nphase tinyint NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ALTER COLUMN nphase tinyint NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('incomephase') and constid=object_id('xpkincomephase'))
BEGIN
	ALTER TABLE [incomephase] ADD CONSTRAINT xpkincomephase PRIMARY KEY (nphase)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('upbincometotal') and constid=object_id('xpkupbincometotal'))
BEGIN
	ALTER TABLE [upbincometotal] ADD CONSTRAINT xpkupbincometotal PRIMARY KEY (idupb, idfin, nphase)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('income') and constid=object_id('uq1income'))
BEGIN
	ALTER TABLE [income] ADD CONSTRAINT uq1income UNIQUE (nphase, ymov, nmov)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1income' and id=object_id('income'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1income ON income (nphase)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1income
	ON income (nphase)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5incomeyear' and id=object_id('incomeyear'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5expenseyear ON incomeyear (nphase)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5incomeyear
	ON incomeyear (nphase)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingkind' and id=object_id('sortingkind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingkind ON sortingkind (nphaseincome)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingkind
	ON sortingkind (nphaseincome)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'income' AND field = 'nphase')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:33.483'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'income' AND field = 'nphase'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('income','nphase','N','int','1','','','System.Byte','int','N','','','S',{ts '2007-05-12 11:53:33.483'},'''SA''','NINO',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomephase' AND field = 'nphase')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:53.907'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'incomephase' AND field = 'nphase'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incomephase','nphase','S','int','1','','','System.Byte','int','N','','','S',{ts '2006-10-12 10:21:53.907'},'''NINO''','SA',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'income' AND field = 'nphase')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:02.077'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'incomeyear' AND field = 'nphase'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incomeyear','nphase','N','int','1','','','System.Byte','int','S','','','N',{ts '2006-10-12 10:22:02.077'},'''NINO''','SA',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finsetup' AND field = 'appropriationphasecode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-03-23 14:27:40.920'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'finsetup' AND field = 'assessmentphasecode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('finsetup','assessmentphasecode','N','int','1','','','System.Byte','int','S','','','N',{ts '2007-03-23 14:27:40.920'},'''SARA''','NINO',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingkind' AND field = 'nphaseincome')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:16.327'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'sortingkind' AND field = 'nphaseincome'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('sortingkind','nphaseincome','N','int','1','','','System.Byte','int','S','','','N',{ts '2006-10-12 10:22:16.327'},'''NINO''','SA',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'upbincometotal' AND field = 'nphase')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:11.877'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'upbincometotal' AND field = 'nphase'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('upbincometotal','nphase','S','int','1','','','System.Byte','int','N','','','S',{ts '2006-10-12 10:22:11.877'},'''NINO''','SA',{ts '2007-05-12 11:53:33.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomesetup' AND field = 'incomephase')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-09 10:48:47.467'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2007-05-12 11:53:33.483'} WHERE tablename = 'incomesetup' AND field = 'incomephase'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incomesetup','incomephase','N','tinyint','1','','','System.Byte','tinyint','S','','','N',{ts '2006-10-09 10:48:47.467'},'''SARA''','SARA',{ts '2007-05-12 11:53:33.483'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomephase'
		and C.name ='nphaseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomephase] DROP COLUMN nphaseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='nphaseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN nphaseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeyear'
		and C.name ='nphaseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeyear] DROP COLUMN nphaseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingkind'
		and C.name ='nphaseincomeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingkind] DROP COLUMN nphaseincomeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbincometotal'
		and C.name ='nphaseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbincometotal] DROP COLUMN nphaseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finsetup'
		and C.name ='assessmentphasecodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finsetup] DROP COLUMN assessmentphasecodeint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesetup'
		and C.name ='incomephaseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesetup] DROP COLUMN incomephaseint
END
GO
	