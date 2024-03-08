
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


-- Aggiornamento tabella LOCATIONLEVEL e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- location

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationlevel' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationlevel] ADD nlevelint tinyint NULL
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD nlevelint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [location] ALTER COLUMN nlevelint tinyint NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationlevel' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE locationlevel SET nlevelint = CONVERT(tinyint, nlevel)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE location SET nlevelint = CONVERT(tinyint, nlevel)
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono inventorysortinglevel
IF exists(SELECT * FROM sysconstraints where id=object_id('locationlevel') and constid=object_id('xpklocationlevel'))
BEGIN
	ALTER TABLE [locationlevel] drop constraint xpklocationlevel
END

IF exists(SELECT * FROM sysconstraints where id=object_id('locationlevel') and constid=object_id('PK_locationlevel'))
BEGIN
	ALTER TABLE [locationlevel] drop constraint PK_locationlevel
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2location' and id=object_id('location'))
	drop index location.xi2location
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationlevel'
		and C.name ='nlevel'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationlevel] DROP COLUMN nlevel
	DELETE FROM columntypes WHERE tablename = 'locationlevel' AND field = 'nlevel'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'location'
		and C.name ='nlevel'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [location] DROP COLUMN nlevel
	DELETE FROM columntypes WHERE tablename = 'location' AND field = 'nlevel'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationlevel' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationlevel] ADD nlevel tinyint NULL
END
ELSE
	ALTER TABLE [locationlevel] ALTER COLUMN nlevel tinyint NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD nlevel tinyint NULL
END
ELSE
	ALTER TABLE [location] ALTER COLUMN nlevel tinyint NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationlevel' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE locationlevel SET nlevel = nlevelint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'nlevelint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE location SET nlevel = nlevelint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationlevel' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationlevel] ALTER COLUMN nlevel tinyint NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ALTER COLUMN nlevel tinyint NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('locationlevel') and constid=object_id('xpklocationlevel'))
BEGIN
	ALTER TABLE [locationlevel] ADD CONSTRAINT xpklocationlevel PRIMARY KEY (nlevel)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2location' and id=object_id('location'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2location ON location (nlevel)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2location
	ON location (nlevel)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'location' AND field = 'nlevel')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 09:18:31.593'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 09:18:31.593'} WHERE tablename = 'location' AND field = 'nlevel'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('location','nlevel','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 09:18:31.593'},'''NINO''','NINO',{ts '2007-10-24 09:18:31.593'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'locationlevel' AND field = 'nlevel')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 09:18:31.860'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 09:18:31.860'} WHERE tablename = 'locationlevel' AND field = 'nlevel'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('locationlevel','nlevel','S','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 09:18:31.860'},'''NINO''','NINO',{ts '2007-10-24 09:18:31.860'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationlevel'
		and C.name ='nlevelint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationlevel] DROP COLUMN nlevelint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'location'
		and C.name ='nlevelint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [location] DROP COLUMN nlevelint
END
GO
