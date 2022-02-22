
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


--setuser 'amm'
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

-- CREAZIONE TABELLA progettoasset --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettoasset]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettoasset] (
idprogetto int NOT NULL,
idasset int NOT NULL,
idpiece int NOT NULL,
aggiunta char(1) NULL,
costoorario decimal(10,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkprogettoasset PRIMARY KEY (idprogetto,
idasset,
idpiece
)
)
END
GO

-- VERIFICA STRUTTURA progettoasset --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'idasset' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD idasset int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'idasset' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'idpiece' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD idpiece int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'idpiece' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'aggiunta' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD aggiunta char(1) NULL 
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN aggiunta char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'costoorario' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD costoorario decimal(10,2) NULL 
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN costoorario decimal(10,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE TABELLA progettoattach --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettoattach]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettoattach] (
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

-- CREAZIONE TABELLA progettobudgetvariazione --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettobudgetvariazione]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettobudgetvariazione] (
idprogettobudgetvariazione int NOT NULL,
idprogettobudget int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
idaccmotive varchar(36) NULL,
idupb varchar(36) NULL,
lt datetime NULL,
lu varchar(60) NULL,
newamount decimal(16,2) NULL,
 CONSTRAINT xpkprogettobudgetvariazione PRIMARY KEY (idprogettobudgetvariazione,
idprogettobudget,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettobudgetvariazione --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogettobudgetvariazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogettobudgetvariazione int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogettobudgetvariazione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogettobudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogettobudget int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogettobudget' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idaccmotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idaccmotive varchar(36) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN idaccmotive varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idupb varchar(36) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN idupb varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN lu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'newamount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD newamount decimal(16,2) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN newamount decimal(16,2) NULL
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

-- CREAZIONE TABELLA progettoproroga --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettoproroga]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettoproroga] (
idprogettoproroga int NOT NULL,
idprogetto int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
motivazioni nvarchar(max) NULL,
proroga date NULL,
 CONSTRAINT xpkprogettoproroga PRIMARY KEY (idprogettoproroga,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettoproroga --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoproroga' and C.name = 'idprogettoproroga' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoproroga] ADD idprogettoproroga int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoproroga') and col.name = 'idprogettoproroga' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoproroga] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoproroga' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoproroga] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoproroga') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoproroga] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoproroga' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoproroga] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoproroga') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoproroga] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoproroga] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoproroga' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoproroga] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoproroga') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoproroga] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoproroga] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoproroga' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoproroga] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoproroga') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoproroga] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoproroga] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoproroga' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoproroga] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoproroga') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoproroga] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoproroga] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoproroga' and C.name = 'motivazioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoproroga] ADD motivazioni nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progettoproroga] ALTER COLUMN motivazioni nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoproroga' and C.name = 'proroga' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoproroga] ADD proroga date NULL 
END
ELSE
	ALTER TABLE [progettoproroga] ALTER COLUMN proroga date NULL
GO

-- CREAZIONE TABELLA progettoregistry_aziende --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettoregistry_aziende]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettoregistry_aziende] (
idprogetto int NOT NULL,
idreg_aziende int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkprogettoregistry_aziende PRIMARY KEY (idprogetto,
idreg_aziende
)
)
END
GO

-- VERIFICA STRUTTURA progettoregistry_aziende --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'idreg_aziende' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD idreg_aziende int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'idreg_aziende' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoregistry_aziende] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoregistry_aziende] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoregistry_aziende] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoregistry_aziende] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE TABELLA progettorp --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettorp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettorp] (
idprogettorp int NOT NULL,
idprogetto int NOT NULL,
datefilter char(1) NULL,
start date NULL,
stop date NULL,
 CONSTRAINT xpkprogettorp PRIMARY KEY (idprogettorp,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettorp --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettorp' and C.name = 'idprogettorp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettorp] ADD idprogettorp int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettorp') and col.name = 'idprogettorp' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettorp] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettorp' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettorp] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettorp') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettorp] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettorp' and C.name = 'datefilter' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettorp] ADD datefilter char(1) NULL 
END
ELSE
	ALTER TABLE [progettorp] ALTER COLUMN datefilter char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettorp' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettorp] ADD start date NULL 
END
ELSE
	ALTER TABLE [progettorp] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettorp' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettorp] ADD stop date NULL 
END
ELSE
	ALTER TABLE [progettorp] ALTER COLUMN stop date NULL
GO

-- CREAZIONE TABELLA progettosettoreerc --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettosettoreerc]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettosettoreerc] (
idprogetto int NOT NULL,
idsettoreerc int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkprogettosettoreerc PRIMARY KEY (idprogetto,
idsettoreerc
)
)
END
GO

-- VERIFICA STRUTTURA progettosettoreerc --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'idsettoreerc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD idsettoreerc int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'idsettoreerc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettosettoreerc] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettosettoreerc] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettosettoreerc] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettosettoreerc] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE TABELLA progettotesto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotesto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotesto] (
idprogettotesto int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
description nvarchar(max) NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkprogettotesto PRIMARY KEY (idprogettotesto,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettotesto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotesto' and C.name = 'idprogettotesto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotesto] ADD idprogettotesto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotesto') and col.name = 'idprogettotesto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotesto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotesto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotesto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotesto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotesto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotesto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotesto] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotesto] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotesto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotesto] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotesto] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotesto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotesto] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progettotesto] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotesto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotesto] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotesto] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotesto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotesto] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotesto] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotesto' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotesto] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [progettotesto] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotesto' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotesto] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettotesto] ALTER COLUMN title nvarchar(2048) NULL
GO

