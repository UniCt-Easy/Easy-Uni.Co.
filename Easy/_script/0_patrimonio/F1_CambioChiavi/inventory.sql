
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


-- Aggiornamento tabella INVENTORY e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- assetacquire, assetloadkind, assetunloadkind, assetvardetail

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DECLARE @err int
SET @err =
	ISNULL(
		(SELECT COUNT(*)
		FROM assetacquire
		WHERE idinventory NOT IN
			(SELECT idinventory FROM inventory WHERE inventory.idinventory = assetacquire.idinventory)
		)
	,0) +
	ISNULL(
		(SELECT COUNT(*)
		FROM assetloadkind
		WHERE idinventory NOT IN
			(SELECT idinventory FROM inventory WHERE inventory.idinventory = assetloadkind.idinventory)
		)
	,0) +
	ISNULL(
		(SELECT COUNT(*)
		FROM assetunloadkind
		WHERE idinventory NOT IN
			(SELECT idinventory FROM inventory WHERE inventory.idinventory = assetunloadkind.idinventory)
		AND idinventory IS NOT NULL
		)
	,0) +
	ISNULL(
		(SELECT COUNT(*)
		FROM assetvardetail
		WHERE idinventory NOT IN
			(SELECT idinventory FROM inventory WHERE inventory.idinventory = assetvardetail.idinventory)
		AND idinventory IS NOT NULL
		)
	,0)

IF (@err > 0)
BEGIN
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

	INSERT INTO inventory (idinventory, description, startnumber, flagmixed, idinventorykind, idinventoryagency, ct, cu, lt, lu)
	SELECT DISTINCT idinventory, idinventory, 1, 'N', @maxinvkind, @maxinvagency, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM assetacquire
	WHERE NOT EXISTS(SELECT * FROM inventory WHERE inventory.idinventory = assetacquire.idinventory)

	INSERT INTO inventory (idinventory, description, startnumber, flagmixed, idinventorykind, idinventoryagency, ct, cu, lt, lu)
	SELECT DISTINCT idinventory, idinventory, 1, 'N', @maxinvkind, @maxinvagency, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM assetloadkind
	WHERE NOT EXISTS(SELECT * FROM inventory WHERE inventory.idinventory = assetloadkind.idinventory)

	INSERT INTO inventory (idinventory, description, startnumber, flagmixed, idinventorykind, idinventoryagency, ct, cu, lt, lu)
	SELECT DISTINCT idinventory, idinventory, 1, 'N', @maxinvkind, @maxinvagency, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM assetunloadkind
	WHERE NOT EXISTS(SELECT * FROM inventory WHERE inventory.idinventory = assetunloadkind.idinventory)
	AND idinventory IS NOT NULL

	INSERT INTO inventory (idinventory, description, startnumber, flagmixed, idinventorykind, idinventoryagency, ct, cu, lt, lu)
	SELECT DISTINCT idinventory, idinventory, 1, 'N', @maxinvkind, @maxinvagency, GETDATE(), 'SA', GETDATE(), '''SA'''
	FROM assetvardetail
	WHERE NOT EXISTS(SELECT * FROM inventory WHERE inventory.idinventory = assetvardetail.idinventory)
	AND idinventory IS NOT NULL
END

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventoryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ADD idinventoryint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'codeinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ADD codeinventory varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [inventory] ALTER COLUMN codeinventory varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinventoryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idinventoryint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN idinventoryint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'idinventoryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadkind] ADD idinventoryint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetloadkind] ALTER COLUMN idinventoryint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'idinventoryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadkind] ADD idinventoryint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetunloadkind] ALTER COLUMN idinventoryint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idinventoryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvardetail] ADD idinventoryint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetvardetail] ALTER COLUMN idinventoryint int NULL
END
GO
-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'codeinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventory SET codeinventory = idinventory
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinventoryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idinventoryint = inventory.idinventoryint
	FROM inventory
	WHERE assetacquire.idinventory = inventory.idinventory
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'idinventoryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadkind SET idinventoryint = inventory.idinventoryint
	FROM inventory
	WHERE assetloadkind.idinventory = inventory.idinventory
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'idinventoryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadkind SET idinventoryint = inventory.idinventoryint
	FROM inventory
	WHERE assetunloadkind.idinventory = inventory.idinventory
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idinventoryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetvardetail SET idinventoryint = inventory.idinventoryint
	FROM inventory
	WHERE assetvardetail.idinventory = inventory.idinventory
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono inventory
IF exists(SELECT * FROM sysconstraints where id=object_id('inventory') and constid=object_id('xpkinventory'))
BEGIN
	ALTER TABLE [inventory] drop constraint xpkinventory
END

