
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


-- Aggiornamento tabella ASSETUNLOAD e tabelle dipendenti
-- le tabelle dipendenti sono:
-- asset, assetamortization, assetunloadincome

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DELETE FROM assetunloadincome WHERE NOT EXISTS
	(SELECT * FROM assetunload
	WHERE assetunload.idassetunloadkind = assetunloadincome.idassetunloadkind
		AND assetunload.yassetunload = assetunloadincome.yassetunload
		AND assetunload.nassetunload = assetunloadincome.nassetunload)

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento) e Passo 2. (aggiunta delle colonne nelle tabelle referenziate)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idassetunloadint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunload] ADD idassetunloadint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunload] ADD idassetunload int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idassetunload int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetamortization] ADD idassetunload int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadincome] ADD idassetunload int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunload SET idassetunload = idassetunloadint
	FROM assetunload
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE asset SET idassetunload = assetunload.idassetunload
	FROM assetunload
	WHERE assetunload.idassetunloadkind = asset.idassetunloadkind
		AND assetunload.yassetunload = asset.yassetunload
		AND assetunload.nassetunload = asset.nassetunload
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadincome SET idassetunload = assetunload.idassetunload
	FROM assetunload
	WHERE assetunload.idassetunloadkind = assetunloadincome.idassetunloadkind
		AND assetunload.yassetunload = assetunloadincome.yassetunload
		AND assetunload.nassetunload = assetunloadincome.nassetunload
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetamortization SET idassetunload = assetunload.idassetunload
	FROM assetunload
	WHERE assetunload.idassetunloadkind = assetamortization.idassetunloadkind
		AND assetunload.yassetunload = assetamortization.yassetunload
		AND assetunload.nassetunload = assetamortization.nassetunload
END
GO
-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono assetunload, assetunloadincome

IF exists(SELECT * FROM sysconstraints where id=object_id('assetunload') and constid=object_id('xpkassetunload'))
BEGIN
	ALTER TABLE [assetunload] drop constraint xpkassetunload
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetunload') and constid=object_id('PK_assetunload'))
BEGIN
	ALTER TABLE [assetunload] drop constraint PK_assetunload
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('assetunloadincome') and constid=object_id('xpkassetunloadincome'))
BEGIN
	ALTER TABLE [assetunloadincome] drop constraint xpkassetunloadincome
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetunloadincome') and constid=object_id('PK_assetunloadincome'))
BEGIN
	ALTER TABLE [assetunloadincome] drop constraint PK_assetunloadincome
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetamortization
IF EXISTS (SELECT * FROM sysindexes where name='xi3assetamortization' and id=object_id('assetamortization'))
	drop index assetamortization.xi3assetamortization
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='idassetunloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN idassetunloadkind
	DELETE FROM columntypes WHERE tablename = 'asset' AND field = 'idassetunloadkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='yassetunload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN yassetunload
	DELETE FROM columntypes WHERE tablename = 'asset' AND field = 'yassetunload'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='nassetunload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN nassetunload
	DELETE FROM columntypes WHERE tablename = 'asset' AND field = 'nassetunload'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetamortization'
		and C.name ='idassetunloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetamortization] DROP COLUMN idassetunloadkind
	DELETE FROM columntypes WHERE tablename = 'assetamortization' AND field = 'idassetunloadkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetamortization'
		and C.name ='yassetunload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetamortization] DROP COLUMN yassetunload
	DELETE FROM columntypes WHERE tablename = 'assetamortization' AND field = 'yassetunload'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetamortization'
		and C.name ='nassetunload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetamortization] DROP COLUMN nassetunload
	DELETE FROM columntypes WHERE tablename = 'assetamortization' AND field = 'nassetunload'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadincome'
		and C.name ='idassetunloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadincome] DROP COLUMN idassetunloadkind
	DELETE FROM columntypes WHERE tablename = 'assetunloadincome' AND field = 'idassetunloadkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadincome'
		and C.name ='yassetunload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadincome] DROP COLUMN yassetunload
	DELETE FROM columntypes WHERE tablename = 'assetunloadincome' AND field = 'yassetunload'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadincome'
		and C.name ='nassetunload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadincome] DROP COLUMN nassetunload
	DELETE FROM columntypes WHERE tablename = 'assetunloadincome' AND field = 'nassetunload'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso) - NON SERVE
