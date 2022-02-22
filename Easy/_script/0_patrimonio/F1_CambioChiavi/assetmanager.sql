
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


-- Aggiornamento tabella ASSETMANAGER e tabelle dipendenti
-- Le tabelle dipendenti sono: -

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento) e Passo 2. (aggiunta delle colonne nelle tabelle referenziate)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetmanager' and C.name = 'idassetmanager' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetmanager] ADD idassetmanager int NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetmanager' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetmanager] ALTER COLUMN start smalldatetime NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetmanager' and C.name = 'idassetmanager' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetmanager
	SET idassetmanager = 1 +
		(SELECT COUNT(*)
		FROM assetmanager a2
		WHERE assetmanager.idasset = a2.idasset
			AND assetmanager.start < a2.start)
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono -

IF exists(SELECT * FROM sysconstraints where id=object_id('assetmanager') and constid=object_id('xpkassetmanager'))
BEGIN
	ALTER TABLE [assetmanager] drop constraint xpkassetmanager
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetmanager') and constid=object_id('PK_assetmanager'))
BEGIN
	ALTER TABLE [assetmanager] drop constraint PK_assetmanager
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetlocation
IF EXISTS (SELECT * FROM sysindexes where name='xi1assetmanager' and id=object_id('assetmanager'))
	drop index assetmanager.xi1assetmanager
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetmanager' and id=object_id('assetmanager'))
	drop index assetmanager.xi2assetmanager
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate - NON CI SONO CAMPI DA CANCELLARE

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso) - NON SERVE

-- Tabelle interessate -

-- Passo 6. Valorizzazione nuovo campo - Gia fatto a priori

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetmanager' and C.name = 'idassetmanager' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetmanager] ALTER COLUMN idassetmanager int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetmanager') and constid=object_id('xpkassetmanager'))
BEGIN
	ALTER TABLE [assetmanager] ADD CONSTRAINT xpkassetmanager PRIMARY KEY (idasset, idassetmanager)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1assetmanager' and id=object_id('assetmanager'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetmanager ON assetlocation (idasset)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetmanager
	ON assetmanager (idasset)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetmanager' and id=object_id('assetmanager'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetmanager ON assetmanager (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetmanager
	ON assetmanager (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetmanager' AND field = 'idassetmanager')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-30 16:31:14.750'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-30 16:31:14.750'} WHERE tablename = 'assetmanager' AND field = 'idassetmanager'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetmanager','idassetmanager','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-30 16:31:14.750'},'''NINO''','NINO',{ts '2007-10-30 16:31:14.750'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetmanager' AND field = 'start')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smalldatetime',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-10-30 16:31:14.733'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-30 16:31:14.733'} WHERE tablename = 'assetmanager' AND field = 'start'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetmanager','start','N','smalldatetime','4',null,null,'System.DateTime','smalldatetime','S','',null,'N',{ts '2007-10-30 16:31:14.733'},'''NINO''','NINO',{ts '2007-10-30 16:31:14.733'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle


