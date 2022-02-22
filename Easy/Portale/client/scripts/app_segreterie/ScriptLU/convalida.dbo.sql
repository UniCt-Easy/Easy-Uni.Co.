
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


-- CREAZIONE TABELLA convalida --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[convalida]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[convalida] (
idconvalida int NOT NULL,
idreg int NOT NULL,
cf decimal(9,2) NULL,
cfintegrazione decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data datetime NULL,
idconvalidakind int NULL,
iddichiar int NULL,
iddidprog int NULL,
idiscrizione int NULL,
idiscrizione_from int NULL,
idiscrizionebmi int NULL,
idistanza int NULL,
idlearningagrstud int NULL,
idlearningagrtrainer int NULL,
idpratica int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
voto decimal(9,2) NULL,
votolode char(1) NULL,
votosu int NULL,
 CONSTRAINT xpkconvalida PRIMARY KEY (idconvalida,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA convalida --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'idconvalida' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD idconvalida int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalida') and col.name = 'idconvalida' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalida] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalida') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalida] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD cf decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN cf decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'cfintegrazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD cfintegrazione decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN cfintegrazione decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalida') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalida] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalida') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalida] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD data datetime NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN data datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'idconvalidakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD idconvalidakind int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN idconvalidakind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'iddichiar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD iddichiar int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN iddichiar int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD iddidprog int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN iddidprog int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'idiscrizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD idiscrizione int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN idiscrizione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'idiscrizione_from' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD idiscrizione_from int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN idiscrizione_from int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'idiscrizionebmi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD idiscrizionebmi int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN idiscrizionebmi int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'idistanza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD idistanza int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN idistanza int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'idlearningagrstud' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD idlearningagrstud int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN idlearningagrstud int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'idlearningagrtrainer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD idlearningagrtrainer int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN idlearningagrtrainer int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'idpratica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD idpratica int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN idpratica int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalida') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalida] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convalida') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convalida] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'voto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD voto decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN voto decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'votolode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD votolode char(1) NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN votolode char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convalida' and C.name = 'votosu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convalida] ADD votosu int NULL 
END
ELSE
	ALTER TABLE [convalida] ALTER COLUMN votosu int NULL
GO

