
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


--setuser 'amministrazione'
-- CREAZIONE TABELLA progettotipocosto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotipocosto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotipocosto] (
idprogettotipocosto int NOT NULL,
idprogetto int NOT NULL,
ammissibilita decimal(5,2) NULL,
budgetrichiesto decimal(19,2) NULL,
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'budgetrichiesto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD budgetrichiesto decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN budgetrichiesto decimal(19,2) NULL
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

-- CREAZIONE TABELLA progetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progetto] (
idprogetto int NOT NULL,
bandoriferimentotxt nvarchar(2048) NULL,
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
dataesito date NULL,
description nvarchar(max) NULL,
durata int NULL,
finanziamento nvarchar(max) NULL,
finanziatoretxt nvarchar(2048) NULL,
idcorsostudio int NULL,
idcurrency int NULL,
idduratakind int NULL,
idpartnerkind int NULL,
idprogettokind int NULL,
idprogettostatuskind int NULL,
idreg int NULL,
idreg_amm int NULL,
idreg_aziende int NULL,
idreg_aziende_fin int NULL,
idregistryprogfin int NULL,
idregistryprogfinbando int NULL,
idstrumentofin int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
progfinanziamentotxt nvarchar(2048) NULL,
start date NULL,
stop date NULL,
title nvarchar(4000) NULL,
title_en nvarchar(4000) NULL,
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'bandoriferimentotxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD bandoriferimentotxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN bandoriferimentotxt nvarchar(2048) NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'dataesito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD dataesito date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN dataesito date NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'finanziamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD finanziamento nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN finanziamento nvarchar(max) NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idpartnerkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idpartnerkind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idpartnerkind int NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg_amm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg_amm int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg_amm int NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idstrumentofin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idstrumentofin int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idstrumentofin int NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'progfinanziamentotxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD progfinanziamentotxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN progfinanziamentotxt nvarchar(2048) NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD title_en nvarchar(4000) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN title_en nvarchar(4000) NULL
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

-- CREAZIONE VISTA progettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettosegview]
GO

CREATE VIEW [progettosegview] AS 
SELECT  progetto.bandoriferimentotxt AS progetto_bandoriferimentotxt, progetto.budget AS progetto_budget, progetto.budgetcalcolato AS progetto_budgetcalcolato, progetto.budgetcalcolatodate AS progetto_budgetcalcolatodate, progetto.capofilatxt AS progetto_capofilatxt, progetto.codiceidentificativo AS progetto_codiceidentificativo, progetto.contributo AS progetto_contributo, progetto.contributoente AS progetto_contributoente, progetto.ct AS progetto_ct, progetto.cu AS progetto_cu, progetto.cup AS progetto_cup, progetto.data AS progetto_data, progetto.datacontabile AS progetto_datacontabile, progetto.dataesito AS progetto_dataesito, progetto.description AS progetto_description, progetto.durata AS progetto_durata, progetto.finanziamento AS progetto_finanziamento, progetto.finanziatoretxt AS progetto_finanziatoretxt,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, progetto.idcorsostudio,
 [dbo].currency.codecurrency AS currency_codecurrency, progetto.idcurrency,
 [dbo].duratakind.title AS duratakind_title, progetto.idduratakind AS progetto_idduratakind,
 [dbo].partnerkind.title AS partnerkind_title, progetto.idpartnerkind AS progetto_idpartnerkind, progetto.idprogetto,
 [dbo].progettokind.title AS progettokind_title, progetto.idprogettokind AS progetto_idprogettokind,
 [dbo].progettostatuskind.title AS progettostatuskind_title, progetto.idprogettostatuskind AS progetto_idprogettostatuskind,
 [dbo].registry.title AS registry_title, progetto.idreg,
 [dbo].title.description AS title_description, registryamm.idtitle AS registryamm_idtitle, registryamm.surname AS registryamm_surname, registryamm.forename AS registryamm_forename, registryamm.cf AS registryamm_cf, progetto.idreg_amm,
 registryaziende.title AS registryaziende_title, progetto.idreg_aziende,
 registryaziende_fin.title AS registryaziende_fin_title, progetto.idreg_aziende_fin,
 [dbo].registryprogfin.title AS registryprogfin_title, [dbo].registryprogfin.code AS registryprogfin_code, progetto.idregistryprogfin AS progetto_idregistryprogfin,
 [dbo].registryprogfinbando.title AS registryprogfinbando_title, [dbo].registryprogfinbando.number AS registryprogfinbando_number, [dbo].registryprogfinbando.scadenza AS registryprogfinbando_scadenza, progetto.idregistryprogfinbando AS progetto_idregistryprogfinbando,
 [dbo].strumentofin.title AS strumentofin_title, progetto.idstrumentofin, progetto.lt AS progetto_lt, progetto.lu AS progetto_lu, progetto.progfinanziamentotxt AS progetto_progfinanziamentotxt, progetto.start AS progetto_start, progetto.stop AS progetto_stop, progetto.title AS progetto_title, progetto.title_en AS progetto_title_en, progetto.titolobreve, progetto.totalbudget AS progetto_totalbudget, progetto.totalcontributo AS progetto_totalcontributo, progetto.url AS progetto_url,
 isnull('Titolo breve o acronimo: ' + progetto.titolobreve + '; ','') as dropdown_title
