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

﻿-- Aggiornamento tabella IVAREGISTERKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- invoicekindregisterkind, ivapaydetail, ivaregister

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO ivaregisterkind (idivaregisterkind, description, registerclass, ct, cu, lt, lu)
SELECT DISTINCT idivaregisterkind, idivaregisterkind, 'A', GETDATE(), 'SA', GETDATE(), 'SA'
FROM invoicekindregisterkind e
WHERE NOT EXISTS(SELECT * FROM ivaregisterkind k WHERE k.idivaregisterkind = e.idivaregisterkind)
GO

INSERT INTO ivaregisterkind (idivaregisterkind, description, registerclass, ct, cu, lt, lu)
SELECT DISTINCT idivaregisterkind, idivaregisterkind, 'A', GETDATE(), 'SA', GETDATE(), 'SA'
FROM ivapaydetail e
WHERE NOT EXISTS(SELECT * FROM ivaregisterkind k WHERE k.idivaregisterkind = e.idivaregisterkind)
GO

INSERT INTO ivaregisterkind (idivaregisterkind, description, registerclass, ct, cu, lt, lu)
SELECT DISTINCT idivaregisterkind, idivaregisterkind, 'A', GETDATE(), 'SA', GETDATE(), 'SA'
FROM ivaregister e
WHERE NOT EXISTS(SELECT * FROM ivaregisterkind k WHERE k.idivaregisterkind = e.idivaregisterkind)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregisterkind' and C.name = 'idivaregisterkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregisterkind] ADD idivaregisterkindint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregisterkind' and C.name = 'codeivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregisterkind] ADD codeivaregisterkind varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [ivaregisterkind] ALTER COLUMN codeivaregisterkind varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindregisterkind' and C.name = 'idivaregisterkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekindregisterkind] ADD idivaregisterkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicekindregisterkind] ALTER COLUMN idivaregisterkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapaydetail' and C.name = 'idivaregisterkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapaydetail] ADD idivaregisterkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [ivapaydetail] ALTER COLUMN idivaregisterkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregister' and C.name = 'idivaregisterkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregister] ADD idivaregisterkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [ivaregister] ALTER COLUMN idivaregisterkindint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregisterkind' and C.name = 'codeivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivaregisterkind SET codeivaregisterkind = idivaregisterkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindregisterkind' and C.name = 'idivaregisterkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicekindregisterkind SET idivaregisterkindint = ivaregisterkind.idivaregisterkindint
	FROM ivaregisterkind
	WHERE ivaregisterkind.idivaregisterkind = invoicekindregisterkind.idivaregisterkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapaydetail' and C.name = 'idivaregisterkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivapaydetail SET idivaregisterkindint = ivaregisterkind.idivaregisterkindint
	FROM ivaregisterkind
	WHERE ivaregisterkind.idivaregisterkind = ivapaydetail.idivaregisterkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregister' and C.name = 'idivaregisterkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivaregister SET idivaregisterkindint = ivaregisterkind.idivaregisterkindint
	FROM ivaregisterkind
	WHERE ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono ivaregisterkind, ivapaydetail, ivaregister
IF exists(SELECT * FROM sysconstraints where id=object_id('ivaregisterkind') and constid=object_id('xpkivaregisterkind'))
BEGIN
	ALTER TABLE [ivaregisterkind] drop constraint xpkivaregisterkind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('ivaregisterkind') and constid=object_id('PK_ivaregisterkind'))
BEGIN
	ALTER TABLE [ivaregisterkind] drop constraint PK_ivaregisterkind
END
GO
-- , , 
IF exists(SELECT * FROM sysconstraints where id=object_id('invoicekindregisterkind') and constid=object_id('xpkinvoicekindregisterkind'))
BEGIN
	ALTER TABLE [invoicekindregisterkind] drop constraint xpkinvoicekindregisterkind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicekindregisterkind') and constid=object_id('PK_invoicekindregisterkind'))
