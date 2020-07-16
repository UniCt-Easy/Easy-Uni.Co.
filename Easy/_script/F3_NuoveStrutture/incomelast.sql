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

﻿-- CREAZIONE TABELLA incomelast --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incomelast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incomelast] (
idinc int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag tinyint NOT NULL,
idpro int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbill int NULL,
npro int NULL,
 CONSTRAINT xpkincomelast PRIMARY KEY (idinc
)
)
END
GO

-- VERIFICA STRUTTURA incomelast --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelast] ADD idinc int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('incomelast') and col.name = 'idinc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [incomelast] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelast] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('incomelast') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [incomelast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [incomelast] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelast] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('incomelast') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [incomelast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [incomelast] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelast] ADD flag tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('incomelast') and col.name = 'flag' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [incomelast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [incomelast] ALTER COLUMN flag tinyint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'idpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelast] ADD idpro int NULL 
END
ELSE
	ALTER TABLE [incomelast] ALTER COLUMN idpro int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelast] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('incomelast') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [incomelast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [incomelast] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelast] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('incomelast') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [incomelast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [incomelast] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'nbill' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelast] ADD nbill int NULL 
END
ELSE
	ALTER TABLE [incomelast] ALTER COLUMN nbill int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelast' and C.name = 'npro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelast] ADD npro int NULL 
END
ELSE
	ALTER TABLE [incomelast] ALTER COLUMN npro int NULL
GO

-- VERIFICA DI incomelast IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'incomelast'
IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelast' AND field = 'idinc')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'S',tablename = 'incomelast',denynull = 'S',format = '',col_len = '4',field = 'idinc',col_precision = '' where tablename = 'incomelast' AND field = 'idinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','S','incomelast','S','','4','idinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelast' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'incomelast',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'incomelast' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','incomelast','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelast' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'incomelast',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'incomelast' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','incomelast','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelast' AND field = 'flag')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'incomelast',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'incomelast' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','N','incomelast','S','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelast' AND field = 'idpro')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'incomelast',denynull = 'N',format = '',col_len = '4',field = 'idpro',col_precision = '' where tablename = 'incomelast' AND field = 'idpro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','incomelast','N','','4','idpro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelast' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'incomelast',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'incomelast' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','incomelast','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelast' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'incomelast',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'incomelast' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','incomelast','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelast' AND field = 'nbill')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'incomelast',denynull = 'N',format = '',col_len = '4',field = 'nbill',col_precision = '' where tablename = 'incomelast' AND field = 'nbill'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','incomelast','N','','4','nbill','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelast' AND field = 'npro')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'incomelast',denynull = 'N',format = '',col_len = '4',field = 'npro',col_precision = '' where tablename = 'incomelast' AND field = 'npro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','incomelast','N','','4','npro','')
GO

-- VERIFICA DI incomelast IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'incomelast')
UPDATE customobject set isreal = 'S' where objectname = 'incomelast'
ELSE
INSERT INTO customobject (objectname, isreal) values('incomelast', 'S')
GO
-- FINE GENERAZIONE SCRIPT --

DECLARE @maxincomephase char(1)
SELECT @maxincomephase = MAX(nphase) FROM incomephase

INSERT INTO incomelast
(
	idinc,
	npro,
	idpro,
	nbill,
	flag,
	ct, cu, lt, lu
)
SELECT 
	idinc,
	npro,
	idpro,
	nbill,
	CASE
		WHEN ISNULL(fulfilled,'N') = 'S' THEN 1
		ELSE 0
	END,
	ct, cu, lt, lu
FROM income
WHERE nphase = @maxincomephase
AND NOT EXISTS(SELECT idinc FROM incomelast WHERE incomelast.idinc = income.idinc)
GO

-- Cancellazione dei campi da INCOME
-- DROP degli indici
IF EXISTS (SELECT * FROM sysindexes where name='xi6income' and id=object_id('income'))
	drop index income.xi6income
go

-- Drop dei campi definitivamente morti
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='amount'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN amount
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'amount'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='ycreation'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN ycreation
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'ycreation'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='ypro'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN ypro
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'ypro'
END
GO

-- Drop dei campi spostati in altre tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='npro'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN npro
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'npro'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='idpro'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN idpro
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'idpro'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='nbill'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN nbill
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'nbill'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='fulfilled'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN fulfilled
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'fulfilled'
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomelast' and id=object_id('incomelast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomelast ON incomelast (npro, idpro)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomelast
	ON incomelast (npro, idpro)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomelast' and id=object_id('incomelast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomelast ON incomelast (npro)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomelast
	ON incomelast (npro)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO
	