-- CREAZIONE TABELLA progettotimesheet --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotimesheet]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotimesheet] (
idprogettotimesheet int NOT NULL,
idreg int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
showactivitiesrow char(1) NULL,
title nvarchar(2048) NULL,
year int NULL,
 CONSTRAINT xpkprogettotimesheet PRIMARY KEY (idprogettotimesheet,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA progettotimesheet --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'idprogettotimesheet' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD idprogettotimesheet int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheet') and col.name = 'idprogettotimesheet' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheet] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheet') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheet] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN lu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'showactivitiesrow' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD showactivitiesrow char(1) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN showactivitiesrow char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN title nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD year int NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN year int NULL
GO

-- CREAZIONE TABELLA progettotimesheetprogetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotimesheetprogetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotimesheetprogetto] (
idprogettotimesheet int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
 CONSTRAINT xpkprogettotimesheetprogetto PRIMARY KEY (idprogettotimesheet,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettotimesheetprogetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'idprogettotimesheet' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD idprogettotimesheet int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheetprogetto') and col.name = 'idprogettotimesheet' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheetprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheetprogetto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheetprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheetprogetto] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheetprogetto] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheetprogetto] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheetprogetto] ALTER COLUMN lu varchar(60) NULL
GO

-- CREAZIONE TABELLA progettotipocosto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotipocosto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotipocosto] (
idprogettotipocosto int NOT NULL,
idprogetto int NOT NULL,
ammissibilita decimal(5,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
idprogettotipocostokind int NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkprogettotipocosto PRIMARY KEY (idprogettotipocosto,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettotipocosto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD idprogettotipocosto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocosto') and col.name = 'idprogettotipocosto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocosto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'ammissibilita' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD ammissibilita decimal(5,2) NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN ammissibilita decimal(5,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'idprogettotipocostokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD idprogettotipocostokind int NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN idprogettotipocostokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN title varchar(2048) NULL
GO

-- CREAZIONE TABELLA progettotipocostoaccmotive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotipocostoaccmotive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotipocostoaccmotive] (
idprogetto int NOT NULL,
idprogettotipocosto int NOT NULL,
idaccmotive varchar(38) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprogettotipocostoaccmotive PRIMARY KEY (idprogetto,
idprogettotipocosto,
idaccmotive
)
)
END
GO

-- VERIFICA STRUTTURA progettotipocostoaccmotive --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoaccmotive' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoaccmotive] ADD idprogetto int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostoaccmotive') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostoaccmotive] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoaccmotive' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoaccmotive] ADD idprogettotipocosto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostoaccmotive') and col.name = 'idprogettotipocosto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostoaccmotive] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoaccmotive' and C.name = 'idaccmotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoaccmotive] ADD idaccmotive varchar(38) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostoaccmotive') and col.name = 'idaccmotive' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostoaccmotive] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoaccmotive' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoaccmotive] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostoaccmotive] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoaccmotive' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoaccmotive] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostoaccmotive] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoaccmotive' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoaccmotive] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostoaccmotive] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoaccmotive' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoaccmotive] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostoaccmotive] ALTER COLUMN lu varchar(64) NULL
GO

-- CREAZIONE TABELLA progettotipocostocontrattokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotipocostocontrattokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotipocostocontrattokind] (
idprogettotipocosto int NOT NULL,
idcontrattokind int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprogettotipocostocontrattokind PRIMARY KEY (idprogettotipocosto,
idcontrattokind,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettotipocostocontrattokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostocontrattokind' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostocontrattokind] ADD idprogettotipocosto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostocontrattokind') and col.name = 'idprogettotipocosto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostocontrattokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostocontrattokind' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostocontrattokind] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostocontrattokind') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostocontrattokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostocontrattokind' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostocontrattokind] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostocontrattokind') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostocontrattokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostocontrattokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostocontrattokind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostocontrattokind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostocontrattokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostocontrattokind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostocontrattokind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostocontrattokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostocontrattokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostocontrattokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostocontrattokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostocontrattokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostocontrattokind] ALTER COLUMN lu varchar(64) NULL
GO

-- CREAZIONE TABELLA progettotipocostoinventorytree --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotipocostoinventorytree]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotipocostoinventorytree] (
idprogettotipocosto int NOT NULL,
idinv int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprogettotipocostoinventorytree PRIMARY KEY (idprogettotipocosto,
idinv,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettotipocostoinventorytree --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoinventorytree' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoinventorytree] ADD idprogettotipocosto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostoinventorytree') and col.name = 'idprogettotipocosto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostoinventorytree] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoinventorytree' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoinventorytree] ADD idinv int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostoinventorytree') and col.name = 'idinv' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostoinventorytree] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoinventorytree' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoinventorytree] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostoinventorytree') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostoinventorytree] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoinventorytree' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoinventorytree] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostoinventorytree] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoinventorytree' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoinventorytree] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostoinventorytree] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoinventorytree' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoinventorytree] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostoinventorytree] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostoinventorytree' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostoinventorytree] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostoinventorytree] ALTER COLUMN lu varchar(64) NULL
GO

-- CREAZIONE TABELLA progettotipocostotax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotipocostotax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotipocostotax] (
idprogettotipocosto int NOT NULL,
taxcode int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprogettotipocostotax PRIMARY KEY (idprogettotipocosto,
taxcode,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettotipocostotax --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD idprogettotipocosto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostotax') and col.name = 'idprogettotipocosto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostotax] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD taxcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostotax') and col.name = 'taxcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostotax] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostotax') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostotax] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostotax] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostotax] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostotax] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostotax] ALTER COLUMN lu varchar(64) NULL
GO

