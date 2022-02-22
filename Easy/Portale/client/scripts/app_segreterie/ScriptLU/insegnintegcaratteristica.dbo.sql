
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


-- CREAZIONE TABELLA insegnintegcaratteristica --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[insegnintegcaratteristica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[insegnintegcaratteristica] (
idinsegn int NOT NULL,
idinsegninteg int NOT NULL,
idinsegnintegcaratteristica int NOT NULL,
cf decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idsasd int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
profess char(1) NOT NULL,
 CONSTRAINT xpkinsegnintegcaratteristica PRIMARY KEY (idinsegn,
idinsegninteg,
idinsegnintegcaratteristica
)
)
END
GO

-- VERIFICA STRUTTURA insegnintegcaratteristica --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idinsegn' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idinsegn int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'idinsegn' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idinsegninteg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idinsegninteg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'idinsegninteg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idinsegnintegcaratteristica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idinsegnintegcaratteristica int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'idinsegnintegcaratteristica' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD cf decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN cf decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'profess' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD profess char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'profess' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN profess char(1) NOT NULL
GO

