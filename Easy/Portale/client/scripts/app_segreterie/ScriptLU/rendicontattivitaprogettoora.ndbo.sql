
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

