
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


-- Aggiornamento tabella MAINTENANCEKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- maintenance

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO maintenancekind (idmaintenancekind, description, ct, cu, lt, lu)
SELECT DISTINCT idmaintenancekind, idmaintenancekind, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM maintenance
WHERE NOT EXISTS(SELECT * FROM maintenancekind WHERE maintenancekind.idmaintenancekind = maintenance.idmaintenancekind)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenancekind' and C.name = 'idmaintenancekindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [maintenancekind] ADD idmaintenancekindint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenancekind' and C.name = 'codemaintenancekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [maintenancekind] ADD codemaintenancekind varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [maintenancekind] ALTER COLUMN codemaintenancekind varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenance' and C.name = 'idmaintenancekindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [maintenance] ADD idmaintenancekindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [maintenance] ALTER COLUMN idmaintenancekindint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenancekind' and C.name = 'codemaintenancekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE maintenancekind SET codemaintenancekind = idmaintenancekind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenance' and C.name = 'idmaintenancekindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE maintenance SET idmaintenancekindint = maintenancekind.idmaintenancekindint
	FROM maintenancekind
	WHERE maintenance.idmaintenancekind = maintenancekind.idmaintenancekind
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono maintenancekind
IF exists(SELECT * FROM sysconstraints where id=object_id('maintenancekind') and constid=object_id('xpkmaintenancekind'))
BEGIN
	ALTER TABLE [maintenancekind] drop constraint xpkmaintenancekind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('maintenancekind') and constid=object_id('PK_maintenancekind'))
BEGIN
	ALTER TABLE [maintenancekind] drop constraint PK_maintenancekind
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetacquire, assetload
IF EXISTS (SELECT * FROM sysindexes where name='xi2maintenance' and id=object_id('maintenance'))
	drop index maintenance.xi2maintenance
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'maintenancekind'
		and C.name ='idmaintenancekind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [maintenancekind] DROP COLUMN idmaintenancekind
	DELETE FROM columntypes WHERE tablename = 'maintenancekind' AND field = 'idmaintenancekind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'maintenance'
		and C.name ='idmaintenancekind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [maintenance] DROP COLUMN idmaintenancekind
	DELETE FROM columntypes WHERE tablename = 'maintenance' AND field = 'idmaintenancekind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate maintenancekind e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenancekind' and C.name = 'idmaintenancekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [maintenancekind] ADD idmaintenancekind int NULL 
END
ELSE
	ALTER TABLE [maintenancekind] ALTER COLUMN idmaintenancekind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenance' and C.name = 'idmaintenancekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [maintenance] ADD idmaintenancekind int NULL 
END
ELSE
	ALTER TABLE [maintenance] ALTER COLUMN idmaintenancekind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenancekind' and C.name = 'idmaintenancekindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE maintenancekind SET idmaintenancekind = idmaintenancekindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenance' and C.name = 'idmaintenancekindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE maintenance SET idmaintenancekind = idmaintenancekindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenancekind' and C.name = 'idmaintenancekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [maintenancekind] ALTER COLUMN idmaintenancekind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenancekind' and C.name = 'codemaintenancekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [maintenancekind] ALTER COLUMN codemaintenancekind varchar(20) NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'maintenance' and C.name = 'idmaintenancekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [maintenance] ALTER COLUMN idmaintenancekind varchar(20) NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('maintenancekind') and constid=object_id('xpkmaintenancekind'))
BEGIN
	ALTER TABLE [maintenancekind] ADD CONSTRAINT xpkmaintenancekind PRIMARY KEY (idmaintenancekind)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('maintenancekind') and constid=object_id('ukmaintenancekind'))
BEGIN
	ALTER TABLE [maintenancekind] ADD CONSTRAINT ukmaintenancekind UNIQUE (codemaintenancekind)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1maintenancekind' and id=object_id('maintenancekind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1maintenancekind ON maintenancekind (codemaintenancekind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1maintenancekind
	ON maintenancekind (codemaintenancekind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2maintenance' and id=object_id('maintenance'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2maintenance ON maintenance (idmaintenancekind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2maintenance
	ON maintenance (idmaintenancekind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'maintenance' AND field = 'idmaintenancekind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 12:04:59.907'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 12:04:59.907'} WHERE tablename = 'maintenance' AND field = 'idmaintenancekind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('maintenance','idmaintenancekind','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-10-23 12:04:59.907'},'''NINO''','NINO',{ts '2007-10-23 12:04:59.907'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'maintenancekind' AND field = 'codemaintenancekind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 12:04:54.233'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 12:04:54.233'} WHERE tablename = 'maintenancekind' AND field = 'codemaintenancekind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('maintenancekind','codemaintenancekind','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-10-23 12:04:54.233'},'''NINO''','NINO',{ts '2007-10-23 12:04:54.233'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'maintenancekind' AND field = 'idmaintenancekind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 12:04:54.233'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 12:04:54.233'} WHERE tablename = 'maintenancekind' AND field = 'idmaintenancekind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('maintenancekind','idmaintenancekind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 12:04:54.233'},'''NINO''','NINO',{ts '2007-10-23 12:04:54.233'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'maintenancekind'
		and C.name ='idmaintenancekindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [maintenancekind] DROP COLUMN idmaintenancekindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'maintenance'
		and C.name ='idmaintenancekindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [maintenance] DROP COLUMN idmaintenancekindint
END
GO
