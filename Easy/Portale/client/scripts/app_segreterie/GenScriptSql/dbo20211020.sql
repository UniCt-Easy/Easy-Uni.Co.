
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


-- CREAZIONE TABELLA analisiannuale --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[analisiannuale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[analisiannuale] (
year int NOT NULL,
 CONSTRAINT xpkanalisiannuale PRIMARY KEY (year
)
)
END
GO

-- VERIFICA STRUTTURA analisiannuale --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('analisiannuale') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [analisiannuale] drop constraint '+@vincolo)
END
GO

-- CREAZIONE TABELLA stipendioannuo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[stipendioannuo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[stipendioannuo] (
idstipendioannuo int NOT NULL,
year int NOT NULL,
caricoente decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idcontratto int NULL,
idreg int NOT NULL,
irap decimal(19,2) NULL,
lordo decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
totale decimal(19,2) NULL,
 CONSTRAINT xpkstipendioannuo PRIMARY KEY (idstipendioannuo,
year
)
)
END
GO

-- VERIFICA STRUTTURA stipendioannuo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'idstipendioannuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD idstipendioannuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'idstipendioannuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'caricoente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD caricoente decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN caricoente decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'idcontratto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD idcontratto int NULL 
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN idcontratto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'irap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD irap decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN irap decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'lordo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD lordo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN lordo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'totale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD totale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN totale decimal(19,2) NULL
GO

-- CREAZIONE TABELLA pcsconfigurazionecostopuntoincr --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcsconfigurazionecostopuntoincr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pcsconfigurazionecostopuntoincr] (
year int NOT NULL,
idpcsconfigurazionecostopuntoincr int NOT NULL,
costo decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
incrementodocenti decimal(19,6) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpcsconfigurazionecostopuntoincr PRIMARY KEY (year,
idpcsconfigurazionecostopuntoincr
)
)
END
GO

-- VERIFICA STRUTTURA pcsconfigurazionecostopuntoincr --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopuntoincr' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopuntoincr') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopuntoincr] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopuntoincr' and C.name = 'idpcsconfigurazionecostopuntoincr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ADD idpcsconfigurazionecostopuntoincr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopuntoincr') and col.name = 'idpcsconfigurazionecostopuntoincr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopuntoincr] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopuntoincr' and C.name = 'costo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ADD costo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ALTER COLUMN costo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopuntoincr' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopuntoincr') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopuntoincr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopuntoincr' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopuntoincr') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopuntoincr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopuntoincr' and C.name = 'incrementodocenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ADD incrementodocenti decimal(19,6) NULL 
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ALTER COLUMN incrementodocenti decimal(19,6) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopuntoincr' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopuntoincr') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopuntoincr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopuntoincr' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopuntoincr') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopuntoincr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopuntoincr] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE TABELLA pcsconfigurazionecostopunto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcsconfigurazionecostopunto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pcsconfigurazionecostopunto] (
idpcsconfigurazione int NOT NULL,
idpcsconfigurazionecostopunto int NOT NULL,
costo decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
year int NULL,
 CONSTRAINT xpkpcsconfigurazionecostopunto PRIMARY KEY (idpcsconfigurazione,
idpcsconfigurazionecostopunto
)
)
END
GO

-- VERIFICA STRUTTURA pcsconfigurazionecostopunto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopunto' and C.name = 'idpcsconfigurazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopunto] ADD idpcsconfigurazione int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopunto') and col.name = 'idpcsconfigurazione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopunto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopunto' and C.name = 'idpcsconfigurazionecostopunto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopunto] ADD idpcsconfigurazionecostopunto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopunto') and col.name = 'idpcsconfigurazionecostopunto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopunto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopunto' and C.name = 'costo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopunto] ADD costo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopunto] ALTER COLUMN costo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopunto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopunto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopunto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopunto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopunto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopunto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopunto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopunto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopunto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopunto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopunto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopunto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopunto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopunto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopunto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopunto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopunto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazionecostopunto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazionecostopunto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopunto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazionecostopunto' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazionecostopunto] ADD year int NULL 
END
ELSE
	ALTER TABLE [pcsconfigurazionecostopunto] ALTER COLUMN year int NULL
GO

-- CREAZIONE TABELLA pcsconfigurazione --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcsconfigurazione]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pcsconfigurazione] (
idpcsconfigurazione int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
incrementodocenti decimal(19,6) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpcsconfigurazione PRIMARY KEY (idpcsconfigurazione
)
)
END
GO

