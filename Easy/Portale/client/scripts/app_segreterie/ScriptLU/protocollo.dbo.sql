
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


-- CREAZIONE TABELLA protocollo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[protocollo] (
protnumero int NOT NULL,
protanno int NOT NULL,
annullato char(1) NOT NULL,
codiceammipa varchar(50) NOT NULL,
codiceregistro varchar(1024) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
dataannullamento datetime NULL,
idaoo int NOT NULL,
idreg_origine int NULL,
lt datetime NULL,
lu varchar(64) NULL,
oggetto varchar(1024) NOT NULL,
originecodiceaoo varchar(50) NULL,
origineidamm varchar(50) NULL,
originemail varchar(512) NULL,
protdata date NOT NULL,
testo varchar(max) NULL,
 CONSTRAINT xpkprotocollo PRIMARY KEY (protnumero,
protanno
)
)
END
GO

-- VERIFICA STRUTTURA protocollo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'protnumero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD protnumero int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'protnumero' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'protanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD protanno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'protanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'annullato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD annullato char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'annullato' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN annullato char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'codiceammipa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD codiceammipa varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'codiceammipa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN codiceammipa varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'codiceregistro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD codiceregistro varchar(1024) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'codiceregistro' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN codiceregistro varchar(1024) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'dataannullamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD dataannullamento datetime NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN dataannullamento datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'idaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD idaoo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'idaoo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN idaoo int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'idreg_origine' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD idreg_origine int NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN idreg_origine int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'oggetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD oggetto varchar(1024) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'oggetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN oggetto varchar(1024) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'originecodiceaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD originecodiceaoo varchar(50) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN originecodiceaoo varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'origineidamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD origineidamm varchar(50) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN origineidamm varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'originemail' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD originemail varchar(512) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN originemail varchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'protdata' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD protdata date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'protdata' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN protdata date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'testo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD testo varchar(max) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN testo varchar(max) NULL
GO

