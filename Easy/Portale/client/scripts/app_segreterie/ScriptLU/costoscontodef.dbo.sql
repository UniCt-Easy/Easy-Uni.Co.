
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


-- CREAZIONE TABELLA costoscontodef --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[costoscontodef]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[costoscontodef] (
idcostoscontodef int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
idcostoscontodefkind int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
paridcostoscontodef int NULL,
title nvarchar(2024) NULL,
 CONSTRAINT xpkcostoscontodef PRIMARY KEY (idcostoscontodef
)
)
END
GO

-- VERIFICA STRUTTURA costoscontodef --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'idcostoscontodef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD idcostoscontodef int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('costoscontodef') and col.name = 'idcostoscontodef' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [costoscontodef] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'idcostoscontodefkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD idcostoscontodefkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('costoscontodef') and col.name = 'idcostoscontodefkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [costoscontodef] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN idcostoscontodefkind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'paridcostoscontodef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD paridcostoscontodef int NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN paridcostoscontodef int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD title nvarchar(2024) NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN title nvarchar(2024) NULL
GO

