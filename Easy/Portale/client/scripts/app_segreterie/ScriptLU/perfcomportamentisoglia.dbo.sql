
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


-- CREAZIONE TABELLA perfcomportamentisoglia --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfcomportamentisoglia]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfcomportamentisoglia] (
idperfcomportamentosoglia int NOT NULL,
idperfcomportamento int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NULL,
idperfsogliakind varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
valore decimal(19,2) NULL,
year nchar(10) NULL,
 CONSTRAINT xpkperfcomportamentisoglia PRIMARY KEY (idperfcomportamentosoglia,
idperfcomportamento
)
)
END
GO

-- VERIFICA STRUTTURA perfcomportamentisoglia --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfcomportamentisoglia' and C.name = 'idperfcomportamentosoglia' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfcomportamentisoglia] ADD idperfcomportamentosoglia int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfcomportamentisoglia') and col.name = 'idperfcomportamentosoglia' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfcomportamentisoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfcomportamentisoglia' and C.name = 'idperfcomportamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfcomportamentisoglia] ADD idperfcomportamento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfcomportamentisoglia') and col.name = 'idperfcomportamento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfcomportamentisoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfcomportamentisoglia' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfcomportamentisoglia] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfcomportamentisoglia') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfcomportamentisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfcomportamentisoglia] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfcomportamentisoglia' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfcomportamentisoglia] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfcomportamentisoglia') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfcomportamentisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfcomportamentisoglia] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfcomportamentisoglia' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfcomportamentisoglia] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfcomportamentisoglia] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfcomportamentisoglia' and C.name = 'idperfsogliakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfcomportamentisoglia] ADD idperfsogliakind varchar(50) NULL 
END
ELSE
	ALTER TABLE [perfcomportamentisoglia] ALTER COLUMN idperfsogliakind varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfcomportamentisoglia' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfcomportamentisoglia] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfcomportamentisoglia') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfcomportamentisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfcomportamentisoglia] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfcomportamentisoglia' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfcomportamentisoglia] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfcomportamentisoglia') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfcomportamentisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfcomportamentisoglia] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfcomportamentisoglia' and C.name = 'valore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfcomportamentisoglia] ADD valore decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfcomportamentisoglia] ALTER COLUMN valore decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfcomportamentisoglia' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfcomportamentisoglia] ADD year nchar(10) NULL 
END
ELSE
	ALTER TABLE [perfcomportamentisoglia] ALTER COLUMN year nchar(10) NULL
GO

