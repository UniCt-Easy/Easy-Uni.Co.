
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


-- CREAZIONE TABELLA upb --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[upb]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [upb] (
idupb varchar(36) NOT NULL,
active char(1) NULL,
assured char(1) NULL,
cigcode varchar(10) NULL,
codeupb varchar(50) NOT NULL,
cofogmpcode varchar(10) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cupcode varchar(15) NULL,
expiration date NULL,
flag int NULL,
flagactivity smallint NULL,
flagkind tinyint NULL,
granted decimal(19,2) NULL,
idepupbkind int NULL,
idman int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idtreasurer int NULL,
idunderwriter int NULL,
idupb_capofila varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
newcodeupb varchar(50) NULL,
paridupb varchar(36) NULL,
previousappropriation decimal(19,2) NULL,
previousassessment decimal(19,2) NULL,
printingorder varchar(50) NOT NULL,
requested decimal(19,2) NULL,
ri_ra_quota decimal(19,6) NULL,
ri_rb_quota decimal(19,6) NULL,
ri_sa_quota decimal(19,6) NULL,
rtf image NULL,
start date NULL,
stop date NULL,
title varchar(150) NOT NULL,
txt text NULL,
uesiopecode varchar(10) NULL,
 CONSTRAINT xpkupb PRIMARY KEY (idupb
)
)
END
GO

