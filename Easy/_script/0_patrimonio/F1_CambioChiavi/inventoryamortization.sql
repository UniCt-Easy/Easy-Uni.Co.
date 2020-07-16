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

﻿-- Aggiornamento tabella INVENTORYAMORTIZATION e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- assetamortization, inventorysortingamortizationyear

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO inventoryamortization (idinventoryamortization, description, calculationkind, flagivaapplying, flagofficial, flagamortization, ct, cu, lt, lu)
SELECT DISTINCT idinventoryamortization, idinventoryamortization, 'A', 'S', 'N', 'S' , GETDATE(), 'SA', GETDATE(), '''SA'''
FROM inventorysortingamortizationyear
WHERE NOT EXISTS(SELECT * FROM inventoryamortization WHERE inventoryamortization.idinventoryamortization = inventorysortingamortizationyear.idinventoryamortization)

INSERT INTO inventoryamortization (idinventoryamortization, description, calculationkind, flagivaapplying, flagofficial, flagamortization, ct, cu, lt, lu)
SELECT DISTINCT idinventoryamortization, idinventoryamortization, 'A', 'S', 'N', 'S' , GETDATE(), 'SA', GETDATE(), '''SA'''
FROM assetamortization
WHERE NOT EXISTS(SELECT * FROM inventoryamortization WHERE inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryamortization' and C.name = 'idinventoryamortizationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryamortization] ADD idinventoryamortizationint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryamortization' and C.name = 'codeinventoryamortization' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryamortization] ADD codeinventoryamortization varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [inventoryamortization] ALTER COLUMN codeinventoryamortization varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idinventoryamortizationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetamortization] ADD idinventoryamortizationint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetamortization] ALTER COLUMN idinventoryamortizationint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortingamortizationyear' and C.name = 'idinventoryamortizationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] ADD idinventoryamortizationint int NULL
END
ELSE
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] ALTER COLUMN idinventoryamortizationint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryamortization' and C.name = 'codeinventoryamortization' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventoryamortization SET codeinventoryamortization = idinventoryamortization
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idinventoryamortizationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetamortization SET idinventoryamortizationint = inventoryamortization.idinventoryamortizationint
	FROM inventoryamortization
	WHERE assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortingamortizationyear' and C.name = 'idinventoryamortizationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorysortingamortizationyear SET idinventoryamortizationint = inventoryamortization.idinventoryamortizationint
	FROM inventoryamortization
	WHERE inventorysortingamortizationyear.idinventoryamortization = inventoryamortization.idinventoryamortization
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono inventorykind
IF exists(SELECT * FROM sysconstraints where id=object_id('inventoryamortization') and constid=object_id('xpkinventoryamortization'))
BEGIN
	ALTER TABLE [inventoryamortization] drop constraint xpkinventoryamortization
END

IF exists(SELECT * FROM sysconstraints where id=object_id('inventoryamortization') and constid=object_id('PK_inventoryamortization'))
BEGIN
	ALTER TABLE [inventoryamortization] drop constraint PK_inventoryamortization
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorysortingamortizationyear') and constid=object_id('xpkinventorysortingamortizationyear'))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] drop constraint xpkinventorysortingamortizationyear
END

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorysortingamortizationyear') and constid=object_id('PK_inventorysortingamortizationyear'))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] drop constraint PK_inventorysortingamortizationyear
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetamortization
IF EXISTS (SELECT * FROM sysindexes where name='xi2assetamortization' and id=object_id('assetamortization'))
	drop index assetamortization.xi2assetamortization
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventoryamortization'
		and C.name ='idinventoryamortization'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventoryamortization] DROP COLUMN idinventoryamortization
	DELETE FROM columntypes WHERE tablename = 'inventoryamortization' AND field = 'idinventoryamortization'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetamortization'
		and C.name ='idinventoryamortization'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetamortization] DROP COLUMN idinventoryamortization
	DELETE FROM columntypes WHERE tablename = 'assetamortization' AND field = 'idinventoryamortization'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorysortingamortizationyear'
		and C.name ='idinventoryamortization'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] DROP COLUMN idinventoryamortization
	DELETE FROM columntypes WHERE tablename = 'inventorysortingamortizationyear' AND field = 'idinventoryamortization'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate inventoryamortization e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryamortization' and C.name = 'idinventoryamortization' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryamortization] ADD idinventoryamortization int NULL 
