
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


-- CREAZIONE TABELLA convalidato --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[convalidato]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[convalidato] (
idconvalidato int NOT NULL,
idconvalida int NOT NULL,
idreg int NOT NULL,
changesother varchar(max) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idattivform int NOT NULL,
idchanges int NULL,
idchangeskind int NULL,
iddichiar int NULL,
iddidprog int NULL,
idiscrizione int NULL,
idiscrizione_from int NULL,
idiscrizionebmi int NULL,
idistanza int NULL,
idlearningagrstud int NULL,
idlearningagrtrainer int NULL,
idpratica int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkconvalidato PRIMARY KEY (idconvalidato,
idconvalida,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA convalidato --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idconvalidato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idconvalidato int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalidato') and col.name = 'idconvalidato' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalidato] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idconvalida' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idconvalida int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalidato') and col.name = 'idconvalida' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalidato] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalidato') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalidato] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'changesother' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD changesother varchar(max) NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN changesother varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalidato') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalidato] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalidato') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalidato] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idattivform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idattivform int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalidato') and col.name = 'idattivform' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalidato] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN idattivform int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idchanges' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idchanges int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN idchanges int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idchangeskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idchangeskind int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN idchangeskind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'iddichiar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD iddichiar int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN iddichiar int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD iddidprog int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN iddidprog int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idiscrizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idiscrizione int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN idiscrizione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idiscrizione_from' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idiscrizione_from int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN idiscrizione_from int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idiscrizionebmi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idiscrizionebmi int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN idiscrizionebmi int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idistanza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idistanza int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN idistanza int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idlearningagrstud' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idlearningagrstud int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN idlearningagrstud int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idlearningagrtrainer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idlearningagrtrainer int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN idlearningagrtrainer int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'idpratica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD idpratica int NULL 
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN idpratica int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalidato') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalidato] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalidato' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalidato] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalidato') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalidato] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convalidato] ALTER COLUMN lu varchar(64) NOT NULL
GO

