
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


-- Aggiornamento tabella ASSETLOADMOTIVE e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- assetacquire, assetload

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO assetloadmotive (idmot, description, flagnewasset, idaccmotive, ct, cu, lt, lu)
SELECT DISTINCT idmot, idmot, 'S', NULL, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM assetacquire
WHERE NOT EXISTS(SELECT * FROM assetloadmotive WHERE assetloadmotive.idmot = assetacquire.idmot)
GO

INSERT INTO assetloadmotive (idmot, description, flagnewasset, idaccmotive, ct, cu, lt, lu)
SELECT DISTINCT idmot, idmot, 'S', NULL, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM assetload
WHERE NOT EXISTS(SELECT * FROM assetloadmotive WHERE assetloadmotive.idmot = assetload.idmot)
AND idmot IS NOT NULL
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadmotive' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadmotive] ADD idmotint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadmotive' and C.name = 'codemot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadmotive] ADD codemot varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [assetloadmotive] ALTER COLUMN codemot varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idmotint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN idmotint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetload] ADD idmotint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetload] ALTER COLUMN idmotint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadmotive' and C.name = 'codemot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadmotive SET codemot = idmot
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idmotint = assetloadmotive.idmotint
	FROM assetloadmotive
	WHERE assetacquire.idmot = assetloadmotive.idmot
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetload SET idmotint = assetloadmotive.idmotint
	FROM assetloadmotive
	WHERE assetload.idmot = assetloadmotive.idmot
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono assetloadmotive
IF exists(SELECT * FROM sysconstraints where id=object_id('assetloadmotive') and constid=object_id('xpkassetloadmotive'))
BEGIN
	ALTER TABLE [assetloadmotive] drop constraint xpkassetloadmotive
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetloadmotive') and constid=object_id('PK_assetloadmotive'))
BEGIN
	ALTER TABLE [assetloadmotive] drop constraint PK_assetloadmotive
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetacquire, assetload
IF EXISTS (SELECT * FROM sysindexes where name='xi5assetacquire' and id=object_id('assetacquire'))
	drop index assetacquire.xi5assetacquire
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetload' and id=object_id('assetload'))
	drop index assetload.xi2assetload
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadmotive'
		and C.name ='idmot'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadmotive] DROP COLUMN idmot
	DELETE FROM columntypes WHERE tablename = 'assetloadmotive' AND field = 'idmot'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='idmot'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idmot
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'idmot'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetload'
		and C.name ='idmot'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetload] DROP COLUMN idmot
	DELETE FROM columntypes WHERE tablename = 'assetload' AND field = 'idmot'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadmotive' and C.name = 'idmot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadmotive] ADD idmot int NULL 
END
ELSE
	ALTER TABLE [assetloadmotive] ALTER COLUMN idmot int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idmot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idmot int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idmot int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idmot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetload] ADD idmot int NULL 
END
ELSE
	ALTER TABLE [assetload] ALTER COLUMN idmot int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadmotive' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadmotive SET idmot = idmotint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idmot = idmotint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetload' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetload SET idmot = idmotint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadmotive' and C.name = 'idmot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadmotive] ALTER COLUMN idmot int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadmotive' and C.name = 'codemot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadmotive] ALTER COLUMN codemot varchar(20) NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idmot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN idmot int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetloadmotive') and constid=object_id('xpkassetloadmotive'))
BEGIN
	ALTER TABLE [assetloadmotive] ADD CONSTRAINT xpkassetloadmotive PRIMARY KEY (idmot)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetloadmotive') and constid=object_id('ukassetloadmotive'))
BEGIN
	ALTER TABLE [assetloadmotive] ADD CONSTRAINT ukassetloadmotive UNIQUE (codemot)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1assetloadmotive' and id=object_id('assetloadmotive'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetloadmotive ON assetloadmotive (codemot)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetloadmotive
	ON assetloadmotive (codemot)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5assetacquire' and id=object_id('assetacquire'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5assetacquire ON assetacquire (idmot)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5assetacquire
	ON assetacquire (idmot)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetload' and id=object_id('assetload'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetload ON assetload (idmot)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetload
	ON assetload (idmot)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetacquire' AND field = 'idmot')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 15:42:44.203'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 15:42:44.203'} WHERE tablename = 'assetacquire' AND field = 'idmot'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetacquire','idmot','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-22 15:42:44.203'},'''NINO''','NINO',{ts '2007-10-22 15:42:44.203'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetload' AND field = 'idmot')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-22 15:42:44.983'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 15:42:44.983'} WHERE tablename = 'assetload' AND field = 'idmot'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetload','idmot','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-22 15:42:44.983'},'''NINO''','NINO',{ts '2007-10-22 15:42:44.983'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetloadmotive' AND field = 'codemot')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 15:42:45.750'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 15:42:45.750'} WHERE tablename = 'assetloadmotive' AND field = 'codemot'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetloadmotive','codemot','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-10-22 15:42:45.750'},'''NINO''','NINO',{ts '2007-10-22 15:42:45.750'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetloadmotive' AND field = 'idmot')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-22 15:42:45.750'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-22 15:42:45.750'} WHERE tablename = 'assetloadmotive' AND field = 'idmot'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetloadmotive','idmot','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-22 15:42:45.750'},'''NINO''','NINO',{ts '2007-10-22 15:42:45.750'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadmotive'
		and C.name ='idmotint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadmotive] DROP COLUMN idmotint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name ='idmotint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idmotint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetload'
		and C.name ='idmotint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetload] DROP COLUMN idmotint
END
GO
