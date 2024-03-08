
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


-- Aggiornamento tabella ASSETVAR e ASSETVARDETAIL

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DELETE FROM assetvardetail WHERE NOT EXISTS(SELECT * FROM assetvar WHERE assetvar.yvar = assetvardetail.yvar AND assetvar.nvar = assetvardetail.nvar)

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento) e Passo 2. (aggiunta delle colonne nelle tabelle referenziate)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvar' and C.name = 'idassetvarint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvar] ADD idassetvarint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvar' and C.name = 'idassetvar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvar] ADD idassetvar int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idassetvar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvardetail] ADD idassetvar int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idassetvardetail' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvardetail] ADD idassetvardetail int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvar' and C.name = 'idassetvar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetvar SET idassetvar = idassetvarint
	FROM assetvar
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idassetvar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetvardetail SET idassetvar = assetvar.idassetvar
	FROM assetvar
	WHERE assetvardetail.yvar = assetvar.yvar AND assetvardetail.nvar = assetvar.nvar
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idassetvar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetvardetail
	SET idassetvardetail = 1 +
		(SELECT COUNT(*)
		FROM assetvardetail a2
		WHERE assetvardetail.idassetvar = a2.idassetvar
			AND (((assetvardetail.idinv = a2.idinv) AND (assetvardetail.rownum < a2.rownum))
			OR (assetvardetail.idinv < a2.idinv)))
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono assetloadkind, assetload, assetloadexpense

IF exists(SELECT * FROM sysconstraints where id=object_id('assetvar') and constid=object_id('xpkassetvar'))
BEGIN
	ALTER TABLE [assetvar] drop constraint xpkassetvar
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetvar') and constid=object_id('PK_assetvar'))
BEGIN
	ALTER TABLE [assetvar] drop constraint PK_assetvar
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('assetvardetail') and constid=object_id('xpkassetvardetail'))
BEGIN
	ALTER TABLE [assetvardetail] drop constraint xpkassetvardetail
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetvardetail') and constid=object_id('PK_assetvardetail'))
BEGIN
	ALTER TABLE [assetvardetail] drop constraint PK_assetvardetail
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono assetvardetail
IF EXISTS (SELECT * FROM sysindexes where name='xi1assetvardetail' and id=object_id('assetvardetail'))
	drop index assetvardetail.xi1assetvardetail
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvardetail'
		and C.name ='yvar'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvardetail] DROP COLUMN yvar
	DELETE FROM columntypes WHERE tablename = 'assetvardetail' AND field = 'yvar'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvardetail'
		and C.name ='nvar'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvardetail] DROP COLUMN nvar
	DELETE FROM columntypes WHERE tablename = 'assetvardetail' AND field = 'nvar'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvardetail'
		and C.name ='rownum'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvardetail] DROP COLUMN rownum
	DELETE FROM columntypes WHERE tablename = 'assetvardetail' AND field = 'rownum'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso) - NON SERVE
-- Tabelle interessate -

-- Passo 6. Valorizzazione nuovo campo - Gia fatto a priori

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvar' and C.name = 'idassetvar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvar] ALTER COLUMN idassetvar int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idassetvar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvardetail] ALTER COLUMN idassetvar int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetvardetail' and C.name = 'idassetvardetail' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetvardetail] ALTER COLUMN idassetvardetail int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetvar') and constid=object_id('xpkassetvar'))
BEGIN
	ALTER TABLE [assetvar] ADD CONSTRAINT xpkassetvar PRIMARY KEY (idassetvar)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetvar') and constid=object_id('ukassetvar'))
BEGIN
	ALTER TABLE [assetvar] ADD CONSTRAINT ukassetvar UNIQUE (yvar, nvar)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetvardetail') and constid=object_id('xpkassetvardetail'))
BEGIN
	ALTER TABLE [assetvardetail] ADD CONSTRAINT xpkassetvardetail PRIMARY KEY (idassetvar, idassetvardetail)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2assetvar' and id=object_id('assetvar'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetvar ON assetvar (yvar, nvar)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetvar
	ON assetvar (yvar, nvar)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetvardetail' and id=object_id('assetvardetail'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetvardetail ON assetvardetail (idassetvar)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1assetvardetail
	ON assetvardetail (idassetvar)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetvar' AND field = 'idassetvar')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 13:57:21.750'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 13:57:21.750'} WHERE tablename = 'assetvar' AND field = 'idassetvar'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetvar','idassetvar','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 13:57:21.750'},'''NINO''','NINO',{ts '2007-10-24 13:57:21.750'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetvar' AND field = 'nvar')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 13:57:21.717'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 13:57:21.717'} WHERE tablename = 'assetvar' AND field = 'nvar'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetvar','nvar','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 13:57:21.717'},'''NINO''','NINO',{ts '2007-10-24 13:57:21.717'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetvar' AND field = 'yvar')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 13:57:21.717'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 13:57:21.717'} WHERE tablename = 'assetvar' AND field = 'yvar'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetvar','yvar','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-10-24 13:57:21.717'},'''NINO''','NINO',{ts '2007-10-24 13:57:21.717'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetvardetail' AND field = 'idassetvar')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 13:57:13.063'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 13:57:13.063'} WHERE tablename = 'assetvardetail' AND field = 'idassetvar'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetvardetail','idassetvar','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 13:57:13.063'},'''NINO''','NINO',{ts '2007-10-24 13:57:13.063'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetvardetail' AND field = 'idassetvardetail')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 13:57:13.063'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 13:57:13.063'} WHERE tablename = 'assetvardetail' AND field = 'idassetvardetail'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetvardetail','idassetvardetail','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 13:57:13.063'},'''NINO''','NINO',{ts '2007-10-24 13:57:13.063'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetvardetail' AND field = 'idinv')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 13:57:13.063'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 13:57:13.063'} WHERE tablename = 'assetvardetail' AND field = 'idinv'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetvardetail','idinv','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-10-24 13:57:13.063'},'''NINO''','NINO',{ts '2007-10-24 13:57:13.063'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetvar'
		and C.name ='idassetvarint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetvar] DROP COLUMN idassetvarint
END
GO

