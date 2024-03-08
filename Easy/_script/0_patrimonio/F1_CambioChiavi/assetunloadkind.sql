
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


-- Aggiornamento tabella ASSETUNLOADKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- asset, assetamortization, assetunload, assetunloadincome

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DECLARE @err int
SET @err =
	ISNULL(
		(SELECT COUNT(*)
		FROM asset
		WHERE idassetunloadkind NOT IN
			(SELECT idassetunloadkind FROM assetunloadkind WHERE assetunloadkind.idassetunloadkind = asset.idassetunloadkind)
		AND idassetunloadkind IS NOT NULL
		)
	,0) +
	ISNULL(
		(SELECT COUNT(*)
		FROM assetamortization
		WHERE idassetunloadkind NOT IN
			(SELECT idassetunloadkind FROM assetunloadkind WHERE assetunloadkind.idassetunloadkind = assetamortization.idassetunloadkind)
		AND idassetunloadkind IS NOT NULL
		)
	,0) +
	ISNULL(
		(SELECT COUNT(*)
		FROM assetunload
		WHERE idassetunloadkind NOT IN
			(SELECT idassetunloadkind FROM assetunloadkind WHERE assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind)
		)
	,0) +
	ISNULL(
		(SELECT COUNT(*)
		FROM assetunloadincome
		WHERE idassetunloadkind NOT IN
			(SELECT idassetunloadkind FROM assetunloadkind WHERE assetunloadkind.idassetunloadkind = assetunloadincome.idassetunloadkind)
		AND idassetunloadkind IS NOT NULL
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

	INSERT INTO assetunloadkind (idassetunloadkind, description, flaglinear, startnumber, idinventory, ct, cu, lt, lu)
	SELECT DISTINCT idassetunloadkind, idassetunloadkind, 'S', 1, @maxinv, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM asset
	WHERE NOT EXISTS(SELECT * FROM assetunloadkind WHERE assetunloadkind.idassetunloadkind = asset.idassetunloadkind)
	AND idassetunloadkind IS NOT NULL

	INSERT INTO assetunloadkind (idassetunloadkind, description, flaglinear, startnumber, idinventory, ct, cu, lt, lu)
	SELECT DISTINCT idassetunloadkind, idassetunloadkind, 'S', 1, @maxinv, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM assetamortization
	WHERE NOT EXISTS(SELECT * FROM assetunloadkind WHERE assetunloadkind.idassetunloadkind = assetamortization.idassetunloadkind)
	AND idassetunloadkind IS NOT NULL
	
	INSERT INTO assetunloadkind (idassetunloadkind, description, flaglinear, startnumber, idinventory, ct, cu, lt, lu)
	SELECT DISTINCT idassetunloadkind, idassetunloadkind, 'S', 1, @maxinv, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM assetunload
	WHERE NOT EXISTS(SELECT * FROM assetunloadkind WHERE assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind)
	
	INSERT INTO assetunloadkind (idassetunloadkind, description, flaglinear, startnumber, idinventory, ct, cu, lt, lu)
	SELECT DISTINCT idassetunloadkind, idassetunloadkind, 'S', 1, @maxinv, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM assetunloadincome
	WHERE NOT EXISTS(SELECT * FROM assetunloadkind WHERE assetunloadkind.idassetunloadkind = assetunloadincome.idassetunloadkind)
END

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadkind] ADD idassetunloadkindint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'codeassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadkind] ADD codeassetunloadkind varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [assetunloadkind] ALTER COLUMN codeassetunloadkind varchar(20) NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idassetunloadkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [asset] ALTER COLUMN idassetunloadkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetamortization] ADD idassetunloadkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetamortization] ALTER COLUMN idassetunloadkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunload] ADD idassetunloadkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetunload] ALTER COLUMN idassetunloadkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadincome] ADD idassetunloadkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetunloadincome] ALTER COLUMN idassetunloadkindint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'codeassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadkind SET codeassetunloadkind = idassetunloadkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE asset SET idassetunloadkindint = assetunloadkind.idassetunloadkindint
	FROM assetunloadkind
	WHERE asset.idassetunloadkind = assetunloadkind.idassetunloadkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetamortization SET idassetunloadkindint = assetunloadkind.idassetunloadkindint
	FROM assetunloadkind
	WHERE assetamortization.idassetunloadkind = assetunloadkind.idassetunloadkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunload SET idassetunloadkindint = assetunloadkind.idassetunloadkindint
	FROM assetunloadkind
	WHERE assetunload.idassetunloadkind = assetunloadkind.idassetunloadkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadincome SET idassetunloadkindint = assetunloadkind.idassetunloadkindint
	FROM assetunloadkind
	WHERE assetunloadincome.idassetunloadkind = assetunloadkind.idassetunloadkind
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono assetunloadkind, assetunload, assetunloadincome
IF exists(SELECT * FROM sysconstraints where id=object_id('assetunloadkind') and constid=object_id('xpkassetunloadkind'))
BEGIN
	ALTER TABLE [assetunloadkind] drop constraint xpkassetunloadkind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetunloadkind') and constid=object_id('PK_assetunloadkind'))
BEGIN
	ALTER TABLE [assetunloadkind] drop constraint PK_assetunloadkind
END
GO

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
-- Tabelle interessate sono assetamortization, assetunload
IF EXISTS (SELECT * FROM sysindexes where name='xi3assetamortization' and id=object_id('assetamortization'))
	drop index assetamortization.xi3assetamortization
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetunload' and id=object_id('assetunload'))
	drop index assetunload.xi4assetunload
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadkind'
		and C.name ='idassetunloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadkind] DROP COLUMN idassetunloadkind
	DELETE FROM columntypes WHERE tablename = 'assetunloadkind' AND field = 'idassetunloadkind'
END

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
		where t.name = 'assetamortization'
		and C.name ='idassetunloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetamortization] DROP COLUMN idassetunloadkind
	DELETE FROM columntypes WHERE tablename = 'assetamortization' AND field = 'idassetunloadkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunload'
		and C.name ='idassetunloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunload] DROP COLUMN idassetunloadkind
	DELETE FROM columntypes WHERE tablename = 'assetunload' AND field = 'idassetunloadkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadincome'
		and C.name ='idassetunloadkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadincome] DROP COLUMN idassetunloadkind
	DELETE FROM columntypes WHERE tablename = 'assetunloadincome' AND field = 'idassetunloadkind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'idassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadkind] ADD idassetunloadkind int NULL 
