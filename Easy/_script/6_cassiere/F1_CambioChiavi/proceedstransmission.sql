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

﻿-- Aggiornamento tabella PROCEEDSTRANSMISSION e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- proceeds

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento) e Passo 2. (aggiunta delle colonne nelle tabelle referenziate)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'kproceedstransmissionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedstransmission] ADD kproceedstransmissionint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'kproceedstransmission' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedstransmission] ADD kproceedstransmission int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'kproceedstransmission' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ADD kproceedstransmission int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'kproceedstransmissionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceedstransmission SET kproceedstransmission = kproceedstransmissionint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'kproceedstransmission' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceeds SET kproceedstransmission = proceedstransmission.kproceedstransmission
	FROM proceedstransmission
	WHERE proceeds.yproceedstransmission = proceedstransmission.yproceedstransmission AND proceeds.nproceedstransmission = proceedstransmission.nproceedstransmission
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono proceedstransmission
IF exists(SELECT * FROM sysconstraints where id=object_id('proceedstransmission') and constid=object_id('xpkproceedstransmission'))
BEGIN
	ALTER TABLE [proceedstransmission] drop constraint xpkproceedstransmission
END

IF exists(SELECT * FROM sysconstraints where id=object_id('proceedstransmission') and constid=object_id('PK_proceedstransmission'))
BEGIN
	ALTER TABLE [proceedstransmission] drop constraint PK_proceedstransmission
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono proceeds
IF EXISTS (SELECT * FROM sysindexes where name='xi1proceeds' and id=object_id('proceeds'))
	drop index proceeds.xi1proceeds
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='yproceedstransmission'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN yproceedstransmission
	DELETE FROM columntypes WHERE tablename = 'proceeds' AND field = 'yproceedstransmission'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='nproceedstransmission'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN nproceedstransmission
	DELETE FROM columntypes WHERE tablename = 'proceeds' AND field = 'nproceedstransmission'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso) - NON SERVE
-- Tabelle interessate -

-- Passo 6. Valorizzazione nuovo campo - Gia fatto a priori

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'kproceedstransmission' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedstransmission] ALTER COLUMN kproceedstransmission int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('proceedstransmission') and constid=object_id('xpkproceedstransmission'))
BEGIN
	ALTER TABLE [proceedstransmission] ADD CONSTRAINT xpkproceedstransmission PRIMARY KEY (kproceedstransmission)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('proceedstransmission') and constid=object_id('ukproceedstransmission'))
BEGIN
	ALTER TABLE [proceedstransmission] ADD CONSTRAINT ukproceedstransmission UNIQUE (yproceedstransmission, nproceedstransmission)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi4proceedstransmission' and id=object_id('proceedstransmission'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4proceedstransmission ON proceedstransmission (yproceedstransmission, nproceedstransmission)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4proceedstransmission
	ON proceedstransmission (yproceedstransmission, nproceedstransmission)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceeds' and id=object_id('proceeds'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1proceeds ON proceeds (kproceedstransmission)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1proceeds
	ON proceeds (kproceedstransmission)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceeds' AND field = 'kproceedstransmission')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-03 13:25:49.823'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 13:25:49.823'} WHERE tablename = 'proceeds' AND field = 'kproceedstransmission'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('proceeds','kproceedstransmission','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-12-03 13:25:49.823'},'''NINO''','NINO',{ts '2007-12-03 13:25:49.823'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceedstransmission' AND field = 'kproceedstransmission')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 13:25:50.027'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 13:25:50.027'} WHERE tablename = 'proceedstransmission' AND field = 'kproceedstransmission'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('proceedstransmission','kproceedstransmission','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 13:25:50.027'},'''NINO''','NINO',{ts '2007-12-03 13:25:50.027'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceedstransmission' AND field = 'nproceedstransmission')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 13:25:50.013'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 13:25:50.013'} WHERE tablename = 'proceedstransmission' AND field = 'nproceedstransmission'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('proceedstransmission','nproceedstransmission','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 13:25:50.013'},'''NINO''','NINO',{ts '2007-12-03 13:25:50.013'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceedstransmission' AND field = 'yproceedstransmission')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 13:25:50.013'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 13:25:50.013'} WHERE tablename = 'proceedstransmission' AND field = 'yproceedstransmission'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('proceedstransmission','yproceedstransmission','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 13:25:50.013'},'''NINO''','NINO',{ts '2007-12-03 13:25:50.013'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceedstransmission'
		and C.name ='kproceedstransmissionint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceedstransmission] DROP COLUMN kproceedstransmissionint
END
GO
	