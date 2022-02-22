
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


-- Aggiornamento tabella POSITION e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- allowanceruledetail, foreigngroupruledetail, itinerationrefundruledetail, registrylegalstatus

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO position (idposition, description, active, ct, cu, lt, lu)
SELECT DISTINCT idposition, idposition, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM allowanceruledetail e
WHERE NOT EXISTS(SELECT * FROM position k WHERE k.idposition = e.idposition)
GO

INSERT INTO position (idposition, description, active, ct, cu, lt, lu)
SELECT DISTINCT idposition, idposition, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM foreigngroupruledetail e
WHERE NOT EXISTS(SELECT * FROM position k WHERE k.idposition = e.idposition)
GO

INSERT INTO position (idposition, description, active, ct, cu, lt, lu)
SELECT DISTINCT idposition, idposition, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM itinerationrefundruledetail e
WHERE NOT EXISTS(SELECT * FROM position k WHERE k.idposition = e.idposition)
GO

INSERT INTO position (idposition, description, active, ct, cu, lt, lu)
SELECT DISTINCT idposition, idposition, 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM registrylegalstatus e
WHERE NOT EXISTS(SELECT * FROM position k WHERE k.idposition = e.idposition)
AND e.idposition IS NOT NULL
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'position' and C.name = 'idpositionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [position] ADD idpositionint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'position' and C.name = 'codeposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [position] ADD codeposition varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [position] ALTER COLUMN codeposition varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allowanceruledetail' and C.name = 'idpositionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allowanceruledetail] ADD idpositionint int NULL
END
ELSE
BEGIN
	ALTER TABLE [allowanceruledetail] ALTER COLUMN idpositionint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigngroupruledetail' and C.name = 'idpositionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreigngroupruledetail] ADD idpositionint int NULL
END
ELSE
BEGIN
	ALTER TABLE [foreigngroupruledetail] ALTER COLUMN idpositionint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundruledetail' and C.name = 'idpositionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefundruledetail] ADD idpositionint int NULL
END
ELSE
BEGIN
	ALTER TABLE [itinerationrefundruledetail] ALTER COLUMN idpositionint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrylegalstatus' and C.name = 'idpositionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrylegalstatus] ADD idpositionint int NULL
END
ELSE
BEGIN
	ALTER TABLE [registrylegalstatus] ALTER COLUMN idpositionint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'position' and C.name = 'codeposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE position SET codeposition = idposition
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allowanceruledetail' and C.name = 'idpositionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE allowanceruledetail SET idpositionint = position.idpositionint
	FROM position
	WHERE position.idposition = allowanceruledetail.idposition
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigngroupruledetail' and C.name = 'idpositionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE foreigngroupruledetail SET idpositionint = position.idpositionint
	FROM position
	WHERE position.idposition = foreigngroupruledetail.idposition
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundruledetail' and C.name = 'idpositionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationrefundruledetail SET idpositionint = position.idpositionint
	FROM position
	WHERE position.idposition = itinerationrefundruledetail.idposition
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrylegalstatus' and C.name = 'idpositionint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrylegalstatus SET idpositionint = position.idpositionint
	FROM position
	WHERE position.idposition = registrylegalstatus.idposition
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono position
IF exists(SELECT * FROM sysconstraints where id=object_id('position') and constid=object_id('xpkposition'))
BEGIN
	ALTER TABLE [position] drop constraint xpkposition
END

IF exists(SELECT * FROM sysconstraints where id=object_id('position') and constid=object_id('PK_position'))
BEGIN
	ALTER TABLE [position] drop constraint PK_position
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono invoicekind, expenseinvoice, incomeinvoice, invoice, invoicedetail, ivaregister, 
IF EXISTS (SELECT * FROM sysindexes where name='xi3registrylegalstatus' and id=object_id('registrylegalstatus'))
	drop index registrylegalstatus.xi3registrylegalstatus
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'position'
		and C.name ='idposition'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [position] DROP COLUMN idposition
	DELETE FROM columntypes WHERE tablename = 'position' AND field = 'idposition'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'allowanceruledetail'
		and C.name ='idposition'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [allowanceruledetail] DROP COLUMN idposition
	DELETE FROM columntypes WHERE tablename = 'allowanceruledetail' AND field = 'idposition'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'foreigngroupruledetail'
		and C.name ='idposition'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [foreigngroupruledetail] DROP COLUMN idposition
	DELETE FROM columntypes WHERE tablename = 'foreigngroupruledetail' AND field = 'idposition'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationrefundruledetail'
		and C.name ='idposition'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationrefundruledetail] DROP COLUMN idposition
	DELETE FROM columntypes WHERE tablename = 'itinerationrefundruledetail' AND field = 'idposition'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrylegalstatus'
		and C.name ='idposition'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrylegalstatus] DROP COLUMN idposition
	DELETE FROM columntypes WHERE tablename = 'registrylegalstatus' AND field = 'idposition'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate position e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'position' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [position] ADD idposition int NULL 
