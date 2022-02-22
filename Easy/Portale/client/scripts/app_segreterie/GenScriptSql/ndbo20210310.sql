
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


-- CREAZIONE TABELLA assetdiary --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetdiary]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetdiary] (
idassetdiary int NOT NULL,
idworkpackage int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idasset int NOT NULL,
idpiece int NULL,
idprogetto int NOT NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
orepreventivate int NULL,
 CONSTRAINT xpkassetdiary PRIMARY KEY (idassetdiary,
idworkpackage
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
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

-- CREAZIONE TABELLA assetdiaryora --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetdiaryora]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetdiaryora] (
idassetdiaryora int NOT NULL,
idassetdiary int NOT NULL,
idworkpackage int NOT NULL,
amount decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idsal int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NULL,
stop datetime NULL,
 CONSTRAINT xpkassetdiaryora PRIMARY KEY (idassetdiaryora,
idassetdiary,
idworkpackage
)
)
END
GO

-- VERIFICA STRUTTURA assetdiaryora --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'idassetdiaryora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD idassetdiaryora int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'idassetdiaryora' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'idassetdiary' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD idassetdiary int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'idassetdiary' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'amount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD amount decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN amount decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'idsal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD idsal int NULL 
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN idsal int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD start datetime NULL 
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN start datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD stop datetime NULL 
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN stop datetime NULL
GO

