
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


-- Aggiornamento tabella IVAKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- estimatedetail, invoicedetail, mandatedetail, profservice

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO ivakind (idivakind, description, rate, unabatabilitypercentage, active, ct, cu, lt, lu)
SELECT DISTINCT idivakind, idivakind, 0, 0, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM estimatedetail e
WHERE NOT EXISTS(SELECT * FROM ivakind k WHERE k.idivakind = e.idivakind)
AND e.idivakind IS NOT NULL

INSERT INTO ivakind (idivakind, description, rate, unabatabilitypercentage, active, ct, cu, lt, lu)
SELECT DISTINCT idivakind, idivakind, 0, 0, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM invoicedetail e
WHERE NOT EXISTS(SELECT * FROM ivakind k WHERE k.idivakind = e.idivakind)

INSERT INTO ivakind (idivakind, description, rate, unabatabilitypercentage, active, ct, cu, lt, lu)
SELECT DISTINCT idivakind, idivakind, 0, 0, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM mandatedetail e
WHERE NOT EXISTS(SELECT * FROM ivakind k WHERE k.idivakind = e.idivakind)
AND e.idivakind IS NOT NULL

INSERT INTO ivakind (idivakind, description, rate, unabatabilitypercentage, active, ct, cu, lt, lu)
SELECT DISTINCT idivakind, idivakind, 0, 0, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM profservice e
WHERE NOT EXISTS(SELECT * FROM ivakind k WHERE k.idivakind = e.idivakind)
AND e.idivakind IS NOT NULL

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivakind' and C.name = 'idivakindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivakind] ADD idivakindint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivakind' and C.name = 'codeivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivakind] ADD codeivakind varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [ivakind] ALTER COLUMN codeivakind varchar(20) NULL
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idivakindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idivakindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [estimatedetail] ALTER COLUMN idivakindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idivakindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idivakindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandatedetail] ALTER COLUMN idivakindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idivakindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idivakindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idivakindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idivakindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idivakindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [profservice] ALTER COLUMN idivakindint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivakind' and C.name = 'codeivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivakind SET codeivakind = idivakind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idivakindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatedetail SET idivakindint = ivakind.idivakindint
	FROM ivakind
	WHERE ivakind.idivakind = estimatedetail.idivakind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idivakindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatedetail SET idivakindint = ivakind.idivakindint
	FROM ivakind
	WHERE ivakind.idivakind = mandatedetail.idivakind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idivakindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idivakindint = ivakind.idivakindint
	FROM ivakind
	WHERE ivakind.idivakind = invoicedetail.idivakind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idivakindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservice SET idivakindint = ivakind.idivakindint
	FROM ivakind
	WHERE ivakind.idivakind = profservice.idivakind
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono ivakind
IF exists(SELECT * FROM sysconstraints where id=object_id('ivakind') and constid=object_id('xpkivakind'))
BEGIN
	ALTER TABLE [ivakind] drop constraint xpkivakind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('ivakind') and constid=object_id('PK_ivakind'))
BEGIN
	ALTER TABLE [ivakind] drop constraint PK_ivakind
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono invoicedetail
IF EXISTS (SELECT * FROM sysindexes where name='xi2invoicedetail' and id=object_id('invoicedetail'))
	drop index invoicedetail.xi2invoicedetail
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3invoicedetail' and id=object_id('invoicedetail'))
	drop index invoicedetail.xi3invoicedetail
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivakind'
		and C.name ='idivakind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivakind] DROP COLUMN idivakind
	DELETE FROM columntypes WHERE tablename = 'ivakind' AND field = 'idivakind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name ='idivakind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idivakind
	DELETE FROM columntypes WHERE tablename = 'estimatedetail' AND field = 'idivakind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name ='idivakind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idivakind
	DELETE FROM columntypes WHERE tablename = 'mandatedetail' AND field = 'idivakind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idivakind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idivakind
	DELETE FROM columntypes WHERE tablename = 'invoicedetail' AND field = 'idivakind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name ='idivakind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idivakind
	DELETE FROM columntypes WHERE tablename = 'profservice' AND field = 'idivakind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivakind' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivakind] ADD idivakind int NULL 