END
ELSE
	ALTER TABLE [inventoryamortization] ALTER COLUMN idinventoryamortization int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idinventoryamortization' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetamortization] ADD idinventoryamortization int NULL 
END
ELSE
	ALTER TABLE [assetamortization] ALTER COLUMN idinventoryamortization int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortingamortizationyear' and C.name = 'idinventoryamortization' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] ADD idinventoryamortization int NULL 
END
ELSE
	ALTER TABLE [inventorysortingamortizationyear] ALTER COLUMN idinventoryamortization int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryamortization' and C.name = 'idinventoryamortizationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventoryamortization SET idinventoryamortization = idinventoryamortizationint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idinventoryamortizationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetamortization SET idinventoryamortization = idinventoryamortizationint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortingamortizationyear' and C.name = 'idinventoryamortizationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorysortingamortizationyear SET idinventoryamortization = idinventoryamortizationint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryamortization' and C.name = 'idinventoryamortization' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryamortization] ALTER COLUMN idinventoryamortization int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetamortization' and C.name = 'idinventoryamortization' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetamortization] ALTER COLUMN idinventoryamortization int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortingamortizationyear' and C.name = 'idinventoryamortization' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] ALTER COLUMN idinventoryamortization int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventoryamortization' and C.name = 'codeinventoryamortization' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventoryamortization] ALTER COLUMN codeinventoryamortization varchar(20) NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventoryamortization') and constid=object_id('xpkinventoryamortization'))
BEGIN
	ALTER TABLE [inventoryamortization] ADD CONSTRAINT xpkinventoryamortization PRIMARY KEY (idinventoryamortization)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventoryamortization') and constid=object_id('ukinventoryamortization'))
BEGIN
	ALTER TABLE [inventoryamortization] ADD CONSTRAINT ukinventoryamortization UNIQUE (codeinventoryamortization)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventorysortingamortizationyear') and constid=object_id('xpkinventorysortingamortizationyear'))
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] ADD CONSTRAINT xpkinventorysortingamortizationyear PRIMARY KEY (ayear, idinv, idinventoryamortization)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1inventoryamortization' and id=object_id('inventoryamortization'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventoryamortization ON inventoryamortization (codeinventoryamortization)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventoryamortization
	ON inventoryamortization (codeinventoryamortization)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetamortization' and id=object_id('assetamortization'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetamortization ON assetamortization (idinventoryamortization)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetamortization
	ON assetamortization (idinventoryamortization)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetamortization' AND field = 'idinventoryamortization')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 12:47:43.750'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 12:47:43.750'} WHERE tablename = 'assetamortization' AND field = 'idinventoryamortization'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetamortization','idinventoryamortization','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 12:47:43.750'},'''NINO''','NINO',{ts '2007-10-24 12:47:43.750'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventoryamortization' AND field = 'codeinventoryamortization')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 12:47:53.797'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 12:47:53.797'} WHERE tablename = 'inventoryamortization' AND field = 'codeinventoryamortization'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventoryamortization','codeinventoryamortization','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-10-24 12:47:53.797'},'''NINO''','NINO',{ts '2007-10-24 12:47:53.797'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventoryamortization' AND field = 'idinventoryamortization')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 12:47:53.797'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 12:47:53.797'} WHERE tablename = 'inventoryamortization' AND field = 'idinventoryamortization'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventoryamortization','idinventoryamortization','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 12:47:53.797'},'''NINO''','NINO',{ts '2007-10-24 12:47:53.797'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorysortingamortizationyear' AND field = 'idinventoryamortization')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 12:47:54.187'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 12:47:54.187'} WHERE tablename = 'inventorysortingamortizationyear' AND field = 'idinventoryamortization'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorysortingamortizationyear','idinventoryamortization','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 12:47:54.187'},'''NINO''','NINO',{ts '2007-10-24 12:47:54.187'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventoryamortization'
		and C.name ='idinventoryamortizationint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventoryamortization] DROP COLUMN idinventoryamortizationint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetamortization'
		and C.name ='idinventoryamortizationint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetamortization] DROP COLUMN idinventoryamortizationint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorysortingamortizationyear'
		and C.name ='idinventoryamortizationint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorysortingamortizationyear] DROP COLUMN idinventoryamortizationint
END
GO
	