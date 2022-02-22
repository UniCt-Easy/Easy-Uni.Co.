
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


-- CREAZIONE TABELLA studdirittokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[studdirittokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[studdirittokind] (
idstuddirittokind int NOT NULL,
active char(1) NOT NULL,
description varchar(512) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortorder int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkstuddirittokind PRIMARY KEY (idstuddirittokind
)
)
END
GO

-- VERIFICA STRUTTURA studdirittokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studdirittokind' and C.name = 'idstuddirittokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studdirittokind] ADD idstuddirittokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studdirittokind') and col.name = 'idstuddirittokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studdirittokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studdirittokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studdirittokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studdirittokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studdirittokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studdirittokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studdirittokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studdirittokind] ADD description varchar(512) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studdirittokind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studdirittokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studdirittokind] ALTER COLUMN description varchar(512) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studdirittokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studdirittokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [studdirittokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studdirittokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studdirittokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [studdirittokind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studdirittokind' and C.name = 'sortorder' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studdirittokind] ADD sortorder int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studdirittokind') and col.name = 'sortorder' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studdirittokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studdirittokind] ALTER COLUMN sortorder int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studdirittokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studdirittokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studdirittokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studdirittokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studdirittokind] ALTER COLUMN title varchar(50) NOT NULL
GO

