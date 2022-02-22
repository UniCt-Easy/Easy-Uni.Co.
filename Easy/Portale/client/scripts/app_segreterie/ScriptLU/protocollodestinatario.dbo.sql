
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


-- CREAZIONE TABELLA protocollodestinatario --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollodestinatario]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[protocollodestinatario] (
idprotocollodestinatario int NOT NULL,
protnumero int NOT NULL,
protanno int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
destcodiceaoo varchar(50) NULL,
destidamm varchar(50) NULL,
destmail varchar(512) NULL,
idreg_dest int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprotocollodestinatario PRIMARY KEY (idprotocollodestinatario,
protnumero,
protanno
)
)
END
GO

-- VERIFICA STRUTTURA protocollodestinatario --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'idprotocollodestinatario' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD idprotocollodestinatario int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodestinatario') and col.name = 'idprotocollodestinatario' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodestinatario] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'protnumero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD protnumero int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodestinatario') and col.name = 'protnumero' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodestinatario] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'protanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD protanno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodestinatario') and col.name = 'protanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodestinatario] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [protocollodestinatario] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollodestinatario] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'destcodiceaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD destcodiceaoo varchar(50) NULL 
END
ELSE
	ALTER TABLE [protocollodestinatario] ALTER COLUMN destcodiceaoo varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'destidamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD destidamm varchar(50) NULL 
END
ELSE
	ALTER TABLE [protocollodestinatario] ALTER COLUMN destidamm varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'destmail' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD destmail varchar(512) NULL 
END
ELSE
	ALTER TABLE [protocollodestinatario] ALTER COLUMN destmail varchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'idreg_dest' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD idreg_dest int NULL 
END
ELSE
	ALTER TABLE [protocollodestinatario] ALTER COLUMN idreg_dest int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [protocollodestinatario] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodestinatario' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodestinatario] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollodestinatario] ALTER COLUMN lu varchar(64) NULL
GO

