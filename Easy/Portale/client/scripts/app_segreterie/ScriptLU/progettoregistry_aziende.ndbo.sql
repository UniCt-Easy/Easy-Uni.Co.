
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


-- CREAZIONE TABELLA progettoregistry_aziende --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettoregistry_aziende]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettoregistry_aziende] (
idprogetto int NOT NULL,
idreg_aziende int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idpartnerkind int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkprogettoregistry_aziende PRIMARY KEY (idprogetto,
idreg_aziende
)
)
END
GO

-- VERIFICA STRUTTURA progettoregistry_aziende --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'idreg_aziende' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD idreg_aziende int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'idreg_aziende' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoregistry_aziende] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoregistry_aziende] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'idpartnerkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD idpartnerkind int NULL 
END
ELSE
	ALTER TABLE [progettoregistry_aziende] ALTER COLUMN idpartnerkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoregistry_aziende] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoregistry_aziende' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoregistry_aziende] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoregistry_aziende') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoregistry_aziende] ALTER COLUMN lu varchar(64) NOT NULL
GO
