
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


-- CREAZIONE TABELLA asset --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[asset]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [asset] (
idasset int NOT NULL,
idpiece int NOT NULL,
amortizationquota float NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag tinyint NOT NULL,
idasset_prev int NULL,
idassetunload int NULL,
idcurrlocation int NULL,
idcurrman int NULL,
idcurrsubman int NULL,
idinventory int NULL,
idinventoryamortization int NULL,
idpiece_prev int NULL,
lifestart date NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
multifield varchar(4000) NULL,
nassetacquire int NULL,
ninventory int NULL,
rfid varchar(30) NULL,
rtf image NULL,
transmitted char(1) NULL,
txt text NULL,
 CONSTRAINT xpkasset PRIMARY KEY (idasset,
idpiece
)
)
END
GO

-- VERIFICA STRUTTURA asset --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idasset' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idasset int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('asset') and col.name = 'idasset' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [asset] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idpiece' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idpiece int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('asset') and col.name = 'idpiece' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [asset] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'amortizationquota' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD amortizationquota float NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN amortizationquota float NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('asset') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [asset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('asset') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [asset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD flag tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('asset') and col.name = 'flag' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [asset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN flag tinyint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idasset_prev' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idasset_prev int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idasset_prev int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idassetunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idassetunload int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idassetunload int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idcurrlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idcurrlocation int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idcurrlocation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idcurrman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idcurrman int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idcurrman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idcurrsubman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idcurrsubman int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idcurrsubman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idinventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idinventory int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idinventory int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idinventoryamortization' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idinventoryamortization int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idinventoryamortization int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idpiece_prev' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idpiece_prev int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idpiece_prev int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'lifestart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD lifestart date NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN lifestart date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('asset') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [asset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('asset') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [asset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'multifield' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD multifield varchar(4000) NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN multifield varchar(4000) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'nassetacquire' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD nassetacquire int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN nassetacquire int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'ninventory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD ninventory int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN ninventory int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'rfid' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD rfid varchar(30) NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN rfid varchar(30) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'transmitted' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD transmitted char(1) NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN transmitted char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD txt text NULL 
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='IX_asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX IX_asset
     ON asset (rfid )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX IX_asset
     ON asset (rfid )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1_asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1_asset
     ON asset (ninventory, idpiece )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1_asset
     ON asset (ninventory, idpiece )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi10asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi10asset
     ON asset (idinventory, ninventory )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi10asset
     ON asset (idinventory, ninventory )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi11asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi11asset
     ON asset (lifestart, amortizationquota )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi11asset
     ON asset (lifestart, amortizationquota )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi13asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi13asset
     ON asset (amortizationquota, lifestart )
     INCLUDE(idasset,idpiece,flag,idassetunload,nassetacquire)
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi13asset
     ON asset (amortizationquota, lifestart )
     INCLUDE(idasset,idpiece,flag,idassetunload,nassetacquire)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4asset
     ON asset (idassetunload )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4asset
     ON asset (idassetunload )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5asset
     ON asset (nassetacquire )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5asset
     ON asset (nassetacquire )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6asset
     ON asset (idasset_prev, idpiece_prev )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6asset
     ON asset (idasset_prev, idpiece_prev )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi7asset
     ON asset (idcurrman )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi7asset
     ON asset (idcurrman )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi8asset
     ON asset (idcurrsubman )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi8asset
     ON asset (idcurrsubman )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi9asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi9asset
     ON asset (idcurrlocation )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi9asset
     ON asset (idcurrlocation )
ON [PRIMARY]
END
GO

