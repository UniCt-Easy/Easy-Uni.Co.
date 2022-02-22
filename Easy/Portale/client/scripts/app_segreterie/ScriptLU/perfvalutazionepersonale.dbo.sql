
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


-- CREAZIONE TABELLA perfvalutazionepersonale --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazionepersonale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazionepersonale] (
idperfvalutazionepersonale int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idafferenza int NULL,
idperfschedastatus int NULL,
idreg_appr int NULL,
idreg_val int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
perccomportamenti decimal(19,2) NULL,
percobiettivi decimal(19,2) NULL,
percperfuo decimal(19,2) NULL,
pesocomportamenti decimal(19,2) NULL,
pesoobiettivi decimal(19,2) NULL,
pesoperfuo decimal(19,2) NULL,
risultato decimal(19,2) NULL,
year int NULL,
 CONSTRAINT xpkperfvalutazionepersonale PRIMARY KEY (idperfvalutazionepersonale,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazionepersonale --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idperfvalutazionepersonale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idperfvalutazionepersonale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'idperfvalutazionepersonale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idafferenza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idafferenza int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN idafferenza int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idperfschedastatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idperfschedastatus int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN idperfschedastatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idreg_appr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idreg_appr int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN idreg_appr int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idreg_val' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idreg_val int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN idreg_val int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'perccomportamenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD perccomportamenti decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN perccomportamenti decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'percobiettivi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD percobiettivi decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN percobiettivi decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'percperfuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD percperfuo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN percperfuo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'pesocomportamenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD pesocomportamenti decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN pesocomportamenti decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'pesoobiettivi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD pesoobiettivi decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN pesoobiettivi decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'pesoperfuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD pesoperfuo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN pesoperfuo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'risultato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD risultato decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN risultato decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD year int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN year int NULL
GO

