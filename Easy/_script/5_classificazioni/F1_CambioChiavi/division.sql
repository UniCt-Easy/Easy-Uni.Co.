
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- Aggiornamento tabella DIVISION e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- divisionsorting, manager

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DELETE FROM divisionsorting WHERE NOT EXISTS(SELECT * FROM division WHERE division.iddivision = divisionsorting.iddivision)

INSERT INTO division (iddivision, description, ct, cu, lt, lu)
SELECT DISTINCT iddivision, iddivision, GETDATE(), 'SA', GETDATE(), 'SA'
FROM manager e
WHERE NOT EXISTS(SELECT * FROM division k WHERE k.iddivision = e.iddivision)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'division' and C.name = 'iddivisionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [division] ADD iddivisionint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'division' and C.name = 'codedivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [division] ADD codedivision varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [division] ALTER COLUMN codedivision varchar(20) NULL
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'iddivisionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [divisionsorting] ADD iddivisionint int NULL
END
ELSE
BEGIN
	ALTER TABLE [divisionsorting] ALTER COLUMN iddivisionint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'manager' and C.name = 'iddivisionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [manager] ADD iddivisionint int NULL
END
ELSE
BEGIN
	ALTER TABLE [manager] ALTER COLUMN iddivisionint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'division' and C.name = 'codedivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE division SET codedivision = iddivision
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'iddivisionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE divisionsorting SET iddivisionint = division.iddivisionint
	FROM division
	WHERE division.iddivision = divisionsorting.iddivision
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'manager' and C.name = 'iddivisionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE manager SET iddivisionint = division.iddivisionint
	FROM division
	WHERE division.iddivision = manager.iddivision
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono ivakind
IF exists(SELECT * FROM sysconstraints where id=object_id('division') and constid=object_id('xpkdivision'))
BEGIN
	ALTER TABLE [division] drop constraint xpkdivision
END

IF exists(SELECT * FROM sysconstraints where id=object_id('division') and constid=object_id('PK_division'))
BEGIN
	ALTER TABLE [division] drop constraint PK_division
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('divisionsorting') and constid=object_id('xpkdivisionsorting'))
BEGIN
	ALTER TABLE [divisionsorting] drop constraint xpkdivisionsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('divisionsorting') and constid=object_id('PK_divisionsorting'))
BEGIN
	ALTER TABLE [divisionsorting] drop constraint PK_divisionsorting
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono invoicedetail
IF EXISTS (SELECT * FROM sysindexes where name='xi2divisionsorting' and id=object_id('divisionsorting'))
	drop index divisionsorting.xi2divisionsorting
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1manager' and id=object_id('manager'))
	drop index manager.xi1manager
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'division'
		and C.name ='iddivision'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [division] DROP COLUMN iddivision
	DELETE FROM columntypes WHERE tablename = 'division' AND field = 'iddivision'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'divisionsorting'
		and C.name ='iddivision'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [divisionsorting] DROP COLUMN iddivision
	DELETE FROM columntypes WHERE tablename = 'divisionsorting' AND field = 'iddivision'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'manager'
		and C.name ='iddivision'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [manager] DROP COLUMN iddivision
	DELETE FROM columntypes WHERE tablename = 'manager' AND field = 'iddivision'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'division' and C.name = 'iddivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [division] ADD iddivision int NULL 
END
ELSE
	ALTER TABLE [division] ALTER COLUMN iddivision int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'iddivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [divisionsorting] ADD iddivision int NULL 
END
ELSE
	ALTER TABLE [divisionsorting] ALTER COLUMN iddivision int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'manager' and C.name = 'iddivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [manager] ADD iddivision int NULL 
END
ELSE
	ALTER TABLE [manager] ALTER COLUMN iddivision int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'division' and C.name = 'iddivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE division SET iddivision = iddivisionint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'iddivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE divisionsorting SET iddivision = iddivisionint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'manager' and C.name = 'iddivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE manager SET iddivision = iddivisionint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'division' and C.name = 'iddivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [division] ALTER COLUMN iddivision int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'iddivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [divisionsorting] ALTER COLUMN iddivision int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'division' and C.name = 'codedivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [division] ALTER COLUMN codedivision varchar(20) NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'manager' and C.name = 'iddivision' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [manager] ALTER COLUMN iddivision int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('division') and constid=object_id('xpkdivision'))
BEGIN
	ALTER TABLE [division] ADD CONSTRAINT xpkdivision PRIMARY KEY (iddivision)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('division') and constid=object_id('ukdivision'))
BEGIN
	ALTER TABLE [division] ADD CONSTRAINT ukdivision UNIQUE (codedivision)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('divisionsorting') and constid=object_id('xpkdivisionsorting'))
BEGIN
	ALTER TABLE [divisionsorting] ADD CONSTRAINT xpkdivisionsorting PRIMARY KEY (iddivision, idsor)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1division' and id=object_id('divisionsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1division ON division (codedivision)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1division
	ON division (codedivision)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2divisionsorting' and id=object_id('divisionsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2divisionsorting ON divisionsorting (iddivision)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2divisionsorting
	ON divisionsorting (iddivision)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1manager' and id=object_id('manager'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1manager ON manager (iddivision)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1manager
	ON manager (iddivision)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'division' AND field = 'codedivision')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-26 17:58:29.517'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 17:58:29.517'} WHERE tablename = 'division' AND field = 'codedivision'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('division','codedivision','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-26 17:58:29.517'},'''NINO''','NINO',{ts '2007-11-26 17:58:29.517'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'division' AND field = 'iddivision')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-26 17:58:29.517'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 17:58:29.517'} WHERE tablename = 'division' AND field = 'iddivision'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('division','iddivision','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-26 17:58:29.517'},'''NINO''','NINO',{ts '2007-11-26 17:58:29.517'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'divisionsorting' AND field = 'iddivision')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-26 17:58:29.890'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 17:58:29.890'} WHERE tablename = 'divisionsorting' AND field = 'iddivision'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('divisionsorting','iddivision','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-26 17:58:29.890'},'''NINO''','NINO',{ts '2007-11-26 17:58:29.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'manager' AND field = 'iddivision')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-26 17:58:35.000'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 17:58:35.000'} WHERE tablename = 'manager' AND field = 'iddivision'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('manager','iddivision','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-26 17:58:35.000'},'''NINO''','NINO',{ts '2007-11-26 17:58:35.000'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'division'
		and C.name ='iddivisionint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [division] DROP COLUMN iddivisionint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'divisionsorting'
		and C.name ='iddivisionint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [divisionsorting] DROP COLUMN iddivisionint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'manager'
		and C.name ='iddivisionint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [manager] DROP COLUMN iddivisionint
END
GO