END
ELSE
	ALTER TABLE [assetunloadkind] ALTER COLUMN idassetunloadkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idassetunloadkind int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idassetunloadkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetamortization] ADD idassetunloadkind int NULL 
END
ELSE
	ALTER TABLE [assetamortization] ALTER COLUMN idassetunloadkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunload] ADD idassetunloadkind int NULL 
END
ELSE
	ALTER TABLE [assetunload] ALTER COLUMN idassetunloadkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadincome] ADD idassetunloadkind int NULL 
END
ELSE
	ALTER TABLE [assetunloadincome] ALTER COLUMN idassetunloadkind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadkind SET idassetunloadkind = idassetunloadkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE asset SET idassetunloadkind = idassetunloadkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetamortization SET idassetunloadkind = idassetunloadkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunload SET idassetunloadkind = idassetunloadkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idassetunloadkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadincome SET idassetunloadkind = idassetunloadkindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'idassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadkind] ALTER COLUMN idassetunloadkind int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunload] ALTER COLUMN idassetunloadkind int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadincome] ALTER COLUMN idassetunloadkind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'codeassetunloadkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadkind] ALTER COLUMN codeassetunloadkind varchar(20) NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetunloadkind') and constid=object_id('xpkassetunloadkind'))
BEGIN
	ALTER TABLE [assetunloadkind] ADD CONSTRAINT xpkassetunloadkind PRIMARY KEY (idassetunloadkind)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetunloadkind') and constid=object_id('ukassetunloadkind'))
BEGIN
	ALTER TABLE [assetunloadkind] ADD CONSTRAINT ukassetunloadkind UNIQUE (codeassetunloadkind)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetunload') and constid=object_id('xpkassetunload'))
BEGIN
	ALTER TABLE [assetunload] ADD CONSTRAINT xpkassetunload PRIMARY KEY (idassetunloadkind, yassetunload, nassetunload)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetunloadincome') and constid=object_id('xpkassetunloadincome'))
BEGIN
	ALTER TABLE [assetunloadincome] ADD CONSTRAINT xpkassetunloadincome PRIMARY KEY (idassetunloadkind, yassetunload, nassetunload, idinc)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2assetunloadkind' and id=object_id('assetloadkind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetunloadkind ON assetunloadkind (codeassetunloadkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetunloadkind
	ON assetunloadkind (codeassetunloadkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetamortization' and id=object_id('assetamortization'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3assetamortization ON assetamortization (idassetunloadkind, yassetunload, nassetunload)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3assetamortization
	ON assetamortization (idassetunloadkind, yassetunload, nassetunload)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetunload' and id=object_id('assetunload'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4assetunload ON assetunload (idassetunloadkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4assetunload
	ON assetunload (idassetunloadkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'asset' AND field = 'idassetunloadkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-23 16:00:01.140'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 16:00:01.140'} WHERE tablename = 'asset' AND field = 'idassetunloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('asset','idassetunloadkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-23 16:00:01.140'},'''NINO''','NINO',{ts '2007-10-23 16:00:01.140'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetamortization' AND field = 'idassetunloadkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-23 16:00:01.797'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 16:00:01.797'} WHERE tablename = 'assetamortization' AND field = 'idassetunloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetamortization','idassetunloadkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-23 16:00:01.797'},'''NINO''','NINO',{ts '2007-10-23 16:00:01.797'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunload' AND field = 'idassetunloadkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 16:00:04.077'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 16:00:04.077'} WHERE tablename = 'assetunload' AND field = 'idassetunloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunload','idassetunloadkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 16:00:04.077'},'''NINO''','NINO',{ts '2007-10-23 16:00:04.077'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunloadincome' AND field = 'idassetunloadkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 16:00:04.517'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 16:00:04.517'} WHERE tablename = 'assetunloadincome' AND field = 'idassetunloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunloadincome','idassetunloadkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 16:00:04.517'},'''NINO''','NINO',{ts '2007-10-23 16:00:04.517'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunloadkind' AND field = 'codeassetunloadkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 16:00:04.890'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 16:00:04.890'} WHERE tablename = 'assetunloadkind' AND field = 'codeassetunloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunloadkind','codeassetunloadkind','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-10-23 16:00:04.890'},'''NINO''','NINO',{ts '2007-10-23 16:00:04.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunloadkind' AND field = 'idassetunloadkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 16:00:04.890'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 16:00:04.890'} WHERE tablename = 'assetunloadkind' AND field = 'idassetunloadkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunloadkind','idassetunloadkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 16:00:04.890'},'''NINO''','NINO',{ts '2007-10-23 16:00:04.890'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadkind'
		and C.name ='idassetunloadkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadkind] DROP COLUMN idassetunloadkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunload'
		and C.name ='idassetunloadkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunload] DROP COLUMN idassetunloadkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='idassetunloadkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN idassetunloadkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetamortization'
		and C.name ='idassetunloadkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetamortization] DROP COLUMN idassetunloadkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadincome'
		and C.name ='idassetunloadkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadincome] DROP COLUMN idassetunloadkindint
END
GO