BEGIN
	ALTER TABLE [invoicekindregisterkind] drop constraint PK_invoicekindregisterkind
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('ivapaydetail') and constid=object_id('xpkivapaydetail'))
BEGIN
	ALTER TABLE [ivapaydetail] drop constraint xpkivapaydetail
END

IF exists(SELECT * FROM sysconstraints where id=object_id('ivapaydetail') and constid=object_id('PK_ivapaydetail'))
BEGIN
	ALTER TABLE [ivapaydetail] drop constraint PK_ivapaydetail
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('ivaregister') and constid=object_id('xpkivaregister'))
BEGIN
	ALTER TABLE [ivaregister] drop constraint xpkivaregister
END

IF exists(SELECT * FROM sysconstraints where id=object_id('ivaregister') and constid=object_id('PK_ivaregister'))
BEGIN
	ALTER TABLE [ivaregister] drop constraint PK_ivaregister
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono invoicekind, expenseinvoice, incomeinvoice, invoice, invoicedetail, ivaregister, 
IF EXISTS (SELECT * FROM sysindexes where name='xi2ivapaydetail' and id=object_id('ivapaydetail'))
	drop index ivapaydetail.xi2ivapaydetail
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1ivaregister' and id=object_id('ivaregister'))
	drop index ivaregister.xi1ivaregister
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivaregisterkind'
		and C.name ='idivaregisterkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivaregisterkind] DROP COLUMN idivaregisterkind
	DELETE FROM columntypes WHERE tablename = 'ivaregisterkind' AND field = 'idivaregisterkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekindregisterkind'
		and C.name ='idivaregisterkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekindregisterkind] DROP COLUMN idivaregisterkind
	DELETE FROM columntypes WHERE tablename = 'invoicekindregisterkind' AND field = 'idivaregisterkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivapaydetail'
		and C.name ='idivaregisterkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivapaydetail] DROP COLUMN idivaregisterkind
	DELETE FROM columntypes WHERE tablename = 'ivapaydetail' AND field = 'idivaregisterkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivaregister'
		and C.name ='idivaregisterkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivaregister] DROP COLUMN idivaregisterkind
	DELETE FROM columntypes WHERE tablename = 'ivaregister' AND field = 'idivaregisterkind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregisterkind' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregisterkind] ADD idivaregisterkind int NULL 
END
ELSE
	ALTER TABLE [ivaregisterkind] ALTER COLUMN idivaregisterkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindregisterkind' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekindregisterkind] ADD idivaregisterkind int NULL 
END
ELSE
	ALTER TABLE [invoicekindregisterkind] ALTER COLUMN idivaregisterkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapaydetail' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapaydetail] ADD idivaregisterkind int NULL 
END
ELSE
	ALTER TABLE [ivapaydetail] ALTER COLUMN idivaregisterkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregister' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregister] ADD idivaregisterkind int NULL 
END
ELSE
	ALTER TABLE [ivaregister] ALTER COLUMN idivaregisterkind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregisterkind' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivaregisterkind SET idivaregisterkind = idivaregisterkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindregisterkind' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicekindregisterkind SET idivaregisterkind = idivaregisterkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapaydetail' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivapaydetail SET idivaregisterkind = idivaregisterkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregister' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivaregister SET idivaregisterkind = idivaregisterkindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregisterkind' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregisterkind] ALTER COLUMN idivaregisterkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindregisterkind' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekindregisterkind] ALTER COLUMN idivaregisterkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapaydetail' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapaydetail] ALTER COLUMN idivaregisterkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregister' and C.name = 'idivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregister] ALTER COLUMN idivaregisterkind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregisterkind' and C.name = 'codeivaregisterkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregisterkind] ALTER COLUMN codeivaregisterkind varchar(20) NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('ivaregisterkind') and constid=object_id('xpkivaregisterkind'))
