
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


-- Aggiornamento tabella ASSETLOADKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- assetacquire, assetload, assetloadexpense
-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DECLARE @err int
SET @err =
	ISNULL(
		(SELECT COUNT(*)
		FROM assetacquire
		WHERE idassetloadkind NOT IN
			(SELECT idassetloadkind FROM assetloadkind WHERE assetloadkind.idassetloadkind = assetacquire.idassetloadkind)
		AND idassetloadkind IS NOT NULL
		)
	,0) +
	ISNULL(
		(SELECT COUNT(*)
		FROM assetload
		WHERE idassetloadkind NOT IN
			(SELECT idassetloadkind FROM assetloadkind WHERE assetloadkind.idassetloadkind = assetload.idassetloadkind)
		)
	,0) +
	ISNULL(
		(SELECT COUNT(*)
		FROM assetloadexpense
		WHERE idassetloadkind NOT IN
			(SELECT idassetloadkind FROM assetloadkind WHERE assetloadkind.idassetloadkind = assetloadexpense.idassetloadkind)
		)
	,0)

IF (@err > 0)
BEGIN
	IF NOT EXISTS(SELECT * FROM inventory WHERE codeinventory = 'FITTIZIA')
	BEGIN
		DECLARE @maxinv int
		SET @maxinv = 1 + ISNULL((SELECT MAX(idinventory) FROM inventory),0)

		DECLARE @maxinvagency int
		IF EXISTS(SELECT * FROM inventoryagency WHERE codeinventoryagency = 'FITTIZIA')
		BEGIN
			SELECT @maxinvagency = idinventoryagency FROM inventoryagency WHERE codeinventoryagency = 'FITTIZIA'
		END
		ELSE
		BEGIN
			SET @maxinvagency = 1 + ISNULL((SELECT MAX(idinventoryagency) FROM inventoryagency),0)

			INSERT INTO inventoryagency (idinventoryagency, codeinventoryagency, description, ct, cu, lt, lu)
			VALUES (@maxinvagency, 'FITTIZIA', 'Fittizia', GETDATE(), 'SA', GETDATE(), 'SA')
		END

		DECLARE @maxinvkind int
		IF EXISTS(SELECT * FROM inventorykind WHERE codeinventorykind = 'FITTIZIA')
		BEGIN
			SELECT @maxinvkind = idinventorykind FROM inventorykind WHERE codeinventorykind = 'FITTIZIA'
		END
		ELSE
		BEGIN

			SET @maxinvkind = 1 + ISNULL((SELECT MAX(idinventorykind) FROM inventortykind),0)

			INSERT INTO inventorykind (idinventorykind, codeinventorykind, description, flagdiscount, ct, cu, lt, lu)
			VALUES (@maxinvkind, 'FITTIZIA', 'Fittizia', 'N', GETDATE(), 'SA', GETDATE(), 'SA')
		END

		INSERT INTO inventory (idinventory, codeinventory, description, startnumber, flagmixed, idinventorykind, idinventoryagency, ct, cu, lt, lu)
		VALUES (@maxinv, 'FITTIZIA', 'Fittizia', 1, 'N', @maxinvkind, @maxinvagency, GETDATE(), 'SA', GETDATE(), 'SA')
	END

	INSERT INTO assetloadkind (idassetloadkind, description, flaglinear, startnumber, idinventory, ct, cu, lt, lu)
	SELECT DISTINCT idassetloadkind, idassetloadkind, 'S', 1, idinventory, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM assetacquire
	WHERE NOT EXISTS(SELECT * FROM assetloadkind WHERE assetloadkind.idassetloadkind = assetacquire.idassetloadkind)
	AND idassetloadkind IS NOT NULL
	
	INSERT INTO assetloadkind (idassetloadkind, description, flaglinear, startnumber, idinventory, ct, cu, lt, lu)
	SELECT DISTINCT idassetloadkind, idassetloadkind, 'S', 1, @maxinv, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM assetload
	WHERE NOT EXISTS(SELECT * FROM assetloadkind WHERE assetloadkind.idassetloadkind = assetload.idassetloadkind)
	
	INSERT INTO assetloadkind (idassetloadkind, description, flaglinear, startnumber, idinventory, ct, cu, lt, lu)
	SELECT DISTINCT idassetloadkind, idassetloadkind, 'S', 1, @maxinv, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM assetloadexpense
	WHERE NOT EXISTS(SELECT * FROM assetloadkind WHERE assetloadkind.idassetloadkind = assetloadexpense.idassetloadkind)
END

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadkind] ADD idassetloadkindint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'codeassetloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadkind] ADD codeassetloadkind varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [assetloadkind] ALTER COLUMN codeassetloadkind varchar(20) NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idassetloadkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN idassetloadkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetload] ADD idassetloadkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetload] ALTER COLUMN idassetloadkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadexpense] ADD idassetloadkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetloadexpense] ALTER COLUMN idassetloadkindint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'codeassetloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadkind SET codeassetloadkind = idassetloadkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idassetloadkindint = assetloadkind.idassetloadkindint
	FROM assetloadkind
	WHERE assetacquire.idassetloadkind = assetloadkind.idassetloadkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetload SET idassetloadkindint = assetloadkind.idassetloadkindint
	FROM assetloadkind
	WHERE assetload.idassetloadkind = assetloadkind.idassetloadkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadexpense SET idassetloadkindint = assetloadkind.idassetloadkindint
	FROM assetloadkind
	WHERE assetloadexpense.idassetloadkind = assetloadkind.idassetloadkind
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono assetloadkind, assetload, assetloadexpense
IF exists(SELECT * FROM sysconstraints where id=object_id('assetloadkind') and constid=object_id('xpkassetloadkind'))
BEGIN
	ALTER TABLE [assetloadkind] drop constraint xpkassetloadkind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetloadkind') and constid=object_id('PK_assetloadkind'))
