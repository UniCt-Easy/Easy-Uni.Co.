
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


-- Aggiornamento tabella ASSETLOAD e tabelle dipendenti
-- le tabelle dipendenti sono: assetacquire, assetloadexpense

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DELETE FROM assetloadexpense WHERE NOT EXISTS
	(SELECT * FROM assetload
	WHERE assetload.idassetloadkind = assetloadexpense.idassetloadkind
		AND assetload.yassetload = assetloadexpense.yassetload
		AND assetload.nassetload = assetloadexpense.nassetload)

-- Qui vengono inseriri buoni di carico che erano stati associati a carichi bene marcati come beni posseduti.
INSERT INTO assetload (idassetloadkind, yassetload, nassetload, ratificationdate, ct, cu, lt, lu)
SELECT DISTINCT idassetloadkind, yassetload, nassetload, CONVERT(datetime, '31-12-' + CONVERT(char(4), yassetload), 105),
GETDATE(), 'SA', GETDATE(), 'SA'
FROM assetacquire
WHERE assetacquire.loadkind = 'R'
	AND idassetloadkind IS NOT NULL
	AND yassetload IS NOT NULL
	AND nassetload IS NOT NULL
	AND NOT EXISTS(SELECT * FROM assetload
		WHERE assetload.idassetloadkind = assetacquire.idassetloadkind
		AND assetload.yassetload = assetacquire.yassetload
		AND assetload.nassetload = assetacquire.nassetload)

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento) e Passo 2. (aggiunta delle colonne nelle tabelle referenziate)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idassetloadint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetload] ADD idassetloadint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idassetload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetload] ADD idassetload int NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idassetload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idassetload int NULL 
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idassetload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadexpense] ADD idassetload int NULL 
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idassetload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetload SET idassetload = idassetloadint
	FROM assetload
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idassetload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idassetload = assetload.idassetload
	FROM assetload
	WHERE assetload.idassetloadkind = assetacquire.idassetloadkind
		AND assetload.yassetload = assetacquire.yassetload
		AND assetload.nassetload = assetacquire.nassetload
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idassetload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadexpense SET idassetload = assetload.idassetload
	FROM assetload
	WHERE assetload.idassetloadkind = assetloadexpense.idassetloadkind
		AND assetload.yassetload = assetloadexpense.yassetload
		AND assetload.nassetload = assetloadexpense.nassetload
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono assetload, assetloadexpense

IF exists(SELECT * FROM sysconstraints where id=object_id('assetload') and constid=object_id('xpkassetload'))
BEGIN
	ALTER TABLE [assetload] drop constraint xpkassetload
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetload') and constid=object_id('PK_assetload'))
BEGIN
	ALTER TABLE [assetload] drop constraint PK_assetload
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('assetloadexpense') and constid=object_id('xpkassetloadexpense'))
BEGIN
	ALTER TABLE [assetloadexpense] drop constraint xpkassetloadexpense
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetloadexpense') and constid=object_id('PK_assetloadexpense'))
BEGIN
	ALTER TABLE [assetloadexpense] drop constraint PK_assetloadexpense
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetvardetail
IF EXISTS (SELECT * FROM sysindexes where name='xi4assetacquire' and id=object_id('assetacquire'))
	drop index assetacquire.xi4assetacquire
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='idassetloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idassetloadkind
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'idassetloadkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='yassetload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN yassetload
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'yassetload'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='nassetload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN nassetload
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'nassetload'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadexpense'
		and C.name ='idassetloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadexpense] DROP COLUMN idassetloadkind
	DELETE FROM columntypes WHERE tablename = 'assetloadexpense' AND field = 'idassetloadkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadexpense'
		and C.name ='yassetload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadexpense] DROP COLUMN yassetload
	DELETE FROM columntypes WHERE tablename = 'assetloadexpense' AND field = 'yassetload'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadexpense'
		and C.name ='nassetload'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadexpense] DROP COLUMN nassetload
	DELETE FROM columntypes WHERE tablename = 'assetloadexpense' AND field = 'nassetload'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso) - NON SERVE
-- Tabelle interessate -

-- Passo 6. Valorizzazione nuovo campo - Gia fatto a priori

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idassetload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetload] ALTER COLUMN idassetload int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idassetload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadexpense] ALTER COLUMN idassetload int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetload') and constid=object_id('xpkassetload'))
BEGIN
	ALTER TABLE [assetload] ADD CONSTRAINT xpkassetload PRIMARY KEY (idassetload)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetload') and constid=object_id('ukassetload'))
BEGIN
	ALTER TABLE [assetload] ADD CONSTRAINT ukassetload UNIQUE (idassetloadkind, yassetload, nassetload)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetloadexpense') and constid=object_id('xpkassetloadexpense'))
BEGIN
	ALTER TABLE [assetloadexpense] ADD CONSTRAINT xpkassetloadexpense PRIMARY KEY (idassetload, idexp)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi5assetload' and id=object_id('assetload'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5assetload ON assetload (idassetloadkind, yassetload, nassetload)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5assetload
	ON assetload (idassetloadkind, yassetload, nassetload)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetacquire' and id=object_id('assetacquire'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4assetacquire ON assetacquire (idassetload)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4assetacquire
	ON assetacquire (idassetload)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetacquire' AND field = 'idassetload')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-24 14:27:35.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:27:35.530'} WHERE tablename = 'assetacquire' AND field = 'idassetload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetacquire','idassetload','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-24 14:27:35.530'},'''NINO''','NINO',{ts '2007-10-24 14:27:35.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetload' AND field = 'idassetload')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 14:27:36.267'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:27:36.267'} WHERE tablename = 'assetload' AND field = 'idassetload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetload','idassetload','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 14:27:36.267'},'''NINO''','NINO',{ts '2007-10-24 14:27:36.267'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetload' AND field = 'idassetloadkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 14:27:36.267'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:27:36.267'} WHERE tablename = 'assetload' AND field = 'idassetloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetload','idassetloadkind','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 14:27:36.267'},'''NINO''','NINO',{ts '2007-10-24 14:27:36.267'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetload' AND field = 'nassetload')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 14:27:36.250'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:27:36.250'} WHERE tablename = 'assetload' AND field = 'nassetload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetload','nassetload','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 14:27:36.250'},'''NINO''','NINO',{ts '2007-10-24 14:27:36.250'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetload' AND field = 'yassetload')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 14:27:36.250'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:27:36.250'} WHERE tablename = 'assetload' AND field = 'yassetload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetload','yassetload','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-10-24 14:27:36.250'},'''NINO''','NINO',{ts '2007-10-24 14:27:36.250'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetloadexpense' AND field = 'idassetload')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 14:27:36.500'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 14:27:36.500'} WHERE tablename = 'assetloadexpense' AND field = 'idassetload'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetloadexpense','idassetload','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 14:27:36.500'},'''NINO''','NINO',{ts '2007-10-24 14:27:36.500'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle (Non sono stati usati campi temporanei)
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetload'
		and C.name ='idassetloadint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetload] DROP COLUMN idassetloadint
END
GO

