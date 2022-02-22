
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


-- CREAZIONE TABELLA assetacquire --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetacquire]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetacquire] (
nassetacquire int NOT NULL,
abatable decimal(19,2) NULL,
adate date NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
discount float NULL,
flag tinyint NOT NULL,
historicalvalue decimal(19,2) NULL,
idassetload int NULL,
idinv int NOT NULL,
idinventory int NOT NULL,
idinvkind int NULL,
idlist int NULL,
idmankind varchar(20) NULL,
idmot int NOT NULL,
idreg int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
invrownum int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ninv int NULL,
nman int NULL,
number int NOT NULL,
rownum int NULL,
rtf image NULL,
startnumber int NULL,
tax decimal(19,2) NULL,
taxable decimal(19,2) NULL,
taxrate float NULL,
transmitted char(1) NULL,
txt text NULL,
yinv smallint NULL,
yman smallint NULL,
 CONSTRAINT xpkassetacquire PRIMARY KEY (nassetacquire
)
)
END
GO

-- VERIFICA STRUTTURA assetacquire --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'nassetacquire' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD nassetacquire int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'nassetacquire' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'abatable' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD abatable decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN abatable decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'adate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD adate date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'adate' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN adate date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD description varchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN description varchar(150) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'discount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD discount float NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN discount float NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD flag tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'flag' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN flag tinyint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'historicalvalue' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD historicalvalue decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN historicalvalue decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idassetload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idassetload int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idassetload int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idinv int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'idinv' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idinv int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idinventory int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'idinventory' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idinventory int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idinvkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idlist' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idlist int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idlist int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idmankind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idmankind varchar(20) NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idmankind varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idmot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idmot int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'idmot' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idmot int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idsor1 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idsor2 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idsor3 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idupb varchar(36) NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idupb varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'invrownum' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD invrownum int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN invrownum int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'ninv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD ninv int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN ninv int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'nman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD nman int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN nman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'number' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD number int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetacquire') and col.name = 'number' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetacquire] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN number int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'rownum' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD rownum int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN rownum int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'startnumber' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD startnumber int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN startnumber int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'tax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD tax decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN tax decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'taxable' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD taxable decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN taxable decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'taxrate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD taxrate float NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN taxrate float NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'transmitted' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD transmitted char(1) NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN transmitted char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD txt text NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'yinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD yinv smallint NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN yinv smallint NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'yman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD yman smallint NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN yman smallint NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetacquire
     ON assetacquire (yman, nman, rownum )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetacquire
     ON assetacquire (yman, nman, rownum )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetacquire
     ON assetacquire (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetacquire
     ON assetacquire (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetacquire
     ON assetacquire (idinv )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetacquire
     ON assetacquire (idinv )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4assetacquire
     ON assetacquire (idassetload )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4assetacquire
     ON assetacquire (idassetload )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5assetacquire
     ON assetacquire (idmot )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5assetacquire
     ON assetacquire (idmot )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6assetacquire
     ON assetacquire (idinventory )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6assetacquire
     ON assetacquire (idinventory )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi7assetacquire
     ON assetacquire (yman, nman )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi7assetacquire
     ON assetacquire (yman, nman )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi8assetacquire
     ON assetacquire (idinventory, startnumber )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi8assetacquire
     ON assetacquire (idinventory, startnumber )
ON [PRIMARY]
END
GO

-- VERIFICA DI assetacquire IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetacquire'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','int','assistenza','nassetacquire','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','decimal(19,2)','assistenza','abatable','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','date','assistenza','adate','3','S','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','varchar(150)','assistenza','description','150','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','float','assistenza','discount','8','N','float','System.Double','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','tinyint','assistenza','flag','1','S','tinyint','System.Byte','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','decimal(19,2)','assistenza','historicalvalue','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','idassetload','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','int','assistenza','idinv','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','int','assistenza','idinventory','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','idinvkind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','idlist','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','varchar(20)','assistenza','idmankind','20','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','int','assistenza','idmot','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','idreg','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','idsor1','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','idsor2','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','idsor3','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','varchar(36)','assistenza','idupb','36','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','invrownum','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','ninv','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','nman','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquire','int','assistenza','number','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','rownum','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','image','assistenza','rtf','16','N','image','System.Byte[]','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','int','assistenza','startnumber','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','decimal(19,2)','assistenza','tax','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','decimal(19,2)','assistenza','taxable','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','float','assistenza','taxrate','8','N','float','System.Double','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','char(1)','assistenza','transmitted','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','text','assistenza','txt','16','N','text','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','smallint','assistenza','yinv','2','N','smallint','System.Int16','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquire','smallint','assistenza','yman','2','N','smallint','System.Int16','','','''assistenza''','','N')
GO

-- VERIFICA DI assetacquire IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetacquire')
UPDATE customobject set isreal = 'S' where objectname = 'assetacquire'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetacquire', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'assetacquire')
UPDATE [tabledescr] SET description = 'Carico dei cespiti da bolla/fattura',idapplication = '1',isdbo = 'N',lt = {ts '1900-01-01 03:00:28.663'},lu = 'nino',title = 'Carico dei cespiti da bolla/fattura' WHERE tablename = 'assetacquire'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('assetacquire','Carico dei cespiti da bolla/fattura','1','N',{ts '1900-01-01 03:00:28.663'},'nino','Carico dei cespiti da bolla/fattura')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'abatable' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'IVA detraibile',kind = 'S',lt = {ts '1900-01-01 03:00:17.813'},lu = 'nino',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'abatable' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('abatable','assetacquire','9','19','2','IVA detraibile','S',{ts '1900-01-01 03:00:17.813'},'nino','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'adate' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data contabile',kind = 'S',lt = {ts '1900-01-01 02:59:52.633'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'adate' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('adate','assetacquire','4',null,null,'data contabile','S',{ts '1900-01-01 02:59:52.633'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:46.333'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','assetacquire','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:46.333'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:43.767'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','assetacquire','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:43.767'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:50.427'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','assetacquire','150',null,null,'Descrizione','S',{ts '1900-01-01 02:59:50.427'},'nino','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'discount' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'sconto',kind = 'S',lt = {ts '1900-01-01 03:00:11.437'},lu = 'nino',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'discount' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('discount','assetacquire','8',null,null,'sconto','S',{ts '1900-01-01 03:00:11.437'},'nino','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flag' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'flag su tipo carico',kind = 'B',lt = {ts '2016-02-06 12:46:20.017'},lu = 'Nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'flag' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flag','assetacquire','1',null,null,'flag su tipo carico','B',{ts '2016-02-06 12:46:20.017'},'Nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'historicalvalue' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Valore iniziale storico ai fini dell''ammortamento. Può differire dal valore iniziale se si tratta di un cespite proveniente da altri dipartimenti e caricato inizialmente con un valore diverso. Il valore iniziale storico è quello con cui è stato inserito la prima volta nel patrimonio.',kind = 'S',lt = {ts '1900-01-01 02:58:11.260'},lu = 'nino',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'historicalvalue' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('historicalvalue','assetacquire','9','19','2','Valore iniziale storico ai fini dell''ammortamento. Può differire dal valore iniziale se si tratta di un cespite proveniente da altri dipartimenti e caricato inizialmente con un valore diverso. Il valore iniziale storico è quello con cui è stato inserito la prima volta nel patrimonio.','S',{ts '1900-01-01 02:58:11.260'},'nino','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetload' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id buono carico (tabella assetload)',kind = 'S',lt = {ts '1900-01-01 03:00:26.597'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetload' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetload','assetacquire','4',null,null,'id buono carico (tabella assetload)','S',{ts '1900-01-01 03:00:26.597'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinv' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'ID class. inventariale (tabella inventorytree)',kind = 'S',lt = {ts '1900-01-01 03:00:10.620'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinv' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinv','assetacquire','4',null,null,'ID class. inventariale (tabella inventorytree)','S',{ts '1900-01-01 03:00:10.620'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinventory' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id inventario (tabella inventory)',kind = 'S',lt = {ts '1900-01-01 03:00:16.303'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinventory' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinventory','assetacquire','4',null,null,'Id inventario (tabella inventory)','S',{ts '1900-01-01 03:00:16.303'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinvkind' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id tipo fattura (tabella invoicekind)',kind = 'S',lt = {ts '2017-05-11 09:33:45.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinvkind' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinvkind','assetacquire','4',null,null,'id tipo fattura (tabella invoicekind)','S',{ts '2017-05-11 09:33:45.997'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlist' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'voce di listino del magazzino (tabella list)',kind = 'S',lt = {ts '2016-02-24 17:09:57.150'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlist' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlist','assetacquire','4',null,null,'voce di listino del magazzino (tabella list)','S',{ts '2016-02-24 17:09:57.150'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmankind' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'id tipo contratto (tabella mandatekind)',kind = 'S',lt = {ts '1900-01-01 03:00:03.343'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idmankind' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmankind','assetacquire','20',null,null,'id tipo contratto (tabella mandatekind)','S',{ts '1900-01-01 03:00:03.343'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmot' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id causale (tabella motive)',kind = 'S',lt = {ts '1900-01-01 03:00:16.990'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idmot' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmot','assetacquire','4',null,null,'Id causale (tabella motive)','S',{ts '1900-01-01 03:00:16.990'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id anagrafica (tabella registry)',kind = 'S',lt = {ts '1900-01-01 02:59:51.940'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','assetacquire','4',null,null,'id anagrafica (tabella registry)','S',{ts '1900-01-01 02:59:51.940'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor1' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce analitica 1(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:26.090'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor1' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor1','assetacquire','4',null,null,'id voce analitica 1(tabella sorting)','S',{ts '1900-01-01 02:59:26.090'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor2' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce analitica 2(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:26.247'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor2' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor2','assetacquire','4',null,null,'id voce analitica 2(tabella sorting)','S',{ts '1900-01-01 02:59:26.247'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor3' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce analitica 3(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:26.403'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor3' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor3','assetacquire','4',null,null,'id voce analitica 3(tabella sorting)','S',{ts '1900-01-01 02:59:26.403'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'id voce upb (tabella upb)',kind = 'S',lt = {ts '1900-01-01 02:59:20.203'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idupb' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','assetacquire','36',null,null,'id voce upb (tabella upb)','S',{ts '1900-01-01 02:59:20.203'},'nino','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'invrownum' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'N. riga fattura ( Il collegamento al dettaglio fattura viene fatto in termini di idgroup e non di rownum, così come avviene per il CP.)',kind = 'S',lt = {ts '2017-05-11 09:33:45.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'invrownum' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('invrownum','assetacquire','4',null,null,'N. riga fattura ( Il collegamento al dettaglio fattura viene fatto in termini di idgroup e non di rownum, così come avviene per il CP.)','S',{ts '2017-05-11 09:33:45.997'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:40.810'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','assetacquire','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:40.810'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:37.843'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','assetacquire','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:37.843'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nassetacquire' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Num. carico',kind = 'S',lt = {ts '1900-01-01 03:00:17.817'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'nassetacquire' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nassetacquire','assetacquire','4',null,null,'Num. carico','S',{ts '1900-01-01 03:00:17.817'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ninv' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'n. fattura',kind = 'S',lt = {ts '2017-05-11 09:33:45.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ninv' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ninv','assetacquire','4',null,null,'n. fattura','S',{ts '2017-05-11 09:33:45.997'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nman' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'n.contratto',kind = 'S',lt = {ts '1900-01-01 03:00:03.863'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'nman' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nman','assetacquire','4',null,null,'n.contratto','S',{ts '1900-01-01 03:00:03.863'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'number' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'quantità',kind = 'S',lt = {ts '1900-01-01 03:00:06.927'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'number' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('number','assetacquire','4',null,null,'quantità','S',{ts '1900-01-01 03:00:06.927'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rownum' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'N. riga contratto passivo ( Il collegamento al dettaglio Contratto Passivo viene fatto in termini di idgroup e non di rownum)',kind = 'S',lt = {ts '2017-05-15 16:12:12.683'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'rownum' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rownum','assetacquire','4',null,null,'N. riga contratto passivo ( Il collegamento al dettaglio Contratto Passivo viene fatto in termini di idgroup e non di rownum)','S',{ts '2017-05-15 16:12:12.683'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'allegati',kind = 'S',lt = {ts '1900-01-01 02:59:58.357'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','assetacquire','16',null,null,'allegati','S',{ts '1900-01-01 02:59:58.357'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startnumber' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Num. iniziale',kind = 'S',lt = {ts '1900-01-01 03:00:17.820'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'startnumber' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startnumber','assetacquire','4',null,null,'Num. iniziale','S',{ts '1900-01-01 03:00:17.820'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tax' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Nome imposta (tabella tax)',kind = 'S',lt = {ts '1900-01-01 03:00:09.227'},lu = 'nino',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'tax' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tax','assetacquire','9','19','2','Nome imposta (tabella tax)','S',{ts '1900-01-01 03:00:09.227'},'nino','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxable' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'imponibile',kind = 'S',lt = {ts '1900-01-01 03:00:06.300'},lu = 'nino',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'taxable' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxable','assetacquire','9','19','2','imponibile','S',{ts '1900-01-01 03:00:06.300'},'nino','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxrate' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Aliquota ritenuta',kind = 'S',lt = {ts '1900-01-01 03:00:12.737'},lu = 'nino',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'taxrate' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxrate','assetacquire','8',null,null,'Aliquota ritenuta','S',{ts '1900-01-01 03:00:12.737'},'nino','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'transmitted' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Trasmesso (non più usato)',kind = 'S',lt = {ts '1900-01-01 03:00:25.103'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'transmitted' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('transmitted','assetacquire','1',null,null,'Trasmesso (non più usato)','S',{ts '1900-01-01 03:00:25.103'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'note testuali',kind = 'S',lt = {ts '1900-01-01 02:59:58.017'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','assetacquire','16',null,null,'note testuali','S',{ts '1900-01-01 02:59:58.017'},'nino','N','text','text','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'yinv' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'esercizio fattura',kind = 'S',lt = {ts '2017-05-11 09:33:45.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'yinv' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('yinv','assetacquire','2',null,null,'esercizio fattura','S',{ts '2017-05-11 09:33:45.997'},'assistenza','N','smallint','smallint','System.Int16')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'yman' AND tablename = 'assetacquire')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'anno contratto',kind = 'S',lt = {ts '1900-01-01 03:00:04.027'},lu = 'nino',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'yman' AND tablename = 'assetacquire'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('yman','assetacquire','2',null,null,'anno contratto','S',{ts '1900-01-01 03:00:04.027'},'nino','N','smallint','smallint','System.Int16')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colbit --
IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '0' AND tablename = 'assetacquire')
UPDATE [colbit] SET description = 'Se vale 1, come di solito dovrebbe essere, il cespite sarà considerato caricato quando sarà inserito in un buono di carico ratificato. In quel momento, sarà aumentata la situazione patrimoniale.

Se vale 0, e può succedere in caso di accessori POSSEDUTI da caricare ai fini dello SCARICO, l''accessorio NON andrà inserito in un buono di carico e NON incrementa la sit. patrimoniale in quanto si intende in essa già conteggiato.

Possono essere caricati anche dei cespiti con flag "non inserire in buono di carico" nel caso di cespiti storici di cui non si conosce il buono di carico e che si intende caricare per storicità. Questi si intendono già conteggiati nella prima situazione patrimoniale del programma',lt = {ts '2016-02-24 13:48:40.307'},lu = 'nino',title = 'Includere in buono di carico' WHERE colname = 'flag' AND nbit = '0' AND tablename = 'assetacquire'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','0','assetacquire','Se vale 1, come di solito dovrebbe essere, il cespite sarà considerato caricato quando sarà inserito in un buono di carico ratificato. In quel momento, sarà aumentata la situazione patrimoniale.

Se vale 0, e può succedere in caso di accessori POSSEDUTI da caricare ai fini dello SCARICO, l''accessorio NON andrà inserito in un buono di carico e NON incrementa la sit. patrimoniale in quanto si intende in essa già conteggiato.

Possono essere caricati anche dei cespiti con flag "non inserire in buono di carico" nel caso di cespiti storici di cui non si conosce il buono di carico e che si intende caricare per storicità. Questi si intendono già conteggiati nella prima situazione patrimoniale del programma',{ts '2016-02-24 13:48:40.307'},'nino','Includere in buono di carico')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '1' AND tablename = 'assetacquire')
UPDATE [colbit] SET description = 'Cespite posseduto (da usare se si stanno inserendo buoni di carico di anni precedenti l''adozione del software)

Se vale 0 è un cespite di nuova acquisizione. Di solito questo tipo di cespite si marca con "inserisci in buono di carico"  e successivamente si carica nel patrimonio inserendolo in un buono di carico che va ratificato. Questo è il valore normale per i cespiti.

Se vale 1 è un cespite "posseduto" ossia si intende già compreso nella situazione patrimoniale. Non va inserito in un buono di carico e non aumenta la situazione patrimoniale. Di solito usato per scaricare degli accessori non inizialmente dettagliati nel carico
Operazioni del genere si effettuano di solito per scaricare cespiti non informatizzati.
Contestualmente bisogna inserire "non inserire in un buono di carico". 
Se  si vuole caricare un cespite incluso nella sit. patrimoniale ma non elencato tra i cespiti è necessario usare questa opzione. 
',lt = {ts '2016-02-04 18:28:12.933'},lu = 'Nino',title = 'Cespite posseduto ' WHERE colname = 'flag' AND nbit = '1' AND tablename = 'assetacquire'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','1','assetacquire','Cespite posseduto (da usare se si stanno inserendo buoni di carico di anni precedenti l''adozione del software)

Se vale 0 è un cespite di nuova acquisizione. Di solito questo tipo di cespite si marca con "inserisci in buono di carico"  e successivamente si carica nel patrimonio inserendolo in un buono di carico che va ratificato. Questo è il valore normale per i cespiti.

Se vale 1 è un cespite "posseduto" ossia si intende già compreso nella situazione patrimoniale. Non va inserito in un buono di carico e non aumenta la situazione patrimoniale. Di solito usato per scaricare degli accessori non inizialmente dettagliati nel carico
Operazioni del genere si effettuano di solito per scaricare cespiti non informatizzati.
Contestualmente bisogna inserire "non inserire in un buono di carico". 
Se  si vuole caricare un cespite incluso nella sit. patrimoniale ma non elencato tra i cespiti è necessario usare questa opzione. 
',{ts '2016-02-04 18:28:12.933'},'Nino','Cespite posseduto ')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '2' AND tablename = 'assetacquire')
UPDATE [colbit] SET description = 'se 0 si tratta di cespite
se 1 si tratta di accessorio 
Gli accessori hanno stesso idasset dei cespiti ma idpiece > 1',lt = null,lu = null,title = 'Cespite o Accessorio' WHERE colname = 'flag' AND nbit = '2' AND tablename = 'assetacquire'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','2','assetacquire','se 0 si tratta di cespite
se 1 si tratta di accessorio 
Gli accessori hanno stesso idasset dei cespiti ma idpiece > 1',null,null,'Cespite o Accessorio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '250')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id buono carico (tabella assetload)',lt = {ts '2017-05-20 09:19:38.810'},lu = 'lu',parenttable = 'assetload',title = 'Carico cespite' WHERE idrelation = '250'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('250','assetacquire','id buono carico (tabella assetload)',{ts '2017-05-20 09:19:38.810'},'lu','assetload','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '254')
UPDATE [relation] SET childtable = 'assetacquire',description = 'Id causale (tabella motive)',lt = {ts '2017-05-20 09:19:39.143'},lu = 'lu',parenttable = 'assetloadmotive',title = 'Carico cespite' WHERE idrelation = '254'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('254','assetacquire','Id causale (tabella motive)',{ts '2017-05-20 09:19:39.143'},'lu','assetloadmotive','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '269')
UPDATE [relation] SET childtable = 'assetacquire',description = 'Id causale (tabella motive)',lt = {ts '2017-05-20 09:19:39.937'},lu = 'lu',parenttable = 'assetunloadmotive',title = 'Carico cespite' WHERE idrelation = '269'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('269','assetacquire','Id causale (tabella motive)',{ts '2017-05-20 09:19:39.937'},'lu','assetunloadmotive','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '969')
UPDATE [relation] SET childtable = 'assetacquire',description = 'Id inventario (tabella inventory)',lt = {ts '2017-05-20 09:19:54.327'},lu = 'lu',parenttable = 'inventory',title = 'Carico cespite' WHERE idrelation = '969'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('969','assetacquire','Id inventario (tabella inventory)',{ts '2017-05-20 09:19:54.327'},'lu','inventory','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '981')
UPDATE [relation] SET childtable = 'assetacquire',description = 'ID class. inventariale (tabella inventorytree)',lt = {ts '2017-05-20 09:19:54.793'},lu = 'lu',parenttable = 'inventorytree',title = 'Carico cespite' WHERE idrelation = '981'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('981','assetacquire','ID class. inventariale (tabella inventorytree)',{ts '2017-05-20 09:19:54.793'},'lu','inventorytree','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '996')
UPDATE [relation] SET childtable = 'assetacquire',description = 'Collegamento a fattura',lt = {ts '2017-05-20 13:23:58.273'},lu = 'lu',parenttable = 'invoice',title = 'Carico cespite' WHERE idrelation = '996'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('996','assetacquire','Collegamento a fattura',{ts '2017-05-20 13:23:58.273'},'lu','invoice','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1019')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id tipo fattura (tabella invoicekind)',lt = {ts '2017-05-20 09:19:55.087'},lu = 'lu',parenttable = 'invoicedetail',title = 'Carico cespite' WHERE idrelation = '1019'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1019','assetacquire','id tipo fattura (tabella invoicekind)',{ts '2017-05-20 09:19:55.087'},'lu','invoicedetail','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1023')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id tipo fattura (tabella invoicekind)',lt = {ts '2017-05-20 09:19:55.147'},lu = 'lu',parenttable = 'invoicekind',title = 'Carico cespite' WHERE idrelation = '1023'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1023','assetacquire','id tipo fattura (tabella invoicekind)',{ts '2017-05-20 09:19:55.147'},'lu','invoicekind','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1121')
UPDATE [relation] SET childtable = 'assetacquire',description = 'voce di listino del magazzino (tabella list)',lt = {ts '2017-05-20 09:19:58.303'},lu = 'lu',parenttable = 'list',title = 'Carico cespite' WHERE idrelation = '1121'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1121','assetacquire','voce di listino del magazzino (tabella list)',{ts '2017-05-20 09:19:58.303'},'lu','list','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1177')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id tipo contratto (tabella mandatekind)',lt = {ts '2017-05-20 09:19:59.583'},lu = 'lu',parenttable = 'mandate',title = 'Carico cespite' WHERE idrelation = '1177'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1177','assetacquire','id tipo contratto (tabella mandatekind)',{ts '2017-05-20 09:19:59.583'},'lu','mandate','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1202')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id tipo contratto (tabella mandatekind)',lt = {ts '2017-05-20 09:19:59.713'},lu = 'lu',parenttable = 'mandatedetail',title = 'Carico cespite' WHERE idrelation = '1202'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1202','assetacquire','id tipo contratto (tabella mandatekind)',{ts '2017-05-20 09:19:59.713'},'lu','mandatedetail','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1204')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id tipo contratto (tabella mandatekind)',lt = {ts '2017-05-20 09:19:59.750'},lu = 'lu',parenttable = 'mandatekind',title = 'Carico cespite' WHERE idrelation = '1204'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1204','assetacquire','id tipo contratto (tabella mandatekind)',{ts '2017-05-20 09:19:59.750'},'lu','mandatekind','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2046')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id anagrafica (tabella registry)',lt = {ts '2017-05-20 09:20:05.860'},lu = 'lu',parenttable = 'registry',title = 'Carico cespite' WHERE idrelation = '2046'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2046','assetacquire','id anagrafica (tabella registry)',{ts '2017-05-20 09:20:05.860'},'lu','registry','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2214')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id voce analitica 1(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Carico cespite' WHERE idrelation = '2214'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2214','assetacquire','id voce analitica 1(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2215')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id voce analitica 2(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Carico cespite' WHERE idrelation = '2215'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2215','assetacquire','id voce analitica 2(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2216')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id voce analitica 3(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Carico cespite' WHERE idrelation = '2216'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2216','assetacquire','id voce analitica 3(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Carico cespite')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2783')
UPDATE [relation] SET childtable = 'assetacquire',description = 'id voce upb (tabella upb)',lt = {ts '2017-05-20 09:20:13.387'},lu = 'lu',parenttable = 'upb',title = 'Carico cespite' WHERE idrelation = '2783'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2783','assetacquire','id voce upb (tabella upb)',{ts '2017-05-20 09:20:13.387'},'lu','upb','Carico cespite')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '250' AND parentcol = 'idassetload')
UPDATE [relationcol] SET childcol = 'idassetload',lt = {ts '2017-05-20 09:19:38.990'},lu = 'lu' WHERE idrelation = '250' AND parentcol = 'idassetload'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('250','idassetload','idassetload',{ts '2017-05-20 09:19:38.990'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

