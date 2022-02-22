
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


-- CREAZIONE TABELLA flowchartuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartuser] (
idflowchart varchar(34) NOT NULL,
ndetail int NOT NULL,
idcustomuser varchar(50) NOT NULL,
all_sorkind01 char(1) NULL,
all_sorkind02 char(1) NULL,
all_sorkind03 char(1) NULL,
all_sorkind04 char(1) NULL,
all_sorkind05 char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flagdefault char(1) NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sorkind01_withchilds char(1) NULL,
sorkind02_withchilds char(1) NULL,
sorkind03_withchilds char(1) NULL,
sorkind04_withchilds char(1) NULL,
sorkind05_withchilds char(1) NULL,
start date NULL,
stop date NULL,
title varchar(150) NULL,
 CONSTRAINT xpkflowchartuser PRIMARY KEY (idflowchart,
ndetail,
idcustomuser
)
)
END
GO

-- VERIFICA STRUTTURA flowchartuser --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'idflowchart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD idflowchart varchar(34) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartuser') and col.name = 'idflowchart' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartuser] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'ndetail' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD ndetail int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartuser') and col.name = 'ndetail' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartuser] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'idcustomuser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD idcustomuser varchar(50) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartuser') and col.name = 'idcustomuser' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartuser] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'all_sorkind01' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD all_sorkind01 char(1) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN all_sorkind01 char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'all_sorkind02' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD all_sorkind02 char(1) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN all_sorkind02 char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'all_sorkind03' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD all_sorkind03 char(1) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN all_sorkind03 char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'all_sorkind04' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD all_sorkind04 char(1) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN all_sorkind04 char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'all_sorkind05' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD all_sorkind05 char(1) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN all_sorkind05 char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartuser') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartuser') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'flagdefault' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD flagdefault char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartuser') and col.name = 'flagdefault' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN flagdefault char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'idsor01' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD idsor01 int NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN idsor01 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'idsor02' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD idsor02 int NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN idsor02 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'idsor03' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD idsor03 int NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN idsor03 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'idsor04' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD idsor04 int NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN idsor04 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'idsor05' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD idsor05 int NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN idsor05 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartuser') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartuser') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'sorkind01_withchilds' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD sorkind01_withchilds char(1) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN sorkind01_withchilds char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'sorkind02_withchilds' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD sorkind02_withchilds char(1) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN sorkind02_withchilds char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'sorkind03_withchilds' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD sorkind03_withchilds char(1) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN sorkind03_withchilds char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'sorkind04_withchilds' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD sorkind04_withchilds char(1) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN sorkind04_withchilds char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'sorkind05_withchilds' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD sorkind05_withchilds char(1) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN sorkind05_withchilds char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD start date NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD stop date NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartuser' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartuser] ADD title varchar(150) NULL 
END
ELSE
	ALTER TABLE [flowchartuser] ALTER COLUMN title varchar(150) NULL
GO

