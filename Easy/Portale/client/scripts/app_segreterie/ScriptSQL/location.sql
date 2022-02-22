
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


-- CREAZIONE TABELLA location --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[location]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [location] (
idlocation int NOT NULL,
active char(1) NULL,
address varchar(100) NULL,
annotations varchar(400) NULL,
cap varchar(20) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
extension varchar(200) NULL,
idcity int NULL,
idman int NULL,
idnation int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
latitude float NULL,
location varchar(20) NULL,
locationcode varchar(50) NOT NULL,
longitude float NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
newlocationcode varchar(50) NULL,
nlevel tinyint NOT NULL,
paridlocation int NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpklocation PRIMARY KEY (idlocation
)
)
END
GO

-- VERIFICA STRUTTURA location --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idlocation int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('location') and col.name = 'idlocation' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [location] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'address' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD address varchar(100) NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN address varchar(100) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'annotations' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD annotations varchar(400) NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN annotations varchar(400) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'cap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD cap varchar(20) NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN cap varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('location') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [location] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [location] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('location') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [location] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [location] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD description varchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('location') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [location] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [location] ALTER COLUMN description varchar(150) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'extension' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD extension varchar(200) NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN extension varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idcity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idcity int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN idcity int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idman int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN idman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idnation int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN idnation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idsor01' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idsor01 int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN idsor01 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idsor02' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idsor02 int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN idsor02 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idsor03' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idsor03 int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN idsor03 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idsor04' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idsor04 int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN idsor04 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idsor05' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idsor05 int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN idsor05 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'latitude' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD latitude float NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN latitude float NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'location' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD location varchar(20) NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN location varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'locationcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD locationcode varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('location') and col.name = 'locationcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [location] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [location] ALTER COLUMN locationcode varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'longitude' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD longitude float NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN longitude float NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('location') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [location] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [location] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('location') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [location] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [location] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'newlocationcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD newlocationcode varchar(50) NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN newlocationcode varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD nlevel tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('location') and col.name = 'nlevel' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [location] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [location] ALTER COLUMN nlevel tinyint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'paridlocation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD paridlocation int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN paridlocation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD txt text NULL 
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_location' and id=object_id('location'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_location
     ON location (locationcode )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_location
     ON location (locationcode )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1location' and id=object_id('location'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1location
     ON location (paridlocation )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1location
     ON location (paridlocation )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2location' and id=object_id('location'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2location
     ON location (nlevel )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2location
     ON location (nlevel )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3location' and id=object_id('location'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3location
     ON location (idman )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3location
     ON location (idman )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA DI location IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'location'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','location','int','ASSISTENZA','idlocation','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','varchar(100)','ASSISTENZA','address','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','varchar(400)','ASSISTENZA','annotations','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','varchar(20)','ASSISTENZA','cap','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','location','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','location','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','location','varchar(150)','ASSISTENZA','description','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','varchar(200)','ASSISTENZA','extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','int','ASSISTENZA','idman','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','int','ASSISTENZA','idsor01','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','int','ASSISTENZA','idsor02','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','int','ASSISTENZA','idsor03','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','int','ASSISTENZA','idsor04','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','int','ASSISTENZA','idsor05','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','float','ASSISTENZA','latitude','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','varchar(20)','ASSISTENZA','location','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','location','varchar(50)','ASSISTENZA','locationcode','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','float','ASSISTENZA','longitude','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','location','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','location','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','varchar(50)','ASSISTENZA','newlocationcode','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','location','tinyint','ASSISTENZA','nlevel','1','S','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','int','ASSISTENZA','paridlocation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','image','ASSISTENZA','rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','location','text','ASSISTENZA','txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI location IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'location')