FROM progetto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON progetto.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].currency WITH (NOLOCK) ON progetto.idcurrency = [dbo].currency.idcurrency
LEFT OUTER JOIN [dbo].duratakind WITH (NOLOCK) ON progetto.idduratakind = [dbo].duratakind.idduratakind
LEFT OUTER JOIN [dbo].partnerkind WITH (NOLOCK) ON progetto.idpartnerkind = [dbo].partnerkind.idpartnerkind
LEFT OUTER JOIN [dbo].progettokind WITH (NOLOCK) ON progetto.idprogettokind = [dbo].progettokind.idprogettokind
LEFT OUTER JOIN [dbo].progettostatuskind WITH (NOLOCK) ON progetto.idprogettostatuskind = [dbo].progettostatuskind.idprogettostatuskind
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON progetto.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].registry AS registryamm WITH (NOLOCK) ON progetto.idreg_amm = registryamm.idreg
LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registryamm.idtitle = [dbo].title.idtitle
LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON progetto.idreg_aziende = registry_aziendeaziende.idreg
LEFT OUTER JOIN [dbo].registry AS registryaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registryaziende.idreg
LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende_fin WITH (NOLOCK) ON progetto.idreg_aziende_fin = registry_aziendeaziende_fin.idreg
LEFT OUTER JOIN [dbo].registry AS registryaziende_fin WITH (NOLOCK) ON registry_aziendeaziende_fin.idreg = registryaziende_fin.idreg
LEFT OUTER JOIN [dbo].registryprogfin WITH (NOLOCK) ON progetto.idregistryprogfin = [dbo].registryprogfin.idregistryprogfin
LEFT OUTER JOIN [dbo].registryprogfinbando WITH (NOLOCK) ON progetto.idregistryprogfinbando = [dbo].registryprogfinbando.idregistryprogfinbando
LEFT OUTER JOIN [dbo].strumentofin WITH (NOLOCK) ON progetto.idstrumentofin = [dbo].strumentofin.idstrumentofin
WHERE  progetto.idprogetto IS NOT NULL 
GO

