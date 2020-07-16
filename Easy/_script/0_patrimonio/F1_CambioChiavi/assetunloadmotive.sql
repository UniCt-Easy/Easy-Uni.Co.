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

﻿-- Aggiornamento tabella ASSETUNLOADMOTIVE e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- assetunload

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO assetunloadmotive (idmot, description, ct, cu, lt, lu)
SELECT DISTINCT idmot, idmot, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM assetunload
WHERE NOT EXISTS(SELECT * FROM assetunloadmotive WHERE assetunloadmotive.idmot = assetunload.idmot)
AND idmot IS NOT NULL
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadmotive' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadmotive] ADD idmotint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadmotive' and C.name = 'codemot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadmotive] ADD codemot varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [assetunloadmotive] ALTER COLUMN codemot varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunload] ADD idmotint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetunload] ALTER COLUMN idmotint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadmotive' and C.name = 'codemot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadmotive SET codemot = idmot
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunload SET idmotint = assetunloadmotive.idmotint
	FROM assetunloadmotive
	WHERE assetunload.idmot = assetunloadmotive.idmot
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono assetloadmotive
IF exists(SELECT * FROM sysconstraints where id=object_id('assetunloadmotive') and constid=object_id('xpkassetunloadmotive'))
BEGIN
	ALTER TABLE [assetunloadmotive] drop constraint xpkassetunloadmotive
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetunloadmotive') and constid=object_id('PK_assetunloadmotive'))
BEGIN
	ALTER TABLE [assetunloadmotive] drop constraint PK_assetunloadmotive
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetacquire, assetload
IF EXISTS (SELECT * FROM sysindexes where name='xi2assetunload' and id=object_id('assetunload'))
	drop index assetunload.xi2assetunload
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadmotive'
		and C.name ='idmot'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadmotive] DROP COLUMN idmot
	DELETE FROM columntypes WHERE tablename = 'assetunloadmotive' AND field = 'idmot'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunload'
		and C.name ='idmot'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunload] DROP COLUMN idmot
	DELETE FROM columntypes WHERE tablename = 'assetunload' AND field = 'idmot'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadmotive' and C.name = 'idmot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadmotive] ADD idmot int NULL 
END
ELSE
	ALTER TABLE [assetunloadmotive] ALTER COLUMN idmot int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idmot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunload] ADD idmot int NULL 
END
ELSE
	ALTER TABLE [assetunload] ALTER COLUMN idmot int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadmotive' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadmotive SET idmot = idmotint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunload' and C.name = 'idmotint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunload SET idmot = idmotint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadmotive' and C.name = 'idmot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadmotive] ALTER COLUMN idmot int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadmotive' and C.name = 'codemot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadmotive] ALTER COLUMN codemot varchar(20) NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetunloadmotive') and constid=object_id('xpkassetunloadmotive'))
BEGIN
	ALTER TABLE [assetunloadmotive] ADD CONSTRAINT xpkassetunloadmotive PRIMARY KEY (idmot)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetunloadmotive') and constid=object_id('ukassetunloadmotive'))
BEGIN
	ALTER TABLE [assetunloadmotive] ADD CONSTRAINT ukassetunloadmotive UNIQUE (codemot)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1assetunloadmotive' and id=object_id('assetunloadmotive'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetunloadmotive ON assetunloadmotive (codemot)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetunloadmotive
	ON assetunloadmotive (codemot)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetunload' and id=object_id('assetunload'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetunload ON assetunload (idmot)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetunload
	ON assetunload (idmot)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunload' AND field = 'idmot')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-23 09:55:02.563'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 09:55:02.563'} WHERE tablename = 'assetunload' AND field = 'idmot'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunload','idmot','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-10-23 09:55:02.563'},'''NINO''','NINO',{ts '2007-10-23 09:55:02.563'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunloadmotive' AND field = 'codemot')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 09:55:05.860'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 09:55:05.860'} WHERE tablename = 'assetunloadmotive' AND field = 'codemot'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunloadmotive','codemot','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-10-23 09:55:05.860'},'''NINO''','NINO',{ts '2007-10-23 09:55:05.860'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunloadmotive' AND field = 'idmot')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-23 09:55:05.860'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-23 09:55:05.860'} WHERE tablename = 'assetunloadmotive' AND field = 'idmot'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetunloadmotive','idmot','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-23 09:55:05.860'},'''NINO''','NINO',{ts '2007-10-23 09:55:05.860'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadmotive'
		and C.name ='idmotint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadmotive] DROP COLUMN idmotint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunload'
		and C.name ='idmotint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunload] DROP COLUMN idmotint
END
GO
	