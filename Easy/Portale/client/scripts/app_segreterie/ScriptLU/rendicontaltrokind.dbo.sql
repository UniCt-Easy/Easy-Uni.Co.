
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


-- CREAZIONE TABELLA rendicontaltrokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontaltrokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[rendicontaltrokind] (
idrendicontaltrokind int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(128) NOT NULL,
 CONSTRAINT xpkrendicontaltrokind PRIMARY KEY (idrendicontaltrokind
)
)
END
GO

-- VERIFICA STRUTTURA rendicontaltrokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltrokind' and C.name = 'idrendicontaltrokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltrokind] ADD idrendicontaltrokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltrokind') and col.name = 'idrendicontaltrokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltrokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltrokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltrokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltrokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltrokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltrokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltrokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltrokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltrokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltrokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltrokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltrokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltrokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltrokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltrokind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [rendicontaltrokind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltrokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltrokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltrokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltrokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltrokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltrokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltrokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltrokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltrokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltrokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltrokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltrokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltrokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltrokind] ADD title varchar(128) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltrokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltrokind] ALTER COLUMN title varchar(128) NOT NULL
GO

