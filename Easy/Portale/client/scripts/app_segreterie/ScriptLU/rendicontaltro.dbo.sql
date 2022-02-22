
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


-- CREAZIONE TABELLA rendicontaltro --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontaltro]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[rendicontaltro] (
idrendicontaltro int NOT NULL,
aa varchar(9) NOT NULL,
idreg_docenti int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data date NOT NULL,
idrendicontaltrokind int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ore decimal(9,2) NOT NULL,
 CONSTRAINT xpkrendicontaltro PRIMARY KEY (idrendicontaltro,
aa,
idreg_docenti
)
)
END
GO

-- VERIFICA STRUTTURA rendicontaltro --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'idrendicontaltro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD idrendicontaltro int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'idrendicontaltro' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD data date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'data' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN data date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'idrendicontaltrokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD idrendicontaltrokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'idrendicontaltrokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN idrendicontaltrokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'ore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD ore decimal(9,2) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'ore' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN ore decimal(9,2) NOT NULL
GO

