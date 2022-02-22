
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


-- CREAZIONE TABELLA progettobudgetvariazione --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettobudgetvariazione]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettobudgetvariazione] (
idprogettobudgetvariazione int NOT NULL,
idprogettobudget int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
data date NULL,
idaccmotive varchar(36) NULL,
idupb varchar(36) NULL,
lt datetime NULL,
lu varchar(60) NULL,
newamount decimal(16,2) NULL,
 CONSTRAINT xpkprogettobudgetvariazione PRIMARY KEY (idprogettobudgetvariazione,
idprogettobudget,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettobudgetvariazione --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogettobudgetvariazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogettobudgetvariazione int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogettobudgetvariazione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogettobudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogettobudget int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogettobudget' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD data date NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idaccmotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idaccmotive varchar(36) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN idaccmotive varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idupb varchar(36) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN idupb varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN lu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'newamount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD newamount decimal(16,2) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN newamount decimal(16,2) NULL
GO