-- Tabelle interessate -

-- Passo 6. Valorizzazione nuovo campo - Gia fatto a priori

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunload] ALTER COLUMN idassetunload int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadincome] ALTER COLUMN idassetunload int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetunload') and constid=object_id('xpkassetunload'))
BEGIN
	ALTER TABLE [assetunload] ADD CONSTRAINT xpkassetunload PRIMARY KEY (idassetunload)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetunload') and constid=object_id('ukassetunload'))
BEGIN
	ALTER TABLE [assetunload] ADD CONSTRAINT ukassetunload UNIQUE (idassetunloadkind, yassetunload, nassetunload)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetunloadincome') and constid=object_id('xpkassetunloadincome'))
BEGIN
	ALTER TABLE [assetunloadincome] ADD CONSTRAINT xpkassetunloadincome PRIMARY KEY (idassetunload, idinc)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi5assetunload' and id=object_id('assetunload'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5assetunload ON assetunload (idassetunloadkind, yassetunload, nassetunload)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5assetunload
	ON assetunload (idassetunloadkind, yassetunload, nassetunload)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4asset' and id=object_id('asset'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4asset ON asset (idassetunload)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4asset
	ON asset (idassetunload)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetamortization' and id=object_id('assetamortization'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3assetamortization ON assetamortization (idassetunload)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3assetamortization
	ON assetamortization (idassetunload)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'asset' AND field = 'idassetunload')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-24 14:50:04.750'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:50:04.750'} WHERE tablename = 'asset' AND field = 'idassetunload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('asset','idassetunload','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-24 14:50:04.750'},'''NINO''','NINO',{ts '2007-10-24 14:50:04.750'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetamortization' AND field = 'idassetunload')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-24 14:50:05.360'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:50:05.360'} WHERE tablename = 'assetamortization' AND field = 'idassetunload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetamortization','idassetunload','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-24 14:50:05.360'},'''NINO''','NINO',{ts '2007-10-24 14:50:05.360'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunload' AND field = 'idassetunload')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 14:50:07.983'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:50:07.983'} WHERE tablename = 'assetunload' AND field = 'idassetunload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunload','idassetunload','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 14:50:07.983'},'''NINO''','NINO',{ts '2007-10-24 14:50:07.983'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunload' AND field = 'idassetunloadkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 14:50:07.983'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:50:07.983'} WHERE tablename = 'assetunload' AND field = 'idassetunloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunload','idassetunloadkind','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 14:50:07.983'},'''NINO''','NINO',{ts '2007-10-24 14:50:07.983'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunload' AND field = 'nassetunload')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 14:50:07.953'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:50:07.953'} WHERE tablename = 'assetunload' AND field = 'nassetunload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunload','nassetunload','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 14:50:07.953'},'''NINO''','NINO',{ts '2007-10-24 14:50:07.953'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunload' AND field = 'yassetunload')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 14:50:07.953'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:50:07.953'} WHERE tablename = 'assetunload' AND field = 'yassetunload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunload','yassetunload','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-10-24 14:50:07.953'},'''NINO''','NINO',{ts '2007-10-24 14:50:07.953'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunloadincome' AND field = 'idassetunload')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 14:50:08.390'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:50:08.390'} WHERE tablename = 'assetunloadincome' AND field = 'idassetunload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunloadincome','idassetunload','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 14:50:08.390'},'''NINO''','NINO',{ts '2007-10-24 14:50:08.390'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle (Non sono stati usati campi temporanei)
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunload'
		and C.name ='idassetunloadint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunload] DROP COLUMN idassetunloadint
END
GO