-- CREAZIONE TABELLA progettoudr --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettoudr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettoudr] (
idprogettoudr int NOT NULL,
idprogetto int NOT NULL,
assegniricerca int NULL,
borsedottorati int NULL,
budget decimal(10,2) NULL,
contrattirtd int NULL,
contributo decimal(10,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(max) NULL,
impegnototale int NULL,
lt datetime NULL,
lu varchar(64) NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkprogettoudr PRIMARY KEY (idprogettoudr,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettoudr --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'idprogettoudr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD idprogettoudr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudr') and col.name = 'idprogettoudr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudr] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudr') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudr] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'assegniricerca' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD assegniricerca int NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN assegniricerca int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'borsedottorati' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD borsedottorati int NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN borsedottorati int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD budget decimal(10,2) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN budget decimal(10,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'contrattirtd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD contrattirtd int NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN contrattirtd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'contributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD contributo decimal(10,2) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN contributo decimal(10,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'impegnototale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD impegnototale int NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN impegnototale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN title nvarchar(2048) NULL
GO

-- CREAZIONE TABELLA progettoudrmembro --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettoudrmembro]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettoudrmembro] (
idprogettoudrmembro int NOT NULL,
idprogettoudr int NOT NULL,
idprogetto int NOT NULL,
costoorario decimal(10,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
idprogettoudrmembrokind int NULL,
idreg int NULL,
impegno int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprogettoudrmembro PRIMARY KEY (idprogettoudrmembro,
idprogettoudr,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettoudrmembro --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'idprogettoudrmembro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD idprogettoudrmembro int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembro') and col.name = 'idprogettoudrmembro' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'idprogettoudr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD idprogettoudr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembro') and col.name = 'idprogettoudr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembro') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'costoorario' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD costoorario decimal(10,2) NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN costoorario decimal(10,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'idprogettoudrmembrokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD idprogettoudrmembrokind int NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN idprogettoudrmembrokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'impegno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD impegno int NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN impegno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN lu varchar(64) NULL
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

-- CREAZIONE TABELLA workpackageupb --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[workpackageupb]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [workpackageupb] (
idprogetto int NOT NULL,
idworkpackage int NOT NULL,
idupb varchar(36) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkworkpackageupb PRIMARY KEY (idprogetto,
idworkpackage,
idupb
)
)
END
GO

-- VERIFICA STRUTTURA workpackageupb --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackageupb' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackageupb] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackageupb') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackageupb] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackageupb' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackageupb] ADD idworkpackage int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackageupb') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackageupb] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackageupb' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackageupb] ADD idupb varchar(36) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackageupb') and col.name = 'idupb' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackageupb] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackageupb' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackageupb] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackageupb') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackageupb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackageupb] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackageupb' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackageupb] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackageupb') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackageupb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackageupb] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackageupb' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackageupb] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackageupb') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackageupb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackageupb] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackageupb' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackageupb] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackageupb') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackageupb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackageupb] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE VISTA assetdiarydocview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetdiarydocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetdiarydocview]
GO



CREATE VIEW [assetdiarydocview] AS SELECT  assetdiary.ct AS assetdiary_ct, assetdiary.cu AS assetdiary_cu, assetdiary.idasset AS assetdiary_idasset, assetdiary.idassetdiary, assetacquire.description AS assetacquire_description, assetacquire.idinv AS assetacquire_idinv, asset.idasset AS asset_idasset, asset.idpiece AS asset_idpiece, inventory.description AS inventory_description, asset.ninventory AS asset_ninventory, asset.rfid AS asset_rfid, assetdiary.idpiece, progetto.titolobreve AS progetto_titolobreve, assetdiary.idprogetto, assetdiary.idreg AS assetdiary_idreg, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, assetdiary.idworkpackage, assetdiary.lt AS assetdiary_lt, assetdiary.lu AS assetdiary_lu, assetdiary.orepreventivate AS assetdiary_orepreventivate, isnull('Descrizione Descrizione: ' + assetacquire.description + '; ','') + ' ' + isnull('Class. Inv. Descrizione: ' + CAST( assetacquire.idinv AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.idasset AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.idpiece AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.ninventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + asset.rfid + '; ','') + ' ' + isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Descrizione Inventario: ' + inventory.description + '; ','') as dropdown_title FROM assetdiary WITH (NOLOCK)  LEFT OUTER JOIN asset WITH (NOLOCK) ON assetdiary.idasset = asset.idasset AND assetdiary.idpiece = asset.idpiece LEFT OUTER JOIN assetacquire WITH (NOLOCK) ON asset.nassetacquire = assetacquire.nassetacquire LEFT OUTER JOIN inventory WITH (NOLOCK) ON asset.idinventory = inventory.idinventory LEFT OUTER JOIN progetto WITH (NOLOCK) ON assetdiary.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON assetdiary.idworkpackage = workpackage.idworkpackage WHERE  assetdiary.idassetdiary IS NOT NULL  AND assetdiary.idworkpackage IS NOT NULL 

GO

-- CREAZIONE VISTA assetdiaryoraview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetdiaryoraview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetdiaryoraview]
GO



