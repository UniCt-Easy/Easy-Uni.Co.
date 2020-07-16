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

﻿-- CREAZIONE TABELLA expenselast --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expenselast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expenselast] (
idexp int NOT NULL,
cc varchar(30) NULL,
cin varchar(2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag tinyint NOT NULL,
idbank varchar(20) NULL,
idcab varchar(20) NULL,
iddeputy int NULL,
idpay int NULL,
idpaymethod varchar(20) NULL,
idregistrypaymethod int NULL,
idser int NULL,
ivaamount decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbill int NULL,
npay int NULL,
paymentdescr varchar(150) NULL,
refexternaldoc varchar(5) NULL,
servicestart datetime NULL,
servicestop datetime NULL,
 CONSTRAINT xpkexpenselast PRIMARY KEY (idexp
)
)
END
GO

-- VERIFICA STRUTTURA expenselast --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD idexp int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expenselast') and col.name = 'idexp' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expenselast] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'cc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD cc varchar(30) NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN cc varchar(30) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'cin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD cin varchar(2) NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN cin varchar(2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expenselast') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expenselast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expenselast') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expenselast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD flag tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expenselast') and col.name = 'flag' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expenselast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN flag tinyint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idbank' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD idbank varchar(20) NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN idbank varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idcab' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD idcab varchar(20) NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN idcab varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'iddeputy' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD iddeputy int NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN iddeputy int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD idpay int NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN idpay int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idpaymethod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD idpaymethod varchar(20) NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN idpaymethod varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idregistrypaymethod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD idregistrypaymethod int NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN idregistrypaymethod int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD idser int NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN idser int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'ivaamount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD ivaamount decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN ivaamount decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expenselast') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expenselast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expenselast') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expenselast] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'nbill' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD nbill int NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN nbill int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'npay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD npay int NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN npay int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'paymentdescr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD paymentdescr varchar(150) NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN paymentdescr varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'refexternaldoc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD refexternaldoc varchar(5) NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN refexternaldoc varchar(5) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'servicestart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD servicestart datetime NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN servicestart datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselast' and C.name = 'servicestop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselast] ADD servicestop datetime NULL 
END
ELSE
	ALTER TABLE [expenselast] ALTER COLUMN servicestop datetime NULL
GO

-- VERIFICA DI expenselast IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'expenselast'
IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'idexp')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'S',tablename = 'expenselast',denynull = 'S',format = '',col_len = '4',field = 'idexp',col_precision = '' where tablename = 'expenselast' AND field = 'idexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','S','expenselast','S','','4','idexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'cc')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(30)',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '30',field = 'cc',col_precision = '' where tablename = 'expenselast' AND field = 'cc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(30)','N','expenselast','N','','30','cc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'cin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(2)',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '2',field = 'cin',col_precision = '' where tablename = 'expenselast' AND field = 'cin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(2)','N','expenselast','N','','2','cin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'expenselast',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'expenselast' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','expenselast','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'expenselast',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'expenselast' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','expenselast','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'flag')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'expenselast',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'expenselast' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','N','expenselast','S','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'idbank')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '20',field = 'idbank',col_precision = '' where tablename = 'expenselast' AND field = 'idbank'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','expenselast','N','','20','idbank','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'idcab')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '20',field = 'idcab',col_precision = '' where tablename = 'expenselast' AND field = 'idcab'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','expenselast','N','','20','idcab','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'iddeputy')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '4',field = 'iddeputy',col_precision = '' where tablename = 'expenselast' AND field = 'iddeputy'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','expenselast','N','','4','iddeputy','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'idpay')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '4',field = 'idpay',col_precision = '' where tablename = 'expenselast' AND field = 'idpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','expenselast','N','','4','idpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'idpaymethod')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '20',field = 'idpaymethod',col_precision = '' where tablename = 'expenselast' AND field = 'idpaymethod'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','expenselast','N','','20','idpaymethod','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'idregistrypaymethod')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '4',field = 'idregistrypaymethod',col_precision = '' where tablename = 'expenselast' AND field = 'idregistrypaymethod'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','expenselast','N','','4','idregistrypaymethod','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'idser')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '4',field = 'idser',col_precision = '' where tablename = 'expenselast' AND field = 'idser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','expenselast','N','','4','idser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'ivaamount')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '9',field = 'ivaamount',col_precision = '19' where tablename = 'expenselast' AND field = 'ivaamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expenselast','N','','9','ivaamount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'expenselast',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'expenselast' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','expenselast','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'expenselast',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'expenselast' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','expenselast','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'nbill')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '4',field = 'nbill',col_precision = '' where tablename = 'expenselast' AND field = 'nbill'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','expenselast','N','','4','nbill','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'npay')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '4',field = 'npay',col_precision = '' where tablename = 'expenselast' AND field = 'npay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','expenselast','N','','4','npay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'paymentdescr')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '150',field = 'paymentdescr',col_precision = '' where tablename = 'expenselast' AND field = 'paymentdescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','expenselast','N','','150','paymentdescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'refexternaldoc')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(5)',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '5',field = 'refexternaldoc',col_precision = '' where tablename = 'expenselast' AND field = 'refexternaldoc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(5)','N','expenselast','N','','5','refexternaldoc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'servicestart')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '8',field = 'servicestart',col_precision = '' where tablename = 'expenselast' AND field = 'servicestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','expenselast','N','','8','servicestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselast' AND field = 'servicestop')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'expenselast',denynull = 'N',format = '',col_len = '8',field = 'servicestop',col_precision = '' where tablename = 'expenselast' AND field = 'servicestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','expenselast','N','','8','servicestop','')
GO

