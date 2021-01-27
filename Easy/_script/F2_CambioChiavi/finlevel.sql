
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- Aggiornamento tabella FINLEVEL e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- fin, expensesetup, incomesetup

-- Passo 0.bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_fin]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_fin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_fin]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_fin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_fin]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_fin]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlevel' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlevel] ADD nlevelint tinyint NULL
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ADD nlevelint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [fin] ALTER COLUMN nlevelint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesetup' and C.name = 'paymentfinlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesetup] ADD paymentfinlevelint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [expensesetup] ALTER COLUMN paymentfinlevelint tinyint NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesetup' and C.name = 'proceedsfinlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesetup] ADD proceedsfinlevelint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [incomesetup] ALTER COLUMN proceedsfinlevelint tinyint NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlevel' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finlevel SET nlevelint = CONVERT(tinyint, nlevel)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE fin SET nlevelint = CONVERT(tinyint, nlevel)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesetup' and C.name = 'paymentfinlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesetup SET paymentfinlevelint = CONVERT(tinyint, paymentfinlevel)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesetup' and C.name = 'proceedsfinlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesetup SET proceedsfinlevelint = CONVERT(tinyint, proceedsfinlevel)
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono finlevel
IF exists(SELECT * FROM sysconstraints where id=object_id('finlevel') and constid=object_id('xpkfinlevel'))
BEGIN
	ALTER TABLE [finlevel] drop constraint xpkfinlevel
END

IF exists(SELECT * FROM sysconstraints where id=object_id('finlevel') and constid=object_id('PK_finlevel'))
BEGIN
	ALTER TABLE [finlevel] drop constraint PK_finlevel
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2fin' and id=object_id('fin'))
	drop index fin.xi2fin
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finlevel'
		and C.name ='nlevel'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finlevel] DROP COLUMN nlevel
	DELETE FROM columntypes WHERE tablename = 'finlevel' AND field = 'nlevel'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='nlevel'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN nlevel
	DELETE FROM columntypes WHERE tablename = 'fin' AND field = 'nlevel'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesetup'
		and C.name ='paymentfinlevel'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesetup] DROP COLUMN paymentfinlevel
	DELETE FROM columntypes WHERE tablename = 'expensesetup' AND field = 'paymentfinlevel'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesetup'
		and C.name ='proceedsfinlevel'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesetup] DROP COLUMN proceedsfinlevel
	DELETE FROM columntypes WHERE tablename = 'incomesetup' AND field = 'proceedsfinlevel'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlevel' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlevel] ADD nlevel tinyint NULL
END
ELSE
	ALTER TABLE [finlevel] ALTER COLUMN nlevel tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ADD nlevel tinyint NULL
END
ELSE
	ALTER TABLE [fin] ALTER COLUMN nlevel tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesetup' and C.name = 'paymentfinlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesetup] ADD paymentfinlevel tinyint NULL
END
ELSE
	ALTER TABLE [expensesetup] ALTER COLUMN paymentfinlevel tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesetup' and C.name = 'proceedsfinlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesetup] ADD proceedsfinlevel tinyint NULL
END
ELSE
	ALTER TABLE [incomesetup] ALTER COLUMN proceedsfinlevel tinyint NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlevel' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finlevel SET nlevel = nlevelint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE fin SET nlevel = nlevelint
END

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesetup' and C.name = 'paymentfinlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesetup SET paymentfinlevel = paymentfinlevelint
END

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesetup' and C.name = 'proceedsfinlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesetup SET proceedsfinlevel = proceedsfinlevelint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlevel' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlevel] ALTER COLUMN nlevel tinyint NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ALTER COLUMN nlevel tinyint NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('finlevel') and constid=object_id('xpkfinlevel'))
BEGIN
	ALTER TABLE [finlevel] ADD CONSTRAINT xpkfinlevel PRIMARY KEY (ayear, nlevel)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2fin' and id=object_id('fin'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2fin ON fin (ayear, nlevel)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2fin
	ON fin (ayear, nlevel)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'fin' AND field = 'nlevel')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:12.017'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-12 10:22:12.017'} WHERE tablename = 'fin' AND field = 'nlevel'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('fin','nlevel','N','tinyint','1','','','System.Byte','tinyint','N','','','S',{ts '2006-10-12 10:22:12.017'},'''NINO''','SA',{ts '2006-10-12 10:22:12.017'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finlevel' AND field = 'nlevel')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'tinyint',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:16.920'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-12 10:22:12.017'} WHERE tablename = 'finlevel' AND field = 'nlevel'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('finlevel','nlevel','S','tinyint','1','','','System.Byte','tinyint','N','','','S',{ts '2006-10-12 10:22:16.920'},'''NINO''','SA',{ts '2006-10-12 10:22:12.017'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensesetup' AND field = 'paymentfinlevel')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-09 10:48:40.733'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:12.017'} WHERE tablename = 'expensesetup' AND field = 'paymentfinlevel'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensesetup','paymentfinlevel','N','tinyint','1','','','System.Byte','tinyint','S','','','N',{ts '2006-10-09 10:48:40.733'},'''SARA''','NINO',{ts '2006-10-12 10:22:12.017'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomesetup' AND field = 'proceedsfinlevel')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = '',col_scale = '',systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-09 10:48:47.517'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2006-10-12 10:22:12.017'} WHERE tablename = 'incomesetup' AND field = 'proceedsfinlevel'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incomesetup','proceedsfinlevel','N','tinyint','1','','','System.Byte','tinyint','S','','','N',{ts '2006-10-09 10:48:47.517'},'''SARA''','SARA',{ts '2006-10-12 10:22:12.017'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finlevel'
		and C.name ='nlevelint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finlevel] DROP COLUMN nlevelint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='nlevelint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN nlevelint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesetup'
		and C.name ='paymentfinlevelint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesetup] DROP COLUMN paymentfinlevelint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesetup'
		and C.name ='proceedsfinlevelint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesetup] DROP COLUMN proceedsfinlevelint
END
GO
