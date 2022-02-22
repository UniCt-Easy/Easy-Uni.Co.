
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


-- CREAZIONE TABELLA tirocinioprogetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tirocinioprogetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tirocinioprogetto] (
idtirocinioprogetto int NOT NULL,
idtirociniocandidatura int NOT NULL,
idtirocinioproposto int NOT NULL,
idreg_studenti int NOT NULL,
idreg_referente int NOT NULL,
competenze varchar(max) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datafineeffettiva date NULL,
datafineprevista date NOT NULL,
datainizioeffettiva date NULL,
datainizioprevista date NOT NULL,
dataverbale date NULL,
description varchar(max) NOT NULL,
description_en varchar(max) NULL,
idaoo int NOT NULL,
idreg_docenti int NOT NULL,
idsede int NULL,
idstruttura int NOT NULL,
idtirociniostato int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ore int NOT NULL,
protanno int NULL,
protnumero int NULL,
tempiaccesso varchar(max) NULL,
title varchar(max) NOT NULL,
title_en varchar(max) NULL,
 CONSTRAINT xpktirocinioprogetto PRIMARY KEY (idtirocinioprogetto,
idtirociniocandidatura,
idtirocinioproposto,
idreg_studenti,
idreg_referente
)
)
END
GO

-- VERIFICA STRUTTURA tirocinioprogetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idtirocinioprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idtirocinioprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idtirocinioprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idtirociniocandidatura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idtirociniocandidatura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idtirociniocandidatura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idtirocinioproposto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idtirocinioproposto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idtirocinioproposto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idreg_studenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idreg_studenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idreg_studenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idreg_referente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idreg_referente int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idreg_referente' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'competenze' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD competenze varchar(max) NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN competenze varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'datafineeffettiva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD datafineeffettiva date NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN datafineeffettiva date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'datafineprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD datafineprevista date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'datafineprevista' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN datafineprevista date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'datainizioeffettiva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD datainizioeffettiva date NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN datainizioeffettiva date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'datainizioprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD datainizioprevista date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'datainizioprevista' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN datainizioprevista date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'dataverbale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD dataverbale date NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN dataverbale date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD description varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN description varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'description_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD description_en varchar(max) NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN description_en varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idaoo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idaoo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN idaoo int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN idreg_docenti int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idsede int NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN idsede int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN idstruttura int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idtirociniostato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idtirociniostato int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idtirociniostato' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN idtirociniostato int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'ore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD ore int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'ore' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN ore int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'protanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD protanno int NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN protanno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'protnumero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD protnumero int NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN protnumero int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'tempiaccesso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD tempiaccesso varchar(max) NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN tempiaccesso varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD title varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN title varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD title_en varchar(max) NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN title_en varchar(max) NULL
GO