-- VERIFICA DI expenselast IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'expenselast')
UPDATE customobject set isreal = 'S' where objectname = 'expenselast'
ELSE
INSERT INTO customobject (objectname, isreal) values('expenselast', 'S')
GO
-- FINE GENERAZIONE SCRIPT --

DECLARE @maxexpensephase char(1)
SELECT @maxexpensephase = MAX(nphase) FROM expensephase

INSERT INTO expenselast
(
	idexp,
	idser,
	servicestart,
	servicestop,
	ivaamount,
	npay,
	idpay,
	nbill,
	idbank,
	idcab,
	cc,
	cin,
	iddeputy,
	idpaymethod,
	idregistrypaymethod,
	paymentdescr,
	refexternaldoc,
	flag,
	ct, cu, lt, lu
)
SELECT 
	idexp,
	idser,
	servicestart,
	servicestop,
	ivaamount,
	npay,
	idpay,
	nbill,
	idbank,
	idcab,
	cc,
	SUBSTRING(cin, 1, 2),
	iddeputy,
	idpaymethod,
	idregistrypaymethod,
	paymentdescr,
	refexternaldoc,
	CASE
		WHEN ISNULL(fulfilled,'N') = 'S' THEN 1
		ELSE 0
	END +
	CASE
		WHEN ISNULL(autoclawbackflag,'N') = 'S' THEN 2
		ELSE 0
	END +
	CASE
		WHEN ISNULL(autotaxflag,'N') = 'S' THEN 4
		ELSE 0
	END,
	ct, cu, lt, lu
FROM expense
WHERE nphase = @maxexpensephase
AND NOT EXISTS(SELECT idexp FROM expenselast WHERE expenselast.idexp = expense.idexp)
GO

-- Cancellazione dei campi da EXPENSE
-- DROP degli indici

IF EXISTS (SELECT * FROM sysindexes where name='IX_expense' and id=object_id('expense'))
	drop index expense.IX_expense
go

IF EXISTS (SELECT * FROM sysindexes where name='xi10expense' and id=object_id('expense'))
	drop index expense.xi10expense
go

IF EXISTS (SELECT * FROM sysindexes where name='xi11expense' and id=object_id('expense'))
	drop index expense.xi11expense
go

IF EXISTS (SELECT * FROM sysindexes where name='xi13expense' and id=object_id('expense'))
	drop index expense.xi13expense
go

IF EXISTS (SELECT * FROM sysindexes where name='xi5expense2' and id=object_id('expense'))
	drop index expense.xi5expense2
go

IF EXISTS (SELECT * FROM sysindexes where name='xi9expense' and id=object_id('expense'))
	drop index expense.xi9expense
go

-- Drop dei campi definitivamente morti
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='amount'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN amount
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'amount'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='regmodcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN regmodcode
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'regmodcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='ycreation'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN ycreation
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'ycreation'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='ypay'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN ypay
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'ypay'
END
GO

-- Drop dei campi spostati in altre tabelle

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='servicestart'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN servicestart
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'servicestart'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='servicestop'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN servicestop
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'servicestop'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='ivaamount'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN ivaamount
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'ivaamount'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='npay'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN npay
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'npay'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idpay'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idpay
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idpay'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='nbill'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN nbill
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'nbill'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idbank'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idbank
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idbank'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idcab'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idcab
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idcab'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='cc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN cc
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'cc'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='cin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN cin
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'cin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='iddeputy'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN iddeputy
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'iddeputy'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idpaymethod'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idpaymethod
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idpaymethod'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idregistrypaymethod'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idregistrypaymethod
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idregistrypaymethod'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='paymentdescr'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN paymentdescr
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'paymentdescr'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='refexternaldoc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN refexternaldoc
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'refexternaldoc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='autotaxflag'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN autotaxflag
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'autotaxflag'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='autoclawbackflag'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN autoclawbackflag
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'autoclawbackflag'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='fulfilled'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN fulfilled
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'fulfilled'
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenselast' and id=object_id('expenselast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenselast ON expenselast (npay, idpay)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenselast
	ON expenselast (npay, idpay)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenselast' and id=object_id('expenselast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenselast ON expenselast (idbank, idcab)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenselast
	ON expenselast (idbank, idcab)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3expenselast' and id=object_id('expenselast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3expenselast ON expenselast (idser)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3expenselast
	ON expenselast (idser)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4expenselast' and id=object_id('expenselast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4expenselast ON expenselast (idregistrypaymethod)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4expenselast
	ON expenselast (idregistrypaymethod)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6expenselast' and id=object_id('expenselast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi6expenselast ON expenselast (npay)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi6expenselast
	ON expenselast (npay)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7expenselast' and id=object_id('expenselast'))
BEGIN
	CREATE NONCLUSTERED INDEX xi7expenselast ON expenselast (idpaymethod)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi7expenselast
	ON expenselast (idpaymethod)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO
	