
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


-- CREAZIONE TABELLA progettotimesheet --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotimesheet]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotimesheet] (
idprogettotimesheet int NOT NULL,
idreg int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
idtimesheettemplate varchar(60) NULL,
intestazioneallsheet char(1) NULL,
lt datetime NULL,
lu varchar(60) NULL,
riepilogoanno char(1) NULL,
showactivitiesrow char(1) NULL,
title nvarchar(2048) NULL,
year int NULL,
 CONSTRAINT xpkprogettotimesheet PRIMARY KEY (idprogettotimesheet,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA progettotimesheet --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'idprogettotimesheet' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD idprogettotimesheet int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheet') and col.name = 'idprogettotimesheet' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheet] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheet') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheet] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'idtimesheettemplate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD idtimesheettemplate varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN idtimesheettemplate varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'intestazioneallsheet' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD intestazioneallsheet char(1) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN intestazioneallsheet char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN lu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'riepilogoanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD riepilogoanno char(1) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN riepilogoanno char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'showactivitiesrow' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD showactivitiesrow char(1) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN showactivitiesrow char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN title nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD year int NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN year int NULL
GO

