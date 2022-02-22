
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


-- CREAZIONE TABELLA stipendiokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[stipendiokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[stipendiokind] (
idstipendiokind int NOT NULL,
assegnoaggiuntivo decimal(7,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
elementoperequativo decimal(7,2) NULL,
idcontrattokind int NULL,
idinquadramento int NULL,
indennitadiateneo decimal(7,2) NULL,
indennitadiposizione decimal(7,2) NULL,
indintegrativaspeciale decimal(7,2) NULL,
indvacancacontrattuale decimal(7,2) NULL,
irap decimal(7,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
oneriprevidenzialicaricoente decimal(7,2) NULL,
retribuzione decimal(7,2) NULL,
scatto nchar(10) NULL,
tempdef char(1) NULL,
totaletredicesima decimal(7,2) NULL,
tredicesimaindennitaintegrativaspeciale decimal(7,2) NULL,
 CONSTRAINT xpkstipendiokind PRIMARY KEY (idstipendiokind
)
)
END
GO

-- VERIFICA STRUTTURA stipendiokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'idstipendiokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD idstipendiokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendiokind') and col.name = 'idstipendiokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendiokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'assegnoaggiuntivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD assegnoaggiuntivo decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN assegnoaggiuntivo decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendiokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendiokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'elementoperequativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD elementoperequativo decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN elementoperequativo decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'idinquadramento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD idinquadramento int NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN idinquadramento int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'indennitadiateneo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD indennitadiateneo decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN indennitadiateneo decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'indennitadiposizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD indennitadiposizione decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN indennitadiposizione decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'indintegrativaspeciale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD indintegrativaspeciale decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN indintegrativaspeciale decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'indvacancacontrattuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD indvacancacontrattuale decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN indvacancacontrattuale decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'irap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD irap decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN irap decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendiokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendiokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'oneriprevidenzialicaricoente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD oneriprevidenzialicaricoente decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN oneriprevidenzialicaricoente decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'retribuzione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD retribuzione decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN retribuzione decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD scatto nchar(10) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN scatto nchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'tempdef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD tempdef char(1) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN tempdef char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'totaletredicesima' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD totaletredicesima decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN totaletredicesima decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'tredicesimaindennitaintegrativaspeciale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD tredicesimaindennitaintegrativaspeciale decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN tredicesimaindennitaintegrativaspeciale decimal(7,2) NULL
GO

