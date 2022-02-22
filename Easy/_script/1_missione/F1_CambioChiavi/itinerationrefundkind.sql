
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


-- Aggiornamento tabella ITINERATIONREFUNDKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- itinerationrefund

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO itinerationrefundkind (iditinerationrefundkind, description, ct, cu, lt, lu)
SELECT DISTINCT iditinerationrefundkind, iditinerationrefundkind, GETDATE(), 'SA', GETDATE(), 'SA'
FROM itinerationrefund
WHERE NOT EXISTS(SELECT * FROM itinerationrefundkind k WHERE k.iditinerationrefundkind = itinerationrefund.iditinerationrefundkind)

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundkind' and C.name = 'iditinerationrefundkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefundkind] ADD iditinerationrefundkindint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundkind' and C.name = 'codeitinerationrefundkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefundkind] ADD codeitinerationrefundkind varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [itinerationrefundkind] ALTER COLUMN codeitinerationrefundkind varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'iditinerationrefundkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefund] ADD iditinerationrefundkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [itinerationrefund] ALTER COLUMN iditinerationrefundkindint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundkind' and C.name = 'codeitinerationrefundkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationrefundkind SET codeitinerationrefundkind = iditinerationrefundkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'iditinerationrefundkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationrefund SET iditinerationrefundkindint = itinerationrefundkind.iditinerationrefundkindint
	FROM itinerationrefundkind
	WHERE itinerationrefund.iditinerationrefundkind = itinerationrefundkind.iditinerationrefundkind
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono itinerationrefundkind
IF exists(SELECT * FROM sysconstraints where id=object_id('itinerationrefundkind') and constid=object_id('xpkitinerationrefundkind'))
BEGIN
	ALTER TABLE [itinerationrefundkind] drop constraint xpkitinerationrefundkind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('itinerationrefundkind') and constid=object_id('PK_itinerationrefundkind'))
BEGIN
	ALTER TABLE [itinerationrefundkind] drop constraint PK_itinerationrefundkind
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetacquire, assetloadkind, assetunloadkind, assetvardetail
IF EXISTS (SELECT * FROM sysindexes where name='xi4itinerationrefund' and id=object_id('itinerationrefund'))
	drop index itinerationrefund.xi4itinerationrefund
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationrefundkind'
		and C.name ='iditinerationrefundkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationrefundkind] DROP COLUMN iditinerationrefundkind
	DELETE FROM columntypes WHERE tablename = 'itinerationrefundkind' AND field = 'iditinerationrefundkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationrefund'
		and C.name ='iditinerationrefundkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationrefund] DROP COLUMN iditinerationrefundkind
	DELETE FROM columntypes WHERE tablename = 'itinerationrefund' AND field = 'iditinerationrefundkind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate itinerationrefundkind e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundkind' and C.name = 'iditinerationrefundkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefundkind] ADD iditinerationrefundkind int NULL 
END
ELSE
	ALTER TABLE [itinerationrefundkind] ALTER COLUMN iditinerationrefundkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'iditinerationrefundkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefund] ADD iditinerationrefundkind int NULL 
END
ELSE
	ALTER TABLE [itinerationrefund] ALTER COLUMN iditinerationrefundkind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundkind' and C.name = 'iditinerationrefundkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationrefundkind SET iditinerationrefundkind = iditinerationrefundkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'iditinerationrefundkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationrefund SET iditinerationrefundkind = iditinerationrefundkindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundkind' and C.name = 'iditinerationrefundkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefundkind] ALTER COLUMN iditinerationrefundkind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundkind' and C.name = 'codeitinerationrefundkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefundkind] ALTER COLUMN codeitinerationrefundkind varchar(20) NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itinerationrefundkind') and constid=object_id('xpkitinerationrefundkind'))
BEGIN
	ALTER TABLE [itinerationrefundkind] ADD CONSTRAINT xpkitinerationrefundkind PRIMARY KEY (iditinerationrefundkind)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itinerationrefundkind') and constid=object_id('ukitinerationrefundkind'))
BEGIN
	ALTER TABLE [itinerationrefundkind] ADD CONSTRAINT ukitinerationrefundkind UNIQUE (codeitinerationrefundkind)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationrefundkind' and id=object_id('itinerationrefundkind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1itinerationrefundkind ON itinerationrefundkind (codeitinerationrefundkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1itinerationrefundkind
	ON itinerationrefundkind (codeitinerationrefundkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4itinerationrefund' and id=object_id('itinerationrefund'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4itinerationrefund ON itinerationrefund (iditinerationrefundkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4itinerationrefund
	ON itinerationrefund (iditinerationrefundkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationrefund' AND field = 'iditinerationrefundkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-13 09:47:17.813'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 09:47:17.813'} WHERE tablename = 'itinerationrefund' AND field = 'iditinerationrefundkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationrefund','iditinerationrefundkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-13 09:47:17.813'},'''NINO''','NINO',{ts '2007-11-13 09:47:17.813'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationrefundkind' AND field = 'codeitinerationrefundkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 09:47:15.377'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 09:47:15.377'} WHERE tablename = 'itinerationrefundkind' AND field = 'codeitinerationrefundkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationrefundkind','codeitinerationrefundkind','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-13 09:47:15.377'},'''NINO''','NINO',{ts '2007-11-13 09:47:15.377'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationrefundkind' AND field = 'iditinerationrefundkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 09:47:15.377'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 09:47:15.377'} WHERE tablename = 'itinerationrefundkind' AND field = 'iditinerationrefundkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationrefundkind','iditinerationrefundkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-13 09:47:15.377'},'''NINO''','NINO',{ts '2007-11-13 09:47:15.377'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationrefundkind'
		and C.name ='iditinerationrefundkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationrefundkind] DROP COLUMN iditinerationrefundkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationrefund'
		and C.name ='iditinerationrefundkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationrefund] DROP COLUMN iditinerationrefundkindint
END
GO
