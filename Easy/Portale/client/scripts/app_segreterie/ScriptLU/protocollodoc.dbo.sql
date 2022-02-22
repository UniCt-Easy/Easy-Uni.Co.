
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


-- CREAZIONE TABELLA protocollodoc --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollodoc]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[protocollodoc] (
idprotocollodoc int NOT NULL,
protnumero int NOT NULL,
protanno int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
filename varchar(1024) NULL,
idattach int NULL,
idmimetype int NULL,
idprotocollorifkind int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprotocollodoc PRIMARY KEY (idprotocollodoc,
protnumero,
protanno
)
)
END
GO

-- VERIFICA STRUTTURA protocollodoc --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'idprotocollodoc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD idprotocollodoc int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodoc') and col.name = 'idprotocollodoc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodoc] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'protnumero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD protnumero int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodoc') and col.name = 'protnumero' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodoc] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'protanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD protanno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodoc') and col.name = 'protanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodoc] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [protocollodoc] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollodoc] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'filename' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD filename varchar(1024) NULL 
END
ELSE
	ALTER TABLE [protocollodoc] ALTER COLUMN filename varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'idattach' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD idattach int NULL 
END
ELSE
	ALTER TABLE [protocollodoc] ALTER COLUMN idattach int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'idmimetype' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD idmimetype int NULL 
END
ELSE
	ALTER TABLE [protocollodoc] ALTER COLUMN idmimetype int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'idprotocollorifkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD idprotocollorifkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodoc') and col.name = 'idprotocollorifkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodoc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollodoc] ALTER COLUMN idprotocollorifkind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [protocollodoc] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodoc' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodoc] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollodoc] ALTER COLUMN lu varchar(64) NULL
GO

