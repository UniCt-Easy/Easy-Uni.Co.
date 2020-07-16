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

﻿-- Aggiornamento tabella INVENTORYAGENCY e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- inventory, assetconsignee, assetvar

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO inventoryagency (idinventoryagency, agencycode, description, ct, cu, lt, lu)
SELECT DISTINCT idinventoryagency, NULL, idinventoryagency, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM inventory
WHERE NOT EXISTS(SELECT * FROM inventoryagency WHERE inventoryagency.idinventoryagency = inventory.idinventoryagency)
GO

INSERT INTO inventoryagency (idinventoryagency, agencycode, description, ct, cu, lt, lu)
SELECT DISTINCT idinventoryagency, NULL, idinventoryagency, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM assetvar
WHERE NOT EXISTS(SELECT * FROM inventoryagency WHERE inventoryagency.idinventoryagency = assetvar.idinventoryagency)
GO

INSERT INTO inventoryagency (idinventoryagency, agencycode, description, ct, cu, lt, lu)
SELECT DISTINCT idinventoryagency, NULL, idinventoryagency, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM assetconsignee
WHERE NOT EXISTS(SELECT * FROM inventoryagency WHERE inventoryagency.idinventoryagency = assetconsignee.idinventoryagency)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryagency' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryagency] ADD idinventoryagencyint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryagency' and C.name = 'codeinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryagency] ADD codeinventoryagency varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [inventoryagency] ALTER COLUMN codeinventoryagency varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ADD idinventoryagencyint int NULL
END
ELSE
BEGIN
	ALTER TABLE [inventory] ALTER COLUMN idinventoryagencyint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetconsignee' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetconsignee] ADD idinventoryagencyint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetconsignee] ALTER COLUMN idinventoryagencyint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvar' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvar] ADD idinventoryagencyint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetvar] ALTER COLUMN idinventoryagencyint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryagency' and C.name = 'codeinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventoryagency SET codeinventoryagency = idinventoryagency
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventory SET idinventoryagencyint = inventoryagency.idinventoryagencyint
	FROM inventoryagency
	WHERE inventory.idinventoryagency = inventoryagency.idinventoryagency
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetconsignee' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetconsignee SET idinventoryagencyint = inventoryagency.idinventoryagencyint
	FROM inventoryagency
	WHERE assetconsignee.idinventoryagency = inventoryagency.idinventoryagency
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvar' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetvar SET idinventoryagencyint = inventoryagency.idinventoryagencyint
	FROM inventoryagency
	WHERE assetvar.idinventoryagency = inventoryagency.idinventoryagency
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono inventoryagency, assetconsignee
IF exists(SELECT * FROM sysconstraints where id=object_id('inventoryagency') and constid=object_id('xpkinventoryagency'))
BEGIN
	ALTER TABLE [inventoryagency] drop constraint xpkinventoryagency
END

IF exists(SELECT * FROM sysconstraints where id=object_id('inventoryagency') and constid=object_id('PK_inventoryagency'))
BEGIN
	ALTER TABLE [inventoryagency] drop constraint PK_inventoryagency
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('assetconsignee') and constid=object_id('xpkassetconsignee'))
BEGIN
	ALTER TABLE [assetconsignee] drop constraint xpkassetconsignee
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetconsignee') and constid=object_id('PK_assetconsignee'))
BEGIN
	ALTER TABLE [assetconsignee] drop constraint PK_assetconsignee
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono inventory, assetvar
IF EXISTS (SELECT * FROM sysindexes where name='xi2inventory' and id=object_id('inventory'))
	drop index inventory.xi2inventory
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetvar' and id=object_id('assetvar'))
	drop index assetvar.xi1assetvar
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventoryagency'
		and C.name ='idinventoryagency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventoryagency] DROP COLUMN idinventoryagency
	DELETE FROM columntypes WHERE tablename = 'inventoryagency' AND field = 'idinventoryagency'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventory'
		and C.name ='idinventoryagency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventory] DROP COLUMN idinventoryagency
	DELETE FROM columntypes WHERE tablename = 'inventory' AND field = 'idinventoryagency'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetconsignee'
		and C.name ='idinventoryagency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetconsignee] DROP COLUMN idinventoryagency
	DELETE FROM columntypes WHERE tablename = 'assetconsignee' AND field = 'idinventoryagency'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvar'
		and C.name ='idinventoryagency'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvar] DROP COLUMN idinventoryagency
	DELETE FROM columntypes WHERE tablename = 'assetvar' AND field = 'idinventoryagency'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate inventoryagency e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryagency' and C.name = 'idinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryagency] ADD idinventoryagency int NULL 