END
ELSE
	ALTER TABLE [ivakind] ALTER COLUMN idivakind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idivakind int NULL 
END
ELSE
	ALTER TABLE [estimatedetail] ALTER COLUMN idivakind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idivakind int NULL 
END
ELSE
	ALTER TABLE [mandatedetail] ALTER COLUMN idivakind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idivakind int NULL 
END
ELSE
	ALTER TABLE [invoicedetail] ALTER COLUMN idivakind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idivakind int NULL 
END
ELSE
	ALTER TABLE [profservice] ALTER COLUMN idivakind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivakind' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivakind SET idivakind = idivakindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatedetail SET idivakind = idivakindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatedetail SET idivakind = idivakindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idivakind = idivakindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservice SET idivakind = idivakindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivakind' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivakind] ALTER COLUMN idivakind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivakind' and C.name = 'codeivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivakind] ALTER COLUMN codeivakind varchar(20) NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idivakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idivakind int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('ivakind') and constid=object_id('xpkivakind'))
BEGIN
	ALTER TABLE [ivakind] ADD CONSTRAINT xpkivakind PRIMARY KEY (idivakind)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('ivakind') and constid=object_id('ukivakind'))
BEGIN
	ALTER TABLE [ivakind] ADD CONSTRAINT ukivakind UNIQUE (codeivakind)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1ivakind' and id=object_id('ivakind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1ivakind ON ivakind (codeivakind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1ivakind
	ON ivakind (codeivakind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2estimatedetail' and id=object_id('estimatedetail'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2estimatedetail ON estimatedetail (idivakind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2estimatedetail
	ON estimatedetail (idivakind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2mandatedetail' and id=object_id('mandatedetail'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2mandatedetail ON mandatedetail (idivakind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2mandatedetail
	ON mandatedetail (idivakind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2invoicedetail' and id=object_id('invoicedetail'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2invoicedetail ON invoicedetail (idivakind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2invoicedetail
	ON invoicedetail (idivakind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1profservice' and id=object_id('profservice'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1profservice ON profservice (idivakind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1profservice
	ON profservice (idivakind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ivakind' AND field = 'codeivakind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:52:56.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:52:56.030'} WHERE tablename = 'ivakind' AND field = 'codeivakind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('ivakind','codeivakind','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-19 15:52:56.030'},'''NINO''','NINO',{ts '2007-11-19 15:52:56.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimatedetail' AND field = 'idivakind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-19 13:21:17.297'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 13:21:17.297'} WHERE tablename = 'estimatedetail' AND field = 'idivakind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('estimatedetail','idivakind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-19 13:21:17.297'},'''NINO''','NINO',{ts '2007-11-19 13:21:17.297'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicedetail' AND field = 'idivakind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 13:21:17.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 13:21:17.577'} WHERE tablename = 'invoicedetail' AND field = 'idivakind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicedetail','idivakind','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 13:21:17.577'},'''NINO''','NINO',{ts '2007-11-19 13:21:17.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ivakind' AND field = 'idivakind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 13:21:19.377'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 13:21:19.377'} WHERE tablename = 'ivakind' AND field = 'idivakind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('ivakind','idivakind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 13:21:19.377'},'''NINO''','NINO',{ts '2007-11-19 13:21:19.377'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandatedetail' AND field = 'idivakind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-19 13:21:23.733'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 13:21:23.733'} WHERE tablename = 'mandatedetail' AND field = 'idivakind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('mandatedetail','idivakind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-19 13:21:23.733'},'''NINO''','NINO',{ts '2007-11-19 13:21:23.733'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'profservice' AND field = 'idivakind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-19 13:21:17.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 13:21:17.030'} WHERE tablename = 'profservice' AND field = 'idivakind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('profservice','idivakind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-19 13:21:17.030'},'''NINO''','NINO',{ts '2007-11-19 13:21:17.030'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivakind'
		and C.name ='idivakindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivakind] DROP COLUMN idivakindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name ='idivakindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idivakindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name ='idivakindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idivakindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idivakindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idivakindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name ='idivakindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idivakindint
END
GO