-- CREAZIONE TABELLA progetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progetto] (
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
datacontabile date NULL,
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'datacontabile' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD datacontabile date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN datacontabile date NULL
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

-- CREAZIONE TABELLA progettobudget --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettobudget]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettobudget] (
idprogettobudget int NOT NULL,
idprogetto int NOT NULL,
budget decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idprogettotipocosto int NULL,
idworkpackage int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
 CONSTRAINT xpkprogettobudget PRIMARY KEY (idprogettobudget,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettobudget --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogettobudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogettobudget int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'idprogettobudget' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD budget decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN budget decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogettotipocosto int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN idprogettotipocosto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idworkpackage int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN idworkpackage int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN sortcode int NULL
GO

-- CREAZIONE TABELLA progettocosto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettocosto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettocosto] (
idprogettocosto int NOT NULL,
idprogetto int NOT NULL,
amount decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
doc varchar(35) NULL,
docdate date NULL,
idcontrattokind int NULL,
idexp int NULL,
idpettycash int NULL,
idprogettotipocosto int NULL,
idrelated varchar(50) NULL,
idrendicontattivitaprogetto int NULL,
idsal int NULL,
idworkpackage int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
noperation int NULL,
yoperation smallint NULL,
 CONSTRAINT xpkprogettocosto PRIMARY KEY (idprogettocosto,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettocosto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idprogettocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idprogettocosto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'idprogettocosto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'amount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD amount decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN amount decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'doc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD doc varchar(35) NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN doc varchar(35) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'docdate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD docdate date NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN docdate date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idexp int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idpettycash int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idprogettotipocosto int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idprogettotipocosto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idrelated' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idrelated varchar(50) NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idrelated varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idrendicontattivitaprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idrendicontattivitaprogetto int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idrendicontattivitaprogetto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idsal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idsal int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idsal int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idworkpackage int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idworkpackage int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'noperation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD noperation int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN noperation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'yoperation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD yoperation smallint NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN yoperation smallint NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1progettocosto' and id=object_id('progettocosto'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1progettocosto
     ON progettocosto (idexp, idrelated )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1progettocosto
     ON progettocosto (idexp, idrelated )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2progettocosto' and id=object_id('progettocosto'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2progettocosto
     ON progettocosto (idrelated, idpettycash, yoperation, noperation )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2progettocosto
     ON progettocosto (idrelated, idpettycash, yoperation, noperation )
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA rendicontattivitaprogetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [rendicontattivitaprogetto] (
idrendicontattivitaprogetto int NOT NULL,
idworkpackage int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datainizioprevista date NULL,
description varchar(max) NULL,
iditineration int NULL,
idprogetto int NOT NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
orepreventivate int NULL,
stop date NULL,
 CONSTRAINT xpkrendicontattivitaprogetto PRIMARY KEY (idrendicontattivitaprogetto,
idworkpackage
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD stop date NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN stop date NULL
GO

-- CREAZIONE TABELLA rendicontattivitaprogettoora --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoora]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [rendicontattivitaprogettoora] (
idrendicontattivitaprogettoora int NOT NULL,
idrendicontattivitaprogetto int NOT NULL,
idworkpackage int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data date NULL,
idsal int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ore int NULL,
 CONSTRAINT xpkrendicontattivitaprogettoora PRIMARY KEY (idrendicontattivitaprogettoora,
idrendicontattivitaprogetto,
idworkpackage
)
)
END
GO

-- VERIFICA STRUTTURA rendicontattivitaprogettoora --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idrendicontattivitaprogettoora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idrendicontattivitaprogettoora int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'idrendicontattivitaprogettoora' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idrendicontattivitaprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idrendicontattivitaprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'idrendicontattivitaprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD data date NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idsal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idsal int NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN idsal int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'ore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD ore int NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN ore int NULL
GO

-- CREAZIONE TABELLA sal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sal] (
idsal int NOT NULL,
idprogetto int NOT NULL,
budget decimal(16,2) NULL,
datablocco date NULL,
start date NULL,
stop date NULL,
 CONSTRAINT xpksal PRIMARY KEY (idsal,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA sal --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sal' and C.name = 'idsal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sal] ADD idsal int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sal') and col.name = 'idsal' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sal] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sal' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sal] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sal') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sal] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sal' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sal] ADD budget decimal(16,2) NULL 
END
ELSE
	ALTER TABLE [sal] ALTER COLUMN budget decimal(16,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sal' and C.name = 'datablocco' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sal] ADD datablocco date NULL 
END
ELSE
	ALTER TABLE [sal] ALTER COLUMN datablocco date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sal' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sal] ADD start date NULL 
END
ELSE
	ALTER TABLE [sal] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sal' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sal] ADD stop date NULL 
END
ELSE
	ALTER TABLE [sal] ALTER COLUMN stop date NULL
GO

-- CREAZIONE TABELLA salassetdiaryora --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[salassetdiaryora]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [salassetdiaryora] (
idprogetto int NOT NULL,
idsal int NOT NULL,
idassetdiaryora int NOT NULL,
ct datetime NOT NULL,
cu varchar(60) NOT NULL,
lt datetime NOT NULL,
lu varchar(60) NOT NULL,
 CONSTRAINT xpksalassetdiaryora PRIMARY KEY (idprogetto,
idsal,
idassetdiaryora
)
)
END
GO

-- VERIFICA STRUTTURA salassetdiaryora --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salassetdiaryora' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salassetdiaryora] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salassetdiaryora') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salassetdiaryora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salassetdiaryora' and C.name = 'idsal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salassetdiaryora] ADD idsal int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salassetdiaryora') and col.name = 'idsal' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salassetdiaryora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salassetdiaryora' and C.name = 'idassetdiaryora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salassetdiaryora] ADD idassetdiaryora int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salassetdiaryora') and col.name = 'idassetdiaryora' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salassetdiaryora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salassetdiaryora' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salassetdiaryora] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salassetdiaryora') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salassetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salassetdiaryora] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salassetdiaryora' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salassetdiaryora] ADD cu varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salassetdiaryora') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salassetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salassetdiaryora] ALTER COLUMN cu varchar(60) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salassetdiaryora' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salassetdiaryora] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salassetdiaryora') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salassetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salassetdiaryora] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salassetdiaryora' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salassetdiaryora] ADD lu varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salassetdiaryora') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salassetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salassetdiaryora] ALTER COLUMN lu varchar(60) NOT NULL
GO

