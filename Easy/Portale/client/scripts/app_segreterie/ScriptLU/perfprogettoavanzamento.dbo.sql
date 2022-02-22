
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


-- CREAZIONE TABELLA perfprogettoavanzamento --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoavanzamento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogettoavanzamento] (
idperfprogetto int NOT NULL,
idperfprogettoavanzamento int NOT NULL,
avanzamento decimal(18,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data date NULL,
idreg_amministrativi int NULL,
idreg_amministrativi_ver int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkperfprogettoavanzamento PRIMARY KEY (idperfprogetto,
idperfprogettoavanzamento
)
)
END
GO

-- VERIFICA STRUTTURA perfprogettoavanzamento --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'idperfprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD idperfprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'idperfprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'idperfprogettoavanzamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD idperfprogettoavanzamento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'idperfprogettoavanzamento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'avanzamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD avanzamento decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN avanzamento decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD data date NULL 
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'idreg_amministrativi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD idreg_amministrativi int NULL 
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN idreg_amministrativi int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'idreg_amministrativi_ver' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD idreg_amministrativi_ver int NULL 
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN idreg_amministrativi_ver int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN lu varchar(64) NOT NULL
GO