END
ELSE
	ALTER TABLE [inventoryagency] ALTER COLUMN idinventoryagency int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ADD idinventoryagency int NULL 
END
ELSE
	ALTER TABLE [inventory] ALTER COLUMN idinventoryagency int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetconsignee' and C.name = 'idinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetconsignee] ADD idinventoryagency int NULL 
END
ELSE
	ALTER TABLE [assetconsignee] ALTER COLUMN idinventoryagency int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvar' and C.name = 'idinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvar] ADD idinventoryagency int NULL 
END
ELSE
	ALTER TABLE [assetvar] ALTER COLUMN idinventoryagency int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryagency' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventoryagency SET idinventoryagency = idinventoryagencyint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventory SET idinventoryagency = idinventoryagencyint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetconsignee' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetconsignee SET idinventoryagency = idinventoryagencyint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvar' and C.name = 'idinventoryagencyint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetvar SET idinventoryagency = idinventoryagencyint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryagency' and C.name = 'idinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryagency] ALTER COLUMN idinventoryagency int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetconsignee' and C.name = 'idinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetconsignee] ALTER COLUMN idinventoryagency int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryagency' and C.name = 'codeinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryagency] ALTER COLUMN codeinventoryagency varchar(20) NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ALTER COLUMN idinventoryagency int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvar' and C.name = 'idinventoryagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvar] ALTER COLUMN idinventoryagency int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventoryagency') and constid=object_id('xpkinventoryagency'))
BEGIN
	ALTER TABLE [inventoryagency] ADD CONSTRAINT xpkinventoryagency PRIMARY KEY (idinventoryagency)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventoryagency') and constid=object_id('ukinventoryagency'))
BEGIN
	ALTER TABLE [inventoryagency] ADD CONSTRAINT ukinventoryagency UNIQUE (codeinventoryagency)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetconsignee') and constid=object_id('xpkassetconsignee'))
BEGIN
	ALTER TABLE [assetconsignee] ADD CONSTRAINT xpkassetconsignee PRIMARY KEY (idinventoryagency, start)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1inventoryagency' and id=object_id('inventoryagency'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventoryagency ON inventoryagency (codeinventoryagency)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventoryagency
	ON inventoryagency (codeinventoryagency)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2inventory' and id=object_id('inventory'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2inventory ON inventory (idinventoryagency)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2inventory
	ON inventory (idinventoryagency)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetvar' and id=object_id('assetvar'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetvar ON assetvar (idinventoryagency)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetvar
	ON assetvar (idinventoryagency)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetconsignee' AND field = 'idinventoryagency')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 12:00:04.500'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 12:00:04.500'} WHERE tablename = 'assetconsignee' AND field = 'idinventoryagency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetconsignee','idinventoryagency','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-22 12:00:04.500'},'''NINO''','NINO',{ts '2007-10-22 12:00:04.500'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetvar' AND field = 'idinventoryagency')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 12:00:07.640'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 12:00:07.640'} WHERE tablename = 'assetvar' AND field = 'idinventoryagency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetvar','idinventoryagency','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-22 12:00:07.640'},'''NINO''','NINO',{ts '2007-10-22 12:00:07.640'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventory' AND field = 'idinventoryagency')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 12:00:12.360'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 12:00:12.360'} WHERE tablename = 'inventory' AND field = 'idinventoryagency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventory','idinventoryagency','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-22 12:00:12.360'},'''NINO''','NINO',{ts '2007-10-22 12:00:12.360'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventoryagency' AND field = 'codeinventoryagency')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 12:00:12.500'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 12:00:12.500'} WHERE tablename = 'inventoryagency' AND field = 'codeinventoryagency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventoryagency','codeinventoryagency','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-10-22 12:00:12.500'},'''NINO''','NINO',{ts '2007-10-22 12:00:12.500'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventoryagency' AND field = 'idinventoryagency')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 12:00:12.500'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 12:00:12.500'} WHERE tablename = 'inventoryagency' AND field = 'idinventoryagency'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventoryagency','idinventoryagency','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-22 12:00:12.500'},'''NINO''','NINO',{ts '2007-10-22 12:00:12.500'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventoryagency'
		and C.name ='idinventoryagencyint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventoryagency] DROP COLUMN idinventoryagencyint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventory'
		and C.name ='idinventoryagencyint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventory] DROP COLUMN idinventoryagencyint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetconsignee'
		and C.name ='idinventoryagencyint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetconsignee] DROP COLUMN idinventoryagencyint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvar'
		and C.name ='idinventoryagencyint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvar] DROP COLUMN idinventoryagencyint
END
GO
	