BEGIN
	ALTER TABLE [ivaregisterkind] ADD CONSTRAINT xpkivaregisterkind PRIMARY KEY (idivaregisterkind)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('ivaregisterkind') and constid=object_id('ukivaregisterkind'))
BEGIN
	ALTER TABLE [ivaregisterkind] ADD CONSTRAINT ukivaregisterkind UNIQUE (codeivaregisterkind)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoicekindregisterkind') and constid=object_id('xpkinvoicekindregisterkind'))
BEGIN
	ALTER TABLE [invoicekindregisterkind] ADD CONSTRAINT xpkinvoicekindregisterkind PRIMARY KEY (idinvkind, idivaregisterkind)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('ivapaydetail') and constid=object_id('xpkivapaydetail'))
BEGIN
	ALTER TABLE [ivapaydetail] ADD CONSTRAINT xpkivapaydetail PRIMARY KEY (yivapay, nivapay, idivaregisterkind)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('ivaregister') and constid=object_id('xpkivaregister'))
BEGIN
	ALTER TABLE [ivaregister] ADD CONSTRAINT xpkivaregister PRIMARY KEY (idivaregisterkind, yivaregister, nivaregister)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1ivaregisterkind' and id=object_id('ivaregisterkind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1ivaregisterkind ON ivaregisterkind (codeivaregisterkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1ivaregisterkind
	ON ivaregisterkind (codeivaregisterkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivapaydetail' and id=object_id('ivapaydetail'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2ivapaydetail ON ivapaydetail (idivaregisterkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2ivapaydetail
	ON ivapaydetail (idivaregisterkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1ivaregister' and id=object_id('ivaregister'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1ivaregister ON ivaregister (idivaregisterkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1ivaregister
	ON ivaregister (idivaregisterkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicekindregisterkind' AND field = 'idivaregisterkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 16:44:08.953'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 16:44:08.953'} WHERE tablename = 'invoicekindregisterkind' AND field = 'idivaregisterkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicekindregisterkind','idivaregisterkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 16:44:08.953'},'''NINO''','NINO',{ts '2007-11-19 16:44:08.953'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ivapaydetail' AND field = 'idivaregisterkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 16:43:52.953'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 16:43:52.953'} WHERE tablename = 'ivapaydetail' AND field = 'idivaregisterkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('ivapaydetail','idivaregisterkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 16:43:52.953'},'''NINO''','NINO',{ts '2007-11-19 16:43:52.953'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ivaregister' AND field = 'idivaregisterkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 16:43:54.093'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 16:43:54.093'} WHERE tablename = 'ivaregister' AND field = 'idivaregisterkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('ivaregister','idivaregisterkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 16:43:54.093'},'''NINO''','NINO',{ts '2007-11-19 16:43:54.093'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ivaregisterkind' AND field = 'codeivaregisterkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 16:43:54.377'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 16:43:54.377'} WHERE tablename = 'ivaregisterkind' AND field = 'codeivaregisterkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('ivaregisterkind','codeivaregisterkind','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-19 16:43:54.377'},'''NINO''','NINO',{ts '2007-11-19 16:43:54.377'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ivaregisterkind' AND field = 'idivaregisterkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 16:43:54.377'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 16:43:54.377'} WHERE tablename = 'ivaregisterkind' AND field = 'idivaregisterkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('ivaregisterkind','idivaregisterkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 16:43:54.377'},'''NINO''','NINO',{ts '2007-11-19 16:43:54.377'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivaregisterkind'
		and C.name ='idivaregisterkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivaregisterkind] DROP COLUMN idivaregisterkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivaregister'
		and C.name ='idivaregisterkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivaregister] DROP COLUMN idivaregisterkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekindregisterkind'
		and C.name ='idivaregisterkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekindregisterkind] DROP COLUMN idivaregisterkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivapaydetail'
		and C.name ='idivaregisterkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivapaydetail] DROP COLUMN idivaregisterkindint
END
GO
	