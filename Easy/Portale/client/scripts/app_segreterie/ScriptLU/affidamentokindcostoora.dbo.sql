
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


-- CREAZIONE TABELLA affidamentokindcostoora --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentokindcostoora]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[affidamentokindcostoora] (
idaffidamentokindcostoora int NOT NULL,
idaffidamentokind int NOT NULL,
aa varchar(9) NULL,
costoora decimal(9,2) NULL,
title nvarchar(1024) NULL,
 CONSTRAINT xpkaffidamentokindcostoora PRIMARY KEY (idaffidamentokindcostoora,
idaffidamentokind
)
)
END
GO

-- VERIFICA STRUTTURA affidamentokindcostoora --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokindcostoora' and C.name = 'idaffidamentokindcostoora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokindcostoora] ADD idaffidamentokindcostoora int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokindcostoora') and col.name = 'idaffidamentokindcostoora' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokindcostoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokindcostoora' and C.name = 'idaffidamentokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokindcostoora] ADD idaffidamentokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokindcostoora') and col.name = 'idaffidamentokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokindcostoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokindcostoora' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokindcostoora] ADD aa varchar(9) NULL 
END
ELSE
	ALTER TABLE [affidamentokindcostoora] ALTER COLUMN aa varchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokindcostoora' and C.name = 'costoora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokindcostoora] ADD costoora decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [affidamentokindcostoora] ALTER COLUMN costoora decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokindcostoora' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokindcostoora] ADD title nvarchar(1024) NULL 
END
ELSE
	ALTER TABLE [affidamentokindcostoora] ALTER COLUMN title nvarchar(1024) NULL
GO