-- CREAZIONE TABELLA salprogettocosto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[salprogettocosto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [salprogettocosto] (
idprogetto int NOT NULL,
idsal int NOT NULL,
idprogettocosto int NOT NULL,
ct datetime NOT NULL,
cu varchar(60) NOT NULL,
lt datetime NOT NULL,
lu varchar(60) NOT NULL,
 CONSTRAINT xpksalprogettocosto PRIMARY KEY (idprogetto,
idsal,
idprogettocosto
)
)
END
GO

-- VERIFICA STRUTTURA salprogettocosto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salprogettocosto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salprogettocosto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salprogettocosto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salprogettocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salprogettocosto' and C.name = 'idsal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salprogettocosto] ADD idsal int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salprogettocosto') and col.name = 'idsal' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salprogettocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salprogettocosto' and C.name = 'idprogettocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salprogettocosto] ADD idprogettocosto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salprogettocosto') and col.name = 'idprogettocosto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salprogettocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salprogettocosto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salprogettocosto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salprogettocosto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salprogettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salprogettocosto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salprogettocosto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salprogettocosto] ADD cu varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salprogettocosto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salprogettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salprogettocosto] ALTER COLUMN cu varchar(60) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salprogettocosto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salprogettocosto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salprogettocosto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salprogettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salprogettocosto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salprogettocosto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salprogettocosto] ADD lu varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salprogettocosto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salprogettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salprogettocosto] ALTER COLUMN lu varchar(60) NOT NULL
GO

-- CREAZIONE TABELLA salrendicontattivitaprogettoora --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[salrendicontattivitaprogettoora]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [salrendicontattivitaprogettoora] (
idprogetto int NOT NULL,
idsal int NOT NULL,
idrendicontattivitaprogettoora int NOT NULL,
ct datetime NOT NULL,
cu varchar(60) NOT NULL,
lt datetime NOT NULL,
lu varchar(60) NOT NULL,
 CONSTRAINT xpksalrendicontattivitaprogettoora PRIMARY KEY (idprogetto,
idsal,
idrendicontattivitaprogettoora
)
)
END
GO

