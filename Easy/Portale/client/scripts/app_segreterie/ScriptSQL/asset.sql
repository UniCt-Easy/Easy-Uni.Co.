
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
Indica la percentuale di ammortamento da applicare sul cespite, se valorizzata, l''ammortamento sarà calcolato sulla base di questa aliquota e NON sarà considerata quella configurata nella classificazione inventariale.',kind = 'S',lt = {ts '2016-10-06 14:04:32.050'},lu = 'nino',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'amortizationquota' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('amortizationquota','asset','8','0','0','Percentuale ammortamento
Indica la percentuale di ammortamento da applicare sul cespite, se valorizzata, l''ammortamento sarà calcolato sulla base di questa aliquota e NON sarà considerata quella configurata nella classificazione inventariale.','S',{ts '2016-10-06 14:04:32.050'},'nino','N','float','float','System.Double')
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
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'Data inizio esistenza. Nel caso di cespiti provenienti da altri dipartimenti questa viene preservata nel travaso. E'''' la data usata per stabilire l''''età di un cespite ai fini degli ammortamenti.',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lifestart' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lifestart','asset','8','0','0','Data inizio esistenza. Nel caso di cespiti provenienti da altri dipartimenti questa viene preservata nel travaso. E'''' la data usata per stabilire l''''età di un cespite ai fini degli ammortamenti.','S',{ts '2017-05-19 07:56:58.147'},'nino','N','datetime','datetime','System.DateTime')
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
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'Trasmesso (non più usato)',kind = 'S',lt = {ts '2017-05-19 07:56:58.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'transmitted' AND tablename = 'asset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('transmitted','asset','1','0','0','Trasmesso (non più usato)','S',{ts '2017-05-19 07:56:58.147'},'nino','N','char(1)','char','System.String')
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

