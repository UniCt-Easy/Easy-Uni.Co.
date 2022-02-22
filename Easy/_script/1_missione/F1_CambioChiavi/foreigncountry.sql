
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


-- Aggiornamento tabella FOREIGNCOUNTRY e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- foreignallowancerule, itinerationlap

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO foreigncountry (idforeigncountry, description, ct, cu, lt, lu)
SELECT DISTINCT idforeigncountry, idforeigncountry, GETDATE(), 'SA', GETDATE(), 'SA'
FROM foreignallowancerule
WHERE NOT EXISTS(SELECT * FROM foreigncountry k WHERE k.idforeigncountry = foreignallowancerule.idforeigncountry)

INSERT INTO foreigncountry (idforeigncountry, description, ct, cu, lt, lu)
SELECT DISTINCT idforeigncountry, idforeigncountry, GETDATE(), 'SA', GETDATE(), 'SA'
FROM itinerationlap
WHERE NOT EXISTS(SELECT * FROM foreigncountry k WHERE k.idforeigncountry = itinerationlap.idforeigncountry)
AND idforeigncountry IS NOT NULL

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigncountry' and C.name = 'idforeigncountryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreigncountry] ADD idforeigncountryint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigncountry' and C.name = 'codeforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreigncountry] ADD codeforeigncountry varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [foreigncountry] ALTER COLUMN codeforeigncountry varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreignallowancerule' and C.name = 'idforeigncountryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreignallowancerule] ADD idforeigncountryint int NULL
END
ELSE
BEGIN
	ALTER TABLE [foreignallowancerule] ALTER COLUMN idforeigncountryint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationlap' and C.name = 'idforeigncountryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationlap] ADD idforeigncountryint int NULL
END
ELSE
BEGIN
	ALTER TABLE [itinerationlap] ALTER COLUMN idforeigncountryint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigncountry' and C.name = 'codeforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE foreigncountry SET codeforeigncountry = idforeigncountry
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreignallowancerule' and C.name = 'idforeigncountryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE foreignallowancerule SET idforeigncountryint = foreigncountry.idforeigncountryint
	FROM foreigncountry
	WHERE foreigncountry.idforeigncountry = foreignallowancerule.idforeigncountry
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationlap' and C.name = 'idforeigncountryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationlap SET idforeigncountryint = foreigncountry.idforeigncountryint
	FROM foreigncountry
	WHERE itinerationlap.idforeigncountry = foreigncountry.idforeigncountry
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono foreigncountry
IF exists(SELECT * FROM sysconstraints where id=object_id('foreigncountry') and constid=object_id('xpkforeigncountry'))
BEGIN
	ALTER TABLE [foreigncountry] drop constraint xpkforeigncountry
END

IF exists(SELECT * FROM sysconstraints where id=object_id('foreigncountry') and constid=object_id('PK_foreigncountry'))
BEGIN
	ALTER TABLE [foreigncountry] drop constraint PK_foreigncountry
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetacquire, assetloadkind, assetunloadkind, assetvardetail
IF EXISTS (SELECT * FROM sysindexes where name='xi1foreignallowancerule' and id=object_id('foreignallowancerule'))
	drop index foreignallowancerule.xi1foreignallowancerule
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2itinerationlap' and id=object_id('itinerationlap'))
	drop index itinerationlap.xi2itinerationlap
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'foreigncountry'
		and C.name ='idforeigncountry'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [foreigncountry] DROP COLUMN idforeigncountry
	DELETE FROM columntypes WHERE tablename = 'foreigncountry' AND field = 'idforeigncountry'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'foreignallowancerule'
		and C.name ='idforeigncountry'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [foreignallowancerule] DROP COLUMN idforeigncountry
	DELETE FROM columntypes WHERE tablename = 'foreignallowancerule' AND field = 'idforeigncountry'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationlap'
		and C.name ='idforeigncountry'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationlap] DROP COLUMN idforeigncountry
	DELETE FROM columntypes WHERE tablename = 'itinerationlap' AND field = 'idforeigncountry'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigncountry' and C.name = 'idforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreigncountry] ADD idforeigncountry int NULL 