-- VERIFICA STRUTTURA salrendicontattivitaprogettoora --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salrendicontattivitaprogettoora' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salrendicontattivitaprogettoora] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salrendicontattivitaprogettoora') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salrendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salrendicontattivitaprogettoora' and C.name = 'idsal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salrendicontattivitaprogettoora] ADD idsal int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salrendicontattivitaprogettoora') and col.name = 'idsal' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salrendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salrendicontattivitaprogettoora' and C.name = 'idrendicontattivitaprogettoora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salrendicontattivitaprogettoora] ADD idrendicontattivitaprogettoora int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salrendicontattivitaprogettoora') and col.name = 'idrendicontattivitaprogettoora' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salrendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salrendicontattivitaprogettoora' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salrendicontattivitaprogettoora] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salrendicontattivitaprogettoora') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salrendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salrendicontattivitaprogettoora] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salrendicontattivitaprogettoora' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salrendicontattivitaprogettoora] ADD cu varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salrendicontattivitaprogettoora') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salrendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salrendicontattivitaprogettoora] ALTER COLUMN cu varchar(60) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salrendicontattivitaprogettoora' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salrendicontattivitaprogettoora] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salrendicontattivitaprogettoora') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salrendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salrendicontattivitaprogettoora] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'salrendicontattivitaprogettoora' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [salrendicontattivitaprogettoora] ADD lu varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('salrendicontattivitaprogettoora') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [salrendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [salrendicontattivitaprogettoora] ALTER COLUMN lu varchar(60) NOT NULL
GO

-- CREAZIONE TABELLA workpackage --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[workpackage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [workpackage] (
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
start date NULL,
stop date NULL,
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD start date NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD stop date NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN title nvarchar(2048) NULL
GO

-- CREAZIONE VISTA assetdiarydocview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetdiarydocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetdiarydocview]
GO

CREATE VIEW [assetdiarydocview] AS SELECT  assetdiary.ct AS assetdiary_ct, assetdiary.cu AS assetdiary_cu, assetdiary.idasset AS assetdiary_idasset, assetdiary.idassetdiary, assetacquire.description AS assetacquire_description, assetacquire.idinv AS assetacquire_idinv, asset.idasset AS asset_idasset, asset.idpiece AS asset_idpiece, inventory.description AS inventory_description, asset.ninventory AS asset_ninventory, asset.rfid AS asset_rfid, assetdiary.idpiece, progetto.titolobreve AS progetto_titolobreve, assetdiary.idprogetto, assetdiary.idreg AS assetdiary_idreg, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, assetdiary.idworkpackage, assetdiary.lt AS assetdiary_lt, assetdiary.lu AS assetdiary_lu, assetdiary.orepreventivate AS assetdiary_orepreventivate, isnull('Descrizione Descrizione: ' + assetacquire.description + '; ','') + ' ' + isnull('Class. Inv. Descrizione: ' + CAST( assetacquire.idinv AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.idasset AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.idpiece AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.ninventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + asset.rfid + '; ','') + ' ' + isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Descrizione Inventario: ' + inventory.description + '; ','') as dropdown_title FROM assetdiary WITH (NOLOCK)  LEFT OUTER JOIN asset WITH (NOLOCK) ON assetdiary.idasset = asset.idasset AND assetdiary.idpiece = asset.idpiece LEFT OUTER JOIN assetacquire WITH (NOLOCK) ON asset.nassetacquire = assetacquire.nassetacquire LEFT OUTER JOIN inventory WITH (NOLOCK) ON asset.idinventory = inventory.idinventory LEFT OUTER JOIN progetto WITH (NOLOCK) ON assetdiary.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON assetdiary.idworkpackage = workpackage.idworkpackage WHERE  assetdiary.idassetdiary IS NOT NULL  AND assetdiary.idworkpackage IS NOT NULL 
GO

-- CREAZIONE VISTA assetdiaryorasegview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetdiaryorasegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetdiaryorasegview]
GO

CREATE VIEW [assetdiaryorasegview] AS SELECT  assetdiaryora.amount AS assetdiaryora_amount, assetdiaryora.ct AS assetdiaryora_ct, assetdiaryora.cu AS assetdiaryora_cu, assetdiaryora.idassetdiary, assetdiaryora.idassetdiaryora, sal.start AS sal_start, sal.stop AS sal_stop, assetdiaryora.idsal, assetdiaryora.idworkpackage, assetdiaryora.lt AS assetdiaryora_lt, assetdiaryora.lu AS assetdiaryora_lu, assetdiaryora.start AS assetdiaryora_start, assetdiaryora.stop AS assetdiaryora_stop FROM assetdiaryora WITH (NOLOCK)  LEFT OUTER JOIN sal WITH (NOLOCK) ON assetdiaryora.idsal = sal.idsal WHERE  assetdiaryora.idassetdiary IS NOT NULL  AND assetdiaryora.idassetdiaryora IS NOT NULL  AND assetdiaryora.idworkpackage IS NOT NULL 
GO

-- CREAZIONE VISTA progettocostosegprgview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettocostosegprgview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettocostosegprgview]
GO

CREATE VIEW [progettocostosegprgview] AS SELECT  progettocosto.amount AS progettocosto_amount, progettocosto.ct AS progettocosto_ct, progettocosto.cu AS progettocosto_cu, progettocosto.doc AS progettocosto_doc, progettocosto.docdate AS progettocosto_docdate, [dbo].contrattokind.title AS contrattokind_title, progettocosto.idcontrattokind AS progettocosto_idcontrattokind, expense.description AS expense_description, expense.ymov AS expense_ymov, expense.nmov AS expense_nmov, progettocosto.idexp, pettycash.description AS pettycash_description, pettycash.pettycode AS pettycash_pettycode, progettocosto.idpettycash, progettocosto.idprogetto, progettocosto.idprogettocosto, progettotipocosto.title AS progettotipocosto_title, progettocosto.idprogettotipocosto AS progettocosto_idprogettotipocosto, entrydetail.description AS entrydetail_description, progettocosto.idrelated, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idworkpackage AS rendicontattivitaprogetto_idworkpackage, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, progettocosto.idrendicontattivitaprogetto, sal.start AS sal_start, sal.stop AS sal_stop, progettocosto.idsal AS progettocosto_idsal, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, progettocosto.idworkpackage, progettocosto.lt AS progettocosto_lt, progettocosto.lu AS progettocosto_lu, progettocosto.noperation AS progettocosto_noperation, progettocosto.yoperation AS progettocosto_yoperation, isnull('Titolo breve o acronimo Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Voce di costo: ' + progettotipocosto.title + '; ','') + ' ' + isnull('Importo: ' + CAST( progettocosto.amount AS NVARCHAR(64)) + '; ','') as dropdown_title FROM progettocosto WITH (NOLOCK)  LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON progettocosto.idcontrattokind = [dbo].contrattokind.idcontrattokind LEFT OUTER JOIN expense WITH (NOLOCK) ON progettocosto.idexp = expense.idexp LEFT OUTER JOIN pettycash WITH (NOLOCK) ON progettocosto.idpettycash = pettycash.idpettycash LEFT OUTER JOIN progettotipocosto WITH (NOLOCK) ON progettocosto.idprogettotipocosto = progettotipocosto.idprogettotipocosto LEFT OUTER JOIN entrydetail WITH (NOLOCK) ON progettocosto.idrelated = entrydetail.idrelated LEFT OUTER JOIN rendicontattivitaprogetto WITH (NOLOCK) ON progettocosto.idrendicontattivitaprogetto = rendicontattivitaprogetto.idrendicontattivitaprogetto LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN sal WITH (NOLOCK) ON progettocosto.idsal = sal.idsal LEFT OUTER JOIN workpackage WITH (NOLOCK) ON progettocosto.idworkpackage = workpackage.idworkpackage WHERE  progettocosto.idprogetto IS NOT NULL  AND progettocosto.idprogettocosto IS NOT NULL 
GO

-- CREAZIONE VISTA progettocostosegsalview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettocostosegsalview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettocostosegsalview]
GO

