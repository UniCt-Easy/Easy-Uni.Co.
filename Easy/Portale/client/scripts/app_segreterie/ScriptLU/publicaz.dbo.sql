
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


-- CREAZIONE TABELLA publicaz --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[publicaz]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[publicaz] (
idpublicaz int NOT NULL,
abstractstring nvarchar(max) NULL,
annocopyright int NULL,
annopub int NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
editore varchar(150) NULL,
fascicolo varchar(150) NULL,
idcity int NULL,
idcity_ed int NULL,
idnation_ed int NULL,
idnation_lang int NULL,
idprogetto int NULL,
isbn varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
numrivista int NULL,
pagestart int NULL,
pagestop int NULL,
pagetot int NULL,
title varchar(512) NULL,
title2 nvarchar(512) NULL,
volume varchar(150) NULL,
 CONSTRAINT xpkpublicaz PRIMARY KEY (idpublicaz
)
)
END
GO

-- VERIFICA STRUTTURA publicaz --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idpublicaz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idpublicaz int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'idpublicaz' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'abstractstring' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD abstractstring nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN abstractstring nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'annocopyright' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD annocopyright int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN annocopyright int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'annopub' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD annopub int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN annopub int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'editore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD editore varchar(150) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN editore varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'fascicolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD fascicolo varchar(150) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN fascicolo varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idcity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idcity int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idcity int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idcity_ed' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idcity_ed int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idcity_ed int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idnation_ed' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idnation_ed int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idnation_ed int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idnation_lang' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idnation_lang int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idnation_lang int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idprogetto int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idprogetto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'isbn' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD isbn varchar(50) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN isbn varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'numrivista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD numrivista int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN numrivista int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'pagestart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD pagestart int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN pagestart int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'pagestop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD pagestop int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN pagestop int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'pagetot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD pagetot int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN pagetot int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD title varchar(512) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN title varchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'title2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD title2 nvarchar(512) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN title2 nvarchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'volume' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD volume varchar(150) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN volume varchar(150) NULL
GO

