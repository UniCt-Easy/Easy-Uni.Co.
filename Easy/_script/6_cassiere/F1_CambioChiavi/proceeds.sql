
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


-- Aggiornamento tabella PROCEEDS e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- banktransaction, incomelast, proceeds_bank

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DELETE FROM banktransaction WHERE NOT EXISTS
	(SELECT * FROM proceeds k
	WHERE k.ypro = banktransaction.ypro
		AND k.npro = banktransaction.npro)
GO

DELETE FROM proceeds_bank WHERE NOT EXISTS
	(SELECT * FROM proceeds k
	WHERE k.ypro = proceeds_bank.ypro
		AND k.npro = proceeds_bank.npro)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_proceeds]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_proceeds]
GO

-- Passo 1. (aggiunta colonna ad autoincremento) e Passo 2. (aggiunta delle colonne nelle tabelle referenziate)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'kproint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ADD kproint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'kpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ADD kpro int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'kpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransaction] ADD kpro int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'kpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelast] ADD kpro int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'kpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD kpro int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'kproint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceeds SET kpro = kproint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'kpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE banktransaction SET kpro = proceeds.kpro
	FROM proceeds
	WHERE banktransaction.ypro = proceeds.ypro AND banktransaction.npro = proceeds.npro
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'kpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceeds_bank SET kpro = proceeds.kpro
	FROM proceeds
	WHERE proceeds_bank.ypro = proceeds.ypro AND proceeds_bank.npro = proceeds.npro
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'kpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomelast SET kpro = proceeds.kpro
	FROM proceeds
	JOIN income
		ON income.ymov = proceeds.ypro
	WHERE income.idinc = incomelast.idinc AND incomelast.npro = proceeds.npro
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono proceeds, proceeds_bank
IF exists(SELECT * FROM sysconstraints where id=object_id('proceeds') and constid=object_id('xpkproceeds'))
BEGIN
	ALTER TABLE [proceeds] drop constraint xpkproceeds
END

IF exists(SELECT * FROM sysconstraints where id=object_id('proceeds') and constid=object_id('PK_proceeds'))
BEGIN
	ALTER TABLE [proceeds] drop constraint PK_proceeds
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('proceeds_bank') and constid=object_id('xpkproceeds_bank'))
BEGIN
	ALTER TABLE [proceeds_bank] drop constraint xpkproceeds_bank
END

IF exists(SELECT * FROM sysconstraints where id=object_id('proceeds_bank') and constid=object_id('PK_proceeds_bank'))
BEGIN
	ALTER TABLE [proceeds_bank] drop constraint PK_proceeds_bank
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono proceeds, incomelast, itinerationtax
IF EXISTS (SELECT * FROM sysindexes where name='xi3banktransaction' and id=object_id('banktransaction'))
	drop index banktransaction.xi3banktransaction
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomelast' and id=object_id('incomelast'))
	drop index incomelast.xi1incomelast
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomelast' and id=object_id('incomelast'))
	drop index incomelast.xi2incomelast
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransaction'
		and C.name ='ypro'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransaction] DROP COLUMN ypro
	DELETE FROM columntypes WHERE tablename = 'banktransaction' AND field = 'ypro'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransaction'
		and C.name ='npro'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransaction] DROP COLUMN npro
	DELETE FROM columntypes WHERE tablename = 'banktransaction' AND field = 'npro'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds_bank'
		and C.name ='ypro'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds_bank] DROP COLUMN ypro
	DELETE FROM columntypes WHERE tablename = 'proceeds_bank' AND field = 'ypro'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds_bank'
		and C.name ='npro'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds_bank] DROP COLUMN npro
	DELETE FROM columntypes WHERE tablename = 'proceeds_bank' AND field = 'npro'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomelast'
		and C.name ='npro'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomelast] DROP COLUMN npro
	DELETE FROM columntypes WHERE tablename = 'incomelast' AND field = 'npro'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso) - NON SERVE
-- Tabelle interessate -

-- Passo 6. Valorizzazione nuovo campo - Gia fatto a priori

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'kpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ALTER COLUMN kpro int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'kpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ALTER COLUMN kpro int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('proceeds') and constid=object_id('xpkproceeds'))
BEGIN
	ALTER TABLE [proceeds] ADD CONSTRAINT xpkproceeds PRIMARY KEY (kpro)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('proceeds') and constid=object_id('ukproceeds'))
BEGIN
	ALTER TABLE [proceeds] ADD CONSTRAINT ukproceeds UNIQUE (ypro, npro)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('proceeds_bank') and constid=object_id('xpkproceeds_bank'))
BEGIN
	ALTER TABLE [proceeds_bank] ADD CONSTRAINT xpkproceeds_bank PRIMARY KEY (kpro, idpro)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi6proceeds' and id=object_id('proceeds'))
BEGIN
	CREATE NONCLUSTERED INDEX xi6proceeds ON proceeds (ypro, npro)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi6proceeds
	ON proceeds (ypro, npro)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3banktransaction' and id=object_id('banktransaction'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3banktransaction ON banktransaction (kpro)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3banktransaction
	ON banktransaction (kpro)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceeds_bank' and id=object_id('proceeds_bank'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1proceeds_bank ON proceeds_bank (kpro)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1proceeds_bank
	ON proceeds_bank (kpro)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomelast' and id=object_id('incomelast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomelast ON incomelast (kpro, idpro)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomelast
	ON incomelast (kpro, idpro)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomelast' and id=object_id('incomelast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomelast ON incomelast (kpro)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomelast
	ON incomelast (kpro)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'banktransaction' AND field = 'kpro')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-03 12:57:42.060'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:57:42.060'} WHERE tablename = 'banktransaction' AND field = 'kpro'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('banktransaction','kpro','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-12-03 12:57:42.060'},'''NINO''','NINO',{ts '2007-12-03 12:57:42.060'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomelast' AND field = 'kpro')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-03 12:57:53.497'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:57:53.497'} WHERE tablename = 'incomelast' AND field = 'kpro'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('incomelast','kpro','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-12-03 12:57:53.497'},'''NINO''','NINO',{ts '2007-12-03 12:57:53.497'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceeds' AND field = 'kpro')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 12:57:56.060'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:57:56.060'} WHERE tablename = 'proceeds' AND field = 'kpro'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('proceeds','kpro','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 12:57:56.060'},'''NINO''','NINO',{ts '2007-12-03 12:57:56.060'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceeds' AND field = 'npro')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 12:57:56.043'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:57:56.043'} WHERE tablename = 'proceeds' AND field = 'npro'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('proceeds','npro','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 12:57:56.043'},'''NINO''','NINO',{ts '2007-12-03 12:57:56.043'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceeds' AND field = 'ypro')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 12:57:56.043'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:57:56.043'} WHERE tablename = 'proceeds' AND field = 'ypro'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('proceeds','ypro','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 12:57:56.043'},'''NINO''','NINO',{ts '2007-12-03 12:57:56.043'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceeds_bank' AND field = 'kpro')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 12:57:43.167'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 12:57:43.167'} WHERE tablename = 'proceeds_bank' AND field = 'kpro'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('proceeds_bank','kpro','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 12:57:43.167'},'''NINO''','NINO',{ts '2007-12-03 12:57:43.167'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='kproint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN kproint
END
GO