END
ELSE
	ALTER TABLE [foreigncountry] ALTER COLUMN idforeigncountry int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreignallowancerule' and C.name = 'idforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreignallowancerule] ADD idforeigncountry int NULL 
END
ELSE
	ALTER TABLE [foreignallowancerule] ALTER COLUMN idforeigncountry int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationlap' and C.name = 'idforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationlap] ADD idforeigncountry int NULL 
END
ELSE
	ALTER TABLE [itinerationlap] ALTER COLUMN idforeigncountry int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigncountry' and C.name = 'idforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE foreigncountry SET idforeigncountry = idforeigncountryint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreignallowancerule' and C.name = 'idforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE foreignallowancerule SET idforeigncountry = idforeigncountryint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationlap' and C.name = 'idforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationlap SET idforeigncountry = idforeigncountryint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigncountry' and C.name = 'idforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreigncountry] ALTER COLUMN idforeigncountry int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreigncountry' and C.name = 'codeforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreigncountry] ALTER COLUMN codeforeigncountry varchar(20) NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'foreignallowancerule' and C.name = 'idforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [foreignallowancerule] ALTER COLUMN idforeigncountry int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('foreigncountry') and constid=object_id('xpkforeigncountry'))
BEGIN
	ALTER TABLE [foreigncountry] ADD CONSTRAINT xpkforeigncountry PRIMARY KEY (idforeigncountry)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('foreigncountry') and constid=object_id('ukforeigncountry'))
BEGIN
	ALTER TABLE [foreigncountry] ADD CONSTRAINT ukforeigncountry UNIQUE (codeforeigncountry)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1foreigncountry' and id=object_id('foreigncountry'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1foreigncountry ON foreigncountry (codeforeigncountry)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1foreigncountry
	ON foreigncountry (codeforeigncountry)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1foreignallowancerule' and id=object_id('foreignallowancerule'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1foreignallowancerule ON foreignallowancerule (idforeigncountry)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1foreignallowancerule
	ON foreignallowancerule (idforeigncountry)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2itinerationlap' and id=object_id('itinerationlap'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2itinerationlap ON itinerationlap (idforeigncountry)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2itinerationlap
	ON itinerationlap (idforeigncountry)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'foreignallowancerule' AND field = 'idforeigncountry')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 10:43:48.047'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 10:43:48.047'} WHERE tablename = 'foreignallowancerule' AND field = 'idforeigncountry'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('foreignallowancerule','idforeigncountry','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-13 10:43:48.047'},'''NINO''','NINO',{ts '2007-11-13 10:43:48.047'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'foreigncountry' AND field = 'codeforeigncountry')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 10:43:55.250'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 10:43:55.250'} WHERE tablename = 'foreigncountry' AND field = 'codeforeigncountry'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('foreigncountry','codeforeigncountry','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-13 10:43:55.250'},'''NINO''','NINO',{ts '2007-11-13 10:43:55.250'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'foreigncountry' AND field = 'idforeigncountry')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-13 10:43:55.250'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 10:43:55.250'} WHERE tablename = 'foreigncountry' AND field = 'idforeigncountry'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('foreigncountry','idforeigncountry','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-13 10:43:55.250'},'''NINO''','NINO',{ts '2007-11-13 10:43:55.250'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationlap' AND field = 'idforeigncountry')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-13 10:43:47.797'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-13 10:43:47.797'} WHERE tablename = 'itinerationlap' AND field = 'idforeigncountry'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationlap','idforeigncountry','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-13 10:43:47.797'},'''NINO''','NINO',{ts '2007-11-13 10:43:47.797'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'foreigncountry'
		and C.name ='idforeigncountryint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [foreigncountry] DROP COLUMN idforeigncountryint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'foreignallowancerule'
		and C.name ='idforeigncountryint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [foreignallowancerule] DROP COLUMN idforeigncountryint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationlap'
		and C.name ='idforeigncountryint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationlap] DROP COLUMN idforeigncountryint
END
GO