END
ELSE
	ALTER TABLE [position] ALTER COLUMN idposition int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allowanceruledetail' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allowanceruledetail] ADD idposition int NULL 
END
ELSE
	ALTER TABLE [allowanceruledetail] ALTER COLUMN idposition int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigngroupruledetail' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreigngroupruledetail] ADD idposition int NULL 
END
ELSE
	ALTER TABLE [foreigngroupruledetail] ALTER COLUMN idposition int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundruledetail' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefundruledetail] ADD idposition int NULL 
END
ELSE
	ALTER TABLE [itinerationrefundruledetail] ALTER COLUMN idposition int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrylegalstatus' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrylegalstatus] ADD idposition int NULL 
END
ELSE
	ALTER TABLE [registrylegalstatus] ALTER COLUMN idposition int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'position' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE position SET idposition = idpositionint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allowanceruledetail' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE allowanceruledetail SET idposition = idpositionint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigngroupruledetail' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE foreigngroupruledetail SET idposition = idpositionint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundruledetail' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationrefundruledetail SET idposition = idpositionint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrylegalstatus' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrylegalstatus SET idposition = idpositionint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'position' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [position] ALTER COLUMN idposition int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'position' and C.name = 'codeposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [position] ALTER COLUMN codeposition varchar(20) NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allowanceruledetail' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allowanceruledetail] ALTER COLUMN idposition int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigngroupruledetail' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreigngroupruledetail] ALTER COLUMN idposition int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefundruledetail' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefundruledetail] ALTER COLUMN idposition int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('position') and constid=object_id('xpkposition'))
BEGIN
	ALTER TABLE [position] ADD CONSTRAINT xpkposition PRIMARY KEY (idposition)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('position') and constid=object_id('ukposition'))
BEGIN
	ALTER TABLE [position] ADD CONSTRAINT ukposition UNIQUE (codeposition)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1position' and id=object_id('position'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1position ON position (codeposition)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1position
	ON position (codeposition)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi3registrylegalstatus' and id=object_id('registrylegalstatus'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3registrylegalstatus ON registrylegalstatus (idposition)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3registrylegalstatus
	ON registrylegalstatus (idposition)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'allowanceruledetail' AND field = 'idposition')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 11:21:08.467'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 11:21:08.467'} WHERE tablename = 'allowanceruledetail' AND field = 'idposition'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('allowanceruledetail','idposition','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-20 11:21:08.467'},'''NINO''','NINO',{ts '2007-11-20 11:21:08.467'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'foreigngroupruledetail' AND field = 'idposition')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 11:20:57.563'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 11:20:57.563'} WHERE tablename = 'foreigngroupruledetail' AND field = 'idposition'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('foreigngroupruledetail','idposition','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-20 11:20:57.563'},'''NINO''','NINO',{ts '2007-11-20 11:20:57.563'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationrefundruledetail' AND field = 'idposition')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 11:20:57.797'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 11:20:57.797'} WHERE tablename = 'itinerationrefundruledetail' AND field = 'idposition'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationrefundruledetail','idposition','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-20 11:20:57.797'},'''NINO''','NINO',{ts '2007-11-20 11:20:57.797'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'position' AND field = 'codeposition')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 11:20:58.703'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 11:20:58.703'} WHERE tablename = 'position' AND field = 'codeposition'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('position','codeposition','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-20 11:20:58.703'},'''NINO''','NINO',{ts '2007-11-20 11:20:58.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'position' AND field = 'idposition')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-20 11:20:58.703'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 11:20:58.703'} WHERE tablename = 'position' AND field = 'idposition'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('position','idposition','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-20 11:20:58.703'},'''NINO''','NINO',{ts '2007-11-20 11:20:58.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registrylegalstatus' AND field = 'idposition')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-20 11:21:02.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-20 11:21:02.530'} WHERE tablename = 'registrylegalstatus' AND field = 'idposition'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registrylegalstatus','idposition','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-20 11:21:02.530'},'''NINO''','NINO',{ts '2007-11-20 11:21:02.530'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'position'
		and C.name ='idpositionint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [position] DROP COLUMN idpositionint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'allowanceruledetail'
		and C.name ='idpositionint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [allowanceruledetail] DROP COLUMN idpositionint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'foreigngroupruledetail'
		and C.name ='idpositionint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [foreigngroupruledetail] DROP COLUMN idpositionint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationrefundruledetail'
		and C.name ='idpositionint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationrefundruledetail] DROP COLUMN idpositionint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrylegalstatus'
		and C.name ='idpositionint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrylegalstatus] DROP COLUMN idpositionint
END
GO
