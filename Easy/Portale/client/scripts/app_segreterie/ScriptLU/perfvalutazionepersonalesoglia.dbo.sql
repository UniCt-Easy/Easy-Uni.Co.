
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


-- CREAZIONE TABELLA perfvalutazionepersonalesoglia --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazionepersonalesoglia]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazionepersonalesoglia] (
idperfvalutazionepersonale int NOT NULL,
idperfvalutazionepersonaleobiettivo int NOT NULL,
idperfvalutazionepersonalesoglia int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NULL,
idperfsogliakind varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
percentuale decimal(19,2) NULL,
valorenumerico decimal(19,2) NULL,
 CONSTRAINT xpkperfvalutazionepersonalesoglia PRIMARY KEY (idperfvalutazionepersonale,
idperfvalutazionepersonaleobiettivo,
idperfvalutazionepersonalesoglia
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazionepersonalesoglia --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'idperfvalutazionepersonale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD idperfvalutazionepersonale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalesoglia') and col.name = 'idperfvalutazionepersonale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalesoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'idperfvalutazionepersonaleobiettivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD idperfvalutazionepersonaleobiettivo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalesoglia') and col.name = 'idperfvalutazionepersonaleobiettivo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalesoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'idperfvalutazionepersonalesoglia' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD idperfvalutazionepersonalesoglia int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalesoglia') and col.name = 'idperfvalutazionepersonalesoglia' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalesoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalesoglia') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalesoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonalesoglia] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalesoglia') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalesoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonalesoglia] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonalesoglia] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'idperfsogliakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD idperfsogliakind varchar(50) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonalesoglia] ALTER COLUMN idperfsogliakind varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalesoglia') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalesoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonalesoglia] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalesoglia') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalesoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonalesoglia] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'percentuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD percentuale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonalesoglia] ALTER COLUMN percentuale decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalesoglia' and C.name = 'valorenumerico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalesoglia] ADD valorenumerico decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonalesoglia] ALTER COLUMN valorenumerico decimal(19,2) NULL
GO
