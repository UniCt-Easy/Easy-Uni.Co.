
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


-- CREAZIONE TABELLA finlast --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finlast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finlast] (
idfin int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
expiration datetime NULL,
idman int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkfinlast PRIMARY KEY (idfin
)
)
END
GO

-- VERIFICA STRUTTURA finlast --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlast' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlast] ADD idfin int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('finlast') and col.name = 'idfin' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [finlast] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlast' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlast] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('finlast') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [finlast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [finlast] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlast' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlast] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('finlast') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [finlast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [finlast] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlast' and C.name = 'expiration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlast] ADD expiration datetime NULL 
END
ELSE
	ALTER TABLE [finlast] ALTER COLUMN expiration datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlast' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlast] ADD idman int NULL 
END
ELSE
	ALTER TABLE [finlast] ALTER COLUMN idman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlast' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlast] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('finlast') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [finlast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [finlast] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlast' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlast] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('finlast') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [finlast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [finlast] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI finlast IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'finlast'
IF exists(SELECT * FROM columntypes WHERE tablename = 'finlast' AND field = 'idfin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'S',tablename = 'finlast',denynull = 'S',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'finlast' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','S','finlast','S','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlast' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finlast',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'finlast' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','finlast','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlast' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'finlast',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'finlast' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','finlast','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlast' AND field = 'expiration')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finlast',denynull = 'N',format = '',col_len = '8',field = 'expiration',col_precision = '' where tablename = 'finlast' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','finlast','N','','8','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlast' AND field = 'idman')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finlast',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'finlast' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','finlast','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlast' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finlast',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'finlast' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','finlast','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlast' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'finlast',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'finlast' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','finlast','S','','64','lu','')
GO

-- VERIFICA DI finlast IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'finlast')
UPDATE customobject set isreal = 'S' where objectname = 'finlast'
ELSE
INSERT INTO customobject (objectname, isreal) values('finlast', 'S')
GO
-- FINE GENERAZIONE SCRIPT --
INSERT INTO finlast
(
	idfin, idman, expiration, ct, cu, lt, lu
)
SELECT
	t1.idfin, t1.idman, t1.expiration,
	GETDATE(), 'SA', GETDATE(), '''SA'''
FROM fin AS t1
LEFT JOIN fin as t2
	ON t1.idfin = t2.paridfin
WHERE t2.idfin IS NULL
GO
-- Aggiunta del campo FLAG a FIN
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ADD flag tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [fin] ALTER COLUMN flag tinyint NULL
END
GO

UPDATE fin SET flag = 
	CASE
		WHEN finpart = 'S' THEN 1
		ELSE 0
	END +
	CASE
		WHEN ISNULL(flagcontra, 'N') = 'S' THEN 2
		ELSE 0
	END +
	CASE
		WHEN ISNULL(flaginternaltransfer,'N') = 'S' THEN 4
		ELSE 0
	END


ALTER TABLE [fin] ALTER COLUMN flag tinyint NOT NULL
GO

-- Scrittura in COLUMNTYPES del campo FLAG di FIN
IF exists(SELECT * FROM columntypes WHERE tablename = 'fin' AND field = 'flag')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'fin',denynull = 'S',format = '',col_len = '4',field = 'flag',col_precision = '' where tablename = 'fin' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision)
VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','N','fin','S','','4','flag','')
GO

-- Cancellazione dei campi da FIN
-- DROP degli indici
IF EXISTS (SELECT * FROM sysindexes where name='xi6fin' and id=object_id('fin'))
	drop index fin.xi6fin
go

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_fin' and id=object_id('fin'))
	drop index fin.UQ_1_fin
go

IF EXISTS (SELECT * FROM sysindexes where name='UQ_2_fin' and id=object_id('fin'))
	drop index fin.UQ_2_fin
go

--- Creazione vincoli di univocità sulle terne (ayear, flag, codefin) e (ayear, flag, printingorder)
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('fin') and constid=object_id('uq1fin'))
BEGIN
	ALTER TABLE [fin] ADD CONSTRAINT uq1fin UNIQUE (ayear, flag, codefin)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('fin') and constid=object_id('uq2fin'))
BEGIN
	ALTER TABLE [fin] ADD CONSTRAINT uq2fin UNIQUE (ayear, flag, printingorder)
END
GO

-- Drop dei campi definitivamente morti
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='flagcontra'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN flagcontra
	DELETE FROM columntypes WHERE tablename = 'fin' AND field = 'flagcontra'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='flaginternaltransfer'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN flaginternaltransfer
	DELETE FROM columntypes WHERE tablename = 'fin' AND field = 'flaginternaltransfer'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='flagthirdparties'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN flagthirdparties
	DELETE FROM columntypes WHERE tablename = 'fin' AND field = 'flagthirdparties'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='finpart'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN finpart
	DELETE FROM columntypes WHERE tablename = 'fin' AND field = 'finpart'
END
GO

-- Drop dei campi spostati in altre tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'fin' AND field = 'idman'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='expiration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN expiration
	DELETE FROM columntypes WHERE tablename = 'fin' AND field = 'expiration'
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1finlast' and id=object_id('finlast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1finlast ON finlast (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1finlast
	ON finlast (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO
