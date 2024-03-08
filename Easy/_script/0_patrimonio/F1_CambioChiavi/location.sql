
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


-- Aggiornamento tabella LOCATION e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- asset, assetlocation, locationsorting

-- Passo 0: Cancellazione di righe che violano l'integrità referenziale
DELETE FROM locationsorting WHERE NOT EXISTS(SELECT * FROM location WHERE location.idlocation = locationsorting.idlocation)
GO

INSERT INTO location (idlocation, locationcode, description, paridlocation, active, idman, nlevel, ct, cu, lt, lu)
SELECT DISTINCT idlocation, idlocation, idlocation, CASE WHEN LEN(idlocation) > 4 THEN SUBSTRING(idlocation, 1, LEN(idlocation)-4) ELSE NULL END,
'S', NULL, LEN(idlocation) / 4, GETDATE(), 'SA', GETDATE(), 'SA' 
FROM asset
WHERE idlocation NOT IN (SELECT idlocation FROM location WHERE location.idlocation = asset.idlocation)
AND idlocation IS NOT NULL

INSERT INTO location (idlocation, locationcode, description, paridlocation, active, idman, nlevel, ct, cu, lt, lu)
SELECT DISTINCT idlocation, idlocation, idlocation, CASE WHEN LEN(idlocation) > 4 THEN SUBSTRING(idlocation, 1, LEN(idlocation)-4) ELSE NULL END,
'S', NULL, LEN(idlocation) / 4, GETDATE(), 'SA', GETDATE(), 'SA' 
FROM assetlocation
WHERE idlocation NOT IN (SELECT idlocation FROM location WHERE location.idlocation = assetlocation.idlocation)

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idlocationint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'paridlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD paridlocationint int NULL
END
ELSE
BEGIN
	ALTER TABLE [location] ALTER COLUMN paridlocationint int NULL
END
-- , , 
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idlocationint int NULL
END
ELSE
BEGIN
	ALTER TABLE [asset] ALTER COLUMN idlocationint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetlocation' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetlocation] ADD idlocationint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetlocation] ALTER COLUMN idlocationint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationsorting] ADD idlocationint int NULL
END
ELSE
BEGIN
	ALTER TABLE [locationsorting] ALTER COLUMN idlocationint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'paridlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE location SET paridlocationint =
		(SELECT idlocationint FROM location i2 WHERE i2.idlocation = location.paridlocation)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE asset SET idlocationint = location.idlocationint
	FROM location
	WHERE asset.idlocation = location.idlocation
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetlocation' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetlocation SET idlocationint = location.idlocationint
	FROM location
	WHERE assetlocation.idlocation = location.idlocation
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE locationsorting SET idlocationint = location.idlocationint
	FROM location
	WHERE locationsorting.idlocation = location.idlocation
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono location, assetlocation, locationsorting

IF exists(SELECT * FROM sysconstraints where id=object_id('location') and constid=object_id('xpklocation'))
BEGIN
	ALTER TABLE [location] drop constraint xpklocation
END

IF exists(SELECT * FROM sysconstraints where id=object_id('location') and constid=object_id('PK_location'))
BEGIN
	ALTER TABLE [location] drop constraint PK_location
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('locationsorting') and constid=object_id('xpklocationsorting'))
BEGIN
	ALTER TABLE [locationsorting] drop constraint xpklocationsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('locationsorting') and constid=object_id('PK_locationsorting'))
BEGIN
	ALTER TABLE [locationsorting] drop constraint PK_locationsorting
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1location' and id=object_id('location'))
	drop index location.xi1location

IF EXISTS (SELECT * FROM sysindexes where name='xi2asset' and id=object_id('asset'))
	drop index asset.xi2asset

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetlocation' and id=object_id('assetlocation'))
	drop index assetlocation.xi2assetlocation

