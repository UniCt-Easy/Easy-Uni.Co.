
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


-- Aggiornamento tabella ASSETUSAGEKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- assetusage

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO assetusagekind (idassetusagekind, description, ct, cu, lt, lu)
SELECT DISTINCT idassetusagekind, idassetusagekind, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM assetusage
WHERE NOT EXISTS(SELECT * FROM assetusagekind WHERE assetusagekind.idassetusagekind = assetusage.idassetusagekind)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusagekind' and C.name = 'idassetusagekindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetusagekind] ADD idassetusagekindint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusagekind' and C.name = 'codeassetusagekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetusagekind] ADD codeassetusagekind varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [assetusagekind] ALTER COLUMN codeassetusagekind varchar(20) NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusage' and C.name = 'idassetusagekindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetusage] ADD idassetusagekindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetusage] ALTER COLUMN idassetusagekindint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusagekind' and C.name = 'codeassetusagekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetusagekind SET codeassetusagekind = idassetusagekind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusage' and C.name = 'idassetusagekindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetusage SET idassetusagekindint = assetusagekind.idassetusagekindint
	FROM assetusagekind
	WHERE assetusage.idassetusagekind = assetusagekind.idassetusagekind
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono assetusagekind
IF exists(SELECT * FROM sysconstraints where id=object_id('assetusagekind') and constid=object_id('xpkassetusagekind'))
BEGIN
	ALTER TABLE [assetusagekind] drop constraint xpkassetusagekind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetusagekind') and constid=object_id('PK_assetusagekind'))
BEGIN
	ALTER TABLE [assetusagekind] drop constraint PK_assetusagekind
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('assetusage') and constid=object_id('xpkassetusage'))
BEGIN
	ALTER TABLE [assetusage] drop constraint xpkassetusage
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetusage') and constid=object_id('PK_assetusage'))
BEGIN
	ALTER TABLE [assetusage] drop constraint PK_assetusage
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetusage
IF EXISTS (SELECT * FROM sysindexes where name='xi2assetusage' and id=object_id('assetusage'))
	drop index assetusage.xi2assetusage
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetusagekind'
		and C.name ='idassetusagekind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetusagekind] DROP COLUMN idassetusagekind
	DELETE FROM columntypes WHERE tablename = 'assetusagekind' AND field = 'idassetusagekind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetusage'
		and C.name ='idassetusagekind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetusage] DROP COLUMN idassetusagekind
	DELETE FROM columntypes WHERE tablename = 'assetusage' AND field = 'idassetusagekind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate assetusagekind e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusagekind' and C.name = 'idassetusagekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetusagekind] ADD idassetusagekind int NULL 
END
ELSE
	ALTER TABLE [assetusagekind] ALTER COLUMN idassetusagekind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusage' and C.name = 'idassetusagekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetusage] ADD idassetusagekind int NULL 
END
ELSE
	ALTER TABLE [assetusage] ALTER COLUMN idassetusagekind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusagekind' and C.name = 'idassetusagekindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetusagekind SET idassetusagekind = idassetusagekindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusage' and C.name = 'idassetusagekindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetusage SET idassetusagekind = idassetusagekindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusagekind' and C.name = 'idassetusagekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetusagekind] ALTER COLUMN idassetusagekind int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusage' and C.name = 'idassetusagekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetusage] ALTER COLUMN idassetusagekind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetusagekind' and C.name = 'codeassetusagekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetusagekind] ALTER COLUMN codeassetusagekind varchar(20) NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetusagekind') and constid=object_id('xpkassetusagekind'))
BEGIN
	ALTER TABLE [assetusagekind] ADD CONSTRAINT xpkassetusagekind PRIMARY KEY (idassetusagekind)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetusagekind') and constid=object_id('ukassetusagekind'))
BEGIN
	ALTER TABLE [assetusagekind] ADD CONSTRAINT ukassetusagekind UNIQUE (codeassetusagekind)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetusage') and constid=object_id('xpkassetusage'))
BEGIN
	ALTER TABLE [assetusage] ADD CONSTRAINT xpkassetusage PRIMARY KEY (nassetacquire, idassetusagekind)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1assetusagekind' and id=object_id('assetusagekind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetusagekind ON assetusagekind (codeassetusagekind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetusagekind
	ON assetusagekind (codeassetusagekind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetusage' and id=object_id('assetusage'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetusage ON assetusage (idassetusagekind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetusage
	ON assetusage (idassetusagekind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetusage' AND field = 'idassetusagekind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-09 11:36:09.907'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-09 11:36:09.907'} WHERE tablename = 'assetusage' AND field = 'idassetusagekind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetusage','idassetusagekind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-09 11:36:09.907'},'''NINO''','NINO',{ts '2007-11-09 11:36:09.907'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetusagekind' AND field = 'codeassetusagekind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-09 11:36:03.157'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-09 11:36:03.157'} WHERE tablename = 'assetusagekind' AND field = 'codeassetusagekind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetusagekind','codeassetusagekind','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-09 11:36:03.157'},'''NINO''','NINO',{ts '2007-11-09 11:36:03.157'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetusagekind' AND field = 'idassetusagekind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-09 11:36:03.157'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-09 11:36:03.157'} WHERE tablename = 'assetusagekind' AND field = 'idassetusagekind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetusagekind','idassetusagekind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-09 11:36:03.157'},'''NINO''','NINO',{ts '2007-11-09 11:36:03.157'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetusagekind'
		and C.name ='idassetusagekindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetusagekind] DROP COLUMN idassetusagekindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetusage'
		and C.name ='idassetusagekindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetusage] DROP COLUMN idassetusagekindint
END
GO
