
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


-- CREAZIONE TABELLA protocollodocelement --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollodocelement]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[protocollodocelement] (
idprotocollodocelement int NOT NULL,
idprotocollodoc int NOT NULL,
protnumero int NOT NULL,
protanno int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
idprotocollodocelement_primo int NOT NULL,
idprotocollodockind int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
oggetto varchar(1024) NOT NULL,
telematicocolloc varchar(1024) NULL,
telematicohash varbinary(160) NULL,
 CONSTRAINT xpkprotocollodocelement PRIMARY KEY (idprotocollodocelement,
idprotocollodoc,
protnumero,
protanno
)
)
END
GO

-- VERIFICA STRUTTURA protocollodocelement --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'idprotocollodocelement' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD idprotocollodocelement int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodocelement') and col.name = 'idprotocollodocelement' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodocelement] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'idprotocollodoc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD idprotocollodoc int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodocelement') and col.name = 'idprotocollodoc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodocelement] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'protnumero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD protnumero int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodocelement') and col.name = 'protnumero' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodocelement] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'protanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD protanno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodocelement') and col.name = 'protanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodocelement] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [protocollodocelement] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollodocelement] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'idprotocollodocelement_primo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD idprotocollodocelement_primo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodocelement') and col.name = 'idprotocollodocelement_primo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodocelement] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollodocelement] ALTER COLUMN idprotocollodocelement_primo int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'idprotocollodockind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD idprotocollodockind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodocelement') and col.name = 'idprotocollodockind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodocelement] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollodocelement] ALTER COLUMN idprotocollodockind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [protocollodocelement] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollodocelement] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'oggetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD oggetto varchar(1024) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodocelement') and col.name = 'oggetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodocelement] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollodocelement] ALTER COLUMN oggetto varchar(1024) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'telematicocolloc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD telematicocolloc varchar(1024) NULL 
END
ELSE
	ALTER TABLE [protocollodocelement] ALTER COLUMN telematicocolloc varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodocelement' and C.name = 'telematicohash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodocelement] ADD telematicohash varbinary(160) NULL 
END
ELSE
	ALTER TABLE [protocollodocelement] ALTER COLUMN telematicohash varbinary(160) NULL
GO