BEGIN
	ALTER TABLE [assetloadkind] drop constraint PK_assetloadkind
END
GO

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
-- Tabelle interessate sono assetacquire, assetload
IF EXISTS (SELECT * FROM sysindexes where name='xi4assetacquire' and id=object_id('assetacquire'))
	drop index assetacquire.xi4assetacquire
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetload' and id=object_id('assetload'))
	drop index assetload.xi4assetload
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadkind'
		and C.name ='idassetloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadkind] DROP COLUMN idassetloadkind
	DELETE FROM columntypes WHERE tablename = 'assetloadkind' AND field = 'idassetloadkind'
END

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
		where t.name = 'assetload'
		and C.name ='idassetloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetload] DROP COLUMN idassetloadkind
	DELETE FROM columntypes WHERE tablename = 'assetload' AND field = 'idassetloadkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadexpense'
		and C.name ='idassetloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadexpense] DROP COLUMN idassetloadkind
	DELETE FROM columntypes WHERE tablename = 'assetloadexpense' AND field = 'idassetloadkind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'idassetloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadkind] ADD idassetloadkind int NULL 
END
ELSE
	ALTER TABLE [assetloadkind] ALTER COLUMN idassetloadkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idassetloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idassetloadkind int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idassetloadkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idassetloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetload] ADD idassetloadkind int NULL 
END
ELSE
	ALTER TABLE [assetload] ALTER COLUMN idassetloadkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idassetloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadexpense] ADD idassetloadkind int NULL 
END
ELSE
	ALTER TABLE [assetloadexpense] ALTER COLUMN idassetloadkind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadkind SET idassetloadkind = idassetloadkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idassetloadkind = idassetloadkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetload SET idassetloadkind = idassetloadkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idassetloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadexpense SET idassetloadkind = idassetloadkindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'idassetloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadkind] ALTER COLUMN idassetloadkind int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idassetloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetload] ALTER COLUMN idassetloadkind int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idassetloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadexpense] ALTER COLUMN idassetloadkind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'idassetloadkind' and C.name = 'codeassetloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadkind] ALTER COLUMN codeassetloadkind varchar(20) NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetloadkind') and constid=object_id('xpkassetloadkind'))
BEGIN
	ALTER TABLE [assetloadkind] ADD CONSTRAINT xpkassetloadkind PRIMARY KEY (idassetloadkind)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetloadkind') and constid=object_id('ukassetloadkind'))
BEGIN
	ALTER TABLE [assetloadkind] ADD CONSTRAINT ukassetloadkind UNIQUE (codeassetloadkind)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetload') and constid=object_id('xpkassetload'))
BEGIN
	ALTER TABLE [assetload] ADD CONSTRAINT xpkassetload PRIMARY KEY (idassetloadkind, yassetload, nassetload)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetloadexpense') and constid=object_id('xpkassetloadexpense'))
BEGIN
	ALTER TABLE [assetloadexpense] ADD CONSTRAINT xpkassetloadexpense PRIMARY KEY (idassetloadkind, yassetload, nassetload, idexp)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2assetloadkind' and id=object_id('assetloadkind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetloadkind ON assetloadkind (codeassetloadkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetloadkind
	ON assetloadkind (codeassetloadkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetacquire' and id=object_id('assetacquire'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4assetacquire ON assetacquire (idassetloadkind, yassetload, nassetload)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4assetacquire
	ON assetacquire (idassetloadkind, yassetload, nassetload)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetload' and id=object_id('assetload'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4assetload ON assetload (idassetloadkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4assetload
	ON assetload (idassetloadkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetacquire' AND field = 'idassetloadkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-23 13:53:00.890'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 13:53:00.890'} WHERE tablename = 'assetacquire' AND field = 'idassetloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetacquire','idassetloadkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-23 13:53:00.890'},'''NINO''','NINO',{ts '2007-10-23 13:53:00.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetload' AND field = 'idassetloadkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 13:53:01.733'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 13:53:01.733'} WHERE tablename = 'assetload' AND field = 'idassetloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetload','idassetloadkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 13:53:01.733'},'''NINO''','NINO',{ts '2007-10-23 13:53:01.733'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetloadexpense' AND field = 'idassetloadkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 13:53:01.953'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 13:53:01.953'} WHERE tablename = 'assetloadexpense' AND field = 'idassetloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetloadexpense','idassetloadkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 13:53:01.953'},'''NINO''','NINO',{ts '2007-10-23 13:53:01.953'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetloadkind' AND field = 'codeassetloadkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-23 13:53:11.733'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 13:53:11.733'} WHERE tablename = 'assetloadkind' AND field = 'codeassetloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetloadkind','codeassetloadkind','N','varchar','20',null,null,'System.String','varchar(20)','S','',null,'N',{ts '2007-10-23 13:53:11.733'},'''NINO''','NINO',{ts '2007-10-23 13:53:11.733'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetloadkind' AND field = 'idassetloadkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 13:53:11.733'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 13:53:11.733'} WHERE tablename = 'assetloadkind' AND field = 'idassetloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetloadkind','idassetloadkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 13:53:11.733'},'''NINO''','NINO',{ts '2007-10-23 13:53:11.733'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadkind'
		and C.name ='idassetloadkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadkind] DROP COLUMN idassetloadkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='idassetloadkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idassetloadkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetload'
		and C.name ='idassetloadkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetload] DROP COLUMN idassetloadkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadexpense'
		and C.name ='idassetloadkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadexpense] DROP COLUMN idassetloadkindint
END
GO