CREATE VIEW [progettocostosegsalview] AS SELECT  progettocosto.amount AS progettocosto_amount, progettocosto.ct AS progettocosto_ct, progettocosto.cu AS progettocosto_cu, progettocosto.doc AS progettocosto_doc, progettocosto.docdate AS progettocosto_docdate, [dbo].contrattokind.title AS contrattokind_title, progettocosto.idcontrattokind AS progettocosto_idcontrattokind, expense.description AS expense_description, expense.ymov AS expense_ymov, expense.nmov AS expense_nmov, progettocosto.idexp, pettycash.description AS pettycash_description, pettycash.pettycode AS pettycash_pettycode, progettocosto.idpettycash, progettocosto.idprogetto, progettocosto.idprogettocosto, progettotipocosto.title AS progettotipocosto_title, progettocosto.idprogettotipocosto, entrydetail.description AS entrydetail_description, progettocosto.idrelated, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idworkpackage AS rendicontattivitaprogetto_idworkpackage, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, progettocosto.idrendicontattivitaprogetto, sal.start AS sal_start, sal.stop AS sal_stop, progettocosto.idsal AS progettocosto_idsal, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, progettocosto.idworkpackage, progettocosto.lt AS progettocosto_lt, progettocosto.lu AS progettocosto_lu, progettocosto.noperation AS progettocosto_noperation, progettocosto.yoperation AS progettocosto_yoperation, isnull('Voce di costo: ' + progettotipocosto.title + '; ','') + ' ' + isnull('Titolo breve o acronimo Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') as dropdown_title FROM progettocosto WITH (NOLOCK)  LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON progettocosto.idcontrattokind = [dbo].contrattokind.idcontrattokind LEFT OUTER JOIN expense WITH (NOLOCK) ON progettocosto.idexp = expense.idexp LEFT OUTER JOIN pettycash WITH (NOLOCK) ON progettocosto.idpettycash = pettycash.idpettycash LEFT OUTER JOIN progettotipocosto WITH (NOLOCK) ON progettocosto.idprogettotipocosto = progettotipocosto.idprogettotipocosto LEFT OUTER JOIN entrydetail WITH (NOLOCK) ON progettocosto.idrelated = entrydetail.idrelated LEFT OUTER JOIN rendicontattivitaprogetto WITH (NOLOCK) ON progettocosto.idrendicontattivitaprogetto = rendicontattivitaprogetto.idrendicontattivitaprogetto LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN sal WITH (NOLOCK) ON progettocosto.idsal = sal.idsal LEFT OUTER JOIN workpackage WITH (NOLOCK) ON progettocosto.idworkpackage = workpackage.idworkpackage WHERE  progettocosto.idprogetto IS NOT NULL  AND progettocosto.idprogettocosto IS NOT NULL  AND progettocosto.idprogettotipocosto IS NOT NULL  AND progettocosto.idworkpackage IS NOT NULL 
GO