IF exists(SELECT * FROM sysconstraints where id=object_id('inventory') and constid=object_id('PK_inventory'))
BEGIN
	ALTER TABLE [inventory] drop constraint PK_inventory
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetacquire, assetloadkind, assetunloadkind, assetvardetail
IF EXISTS (SELECT * FROM sysindexes where name='xi6assetacquire' and id=object_id('assetacquire'))
	drop index assetacquire.xi6assetacquire
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetloadkind' and id=object_id('assetloadkind'))
	drop index assetloadkind.xi1assetloadkind
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetunloadkind' and id=object_id('assetunloadkind'))
	drop index assetunloadkind.xi1assetunloadkind
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventory'
		and C.name ='idinventory'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventory] DROP COLUMN idinventory
	DELETE FROM columntypes WHERE tablename = 'inventory' AND field = 'idinventory'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='idinventory'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idinventory
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'idinventory'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadkind'
		and C.name ='idinventory'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadkind] DROP COLUMN idinventory
	DELETE FROM columntypes WHERE tablename = 'assetloadkind' AND field = 'idinventory'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadkind'
		and C.name ='idinventory'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadkind] DROP COLUMN idinventory
	DELETE FROM columntypes WHERE tablename = 'assetunloadkind' AND field = 'idinventory'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvardetail'
		and C.name ='idinventory'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvardetail] DROP COLUMN idinventory
	DELETE FROM columntypes WHERE tablename = 'assetvardetail' AND field = 'idinventory'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate inventory e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ADD idinventory int NULL 
END
ELSE
	ALTER TABLE [inventory] ALTER COLUMN idinventory int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idinventory int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idinventory int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadkind] ADD idinventory int NULL 
END
ELSE
	ALTER TABLE [assetloadkind] ALTER COLUMN idinventory int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadkind] ADD idinventory int NULL 
END
ELSE
	ALTER TABLE [assetunloadkind] ALTER COLUMN idinventory int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvardetail] ADD idinventory int NULL 
END
ELSE
	ALTER TABLE [assetvardetail] ALTER COLUMN idinventory int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventory SET idinventory = idinventoryint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idinventory = idinventoryint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadkind SET idinventory = idinventoryint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadkind' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadkind SET idinventory = idinventoryint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetvardetail SET idinventory = idinventoryint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ALTER COLUMN idinventory int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'codeinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ALTER COLUMN codeinventory varchar(20) NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN idinventory int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadkind' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadkind] ALTER COLUMN idinventory int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventory') and constid=object_id('xpkinventory'))
BEGIN
	ALTER TABLE [inventory] ADD CONSTRAINT xpkinventory PRIMARY KEY (idinventory)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventory') and constid=object_id('ukinventory'))
BEGIN
	ALTER TABLE [inventory] ADD CONSTRAINT ukinventory UNIQUE (codeinventory)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi3inventory' and id=object_id('inventory'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3inventory ON inventory (codeinventory)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3inventory
	ON inventory (codeinventory)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6assetacquire' and id=object_id('assetacquire'))
BEGIN
	CREATE NONCLUSTERED INDEX xi6assetacquire ON assetacquire (idinventory)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi6assetacquire
	ON assetacquire (idinventory)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetloadkind' and id=object_id('assetloadkind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetloadkind ON assetloadkind (idinventory)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetloadkind
	ON assetloadkind (idinventory)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetunloadkind' and id=object_id('assetunloadkind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetunloadkind ON assetunloadkind (idinventory)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetunloadkind
	ON assetunloadkind (idinventory)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetvardetail' and id=object_id('assetvardetail'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3assetvardetail ON assetvardetail (idinventory)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3assetvardetail
	ON assetvardetail (idinventory)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetacquire' AND field = 'idinventory')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 09:18:13.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 09:18:13.577'} WHERE tablename = 'assetacquire' AND field = 'idinventory'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetacquire','idinventory','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 09:18:13.577'},'''NINO''','NINO',{ts '2007-10-23 09:18:13.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetloadkind' AND field = 'idinventory')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 09:18:23.983'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 09:18:23.983'} WHERE tablename = 'assetloadkind' AND field = 'idinventory'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetloadkind','idinventory','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 09:18:23.983'},'''NINO''','NINO',{ts '2007-10-23 09:18:23.983'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunloadkind' AND field = 'idinventory')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-23 09:18:16.797'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 09:18:16.797'} WHERE tablename = 'assetunloadkind' AND field = 'idinventory'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunloadkind','idinventory','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-23 09:18:16.797'},'''NINO''','NINO',{ts '2007-10-23 09:18:16.797'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetvardetail' AND field = 'idinventory')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-23 09:18:08.453'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 09:18:08.453'} WHERE tablename = 'assetvardetail' AND field = 'idinventory'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetvardetail','idinventory','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-23 09:18:08.453'},'''NINO''','NINO',{ts '2007-10-23 09:18:08.453'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventory' AND field = 'codeinventory')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 09:18:23.140'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 09:18:23.140'} WHERE tablename = 'inventory' AND field = 'codeinventory'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventory','codeinventory','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-10-23 09:18:23.140'},'''NINO''','NINO',{ts '2007-10-23 09:18:23.140'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventory' AND field = 'idinventory')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 09:18:23.140'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 09:18:23.140'} WHERE tablename = 'inventory' AND field = 'idinventory'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventory','idinventory','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 09:18:23.140'},'''NINO''','NINO',{ts '2007-10-23 09:18:23.140'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventory'
		and C.name ='idinventoryint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventory] DROP COLUMN idinventoryint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='idinventoryint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idinventoryint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadkind'
		and C.name ='idinventoryint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadkind] DROP COLUMN idinventoryint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadkind'
		and C.name ='idinventoryint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadkind] DROP COLUMN idinventoryint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvardetail'
		and C.name ='idinventoryint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvardetail] DROP COLUMN idinventoryint
END
GO