-- CREAZIONE VISTA strutturaperfview
IF EXISTS(select * from sysobjects where id = object_id(N'[strutturaperfview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [strutturaperfview]
GO

CREATE VIEW [strutturaperfview] AS 
SELECT  struttura.codice AS struttura_codice, struttura.codiceipa AS struttura_codiceipa, struttura.ct AS struttura_ct, struttura.cu AS struttura_cu, struttura.email AS struttura_email, struttura.fax AS struttura_fax, struttura.idaoo AS struttura_idaoo, struttura.idreg AS struttura_idreg, struttura.idsede AS struttura_idsede, struttura.idstruttura,
 [dbo].strutturakind.title AS strutturakind_title, struttura.idstrutturakind AS struttura_idstrutturakind,
 upb.title AS upb_title, struttura.idupb, struttura.lt AS struttura_lt, struttura.lu AS struttura_lu,
 strutturaparent.title AS strutturaparent_title, strutturakind_struttura.title AS strutturakind_struttura_title, strutturaparent.idstrutturakind AS strutturaparent_idstrutturakind, struttura.paridstruttura, struttura.pesoindicatori AS struttura_pesoindicatori, struttura.pesoobiettivi AS struttura_pesoobiettivi, struttura.pesoprogaltreuo AS struttura_pesoprogaltreuo, struttura.pesoproguo AS struttura_pesoproguo, struttura.telefono AS struttura_telefono, struttura.title, struttura.title_en AS struttura_title_en,
 isnull('Denominazione: ' + struttura.title + '; ','') as dropdown_title
FROM [dbo].struttura WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
LEFT OUTER JOIN upb WITH (NOLOCK) ON struttura.idupb = upb.idupb
LEFT OUTER JOIN [dbo].struttura AS strutturaparent WITH (NOLOCK) ON struttura.paridstruttura = strutturaparent.idstruttura
LEFT OUTER JOIN [dbo].strutturakind AS strutturakind_struttura WITH (NOLOCK) ON strutturaparent.idstrutturakind = strutturakind_struttura.idstrutturakind
WHERE  struttura.idstruttura IS NOT NULL 
GO

-- CREAZIONE VISTA strutturaseg_childview
IF EXISTS(select * from sysobjects where id = object_id(N'[strutturaseg_childview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [strutturaseg_childview]
GO

CREATE VIEW [strutturaseg_childview] AS 
SELECT  struttura.codice AS struttura_codice, struttura.codiceipa AS struttura_codiceipa, struttura.ct AS struttura_ct, struttura.cu AS struttura_cu, struttura.email AS struttura_email, struttura.fax AS struttura_fax,
 [dbo].aoo.title AS aoo_title, struttura.idaoo AS struttura_idaoo,
 [dbo].registry.title AS registry_title, struttura.idreg,
 [dbo].sede.title AS sede_title, struttura.idsede AS struttura_idsede, struttura.idstruttura,
 [dbo].strutturakind.title AS strutturakind_title, struttura.idstrutturakind,
 upb.title AS upb_title, struttura.idupb, struttura.lt AS struttura_lt, struttura.lu AS struttura_lu,
 strutturaparent.title AS strutturaparent_title, strutturakind_struttura.title AS strutturakind_struttura_title, strutturaparent.idstrutturakind AS strutturaparent_idstrutturakind, struttura.paridstruttura, struttura.pesoindicatori AS struttura_pesoindicatori, struttura.pesoobiettivi AS struttura_pesoobiettivi, struttura.pesoprogaltreuo AS struttura_pesoprogaltreuo, struttura.pesoproguo AS struttura_pesoproguo, struttura.telefono AS struttura_telefono, struttura.title AS struttura_title, struttura.title_en AS struttura_title_en,
 isnull('Tipo: ' + [dbo].strutturakind.title + '; ','') + ' ' + isnull('Denominazione: ' + struttura.title + '; ','') as dropdown_title
FROM [dbo].struttura WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON struttura.idaoo = [dbo].aoo.idaoo
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON struttura.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON struttura.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
LEFT OUTER JOIN upb WITH (NOLOCK) ON struttura.idupb = upb.idupb
LEFT OUTER JOIN [dbo].struttura AS strutturaparent WITH (NOLOCK) ON struttura.paridstruttura = strutturaparent.idstruttura
LEFT OUTER JOIN [dbo].strutturakind AS strutturakind_struttura WITH (NOLOCK) ON strutturaparent.idstrutturakind = strutturakind_struttura.idstrutturakind
WHERE  struttura.idstruttura IS NOT NULL 
GO

-- CREAZIONE VISTA strutturaprincview
IF EXISTS(select * from sysobjects where id = object_id(N'[strutturaprincview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [strutturaprincview]
GO

CREATE VIEW [strutturaprincview] AS 
SELECT  struttura.codice AS struttura_codice, struttura.codiceipa AS struttura_codiceipa, struttura.ct AS struttura_ct, struttura.cu AS struttura_cu, struttura.email AS struttura_email, struttura.fax AS struttura_fax,
 [dbo].aoo.title AS aoo_title, struttura.idaoo AS struttura_idaoo, struttura.idreg AS struttura_idreg,
 [dbo].sede.title AS sede_title, struttura.idsede AS struttura_idsede, struttura.idstruttura,
 [dbo].strutturakind.title AS strutturakind_title, struttura.idstrutturakind AS struttura_idstrutturakind,
 upb.title AS upb_title, struttura.idupb, struttura.lt AS struttura_lt, struttura.lu AS struttura_lu, struttura.paridstruttura AS struttura_paridstruttura, struttura.pesoindicatori AS struttura_pesoindicatori, struttura.pesoobiettivi AS struttura_pesoobiettivi, struttura.pesoprogaltreuo AS struttura_pesoprogaltreuo, struttura.pesoproguo AS struttura_pesoproguo, struttura.telefono AS struttura_telefono, struttura.title, struttura.title_en AS struttura_title_en,
 isnull('Denominazione: ' + struttura.title + '; ','') + ' ' + isnull('Tipo: ' + [dbo].strutturakind.title + '; ','') as dropdown_title
FROM [dbo].struttura WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON struttura.idaoo = [dbo].aoo.idaoo
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON struttura.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
LEFT OUTER JOIN upb WITH (NOLOCK) ON struttura.idupb = upb.idupb
WHERE  struttura.idstruttura IS NOT NULL 
GO

-- CREAZIONE VISTA strutturadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[strutturadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [strutturadefaultview]
GO

CREATE VIEW [strutturadefaultview] AS 
SELECT  struttura.codice AS struttura_codice, struttura.codiceipa AS struttura_codiceipa, struttura.ct AS struttura_ct, struttura.cu AS struttura_cu, struttura.email AS struttura_email, struttura.fax AS struttura_fax,
 [dbo].aoo.title AS aoo_title, struttura.idaoo AS struttura_idaoo, struttura.idreg AS struttura_idreg,
 [dbo].sede.title AS sede_title, struttura.idsede AS struttura_idsede, struttura.idstruttura,
 [dbo].strutturakind.title AS strutturakind_title, struttura.idstrutturakind AS struttura_idstrutturakind,
 upb.title AS upb_title, struttura.idupb, struttura.lt AS struttura_lt, struttura.lu AS struttura_lu,
 strutturaparent.title AS strutturaparent_title, strutturakind_struttura.title AS strutturakind_struttura_title, strutturaparent.idstrutturakind AS strutturaparent_idstrutturakind, struttura.paridstruttura, struttura.pesoindicatori AS struttura_pesoindicatori, struttura.pesoobiettivi AS struttura_pesoobiettivi, struttura.pesoprogaltreuo AS struttura_pesoprogaltreuo, struttura.pesoproguo AS struttura_pesoproguo, struttura.telefono AS struttura_telefono, struttura.title, struttura.title_en AS struttura_title_en,
 isnull('Denominazione: ' + struttura.title + '; ','') + ' ' + isnull('Tipo: ' + [dbo].strutturakind.title + '; ','') as dropdown_title
FROM [dbo].struttura WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON struttura.idaoo = [dbo].aoo.idaoo
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON struttura.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
LEFT OUTER JOIN upb WITH (NOLOCK) ON struttura.idupb = upb.idupb
LEFT OUTER JOIN [dbo].struttura AS strutturaparent WITH (NOLOCK) ON struttura.paridstruttura = strutturaparent.idstruttura
LEFT OUTER JOIN [dbo].strutturakind AS strutturakind_struttura WITH (NOLOCK) ON strutturaparent.idstrutturakind = strutturakind_struttura.idstrutturakind
WHERE  struttura.idstruttura IS NOT NULL 
GO

-- CREAZIONE VISTA publicazdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[publicazdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [publicazdefaultview]
GO

CREATE VIEW [publicazdefaultview] AS 
SELECT  publicaz.abstractstring AS publicaz_abstractstring, publicaz.annocopyright AS publicaz_annocopyright, publicaz.annopub AS publicaz_annopub, publicaz.ct AS publicaz_ct, publicaz.cu AS publicaz_cu, publicaz.editore AS publicaz_editore, publicaz.fascicolo AS publicaz_fascicolo,
 [dbo].geo_city.title AS geo_city_title, publicaz.idcity,
 geo_cityed.title AS geo_cityed_title, publicaz.idcity_ed,
 geo_nationed.title AS geo_nationed_title, publicaz.idnation_ed,
 geo_nationlang.title AS geo_nationlang_title, publicaz.idnation_lang,
 progetto.titolobreve AS progetto_titolobreve, publicaz.idprogetto, publicaz.idpublicaz, publicaz.isbn AS publicaz_isbn, publicaz.lt AS publicaz_lt, publicaz.lu AS publicaz_lu, publicaz.numrivista AS publicaz_numrivista, publicaz.pagestart AS publicaz_pagestart, publicaz.pagestop AS publicaz_pagestop, publicaz.pagetot AS publicaz_pagetot, publicaz.title, publicaz.title2 AS publicaz_title2, publicaz.volume AS publicaz_volume,
 isnull('Titolo: ' + publicaz.title + '; ','') as dropdown_title
FROM [dbo].publicaz WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON publicaz.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].geo_city AS geo_cityed WITH (NOLOCK) ON publicaz.idcity_ed = geo_cityed.idcity
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationed WITH (NOLOCK) ON publicaz.idnation_ed = geo_nationed.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang WITH (NOLOCK) ON publicaz.idnation_lang = geo_nationlang.idnation
LEFT OUTER JOIN progetto WITH (NOLOCK) ON publicaz.idprogetto = progetto.idprogetto
WHERE  publicaz.idpublicaz IS NOT NULL 
GO

-- CREAZIONE VISTA estimatedetailexpworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[estimatedetailexpworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimatedetailexpworkpackageview]
GO


-- Per estimatedetail è sufficiente che progettoricavo vada in join con idrelated, perchè l'idrelated ha il rownum


CREATE        VIEW [estimatedetailexpworkpackageview]
as
select 
	I.idestimkind, I.yestim, I.nestim,
	I.description as descriptionestimate,
	substring('Doc.CA:' + I.doc,1,35) as doc,
	I.docdate,
	DET.rownum,
	DET.idupb,
	'estim' + '§' + convert(varchar(4), DET.idestimkind) + '§'  + convert(varchar(4), DET.yestim) + '§'  + convert(varchar(14),DET.nestim)+ '§'  + convert(varchar(10),DET.rownum) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	v.idinc as idincproceed,
	-- IMPONIBILE 
		CONVERT(decimal(19,2),
		ROUND(DET.taxable * DET.number * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(DET.discount, 0.0)))
		 ,2
		)) as taxable_euro,
	-- IVA
	CONVERT(decimal(19,2),ROUND(DET.tax,2))
			 as iva_euro,
-- Calcola il pagato
	ISNULL(v.amount, 0) AS proceedamount,
	PC.idprogettoricavo
from estimate I 
JOIN estimatekind 		
	ON estimatekind.idestimkind = I.idestimkind
join estimatedetail DET 
	ON I.idestimkind = DET.idestimkind  and I.yestim = DET.yestim and I.nestim = DET.nestim
join progettotiporicavoaccmotive PM 	
	on PM.idaccmotive = DET.idaccmotive 
join progettotipocosto PTC		/*Tipo voce ricavo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
join progetto P 
	on PM.idprogetto = P.idprogetto
join workpackageupb WPU 
	on WPU.idprogetto = P.idprogetto and WPU.idupb = DET.idupb
join workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
left outer join incomelastestimatedetail v 
				on	v.idestimkind = DET.idestimkind AND	 v.yestim = DET.yestim AND	 v.nestim = DET.nestim AND		 v.rownum = DET.rownum
left outer join progettoricavo PC
	on 'estim' + '§' + convert(varchar(4), DET.idestimkind) + '§'  + convert(varchar(4), DET.yestim) + '§'  + convert(varchar(14),DET.nestim)+ '§'  + convert(varchar(10),DET.rownum) = PC.idrelated
WHERE estimatekind.linktoinvoice = 'N'

GO

-- VERIFICA DI estimatedetailexpworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'estimatedetailexpworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','descriptionestimate','150','''assistenza''','varchar(150)','estimatedetailexpworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','estimatedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','35','''assistenza''','varchar(35)','estimatedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','docdate','3','''assistenza''','date','estimatedetailexpworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idestimkind','20','''assistenza''','varchar(20)','estimatedetailexpworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idincproceed','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettoricavo','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotiporicavo','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','41','''assistenza''','varchar(41)','estimatedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','estimatedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','iva_euro','9','''assistenza''','decimal(19,2)','estimatedetailexpworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nestim','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','proceedamount','9','''assistenza''','decimal(19,2)','estimatedetailexpworkpackageview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','4000','''assistenza''','nvarchar(4000)','estimatedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','rownum','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','taxable_euro','9','''assistenza''','decimal(19,2)','estimatedetailexpworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','estimatedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','yestim','2','''assistenza''','smallint','estimatedetailexpworkpackageview','','','','','N','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI estimatedetailexpworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'estimatedetailexpworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'estimatedetailexpworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('estimatedetailexpworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE PROCEDURE [compute_assetdiaryora]
IF EXISTS (select * from sysobjects where id = object_id(N'[compute_assetdiaryora]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [compute_assetdiaryora]
GO
CREATE PROCEDURE [compute_assetdiaryora] 
(
	@max_ayear int, 
	@max_mese int,
	@idprogetto int
)
as begin 
--185.56.8.51,5839
-- Per ogni mese si calcola la proporzione di ore di utilizzo dell'asset

	create table #oremesicespite(sommeore int, mese int, idasset int, idpiece int, ayear int)
	--sommeore : indica quante ore Ã¨ stato usato il bene nel mese indicato @max_mese

	;WITH curr_asset (idassetdiary, idpiece) as
	(
	select idassetdiary, idpiece 
	from 	assetdiary
	where idprogetto = @idprogetto
	group by idassetdiary, idpiece 
	)
	insert into #oremesicespite(sommeore, idasset, idpiece , ayear, mese)
	select	sum(DATEDIFF(hour, ADETT.start, ADETT.stop)) as SommaOreDx,
			AD.idasset, 
			AD.idpiece, --, AD.idprogetto
			year(ADETT.start), month(ADETT.start)
	 from assetdiary AD 
	join  assetdiaryora ADETT 
		on AD.idassetdiary = ADETT.idassetdiary
	join asset A 
		on AD.idasset = A.idasset and AD.idpiece = A.idpiece
	join curr_asset CA
		on CA.idassetdiary = A.idasset and CA.idpiece = A.idpiece
		where month(ADETT.start) <= @max_mese 
		and year (ADETT.start) <= @max_ayear		
		-- Vanno considerati solo i cespiti che hanno una class. inventariale associata ad un Tipo costo
		and exists (select * from  assetacquire	
				JOIN inventorytree 		ON inventorytree.idinv = assetacquire.idinv
				join inventorytreelink  on  inventorytreelink.idchild = assetacquire.idinv
				join progettotipocostoinventorytree on progettotipocostoinventorytree.idinv = inventorytreelink.idparent
				where assetacquire.nassetacquire = A.nassetacquire
			)
	group by year(ADETT.start),month(ADETT.start), AD.idasset, AD.idpiece --, AD.idprogetto
	
	-- Per ogni cespite calcola l'ammortamento annuo e poi farÃ  diviso 12
	DECLARE @dec_31 datetime
	declare @assetvalue_to_date decimal(19,2)
	declare @actualvalue_to_date decimal(19,2)

	DECLARE @idasset int
	DECLARE @idpiece int
	DECLARE @ayear int
	
	create table #ammortamenti(importo decimal(19,2), idasset int, idpiece int, ayear int)
	
	DECLARE amt_crs1 INSENSITIVE CURSOR FOR
	SELECT 
		idasset, idpiece, ayear
	FROM #oremesicespite
	FOR READ ONLY
	OPEN amt_crs1
	
	FETCH NEXT FROM amt_crs1 INTO @idasset, @idpiece, @ayear
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SELECT  @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)
		EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue_to_date OUTPUT, @actualvalue_to_date OUTPUT 
		if (@assetvalue_to_date>0)
		begin
			-- in questa tebella metterÃ  tutti i valori dell'Ammortamento, cosÃ¬ dopo potrÃ  fare direttamente il JOIN piuttosto che fare l'UPDATE su #oremesicespite
			insert into #ammortamenti(importo, idasset, idpiece, ayear)
			values(@actualvalue_to_date, @idasset, @idpiece, @ayear) 
		end
	
		FETCH NEXT FROM amt_crs1 INTO  @idasset, @idpiece, @ayear
		END

	DEALLOCATE amt_crs1
	
	--Calcola il valore da scrivere in amount di assetdiaryora come:
	-- (ore dell'i-esima riga di assetdiaryora / Somma delle ore di quell'asset) * Ammortamento cespite
	select case when isnull(AMM.importo,0)>0
			then CONVERT(decimal(19,2), DATEDIFF(hour, ADETT.start, ADETT.stop)) /(convert(decimal(19,2),O.sommeore))  
									* ( isnull(AMM.importo,1)/12) 
			else  CONVERT(decimal(19,2), DATEDIFF(hour, ADETT.start, ADETT.stop)) /(convert(decimal(19,2),O.sommeore))  
			end	as amount ,
	ADETT.idassetdiary, ADETT.idassetdiaryora
	from assetdiary A 
	join  assetdiaryora ADETT 
		on A.idassetdiary = ADETT.idassetdiary and A.idprogetto = @idprogetto --> deve valorizzare solo le righe del progetto specificato.
	join #oremesicespite O
		on A.idasset = O.idasset and A.idpiece = O.idpiece
	LEFT OUTER join #ammortamenti AMM
		on AMM.idasset = O.idasset and AMM.idpiece = O.idpiece and AMM.ayear = O.ayear
	where O.sommeore<>0 and O.mese = month(ADETT.start) and O.ayear = year(ADETT.start)
	order by ADETT.idassetdiary, ADETT.idassetdiaryora

	drop table #oremesicespite

END
GO
