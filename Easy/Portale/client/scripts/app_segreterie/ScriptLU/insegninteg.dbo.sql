
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE TABELLA insegninteg --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[insegninteg]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[insegninteg] (
idinsegninteg int NOT NULL,
idinsegn int NOT NULL,
codice varchar(50) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
denominazione varchar(256) NULL,
denominazione_en varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkinsegninteg PRIMARY KEY (idinsegninteg,
idinsegn
)
)
END
GO

-- VERIFICA STRUTTURA insegninteg --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegninteg' and C.name = 'idinsegninteg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegninteg] ADD idinsegninteg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegninteg') and col.name = 'idinsegninteg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegninteg] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegninteg' and C.name = 'idinsegn' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegninteg] ADD idinsegn int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegninteg') and col.name = 'idinsegn' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegninteg] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegninteg' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegninteg] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [insegninteg] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegninteg' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegninteg] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegninteg') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegninteg] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegninteg] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegninteg' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegninteg] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegninteg') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegninteg] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegninteg] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegninteg' and C.name = 'denominazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegninteg] ADD denominazione varchar(256) NULL 
END
ELSE
	ALTER TABLE [insegninteg] ALTER COLUMN denominazione varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegninteg' and C.name = 'denominazione_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegninteg] ADD denominazione_en varchar(256) NULL 
END
ELSE
	ALTER TABLE [insegninteg] ALTER COLUMN denominazione_en varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegninteg' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegninteg] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegninteg') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegninteg] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegninteg] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegninteg' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegninteg] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegninteg') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegninteg] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegninteg] ALTER COLUMN lu varchar(64) NOT NULL
GO
