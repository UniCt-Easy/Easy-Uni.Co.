
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


-- Aggiornamento tabella ADDRESS e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- registryaddress

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO address (idaddress, description, active, lt, lu)
SELECT DISTINCT idaddresskind, idaddresskind, 'N', GETDATE(), 'SA'
FROM registryaddress
WHERE NOT EXISTS(SELECT * FROM address k WHERE k.idaddress = registryaddress.idaddresskind)

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'idaddressint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD idaddressint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'codeaddress' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD codeaddress varchar(10) NULL
END
ELSE
BEGIN
	ALTER TABLE [address] ALTER COLUMN codeaddress varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'idaddresskindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD idaddresskindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [registryaddress] ALTER COLUMN idaddresskindint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'codeaddress' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE address SET codeaddress = idaddress
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'idaddresskindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registryaddress SET idaddresskindint = address.idaddressint
	FROM address
	WHERE registryaddress.idaddresskind = address.idaddress
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono address
IF exists(SELECT * FROM sysconstraints where id=object_id('address') and constid=object_id('xpkaddress'))
BEGIN
	ALTER TABLE [address] drop constraint xpkaddress
END

IF exists(SELECT * FROM sysconstraints where id=object_id('address') and constid=object_id('PK_address'))
BEGIN
	ALTER TABLE [address] drop constraint PK_address
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('registryaddress') and constid=object_id('xpkregistryaddress'))
BEGIN
	ALTER TABLE [registryaddress] drop constraint xpkregistryaddress
END

IF exists(SELECT * FROM sysconstraints where id=object_id('registryaddress') and constid=object_id('PK_registryaddress'))
BEGIN
	ALTER TABLE [registryaddress] drop constraint PK_registryaddress
END
GO

-- Passo 4.2: Indici
-- NON CI SONO INDICI

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'address'
		and C.name ='idaddress'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [address] DROP COLUMN idaddress
	DELETE FROM columntypes WHERE tablename = 'address' AND field = 'idaddress'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registryaddress'
		and C.name ='idaddresskind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registryaddress] DROP COLUMN idaddresskind
	DELETE FROM columntypes WHERE tablename = 'registryaddress' AND field = 'idaddresskind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate address e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'idaddress' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD idaddress int NULL 
END
ELSE
	ALTER TABLE [address] ALTER COLUMN idaddress int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'idaddresskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD idaddresskind int NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN idaddresskind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'idaddress' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE address SET idaddress = idaddressint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'idaddresskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registryaddress SET idaddresskind = idaddresskindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'idaddress' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ALTER COLUMN idaddress int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'codeaddress' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ALTER COLUMN codeaddress varchar(20) NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'idaddresskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ALTER COLUMN idaddresskind int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('address') and constid=object_id('xpkaddress'))
BEGIN
	ALTER TABLE [address] ADD CONSTRAINT xpkaddress PRIMARY KEY (idaddress)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('address') and constid=object_id('ukaddress'))
BEGIN
	ALTER TABLE [address] ADD CONSTRAINT ukaddress UNIQUE (codeaddress)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('registryaddress') and constid=object_id('xpkregistryaddress'))
BEGIN
	ALTER TABLE [registryaddress] ADD CONSTRAINT xpkregistryaddress PRIMARY KEY (idreg, start, idaddresskind)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1address' and id=object_id('address'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1address ON address (codeaddress)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1address
	ON address (codeaddress)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'address' AND field = 'codeaddress')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 14:32:16.453'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 14:32:16.453'} WHERE tablename = 'address' AND field = 'codeaddress'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('address','codeaddress','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-13 14:32:16.453'},'''NINO''','NINO',{ts '2007-11-13 14:32:16.453'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'address' AND field = 'idaddress')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 14:32:16.453'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 14:32:16.453'} WHERE tablename = 'address' AND field = 'idaddress'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('address','idaddress','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-13 14:32:16.453'},'''NINO''','NINO',{ts '2007-11-13 14:32:16.453'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registryaddress' AND field = 'idaddresskind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 14:33:06.983'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 14:33:06.983'} WHERE tablename = 'registryaddress' AND field = 'idaddresskind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registryaddress','idaddresskind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-13 14:33:06.983'},'''NINO''','NINO',{ts '2007-11-13 14:33:06.983'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'address'
		and C.name ='idaddressint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [address] DROP COLUMN idaddressint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registryaddress'
		and C.name ='idaddresskindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registryaddress] DROP COLUMN idaddresskindint
END
GO
