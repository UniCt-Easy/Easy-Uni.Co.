
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


-- CREAZIONE TABELLA perfrequestobbunatantum --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfrequestobbunatantum]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfrequestobbunatantum] (
idperfrequestobbunatantum int NOT NULL,
idstruttura int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NULL,
inserito char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
peso decimal(19,2) NULL,
title varchar(1024) NULL,
year int NULL,
 CONSTRAINT xpkperfrequestobbunatantum PRIMARY KEY (idperfrequestobbunatantum,
idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA perfrequestobbunatantum --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'idperfrequestobbunatantum' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD idperfrequestobbunatantum int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantum') and col.name = 'idperfrequestobbunatantum' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantum] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantum') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantum] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantum') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantum] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfrequestobbunatantum] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantum') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantum] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfrequestobbunatantum] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfrequestobbunatantum] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'inserito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD inserito char(1) NULL 
END
ELSE
	ALTER TABLE [perfrequestobbunatantum] ALTER COLUMN inserito char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantum') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantum] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfrequestobbunatantum] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantum') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantum] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfrequestobbunatantum] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'peso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD peso decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfrequestobbunatantum] ALTER COLUMN peso decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [perfrequestobbunatantum] ALTER COLUMN title varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantum' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantum] ADD year int NULL 
END
ELSE
	ALTER TABLE [perfrequestobbunatantum] ALTER COLUMN year int NULL
GO

