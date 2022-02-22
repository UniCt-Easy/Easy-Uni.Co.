
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


-- Aggiornamento tabella REGISTRYKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- registry

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO registrykind (sortcode, description, ct, cu, lt, lu)
SELECT DISTINCT sortcode, sortcode, GETDATE(), 'SA', GETDATE(), 'SA'
FROM registry e
WHERE NOT EXISTS(SELECT * FROM registrykind k WHERE k.sortcode = e.sortcode)
AND e.sortcode IS NOT NULL

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrykind' and C.name = 'idregistrykindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrykind] ADD idregistrykindint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idregistrykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idregistrykind int NULL
END
ELSE
BEGIN
	ALTER TABLE [registry] ALTER COLUMN idregistrykind int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idregistrykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registry SET idregistrykind = registrykind.idregistrykindint
	FROM registrykind
	WHERE registrykind.sortcode = registry.sortcode
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono ivakind
IF exists(SELECT * FROM sysconstraints where id=object_id('registrykind') and constid=object_id('xpkregistrykind'))
BEGIN
	ALTER TABLE [registrykind] drop constraint xpkregistrykind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('registrykind') and constid=object_id('PK_registrykind'))
BEGIN
	ALTER TABLE [registrykind] drop constraint PK_registrykind
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono invoicedetail
IF EXISTS (SELECT * FROM sysindexes where name='xi2registry' and id=object_id('registry'))
	drop index registry.xi2registry
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
-- N.B. Non viene droppato il campo SORTCODE di REGITRYKIND in quanto resta come campo non chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registry'
		and C.name ='sortcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registry] DROP COLUMN sortcode
	DELETE FROM columntypes WHERE tablename = 'registry' AND field = 'sortcode'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate registrykind e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrykind' and C.name = 'idregistrykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrykind] ADD idregistrykind int NULL 
END
ELSE
	ALTER TABLE [registrykind] ALTER COLUMN idregistrykind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrykind' and C.name = 'idregistrykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrykind SET idregistrykind = idregistrykindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrykind' and C.name = 'idregistrykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrykind] ALTER COLUMN idregistrykind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('registrykind') and constid=object_id('xpkregistrykind'))
BEGIN
	ALTER TABLE [registrykind] ADD CONSTRAINT xpkregistrykind PRIMARY KEY (idregistrykind)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('registrykind') and constid=object_id('ukregistrykind'))
BEGIN
	ALTER TABLE [registrykind] ADD CONSTRAINT ukregistrykind UNIQUE (sortcode)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1registrykind' and id=object_id('registrykind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1registrykind ON registrykind (sortcode)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1registrykind
	ON registrykind (sortcode)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2registry' and id=object_id('registry'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2registry ON registry (idregistrykind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2registry
	ON registry (idregistrykind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registry' AND field = 'idregistrykind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-26 16:36:05.983'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 16:36:05.983'} WHERE tablename = 'registry' AND field = 'idregistrykind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registry','idregistrykind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-26 16:36:05.983'},'''NINO''','NINO',{ts '2007-11-26 16:36:05.983'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registrykind' AND field = 'idregistrykind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-26 16:36:06.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 16:36:06.967'} WHERE tablename = 'registrykind' AND field = 'idregistrykind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registrykind','idregistrykind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-26 16:36:06.967'},'''NINO''','NINO',{ts '2007-11-26 16:36:06.967'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registrykind' AND field = 'sortcode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-26 16:36:06.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 16:36:06.967'} WHERE tablename = 'registrykind' AND field = 'sortcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registrykind','sortcode','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-26 16:36:06.967'},'''NINO''','NINO',{ts '2007-11-26 16:36:06.967'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrykind'
		and C.name ='idregistrykindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrykind] DROP COLUMN idregistrykindint
END
GO

