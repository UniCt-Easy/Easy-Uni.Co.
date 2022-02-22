
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


-- CREAZIONE TABELLA perfprogettoobiettivoattivita --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivoattivita]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogettoobiettivoattivita] (
idperfprogetto int NOT NULL,
idperfprogettoobiettivo int NOT NULL,
idperfprogettoobiettivoattivita int NOT NULL,
completamento decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datafineeffettiva datetime NULL,
datafineprevista datetime NULL,
datainizioeffettiva datetime NULL,
datainizioprevista datetime NULL,
description varchar(max) NULL,
idreg int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridperfprogettoobiettivoattivita int NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkperfprogettoobiettivoattivita PRIMARY KEY (idperfprogetto,
idperfprogettoobiettivo,
idperfprogettoobiettivoattivita
)
)
END
GO

-- VERIFICA STRUTTURA perfprogettoobiettivoattivita --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'idperfprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD idperfprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'idperfprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'idperfprogettoobiettivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD idperfprogettoobiettivo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'idperfprogettoobiettivo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'idperfprogettoobiettivoattivita' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD idperfprogettoobiettivoattivita int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'idperfprogettoobiettivoattivita' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'completamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD completamento decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN completamento decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'datafineeffettiva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD datafineeffettiva datetime NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN datafineeffettiva datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'datafineprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD datafineprevista datetime NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN datafineprevista datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'datainizioeffettiva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD datainizioeffettiva datetime NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN datainizioeffettiva datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'datainizioprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD datainizioprevista datetime NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN datainizioprevista datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'paridperfprogettoobiettivoattivita' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD paridperfprogettoobiettivoattivita int NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN paridperfprogettoobiettivoattivita int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN title varchar(1024) NULL
GO