-- CREAZIONE VISTA progettocostosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettocostosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettocostosegview]
GO

CREATE VIEW [progettocostosegview] AS SELECT  progettocosto.amount AS progettocosto_amount, progettocosto.ct AS progettocosto_ct, progettocosto.cu AS progettocosto_cu, progettocosto.doc AS progettocosto_doc, progettocosto.docdate AS progettocosto_docdate, [dbo].contrattokind.title AS contrattokind_title, progettocosto.idcontrattokind AS progettocosto_idcontrattokind, expense.description AS expense_description, expense.ymov AS expense_ymov, expense.nmov AS expense_nmov, progettocosto.idexp, pettycash.description AS pettycash_description, pettycash.pettycode AS pettycash_pettycode, progettocosto.idpettycash, progettocosto.idprogetto, progettocosto.idprogettocosto, progettotipocosto.title AS progettotipocosto_title, progettocosto.idprogettotipocosto, entrydetail.description AS entrydetail_description, progettocosto.idrelated, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idworkpackage AS rendicontattivitaprogetto_idworkpackage, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, progettocosto.idrendicontattivitaprogetto, sal.start AS sal_start, sal.stop AS sal_stop, progettocosto.idsal AS progettocosto_idsal, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, progettocosto.idworkpackage, progettocosto.lt AS progettocosto_lt, progettocosto.lu AS progettocosto_lu, progettocosto.noperation AS progettocosto_noperation, progettocosto.yoperation AS progettocosto_yoperation, isnull('Voce di costo: ' + progettotipocosto.title + '; ','') + ' ' + isnull('Titolo breve o acronimo Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') as dropdown_title FROM progettocosto WITH (NOLOCK)  LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON progettocosto.idcontrattokind = [dbo].contrattokind.idcontrattokind LEFT OUTER JOIN expense WITH (NOLOCK) ON progettocosto.idexp = expense.idexp LEFT OUTER JOIN pettycash WITH (NOLOCK) ON progettocosto.idpettycash = pettycash.idpettycash LEFT OUTER JOIN progettotipocosto WITH (NOLOCK) ON progettocosto.idprogettotipocosto = progettotipocosto.idprogettotipocosto LEFT OUTER JOIN entrydetail WITH (NOLOCK) ON progettocosto.idrelated = entrydetail.idrelated LEFT OUTER JOIN rendicontattivitaprogetto WITH (NOLOCK) ON progettocosto.idrendicontattivitaprogetto = rendicontattivitaprogetto.idrendicontattivitaprogetto LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN sal WITH (NOLOCK) ON progettocosto.idsal = sal.idsal LEFT OUTER JOIN workpackage WITH (NOLOCK) ON progettocosto.idworkpackage = workpackage.idworkpackage WHERE  progettocosto.idprogetto IS NOT NULL  AND progettocosto.idprogettocosto IS NOT NULL  AND progettocosto.idprogettotipocosto IS NOT NULL  AND progettocosto.idworkpackage IS NOT NULL 
GO