IF EXISTS (SELECT * FROM sysindexes where name='xi2locationsorting' and id=object_id('locationsorting'))
	drop index locationsorting.xi2locationsorting
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'location'
		and C.name ='idlocation'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [location] DROP COLUMN idlocation
	DELETE FROM columntypes WHERE tablename = 'location' AND field = 'idlocation'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'location'
		and C.name ='paridlocation'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [location] DROP COLUMN paridlocation
	DELETE FROM columntypes WHERE tablename = 'location' AND field = 'paridlocation'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='idlocation'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN idlocation
	DELETE FROM columntypes WHERE tablename = 'asset' AND field = 'idlocation'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetlocation'
		and C.name ='idlocation'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetlocation] DROP COLUMN idlocation
	DELETE FROM columntypes WHERE tablename = 'assetlocation' AND field = 'idlocation'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationsorting'
		and C.name ='idlocation'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationsorting] DROP COLUMN idlocation
	DELETE FROM columntypes WHERE tablename = 'locationsorting' AND field = 'idlocation'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate expense e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idlocation int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN idlocation int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'paridlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD paridlocation int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN paridlocation int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idlocation int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idlocation int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetlocation' and C.name = 'idlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetlocation] ADD idlocation int NULL 
END
ELSE
	ALTER TABLE [assetlocation] ALTER COLUMN idlocation int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationsorting] ADD idlocation int NULL 
END
ELSE
	ALTER TABLE [locationsorting] ALTER COLUMN idlocation int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE location SET idlocation = idlocationint, paridlocation = paridlocationint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE asset SET idlocation = idlocationint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetlocation' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetlocation SET idlocation = idlocationint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idlocationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE locationsorting SET idlocation = idlocationint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ALTER COLUMN idlocation int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationsorting] ALTER COLUMN idlocation int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE A NOT NULL)
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetlocation' and C.name = 'idlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetlocation] ALTER COLUMN idlocation int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('location') and constid=object_id('xpklocation'))
BEGIN
	ALTER TABLE [location] ADD CONSTRAINT xpklocation PRIMARY KEY (idlocation)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('locationsorting') and constid=object_id('xpklocationsorting'))
BEGIN
	ALTER TABLE [locationsorting] ADD CONSTRAINT xpklocationsorting PRIMARY KEY (idsorkind, idsor, idlocation)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1location' and id=object_id('location'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1location ON location (paridlocation)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1location
	ON location (paridlocation)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2asset' and id=object_id('asset'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2asset ON asset (idlocation)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2asset
	ON asset (idlocation)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetlocation' and id=object_id('assetlocation'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetlocation ON assetlocation (idlocation)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetlocation
	ON assetlocation (idlocation)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2locationsorting' and id=object_id('locationsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2locationsorting ON locationsorting (idlocation)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2locationsorting
	ON locationsorting (idlocation)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'asset' AND field = 'idlocation')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-24 11:45:52.157'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 11:45:52.157'} WHERE tablename = 'asset' AND field = 'idlocation'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('asset','idlocation','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-24 11:45:52.157'},'''NINO''','NINO',{ts '2007-10-24 11:45:52.157'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetlocation' AND field = 'idlocation')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 11:45:54.390'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 11:45:54.390'} WHERE tablename = 'assetlocation' AND field = 'idlocation'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetlocation','idlocation','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 11:45:54.390'},'''NINO''','NINO',{ts '2007-10-24 11:45:54.390'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'location' AND field = 'idlocation')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 11:45:52.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 11:45:52.420'} WHERE tablename = 'location' AND field = 'idlocation'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('location','idlocation','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 11:45:52.420'},'''NINO''','NINO',{ts '2007-10-24 11:45:52.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'location' AND field = 'paridlocation')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-24 11:45:52.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 11:45:52.420'} WHERE tablename = 'location' AND field = 'paridlocation'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('location','paridlocation','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-24 11:45:52.420'},'''NINO''','NINO',{ts '2007-10-24 11:45:52.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'locationsorting' AND field = 'idlocation')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 11:45:52.953'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 11:45:52.953'} WHERE tablename = 'locationsorting' AND field = 'idlocation'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('locationsorting','idlocation','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 11:45:52.953'},'''NINO''','NINO',{ts '2007-10-24 11:45:52.953'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'location'
		and C.name ='idlocationint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [location] DROP COLUMN idlocationint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'location'
		and C.name ='paridlocationint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [location] DROP COLUMN paridlocationint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='idlocationint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN idlocationint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetlocation'
		and C.name ='idlocationint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetlocation] DROP COLUMN idlocationint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationsorting'
		and C.name ='idlocationint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationsorting] DROP COLUMN idlocationint
END
GO