CREATE VIEW [assetdiaryoraview] AS 
SELECT  assetdiary.idreg, assetdiary.idasset, assetdiary.idpiece, assetdiary.idassetdiary,assetdiaryora.start, assetdiaryora.stop, 
'<b>Progetto:</b> ' + isnull(progetto.titolobreve,'') + 
'; <b>Workpackage:</b> ' + isnull(workpackage.title,'') + 
'; <b>Operatore:</b> ' + isnull(registrydefaultview.dropdown_title,'') + 
'; <b>Bene:</b> ' + isnull('' + CAST(inventory.description AS NVARCHAR(64)) + ' Inventario' ,'') + ' ' + isnull('' + CAST( asset.idasset AS NVARCHAR(64)) + ' Identificativo' ,'') + ' ' + 
isnull('' + CAST( asset.idpiece AS NVARCHAR(64)) + ' Numero parte' ,'') + ' ' + isnull('' + CAST(assetacquire.description AS NVARCHAR(64)) + ' Descrizione' ,'') + ' ' + 
isnull('' + CAST( asset.ninventory AS NVARCHAR(64)) + ' Numero inventario' ,'') + ' ' + isnull('' + asset.rfid,'')
as title
FROM  assetdiaryora WITH (NOLOCK) 
LEFT OUTER JOIN assetdiary WITH (NOLOCK) ON assetdiary.idassetdiary = assetdiaryora.idassetdiary
LEFT OUTER JOIN asset WITH (NOLOCK) ON asset.idasset = assetdiary.idasset and asset.idpiece = assetdiary.idpiece
LEFT OUTER JOIN inventory WITH (NOLOCK) ON asset.idinventory = inventory.idinventory 
LEFT OUTER JOIN assetacquire WITH (NOLOCK) ON asset.nassetacquire = assetacquire.nassetacquire 
LEFT OUTER JOIN progetto WITH (NOLOCK) ON progetto.idprogetto = assetdiary.idprogetto 
LEFT OUTER JOIN workpackage WITH (NOLOCK) ON workpackage.idworkpackage = assetdiary.idworkpackage
LEFT OUTER JOIN dbo.registrydefaultview WITH (NOLOCK) ON dbo.registrydefaultview.idreg = assetdiary.idreg
WHERE  asset.idasset IS NOT NULL  AND asset.idpiece IS NOT NULL 

GO

-- CREAZIONE VISTA assetsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetsegview]
GO