-- CREAZIONE VISTA progettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettosegview]
GO

CREATE VIEW [progettosegview] AS SELECT  progetto.budget AS progetto_budget, progetto.budgetcalcolato AS progetto_budgetcalcolato, progetto.budgetcalcolatodate AS progetto_budgetcalcolatodate, progetto.capofilatxt AS progetto_capofilatxt, progetto.codiceidentificativo AS progetto_codiceidentificativo, progetto.contributo AS progetto_contributo, progetto.contributoente AS progetto_contributoente, progetto.ct AS progetto_ct, progetto.cu AS progetto_cu, progetto.cup AS progetto_cup, progetto.data AS progetto_data, progetto.datacontabile AS progetto_datacontabile, progetto.description AS progetto_description, progetto.durata AS progetto_durata, progetto.finanziatoretxt AS progetto_finanziatoretxt, [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, progetto.idcorsostudio, [dbo].currency.codecurrency AS currency_codecurrency, progetto.idcurrency, [dbo].duratakind.title AS duratakind_title, progetto.idduratakind AS progetto_idduratakind, progetto.idprogetto, [dbo].progettokind.title AS progettokind_title, progetto.idprogettokind AS progetto_idprogettokind, [dbo].progettostatuskind.title AS progettostatuskind_title, progetto.idprogettostatuskind AS progetto_idprogettostatuskind, [dbo].registry.title AS registry_title, progetto.idreg, registry_registry_aziendeaziende.title AS registryaziende_title, progetto.idreg_aziende, registry_registry_aziendeaziende_fin.title AS registryaziende_fin_title, progetto.idreg_aziende_fin, [dbo].registryprogfin.title AS registryprogfin_title, [dbo].registryprogfin.code AS registryprogfin_code, progetto.idregistryprogfin AS progetto_idregistryprogfin, [dbo].registryprogfinbando.title AS registryprogfinbando_title, [dbo].registryprogfinbando.number AS registryprogfinbando_number, [dbo].registryprogfinbando.scadenza AS registryprogfinbando_scadenza, progetto.idregistryprogfinbando AS progetto_idregistryprogfinbando, progetto.lt AS progetto_lt, progetto.lu AS progetto_lu, progetto.start AS progetto_start, progetto.stop AS progetto_stop, progetto.title AS progetto_title, progetto.titolobreve, progetto.totalbudget AS progetto_totalbudget, progetto.totalcontributo AS progetto_totalcontributo, progetto.url AS progetto_url, isnull('Titolo breve o acronimo: ' + progetto.titolobreve + '; ','') as dropdown_title FROM progetto WITH (NOLOCK)  LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON progetto.idcorsostudio = [dbo].corsostudio.idcorsostudio LEFT OUTER JOIN [dbo].currency WITH (NOLOCK) ON progetto.idcurrency = [dbo].currency.idcurrency LEFT OUTER JOIN [dbo].duratakind WITH (NOLOCK) ON progetto.idduratakind = [dbo].duratakind.idduratakind LEFT OUTER JOIN [dbo].progettokind WITH (NOLOCK) ON progetto.idprogettokind = [dbo].progettokind.idprogettokind LEFT OUTER JOIN [dbo].progettostatuskind WITH (NOLOCK) ON progetto.idprogettostatuskind = [dbo].progettostatuskind.idprogettostatuskind LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON progetto.idreg = [dbo].registry.idreg LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON progetto.idreg_aziende = registry_aziendeaziende.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registry_registry_aziendeaziende.idreg LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende_fin WITH (NOLOCK) ON progetto.idreg_aziende_fin = registry_aziendeaziende_fin.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende_fin WITH (NOLOCK) ON registry_aziendeaziende_fin.idreg = registry_registry_aziendeaziende_fin.idreg LEFT OUTER JOIN [dbo].registryprogfin WITH (NOLOCK) ON progetto.idregistryprogfin = [dbo].registryprogfin.idregistryprogfin LEFT OUTER JOIN [dbo].registryprogfinbando WITH (NOLOCK) ON progetto.idregistryprogfinbando = [dbo].registryprogfinbando.idregistryprogfinbando WHERE  progetto.idprogetto IS NOT NULL 
GO

-- CREAZIONE VISTA rendicontattivitaprogettoanagammview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoanagammview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoanagammview]
GO

