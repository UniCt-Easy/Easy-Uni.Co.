
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


-- CREAZIONE TABELLA progettotiporicavokindaccmotive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettotiporicavokindaccmotive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettotiporicavokindaccmotive] (
idprogettokind int NOT NULL,
idprogettotipocostokind int NOT NULL,
idaccmotive varchar(38) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprogettotiporicavokindaccmotive PRIMARY KEY (idprogettokind,
idprogettotipocostokind,
idaccmotive
)
)
END
GO

-- VERIFICA STRUTTURA progettotiporicavokindaccmotive --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindaccmotive' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindaccmotive] ADD idprogettokind int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotiporicavokindaccmotive') and col.name = 'idprogettokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotiporicavokindaccmotive] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindaccmotive' and C.name = 'idprogettotipocostokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindaccmotive] ADD idprogettotipocostokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotiporicavokindaccmotive') and col.name = 'idprogettotipocostokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotiporicavokindaccmotive] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindaccmotive' and C.name = 'idaccmotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindaccmotive] ADD idaccmotive varchar(38) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotiporicavokindaccmotive') and col.name = 'idaccmotive' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotiporicavokindaccmotive] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindaccmotive' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindaccmotive] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotiporicavokindaccmotive] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindaccmotive' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindaccmotive] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotiporicavokindaccmotive] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindaccmotive' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindaccmotive] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotiporicavokindaccmotive] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindaccmotive' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindaccmotive] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotiporicavokindaccmotive] ALTER COLUMN lu varchar(64) NULL
GO
