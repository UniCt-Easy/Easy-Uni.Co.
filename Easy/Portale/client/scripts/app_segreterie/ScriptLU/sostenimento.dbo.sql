
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


-- CREAZIONE TABELLA sostenimento --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sostenimento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sostenimento] (
idsostenimento int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data date NOT NULL,
domande ntext NULL,
ects int NULL,
giudizio varchar(50) NULL,
idappello int NULL,
idattivform int NULL,
idcorsostudio int NULL,
iddidprog int NULL,
idiscrizione int NULL,
idprova int NULL,
idsostenimentoesito int NOT NULL,
idtitolostudio int NULL,
insecod varchar(50) NULL,
insedesc varchar(1024) NULL,
livello char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridsostenimento int NULL,
protanno int NULL,
protnumero int NULL,
voto decimal(9,2) NULL,
votolode char(1) NULL,
votosu int NULL,
 CONSTRAINT xpksostenimento PRIMARY KEY (idsostenimento,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA sostenimento --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idsostenimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idsostenimento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'idsostenimento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD data date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'data' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN data date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'domande' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD domande ntext NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'ects' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD ects int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN ects int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'giudizio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD giudizio varchar(50) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN giudizio varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idappello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idappello int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idappello int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idattivform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idattivform int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idattivform int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD iddidprog int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN iddidprog int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idiscrizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idiscrizione int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idiscrizione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idprova' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idprova int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idprova int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idsostenimentoesito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idsostenimentoesito int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'idsostenimentoesito' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idsostenimentoesito int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idtitolostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idtitolostudio int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idtitolostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'insecod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD insecod varchar(50) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN insecod varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'insedesc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD insedesc varchar(1024) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN insedesc varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'livello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD livello char(1) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN livello char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'paridsostenimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD paridsostenimento int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN paridsostenimento int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'protanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD protanno int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN protanno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'protnumero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD protnumero int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN protnumero int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'voto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD voto decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN voto decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'votolode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD votolode char(1) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN votolode char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'votosu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD votosu int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN votosu int NULL
GO

