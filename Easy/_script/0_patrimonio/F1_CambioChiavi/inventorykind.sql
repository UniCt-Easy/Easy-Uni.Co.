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

﻿-- Aggiornamento tabella INVENTORYKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- inventory

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO inventorykind (idinventorykind, description, flagdiscount, ct, cu, lt, lu)
SELECT DISTINCT idinventorykind, idinventorykind, 'N', GETDATE(), 'SA', GETDATE(), '''SA'''
FROM inventory
WHERE NOT EXISTS(SELECT * FROM inventorykind WHERE inventorykind.idinventorykind = inventory.idinventorykind)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorykind' and C.name = 'idinventorykindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorykind] ADD idinventorykindint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorykind' and C.name = 'codeinventorykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorykind] ADD codeinventorykind varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [inventorykind] ALTER COLUMN codeinventorykind varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventorykindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ADD idinventorykindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [inventory] ALTER COLUMN idinventorykindint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorykind' and C.name = 'codeinventorykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorykind SET codeinventorykind = idinventorykind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventorykindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventory SET idinventorykindint = inventorykind.idinventorykindint
	FROM inventorykind
	WHERE inventory.idinventorykind = inventorykind.idinventorykind
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono inventorykind
IF exists(SELECT * FROM sysconstraints where id=object_id('inventorykind') and constid=object_id('xpkinventorykind'))
BEGIN
	ALTER TABLE [inventorykind] drop constraint xpkinventorykind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorykind') and constid=object_id('PK_inventorykind'))
BEGIN
	ALTER TABLE [inventorykind] drop constraint PK_inventorykind
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono inventory

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventory' and id=object_id('inventory'))
	drop index inventory.xi1inventory
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorykind'
		and C.name ='idinventorykind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorykind] DROP COLUMN idinventorykind
	DELETE FROM columntypes WHERE tablename = 'inventorykind' AND field = 'idinventorykind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventory'
		and C.name ='idinventorykind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventory] DROP COLUMN idinventorykind
	DELETE FROM columntypes WHERE tablename = 'inventory' AND field = 'idinventorykind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorykind' and C.name = 'idinventorykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorykind] ADD idinventorykind int NULL 
END
ELSE
	ALTER TABLE [inventorykind] ALTER COLUMN idinventorykind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventorykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ADD idinventorykind int NULL 
END
ELSE
	ALTER TABLE [inventory] ALTER COLUMN idinventorykind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorykind' and C.name = 'idinventorykindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorykind SET idinventorykind = idinventorykindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventorykindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventory SET idinventorykind = idinventorykindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorykind' and C.name = 'idinventorykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorykind] ALTER COLUMN idinventorykind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorykind' and C.name = 'codeinventorykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorykind] ALTER COLUMN codeinventorykind varchar(20) NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventory' and C.name = 'idinventorykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventory] ALTER COLUMN idinventorykind int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventorykind') and constid=object_id('xpkinventorykind'))
BEGIN
	ALTER TABLE [inventorykind] ADD CONSTRAINT xpkinventorykind PRIMARY KEY (idinventorykind)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventorykind') and constid=object_id('ukinventorykind'))
BEGIN
	ALTER TABLE [inventorykind] ADD CONSTRAINT ukinventorykind UNIQUE (codeinventorykind)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorykind' and id=object_id('inventorykind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventorykind ON inventorykind (codeinventorykind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventorykind
	ON inventorykind (codeinventorykind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventory' and id=object_id('inventory'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventory ON inventory (idinventorykind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventory
	ON inventory (idinventorykind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventory' AND field = 'idinventorykind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 11:14:21.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 11:14:21.577'} WHERE tablename = 'inventory' AND field = 'idinventorykind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventory','idinventorykind','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-22 11:14:21.577'},'''NINO''','NINO',{ts '2007-10-22 11:14:21.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorykind' AND field = 'codeinventorykind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 11:14:22.000'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 11:14:22.000'} WHERE tablename = 'inventorykind' AND field = 'codeinventorykind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorykind','codeinventorykind','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-10-22 11:14:22.000'},'''NINO''','NINO',{ts '2007-10-22 11:14:22.000'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorykind' AND field = 'idinventorykind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 11:14:22.000'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 11:14:22.000'} WHERE tablename = 'inventorykind' AND field = 'idinventorykind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorykind','idinventorykind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-22 11:14:22.000'},'''NINO''','NINO',{ts '2007-10-22 11:14:22.000'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorykind'
		and C.name ='idinventorykindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorykind] DROP COLUMN idinventorykindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventory'
		and C.name ='idinventorykindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventory] DROP COLUMN idinventorykindint
END
GO
	