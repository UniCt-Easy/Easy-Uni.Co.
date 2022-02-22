
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


-- CREAZIONE TABELLA bandodsservizio --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandodsservizio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[bandodsservizio] (
idbandodsservizio int NOT NULL,
idbandods int NOT NULL,
alloggio char(1) NULL,
borsafuorisede decimal(9,2) NULL,
borsainsede decimal(9,2) NULL,
borsapendolari decimal(9,2) NULL,
contributo decimal(9,2) NULL,
contributomiimporto decimal(9,2) NULL,
contributomimesi int NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
fuoricorso char(1) NOT NULL,
idbandodsserviziokind int NOT NULL,
idesonero int NULL,
idistattitolistudio_min int NOT NULL,
iseemax decimal(9,2) NULL,
ispemax decimal(9,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maggiorenne char(1) NULL,
mensa char(1) NULL,
parttime char(1) NULL,
primaimmatlivello char(1) NULL,
 CONSTRAINT xpkbandodsservizio PRIMARY KEY (idbandodsservizio,
idbandods
)
)
END
GO

-- VERIFICA STRUTTURA bandodsservizio --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'idbandodsservizio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD idbandodsservizio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsservizio') and col.name = 'idbandodsservizio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsservizio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'idbandods' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD idbandods int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsservizio') and col.name = 'idbandods' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsservizio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'alloggio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD alloggio char(1) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN alloggio char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'borsafuorisede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD borsafuorisede decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN borsafuorisede decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'borsainsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD borsainsede decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN borsainsede decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'borsapendolari' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD borsapendolari decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN borsapendolari decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'contributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD contributo decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN contributo decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'contributomiimporto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD contributomiimporto decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN contributomiimporto decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'contributomimesi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD contributomimesi int NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN contributomimesi int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsservizio') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsservizio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsservizio') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsservizio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'fuoricorso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD fuoricorso char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsservizio') and col.name = 'fuoricorso' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsservizio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN fuoricorso char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'idbandodsserviziokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD idbandodsserviziokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsservizio') and col.name = 'idbandodsserviziokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsservizio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN idbandodsserviziokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'idesonero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD idesonero int NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN idesonero int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'idistattitolistudio_min' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD idistattitolistudio_min int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsservizio') and col.name = 'idistattitolistudio_min' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsservizio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN idistattitolistudio_min int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'iseemax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD iseemax decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN iseemax decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'ispemax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD ispemax decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN ispemax decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsservizio') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsservizio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsservizio') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsservizio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'maggiorenne' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD maggiorenne char(1) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN maggiorenne char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'mensa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD mensa char(1) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN mensa char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'parttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD parttime char(1) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN parttime char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsservizio' and C.name = 'primaimmatlivello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsservizio] ADD primaimmatlivello char(1) NULL 
END
ELSE
	ALTER TABLE [bandodsservizio] ALTER COLUMN primaimmatlivello char(1) NULL
GO

