
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


-- CREAZIONE TABELLA expense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expense] (
idexp int NOT NULL,
adate date NOT NULL,
autocode int NULL,
autokind tinyint NULL,
cigcode varchar(10) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cupcode varchar(15) NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate date NULL,
expiration date NULL,
external_reference varchar(200) NULL,
flag int NULL,
idclawback int NULL,
idformerexpense int NULL,
idinc_linked int NULL,
idman int NULL,
idpayment int NULL,
idreg int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nmov int NOT NULL,
nphase tinyint NOT NULL,
parentidexp int NULL,
rtf image NULL,
txt text NULL,
ymov smallint NOT NULL,
 CONSTRAINT xpkexpense PRIMARY KEY (idexp
)
)
END
GO

-- VERIFICA STRUTTURA expense --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idexp int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'idexp' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'adate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD adate date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'adate' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN adate date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'autocode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD autocode int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN autocode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'autokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD autokind tinyint NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN autokind tinyint NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'cigcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD cigcode varchar(10) NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN cigcode varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'cupcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD cupcode varchar(15) NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN cupcode varchar(15) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD description varchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN description varchar(150) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'doc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD doc varchar(35) NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN doc varchar(35) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'docdate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD docdate date NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN docdate date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'expiration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD expiration date NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN expiration date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'external_reference' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD external_reference varchar(200) NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN external_reference varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD flag int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN flag int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idclawback int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idclawback int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idformerexpense' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idformerexpense int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idformerexpense int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idinc_linked' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idinc_linked int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idinc_linked int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idman int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idpayment' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idpayment int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idpayment int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'nmov' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD nmov int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'nmov' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN nmov int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD nphase tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'nphase' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN nphase tinyint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'parentidexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD parentidexp int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN parentidexp int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD txt text NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'ymov' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD ymov smallint NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'ymov' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN ymov smallint NOT NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='uq1expense' and id=object_id('expense'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq1expense
     ON expense (nphase, ymov, nmov )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq1expense
     ON expense (nphase, ymov, nmov )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi10expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi10expense
     ON expense (description, nphase )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi10expense
     ON expense (description, nphase )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi12expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi12expense
     ON expense (parentidexp )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi12expense
     ON expense (parentidexp )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi13expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi13expense
     ON expense (idinc_linked )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi13expense
     ON expense (idinc_linked )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expense
     ON expense (nphase )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expense
     ON expense (nphase )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expense
     ON expense (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expense
     ON expense (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3expense
     ON expense (idreg, doc, docdate )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3expense
     ON expense (idreg, doc, docdate )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4expense
     ON expense (idman )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4expense
     ON expense (idman )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi8expense
     ON expense (idpayment )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi8expense
     ON expense (idpayment )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi9expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi9expense
     ON expense (idformerexpense )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi9expense
     ON expense (idformerexpense )
ON [PRIMARY]
END
GO

