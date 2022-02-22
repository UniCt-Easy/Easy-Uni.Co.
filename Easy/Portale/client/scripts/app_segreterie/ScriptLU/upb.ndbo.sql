
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

