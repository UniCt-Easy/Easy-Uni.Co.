
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


-- CREAZIONE TABELLA perfprogetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogetto] (
idperfprogetto int NOT NULL,
benefici varchar(max) NULL,
ct datetime NULL,
cu varchar(64) NULL,
datafineeffettiva datetime NULL,
datafineprevista datetime NULL,
datainizioeffettiva datetime NULL,
datainizioprevista datetime NULL,
description varchar(max) NULL,
iddidprogsuddannokind int NULL,
idperfprogettostatus int NULL,
idstruttura int NULL,
lt datetime NULL,
lu varchar(64) NULL,
note varchar(max) NULL,
risultato decimal(18,2) NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkperfprogetto PRIMARY KEY (idperfprogetto
)
)
END
GO

-- VERIFICA STRUTTURA perfprogetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'idperfprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD idperfprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogetto') and col.name = 'idperfprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'benefici' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD benefici varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN benefici varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'datafineeffettiva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD datafineeffettiva datetime NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN datafineeffettiva datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'datafineprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD datafineprevista datetime NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN datafineprevista datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'datainizioeffettiva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD datainizioeffettiva datetime NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN datainizioeffettiva datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'datainizioprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD datainizioprevista datetime NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN datainizioprevista datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'iddidprogsuddannokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD iddidprogsuddannokind int NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN iddidprogsuddannokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'idperfprogettostatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD idperfprogettostatus int NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN idperfprogettostatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'note' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD note varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN note varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'risultato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD risultato decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN risultato decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogetto' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogetto] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [perfprogetto] ALTER COLUMN title varchar(1024) NULL
GO