CREATE VIEW [assetsegview] AS SELECT  asset.amortizationquota AS asset_amortizationquota, asset.ct AS asset_ct, asset.cu AS asset_cu, asset.flag AS asset_flag, asset.idasset, asset.idasset_prev AS asset_idasset_prev, asset.idassetunload AS asset_idassetunload, asset.idcurrlocation AS asset_idcurrlocation, asset.idcurrman AS asset_idcurrman, asset.idcurrsubman AS asset_idcurrsubman, inventory.description AS inventory_description, asset.idinventory, asset.idinventoryamortization AS asset_idinventoryamortization, asset.idpiece, asset.idpiece_prev AS asset_idpiece_prev, asset.lifestart AS asset_lifestart, asset.lt AS asset_lt, asset.lu AS asset_lu, asset.multifield AS asset_multifield, assetacquire.description AS assetacquire_description, [dbo].inventorytree.codeinv AS inventorytree_codeinv, [dbo].inventorytree.description AS inventorytree_description, asset.nassetacquire, asset.ninventory AS asset_ninventory, asset.rfid AS asset_rfid, asset.rtf AS asset_rtf,CASE WHEN asset.transmitted = 'S' THEN 'Si' WHEN asset.transmitted = 'N' THEN 'No' END AS asset_transmitted, asset.txt AS asset_txt, isnull('Descrizione: ' + assetacquire.description + '; ','') + ' ' + isnull('Identificativo: ' + CAST( asset.idasset AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice Class. Inv.: ' + [dbo].inventorytree.codeinv + '; ','') + ' ' + isnull('Denominazione Class. Inv.: ' + [dbo].inventorytree.description + '; ','') + ' ' + isnull('Numero parte: ' + CAST( asset.idpiece AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Inventario: ' + inventory.description + '; ','') + ' ' + isnull('Numero inventario: ' + CAST( asset.ninventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice RFID: ' + asset.rfid + '; ','') as dropdown_title FROM asset WITH (NOLOCK)  LEFT OUTER JOIN inventory WITH (NOLOCK) ON asset.idinventory = inventory.idinventory LEFT OUTER JOIN assetacquire WITH (NOLOCK) ON asset.nassetacquire = assetacquire.nassetacquire LEFT OUTER JOIN [dbo].inventorytree WITH (NOLOCK) ON assetacquire.idinv = [dbo].inventorytree.idinv WHERE  asset.idasset IS NOT NULL  AND asset.idpiece IS NOT NULL 

GO

-- CREAZIONE VISTA TimesheetView
IF EXISTS(select * from sysobjects where id = object_id(N'[TimesheetView]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [TimesheetView]
GO


CREATE VIEW [timesheetview]
AS
SELECT        
	progetto.idprogetto,
	rendicontattivitaprogetto.idreg, 
	YEAR(rendicontattivitaprogettoora.data) AS anno, 
	rendicontattivitaprogettoora.data, 
	rendicontattivitaprogettoora.ore, 
	progetto.titolobreve AS progetto, 
    workpackage.title AS workpackage, 
	DAY(rendicontattivitaprogettoora.data) AS giorno, 
	MONTH(rendicontattivitaprogettoora.data) AS mese,
	s.title as dipartimento,
	progetto.idreg as responsabile
FROM
	rendicontattivitaprogetto 
	INNER JOIN rendicontattivitaprogettoora ON rendicontattivitaprogetto.idrendicontattivitaprogetto = rendicontattivitaprogettoora.idrendicontattivitaprogetto 
	INNER JOIN progetto ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto 
	INNER JOIN workpackage ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage
	LEFT OUTER JOIN Struttura s on s.idstruttura = workpackage.idstruttura
UNION
SELECT        
	null as idprogetto,
	dbo.lezione.idreg_docenti, 
	YEAR(dbo.lezione.start) AS anno, 
	dbo.lezione.start as data, 
	DATEDIFF(hh, dbo.lezione.start, dbo.lezione.stop) as ore, 
	'Teaching activities' AS progetto, 
    'Teaching activities' AS workpackage, 
	DAY(dbo.lezione.start) AS giorno, 
	MONTH(dbo.lezione.start) AS mese,
	s.title as dipartimento,
	null as responsabile
FROM
	dbo.lezione
	INNER JOIN corsostudio cs on cs.idcorsostudio = lezione.idcorsostudio
	LEFT OUTER JOIN Struttura s on s.idstruttura = cs.idcorsostudio



GO

-- CREAZIONE VISTA getcontratti
IF EXISTS(select * from sysobjects where id = object_id(N'[getcontratti]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcontratti]
GO


CREATE VIEW [getcontratti]
AS
SELECT        
	c.idcontratto,
	c.idreg, 
	ck.idcontrattokind, 
	ck.title, 
	ck.oremaxgg, 
	c.parttime, 
	c.tempdef, 
	c.start, 
	c.stop,
	c.idinquadramento, 
	c.scatto,
	ck.costolordoannuo,
	Cast(round(ck.costolordoannuo/isnull(oremaxtempopieno,1720),2,1) as decimal(18,2)) costoora,
	Cast(round(ck.costolordoannuo/CASE WHEN isnull(c.tempdef,'N') = 'S' THEN 24 ELSE 12 END,2,1) as decimal(18,2)) costomese,
	CASE WHEN isnull(c.tempdef,'N') = 'S' OR isnull(c.parttime,0)<100 THEN oremaxdidatempoparziale ELSE oremaxdidatempopieno END as oremaxdida,
	CASE WHEN isnull(c.tempdef,'N') = 'S' OR isnull(c.parttime,0)<100 THEN oremindidatempoparziale ELSE oremindidatempopieno END as oremindida
FROM dbo.contrattokind ck 
INNER JOIN dbo.contratto c ON ck.idcontrattokind = c.idcontrattokind


GO

-- CREAZIONE VISTA getprogettocostoview
IF EXISTS(select * from sysobjects where id = object_id(N'[getprogettocostoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getprogettocostoview]
GO



CREATE VIEW [getprogettocostoview]
AS
SELECT        progettocosto.idprogettocosto AS idgetprogettocostoview, progettocosto.idprogetto, workpackage.raggruppamento, workpackage.title AS workpackage_title, progettotipocosto.title AS progettotipocosto_title, 
                         progettotipocosto.ammissibilita, progettocosto.amount, dbo.contrattokind.title AS contrattokind_title, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, progettocosto.doc, 
                         progettocosto.docdate, banktransaction.transactiondate, expense.description, expense.ymov, expense.nmov, pettycash.description AS pettycash_description, 
                         pettycash.pettycode AS pettycash_pettycode, progettocosto.yoperation, progettocosto.noperation, dbo.registry.title AS registry_title, dbo.registry.cf, dbo.registry.p_iva, 
                         payment.adate AS payment_adate, expense.adate, paymenttransmission.transmissiondate
FROM            pettycash RIGHT OUTER JOIN
                         rendicontattivitaprogetto RIGHT OUTER JOIN
                         dbo.registry INNER JOIN
                         expense ON dbo.registry.idreg = expense.idreg INNER JOIN
                         expenselast INNER JOIN
                         payment ON expenselast.kpay = payment.kpay ON expense.idexp = expenselast.idexp INNER JOIN
                         paymenttransmission ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission RIGHT OUTER JOIN
                         dbo.contrattokind RIGHT OUTER JOIN
                         progettocosto INNER JOIN
                         workpackage ON progettocosto.idworkpackage = workpackage.idworkpackage INNER JOIN
                         progettotipocosto ON progettocosto.idprogettotipocosto = progettotipocosto.idprogettotipocosto ON dbo.contrattokind.idcontrattokind = progettocosto.idcontrattokind ON 
                         expense.idexp = progettocosto.idexp ON rendicontattivitaprogetto.idrendicontattivitaprogetto = progettocosto.idrendicontattivitaprogetto ON 
                         pettycash.idpettycash = progettocosto.idpettycash LEFT OUTER JOIN
                         banktransaction RIGHT OUTER JOIN
                         expenseyear ON banktransaction.yban = expenseyear.ayear ON expense.idexp = expenseyear.idexp AND 
                         expense.idexp = banktransaction.idexp

GO

-- CREAZIONE VISTA progettoassetdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettoassetdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettoassetdefaultview]
GO


GO

-- CREAZIONE VISTA progettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettosegview]
GO



CREATE VIEW [progettosegview] AS SELECT  progetto.budget AS progetto_budget, progetto.budgetcalcolato AS progetto_budgetcalcolato, progetto.budgetcalcolatodate AS progetto_budgetcalcolatodate, progetto.capofilatxt AS progetto_capofilatxt, progetto.codiceidentificativo AS progetto_codiceidentificativo, progetto.contributo AS progetto_contributo, progetto.contributoente AS progetto_contributoente, progetto.ct AS progetto_ct, progetto.cu AS progetto_cu, progetto.cup AS progetto_cup, progetto.data AS progetto_data, progetto.datacontabile AS progetto_datacontabile, progetto.description AS progetto_description, progetto.durata AS progetto_durata, progetto.finanziatoretxt AS progetto_finanziatoretxt, [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, progetto.idcorsostudio, [dbo].currency.codecurrency AS currency_codecurrency, progetto.idcurrency, [dbo].duratakind.title AS duratakind_title, progetto.idduratakind AS progetto_idduratakind, progetto.idprogetto, [dbo].progettokind.title AS progettokind_title, progetto.idprogettokind AS progetto_idprogettokind, [dbo].progettostatuskind.title AS progettostatuskind_title, progetto.idprogettostatuskind AS progetto_idprogettostatuskind, [dbo].registry.title AS registry_title, progetto.idreg, registry_registry_aziendeaziende.title AS registryaziende_title, progetto.idreg_aziende, registry_registry_aziendeaziende_fin.title AS registryaziende_fin_title, progetto.idreg_aziende_fin, [dbo].registryprogfin.title AS registryprogfin_title, [dbo].registryprogfin.code AS registryprogfin_code, progetto.idregistryprogfin AS progetto_idregistryprogfin, [dbo].registryprogfinbando.title AS registryprogfinbando_title, [dbo].registryprogfinbando.number AS registryprogfinbando_number, [dbo].registryprogfinbando.scadenza AS registryprogfinbando_scadenza, progetto.idregistryprogfinbando AS progetto_idregistryprogfinbando, progetto.lt AS progetto_lt, progetto.lu AS progetto_lu, progetto.start AS progetto_start, progetto.stop AS progetto_stop, progetto.title AS progetto_title, progetto.titolobreve, progetto.totalbudget AS progetto_totalbudget, progetto.totalcontributo AS progetto_totalcontributo, progetto.url AS progetto_url, isnull('Titolo breve o acronimo: ' + progetto.titolobreve + '; ','') as dropdown_title FROM progetto WITH (NOLOCK)  LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON progetto.idcorsostudio = [dbo].corsostudio.idcorsostudio LEFT OUTER JOIN [dbo].currency WITH (NOLOCK) ON progetto.idcurrency = [dbo].currency.idcurrency LEFT OUTER JOIN [dbo].duratakind WITH (NOLOCK) ON progetto.idduratakind = [dbo].duratakind.idduratakind LEFT OUTER JOIN [dbo].progettokind WITH (NOLOCK) ON progetto.idprogettokind = [dbo].progettokind.idprogettokind LEFT OUTER JOIN [dbo].progettostatuskind WITH (NOLOCK) ON progetto.idprogettostatuskind = [dbo].progettostatuskind.idprogettostatuskind LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON progetto.idreg = [dbo].registry.idreg LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON progetto.idreg_aziende = registry_aziendeaziende.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registry_registry_aziendeaziende.idreg LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende_fin WITH (NOLOCK) ON progetto.idreg_aziende_fin = registry_aziendeaziende_fin.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende_fin WITH (NOLOCK) ON registry_aziendeaziende_fin.idreg = registry_registry_aziendeaziende_fin.idreg LEFT OUTER JOIN [dbo].registryprogfin WITH (NOLOCK) ON progetto.idregistryprogfin = [dbo].registryprogfin.idregistryprogfin LEFT OUTER JOIN [dbo].registryprogfinbando WITH (NOLOCK) ON progetto.idregistryprogfinbando = [dbo].registryprogfinbando.idregistryprogfinbando WHERE  progetto.idprogetto IS NOT NULL 

GO

-- CREAZIONE VISTA progettotipocostosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettotipocostosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettotipocostosegview]
GO


GO

-- CREAZIONE VISTA publicazdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[publicazdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [publicazdefaultview]
GO



CREATE VIEW [publicazdefaultview] AS SELECT  publicaz.abstractstring AS publicaz_abstractstring, publicaz.annocopyright AS publicaz_annocopyright, publicaz.annopub AS publicaz_annopub, publicaz.ct AS publicaz_ct, publicaz.cu AS publicaz_cu, publicaz.editore AS publicaz_editore, publicaz.fascicolo AS publicaz_fascicolo, [dbo].geo_city.title AS geo_city_title, publicaz.idcity, geo_city_publicaz.title AS geo_city_publicaz_title, publicaz.idcity_ed, geo_nationed.title AS geo_nationed_title, publicaz.idnation_ed, geo_nationlang.title AS geo_nationlang_title, publicaz.idnation_lang, progetto.titolobreve AS progetto_titolobreve, publicaz.idprogetto, publicaz.idpublicaz, publicaz.isbn AS publicaz_isbn, publicaz.lt AS publicaz_lt, publicaz.lu AS publicaz_lu, publicaz.numrivista AS publicaz_numrivista, publicaz.pagestart AS publicaz_pagestart, publicaz.pagestop AS publicaz_pagestop, publicaz.pagetot AS publicaz_pagetot, publicaz.title, publicaz.title2 AS publicaz_title2, publicaz.volume AS publicaz_volume, isnull('Titolo: ' + publicaz.title + '; ','') as dropdown_title FROM [dbo].publicaz WITH (NOLOCK)  LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON publicaz.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].geo_city AS geo_city_publicaz WITH (NOLOCK) ON publicaz.idcity_ed = geo_city_publicaz.idcity LEFT OUTER JOIN [dbo].geo_nation AS geo_nationed WITH (NOLOCK) ON publicaz.idnation_ed = geo_nationed.idnation LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang WITH (NOLOCK) ON publicaz.idnation_lang = geo_nationlang.idnation LEFT OUTER JOIN progetto WITH (NOLOCK) ON publicaz.idprogetto = progetto.idprogetto WHERE  publicaz.idpublicaz IS NOT NULL 

GO

-- CREAZIONE VISTA publicazdocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[publicazdocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [publicazdocentiview]
GO



CREATE VIEW [publicazdocentiview] AS SELECT  publicaz.abstractstring AS publicaz_abstractstring, publicaz.annocopyright AS publicaz_annocopyright, publicaz.annopub AS publicaz_annopub, publicaz.ct AS publicaz_ct, publicaz.cu AS publicaz_cu, publicaz.editore AS publicaz_editore, publicaz.fascicolo AS publicaz_fascicolo, [dbo].geo_city.title AS geo_city_title, publicaz.idcity, geo_city_publicaz.title AS geo_city_publicaz_title, publicaz.idcity_ed, geo_nationed.title AS geo_nationed_title, publicaz.idnation_ed, geo_nationlang.title AS geo_nationlang_title, publicaz.idnation_lang, progetto.titolobreve AS progetto_titolobreve, publicaz.idprogetto, publicaz.idpublicaz, publicaz.isbn AS publicaz_isbn, publicaz.lt AS publicaz_lt, publicaz.lu AS publicaz_lu, publicaz.numrivista AS publicaz_numrivista, publicaz.pagestart AS publicaz_pagestart, publicaz.pagestop AS publicaz_pagestop, publicaz.pagetot AS publicaz_pagetot, publicaz.title, publicaz.title2 AS publicaz_title2, publicaz.volume AS publicaz_volume, isnull('Titolo: ' + publicaz.title + '; ','') as dropdown_title FROM [dbo].publicaz WITH (NOLOCK)  LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON publicaz.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].geo_city AS geo_city_publicaz WITH (NOLOCK) ON publicaz.idcity_ed = geo_city_publicaz.idcity LEFT OUTER JOIN [dbo].geo_nation AS geo_nationed WITH (NOLOCK) ON publicaz.idnation_ed = geo_nationed.idnation LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang WITH (NOLOCK) ON publicaz.idnation_lang = geo_nationlang.idnation LEFT OUTER JOIN progetto WITH (NOLOCK) ON publicaz.idprogetto = progetto.idprogetto WHERE  publicaz.idpublicaz IS NOT NULL 

GO

-- CREAZIONE VISTA rendicontattivitaprogettoanagammview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoanagammview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoanagammview]
GO



CREATE VIEW [rendicontattivitaprogettoanagammview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 

GO

-- CREAZIONE VISTA rendicontattivitaprogettoanagview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoanagview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoanagview]
GO



CREATE VIEW [rendicontattivitaprogettoanagview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 

GO

-- CREAZIONE VISTA rendicontattivitaprogettodocview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettodocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettodocview]
GO



CREATE VIEW [rendicontattivitaprogettodocview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 

GO

-- CREAZIONE VISTA rendicontattivitaprogettooraview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettooraview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettooraview]
GO



CREATE VIEW [rendicontattivitaprogettooraview]
AS
SELECT			rendicontattivitaprogettoora.idrendicontattivitaprogettoora, rendicontattivitaprogettoora.idrendicontattivitaprogetto, rendicontattivitaprogettoora.data, 
				rendicontattivitaprogettoora.ore, rendicontattivitaprogettoora.ct, rendicontattivitaprogettoora.cu, rendicontattivitaprogettoora.lt, rendicontattivitaprogettoora.lu, 
				'<b>Progetto:</b> ' + isnull(progetto.title,'') + 
				'; <b>Workpackage:</b> ' + isnull(workpackage.title,'') + 
				'; <b>Attività:</b> ' + isnull(rendicontattivitaprogetto.description,'') + 
				'; <b>Ore:</b> ' +CAST(rendicontattivitaprogettoora.ore AS nvarchar(10)) AS titleancestor, 
                         rendicontattivitaprogetto.idreg
FROM            rendicontattivitaprogettoora 
INNER JOIN		rendicontattivitaprogetto ON rendicontattivitaprogettoora.idrendicontattivitaprogetto = rendicontattivitaprogetto.idrendicontattivitaprogetto
INNER JOIN		workpackage ON workpackage.idworkpackage = rendicontattivitaprogetto.idworkpackage
INNER JOIN		progetto ON progetto.idprogetto = workpackage.idprogetto

GO

-- CREAZIONE VISTA rendicontattivitaprogettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettosegview]
GO



CREATE VIEW [rendicontattivitaprogettosegview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, rendicontattivitaprogetto.idprogetto AS rendicontattivitaprogetto_idprogetto, [dbo].registry.title AS registry_title, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON rendicontattivitaprogetto.idreg = [dbo].registry.idreg WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 

GO

-- CREAZIONE VISTA settoreercsegprogview
IF EXISTS(select * from sysobjects where id = object_id(N'[settoreercsegprogview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [settoreercsegprogview]
GO


GO

-- CREAZIONE VISTA strutturadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[strutturadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [strutturadefaultview]
GO



CREATE VIEW [strutturadefaultview] AS SELECT  struttura.codice AS struttura_codice, struttura.codiceipa AS struttura_codiceipa, struttura.ct AS struttura_ct, struttura.cu AS struttura_cu, struttura.email AS struttura_email, struttura.fax AS struttura_fax, [dbo].aoo.title AS aoo_title, struttura.idaoo AS struttura_idaoo, struttura.idreg AS struttura_idreg, [dbo].sede.title AS sede_title, struttura.idsede AS struttura_idsede, struttura.idstruttura, [dbo].strutturakind.title AS strutturakind_title, struttura.idstrutturakind AS struttura_idstrutturakind, upb.title AS upb_title, struttura.idupb, struttura.lt AS struttura_lt, struttura.lu AS struttura_lu, struttura.telefono AS struttura_telefono, struttura.title, struttura.title_en AS struttura_title_en, isnull('Denominazione: ' + struttura.title + '; ','') + ' ' + isnull('Tipologia: ' + [dbo].strutturakind.title + '; ','') as dropdown_title FROM [dbo].struttura WITH (NOLOCK)  LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON struttura.idaoo = [dbo].aoo.idaoo LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON struttura.idsede = [dbo].sede.idsede LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind LEFT OUTER JOIN upb WITH (NOLOCK) ON struttura.idupb = upb.idupb WHERE  struttura.idstruttura IS NOT NULL 

GO

-- CREAZIONE VISTA strutturaprincview
IF EXISTS(select * from sysobjects where id = object_id(N'[strutturaprincview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [strutturaprincview]
GO



CREATE VIEW [strutturaprincview] AS SELECT  struttura.codice AS struttura_codice, struttura.codiceipa AS struttura_codiceipa, struttura.ct AS struttura_ct, struttura.cu AS struttura_cu, struttura.email AS struttura_email, struttura.fax AS struttura_fax, [dbo].aoo.title AS aoo_title, struttura.idaoo AS struttura_idaoo, struttura.idreg AS struttura_idreg, [dbo].sede.title AS sede_title, struttura.idsede AS struttura_idsede, struttura.idstruttura, [dbo].strutturakind.title AS strutturakind_title, struttura.idstrutturakind AS struttura_idstrutturakind, upb.title AS upb_title, struttura.idupb, struttura.lt AS struttura_lt, struttura.lu AS struttura_lu, struttura.telefono AS struttura_telefono, struttura.title, struttura.title_en AS struttura_title_en, isnull('Denominazione: ' + struttura.title + '; ','') + ' ' + isnull('Tipologia: ' + [dbo].strutturakind.title + '; ','') as dropdown_title FROM [dbo].struttura WITH (NOLOCK)  LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON struttura.idaoo = [dbo].aoo.idaoo LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON struttura.idsede = [dbo].sede.idsede LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind LEFT OUTER JOIN upb WITH (NOLOCK) ON struttura.idupb = upb.idupb WHERE  struttura.idstruttura IS NOT NULL 

GO

-- CREAZIONE VISTA upbsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[upbsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbsegview]
GO



CREATE VIEW [upbsegview] AS SELECT CASE WHEN upb.active = 'S' THEN 'Si' WHEN upb.active = 'N' THEN 'No' END AS upb_active,CASE WHEN upb.assured = 'S' THEN 'Si' WHEN upb.assured = 'N' THEN 'No' END AS upb_assured, upb.cigcode AS upb_cigcode, upb.codeupb, upb.cofogmpcode AS upb_cofogmpcode, upb.ct AS upb_ct, upb.cu AS upb_cu, upb.cupcode AS upb_cupcode, upb.expiration AS upb_expiration, upb.flag AS upb_flag, upb.flagactivity AS upb_flagactivity, upb.flagkind AS upb_flagkind, upb.granted AS upb_granted, upb.idepupbkind AS upb_idepupbkind, upb.idtreasurer AS upb_idtreasurer, upb.idunderwriter AS upb_idunderwriter, upb.idupb, upb.idupb_capofila AS upb_idupb_capofila, upb.lt AS upb_lt, upb.lu AS upb_lu, upb.newcodeupb AS upb_newcodeupb, upb.paridupb AS upb_paridupb, upb.previousappropriation AS upb_previousappropriation, upb.previousassessment AS upb_previousassessment, upb.printingorder AS upb_printingorder, upb.requested AS upb_requested, upb.ri_ra_quota AS upb_ri_ra_quota, upb.ri_rb_quota AS upb_ri_rb_quota, upb.ri_sa_quota AS upb_ri_sa_quota, upb.rtf AS upb_rtf, upb.start AS upb_start, upb.stop AS upb_stop, upb.title AS upb_title, upb.txt AS upb_txt, upb.uesiopecode AS upb_uesiopecode, isnull('Codice: ' + upb.codeupb + '; ','') + ' ' + isnull('Denominazione: ' + upb.title + '; ','') as dropdown_title FROM upb WITH (NOLOCK)  WHERE  upb.idupb IS NOT NULL 

GO

-- CREAZIONE VISTA workpackagesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[workpackagesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [workpackagesegview]
GO



CREATE VIEW [workpackagesegview] AS SELECT  workpackage.acronimo AS workpackage_acronimo, workpackage.ct AS workpackage_ct, workpackage.cu AS workpackage_cu, workpackage.description AS workpackage_description, workpackage.idprogetto, [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, workpackage.idstruttura AS workpackage_idstruttura, workpackage.idworkpackage, workpackage.lt AS workpackage_lt, workpackage.lu AS workpackage_lu, workpackage.raggruppamento, workpackage.title AS workpackage_title, isnull('Raggruppamento: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Titolo: ' + workpackage.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].strutturakind.title + '; ','') as dropdown_title FROM workpackage WITH (NOLOCK)  LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON workpackage.idstruttura = [dbo].struttura.idstruttura LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind WHERE  workpackage.idprogetto IS NOT NULL  AND workpackage.idworkpackage IS NOT NULL 

GO