-- VERIFICA STRUTTURA pcsconfigurazione --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazione' and C.name = 'idpcsconfigurazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazione] ADD idpcsconfigurazione int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazione') and col.name = 'idpcsconfigurazione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazione' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazione] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazione') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazione] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazione' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazione] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazione') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazione] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazione' and C.name = 'incrementodocenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazione] ADD incrementodocenti decimal(19,6) NULL 
END
ELSE
	ALTER TABLE [pcsconfigurazione] ALTER COLUMN incrementodocenti decimal(19,6) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazione' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazione] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazione') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazione] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsconfigurazione' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsconfigurazione] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsconfigurazione') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsconfigurazione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsconfigurazione] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE TABELLA pcsbilancio --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcsbilancio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pcsbilancio] (
idpcsbilancio int NOT NULL,
year int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
descrizione varchar(150) NULL,
importo decimal(19,2) NULL,
importo1 decimal(19,2) NULL,
importo2 decimal(19,2) NULL,
importo3 decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpcsbilancio PRIMARY KEY (idpcsbilancio,
year
)
)
END
GO

-- VERIFICA STRUTTURA pcsbilancio --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'idpcsbilancio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD idpcsbilancio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsbilancio') and col.name = 'idpcsbilancio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsbilancio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsbilancio') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsbilancio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsbilancio') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsbilancio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsbilancio] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsbilancio') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsbilancio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsbilancio] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'descrizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD descrizione varchar(150) NULL 
END
ELSE
	ALTER TABLE [pcsbilancio] ALTER COLUMN descrizione varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'importo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD importo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsbilancio] ALTER COLUMN importo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'importo1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD importo1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsbilancio] ALTER COLUMN importo1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'importo2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD importo2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsbilancio] ALTER COLUMN importo2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'importo3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD importo3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsbilancio] ALTER COLUMN importo3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsbilancio') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsbilancio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsbilancio] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsbilancio' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsbilancio] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsbilancio') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsbilancio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsbilancio] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE TABELLA pcsassunzioni --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcsassunzioni]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pcsassunzioni] (
idpcsassunzioni int NOT NULL,
year int NOT NULL,
codicessd nvarchar(50) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data datetime NULL,
finanziamento varchar(150) NULL,
idcontrattokind int NULL,
idstruttura int NULL,
legge varchar(250) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nominativo varchar(150) NULL,
percentuale decimal(19,6) NULL,
totale decimal(19,2) NULL,
totale1 decimal(19,2) NULL,
totale2 decimal(19,2) NULL,
totale3 decimal(19,2) NULL,
 CONSTRAINT xpkpcsassunzioni PRIMARY KEY (idpcsassunzioni,
year
)
)
END
GO

-- VERIFICA STRUTTURA pcsassunzioni --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idpcsassunzioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idpcsassunzioni int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'idpcsassunzioni' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'codicessd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD codicessd nvarchar(50) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN codicessd nvarchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD data datetime NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN data datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'finanziamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD finanziamento varchar(150) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN finanziamento varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'legge' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD legge varchar(250) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN legge varchar(250) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'nominativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD nominativo varchar(150) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN nominativo varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'percentuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD percentuale decimal(19,6) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN percentuale decimal(19,6) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale3 decimal(19,2) NULL
GO

-- CREAZIONE VISTA perfcomportamentodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfcomportamentodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfcomportamentodefaultview]
GO
-- CREAZIONE VISTA pcsconfigurazionecostopuntoincrdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcsconfigurazionecostopuntoincrdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[pcsconfigurazionecostopuntoincrdefaultview]
GO

CREATE VIEW [dbo].[pcsconfigurazionecostopuntoincrdefaultview] AS 
SELECT  pcsconfigurazionecostopuntoincr.costo AS pcsconfigurazionecostopuntoincr_costo, pcsconfigurazionecostopuntoincr.ct AS pcsconfigurazionecostopuntoincr_ct, pcsconfigurazionecostopuntoincr.cu AS pcsconfigurazionecostopuntoincr_cu, pcsconfigurazionecostopuntoincr.idpcsconfigurazionecostopuntoincr, pcsconfigurazionecostopuntoincr.incrementodocenti AS pcsconfigurazionecostopuntoincr_incrementodocenti, pcsconfigurazionecostopuntoincr.lt AS pcsconfigurazionecostopuntoincr_lt, pcsconfigurazionecostopuntoincr.lu AS pcsconfigurazionecostopuntoincr_lu,
 [dbo].year.year AS year_year, pcsconfigurazionecostopuntoincr.year
FROM [dbo].pcsconfigurazionecostopuntoincr WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].year WITH (NOLOCK) ON pcsconfigurazionecostopuntoincr.year = [dbo].year.year
WHERE  pcsconfigurazionecostopuntoincr.idpcsconfigurazionecostopuntoincr IS NOT NULL  AND pcsconfigurazionecostopuntoincr.year IS NOT NULL 
GO

-- CREAZIONE VISTA analisiannualedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[analisiannualedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[analisiannualedefaultview]
GO

CREATE VIEW [dbo].[analisiannualedefaultview] AS 
SELECT 
 [dbo].year.year AS year_year, analisiannuale.year
FROM [dbo].analisiannuale WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].year WITH (NOLOCK) ON analisiannuale.year = [dbo].year.year
WHERE  analisiannuale.year IS NOT NULL 
GO

