
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


-- CREAZIONE TABELLA classescuolacaratteristica --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuolacaratteristica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[classescuolacaratteristica] (
idclassescuolacaratteristica int NOT NULL,
cf decimal(9,2) NULL,
cfmax decimal(9,2) NULL,
cfmin decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idambitoareadisc int NULL,
idclassescuola int NOT NULL,
idsasd int NULL,
idsasdgruppo int NULL,
idtipoattform int NULL,
idtipoattform_2 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
obblig char(1) NOT NULL,
profess char(1) NOT NULL,
 CONSTRAINT xpkclassescuolacaratteristica PRIMARY KEY (idclassescuolacaratteristica
)
)
END
GO

-- VERIFICA STRUTTURA classescuolacaratteristica --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idclassescuolacaratteristica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idclassescuolacaratteristica int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'idclassescuolacaratteristica' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cf decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cf decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cfmax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cfmax decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cfmax decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cfmin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cfmin decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cfmin decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD ct datetime NOT NULL DEFAULT 1/1/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idambitoareadisc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idambitoareadisc int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idambitoareadisc int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idclassescuola' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idclassescuola int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'idclassescuola' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idclassescuola int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idsasdgruppo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idsasdgruppo int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idsasdgruppo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idtipoattform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idtipoattform int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idtipoattform int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idtipoattform_2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idtipoattform_2 int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idtipoattform_2 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD lt datetime NOT NULL DEFAULT 1/1/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'obblig' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD obblig char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'obblig' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN obblig char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'profess' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD profess char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'profess' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN profess char(1) NOT NULL
GO