CREATE VIEW [rendicontattivitaprogettoanagammview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, rendicontattivitaprogetto.stop AS rendicontattivitaprogetto_stop, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 
GO

-- CREAZIONE VISTA rendicontattivitaprogettoanagview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoanagview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoanagview]
GO

CREATE VIEW [rendicontattivitaprogettoanagview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, rendicontattivitaprogetto.stop AS rendicontattivitaprogetto_stop, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 
GO

-- CREAZIONE VISTA rendicontattivitaprogettodocview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettodocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettodocview]
GO

CREATE VIEW [rendicontattivitaprogettodocview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, rendicontattivitaprogetto.stop AS rendicontattivitaprogetto_stop, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 
GO

-- CREAZIONE VISTA rendicontattivitaprogettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettosegview]
GO

CREATE VIEW [rendicontattivitaprogettosegview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, rendicontattivitaprogetto.idprogetto AS rendicontattivitaprogetto_idprogetto, [dbo].registry.title AS registry_title, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, rendicontattivitaprogetto.stop AS rendicontattivitaprogetto_stop, isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON rendicontattivitaprogetto.idreg = [dbo].registry.idreg WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 
GO

-- CREAZIONE VISTA saldefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[saldefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [saldefaultview]
GO

CREATE VIEW [saldefaultview] AS SELECT  sal.budget AS sal_budget, sal.datablocco AS sal_datablocco, sal.idprogetto, sal.idsal, sal.start, sal.stop AS sal_stop, isnull('dal ' + CONVERT(VARCHAR, sal.start, 103),'') + ' ' + isnull('al ' + CONVERT(VARCHAR, sal.stop, 103),'') as dropdown_title FROM sal WITH (NOLOCK)  WHERE  sal.idprogetto IS NOT NULL  AND sal.idsal IS NOT NULL 
GO

-- CREAZIONE VISTA workpackagesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[workpackagesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [workpackagesegview]
GO

CREATE VIEW [workpackagesegview] AS SELECT  workpackage.acronimo AS workpackage_acronimo, workpackage.ct AS workpackage_ct, workpackage.cu AS workpackage_cu, workpackage.description AS workpackage_description, workpackage.idprogetto, [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, workpackage.idstruttura AS workpackage_idstruttura, workpackage.idworkpackage, workpackage.lt AS workpackage_lt, workpackage.lu AS workpackage_lu, workpackage.raggruppamento, workpackage.start AS workpackage_start, workpackage.stop AS workpackage_stop, workpackage.title AS workpackage_title, isnull('Raggruppamento: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Titolo: ' + workpackage.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].strutturakind.title + '; ','') as dropdown_title FROM workpackage WITH (NOLOCK)  LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON workpackage.idstruttura = [dbo].struttura.idstruttura LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind WHERE  workpackage.idprogetto IS NOT NULL  AND workpackage.idworkpackage IS NOT NULL 
GO