UPDATE customobject set isreal = 'S' where objectname = 'location'
ELSE
INSERT INTO customobject (objectname, isreal) values('location', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'location')
UPDATE [tabledescr] SET description = 'Piano delle Ubicazioni',idapplication = '1',isdbo = 'N',lt = {ts '1900-01-01 03:00:29.687'},lu = 'nino',title = 'Piano delle Ubicazioni' WHERE tablename = 'location'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('location','Piano delle Ubicazioni','1','N',{ts '1900-01-01 03:00:29.687'},'nino','Piano delle Ubicazioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'attivo',kind = 'S',lt = {ts '1900-01-01 02:59:57.277'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','location','1',null,null,'attivo','S',{ts '1900-01-01 02:59:57.277'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'address' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '100',col_precision = null,col_scale = null,description = 'Indirizzo',kind = 'S',lt = {ts '2019-04-30 10:54:49.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(100)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'address' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('address','location','100',null,null,'Indirizzo','S',{ts '2019-04-30 10:54:49.640'},'assistenza','N','varchar(100)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annotations' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '400',col_precision = null,col_scale = null,description = 'Note',kind = 'S',lt = {ts '2019-04-30 10:54:49.643'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(400)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'annotations' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annotations','location','400',null,null,'Note','S',{ts '2019-04-30 10:54:49.643'},'assistenza','N','varchar(400)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cap' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'CAP',kind = 'S',lt = {ts '2019-04-30 10:54:49.643'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cap' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cap','location','20',null,null,'CAP','S',{ts '2019-04-30 10:54:49.643'},'assistenza','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:47.567'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','location','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:47.567'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:45.000'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','location','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:45.000'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:51.247'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','location','150',null,null,'Descrizione','S',{ts '1900-01-01 02:59:51.247'},'nino','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'extension' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'Tabella che estende il record',kind = 'S',lt = {ts '2019-04-30 10:54:49.643'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'extension' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('extension','location','200',null,null,'Tabella che estende il record','S',{ts '2019-04-30 10:54:49.643'},'assistenza','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Comune',kind = 'S',lt = {ts '2019-04-30 10:54:49.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity','location','4',null,null,'Comune','S',{ts '2019-04-30 10:54:49.647'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlocation' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id ubicazione (tabella location)',kind = 'S',lt = {ts '1900-01-01 03:00:26.177'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlocation' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlocation','location','4',null,null,'id ubicazione (tabella location)','S',{ts '1900-01-01 03:00:26.177'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idman' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id responsabile (tabella manager)',kind = 'S',lt = {ts '1900-01-01 02:59:21.937'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idman' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idman','location','4',null,null,'id responsabile (tabella manager)','S',{ts '1900-01-01 02:59:21.937'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Nazione',kind = 'S',lt = {ts '2019-04-30 10:54:49.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','location','4',null,null,'Nazione','S',{ts '2019-04-30 10:54:49.647'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor01' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 1(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:23.410'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor01' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor01','location','4',null,null,'id voce class.sicurezza 1(tabella sorting)','S',{ts '1900-01-01 02:59:23.410'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor02' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 2(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:24.010'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor02' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor02','location','4',null,null,'id voce class.sicurezza 2(tabella sorting)','S',{ts '1900-01-01 02:59:24.010'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor03' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 3(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:24.607'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor03' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor03','location','4',null,null,'id voce class.sicurezza 3(tabella sorting)','S',{ts '1900-01-01 02:59:24.607'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor04' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 4(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:25.207'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor04' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor04','location','4',null,null,'id voce class.sicurezza 4(tabella sorting)','S',{ts '1900-01-01 02:59:25.207'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor05' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 5(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:25.807'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor05' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor05','location','4',null,null,'id voce class.sicurezza 5(tabella sorting)','S',{ts '1900-01-01 02:59:25.807'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'latitude' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Latitudine',kind = 'S',lt = {ts '2019-04-30 10:54:49.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'latitude' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('latitude','location','8',null,null,'Latitudine','S',{ts '2019-04-30 10:54:49.647'},'assistenza','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'location' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Localit?',kind = 'S',lt = {ts '2019-04-30 10:54:49.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'location' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('location','location','20',null,null,'Localit?','S',{ts '2019-04-30 10:54:49.647'},'assistenza','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'locationcode' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '1900-01-01 03:00:21.167'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'locationcode' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('locationcode','location','50',null,null,'Codice','S',{ts '1900-01-01 03:00:21.167'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'longitude' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Longitudine',kind = 'S',lt = {ts '2019-04-30 10:54:49.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'longitude' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('longitude','location','8',null,null,'Longitudine','S',{ts '2019-04-30 10:54:49.647'},'assistenza','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:42.290'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','location','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:42.290'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:39.323'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','location','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:39.323'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'newlocationcode' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'nuovo codice ubicazione (usato per migrazioni)',kind = 'S',lt = {ts '2016-10-07 20:16:42.163'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'newlocationcode' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('newlocationcode','location','50',null,null,'nuovo codice ubicazione (usato per migrazioni)','S',{ts '2016-10-07 20:16:42.163'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nlevel' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'N. livello',kind = 'S',lt = {ts '1900-01-01 02:59:21.577'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'nlevel' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nlevel','location','1',null,null,'N. livello','S',{ts '1900-01-01 02:59:21.577'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paridlocation' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'chiave parent Piano delle Ubicazioni (tabella location) ',kind = 'S',lt = {ts '1900-01-01 02:58:47.163'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'paridlocation' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paridlocation','location','4',null,null,'chiave parent Piano delle Ubicazioni (tabella location) ','S',{ts '1900-01-01 02:58:47.163'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'allegati',kind = 'S',lt = {ts '1900-01-01 02:59:58.490'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','location','16',null,null,'allegati','S',{ts '1900-01-01 02:59:58.490'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'location')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'note testuali',kind = 'S',lt = {ts '1900-01-01 02:59:58.173'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'location'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','location','16',null,null,'note testuali','S',{ts '1900-01-01 02:59:58.173'},'nino','N','text','text','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '1160')
UPDATE [relation] SET childtable = 'location',description = 'id responsabile (tabella manager)',lt = {ts '2017-05-20 09:19:59.413'},lu = 'lu',parenttable = 'manager',title = 'Piano delle Ubicazioni' WHERE idrelation = '1160'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1160','location','id responsabile (tabella manager)',{ts '2017-05-20 09:19:59.413'},'lu','manager','Piano delle Ubicazioni')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2378')
UPDATE [relation] SET childtable = 'location',description = 'id voce class.sicurezza 1(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Piano delle Ubicazioni' WHERE idrelation = '2378'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2378','location','id voce class.sicurezza 1(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Piano delle Ubicazioni')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2379')
UPDATE [relation] SET childtable = 'location',description = 'id voce class.sicurezza 2(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Piano delle Ubicazioni' WHERE idrelation = '2379'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2379','location','id voce class.sicurezza 2(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Piano delle Ubicazioni')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2380')
UPDATE [relation] SET childtable = 'location',description = 'id voce class.sicurezza 3(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Piano delle Ubicazioni' WHERE idrelation = '2380'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2380','location','id voce class.sicurezza 3(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Piano delle Ubicazioni')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2381')
UPDATE [relation] SET childtable = 'location',description = 'id voce class.sicurezza 4(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Piano delle Ubicazioni' WHERE idrelation = '2381'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2381','location','id voce class.sicurezza 4(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Piano delle Ubicazioni')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2382')
UPDATE [relation] SET childtable = 'location',description = 'id voce class.sicurezza 5(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Piano delle Ubicazioni' WHERE idrelation = '2382'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2382','location','id voce class.sicurezza 5(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Piano delle Ubicazioni')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2968')
UPDATE [relation] SET childtable = 'location',description = 'N. livello',lt = {ts '2017-05-20 14:40:37.920'},lu = 'lu',parenttable = 'locationlevel',title = 'Piano delle Ubicazioni' WHERE idrelation = '2968'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2968','location','N. livello',{ts '2017-05-20 14:40:37.920'},'lu','locationlevel','Piano delle Ubicazioni')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3078')
UPDATE [relation] SET childtable = 'location',description = 'chiave parent Piano delle Ubicazioni (tabella location) ',lt = {ts '2017-05-22 12:48:12.567'},lu = 'nino',parenttable = 'location',title = 'Piano delle Ubicazioni' WHERE idrelation = '3078'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3078','location','chiave parent Piano delle Ubicazioni (tabella location) ',{ts '2017-05-22 12:48:12.567'},'nino','location','Piano delle Ubicazioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '1160' AND parentcol = 'idman')
UPDATE [relationcol] SET childcol = 'idman',lt = {ts '2017-05-20 09:19:59.560'},lu = 'lu' WHERE idrelation = '1160' AND parentcol = 'idman'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('1160','idman','idman',{ts '2017-05-20 09:19:59.560'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