-- VERIFICA DI flowchartuser IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'flowchartuser'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartuser','varchar(50)','sa','idcustomuser','50','S','varchar','System.String','','','''sa''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartuser','varchar(34)','sa','idflowchart','34','S','varchar','System.String','','','''sa''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartuser','int','sa','ndetail','4','S','int','System.Int32','','','''sa''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','char(1)','sa','all_sorkind01','1','N','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','char(1)','sa','all_sorkind02','1','N','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','char(1)','sa','all_sorkind03','1','N','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','char(1)','sa','all_sorkind04','1','N','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','char(1)','sa','all_sorkind05','1','N','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartuser','datetime','sa','ct','8','S','datetime','System.DateTime','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartuser','varchar(64)','sa','cu','64','S','varchar','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartuser','char(1)','sa','flagdefault','1','S','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','int','sa','idsor01','4','N','int','System.Int32','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','int','sa','idsor02','4','N','int','System.Int32','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','int','sa','idsor03','4','N','int','System.Int32','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','int','sa','idsor04','4','N','int','System.Int32','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','int','sa','idsor05','4','N','int','System.Int32','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartuser','datetime','sa','lt','8','S','datetime','System.DateTime','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartuser','varchar(64)','sa','lu','64','S','varchar','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','char(1)','sa','sorkind01_withchilds','1','N','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','char(1)','sa','sorkind02_withchilds','1','N','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','char(1)','sa','sorkind03_withchilds','1','N','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','char(1)','sa','sorkind04_withchilds','1','N','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','char(1)','sa','sorkind05_withchilds','1','N','char','System.String','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','date','sa','start','3','N','date','System.DateTime','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','date','sa','stop','3','N','date','System.DateTime','','','''sa''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartuser','varchar(150)','sa','title','150','N','varchar','System.String','','','''sa''','','N')
GO

-- VERIFICA DI flowchartuser IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'flowchartuser')
UPDATE customobject set isreal = 'S' where objectname = 'flowchartuser'
ELSE
INSERT INTO customobject (objectname, isreal) values('flowchartuser', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'flowchartuser')
UPDATE [tabledescr] SET description = 'Associazione Utente - Organigramma',idapplication = '1',isdbo = 'N',lt = {ts '1900-01-01 03:00:29.563'},lu = 'nino',title = 'Associazione Utente - Organigramma' WHERE tablename = 'flowchartuser'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('flowchartuser','Associazione Utente - Organigramma','1','N',{ts '1900-01-01 03:00:29.563'},'nino','Associazione Utente - Organigramma')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'all_sorkind01' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'veditutto(1)',kind = 'S',lt = {ts '1900-01-01 03:00:20.120'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'all_sorkind01' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('all_sorkind01','flowchartuser','1',null,null,'veditutto(1)','S',{ts '1900-01-01 03:00:20.120'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'all_sorkind02' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'veditutto(2)',kind = 'S',lt = {ts '1900-01-01 03:00:20.123'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'all_sorkind02' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('all_sorkind02','flowchartuser','1',null,null,'veditutto(2)','S',{ts '1900-01-01 03:00:20.123'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'all_sorkind03' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'veditutto(3)',kind = 'S',lt = {ts '1900-01-01 03:00:20.127'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'all_sorkind03' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('all_sorkind03','flowchartuser','1',null,null,'veditutto(3)','S',{ts '1900-01-01 03:00:20.127'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'all_sorkind04' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'veditutto(4)',kind = 'S',lt = {ts '1900-01-01 03:00:20.130'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'all_sorkind04' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('all_sorkind04','flowchartuser','1',null,null,'veditutto(4)','S',{ts '1900-01-01 03:00:20.130'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'all_sorkind05' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'veditutto(5)',kind = 'S',lt = {ts '1900-01-01 03:00:20.133'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'all_sorkind05' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('all_sorkind05','flowchartuser','1',null,null,'veditutto(5)','S',{ts '1900-01-01 03:00:20.133'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:47.237'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','flowchartuser','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:47.237'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.670'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','flowchartuser','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.670'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagdefault' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Ruolo di default per l''utente',kind = 'C',lt = {ts '2016-02-06 15:04:18.730'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagdefault' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagdefault','flowchartuser','1',null,null,'Ruolo di default per l''utente','C',{ts '2016-02-06 15:04:18.730'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcustomuser' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'ID Utente',kind = 'S',lt = {ts '1900-01-01 03:00:20.140'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idcustomuser' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcustomuser','flowchartuser','50',null,null,'ID Utente','S',{ts '1900-01-01 03:00:20.140'},'nino','S','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idflowchart' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '34',col_precision = null,col_scale = null,description = 'Id della voce di organigramma (tabella flowchart)',kind = 'S',lt = {ts '1900-01-01 03:00:14.813'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(34)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idflowchart' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idflowchart','flowchartuser','34',null,null,'Id della voce di organigramma (tabella flowchart)','S',{ts '1900-01-01 03:00:14.813'},'nino','S','varchar(34)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor01' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 1(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:23.300'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor01' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor01','flowchartuser','4',null,null,'id voce class.sicurezza 1(tabella sorting)','S',{ts '1900-01-01 02:59:23.300'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor02' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 2(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:23.897'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor02' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor02','flowchartuser','4',null,null,'id voce class.sicurezza 2(tabella sorting)','S',{ts '1900-01-01 02:59:23.897'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor03' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 3(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:24.497'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor03' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor03','flowchartuser','4',null,null,'id voce class.sicurezza 3(tabella sorting)','S',{ts '1900-01-01 02:59:24.497'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor04' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 4(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:25.097'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor04' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor04','flowchartuser','4',null,null,'id voce class.sicurezza 4(tabella sorting)','S',{ts '1900-01-01 02:59:25.097'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor05' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 5(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:25.697'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor05' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor05','flowchartuser','4',null,null,'id voce class.sicurezza 5(tabella sorting)','S',{ts '1900-01-01 02:59:25.697'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.833'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','flowchartuser','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.833'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.867'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','flowchartuser','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.867'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ndetail' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'N. dettaglio',kind = 'S',lt = {ts '1900-01-01 03:00:27.510'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ndetail' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ndetail','flowchartuser','4',null,null,'N. dettaglio','S',{ts '1900-01-01 03:00:27.510'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sorkind01_withchilds' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'sottostanti(1)',kind = 'S',lt = {ts '1900-01-01 03:00:20.143'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'sorkind01_withchilds' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sorkind01_withchilds','flowchartuser','1',null,null,'sottostanti(1)','S',{ts '1900-01-01 03:00:20.143'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sorkind02_withchilds' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'sottostanti(2)',kind = 'S',lt = {ts '1900-01-01 03:00:20.147'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'sorkind02_withchilds' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sorkind02_withchilds','flowchartuser','1',null,null,'sottostanti(2)','S',{ts '1900-01-01 03:00:20.147'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sorkind03_withchilds' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'sottostanti(31)',kind = 'S',lt = {ts '1900-01-01 03:00:20.150'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'sorkind03_withchilds' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sorkind03_withchilds','flowchartuser','1',null,null,'sottostanti(31)','S',{ts '1900-01-01 03:00:20.150'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sorkind04_withchilds' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'sottostanti(4)',kind = 'S',lt = {ts '1900-01-01 03:00:20.153'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'sorkind04_withchilds' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sorkind04_withchilds','flowchartuser','1',null,null,'sottostanti(4)','S',{ts '1900-01-01 03:00:20.153'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sorkind05_withchilds' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'sottostanti(5)',kind = 'S',lt = {ts '1900-01-01 03:00:20.157'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'sorkind05_withchilds' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sorkind05_withchilds','flowchartuser','1',null,null,'sottostanti(5)','S',{ts '1900-01-01 03:00:20.157'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data inizio',kind = 'S',lt = {ts '1900-01-01 02:59:54.047'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','flowchartuser','8',null,null,'data inizio','S',{ts '1900-01-01 02:59:54.047'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data fine',kind = 'S',lt = {ts '1900-01-01 02:59:54.573'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','flowchartuser','8',null,null,'data fine','S',{ts '1900-01-01 02:59:54.573'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'flowchartuser')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '1900-01-01 03:00:00.053'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'flowchartuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','flowchartuser','150',null,null,'Denominazione','S',{ts '1900-01-01 03:00:00.053'},'nino','N','varchar(150)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagdefault' AND tablename = 'flowchartuser' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-06 15:04:18.730'},lu = 'Nino',title = 'Non è ruolo di default per l''utente' WHERE colname = 'flagdefault' AND tablename = 'flowchartuser' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagdefault','flowchartuser','N',null,{ts '2016-02-06 15:04:18.730'},'Nino','Non è ruolo di default per l''utente')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagdefault' AND tablename = 'flowchartuser' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-06 15:04:18.730'},lu = 'Nino',title = 'Ruolo di default per l''utente' WHERE colname = 'flagdefault' AND tablename = 'flowchartuser' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagdefault','flowchartuser','S',null,{ts '2016-02-06 15:04:18.730'},'Nino','Ruolo di default per l''utente')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '426')
UPDATE [relation] SET childtable = 'flowchartuser',description = 'ID Utente',lt = {ts '2017-05-20 09:19:46.013'},lu = 'lu',parenttable = 'customuser',title = 'Associazione Utente - Organigramma' WHERE idrelation = '426'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('426','flowchartuser','ID Utente',{ts '2017-05-20 09:19:46.013'},'lu','customuser','Associazione Utente - Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '816')
UPDATE [relation] SET childtable = 'flowchartuser',description = 'Id della voce di organigramma (tabella flowchart)',lt = {ts '2017-05-20 09:19:50.833'},lu = 'lu',parenttable = 'flowchart',title = 'Associazione Utente - Organigramma' WHERE idrelation = '816'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('816','flowchartuser','Id della voce di organigramma (tabella flowchart)',{ts '2017-05-20 09:19:50.833'},'lu','flowchart','Associazione Utente - Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2325')
UPDATE [relation] SET childtable = 'flowchartuser',description = 'id voce class.sicurezza 1(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Associazione Utente - Organigramma' WHERE idrelation = '2325'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2325','flowchartuser','id voce class.sicurezza 1(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Associazione Utente - Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2326')
UPDATE [relation] SET childtable = 'flowchartuser',description = 'id voce class.sicurezza 2(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Associazione Utente - Organigramma' WHERE idrelation = '2326'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2326','flowchartuser','id voce class.sicurezza 2(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Associazione Utente - Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2327')
UPDATE [relation] SET childtable = 'flowchartuser',description = 'id voce class.sicurezza 3(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Associazione Utente - Organigramma' WHERE idrelation = '2327'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2327','flowchartuser','id voce class.sicurezza 3(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Associazione Utente - Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2328')
UPDATE [relation] SET childtable = 'flowchartuser',description = 'id voce class.sicurezza 4(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Associazione Utente - Organigramma' WHERE idrelation = '2328'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2328','flowchartuser','id voce class.sicurezza 4(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Associazione Utente - Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2329')
UPDATE [relation] SET childtable = 'flowchartuser',description = 'id voce class.sicurezza 5(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Associazione Utente - Organigramma' WHERE idrelation = '2329'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2329','flowchartuser','id voce class.sicurezza 5(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Associazione Utente - Organigramma')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '426' AND parentcol = 'idcustomuser')
UPDATE [relationcol] SET childcol = 'idcustomuser',lt = {ts '2017-05-20 09:19:46.080'},lu = 'lu' WHERE idrelation = '426' AND parentcol = 'idcustomuser'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('426','idcustomuser','idcustomuser',{ts '2017-05-20 09:19:46.080'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