-- VERIFICA STRUTTURA upb --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idupb varchar(36) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('upb') and col.name = 'idupb' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [upb] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'assured' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD assured char(1) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN assured char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'cigcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD cigcode varchar(10) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN cigcode varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'codeupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD codeupb varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('upb') and col.name = 'codeupb' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [upb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN codeupb varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'cofogmpcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD cofogmpcode varchar(10) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN cofogmpcode varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('upb') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [upb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('upb') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [upb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'cupcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD cupcode varchar(15) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN cupcode varchar(15) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'expiration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD expiration date NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN expiration date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD flag int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN flag int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'flagactivity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD flagactivity smallint NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN flagactivity smallint NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'flagkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD flagkind tinyint NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN flagkind tinyint NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'granted' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD granted decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN granted decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idepupbkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idepupbkind int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idepupbkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idman int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idsor01' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idsor01 int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idsor01 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idsor02' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idsor02 int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idsor02 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idsor03' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idsor03 int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idsor03 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idsor04' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idsor04 int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idsor04 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idsor05' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idsor05 int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idsor05 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idtreasurer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idtreasurer int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idtreasurer int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idunderwriter' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idunderwriter int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idunderwriter int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idupb_capofila' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idupb_capofila varchar(36) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idupb_capofila varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('upb') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [upb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('upb') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [upb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'newcodeupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD newcodeupb varchar(50) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN newcodeupb varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'paridupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD paridupb varchar(36) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN paridupb varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'previousappropriation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD previousappropriation decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN previousappropriation decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'previousassessment' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD previousassessment decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN previousassessment decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'printingorder' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD printingorder varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('upb') and col.name = 'printingorder' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [upb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN printingorder varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'requested' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD requested decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN requested decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'ri_ra_quota' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD ri_ra_quota decimal(19,6) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN ri_ra_quota decimal(19,6) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'ri_rb_quota' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD ri_rb_quota decimal(19,6) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN ri_rb_quota decimal(19,6) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'ri_sa_quota' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD ri_sa_quota decimal(19,6) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN ri_sa_quota decimal(19,6) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD start date NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD stop date NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD title varchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('upb') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [upb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN title varchar(150) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD txt text NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'uesiopecode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD uesiopecode varchar(10) NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN uesiopecode varchar(10) NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1upb' and id=object_id('upb'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1upb
     ON upb (paridupb )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1upb
     ON upb (paridupb )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2upb' and id=object_id('upb'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2upb
     ON upb (idsor01 )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2upb
     ON upb (idsor01 )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3upb' and id=object_id('upb'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3upb
     ON upb (idsor02 )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3upb
     ON upb (idsor02 )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4upb' and id=object_id('upb'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4upb
     ON upb (idsor03 )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4upb
     ON upb (idsor03 )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5upb' and id=object_id('upb'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5upb
     ON upb (idsor04 )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5upb
     ON upb (idsor04 )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6upb' and id=object_id('upb'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6upb
     ON upb (idsor05 )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6upb
     ON upb (idsor05 )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7upb' and id=object_id('upb'))
BEGIN
     CREATE NONCLUSTERED INDEX xi7upb
     ON upb (stop )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi7upb
     ON upb (stop )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8upb' and id=object_id('upb'))
BEGIN
     CREATE NONCLUSTERED INDEX xi8upb
     ON upb (idepupbkind )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi8upb
     ON upb (idepupbkind )
ON [PRIMARY]
END
GO

-- VERIFICA DI upb IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'upb'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upb','varchar(36)','ASSISTENZA','idupb','36','S','varchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','char(1)','ASSISTENZA','assured','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','varchar(10)','ASSISTENZA','cigcode','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upb','varchar(50)','ASSISTENZA','codeupb','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','varchar(10)','ASSISTENZA','cofogmpcode','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upb','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upb','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','varchar(15)','ASSISTENZA','cupcode','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','date','ASSISTENZA','expiration','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','int','ASSISTENZA','flag','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','smallint','ASSISTENZA','flagactivity','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','tinyint','ASSISTENZA','flagkind','1','N','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','decimal(19,2)','ASSISTENZA','granted','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','int','ASSISTENZA','idepupbkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','int','ASSISTENZA','idman','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','int','ASSISTENZA','idsor01','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','int','ASSISTENZA','idsor02','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','int','ASSISTENZA','idsor03','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','int','ASSISTENZA','idsor04','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','int','ASSISTENZA','idsor05','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','int','ASSISTENZA','idtreasurer','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','int','ASSISTENZA','idunderwriter','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','varchar(36)','ASSISTENZA','idupb_capofila','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upb','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upb','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','varchar(50)','ASSISTENZA','newcodeupb','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','varchar(36)','ASSISTENZA','paridupb','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','decimal(19,2)','ASSISTENZA','previousappropriation','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','decimal(19,2)','ASSISTENZA','previousassessment','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upb','varchar(50)','ASSISTENZA','printingorder','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','decimal(19,2)','ASSISTENZA','requested','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','decimal(19,6)','ASSISTENZA','ri_ra_quota','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','decimal(19,6)','ASSISTENZA','ri_rb_quota','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','decimal(19,6)','ASSISTENZA','ri_sa_quota','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','image','ASSISTENZA','rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','date','ASSISTENZA','start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','date','ASSISTENZA','stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upb','varchar(150)','ASSISTENZA','title','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','text','ASSISTENZA','txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upb','varchar(10)','ASSISTENZA','uesiopecode','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI upb IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'upb')
UPDATE customobject set isreal = 'S' where objectname = 'upb'
ELSE
INSERT INTO customobject (objectname, isreal) values('upb', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'upb')
UPDATE [tabledescr] SET description = 'U.P.B.',idapplication = '1',isdbo = 'N',lt = {ts '1900-01-01 03:00:29.117'},lu = 'nino',title = 'U.P.B.' WHERE tablename = 'upb'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('upb','U.P.B.','1','N',{ts '1900-01-01 03:00:29.117'},'nino','U.P.B.')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'Attivo',kind = 'S',lt = {ts '2020-11-04 19:03:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','upb','1','0','0','Attivo','S',{ts '2020-11-04 19:03:24.460'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assured' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'Finanziamento certo (Non gestire assegnazione crediti/incassi)',kind = 'C',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assured' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assured','upb','1','0','0','Finanziamento certo (Non gestire assegnazione crediti/incassi)','C',{ts '2016-11-21 14:04:04.650'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cigcode' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '10',col_precision = '0',col_scale = '0',description = 'Codice CIG, Codice identificativo di gara',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cigcode' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cigcode','upb','10','0','0','Codice CIG, Codice identificativo di gara','S',{ts '2016-11-21 14:04:04.650'},'nino','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codeupb' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '50',col_precision = '0',col_scale = '0',description = 'Codice',kind = 'S',lt = {ts '2020-11-04 19:03:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codeupb' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codeupb','upb','50','0','0','Codice','S',{ts '2020-11-04 19:03:24.460'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data creazione',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','upb','8','0','0','data creazione','S',{ts '2016-11-21 14:04:04.650'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '64',col_precision = '0',col_scale = '0',description = 'nome utente creazione',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','upb','64','0','0','nome utente creazione','S',{ts '2016-11-21 14:04:04.650'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cupcode' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '15',col_precision = '0',col_scale = '0',description = 'Codice CUP, Codice unico di progetto',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cupcode' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cupcode','upb','15','0','0','Codice CUP, Codice unico di progetto','S',{ts '2016-11-21 14:04:04.650'},'nino','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'expiration' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'scadenza',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'expiration' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('expiration','upb','8','0','0','scadenza','S',{ts '2016-11-21 14:04:04.650'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flag' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'flag vari',kind = 'B',lt = {ts '2016-11-21 14:05:17.787'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'flag' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flag','upb','4','0','0','flag vari','B',{ts '2016-11-21 14:05:17.787'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagactivity' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '2',col_precision = '0',col_scale = '0',description = 'Tipo attività',kind = 'C',lt = {ts '2020-11-04 18:01:20.387'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'flagactivity' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagactivity','upb','2','0','0','Tipo attività','C',{ts '2020-11-04 18:01:20.387'},'assistenza','N','smallint','smallint','System.Int16')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagkind' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'Funzione',kind = 'B',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'flagkind' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagkind','upb','1','0','0','Funzione','B',{ts '2016-11-21 14:04:04.650'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'granted' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Finanziamento concesso',kind = 'S',lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'granted' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('granted','upb','9','19','2','Finanziamento concesso','S',{ts '2016-02-03 09:14:40.863'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idepupbkind' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'ID Tipo UPB nell''economico patrimoniale (tabella epupbkind)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idepupbkind' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idepupbkind','upb','4','0','0','ID Tipo UPB nell''economico patrimoniale (tabella epupbkind)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idman' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id responsabile (tabella manager)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idman' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idman','upb','4','0','0','id responsabile (tabella manager)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor01' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id voce class.sicurezza 1(tabella sorting)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor01' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor01','upb','4','0','0','id voce class.sicurezza 1(tabella sorting)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor02' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id voce class.sicurezza 2(tabella sorting)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor02' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor02','upb','4','0','0','id voce class.sicurezza 2(tabella sorting)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor03' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id voce class.sicurezza 3(tabella sorting)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor03' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor03','upb','4','0','0','id voce class.sicurezza 3(tabella sorting)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor04' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id voce class.sicurezza 4(tabella sorting)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor04' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor04','upb','4','0','0','id voce class.sicurezza 4(tabella sorting)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor05' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id voce class.sicurezza 5(tabella sorting)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor05' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor05','upb','4','0','0','id voce class.sicurezza 5(tabella sorting)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtreasurer' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'Id cassiere (tabella treasurer)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtreasurer' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtreasurer','upb','4','0','0','Id cassiere (tabella treasurer)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idunderwriter' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'ID Ente finanziatore (tabella underwriter)',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idunderwriter' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idunderwriter','upb','4','0','0','ID Ente finanziatore (tabella underwriter)','S',{ts '2016-11-21 14:04:04.657'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '36',col_precision = '0',col_scale = '0',description = 'id voce upb (tabella upb)',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idupb' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','upb','36','0','0','id voce upb (tabella upb)','S',{ts '2016-11-21 14:04:04.657'},'nino','S','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data ultima modifica',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','upb','8','0','0','data ultima modifica','S',{ts '2016-11-21 14:04:04.657'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '64',col_precision = '0',col_scale = '0',description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','upb','64','0','0','nome ultimo utente modifica','S',{ts '2016-11-21 14:04:04.657'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'newcodeupb' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '50',col_precision = '0',col_scale = '0',description = 'Codice di consolidamento',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'newcodeupb' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('newcodeupb','upb','50','0','0','Codice di consolidamento','S',{ts '2016-11-21 14:04:04.657'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paridupb' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '36',col_precision = '0',col_scale = '0',description = 'chiave parent U.P.B. (tabella upb) ',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'paridupb' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paridupb','upb','36','0','0','chiave parent U.P.B. (tabella upb) ','S',{ts '2016-11-21 14:04:04.657'},'nino','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'previousappropriation' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Totale impegnato pregresso (previa informatizzazione)',kind = 'S',lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'previousappropriation' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('previousappropriation','upb','9','19','2','Totale impegnato pregresso (previa informatizzazione)','S',{ts '2016-02-03 09:14:40.863'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'previousassessment' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Totale accertato pregresso (previa informatizzazione)',kind = 'S',lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'previousassessment' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('previousassessment','upb','9','19','2','Totale accertato pregresso (previa informatizzazione)','S',{ts '2016-02-03 09:14:40.863'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'printingorder' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '50',col_precision = '0',col_scale = '0',description = 'Ordine di stampa',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'printingorder' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('printingorder','upb','50','0','0','Ordine di stampa','S',{ts '2016-11-21 14:04:04.657'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'requested' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Finanziamento richiesto',kind = 'S',lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'requested' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('requested','upb','9','19','2','Finanziamento richiesto','S',{ts '2016-02-03 09:14:40.863'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '16',col_precision = '0',col_scale = '0',description = 'allegati',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','upb','16','0','0','allegati','S',{ts '2016-11-21 14:04:04.657'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data inizio',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','upb','8','0','0','data inizio','S',{ts '2016-11-21 14:04:04.657'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data fine',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','upb','8','0','0','data fine','S',{ts '2016-11-21 14:04:04.657'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '150',col_precision = '0',col_scale = '0',description = 'Denominazione',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','upb','150','0','0','Denominazione','S',{ts '2016-11-21 14:04:04.657'},'nino','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '16',col_precision = '0',col_scale = '0',description = 'note testuali',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','upb','16','0','0','note testuali','S',{ts '2016-11-21 14:04:04.657'},'nino','N','text','text','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colbit --
IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '0' AND tablename = 'upb')
UPDATE [colbit] SET description = null,lt = {ts '2016-11-21 14:05:17.787'},lu = 'nino',title = 'EP bloccato per prima fase e variazioni' WHERE colname = 'flag' AND nbit = '0' AND tablename = 'upb'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','0','upb',null,{ts '2016-11-21 14:05:17.787'},'nino','EP bloccato per prima fase e variazioni')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '1' AND tablename = 'upb')
UPDATE [colbit] SET description = null,lt = {ts '2016-11-21 14:05:17.787'},lu = 'nino',title = 'Finanziario bloccato per prima fase e variazioni' WHERE colname = 'flag' AND nbit = '1' AND tablename = 'upb'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','1','upb',null,{ts '2016-11-21 14:05:17.787'},'nino','Finanziario bloccato per prima fase e variazioni')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flagkind' AND nbit = '0' AND tablename = 'upb')
UPDATE [colbit] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Didattica' WHERE colname = 'flagkind' AND nbit = '0' AND tablename = 'upb'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flagkind','0','upb',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Didattica')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flagkind' AND nbit = '1' AND tablename = 'upb')
UPDATE [colbit] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Ricerca' WHERE colname = 'flagkind' AND nbit = '1' AND tablename = 'upb'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flagkind','1','upb',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Ricerca')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flagkind' AND nbit = '2' AND tablename = 'upb')
UPDATE [colbit] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Usa contabilit? speciale negli impegni di budget' WHERE colname = 'flagkind' AND nbit = '2' AND tablename = 'upb'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flagkind','2','upb',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Usa contabilit? speciale negli impegni di budget')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'assured' AND tablename = 'upb' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Non si tratta di Finanziamento certo' WHERE colname = 'assured' AND tablename = 'upb' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('assured','upb','N',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Non si tratta di Finanziamento certo')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'assured' AND tablename = 'upb' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Finanziamento certo' WHERE colname = 'assured' AND tablename = 'upb' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('assured','upb','S',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Finanziamento certo')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '1')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Istituzionale' WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '1'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagactivity','upb','1',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Istituzionale')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '2')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Commerciale' WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '2'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagactivity','upb','2',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Commerciale')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '4')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Qualsiasi / Non specificata' WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '4'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagactivity','upb','4',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Qualsiasi / Non specificata')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '483')
UPDATE [relation] SET childtable = 'upb',description = 'ID Tipo UPB nell''economico patrimoniale (tabella epupbkind)',lt = {ts '2017-05-20 09:19:47.780'},lu = 'lu',parenttable = 'epupbkind',title = 'U.P.B.' WHERE idrelation = '483'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('483','upb','ID Tipo UPB nell''economico patrimoniale (tabella epupbkind)',{ts '2017-05-20 09:19:47.780'},'lu','epupbkind','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1172')
UPDATE [relation] SET childtable = 'upb',description = 'id responsabile (tabella manager)',lt = {ts '2017-05-20 09:19:59.413'},lu = 'lu',parenttable = 'manager',title = 'U.P.B.' WHERE idrelation = '1172'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1172','upb','id responsabile (tabella manager)',{ts '2017-05-20 09:19:59.413'},'lu','manager','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2531')
UPDATE [relation] SET childtable = 'upb',description = 'id voce class.sicurezza 1(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'U.P.B.' WHERE idrelation = '2531'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2531','upb','id voce class.sicurezza 1(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2532')
UPDATE [relation] SET childtable = 'upb',description = 'id voce class.sicurezza 2(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'U.P.B.' WHERE idrelation = '2532'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2532','upb','id voce class.sicurezza 2(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2533')
UPDATE [relation] SET childtable = 'upb',description = 'id voce class.sicurezza 3(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'U.P.B.' WHERE idrelation = '2533'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2533','upb','id voce class.sicurezza 3(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2534')
UPDATE [relation] SET childtable = 'upb',description = 'id voce class.sicurezza 4(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'U.P.B.' WHERE idrelation = '2534'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2534','upb','id voce class.sicurezza 4(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2535')
UPDATE [relation] SET childtable = 'upb',description = 'id voce class.sicurezza 5(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'U.P.B.' WHERE idrelation = '2535'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2535','upb','id voce class.sicurezza 5(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2734')
UPDATE [relation] SET childtable = 'upb',description = 'Id cassiere (tabella treasurer)',lt = {ts '2017-05-20 09:20:11.903'},lu = 'lu',parenttable = 'treasurer',title = 'U.P.B.' WHERE idrelation = '2734'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2734','upb','Id cassiere (tabella treasurer)',{ts '2017-05-20 09:20:11.903'},'lu','treasurer','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2736')
UPDATE [relation] SET childtable = 'upb',description = 'ID Ente finanziatore (tabella underwriter)',lt = {ts '2017-05-20 09:20:12.060'},lu = 'lu',parenttable = 'underwriter',title = 'U.P.B.' WHERE idrelation = '2736'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2736','upb','ID Ente finanziatore (tabella underwriter)',{ts '2017-05-20 09:20:12.060'},'lu','underwriter','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3090')
UPDATE [relation] SET childtable = 'upb',description = 'chiave parent U.P.B. (tabella upb) ',lt = {ts '2017-05-22 14:54:23.597'},lu = 'nino',parenttable = 'upb',title = 'U.P.B.' WHERE idrelation = '3090'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3090','upb','chiave parent U.P.B. (tabella upb) ',{ts '2017-05-22 14:54:23.597'},'nino','upb','U.P.B.')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '483' AND parentcol = 'idepupbkind')
UPDATE [relationcol] SET childcol = 'idepupbkind',lt = {ts '2017-05-20 09:19:47.847'},lu = 'lu' WHERE idrelation = '483' AND parentcol = 'idepupbkind'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('483','idepupbkind','idepupbkind',{ts '2017-05-20 09:19:47.847'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

