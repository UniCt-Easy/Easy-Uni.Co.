
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


-- CREAZIONE TABELLA tipologiastudente --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tipologiastudente]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tipologiastudente] (
idtipologiastudente int NOT NULL,
idbandodsservizio int NOT NULL,
idbandods int NOT NULL,
abbreviazione char(1) NULL,
annoiscr int NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idcorsostudiokind int NULL,
immatricolato char(1) NULL,
iscrittobmi char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
passaggio char(1) NULL,
tri char(1) NULL,
 CONSTRAINT xpktipologiastudente PRIMARY KEY (idtipologiastudente,
idbandodsservizio,
idbandods
)
)
END
GO

-- VERIFICA STRUTTURA tipologiastudente --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'idtipologiastudente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD idtipologiastudente int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudente') and col.name = 'idtipologiastudente' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudente] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'idbandodsservizio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD idbandodsservizio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudente') and col.name = 'idbandodsservizio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudente] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'idbandods' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD idbandods int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudente') and col.name = 'idbandods' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudente] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'abbreviazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD abbreviazione char(1) NULL 
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN abbreviazione char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'annoiscr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD annoiscr int NULL 
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN annoiscr int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudente') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudente] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudente') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudente] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'idcorsostudiokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD idcorsostudiokind int NULL 
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN idcorsostudiokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'immatricolato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD immatricolato char(1) NULL 
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN immatricolato char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'iscrittobmi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD iscrittobmi char(1) NULL 
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN iscrittobmi char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudente') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudente] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudente') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudente] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'passaggio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD passaggio char(1) NULL 
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN passaggio char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudente' and C.name = 'tri' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudente] ADD tri char(1) NULL 
END
ELSE
	ALTER TABLE [tipologiastudente] ALTER COLUMN tri char(1) NULL
GO

