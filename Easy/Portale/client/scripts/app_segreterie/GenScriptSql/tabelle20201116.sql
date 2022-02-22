
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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

-- VERIFICA DI asset IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'asset'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','asset','int','ASSISTENZA','idasset','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','asset','int','ASSISTENZA','idpiece','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','float','ASSISTENZA','amortizationquota','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','asset','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','asset','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','asset','tinyint','ASSISTENZA','flag','1','S','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','int','ASSISTENZA','idasset_prev','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','int','ASSISTENZA','idassetunload','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','int','ASSISTENZA','idcurrlocation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','int','ASSISTENZA','idcurrman','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','int','ASSISTENZA','idcurrsubman','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','int','ASSISTENZA','idinventory','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','int','ASSISTENZA','idinventoryamortization','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','int','ASSISTENZA','idpiece_prev','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','date','ASSISTENZA','lifestart','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','asset','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','asset','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','varchar(4000)','ASSISTENZA','multifield','4000','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','int','ASSISTENZA','nassetacquire','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','int','ASSISTENZA','ninventory','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','varchar(30)','ASSISTENZA','rfid','30','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','image','ASSISTENZA','rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','char(1)','ASSISTENZA','transmitted','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','asset','text','ASSISTENZA','txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI asset IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'asset')
UPDATE customobject set isreal = 'S' where objectname = 'asset'
ELSE
INSERT INTO customobject (objectname, isreal) values('asset', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'asset')
UPDATE [tabledescr] SET description = 'Cespiti e accessori',idapplication = '1',isdbo = 'N',lt = {ts '2017-05-20 14:56:28.520'},lu = 'nino',title = 'Cespiti e accessori' WHERE tablename = 'asset'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('asset','Cespiti e accessori','1','N',{ts '2017-05-20 14:56:28.520'},'nino','Cespiti e accessori')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'amortizationquota' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'Percentuale ammortamento
Indica la percentuale di ammortamento da applicare sul cespite, se valorizzata, l''ammortamento sar? calcolato sulla base di questa aliquota e NON sar? considerata quella configurata nella classificazione inventariale.',kind = 'S',lt = {ts '2016-10-06 14:04:32.050'},lu = 'nino',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'amortizationquota' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('amortizationquota','asset','8','0','0','Percentuale ammortamento
Indica la percentuale di ammortamento da applicare sul cespite, se valorizzata, l''ammortamento sar? calcolato sulla base di questa aliquota e NON sar? considerata quella configurata nella classificazione inventariale.','S',{ts '2016-10-06 14:04:32.050'},'nino','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data creazione',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','asset','8','0','0','data creazione','S',{ts '2017-05-19 07:56:58.147'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '64',col_precision = '0',col_scale = '0',description = 'nome utente creazione',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','asset','64','0','0','nome utente creazione','S',{ts '2017-05-19 07:56:58.147'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flag' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'flag su scarico',kind = 'B',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'flag' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flag','asset','1','0','0','flag su scarico','B',{ts '2017-05-19 07:56:58.147'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idasset' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'Id cespite (tabella asset)',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idasset' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idasset','asset','4','0','0','Id cespite (tabella asset)','S',{ts '2017-05-19 07:56:58.147'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idasset_prev' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'Id asset precedente il trasferimento di inventario',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idasset_prev' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idasset_prev','asset','4','0','0','Id asset precedente il trasferimento di inventario','S',{ts '2017-05-19 07:56:58.147'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetunload' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id buono di scarico (tabella assetunload)',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetunload' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetunload','asset','4','0','0','id buono di scarico (tabella assetunload)','S',{ts '2017-05-19 07:56:58.147'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcurrlocation' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'ubicazione corrente (tabella location)',kind = 'S',lt = {ts '2017-05-19 07:58:11.033'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcurrlocation' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcurrlocation','asset','4','0','0','ubicazione corrente (tabella location)','S',{ts '2017-05-19 07:58:11.033'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcurrman' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'Consegnatario corrente (tabella manager)',kind = 'S',lt = {ts '2017-05-19 07:58:11.033'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcurrman' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcurrman','asset','4','0','0','Consegnatario corrente (tabella manager)','S',{ts '2017-05-19 07:58:11.033'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcurrsubman' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'Subconsegnatario corrente (tabella manager)',kind = 'S',lt = {ts '2017-05-19 07:58:11.033'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcurrsubman' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcurrsubman','asset','4','0','0','Subconsegnatario corrente (tabella manager)','S',{ts '2017-05-19 07:58:11.033'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinventory' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'Id inventario (tabella inventory)',kind = 'S',lt = null,lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinventory' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinventory','asset','4','0','0','Id inventario (tabella inventory)','S',null,'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinventoryamortization' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = null,kind = 'S',lt = null,lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinventoryamortization' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinventoryamortization','asset','4','0','0',null,'S',null,'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpiece' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'idpiece',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpiece' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpiece','asset','4','0','0','idpiece','S',{ts '2017-05-19 07:56:58.147'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpiece_prev' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'Id piece precedente il trasferimento di inventario',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpiece_prev' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpiece_prev','asset','4','0','0','Id piece precedente il trasferimento di inventario','S',{ts '2017-05-19 07:56:58.147'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lifestart' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'Data inizio esistenza. Nel caso di cespiti provenienti da altri dipartimenti questa viene preservata nel travaso. E'''' la data usata per stabilire l''''et? di un cespite ai fini degli ammortamenti.',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lifestart' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lifestart','asset','8','0','0','Data inizio esistenza. Nel caso di cespiti provenienti da altri dipartimenti questa viene preservata nel travaso. E'''' la data usata per stabilire l''''et? di un cespite ai fini degli ammortamenti.','S',{ts '2017-05-19 07:56:58.147'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data ultima modifica',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','asset','8','0','0','data ultima modifica','S',{ts '2017-05-19 07:56:58.147'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '64',col_precision = '0',col_scale = '0',description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','asset','64','0','0','nome ultimo utente modifica','S',{ts '2017-05-19 07:56:58.147'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'multifield' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4000',col_precision = '0',col_scale = '0',description = 'campo contenente una codifica di n campi serializzati in un''unica stringa',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(4000)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'multifield' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('multifield','asset','4000','0','0','campo contenente una codifica di n campi serializzati in un''unica stringa','S',{ts '2017-05-19 07:56:58.147'},'nino','N','varchar(4000)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nassetacquire' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'Num. carico',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'nassetacquire' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nassetacquire','asset','4','0','0','Num. carico','S',{ts '2017-05-19 07:56:58.147'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ninventory' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'Numero inv.',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ninventory' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ninventory','asset','4','0','0','Numero inv.','S',{ts '2017-05-19 07:56:58.147'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '16',col_precision = '0',col_scale = '0',description = 'allegati',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','asset','16','0','0','allegati','S',{ts '2017-05-19 07:56:58.147'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'transmitted' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'Trasmesso (non pi? usato)',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'transmitted' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('transmitted','asset','1','0','0','Trasmesso (non pi? usato)','S',{ts '2017-05-19 07:56:58.147'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'asset')
UPDATE [coldescr] SET col_len = '16',col_precision = '0',col_scale = '0',description = 'note testuali',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','asset','16','0','0','note testuali','S',{ts '2017-05-19 07:56:58.147'},'nino','N','text','text','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colbit --
IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '0' AND tablename = 'asset')
UPDATE [colbit] SET description = 'Se vale 1, come di solito dovrebbe essere, il cespite sar? considerato scaricato quando sar? inserito in un buono di scarico ed in quel momento la sit. patrimoniale sar? diminuita del valore residuo che il cespite avr? in quel momento

Se vale 0, e pu? succedere in caso di cespiti caricati nel programma solo a fini storici il cespite ? stato gi? scaricato e non ? in carico, anche se non ? presente nel programma il buono di scarico
',lt = {ts '2016-02-04 18:24:23.657'},lu = 'Nino',title = 'Inserisci in buono di scarico' WHERE colname = 'flag' AND nbit = '0' AND tablename = 'asset'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','0','asset','Se vale 1, come di solito dovrebbe essere, il cespite sar? considerato scaricato quando sar? inserito in un buono di scarico ed in quel momento la sit. patrimoniale sar? diminuita del valore residuo che il cespite avr? in quel momento

Se vale 0, e pu? succedere in caso di cespiti caricati nel programma solo a fini storici il cespite ? stato gi? scaricato e non ? in carico, anche se non ? presente nel programma il buono di scarico
',{ts '2016-02-04 18:24:23.657'},'Nino','Inserisci in buono di scarico')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '1' AND tablename = 'asset')
UPDATE [colbit] SET description = 'Il cespite ? stato selezionato per un prossimo scarico con la procedura di scarico automatico che consente di scaricare tutti i cespiti con il suddetto flag',lt = {ts '2016-02-04 18:29:58.423'},lu = 'Nino',title = 'Pronto per lo scarico' WHERE colname = 'flag' AND nbit = '1' AND tablename = 'asset'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','1','asset','Il cespite ? stato selezionato per un prossimo scarico con la procedura di scarico automatico che consente di scaricare tutti i cespiti con il suddetto flag',{ts '2016-02-04 18:29:58.423'},'Nino','Pronto per lo scarico')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '2' AND tablename = 'asset')
UPDATE [colbit] SET description = 'Il cespite ? stato selezionato per essere trasferito prossimamente di inventario con l''apposita procedura',lt = {ts '2016-02-04 18:29:58.423'},lu = 'Nino',title = 'Pronto per il trasferimento di inventario' WHERE colname = 'flag' AND nbit = '2' AND tablename = 'asset'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','2','asset','Il cespite ? stato selezionato per essere trasferito prossimamente di inventario con l''apposita procedura',{ts '2016-02-04 18:29:58.423'},'Nino','Pronto per il trasferimento di inventario')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '247')
UPDATE [relation] SET childtable = 'asset',description = 'Num. carico',lt = {ts '2017-05-20 09:19:38.487'},lu = 'lu',parenttable = 'assetacquire',title = 'Cespiti e accessori' WHERE idrelation = '247'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('247','asset','Num. carico',{ts '2017-05-20 09:19:38.487'},'lu','assetacquire','Cespiti e accessori')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '265')
UPDATE [relation] SET childtable = 'asset',description = 'id buono di scarico (tabella assetunload)',lt = {ts '2017-05-20 09:19:39.600'},lu = 'lu',parenttable = 'assetunload',title = 'Cespiti e accessori' WHERE idrelation = '265'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('265','asset','id buono di scarico (tabella assetunload)',{ts '2017-05-20 09:19:39.600'},'lu','assetunload','Cespiti e accessori')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '976')
UPDATE [relation] SET childtable = 'asset',description = 'ID Tipo Ammortamento (tabella inventoryamortization)',lt = {ts '2017-05-20 09:19:54.527'},lu = 'lu',parenttable = 'inventoryamortization',title = 'Cespiti e accessori' WHERE idrelation = '976'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('976','asset','ID Tipo Ammortamento (tabella inventoryamortization)',{ts '2017-05-20 09:19:54.527'},'lu','inventoryamortization','Cespiti e accessori')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3084')
UPDATE [relation] SET childtable = 'asset',description = 'asset precedente il trasferimento di inventario',lt = {ts '2017-05-22 14:50:08.580'},lu = 'nino',parenttable = 'asset',title = 'Cespiti e accessori' WHERE idrelation = '3084'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3084','asset','asset precedente il trasferimento di inventario',{ts '2017-05-22 14:50:08.580'},'nino','asset','Cespiti e accessori')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3085')
UPDATE [relation] SET childtable = 'asset',description = 'Consegnatario corrente (tabella manager)',lt = {ts '2017-05-22 14:51:23.100'},lu = 'nino',parenttable = 'manager',title = 'Cespiti e accessori' WHERE idrelation = '3085'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3085','asset','Consegnatario corrente (tabella manager)',{ts '2017-05-22 14:51:23.100'},'nino','manager','Cespiti e accessori')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3086')
UPDATE [relation] SET childtable = 'asset',description = 'Subconsegnatario corrente (tabella manager)',lt = {ts '2017-05-22 14:51:23.103'},lu = 'nino',parenttable = 'manager',title = 'Cespiti e accessori' WHERE idrelation = '3086'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3086','asset','Subconsegnatario corrente (tabella manager)',{ts '2017-05-22 14:51:23.103'},'nino','manager','Cespiti e accessori')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3087')
UPDATE [relation] SET childtable = 'asset',description = 'ubicazione corrente (tabella location)',lt = {ts '2017-05-22 14:51:38.887'},lu = 'nino',parenttable = 'location',title = 'Cespiti e accessori' WHERE idrelation = '3087'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3087','asset','ubicazione corrente (tabella location)',{ts '2017-05-22 14:51:38.887'},'nino','location','Cespiti e accessori')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '247' AND parentcol = 'nassetacquire')
UPDATE [relationcol] SET childcol = 'nassetacquire',lt = {ts '2017-05-20 09:19:38.607'},lu = 'lu' WHERE idrelation = '247' AND parentcol = 'nassetacquire'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('247','nassetacquire','nassetacquire',{ts '2017-05-20 09:19:38.607'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA assetdiary --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[assetdiary]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[assetdiary] (
idassetdiary int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idasset int NOT NULL,
idpiece int NULL,
idprogetto int NOT NULL,
idreg int NOT NULL,
idworkpackage int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
orepreventivate int NULL,
 CONSTRAINT xpkassetdiary PRIMARY KEY (idassetdiary
)
)
END
GO

-- VERIFICA STRUTTURA assetdiary --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idassetdiary' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idassetdiary int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idassetdiary' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idasset' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idasset int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idasset' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idasset int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idpiece' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idpiece int NULL 
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idpiece int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idprogetto int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idworkpackage int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'orepreventivate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD orepreventivate int NULL 
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN orepreventivate int NULL
GO

-- VERIFICA DI assetdiary IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetdiary'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idassetdiary','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idasset','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiary','int','ASSISTENZA','idpiece','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiary','int','ASSISTENZA','orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI assetdiary IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetdiary')
UPDATE customobject set isreal = 'S' where objectname = 'assetdiary'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetdiary', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'assetdiary')
UPDATE [tabledescr] SET description = 'Diari di utilizzo dei beni strumentali relativi al workpackage di un progetto',idapplication = null,isdbo = 'S',lt = {ts '2020-06-05 16:00:02.353'},lu = 'assistenza',title = 'Diari di utilizzo dei beni strumentali' WHERE tablename = 'assetdiary'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('assetdiary','Diari di utilizzo dei beni strumentali relativi al workpackage di un progetto',null,'S',{ts '2020-06-05 16:00:02.353'},'assistenza','Diari di utilizzo dei beni strumentali')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','assetdiary','8',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','assetdiary','64',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idasset' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Bene strumentale',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idasset' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idasset','assetdiary','4',null,null,'Bene strumentale','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetdiary' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetdiary' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetdiary','assetdiary','4',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpiece' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero parte',kind = 'S',lt = {ts '2020-06-18 10:33:39.790'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpiece' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpiece','assetdiary','4',null,null,'Numero parte','S',{ts '2020-06-18 10:33:39.790'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','assetdiary','4',null,null,'Progetto','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Operatore',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','assetdiary','4',null,null,'Operatore','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','assetdiary','4',null,null,'Workpackage','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','assetdiary','8',null,null,null,'S',{ts '2020-06-05 15:58:18.143'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','assetdiary','64',null,null,null,'S',{ts '2020-06-05 15:58:18.143'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orepreventivate' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore di utilizzo complessive preventivate',kind = 'S',lt = {ts '2020-06-18 10:33:39.793'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orepreventivate' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orepreventivate','assetdiary','4',null,null,'Ore di utilizzo complessive preventivate','S',{ts '2020-06-18 10:33:39.793'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

Ôªøexec menuweb_addentry @idmenuwebparent = 296, @tableName = 'progetto', @editType = 'seg', @label = 'Attivit√† e progetti';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'affidamentokind', @editType = 'default', @label = 'Tipologie di affidamento';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'ambitoareadisc', @editType = 'default', @label = 'Ambiti o aree disciplinari';
exec menuweb_addentry @idmenuwebparent = 86, @tableName = 'aoo', @editType = 'default', @label = 'Aree organizzative omogenee';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'appello', @editType = 'default', @label = 'Appelli';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'appelloazionekind', @editType = 'default', @label = 'Titologie di azione in appello';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'appellokind', @editType = 'default', @label = 'Tipologie di appello';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'areadidattica', @editType = 'default', @label = 'Aeree didattiche';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'ateco', @editType = 'default', @label = 'Classificazione ATECO';
exec menuweb_addentry @idmenuwebparent = 82, @tableName = 'aula', @editType = 'default', @label = 'Aule';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'aulakind', @editType = 'default', @label = 'Tipologie delle aule';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'ccnl', @editType = 'default', @label = 'Contratti Collettivi Nazionali del Lavoro';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'changes', @editType = 'default', @label = 'Cambiamento per learning agreement';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'changeskind', @editType = 'default', @label = 'Tipo di cambiamenti';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'classconsorsuale', @editType = 'default', @label = 'Classi di concorso MIUR';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'classescuola', @editType = 'default', @label = 'Scuole / Classi di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'classescuolaarea', @editType = 'default', @label = 'Area della scuola / classe di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'classescuolakind', @editType = 'default', @label = 'Tipologia della scuola / classe di laurea';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'contrattokind', @editType = 'default', @label = 'Tipologie di contratto';
exec menuweb_addentry @idmenuwebparent = 313, @tableName = 'convenzione', @editType = 'seg', @label = 'Convenzioni';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'corsostudio', @editType = 'default', @label = 'Corsi di studio';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'corsostudio', @editType = 'dotmas', @label = 'Master';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'corsostudio', @editType = 'ingresso', @label = 'Prove di ammissione';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'corsostudio', @editType = 'stato', @label = 'Esami di stato';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'corsostudiokind', @editType = 'default', @label = 'Tipologie dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'corsostudiolivello', @editType = 'default', @label = 'Livelli dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'corsostudionorma', @editType = 'default', @label = 'Normativa dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'costoscontodef', @editType = 'default', @label = 'Costi';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'costoscontodef', @editType = 'more', @label = 'Indennit√† / More';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'costoscontodef', @editType = 'sconti', @label = 'Sconti';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'costoscontodefdettagliokind', @editType = 'default', @label = 'Voci dei dettaglio debito';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'costoscontodefkind', @editType = 'default', @label = 'Tipologia tra Costo, Sconto, Mora, indennizzo';
exec menuweb_addentry @idmenuwebparent = 84, @tableName = 'decadenza', @editType = 'seg', @label = 'Decadenza';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'dichiarkind', @editType = 'default', @label = 'Tipi di dichiarazione';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'diderog', @editType = 'default', @label = 'Didattica Erogata';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'didprog', @editType = 'default', @label = 'Didattiche programmate';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'duratakind', @editType = 'default', @label = 'Tipo di durata';
exec menuweb_addentry @idmenuwebparent = 82, @tableName = 'edificio', @editType = 'default', @label = 'Edifici';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'erogazkind', @editType = 'default', @label = 'Tipologie di erogazione della didattica';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'esonero', @editType = 'default', @label = 'Definizione degli esoneri generici';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'esonero', @editType = 'carriera', @label = 'Definizione degli esoneri  derivanti dalla carriera';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'esonero', @editType = 'disabil', @label = 'Definizione degli esoneri di invalidit√†';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'esonero', @editType = 'titolostudio', @label = 'Definizione degli esoneri per titoli di studio conseguiti';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'fasciaisee', @editType = 'default', @label = 'Fasce ISEE';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'fonteindicebibliometrico', @editType = 'seg', @label = 'Fonti degli indici bibliometrici';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'geo_city', @editType = 'seg', @label = 'Comuni';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'geo_continent', @editType = 'default', @label = 'Continenti';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'geo_country', @editType = 'seg', @label = 'Province';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'geo_nation', @editType = 'seg', @label = 'Nazioni';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'geo_region', @editType = 'seg', @label = 'Regioni';
exec menuweb_addentry @idmenuwebparent = 143, @tableName = 'graduatoria', @editType = 'default', @label = 'Definizioni delle graduatorie';
exec menuweb_addentry @idmenuwebparent = 143, @tableName = 'graduatoriavar', @editType = 'default', @label = 'Variabili delle graduatorie';
exec menuweb_addentry @idmenuwebparent = 82, @tableName = 'insegn', @editType = 'default', @label = 'Insegnamenti';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'inventorytree', @editType = 'seg', @label = 'Inventario';
exec menuweb_addentry @idmenuwebparent = 84, @tableName = 'iscrizione', @editType = 'seg', @label = 'Iscrizioni';
exec menuweb_addentry @idmenuwebparent = 280, @tableName = 'istanza', @editType = 'imm_seg', @label = 'Istanze di immatricolazione';
exec menuweb_addentry @idmenuwebparent = 280, @tableName = 'istanza', @editType = 'imm_segpre', @label = 'Istanze di preimmatricolazione';
exec menuweb_addentry @idmenuwebparent = 280, @tableName = 'istanza', @editType = 'imm_segrin', @label = 'Istanze di rinnovo della iscrizione';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'istanzakind', @editType = 'default', @label = 'Tipologie di istanza';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'istattitolistudio', @editType = 'default', @label = 'Titoli di studio ISTAT';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'istitutokind', @editType = 'default', @label = 'Tipologia di istituto';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'nace', @editType = 'default', @label = 'Classificazione delle attivit√† economiche nella Comunit√† Europea';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'naturagiur', @editType = 'default', @label = 'Natura giuridica';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'numerodip', @editType = 'default', @label = 'Numero dipendenti';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'ofakind', @editType = 'default', @label = 'Titologie di obblighi formativi aggiuntivi';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'orakind', @editType = 'seg', @label = 'Tipologia di ore';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'pagamentokind', @editType = 'default', @label = 'Tipologie di pagamento';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'pianostudio', @editType = 'segstud', @label = 'Piani di studio';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'pianostudiostatus', @editType = 'default', @label = 'Stati dei piani di studio';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'pratica', @editType = 'segstud', @label = 'Pratica di convalida/riconoscimento/dispensa';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'progettoactivitykind', @editType = 'default', @label = 'Tipo di attivit√† o progetto';
exec menuweb_addentry @idmenuwebparent = 296, @tableName = 'progettokind', @editType = 'seg', @label = 'Modelli di attivit√† o progetto';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'progettostatuskind', @editType = 'default', @label = 'Stati delle attivit√† o progetti';
exec menuweb_addentry @idmenuwebparent = 283, @tableName = 'protocollo', @editType = 'seg', @label = 'Registrazioni di protocollo';
exec menuweb_addentry @idmenuwebparent = 283, @tableName = 'protocollodockind', @editType = 'seg', @label = 'Tipo di documento protocollato';
exec menuweb_addentry @idmenuwebparent = 283, @tableName = 'protocollorifkind', @editType = 'seg', @label = 'Tipo di documento di riferimento';
exec menuweb_addentry @idmenuwebparent = 82, @tableName = 'publicaz', @editType = 'default', @label = 'Pubblicazioni';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'publicazkind', @editType = 'default', @label = 'Tipologie di pubblicazione ';
exec menuweb_addentry @idmenuwebparent = 143, @tableName = 'questionario', @editType = 'default', @label = 'Questionari';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'questionariodomkind', @editType = 'default', @label = 'Tipologie di  domande del questionario';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'questionariokind', @editType = 'default', @label = 'Tipologie di questionario';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'ratakind', @editType = 'default', @label = 'Rate';
exec menuweb_addentry @idmenuwebparent = 86, @tableName = 'registry', @editType = 'default', @label = 'Anagrafica generale';
exec menuweb_addentry @idmenuwebparent = 86, @tableName = 'registry', @editType = 'amministrativi', @label = 'Personale Amministrativo';
exec menuweb_addentry @idmenuwebparent = 86, @tableName = 'registry', @editType = 'aziende', @label = 'Enti e Aziende';
exec menuweb_addentry @idmenuwebparent = 82, @tableName = 'registry', @editType = 'docenti', @label = 'Docenti';
exec menuweb_addentry @idmenuwebparent = 86, @tableName = 'registry', @editType = 'istituti', @label = 'Istituti';
exec menuweb_addentry @idmenuwebparent = 143, @tableName = 'registry', @editType = 'istituti_princ', @label = 'Istituto in gestione';
exec menuweb_addentry @idmenuwebparent = 86, @tableName = 'registry', @editType = 'istitutiesteri', @label = 'Istituti esteri';
exec menuweb_addentry @idmenuwebparent = 86, @tableName = 'registry', @editType = 'studenti', @label = 'Studenti';
exec menuweb_addentry @idmenuwebparent = 143, @tableName = 'registry', @editType = 'user', @label = 'Pagina di registrazione';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'registryclass', @editType = 'default', @label = 'Tipologia fiscale';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'rendicontaltrokind', @editType = 'default', @label = 'Tipologia delle attivit√† da rendicontare oltre le lezioni ';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'sasd', @editType = 'default', @label = 'Settori artistico-scientifico disciplinari';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'sasdgruppo', @editType = 'default', @label = 'Gruppo';
exec menuweb_addentry @idmenuwebparent = 86, @tableName = 'sede', @editType = 'default', @label = 'Sedi';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'sessione', @editType = 'default', @label = 'Sessioni di esami';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'sessionekind', @editType = 'default', @label = 'Tipologie di sessione';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'settoreerc', @editType = 'seg', @label = 'Settori dell''European Research Council';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'settoreerc', @editType = 'segprog', @label = 'Settori dell''European Research Council';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'sostenimentoesito', @editType = 'default', @label = 'Esito';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'stipendiokind', @editType = 'default', @label = 'Tabelle stipendiali';
exec menuweb_addentry @idmenuwebparent = 86, @tableName = 'struttura', @editType = 'default', @label = 'Struttura / Unit√† organizzativa';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'strutturakind', @editType = 'default', @label = 'Tipologia delle strutture';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'studdirittokind', @editType = 'default', @label = 'Categoria dello studente per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'studprenotkind', @editType = 'default', @label = 'Tipologia di studente durante la prenotazione';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'tassaconf', @editType = 'default', @label = 'Definizione dei costi generici';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'tassaconfkind', @editType = 'default', @label = 'Definizione delle tasse generiche';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'tassacsingconf', @editType = 'default', @label = 'Definizione dei costi dei corsi singoli';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'tassaiscrizioneconf', @editType = 'default', @label = 'Definizione delle tasse di iscrizione';
exec menuweb_addentry @idmenuwebparent = 244, @tableName = 'tassaistanzaconf', @editType = 'default', @label = 'Definizione dei costi delle istanze';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'tax', @editType = 'seg', @label = 'Tipi di ritenuta';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'tipoattform', @editType = 'default', @label = 'Tipologia delle attivit√† formative';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'tirociniocandidaturakind', @editType = 'default', @label = 'Tipologia di candidatura ad un tirocinio';
exec menuweb_addentry @idmenuwebparent = 313, @tableName = 'tirocinioproposto', @editType = 'seg', @label = 'Proposte di tirocinio';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'tirociniostato', @editType = 'default', @label = 'Stato dei tirocini';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'upb', @editType = 'default', @label = 'Unit√† previsionali di base';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'valutazionekind', @editType = 'default', @label = 'Tipologia di valutazione di una attivit√† didattica';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'valutazionekind', @editType = 'seg_child', @label = 'Tipologia di valutazione di una attivit√† didattica';
exec menuweb_addentry @idmenuwebparent = 349, @tableName = 'accordoscambiomi', @editType = 'seg', @label = 'Accordi bilaterali';
exec menuweb_addentry @idmenuwebparent = 349, @tableName = 'programmami', @editType = 'seg', @label = 'Programmi di cooperazione';
exec menuweb_addentry @idmenuwebparent = 349, @tableName = 'bandomi', @editType = 'seg', @label = 'Bandi di mobilit√†';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'isced2013', @editType = 'default', @label = 'International Standard Classification of Education (ISCED)';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'cefr', @editType = 'default', @label = 'Quadro europeo comune di riferimento per le lingue';
exec menuweb_addentry @idmenuwebparent = 349, @tableName = 'assicurazione', @editType = 'default', @label = 'Assicurazione';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'bandomobilitaintkind', @editType = 'default', @label = 'Tipologa del bando di mobilit√† internanzionale';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'convalidakind', @editType = 'default', @label = 'Tipologie di convalida';
exec menuweb_addentry @idmenuwebparent = 359, @tableName = 'bandods', @editType = 'seg', @label = 'Bandi di diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'accreditokind', @editType = 'default', @label = 'Tipi di accredito in una richiesta di partecipazione al bando per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'dichiardisabilkind', @editType = 'default', @label = 'Tipologie di disabilit√†';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'dichiardisabilsuppkind', @editType = 'default', @label = 'Tipologie dichiarazioni disabilita';
exec menuweb_addentry @idmenuwebparent = 367, @tableName = 'dichiar', @editType = 'disabil_seg', @label = 'Dichiarazione di disabilit√†';
exec menuweb_addentry @idmenuwebparent = 367, @tableName = 'dichiar', @editType = 'isee_seg', @label = 'Attestazione ISEE';
exec menuweb_addentry @idmenuwebparent = 367, @tableName = 'dichiar', @editType = 'altrititoli_seg', @label = 'Altri titoli';
exec menuweb_addentry @idmenuwebparent = 367, @tableName = 'dichiar', @editType = 'altre_seg', @label = 'Altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 84, @tableName = 'sostenimento', @editType = 'segcons', @label = 'Conseguimento del titolo';
exec menuweb_addentry @idmenuwebparent = 274, @tableName = 'decadenza', @editType = 'seg', @label = 'Decadenza';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'dichiaraltrekind', @editType = 'default', @label = 'Tipologia delle altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 177, @tableName = 'dichiaraltrekind', @editType = 'elenchi', @label = 'Tipologia delle altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 367, @tableName = 'dichiar', @editType = 'titolo_seg', @label = 'Dichiarazione titoli di studio';
exec menuweb_addentry @idmenuwebparent = 280, @tableName = 'istanza', @editType = 'rin_seg', @label = 'Istanza di rinuncia agli studi';
exec menuweb_addentry @idmenuwebparent = 280, @tableName = 'istanza', @editType = 'tru_seg', @label = 'Istanza di trasferimento in uscita';
exec menuweb_addentry @idmenuwebparent = 280, @tableName = 'istanza', @editType = 'eq_seg', @label = 'Istanza di equipollenza ';
exec menuweb_addentry @idmenuwebparent = 280, @tableName = 'istanza', @editType = 'cert_seg', @label = 'Richiesta di certificato';
exec menuweb_addentry @idmenuwebparent = 280, @tableName = 'istanza', @editType = 'sosp_seg', @label = 'Istanza di sospensione degli studi';
exec menuweb_addentry @idmenuwebparent = 280, @tableName = 'delibera', @editType = 'seg', @label = 'Delibere';
exec menuweb_addentry @idmenuwebparent = 179, @tableName = 'getcostididattica', @editType = 'default', @label = 'Riepilogo dei costi degli affidamenti';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'inventorytree', @editType = 'seg', @label = 'Classificazione inventariale';
exec menuweb_addentry @idmenuwebparent = 296, @tableName = 'progettokind', @editType = 'seg', @label = 'Tipo di progetto o attivit√†';
exec menuweb_addentry @idmenuwebparent = 41, @tableName = 'currency', @editType = 'default', @label = 'Valute';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 297, @tableName = 'progetto', @editType = 'seg', @label = 'Attivit√† e progetti';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 299, @tableName = 'progettokind', @editType = 'seg', @label = 'Tipo di progetto o attivit√†';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 79, @tableName = 'registry', @editType = 'docenti', @label = 'Docenti';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 300, @tableName = 'registry', @editType = 'amministrativi', @label = 'Personale Amministrativo';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 136, @tableName = 'publicaz', @editType = 'default', @label = 'Pubblicazioni';
--menuÔªø INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('duratakind', 'default', 'duratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progetto', 'seg', 'progettosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('naturagiur', 'default', 'naturagiurdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'seg', 'accmotivesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('address', 'seg', 'addresssegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'default', 'affidamentodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'seg', 'affidamentosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamentokind', 'default', 'affidamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ambitoareadisc', 'default', 'ambitoareadiscdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'default', 'aoodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'princ', 'aooprincview', 'princ', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'default', 'appellodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'erogata', 'appelloerogataview', 'erogata', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appelloazionekind', 'default', 'appelloazionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appellokind', 'default', 'appellokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('areadidattica', 'default', 'areadidatticadefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('asset', 'seg', 'assetsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ateco', 'default', 'atecodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'appello', 'attivformappelloview', 'appello', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'default', 'attivformdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'erogata', 'attivformerogataview', 'erogata', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'gruppo', 'attivformgruppoview', 'gruppo', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'proped', 'attivformpropedview', 'proped', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'default', 'auladefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'seg_child', 'aulaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aulakind', 'default', 'aulakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('canale', 'erogata', 'canaleerogataview', 'erogata', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ccnl', 'default', 'ccnldefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('changeskind', 'default', 'changeskinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classconsorsuale', 'default', 'classconsorsualedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuola', 'default', 'classescuoladefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuolakind', 'default', 'classescuolakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contrattokind', 'default', 'contrattokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('convenzione', 'seg', 'convenzionesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'default', 'corsostudiodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'dotmas', 'corsostudiodotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'ingresso', 'corsostudioingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'stato', 'corsostudiostatoview', 'stato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiokind', 'default', 'corsostudiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiolivello', 'default', 'corsostudiolivellodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudionorma', 'default', 'corsostudionormadefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'more', 'costoscontodefmoreview', 'more', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'sconti', 'costoscontodefscontiview', 'sconti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodefkind', 'default', 'costoscontodefkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('decadenza', 'seg', 'decadenzasegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'seg', 'dichiarsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiarkind', 'default', 'dichiarkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('diderog', 'default', 'diderogdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'default', 'didprogdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'dotmas', 'didprogdotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'ingresso', 'didprogingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'stato', 'didprogstatoview', 'stato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didproganno', 'default', 'didprogannodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'default', 'didprogoridefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'sceltacorso', 'didprogorisceltacorsoview', 'sceltacorso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogporzanno', 'default', 'didprogporzannodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'default', 'edificiodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'seg_child', 'edificioseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('erogazkind', 'default', 'erogazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'default', 'esonerodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'carriera', 'esonerocarrieraview', 'carriera', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'disabil', 'esonerodisabilview', 'disabil', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'titolostudio', 'esonerotitolostudioview', 'titolostudio', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('expense', 'seg', 'expensesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'default', 'fasciaiseedefdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'more', 'fasciaiseedefmoreview', 'more', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'sconti', 'fasciaiseedefscontiview', 'sconti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fonteindicebibliometrico', 'seg', 'fonteindicebibliometricosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'default', 'geo_citydefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'seg', 'geo_citysegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'segchild', 'geo_citysegchildview', 'segchild', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'seg', 'geo_countrysegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'segchild', 'geo_countrysegchildview', 'segchild', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'lingue', 'geo_nationlingueview', 'lingue', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'seg', 'geo_nationsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'segchild', 'geo_nationsegchildview', 'segchild', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_region', 'seg', 'geo_regionsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('graduatoriavar', 'default', 'graduatoriavardefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inquadramento', 'default', 'inquadramentodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegn', 'default', 'insegndefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegninteg', 'default', 'insegnintegdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'default', 'iscrizionedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'didprog', 'iscrizionedidprogview', 'didprog', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'dotmas', 'iscrizionedotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'ingresso', 'iscrizioneingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seg', 'iscrizionesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstu', 'iscrizioneseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstuacc', 'iscrizioneseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstumast', 'iscrizioneseganagstumastview', 'seganagstumast', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstusing', 'iscrizioneseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstustato', 'iscrizioneseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'stato', 'iscrizionestatoview', 'stato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'seganagstusonpre', 'istanzaseganagstusonpreview', 'seganagstusonpre', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seg', 'istanzaimm_segview', 'imm_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstu', 'istanzaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstupre', 'istanzaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagsturin', 'istanzaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segpre', 'istanzaimm_segpreview', 'imm_segpre', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segrin', 'istanzaimm_segrinview', 'imm_segrin', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'pas_seganagstu', 'istanzapas_seganagstuview', 'pas_seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzakind', 'default', 'istanzakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('itineration', 'seg', 'itinerationsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nace', 'default', 'nacedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstu', 'nullaostaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstupre', 'nullaostaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagsturin', 'nullaostaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ofakind', 'default', 'ofakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('orakind', 'seg', 'orakindsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pagamentokind', 'default', 'pagamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pettycash', 'seg', 'pettycashsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudio', 'segstud', 'pianostudiosegstudview', 'segstud', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudiostatus', 'default', 'pianostudiostatusdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segstud', 'praticasegstudview', 'segstud', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoactivitykind', 'default', 'progettoactivitykinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettokind', 'seg', 'progettokindsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettotipocosto', 'seg', 'progettotipocostosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollo', 'seg', 'protocollosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollodockind', 'seg', 'protocollodockindsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollorifkind', 'seg', 'protocollorifkindsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'aula', 'provaaulaview', 'aula', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'default', 'provadefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'dotmas', 'provadotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'ingresso', 'provaingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'stato', 'provastatoview', 'stato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicazkind', 'default', 'publicazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionario', 'default', 'questionariodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariodomkind', 'default', 'questionariodomkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariokind', 'default', 'questionariokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'default', 'ratadefdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'more', 'ratadefmoreview', 'more', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'sconti', 'ratadefscontiview', 'sconti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratakind', 'default', 'ratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'default', 'registrydefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'amministrativi', 'registryamministrativiview', 'amministrativi', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'aziende', 'registryaziendeview', 'aziende', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti', 'registrydocentiview', 'docenti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti', 'registryistitutiview', 'istituti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti_princ', 'registryistituti_princview', 'istituti_princ', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istitutiesteri', 'registryistitutiesteriview', 'istitutiesteri', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'studenti', 'registrystudentiview', 'studenti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'user', 'registryuserview', 'user', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'seg', 'registryaddresssegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'user', 'registryaddressuserview', 'user', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'aziende', 'registryclassaziendeview', 'aziende', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'default', 'registryclassdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'persone', 'registryclasspersoneview', 'persone', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfin', 'seg', 'registryprogfinsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfinbando', 'seg', 'registryprogfinbandosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontaltrokind', 'default', 'rendicontaltrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anag', 'rendicontattivitaprogettoanagview', 'anag', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anagamm', 'rendicontattivitaprogettoanagammview', 'anagamm', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'seg', 'rendicontattivitaprogettosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasd', 'default', 'sasddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasdgruppo', 'default', 'sasdgruppodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'default', 'sededefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child', 'sedeseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child_azienda', 'sedeseg_child_aziendaview', 'seg_child_azienda', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessione', 'default', 'sessionedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessionekind', 'default', 'sessionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'seg', 'settoreercsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'segprog', 'settoreercsegprogview', 'segprog', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'default', 'sostenimentodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'didprog', 'sostenimentodidprogview', 'didprog', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'ingresso', 'sostenimentoingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstu', 'sostenimentoseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuacc', 'sostenimentoseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuconsmast', 'sostenimentoseganagstuconsmastview', 'seganagstuconsmast', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstusing', 'sostenimentoseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstustato', 'sostenimentoseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segstud', 'sostenimentosegstudview', 'segstud', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimentoesito', 'default', 'sostenimentoesitodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('stipendiokind', 'default', 'stipendiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'default', 'strutturadefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'princ', 'strutturaprincview', 'princ', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'seg_child', 'strutturaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strutturakind', 'default', 'strutturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studdirittokind', 'default', 'studdirittokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studprenotkind', 'default', 'studprenotkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconf', 'default', 'tassaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconfkind', 'default', 'tassaconfkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassacsingconf', 'default', 'tassacsingconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaiscrizioneconf', 'default', 'tassaiscrizioneconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaistanzaconf', 'default', 'tassaistanzaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tax', 'seg', 'taxsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tipoattform', 'default', 'tipoattformdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniocandidaturakind', 'default', 'tirociniocandidaturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioprogetto', 'seg', 'tirocinioprogettosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioproposto', 'seg', 'tirociniopropostosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniostato', 'default', 'tirociniostatodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolostudio', 'docenti', 'titolostudiodocentiview', 'docenti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'default', 'upbdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'seg', 'upbsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inventorytree', 'seg', 'inventorytreesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accordoscambiomi', 'seg', 'accordoscambiomisegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomi', 'seg', 'bandomisegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('cefr', 'default', 'cefrdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('cefrlanglevel', 'default', 'cefrlangleveldefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assicurazione', 'default', 'assicurazionedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomobilitaintkind', 'default', 'bandomobilitaintkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizionebmi', 'seg', 'iscrizionebmisegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizionebmiattach', 'seg', 'iscrizionebmiattachsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandods', 'seg', 'bandodssegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrstud', 'seg', 'learningagrstudsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tipologiastudente', 'seg', 'tipologiastudentesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrtrainer', 'seg', 'learningagrtrainersegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accreditokind', 'default', 'accreditokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'isee_seganagstu', 'dichiarisee_seganagstuview', 'isee_seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'disabil_seganagstu', 'dichiardisabil_seganagstuview', 'disabil_seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilkind', 'default', 'dichiardisabilkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilsuppkind', 'default', 'dichiardisabilsuppkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'disabil_seg', 'dichiardisabil_segview', 'disabil_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'isee_seg', 'dichiarisee_segview', 'isee_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altrititoli_seg', 'dichiaraltrititoli_segview', 'altrititoli_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altre_seg', 'dichiaraltre_segview', 'altre_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segcons', 'sostenimentosegconsview', 'segcons', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiaraltrekind', 'default', 'dichiaraltrekinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'titolo_seg', 'dichiartitolo_segview', 'titolo_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'rin_seg', 'istanzarin_segview', 'rin_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'tru_seg', 'istanzatru_segview', 'tru_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolostudio', 'segtitolo', 'titolostudiosegtitoloview', 'segtitolo', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'eq_seg', 'istanzaeq_segview', 'eq_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'cert_seg', 'istanzacert_segview', 'cert_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'sosp_seg', 'istanzasosp_segview', 'sosp_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzaattach', 'seg', 'istanzaattachsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('delibera', 'seg', 'deliberasegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getdocentiperssd', 'seg', 'getdocentiperssdsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcostididattica', 'default', 'getcostididatticadefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getregistrydocentiamministrativi', 'default', 'getregistrydocentiamministratividefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcostididattica', 'erogata', 'getcostididatticaerogataview', 'erogata', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('workpackage', 'seg', 'workpackagesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'default', 'accmotivedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetacquire', 'seg', 'assetacquiresegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'default', 'publicazdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'docenti', 'publicazdocentiview', 'docenti', NULL, NULL, NULL, NULL)
 --insert--[DBO]--
-- CREAZIONE TABELLA progetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progetto] (
idprogetto int NOT NULL,
budget decimal(14,2) NULL,
budgetcalcolato decimal(14,2) NULL,
budgetcalcolatodate datetime NULL,
capofilatxt nvarchar(2048) NULL,
codiceidentificativo varchar(2048) NULL,
contributo decimal(14,2) NULL,
contributoente decimal(14,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cup varchar(15) NULL,
data date NULL,
description nvarchar(max) NULL,
durata int NULL,
finanziatoretxt nvarchar(2048) NULL,
idcorsostudio int NULL,
idcurrency int NULL,
idduratakind int NULL,
idprogettokind int NULL,
idprogettostatuskind int NULL,
idreg int NULL,
idreg_aziende int NULL,
idreg_aziende_fin int NULL,
idregistryprogfin int NULL,
idregistryprogfinbando int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start date NULL,
stop date NULL,
title nvarchar(4000) NULL,
titolobreve nvarchar(2048) NULL,
totalbudget decimal(14,2) NULL,
totalcontributo decimal(14,2) NULL,
url varchar(1024) NULL,
 CONSTRAINT xpkprogetto PRIMARY KEY (idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budget decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budget decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budgetcalcolato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budgetcalcolato decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budgetcalcolato decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budgetcalcolatodate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budgetcalcolatodate datetime NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budgetcalcolatodate datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'capofilatxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD capofilatxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN capofilatxt nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'codiceidentificativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD codiceidentificativo varchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN codiceidentificativo varchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'contributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD contributo decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN contributo decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'contributoente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD contributoente decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN contributoente decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'cup' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD cup varchar(15) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN cup varchar(15) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD data date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'durata' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD durata int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN durata int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'finanziatoretxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD finanziatoretxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN finanziatoretxt nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idcurrency int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idcurrency int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idduratakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idduratakind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idduratakind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogettokind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idprogettokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogettostatuskind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idprogettostatuskind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg_aziende' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg_aziende int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg_aziende int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg_aziende_fin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg_aziende_fin int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg_aziende_fin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idregistryprogfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idregistryprogfin int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idregistryprogfin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idregistryprogfinbando' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idregistryprogfinbando int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idregistryprogfinbando int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD start date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD stop date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD title nvarchar(4000) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN title nvarchar(4000) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'titolobreve' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD titolobreve nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN titolobreve nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'totalbudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD totalbudget decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN totalbudget decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'totalcontributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD totalcontributo decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN totalcontributo decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'url' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD url varchar(1024) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN url varchar(1024) NULL
GO

-- VERIFICA DI progetto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progetto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','budget','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','budgetcalcolato','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','datetime','assistenza','budgetcalcolatodate','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(2048)','assistenza','capofilatxt','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','varchar(2048)','assistenza','codiceidentificativo','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','contributo','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','contributoente','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','varchar(15)','assistenza','cup','15','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','data','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(max)','assistenza','description','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','durata','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(2048)','assistenza','finanziatoretxt','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idcorsostudio','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idcurrency','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idduratakind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idprogettokind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idprogettostatuskind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idreg','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idreg_aziende','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idreg_aziende_fin','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idregistryprogfin','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idregistryprogfinbando','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','start','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','stop','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(4000)','assistenza','title','4000','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(2048)','assistenza','titolobreve','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','totalbudget','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','totalcontributo','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','varchar(1024)','assistenza','url','1024','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progetto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progetto')
UPDATE customobject set isreal = 'S' where objectname = 'progetto'
ELSE
INSERT INTO customobject (objectname, isreal) values('progetto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progetto')
UPDATE [tabledescr] SET description = 'Progetto di ricerca',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:00:37.623'},lu = 'assistenza',title = 'Progetto di ricerca' WHERE tablename = 'progetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progetto','Progetto di ricerca',null,'N',{ts '2020-05-20 14:00:37.623'},'assistenza','Progetto di ricerca')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'budget' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo totale per l''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budget' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budget','progetto','9','14','2','Costo totale per l''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'budgetcalcolato' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo totale effettivo per l''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budgetcalcolato' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budgetcalcolato','progetto','9','14','2','Costo totale effettivo per l''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'budgetcalcolatodate' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Calcolato il',kind = 'S',lt = {ts '2020-10-26 10:44:21.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'budgetcalcolatodate' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budgetcalcolatodate','progetto','8',null,null,'Calcolato il','S',{ts '2020-10-26 10:44:21.677'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'capofilatxt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Ente capofila non censito',kind = 'S',lt = {ts '2020-10-26 10:22:18.617'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'capofilatxt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('capofilatxt','progetto','2048',null,null,'Ente capofila non censito','S',{ts '2020-10-26 10:22:18.617'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceidentificativo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Codice identificativo',kind = 'S',lt = {ts '2020-10-30 08:33:43.240'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceidentificativo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceidentificativo','progetto','2048',null,null,'Codice identificativo','S',{ts '2020-10-30 08:33:43.240'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Cofinanziamento richiesto all''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributo','progetto','9','14','2','Cofinanziamento richiesto all''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributoente' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Contributo totale richiesto dall''ateneo allíente finanziatore',kind = 'S',lt = {ts '2020-11-04 16:51:02.247'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributoente' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributoente','progetto','9','14','2','Contributo totale richiesto dall''ateneo allíente finanziatore','S',{ts '2020-11-04 16:51:02.247'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progetto','8',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progetto','64',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cup' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '15',col_precision = null,col_scale = null,description = 'Codice univoco progetto (CUP)',kind = 'S',lt = {ts '2020-10-30 17:51:30.213'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cup' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cup','progetto','15',null,null,'Codice univoco progetto (CUP)','S',{ts '2020-10-30 17:51:30.213'},'assistenza','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di presentazione',kind = 'S',lt = {ts '2020-05-25 13:14:10.947'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','progetto','3',null,null,'Data di presentazione','S',{ts '2020-05-25 13:14:10.947'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-20 14:03:58.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','progetto','0',null,null,'Descrizione','S',{ts '2020-05-20 14:03:58.150'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'durata' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:11:44.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'durata' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('durata','progetto','4',null,null,null,'S',{ts '2020-05-25 13:11:44.723'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanziatoretxt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Ente finanziatore non censito',kind = 'S',lt = {ts '2020-10-26 10:22:18.617'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'finanziatoretxt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanziatoretxt','progetto','2048',null,null,'Ente finanziatore non censito','S',{ts '2020-10-26 10:22:18.617'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','progetto','4',null,null,'Didattica','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcurrency' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice valuta',kind = 'S',lt = {ts '2020-11-02 18:34:42.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcurrency' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcurrency','progetto','4',null,null,'Codice valuta','S',{ts '2020-11-02 18:34:42.180'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idduratakind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Espressa in',kind = 'S',lt = {ts '2020-05-25 13:14:10.947'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idduratakind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idduratakind','progetto','4',null,null,'Espressa in','S',{ts '2020-05-25 13:14:10.947'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice interno',kind = 'S',lt = {ts '2020-10-30 08:33:16.517'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progetto','4',null,null,'Codice interno','S',{ts '2020-10-30 08:33:16.517'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di progetto o attivit‡',kind = 'S',lt = {ts '2020-11-04 16:52:57.667'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progetto','4',null,null,'Tipo di progetto o attivit‡','S',{ts '2020-11-04 16:52:57.667'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettostatuskind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato del progetto o attivit‡',kind = 'S',lt = {ts '2020-09-30 16:14:37.087'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettostatuskind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettostatuskind','progetto','4',null,null,'Stato del progetto o attivit‡','S',{ts '2020-09-30 16:14:37.087'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Principal investigator / Responsabile di progetto ',kind = 'S',lt = {ts '2020-07-15 17:09:18.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','progetto','4',null,null,'Principal investigator / Responsabile di progetto ','S',{ts '2020-07-15 17:09:18.147'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ente capofila',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende','progetto','4',null,null,'Ente capofila','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende_fin' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ente finanziatore',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende_fin' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende_fin','progetto','4',null,null,'Ente finanziatore','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryprogfin' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Programma di finanziamento',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryprogfin' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryprogfin','progetto','4',null,null,'Programma di finanziamento','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryprogfinbando' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Bando di riferimento',kind = 'S',lt = {ts '2020-06-12 18:11:47.253'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryprogfinbando' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryprogfinbando','progetto','4',null,null,'Bando di riferimento','S',{ts '2020-06-12 18:11:47.253'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progetto','8',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progetto','64',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','progetto','3',null,null,'Data di inizio','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','progetto','3',null,null,'Data di fine','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4000',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(4000)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progetto','4000',null,null,'Titolo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','nvarchar(4000)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'titolobreve' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo breve o acronimo',kind = 'S',lt = {ts '2020-05-20 14:03:58.153'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'titolobreve' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('titolobreve','progetto','2048',null,null,'Titolo breve o acronimo','S',{ts '2020-05-20 14:03:58.153'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totalbudget' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo globale del progetto per tutto il partenariato',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totalbudget' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totalbudget','progetto','9','14','2','Costo globale del progetto per tutto il partenariato','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totalcontributo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Contributo globale del progetto per tutto il partenariato',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totalcontributo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totalcontributo','progetto','9','14','2','Contributo globale del progetto per tutto il partenariato','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'url' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'URL del sito del progetto',kind = 'S',lt = {ts '2020-11-02 18:28:26.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'url' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('url','progetto','1024',null,null,'URL del sito del progetto','S',{ts '2020-11-02 18:28:26.997'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettoattach --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoattach]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettoattach] (
idprogetto int NOT NULL,
idprogettoattach int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idattach int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkprogettoattach PRIMARY KEY (idprogetto,
idprogettoattach
)
)
END
GO

-- VERIFICA STRUTTURA progettoattach --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattach' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattach] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattach') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattach' and C.name = 'idprogettoattach' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattach] ADD idprogettoattach int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattach') and col.name = 'idprogettoattach' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattach' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattach] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattach') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoattach] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattach' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattach] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattach') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoattach] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattach' and C.name = 'idattach' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattach] ADD idattach int NULL 
END
ELSE
	ALTER TABLE [progettoattach] ALTER COLUMN idattach int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattach' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattach] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattach') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoattach] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattach' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattach] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattach') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoattach] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattach' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattach] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettoattach] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI progettoattach IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettoattach'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattach','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattach','int','ASSISTENZA','idprogettoattach','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattach','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattach','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattach','int','ASSISTENZA','idattach','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattach','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattach','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattach','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettoattach IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettoattach')
UPDATE customobject set isreal = 'S' where objectname = 'progettoattach'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettoattach', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettoattach')
UPDATE [tabledescr] SET description = 'Allegati al progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-06-05 15:49:00.543'},lu = 'assistenza',title = 'Allegati' WHERE tablename = 'progettoattach'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettoattach','Allegati al progetto',null,'N',{ts '2020-06-05 15:49:00.543'},'assistenza','Allegati')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettoattach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:49:02.623'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettoattach','8',null,null,null,'S',{ts '2020-06-05 15:49:02.623'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettoattach')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:49:02.623'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettoattach','64',null,null,null,'S',{ts '2020-06-05 15:49:02.623'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattach' AND tablename = 'progettoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Allegato',kind = 'S',lt = {ts '2020-06-05 15:49:12.797'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattach' AND tablename = 'progettoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattach','progettoattach','4',null,null,'Allegato','S',{ts '2020-06-05 15:49:12.797'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:49:02.623'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettoattach','4',null,null,null,'S',{ts '2020-06-05 15:49:02.623'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettoattach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:49:02.623'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettoattach','8',null,null,null,'S',{ts '2020-06-05 15:49:02.623'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettoattach')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:49:02.623'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettoattach','64',null,null,null,'S',{ts '2020-06-05 15:49:02.623'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progettoattach')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-06-12 18:36:50.033'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progettoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progettoattach','2048',null,null,'Titolo','S',{ts '2020-06-12 18:36:50.033'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettoattachkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoattachkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettoattachkind] (
idprogettoattachkind int NOT NULL,
idprogettokind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkprogettoattachkind PRIMARY KEY (idprogettoattachkind,
idprogettokind
)
)
END
GO

-- VERIFICA STRUTTURA progettoattachkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkind' and C.name = 'idprogettoattachkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkind] ADD idprogettoattachkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkind') and col.name = 'idprogettoattachkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkind' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkind] ADD idprogettokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkind') and col.name = 'idprogettokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoattachkind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoattachkind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoattachkind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoattachkind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkind] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettoattachkind] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI progettoattachkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettoattachkind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattachkind','int','ASSISTENZA','idprogettoattachkind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattachkind','int','ASSISTENZA','idprogettokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattachkind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattachkind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattachkind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattachkind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattachkind','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettoattachkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettoattachkind')
UPDATE customobject set isreal = 'S' where objectname = 'progettoattachkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettoattachkind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettoattachkind')
UPDATE [tabledescr] SET description = 'Allegati necessari nel 2.7.10 modello dei progetti',idapplication = null,isdbo = 'N',lt = {ts '2020-06-12 15:45:29.600'},lu = 'assistenza',title = 'Allegati necessari' WHERE tablename = 'progettoattachkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettoattachkind','Allegati necessari nel 2.7.10 modello dei progetti',null,'N',{ts '2020-06-12 15:45:29.600'},'assistenza','Allegati necessari')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettoattachkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:45:32.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettoattachkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettoattachkind','8',null,null,null,'S',{ts '2020-06-12 15:45:32.177'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettoattachkind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:45:32.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettoattachkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettoattachkind','64',null,null,null,'S',{ts '2020-06-12 15:45:32.177'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettoattachkind' AND tablename = 'progettoattachkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:45:32.177'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettoattachkind' AND tablename = 'progettoattachkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettoattachkind','progettoattachkind','4',null,null,null,'S',{ts '2020-06-12 15:45:32.177'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progettoattachkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Modello di attivit? o progetto',kind = 'S',lt = {ts '2020-06-12 15:46:03.017'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progettoattachkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progettoattachkind','4',null,null,'Modello di attivit? o progetto','S',{ts '2020-06-12 15:46:03.017'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettoattachkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:45:32.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettoattachkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettoattachkind','8',null,null,null,'S',{ts '2020-06-12 15:45:32.180'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettoattachkind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:45:32.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettoattachkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettoattachkind','64',null,null,null,'S',{ts '2020-06-12 15:45:32.180'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progettoattachkind')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2020-06-12 15:46:03.017'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progettoattachkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progettoattachkind','2048',null,null,'Denominazione','S',{ts '2020-06-12 15:46:03.017'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettoattachkindprogettostatuskind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoattachkindprogettostatuskind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettoattachkindprogettostatuskind] (
idprogettostatuskind int NOT NULL,
idprogettoattachkind int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
 CONSTRAINT xpkprogettoattachkindprogettostatuskind PRIMARY KEY (idprogettostatuskind,
idprogettoattachkind
)
)
END
GO

-- VERIFICA STRUTTURA progettoattachkindprogettostatuskind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD idprogettostatuskind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkindprogettostatuskind') and col.name = 'idprogettostatuskind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkindprogettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'idprogettoattachkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD idprogettoattachkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkindprogettostatuskind') and col.name = 'idprogettoattachkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkindprogettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN lu varchar(60) NULL
GO

-- VERIFICA DI progettoattachkindprogettostatuskind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettoattachkindprogettostatuskind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattachkindprogettostatuskind','int','assistenza','idprogettoattachkind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattachkindprogettostatuskind','int','assistenza','idprogettostatuskind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattachkindprogettostatuskind','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattachkindprogettostatuskind','varchar(60)','assistenza','cu','60','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattachkindprogettostatuskind','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattachkindprogettostatuskind','varchar(60)','assistenza','lu','60','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progettoattachkindprogettostatuskind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettoattachkindprogettostatuskind')
UPDATE customobject set isreal = 'S' where objectname = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettoattachkindprogettostatuskind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettoattachkindprogettostatuskind')
UPDATE [tabledescr] SET description = 'Stati in cui l''allegato Ë obbligatorio',idapplication = null,isdbo = 'N',lt = {ts '2020-11-12 16:17:08.297'},lu = 'assistenza',title = 'Stati in cui l''allegato Ë obbligatorio' WHERE tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettoattachkindprogettostatuskind','Stati in cui l''allegato Ë obbligatorio',null,'N',{ts '2020-11-12 16:17:08.297'},'assistenza','Stati in cui l''allegato Ë obbligatorio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:17:12.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettoattachkindprogettostatuskind','8',null,null,null,'S',{ts '2020-11-12 16:17:12.303'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:17:12.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettoattachkindprogettostatuskind','60',null,null,null,'S',{ts '2020-11-12 16:17:12.303'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettoattachkind' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:17:12.303'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettoattachkind' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettoattachkind','progettoattachkindprogettostatuskind','4',null,null,null,'S',{ts '2020-11-12 16:17:12.303'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettostatuskind' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2020-11-12 16:17:38.733'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettostatuskind' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettostatuskind','progettoattachkindprogettostatuskind','4',null,null,'Stato','S',{ts '2020-11-12 16:17:38.733'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:17:12.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettoattachkindprogettostatuskind','8',null,null,null,'S',{ts '2020-11-12 16:17:12.303'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:17:12.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettoattachkindprogettostatuskind','60',null,null,null,'S',{ts '2020-11-12 16:17:12.303'},'assistenza','N','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettokind] (
idprogettokind int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
description nvarchar(max) NULL,
idprogettoactivitykind int NULL,
lt datetime NULL,
lu varchar(64) NULL,
oredivisionecostostipendio int NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkprogettokind PRIMARY KEY (idprogettokind
)
)
END
GO

-- VERIFICA STRUTTURA progettokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD idprogettokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettokind') and col.name = 'idprogettokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'idprogettoactivitykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD idprogettoactivitykind int NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN idprogettoactivitykind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'oredivisionecostostipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD oredivisionecostostipendio int NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN oredivisionecostostipendio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI progettokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettokind','int','ASSISTENZA','idprogettokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','nvarchar(max)','ASSISTENZA','description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','int','ASSISTENZA','idprogettoactivitykind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','int','ASSISTENZA','oredivisionecostostipendio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettokind')
UPDATE customobject set isreal = 'S' where objectname = 'progettokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettokind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettokind')
UPDATE [tabledescr] SET description = 'Tipologie di progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-05-22 12:54:10.557'},lu = 'assistenza',title = 'Tipologie di progetto' WHERE tablename = 'progettokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettokind','Tipologie di progetto',null,'N',{ts '2020-05-22 12:54:10.557'},'assistenza','Tipologie di progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:42:22.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettokind','8',null,null,null,'S',{ts '2020-07-14 15:42:22.470'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:42:22.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettokind','64',null,null,null,'S',{ts '2020-07-14 15:42:22.470'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-22 12:55:03.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','progettokind','0',null,null,'Descrizione','S',{ts '2020-05-22 12:55:03.843'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettoactivitykind' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2020-07-14 15:44:27.693'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettoactivitykind' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettoactivitykind','progettokind','4',null,null,'Tipologia','S',{ts '2020-07-14 15:44:27.693'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:30:12.453'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progettokind','4',null,null,null,'S',{ts '2020-06-05 16:30:12.453'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokindkind' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2020-06-05 16:30:12.453'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokindkind' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokindkind','progettokind','4',null,null,'Tipologia','S',{ts '2020-06-05 16:30:12.453'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:42:22.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettokind','8',null,null,null,'S',{ts '2020-07-14 15:42:22.470'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:42:22.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettokind','64',null,null,null,'S',{ts '2020-07-14 15:42:22.470'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oredivisionecostostipendio' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero ore lavorate in un anno dal personale',kind = 'S',lt = {ts '2020-07-14 15:44:27.693'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oredivisionecostostipendio' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oredivisionecostostipendio','progettokind','4',null,null,'Numero ore lavorate in un anno dal personale','S',{ts '2020-07-14 15:44:27.693'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-05-22 12:55:03.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progettokind','2048',null,null,'Titolo','S',{ts '2020-05-22 12:55:03.843'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettotestokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettotestokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettotestokind] (
idprogettotestokind int NOT NULL,
idprogettokind int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NULL,
titolo nvarchar(2048) NULL,
 CONSTRAINT xpkprogettotestokind PRIMARY KEY (idprogettotestokind,
idprogettokind
)
)
END
GO

-- VERIFICA STRUTTURA progettotestokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokind' and C.name = 'idprogettotestokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokind] ADD idprogettotestokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotestokind') and col.name = 'idprogettotestokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotestokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokind' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokind] ADD idprogettokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotestokind') and col.name = 'idprogettokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotestokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotestokind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotestokind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotestokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotestokind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [progettotestokind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokind' and C.name = 'titolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokind] ADD titolo nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettotestokind] ALTER COLUMN titolo nvarchar(2048) NULL
GO

-- VERIFICA DI progettotestokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettotestokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotestokind','int','ASSISTENZA','idprogettokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotestokind','int','ASSISTENZA','idprogettotestokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokind','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokind','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokind','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokind','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokind','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokind','nvarchar(2048)','ASSISTENZA','titolo','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettotestokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettotestokind')
UPDATE customobject set isreal = 'S' where objectname = 'progettotestokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettotestokind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotestokind')
UPDATE [tabledescr] SET description = 'Testi nei 2.7.10 modelli di progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-05-25 13:17:58.427'},lu = 'assistenza',title = 'Testi nei modelli di progetto' WHERE tablename = 'progettotestokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotestokind','Testi nei 2.7.10 modelli di progetto',null,'N',{ts '2020-05-25 13:17:58.427'},'assistenza','Testi nei modelli di progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotestokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:18:03.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotestokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotestokind','8',null,null,null,'S',{ts '2020-05-25 13:18:03.177'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotestokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:18:03.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotestokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotestokind','64',null,null,null,'S',{ts '2020-05-25 13:18:03.177'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progettotestokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:18:03.177'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progettotestokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progettotestokind','4',null,null,null,'S',{ts '2020-05-25 13:18:03.177'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotestokind' AND tablename = 'progettotestokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:18:03.177'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotestokind' AND tablename = 'progettotestokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotestokind','progettotestokind','4',null,null,null,'S',{ts '2020-05-25 13:18:03.177'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotestokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:18:03.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotestokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotestokind','8',null,null,null,'S',{ts '2020-05-25 13:18:03.177'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotestokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:18:03.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotestokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotestokind','64',null,null,null,'S',{ts '2020-05-25 13:18:03.177'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'progettotestokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordine di presentazione',kind = 'S',lt = {ts '2020-05-25 13:18:35.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'progettotestokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','progettotestokind','4',null,null,'Ordine di presentazione','S',{ts '2020-05-25 13:18:35.983'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'titolo' AND tablename = 'progettotestokind')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-05-26 18:09:30.050'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'titolo' AND tablename = 'progettotestokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('titolo','progettotestokind','2048',null,null,'Titolo','S',{ts '2020-05-26 18:09:30.050'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettotestokindprogettostatuskind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettotestokindprogettostatuskind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettotestokindprogettostatuskind] (
idprogettostatuskind int NOT NULL,
idprogettotestokind int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
 CONSTRAINT xpkprogettotestokindprogettostatuskind PRIMARY KEY (idprogettostatuskind,
idprogettotestokind
)
)
END
GO

-- VERIFICA STRUTTURA progettotestokindprogettostatuskind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD idprogettostatuskind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotestokindprogettostatuskind') and col.name = 'idprogettostatuskind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotestokindprogettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'idprogettotestokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD idprogettotestokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotestokindprogettostatuskind') and col.name = 'idprogettotestokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotestokindprogettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotestokindprogettostatuskind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotestokindprogettostatuskind] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotestokindprogettostatuskind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotestokindprogettostatuskind] ALTER COLUMN lu varchar(60) NULL
GO

-- VERIFICA DI progettotestokindprogettostatuskind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettotestokindprogettostatuskind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotestokindprogettostatuskind','int','assistenza','idprogettostatuskind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotestokindprogettostatuskind','int','assistenza','idprogettotestokind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokindprogettostatuskind','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokindprogettostatuskind','varchar(60)','assistenza','cu','60','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokindprogettostatuskind','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokindprogettostatuskind','varchar(60)','assistenza','lu','60','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progettotestokindprogettostatuskind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettotestokindprogettostatuskind')
UPDATE customobject set isreal = 'S' where objectname = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettotestokindprogettostatuskind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotestokindprogettostatuskind')
UPDATE [tabledescr] SET description = 'Stati in cui il testo Ë obbligatorio',idapplication = null,isdbo = 'N',lt = {ts '2020-11-12 16:18:29.967'},lu = 'assistenza',title = 'Stati in cui il testo Ë obbligatorio' WHERE tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotestokindprogettostatuskind','Stati in cui il testo Ë obbligatorio',null,'N',{ts '2020-11-12 16:18:29.967'},'assistenza','Stati in cui il testo Ë obbligatorio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:18:33.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotestokindprogettostatuskind','8',null,null,null,'S',{ts '2020-11-12 16:18:33.673'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:18:33.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotestokindprogettostatuskind','60',null,null,null,'S',{ts '2020-11-12 16:18:33.673'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettostatuskind' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2020-11-12 16:18:43.750'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettostatuskind' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettostatuskind','progettotestokindprogettostatuskind','4',null,null,'Stato','S',{ts '2020-11-12 16:18:43.750'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotestokind' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:18:33.673'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotestokind' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotestokind','progettotestokindprogettostatuskind','4',null,null,null,'S',{ts '2020-11-12 16:18:33.673'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:18:33.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotestokindprogettostatuskind','8',null,null,null,'S',{ts '2020-11-12 16:18:33.677'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:18:33.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotestokindprogettostatuskind','60',null,null,null,'S',{ts '2020-11-12 16:18:33.677'},'assistenza','N','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA publicaz --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[publicaz]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[publicaz] (
idpublicaz int NOT NULL,
abstractstring nvarchar(max) NULL,
annocopyright int NULL,
annopub int NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
editore varchar(150) NULL,
fascicolo varchar(150) NULL,
idcity int NULL,
idcity_ed int NULL,
idnation_ed int NULL,
idnation_lang int NULL,
idprogetto int NULL,
isbn varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
numrivista int NULL,
pagestart int NULL,
pagestop int NULL,
pagetot int NULL,
title varchar(512) NULL,
title2 nvarchar(512) NULL,
volume varchar(150) NULL,
 CONSTRAINT xpkpublicaz PRIMARY KEY (idpublicaz
)
)
END
GO

-- VERIFICA STRUTTURA publicaz --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idpublicaz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idpublicaz int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'idpublicaz' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'abstractstring' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD abstractstring nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN abstractstring nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'annocopyright' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD annocopyright int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN annocopyright int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'annopub' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD annopub int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN annopub int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'editore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD editore varchar(150) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN editore varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'fascicolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD fascicolo varchar(150) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN fascicolo varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idcity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idcity int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idcity int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idcity_ed' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idcity_ed int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idcity_ed int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idnation_ed' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idnation_ed int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idnation_ed int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idnation_lang' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idnation_lang int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idnation_lang int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idprogetto int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idprogetto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'isbn' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD isbn varchar(50) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN isbn varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'numrivista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD numrivista int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN numrivista int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'pagestart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD pagestart int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN pagestart int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'pagestop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD pagestop int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN pagestop int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'pagetot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD pagetot int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN pagetot int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD title varchar(512) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN title varchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'title2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD title2 nvarchar(512) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN title2 nvarchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'volume' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD volume varchar(150) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN volume varchar(150) NULL
GO

-- VERIFICA DI publicaz IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'publicaz'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicaz','int','ASSISTENZA','idpublicaz','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','nvarchar(max)','ASSISTENZA','abstractstring','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','ASSISTENZA','annocopyright','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','ASSISTENZA','annopub','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicaz','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicaz','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','varchar(150)','ASSISTENZA','editore','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','varchar(150)','ASSISTENZA','fascicolo','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','ASSISTENZA','idcity_ed','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','ASSISTENZA','idnation_ed','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','ASSISTENZA','idnation_lang','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','','idprogetto','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','varchar(50)','ASSISTENZA','isbn','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicaz','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicaz','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','ASSISTENZA','numrivista','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','ASSISTENZA','pagestart','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','ASSISTENZA','pagestop','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','ASSISTENZA','pagetot','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','varchar(512)','ASSISTENZA','title','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','nvarchar(512)','ASSISTENZA','title2','512','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','varchar(150)','ASSISTENZA','volume','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI publicaz IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'publicaz')
UPDATE customobject set isreal = 'S' where objectname = 'publicaz'
ELSE
INSERT INTO customobject (objectname, isreal) values('publicaz', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'publicaz')
UPDATE [tabledescr] SET description = '2.4.27 pubblicazione',idapplication = null,isdbo = 'N',lt = {ts '2018-07-17 17:01:53.440'},lu = 'assistenza',title = 'Pubblicazione' WHERE tablename = 'publicaz'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('publicaz','2.4.27 pubblicazione',null,'N',{ts '2018-07-17 17:01:53.440'},'assistenza','Pubblicazione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'abstractstring' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Abstract',kind = 'S',lt = {ts '2018-12-04 18:12:43.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'abstractstring' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('abstractstring','publicaz','0',null,null,'Abstract','S',{ts '2018-12-04 18:12:43.767'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annocopyright' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno Copyright',kind = 'S',lt = {ts '2018-11-21 18:33:45.263'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annocopyright' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annocopyright','publicaz','4',null,null,'Anno Copyright','S',{ts '2018-11-21 18:33:45.263'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annopub' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno pubblicazione',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annopub' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annopub','publicaz','4',null,null,'Anno pubblicazione','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','publicaz','8',null,null,null,'S',{ts '2018-07-17 17:01:54.597'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','publicaz','64',null,null,null,'S',{ts '2018-07-17 17:01:54.597'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'editore' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'editore' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('editore','publicaz','150',null,null,null,'S',{ts '2018-07-17 17:01:54.597'},'assistenza','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fascicolo' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'fascicolo' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fascicolo','publicaz','150',null,null,null,'S',{ts '2018-07-17 17:01:54.597'},'assistenza','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Comune',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity','publicaz','4',null,null,'Comune','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity_ed' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Comune editore',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity_ed' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity_ed','publicaz','4',null,null,'Comune editore','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation_ed' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Nazionalit? editore',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation_ed' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation_ed','publicaz','4',null,null,'Nazionalit? editore','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation_lang' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Lingua',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation_lang' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation_lang','publicaz','4',null,null,'Lingua','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpublicaz' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Istituto',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpublicaz' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpublicaz','publicaz','4',null,null,'Codice Istituto','S',{ts '2018-11-21 18:33:45.267'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'isbn' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'ISBN',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'isbn' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('isbn','publicaz','50',null,null,'ISBN','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','publicaz','8',null,null,null,'S',{ts '2018-07-17 17:01:54.600'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','publicaz','64',null,null,null,'S',{ts '2018-07-17 17:01:54.600'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numrivista' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero Rivista',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numrivista' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numrivista','publicaz','4',null,null,'Numero Rivista','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pagestart' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Inizio a pagina',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'pagestart' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pagestart','publicaz','4',null,null,'Inizio a pagina','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pagestop' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'fine a pagina',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'pagestop' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pagestop','publicaz','4',null,null,'fine a pagina','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pagetot' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di pagine',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'pagetot' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pagetot','publicaz','4',null,null,'Numero di pagine','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','publicaz','512',null,null,'Titolo','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title2' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Sottotitolo',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(512)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title2' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title2','publicaz','512',null,null,'Sottotitolo','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','nvarchar(512)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'volume' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'volume' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('volume','publicaz','150',null,null,null,'S',{ts '2018-07-17 17:01:54.600'},'assistenza','N','varchar(150)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA publicazregistry_docenti --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[publicazregistry_docenti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[publicazregistry_docenti] (
idreg_docenti int NOT NULL,
idpublicaz int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpublicazregistry_docenti PRIMARY KEY (idreg_docenti,
idpublicaz
)
)
END
GO

-- VERIFICA STRUTTURA publicazregistry_docenti --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_docenti' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_docenti] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_docenti') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_docenti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_docenti' and C.name = 'idpublicaz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_docenti] ADD idpublicaz int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_docenti') and col.name = 'idpublicaz' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_docenti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_docenti' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_docenti] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_docenti') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazregistry_docenti] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_docenti' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_docenti] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_docenti') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazregistry_docenti] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_docenti' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_docenti] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_docenti') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazregistry_docenti] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_docenti' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_docenti] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_docenti') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazregistry_docenti] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI publicazregistry_docenti IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'publicazregistry_docenti'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_docenti','int','ASSISTENZA','idpublicaz','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_docenti','int','ASSISTENZA','idreg_docenti','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_docenti','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_docenti','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_docenti','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_docenti','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI publicazregistry_docenti IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'publicazregistry_docenti')
UPDATE customobject set isreal = 'S' where objectname = 'publicazregistry_docenti'
ELSE
INSERT INTO customobject (objectname, isreal) values('publicazregistry_docenti', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'publicazregistry_docenti')
UPDATE [tabledescr] SET description = 'autori della 2.4.27 pubblicazione',idapplication = null,isdbo = 'N',lt = {ts '2018-11-21 18:48:05.547'},lu = 'assistenza',title = 'Autori della pubblicazione' WHERE tablename = 'publicazregistry_docenti'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('publicazregistry_docenti','autori della 2.4.27 pubblicazione',null,'N',{ts '2018-11-21 18:48:05.547'},'assistenza','Autori della pubblicazione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'publicazregistry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:29.370'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'publicazregistry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','publicazregistry_docenti','8',null,null,null,'S',{ts '2018-07-17 17:01:29.370'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'publicazregistry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:29.370'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'publicazregistry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','publicazregistry_docenti','64',null,null,null,'S',{ts '2018-07-17 17:01:29.370'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpublicaz' AND tablename = 'publicazregistry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Pubblicazione',kind = 'S',lt = {ts '2019-02-22 17:07:20.913'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpublicaz' AND tablename = 'publicazregistry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpublicaz','publicazregistry_docenti','4',null,null,'Pubblicazione','S',{ts '2019-02-22 17:07:20.913'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'publicazregistry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente',kind = 'S',lt = {ts '2019-02-22 17:07:20.913'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'publicazregistry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','publicazregistry_docenti','4',null,null,'Docente','S',{ts '2019-02-22 17:07:20.913'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'publicazregistry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:29.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'publicazregistry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','publicazregistry_docenti','8',null,null,null,'S',{ts '2018-07-17 17:01:29.373'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'publicazregistry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:29.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'publicazregistry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','publicazregistry_docenti','64',null,null,null,'S',{ts '2018-07-17 17:01:29.373'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA registry_amministrativi --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_amministrativi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_amministrativi] (
idreg int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
cv nvarchar(max) NULL,
idcontrattokind int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkregistry_amministrativi PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_amministrativi --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_amministrativi') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_amministrativi] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'cv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD cv nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN cv nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN lu varchar(64) NULL
GO

-- VERIFICA DI registry_amministrativi IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry_amministrativi'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_amministrativi','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','nvarchar(max)','ASSISTENZA','cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','int','ASSISTENZA','idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registry_amministrativi IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry_amministrativi')
UPDATE customobject set isreal = 'S' where objectname = 'registry_amministrativi'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry_amministrativi', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_amministrativi')
UPDATE [tabledescr] SET description = '2.7.8 Personale amministrativo',idapplication = null,isdbo = 'N',lt = {ts '2020-05-25 13:44:18.543'},lu = 'assistenza',title = 'Personale amministrativo' WHERE tablename = 'registry_amministrativi'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_amministrativi','2.7.8 Personale amministrativo',null,'N',{ts '2020-05-25 13:44:18.543'},'assistenza','Personale amministrativo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_amministrativi','8',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_amministrativi','64',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cv' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Curriculum vitae',kind = 'S',lt = {ts '2020-05-25 13:44:54.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cv' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cv','registry_amministrativi','0',null,null,'Curriculum vitae','S',{ts '2020-05-25 13:44:54.460'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2020-05-25 13:44:54.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','registry_amministrativi','4',null,null,'Tipo','S',{ts '2020-05-25 13:44:54.460'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_amministrativi','4',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_amministrativi','8',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_amministrativi','64',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA registry_docenti --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_docenti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_docenti] (
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cv nvarchar(max) NULL,
idclassconsorsuale int NULL,
idcontrattokind int NULL,
idfonteindicebibliometrico int NULL,
idreg_istituti int NULL,
idsasd int NULL,
idstruttura int NULL,
indicebibliometrico int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
matricola varchar(50) NULL,
ricevimento nvarchar(max) NULL,
soggiorno varchar(255) NULL,
 CONSTRAINT xpkregistry_docenti PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_docenti --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'cv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD cv nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN cv nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idclassconsorsuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idclassconsorsuale int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idclassconsorsuale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idfonteindicebibliometrico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idfonteindicebibliometrico int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idfonteindicebibliometrico int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idreg_istituti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idreg_istituti int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idreg_istituti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'indicebibliometrico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD indicebibliometrico int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN indicebibliometrico int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'matricola' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD matricola varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN matricola varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'ricevimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD ricevimento nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN ricevimento nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'soggiorno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD soggiorno varchar(255) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN soggiorno varchar(255) NULL
GO

-- VERIFICA DI registry_docenti IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry_docenti'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','nvarchar(max)','ASSISTENZA','cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idclassconsorsuale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idfonteindicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idreg_istituti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idsasd','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','indicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','varchar(50)','ASSISTENZA','matricola','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','nvarchar(max)','ASSISTENZA','ricevimento','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','varchar(255)','ASSISTENZA','soggiorno','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registry_docenti IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry_docenti')
UPDATE customobject set isreal = 'S' where objectname = 'registry_docenti'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry_docenti', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_docenti')
UPDATE [tabledescr] SET description = '2.4.20 docenti',idapplication = null,isdbo = 'N',lt = {ts '2018-11-29 16:25:52.000'},lu = 'Ferdinando',title = 'Docenti' WHERE tablename = 'registry_docenti'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_docenti','2.4.20 docenti',null,'N',{ts '2018-11-29 16:25:52.000'},'Ferdinando','Docenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_docenti','8',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_docenti','64',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cv' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Curriculum Vitae',kind = 'S',lt = {ts '2018-11-27 13:37:14.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cv' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cv','registry_docenti','0',null,null,'Curriculum Vitae','S',{ts '2018-11-27 13:37:14.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassconsorsuale' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Classe consorsuale',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassconsorsuale' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassconsorsuale','registry_docenti','4',null,null,'Classe consorsuale','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2020-05-26 17:44:20.453'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','registry_docenti','4',null,null,'Tipo','S',{ts '2020-05-26 17:44:20.453'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Fonte',kind = 'S',lt = {ts '2020-05-25 13:46:28.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idfonteindicebibliometrico','registry_docenti','4',null,null,'Fonte','S',{ts '2020-05-25 13:46:28.367'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Istituto',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_docenti','4',null,null,'Codice Istituto','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_istituti' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto, Ente o Azienda',kind = 'S',lt = {ts '2019-02-15 17:21:00.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_istituti' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_istituti','registry_docenti','4',null,null,'Istituto, Ente o Azienda','S',{ts '2019-02-15 17:21:00.613'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','registry_docenti','4',null,null,'SASD','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura di afferenza',kind = 'S',lt = {ts '2019-09-09 18:32:55.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','registry_docenti','4',null,null,'Struttura di afferenza','S',{ts '2019-09-09 18:32:55.953'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicebibliometrico' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Indice bibliometrico (H-Index)',kind = 'S',lt = {ts '2020-05-25 13:46:28.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indicebibliometrico' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicebibliometrico','registry_docenti','4',null,null,'Indice bibliometrico (H-Index)','S',{ts '2020-05-25 13:46:28.367'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_docenti','8',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_docenti','64',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'matricola' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Matricola',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'matricola' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('matricola','registry_docenti','50',null,null,'Matricola','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ricevimento' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Orari di ricevimento',kind = 'S',lt = {ts '2018-11-27 13:28:30.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'ricevimento' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ricevimento','registry_docenti','0',null,null,'Orari di ricevimento','S',{ts '2018-11-27 13:28:30.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'soggiorno' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = 'Permesso di soggiorno',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'soggiorno' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('soggiorno','registry_docenti','255',null,null,'Permesso di soggiorno','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','varchar(255)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA rendicontattivitaprogetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontattivitaprogetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[rendicontattivitaprogetto] (
idrendicontattivitaprogetto int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datainizioprevista date NULL,
description varchar(max) NULL,
iditineration int NULL,
idprogetto int NOT NULL,
idreg int NOT NULL,
idworkpackage int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
orepreventivate int NULL,
 CONSTRAINT xpkrendicontattivitaprogetto PRIMARY KEY (idrendicontattivitaprogetto
)
)
END
GO

-- VERIFICA STRUTTURA rendicontattivitaprogetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idrendicontattivitaprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idrendicontattivitaprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idrendicontattivitaprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'datainizioprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD datainizioprevista date NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN datainizioprevista date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD iditineration int NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN iditineration int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN idprogetto int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN idworkpackage int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'orepreventivate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD orepreventivate int NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN orepreventivate int NULL
GO

-- VERIFICA DI rendicontattivitaprogetto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogetto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','date','ASSISTENZA','datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','varchar(max)','ASSISTENZA','description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','int','ASSISTENZA','iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','int','ASSISTENZA','orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogetto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogetto')
UPDATE customobject set isreal = 'S' where objectname = 'rendicontattivitaprogetto'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogetto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicontattivitaprogetto')
UPDATE [tabledescr] SET description = '2.7.3 Attivit? di progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:12:22.837'},lu = 'assistenza',title = 'Attivit? di progetto' WHERE tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicontattivitaprogetto','2.7.3 Attivit? di progetto',null,'N',{ts '2020-05-20 14:12:22.837'},'assistenza','Attivit? di progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','rendicontattivitaprogetto','8',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','rendicontattivitaprogetto','64',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioprevista' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio prevista',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datainizioprevista' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioprevista','rendicontattivitaprogetto','3',null,null,'Data inizio prevista','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','rendicontattivitaprogetto','-1',null,null,'Descrizione','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iditineration' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Missione',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iditineration' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iditineration','rendicontattivitaprogetto','4',null,null,'Missione','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','rendicontattivitaprogetto','4',null,null,'Progetto','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Partecipante',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','rendicontattivitaprogetto','4',null,null,'Partecipante','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogetto','rendicontattivitaprogetto','4',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','rendicontattivitaprogetto','4',null,null,'Workpackage','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','rendicontattivitaprogetto','8',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','rendicontattivitaprogetto','64',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orepreventivate' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di ore preventivate',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orepreventivate' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orepreventivate','rendicontattivitaprogetto','4',null,null,'Numero di ore preventivate','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA assetsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[assetsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[assetsegview]
GO

CREATE VIEW [dbo].[assetsegview] AS SELECT  asset.amortizationquota AS asset_amortizationquota, asset.ct AS asset_ct, asset.cu AS asset_cu, asset.flag AS asset_flag, asset.idasset, asset.idasset_prev AS asset_idasset_prev, asset.idassetunload AS asset_idassetunload, asset.idcurrlocation AS asset_idcurrlocation, asset.idcurrman AS asset_idcurrman, asset.idcurrsubman AS asset_idcurrsubman, amministrazione.inventory.description AS inventory_description, asset.idinventory, asset.idinventoryamortization AS asset_idinventoryamortization, asset.idpiece, asset.idpiece_prev AS asset_idpiece_prev, asset.lifestart AS asset_lifestart, asset.lt AS asset_lt, asset.lu AS asset_lu, asset.multifield AS asset_multifield, amministrazione.assetacquire.description AS assetacquire_description, inventorytree.codeinv AS inventorytree_codeinv, inventorytree.description AS inventorytree_description, asset.nassetacquire, asset.ninventory AS asset_ninventory, asset.rfid AS asset_rfid, asset.rtf AS asset_rtf,CASE WHEN asset.transmitted = 'S' THEN 'Si' WHEN asset.transmitted = 'N' THEN 'No' END AS asset_transmitted, asset.txt AS asset_txt, isnull('Descrizione: ' + amministrazione.assetacquire.description + '; ','') + ' ' + isnull('Identificativo: ' + CAST( asset.idasset AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice Class. Inv.: ' + inventorytree.codeinv + '; ','') + ' ' + isnull('Denominazione Class. Inv.: ' + inventorytree.description + '; ','') + ' ' + isnull('Numero parte: ' + CAST( asset.idpiece AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Inventario: ' + amministrazione.inventory.description + '; ','') + ' ' + isnull('Numero inventario: ' + CAST( asset.ninventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice RFID: ' + asset.rfid + '; ','') as dropdown_title FROM amministrazione.asset WITH (NOLOCK)  LEFT OUTER JOIN amministrazione.inventory WITH (NOLOCK) ON asset.idinventory = amministrazione.inventory.idinventory LEFT OUTER JOIN amministrazione.assetacquire WITH (NOLOCK) ON asset.nassetacquire = amministrazione.assetacquire.nassetacquire LEFT OUTER JOIN inventorytree WITH (NOLOCK) ON assetacquire.idinv = inventorytree.idinv WHERE  asset.idasset IS NOT NULL  AND asset.idpiece IS NOT NULL 
GO

-- VERIFICA DI assetsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','float','ASSISTENZA','asset_amortizationquota','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','datetime','ASSISTENZA','asset_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','varchar(64)','ASSISTENZA','asset_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','tinyint','ASSISTENZA','asset_flag','1','S','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','asset_idasset_prev','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','asset_idassetunload','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','asset_idcurrlocation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','asset_idcurrman','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','asset_idcurrsubman','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','asset_idinventoryamortization','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','asset_idpiece_prev','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','date','ASSISTENZA','asset_lifestart','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','datetime','ASSISTENZA','asset_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','varchar(64)','ASSISTENZA','asset_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(4000)','ASSISTENZA','asset_multifield','4000','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','asset_ninventory','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(30)','ASSISTENZA','asset_rfid','30','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','image','ASSISTENZA','asset_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(2)','ASSISTENZA','asset_transmitted','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','text','ASSISTENZA','asset_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(150)','ASSISTENZA','assetacquire_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','nvarchar(779)','ASSISTENZA','dropdown_title','779','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','int','ASSISTENZA','idasset','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','idinventory','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','int','ASSISTENZA','idpiece','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(50)','ASSISTENZA','inventory_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(50)','','inventorytree_codeinv','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(150)','','inventorytree_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','nassetacquire','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI assetsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetsegview')
UPDATE customobject set isreal = 'N' where objectname = 'assetsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA progettokindsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettokindsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettokindsegview]
GO

CREATE VIEW [dbo].[progettokindsegview] AS SELECT  progettokind.ct AS progettokind_ct, progettokind.cu AS progettokind_cu, progettokind.description AS progettokind_description, progettoactivitykind.title AS progettoactivitykind_title, progettokind.idprogettoactivitykind AS progettokind_idprogettoactivitykind, progettokind.idprogettokind, progettokind.lt AS progettokind_lt, progettokind.lu AS progettokind_lu, progettokind.oredivisionecostostipendio AS progettokind_oredivisionecostostipendio, progettokind.title, isnull('Titolo: ' + progettokind.title + '; ','') as dropdown_title FROM progettokind WITH (NOLOCK)  LEFT OUTER JOIN progettoactivitykind WITH (NOLOCK) ON progettokind.idprogettoactivitykind = progettoactivitykind.idprogettoactivitykind WHERE  progettokind.idprogettokind IS NOT NULL 
GO

-- VERIFICA DI progettokindsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettokindsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettokindsegview','nvarchar(2058)','ASSISTENZA','dropdown_title','2058','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettokindsegview','int','ASSISTENZA','idprogettokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','nvarchar(2048)','ASSISTENZA','progettoactivitykind_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','datetime','ASSISTENZA','progettokind_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','varchar(64)','ASSISTENZA','progettokind_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','nvarchar(max)','ASSISTENZA','progettokind_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','int','ASSISTENZA','progettokind_idprogettoactivitykind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','datetime','ASSISTENZA','progettokind_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','varchar(64)','ASSISTENZA','progettokind_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','int','ASSISTENZA','progettokind_oredivisionecostostipendio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettokindsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettokindsegview')
UPDATE customobject set isreal = 'N' where objectname = 'progettokindsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettokindsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA progettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettosegview]
GO

CREATE VIEW [dbo].[progettosegview] AS SELECT  progetto.budget AS progetto_budget, progetto.budgetcalcolato AS progetto_budgetcalcolato, progetto.budgetcalcolatodate AS progetto_budgetcalcolatodate, progetto.capofilatxt AS progetto_capofilatxt, progetto.codiceidentificativo AS progetto_codiceidentificativo, progetto.contributo AS progetto_contributo, progetto.contributoente AS progetto_contributoente, progetto.ct AS progetto_ct, progetto.cu AS progetto_cu, progetto.cup AS progetto_cup, progetto.data AS progetto_data, progetto.description AS progetto_description, progetto.durata AS progetto_durata, progetto.finanziatoretxt AS progetto_finanziatoretxt, corsostudio.title AS corsostudio_title, corsostudio.annoistituz AS corsostudio_annoistituz, progetto.idcorsostudio, currency.codecurrency AS currency_codecurrency, progetto.idcurrency, duratakind.title AS duratakind_title, progetto.idduratakind AS progetto_idduratakind, progetto.idprogetto, progettokind.title AS progettokind_title, progetto.idprogettokind AS progetto_idprogettokind, progettostatuskind.title AS progettostatuskind_title, progetto.idprogettostatuskind AS progetto_idprogettostatuskind, registry.title AS registry_title, progetto.idreg, registry_registry_aziendeaziende.title AS registryaziende_title, progetto.idreg_aziende, registry_registry_aziendeaziende_fin.title AS registryaziende_fin_title, progetto.idreg_aziende_fin, registryprogfin.title AS registryprogfin_title, registryprogfin.code AS registryprogfin_code, progetto.idregistryprogfin AS progetto_idregistryprogfin, registryprogfinbando.title AS registryprogfinbando_title, registryprogfinbando.number AS registryprogfinbando_number, registryprogfinbando.scadenza AS registryprogfinbando_scadenza, progetto.idregistryprogfinbando AS progetto_idregistryprogfinbando, progetto.lt AS progetto_lt, progetto.lu AS progetto_lu, progetto.start AS progetto_start, progetto.stop AS progetto_stop, progetto.title AS progetto_title, progetto.titolobreve, progetto.totalbudget AS progetto_totalbudget, progetto.totalcontributo AS progetto_totalcontributo, progetto.url AS progetto_url, isnull('Titolo breve o acronimo: ' + progetto.titolobreve + '; ','') as dropdown_title FROM progetto WITH (NOLOCK)  LEFT OUTER JOIN corsostudio WITH (NOLOCK) ON progetto.idcorsostudio = corsostudio.idcorsostudio LEFT OUTER JOIN currency WITH (NOLOCK) ON progetto.idcurrency = currency.idcurrency LEFT OUTER JOIN duratakind WITH (NOLOCK) ON progetto.idduratakind = duratakind.idduratakind LEFT OUTER JOIN progettokind WITH (NOLOCK) ON progetto.idprogettokind = progettokind.idprogettokind LEFT OUTER JOIN progettostatuskind WITH (NOLOCK) ON progetto.idprogettostatuskind = progettostatuskind.idprogettostatuskind LEFT OUTER JOIN registry WITH (NOLOCK) ON progetto.idreg = registry.idreg LEFT OUTER JOIN registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON progetto.idreg_aziende = registry_aziendeaziende.idreg LEFT OUTER JOIN registry AS registry_registry_aziendeaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registry_registry_aziendeaziende.idreg LEFT OUTER JOIN registry_aziende AS registry_aziendeaziende_fin WITH (NOLOCK) ON progetto.idreg_aziende_fin = registry_aziendeaziende_fin.idreg LEFT OUTER JOIN registry AS registry_registry_aziendeaziende_fin WITH (NOLOCK) ON registry_aziendeaziende_fin.idreg = registry_registry_aziendeaziende_fin.idreg LEFT OUTER JOIN registryprogfin WITH (NOLOCK) ON progetto.idregistryprogfin = registryprogfin.idregistryprogfin LEFT OUTER JOIN registryprogfinbando WITH (NOLOCK) ON progetto.idregistryprogfinbando = registryprogfinbando.idregistryprogfinbando WHERE  progetto.idprogetto IS NOT NULL 
GO

-- VERIFICA DI progettosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','corsostudio_annoistituz','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(20)','','currency_codecurrency','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','nvarchar(2075)','ASSISTENZA','dropdown_title','2075','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(50)','ASSISTENZA','duratakind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','','idcurrency','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idreg_aziende','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idreg_aziende_fin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_budget','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_budgetcalcolato','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','datetime','ASSISTENZA','progetto_budgetcalcolatodate','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','progetto_capofilatxt','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(2048)','','progetto_codiceidentificativo','2048','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_contributo','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_contributoente','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','datetime','ASSISTENZA','progetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','varchar(64)','ASSISTENZA','progetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(15)','ASSISTENZA','progetto_cup','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','progetto_data','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(max)','ASSISTENZA','progetto_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_durata','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','progetto_finanziatoretxt','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idduratakind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idprogettokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idprogettostatuskind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idregistryprogfin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idregistryprogfinbando','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','datetime','ASSISTENZA','progetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','varchar(64)','ASSISTENZA','progetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','progetto_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','progetto_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(4000)','ASSISTENZA','progetto_title','4000','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_totalbudget','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','','progetto_totalcontributo','9','N','decimal','System.Decimal','','2','','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(1024)','','progetto_url','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','progettokind_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(50)','ASSISTENZA','progettostatuskind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(101)','ASSISTENZA','registryaziende_fin_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(101)','ASSISTENZA','registryaziende_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfin_code','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfin_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfinbando_number','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','registryprogfinbando_scadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfinbando_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','titolobreve','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettosegview')
UPDATE customobject set isreal = 'N' where objectname = 'progettosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA publicazdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[publicazdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[publicazdefaultview]
GO

CREATE VIEW [dbo].[publicazdefaultview] AS SELECT  publicaz.abstractstring AS publicaz_abstractstring, publicaz.annocopyright AS publicaz_annocopyright, publicaz.annopub AS publicaz_annopub, publicaz.ct AS publicaz_ct, publicaz.cu AS publicaz_cu, publicaz.editore AS publicaz_editore, publicaz.fascicolo AS publicaz_fascicolo, geo_city.title AS geo_city_title, publicaz.idcity, geo_cityed.title AS geo_cityed_title, publicaz.idcity_ed, geo_nationed.title AS geo_nationed_title, publicaz.idnation_ed, geo_nationlang.title AS geo_nationlang_title, publicaz.idnation_lang, progetto.titolobreve AS progetto_titolobreve, publicaz.idprogetto, publicaz.idpublicaz, publicaz.isbn AS publicaz_isbn, publicaz.lt AS publicaz_lt, publicaz.lu AS publicaz_lu, publicaz.numrivista AS publicaz_numrivista, publicaz.pagestart AS publicaz_pagestart, publicaz.pagestop AS publicaz_pagestop, publicaz.pagetot AS publicaz_pagetot, publicaz.title, publicaz.title2 AS publicaz_title2, publicaz.volume AS publicaz_volume, isnull('Titolo: ' + publicaz.title + '; ','') as dropdown_title FROM publicaz WITH (NOLOCK)  LEFT OUTER JOIN geo_city WITH (NOLOCK) ON publicaz.idcity = geo_city.idcity LEFT OUTER JOIN geo_city AS geo_cityed WITH (NOLOCK) ON publicaz.idcity_ed = geo_cityed.idcity LEFT OUTER JOIN geo_nation AS geo_nationed WITH (NOLOCK) ON publicaz.idnation_ed = geo_nationed.idnation LEFT OUTER JOIN geo_nation AS geo_nationlang WITH (NOLOCK) ON publicaz.idnation_lang = geo_nationlang.idnation LEFT OUTER JOIN progetto WITH (NOLOCK) ON publicaz.idprogetto = progetto.idprogetto WHERE  publicaz.idpublicaz IS NOT NULL 
GO

-- VERIFICA DI publicazdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'publicazdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdefaultview','varchar(522)','','dropdown_title','522','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','varchar(65)','','geo_city_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','varchar(65)','','geo_cityed_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','varchar(65)','','geo_nationed_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','varchar(65)','','geo_nationlang_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','idcity','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','idcity_ed','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','idnation_ed','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','idnation_lang','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','idprogetto','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdefaultview','int','','idpublicaz','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','nvarchar(2048)','','progetto_titolobreve','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','nvarchar(max)','','publicaz_abstractstring','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','publicaz_annocopyright','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','publicaz_annopub','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdefaultview','datetime','','publicaz_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdefaultview','varchar(64)','','publicaz_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','varchar(150)','','publicaz_editore','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','varchar(150)','','publicaz_fascicolo','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','varchar(50)','','publicaz_isbn','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdefaultview','datetime','','publicaz_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdefaultview','varchar(64)','','publicaz_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','publicaz_numrivista','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','publicaz_pagestart','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','publicaz_pagestop','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','int','','publicaz_pagetot','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','nvarchar(512)','','publicaz_title2','512','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','varchar(150)','','publicaz_volume','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdefaultview','varchar(512)','','title','512','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI publicazdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'publicazdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'publicazdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('publicazdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA publicazdocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[publicazdocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[publicazdocentiview]
GO

CREATE VIEW [dbo].[publicazdocentiview] AS SELECT  publicaz.abstractstring AS publicaz_abstractstring, publicaz.annocopyright AS publicaz_annocopyright, publicaz.annopub AS publicaz_annopub, publicaz.ct AS publicaz_ct, publicaz.cu AS publicaz_cu, publicaz.editore AS publicaz_editore, publicaz.fascicolo AS publicaz_fascicolo, geo_city.title AS geo_city_title, publicaz.idcity, geo_cityed.title AS geo_cityed_title, publicaz.idcity_ed, geo_nationed.title AS geo_nationed_title, publicaz.idnation_ed, geo_nationlang.title AS geo_nationlang_title, publicaz.idnation_lang, progetto.titolobreve AS progetto_titolobreve, publicaz.idprogetto, publicaz.idpublicaz, publicaz.isbn AS publicaz_isbn, publicaz.lt AS publicaz_lt, publicaz.lu AS publicaz_lu, publicaz.numrivista AS publicaz_numrivista, publicaz.pagestart AS publicaz_pagestart, publicaz.pagestop AS publicaz_pagestop, publicaz.pagetot AS publicaz_pagetot, publicaz.title, publicaz.title2 AS publicaz_title2, publicaz.volume AS publicaz_volume, isnull('Titolo: ' + publicaz.title + '; ','') as dropdown_title FROM publicaz WITH (NOLOCK)  LEFT OUTER JOIN geo_city WITH (NOLOCK) ON publicaz.idcity = geo_city.idcity LEFT OUTER JOIN geo_city AS geo_cityed WITH (NOLOCK) ON publicaz.idcity_ed = geo_cityed.idcity LEFT OUTER JOIN geo_nation AS geo_nationed WITH (NOLOCK) ON publicaz.idnation_ed = geo_nationed.idnation LEFT OUTER JOIN geo_nation AS geo_nationlang WITH (NOLOCK) ON publicaz.idnation_lang = geo_nationlang.idnation LEFT OUTER JOIN progetto WITH (NOLOCK) ON publicaz.idprogetto = progetto.idprogetto WHERE  publicaz.idpublicaz IS NOT NULL 
GO

-- VERIFICA DI publicazdocentiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'publicazdocentiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdocentiview','varchar(522)','','dropdown_title','522','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','varchar(65)','','geo_city_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','varchar(65)','','geo_cityed_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','varchar(65)','','geo_nationed_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','varchar(65)','','geo_nationlang_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','idcity','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','idcity_ed','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','idnation_ed','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','idnation_lang','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','idprogetto','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdocentiview','int','','idpublicaz','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','nvarchar(2048)','','progetto_titolobreve','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','nvarchar(max)','','publicaz_abstractstring','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','publicaz_annocopyright','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','publicaz_annopub','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdocentiview','datetime','','publicaz_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdocentiview','varchar(64)','','publicaz_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','varchar(150)','','publicaz_editore','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','varchar(150)','','publicaz_fascicolo','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','varchar(50)','','publicaz_isbn','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdocentiview','datetime','','publicaz_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazdocentiview','varchar(64)','','publicaz_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','publicaz_numrivista','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','publicaz_pagestart','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','publicaz_pagestop','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','int','','publicaz_pagetot','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','nvarchar(512)','','publicaz_title2','512','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','varchar(150)','','publicaz_volume','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazdocentiview','varchar(512)','','title','512','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI publicazdocentiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'publicazdocentiview')
UPDATE customobject set isreal = 'N' where objectname = 'publicazdocentiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('publicazdocentiview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA registryamministrativiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryamministrativiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryamministrativiview]
GO

CREATE VIEW [dbo].[registryamministrativiview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, category.description AS category_description, registry.idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, registryclass.description AS registryclass_description, registry.idregistryclass, registrykind.description AS registrykind_description, registry.idregistrykind AS registry_idregistrykind, title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title AS registry_title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_amministrativi.ct AS registry_amministrativi_ct, registry_amministrativi.cu AS registry_amministrativi_cu, registry_amministrativi.cv AS registry_amministrativi_cv, contrattokind.title AS contrattokind_title, registry_amministrativi.idcontrattokind AS registry_amministrativi_idcontrattokind, registry_amministrativi.idreg AS registry_amministrativi_idreg, registry_amministrativi.lt AS registry_amministrativi_lt, registry_amministrativi.lu AS registry_amministrativi_lu, isnull('Titolo: ' + title.description + '; ','') + ' ' + isnull('Cognome: ' + registry.surname + '; ','') + ' ' + isnull('Nome: ' + registry.forename + '; ','') + ' ' + isnull('Codice fiscale: ' + registry.cf + '; ','') as dropdown_title FROM registry WITH (NOLOCK)  INNER JOIN registry_amministrativi WITH (NOLOCK) ON registry.idreg = registry_amministrativi.idreg LEFT OUTER JOIN category WITH (NOLOCK) ON registry.idcategory = category.idcategory LEFT OUTER JOIN geo_city WITH (NOLOCK) ON registry.idcity = geo_city.idcity LEFT OUTER JOIN maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = maritalstatus.idmaritalstatus LEFT OUTER JOIN geo_nation WITH (NOLOCK) ON registry.idnation = geo_nation.idnation LEFT OUTER JOIN registryclass WITH (NOLOCK) ON registry.idregistryclass = registryclass.idregistryclass LEFT OUTER JOIN registrykind WITH (NOLOCK) ON registry.idregistrykind = registrykind.idregistrykind LEFT OUTER JOIN title WITH (NOLOCK) ON registry.idtitle = title.idtitle LEFT OUTER JOIN residence WITH (NOLOCK) ON registry.residence = residence.idresidence LEFT OUTER JOIN contrattokind WITH (NOLOCK) ON registry_amministrativi.idcontrattokind = contrattokind.idcontrattokind WHERE  registry.idreg IS NOT NULL  AND registry_amministrativi.idreg IS NOT NULL 
GO

-- VERIFICA DI registryamministrativiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryamministrativiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','category_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(216)','ASSISTENZA','dropdown_title','216','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(65)','ASSISTENZA','geo_city_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','idcategory','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','idregistryclass','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','idtitle','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','maritalstatus_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','datetime','ASSISTENZA','registry_amministrativi_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(64)','ASSISTENZA','registry_amministrativi_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','nvarchar(max)','ASSISTENZA','registry_amministrativi_cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_amministrativi_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','int','ASSISTENZA','registry_amministrativi_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','datetime','ASSISTENZA','registry_amministrativi_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(64)','ASSISTENZA','registry_amministrativi_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(400)','ASSISTENZA','registry_annotation','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_authorization_free','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_badgecode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','date','ASSISTENZA','registry_birthdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(12)','ASSISTENZA','registry_ccp','12','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(16)','ASSISTENZA','registry_cf','16','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','datetime','ASSISTENZA','registry_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(64)','ASSISTENZA','registry_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(200)','ASSISTENZA','registry_email_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(200)','ASSISTENZA','registry_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(40)','ASSISTENZA','registry_extmatricula','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_flag_pa','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_flagbankitaliaproceeds','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(40)','ASSISTENZA','registry_foreigncf','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_forename','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(7)','ASSISTENZA','registry_gender','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_idcentralizedcategory','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_idexternal','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_idmaritalstatus','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_idregistrykind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(7)','ASSISTENZA','registry_ipa_fe','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(100)','ASSISTENZA','registry_ipa_perlapa','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_location','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','datetime','ASSISTENZA','registry_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(64)','ASSISTENZA','registry_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_maritalsurname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_multi_cf','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(15)','ASSISTENZA','registry_p_iva','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(200)','ASSISTENZA','registry_pec_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','image','ASSISTENZA','registry_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_sdi_defrifamm','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_sdi_norifamm','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_surname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(101)','ASSISTENZA','registry_title','101','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_toredirect','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','text','ASSISTENZA','registry_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(150)','ASSISTENZA','registryclass_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registrykind_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','int','ASSISTENZA','residence','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(60)','ASSISTENZA','residence_description','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','title_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registryamministrativiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryamministrativiview')
UPDATE customobject set isreal = 'N' where objectname = 'registryamministrativiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryamministrativiview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA registrydocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydocentiview]
GO

CREATE VIEW [dbo].[registrydocentiview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, registryclass.description AS registryclass_description, registry.idregistryclass, registry.idregistrykind AS registry_idregistrykind, title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_docenti.ct AS registry_docenti_ct, registry_docenti.cu AS registry_docenti_cu, registry_docenti.cv AS registry_docenti_cv, classconsorsuale.title AS classconsorsuale_title, registry_docenti.idclassconsorsuale, contrattokind.title AS contrattokind_title, registry_docenti.idcontrattokind AS registry_docenti_idcontrattokind, fonteindicebibliometrico.title AS fonteindicebibliometrico_title, registry_docenti.idfonteindicebibliometrico AS registry_docenti_idfonteindicebibliometrico, registry_docenti.idreg AS registry_docenti_idreg, registry_registry_istitutiistituti.title AS registryistituti_title, registry_docenti.idreg_istituti, sasd.codice AS sasd_codice, sasd.title AS sasd_title, registry_docenti.idsasd, struttura.title AS struttura_title, strutturakind.title AS strutturakind_title, registry_docenti.idstruttura, registry_docenti.indicebibliometrico AS registry_docenti_indicebibliometrico, registry_docenti.lt AS registry_docenti_lt, registry_docenti.lu AS registry_docenti_lu, registry_docenti.matricola AS registry_docenti_matricola, registry_docenti.ricevimento AS registry_docenti_ricevimento, registry_docenti.soggiorno AS registry_docenti_soggiorno, isnull('Denominazione: ' + registry.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + strutturakind.title + '; ','') as dropdown_title FROM registry WITH (NOLOCK)  INNER JOIN registry_docenti WITH (NOLOCK) ON registry.idreg = registry_docenti.idreg LEFT OUTER JOIN geo_city WITH (NOLOCK) ON registry.idcity = geo_city.idcity LEFT OUTER JOIN maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = maritalstatus.idmaritalstatus LEFT OUTER JOIN geo_nation WITH (NOLOCK) ON registry.idnation = geo_nation.idnation LEFT OUTER JOIN registryclass WITH (NOLOCK) ON registry.idregistryclass = registryclass.idregistryclass LEFT OUTER JOIN title WITH (NOLOCK) ON registry.idtitle = title.idtitle LEFT OUTER JOIN residence WITH (NOLOCK) ON registry.residence = residence.idresidence LEFT OUTER JOIN classconsorsuale WITH (NOLOCK) ON registry_docenti.idclassconsorsuale = classconsorsuale.idclassconsorsuale LEFT OUTER JOIN contrattokind WITH (NOLOCK) ON registry_docenti.idcontrattokind = contrattokind.idcontrattokind LEFT OUTER JOIN fonteindicebibliometrico WITH (NOLOCK) ON registry_docenti.idfonteindicebibliometrico = fonteindicebibliometrico.idfonteindicebibliometrico LEFT OUTER JOIN registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON registry_docenti.idreg_istituti = registry_istitutiistituti.idreg LEFT OUTER JOIN registry AS registry_registry_istitutiistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registry_registry_istitutiistituti.idreg LEFT OUTER JOIN sasd WITH (NOLOCK) ON registry_docenti.idsasd = sasd.idsasd LEFT OUTER JOIN struttura WITH (NOLOCK) ON registry_docenti.idstruttura = struttura.idstruttura LEFT OUTER JOIN strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = strutturakind.idstrutturakind WHERE  registry.idreg IS NOT NULL  AND registry_docenti.idreg IS NOT NULL 
GO

-- VERIFICA DI registrydocentiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrydocentiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','classconsorsuale_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(192)','ASSISTENZA','dropdown_title','192','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','nvarchar(1024)','ASSISTENZA','fonteindicebibliometrico_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(65)','ASSISTENZA','geo_city_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idclassconsorsuale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idreg_istituti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','idregistryclass','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idsasd','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','idtitle','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','maritalstatus_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(400)','ASSISTENZA','registry_annotation','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_authorization_free','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_badgecode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','date','ASSISTENZA','registry_birthdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(12)','ASSISTENZA','registry_ccp','12','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(16)','ASSISTENZA','registry_cf','16','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_docenti_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_docenti_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','nvarchar(max)','ASSISTENZA','registry_docenti_cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_docenti_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_docenti_idfonteindicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','int','ASSISTENZA','registry_docenti_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_docenti_indicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_docenti_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_docenti_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_docenti_matricola','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','nvarchar(max)','ASSISTENZA','registry_docenti_ricevimento','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(255)','ASSISTENZA','registry_docenti_soggiorno','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(200)','ASSISTENZA','registry_email_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(200)','ASSISTENZA','registry_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(40)','ASSISTENZA','registry_extmatricula','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_flag_pa','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_flagbankitaliaproceeds','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(40)','ASSISTENZA','registry_foreigncf','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_forename','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(7)','ASSISTENZA','registry_gender','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_idcategory','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_idcentralizedcategory','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_idexternal','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_idmaritalstatus','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_idregistrykind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(7)','ASSISTENZA','registry_ipa_fe','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(100)','ASSISTENZA','registry_ipa_perlapa','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_location','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_maritalsurname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_multi_cf','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(15)','ASSISTENZA','registry_p_iva','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(200)','ASSISTENZA','registry_pec_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','image','ASSISTENZA','registry_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_sdi_defrifamm','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_sdi_norifamm','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_surname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_toredirect','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','text','ASSISTENZA','registry_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(150)','ASSISTENZA','registryclass_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(101)','ASSISTENZA','registryistituti_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','int','ASSISTENZA','residence','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(60)','ASSISTENZA','residence_description','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','sasd_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(255)','ASSISTENZA','sasd_title','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(1024)','ASSISTENZA','struttura_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(101)','ASSISTENZA','title','101','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','title_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registrydocentiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrydocentiview')
UPDATE customobject set isreal = 'N' where objectname = 'registrydocentiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrydocentiview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA rendicontattivitaprogettoanagammview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontattivitaprogettoanagammview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[rendicontattivitaprogettoanagammview]
GO

CREATE VIEW [dbo].[rendicontattivitaprogettoanagammview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, amministrazione.itineration.description AS itineration_description, amministrazione.itineration.location AS itineration_location, amministrazione.itineration.starttime AS itineration_starttime, amministrazione.itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage AS rendicontattivitaprogetto_idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN amministrazione.itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = amministrazione.itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettoanagammview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoanagammview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','varchar(150)','ASSISTENZA','itineration_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','varchar(65)','ASSISTENZA','itineration_location','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','itineration_starttime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','itineration_stoptime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','nvarchar(2048)','ASSISTENZA','progetto_titolobreve','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','rendicontattivitaprogetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','date','ASSISTENZA','rendicontattivitaprogetto_datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','varchar(max)','ASSISTENZA','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','rendicontattivitaprogetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','nvarchar(2048)','ASSISTENZA','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettoanagammview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoanagammview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoanagammview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoanagammview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA rendicontattivitaprogettoanagview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontattivitaprogettoanagview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[rendicontattivitaprogettoanagview]
GO

CREATE VIEW [dbo].[rendicontattivitaprogettoanagview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, amministrazione.itineration.description AS itineration_description, amministrazione.itineration.location AS itineration_location, amministrazione.itineration.starttime AS itineration_starttime, amministrazione.itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage AS rendicontattivitaprogetto_idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN amministrazione.itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = amministrazione.itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettoanagview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoanagview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','varchar(150)','ASSISTENZA','itineration_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','varchar(65)','ASSISTENZA','itineration_location','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','itineration_starttime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','itineration_stoptime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','nvarchar(2048)','ASSISTENZA','progetto_titolobreve','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','rendicontattivitaprogetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','date','ASSISTENZA','rendicontattivitaprogetto_datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','varchar(max)','ASSISTENZA','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','rendicontattivitaprogetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','nvarchar(2048)','ASSISTENZA','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettoanagview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoanagview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoanagview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoanagview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA workpackagesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[workpackagesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[workpackagesegview]
GO

CREATE VIEW [dbo].[workpackagesegview] AS SELECT  workpackage.acronimo AS workpackage_acronimo, workpackage.ct AS workpackage_ct, workpackage.cu AS workpackage_cu, workpackage.description AS workpackage_description, workpackage.idprogetto, struttura.title AS struttura_title, strutturakind.title AS strutturakind_title, workpackage.idstruttura, workpackage.idworkpackage, workpackage.lt AS workpackage_lt, workpackage.lu AS workpackage_lu, workpackage.raggruppamento, workpackage.title AS workpackage_title, isnull('Raggruppamento: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Titolo: ' + workpackage.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + strutturakind.title + '; ','') as dropdown_title FROM workpackage WITH (NOLOCK)  LEFT OUTER JOIN struttura WITH (NOLOCK) ON workpackage.idstruttura = struttura.idstruttura LEFT OUTER JOIN strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = strutturakind.idstrutturakind WHERE  workpackage.idprogetto IS NOT NULL  AND workpackage.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI workpackagesegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'workpackagesegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','nvarchar(4000)','ASSISTENZA','dropdown_title','4000','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','int','','idstruttura','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','varchar(1024)','','struttura_title','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','workpackage_acronimo','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','datetime','ASSISTENZA','workpackage_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','varchar(64)','ASSISTENZA','workpackage_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(max)','ASSISTENZA','workpackage_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','datetime','ASSISTENZA','workpackage_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','varchar(64)','ASSISTENZA','workpackage_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI workpackagesegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'workpackagesegview')
UPDATE customobject set isreal = 'N' where objectname = 'workpackagesegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('workpackagesegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA workpackage --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[workpackage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[workpackage] (
idworkpackage int NOT NULL,
idprogetto int NOT NULL,
acronimo nvarchar(2048) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description nvarchar(max) NULL,
idstruttura int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
raggruppamento nvarchar(2048) NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkworkpackage PRIMARY KEY (idworkpackage,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA workpackage --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'acronimo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD acronimo nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN acronimo nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'raggruppamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD raggruppamento nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN raggruppamento nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI workpackage IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'workpackage'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','int','assistenza','idworkpackage','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','acronimo','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(max)','assistenza','description','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','int','assistenza','idstruttura','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','raggruppamento','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','title','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI workpackage IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'workpackage')
UPDATE customobject set isreal = 'S' where objectname = 'workpackage'
ELSE
INSERT INTO customobject (objectname, isreal) values('workpackage', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'workpackage')
UPDATE [tabledescr] SET description = 'Workpackage',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:05:03.637'},lu = 'assistenza',title = 'Workpackage' WHERE tablename = 'workpackage'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('workpackage','Workpackage',null,'N',{ts '2020-05-20 14:05:03.637'},'assistenza','Workpackage')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'acronimo' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-02 18:25:10.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'acronimo' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('acronimo','workpackage','2048',null,null,null,'S',{ts '2020-11-02 18:25:10.753'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','workpackage','8',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','workpackage','64',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','workpackage','0',null,null,'Descrizione','S',{ts '2020-05-20 14:05:52.450'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','workpackage','4',null,null,'Progetto','S',{ts '2020-05-20 14:05:52.450'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dipartimento',kind = 'S',lt = {ts '2020-11-02 18:25:36.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','workpackage','4',null,null,'Dipartimento','S',{ts '2020-11-02 18:25:36.680'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Unit‡ previsionale di base (UPB)',kind = 'S',lt = {ts '2020-11-02 18:25:36.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idupb' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','workpackage','50',null,null,'Unit‡ previsionale di base (UPB)','S',{ts '2020-11-02 18:25:36.680'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','workpackage','4',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.637'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','workpackage','8',null,null,null,'S',{ts '2020-05-20 14:05:05.637'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.637'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','workpackage','64',null,null,null,'S',{ts '2020-05-20 14:05:05.637'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'raggruppamento' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-02 18:25:10.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'raggruppamento' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('raggruppamento','workpackage','2048',null,null,null,'S',{ts '2020-11-02 18:25:10.753'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','workpackage','2048',null,null,'Titolo','S',{ts '2020-05-20 14:05:52.450'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

