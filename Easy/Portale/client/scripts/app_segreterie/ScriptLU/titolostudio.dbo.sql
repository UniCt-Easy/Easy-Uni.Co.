
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


-- CREAZIONE TABELLA titolostudio --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[titolostudio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[titolostudio] (
idtitolostudio int NOT NULL,
idreg int NOT NULL,
aa varchar(9) NOT NULL,
conseguito char(1) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
data date NULL,
giudizio varchar(50) NULL,
idattach int NULL,
idistattitolistudio int NOT NULL,
idreg_istituti int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
voto int NULL,
votolode char(1) NULL,
votosu int NULL,
 CONSTRAINT xpktitolostudio PRIMARY KEY (idtitolostudio,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA titolostudio --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'idtitolostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD idtitolostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolostudio') and col.name = 'idtitolostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolostudio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolostudio') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolostudio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD aa varchar(9) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolostudio') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN aa varchar(9) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'conseguito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD conseguito char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolostudio') and col.name = 'conseguito' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN conseguito char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD data date NULL 
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'giudizio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD giudizio varchar(50) NULL 
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN giudizio varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'idattach' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD idattach int NULL 
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN idattach int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'idistattitolistudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD idistattitolistudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolostudio') and col.name = 'idistattitolistudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN idistattitolistudio int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'idreg_istituti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD idreg_istituti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolostudio') and col.name = 'idreg_istituti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN idreg_istituti int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'voto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD voto int NULL 
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN voto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'votolode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD votolode char(1) NULL 
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN votolode char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolostudio' and C.name = 'votosu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolostudio] ADD votosu int NULL 
END
ELSE
	ALTER TABLE [titolostudio] ALTER COLUMN votosu int NULL
GO

