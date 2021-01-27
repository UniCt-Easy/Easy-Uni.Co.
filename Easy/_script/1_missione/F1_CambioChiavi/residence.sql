
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


-- Aggiornamento tabella RESIDENCE e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- registry

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO residence (idresidence, description, active, lt, lu)
SELECT DISTINCT residence, residence, 'N', GETDATE(), 'SA'
FROM registry
WHERE NOT EXISTS(SELECT * FROM residence k WHERE k.idresidence = registry.residence)

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'residence' and C.name = 'idresidenceint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [residence] ADD idresidenceint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'residence' and C.name = 'coderesidence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [residence] ADD coderesidence varchar(10) NULL
END
ELSE
BEGIN
	ALTER TABLE [residence] ALTER COLUMN coderesidence varchar(10) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'residenceint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD residenceint int NULL
END
ELSE
BEGIN
	ALTER TABLE [registry] ALTER COLUMN residenceint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'residence' and C.name = 'coderesidence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE residence SET coderesidence = idresidence
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'residenceint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registry SET residenceint = residence.idresidenceint
	FROM residence
	WHERE registry.residence = residence.idresidence
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono residence
IF exists(SELECT * FROM sysconstraints where id=object_id('residence') and constid=object_id('xpkresidence'))
BEGIN
	ALTER TABLE [residence] drop constraint xpkresidence
END

IF exists(SELECT * FROM sysconstraints where id=object_id('residence') and constid=object_id('PK_residence'))
BEGIN
	ALTER TABLE [residence] drop constraint PK_residence
END
GO

-- Passo 4.2: Indici
-- NON CI SONO INDICI

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'residence'
		and C.name ='idresidence'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [residence] DROP COLUMN idresidence
	DELETE FROM columntypes WHERE tablename = 'residence' AND field = 'idresidence'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registry'
		and C.name ='residence'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registry] DROP COLUMN residence
	DELETE FROM columntypes WHERE tablename = 'registry' AND field = 'residence'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate residence e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'residence' and C.name = 'idresidence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [residence] ADD idresidence int NULL 
END
ELSE
	ALTER TABLE [residence] ALTER COLUMN idresidence int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'residence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD residence int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN residence int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'residence' and C.name = 'idresidence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE residence SET idresidence = idresidenceint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'residence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registry SET residence = residenceint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'residence' and C.name = 'idresidence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [residence] ALTER COLUMN idresidence int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'residence' and C.name = 'coderesidence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [residence] ALTER COLUMN coderesidence varchar(10) NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'residence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ALTER COLUMN residence int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('residence') and constid=object_id('xpkresidence'))
BEGIN
	ALTER TABLE [residence] ADD CONSTRAINT xpkresidence PRIMARY KEY (idresidence)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('residence') and constid=object_id('ukresidence'))
BEGIN
	ALTER TABLE [residence] ADD CONSTRAINT ukresidence UNIQUE (coderesidence)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1residence' and id=object_id('residence'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1residence ON residence (coderesidence)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1residence
	ON residence (coderesidence)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registry' AND field = 'residence')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 12:48:23.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 12:48:23.530'} WHERE tablename = 'registry' AND field = 'residence'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registry','residence','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-13 12:48:23.530'},'''NINO''','NINO',{ts '2007-11-13 12:48:23.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'residence' AND field = 'coderesidence')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '10',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(10)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 12:48:27.187'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 12:48:27.187'} WHERE tablename = 'residence' AND field = 'coderesidence'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('residence','coderesidence','N','varchar','10',null,null,'System.String','varchar(10)','N','',null,'S',{ts '2007-11-13 12:48:27.187'},'''NINO''','NINO',{ts '2007-11-13 12:48:27.187'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'residence' AND field = 'idresidence')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 12:48:27.187'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 12:48:27.187'} WHERE tablename = 'residence' AND field = 'idresidence'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('residence','idresidence','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-13 12:48:27.187'},'''NINO''','NINO',{ts '2007-11-13 12:48:27.187'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'residence'
		and C.name ='idresidenceint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [residence] DROP COLUMN idresidenceint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registry'
		and C.name ='residenceint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registry] DROP COLUMN residenceint
END
GO
