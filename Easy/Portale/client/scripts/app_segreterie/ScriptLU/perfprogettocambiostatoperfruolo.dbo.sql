
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


-- CREAZIONE TABELLA perfprogettocambiostatoperfruolo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettocambiostatoperfruolo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogettocambiostatoperfruolo] (
idperfprogettocambiostato int NOT NULL,
idperfruolo varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkperfprogettocambiostatoperfruolo PRIMARY KEY (idperfprogettocambiostato,
idperfruolo
)
)
END
GO

-- VERIFICA STRUTTURA perfprogettocambiostatoperfruolo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettocambiostatoperfruolo' and C.name = 'idperfprogettocambiostato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettocambiostatoperfruolo] ADD idperfprogettocambiostato int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettocambiostatoperfruolo') and col.name = 'idperfprogettocambiostato' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettocambiostatoperfruolo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettocambiostatoperfruolo' and C.name = 'idperfruolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettocambiostatoperfruolo] ADD idperfruolo varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettocambiostatoperfruolo') and col.name = 'idperfruolo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettocambiostatoperfruolo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettocambiostatoperfruolo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettocambiostatoperfruolo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettocambiostatoperfruolo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettocambiostatoperfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettocambiostatoperfruolo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettocambiostatoperfruolo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettocambiostatoperfruolo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettocambiostatoperfruolo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettocambiostatoperfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettocambiostatoperfruolo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettocambiostatoperfruolo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettocambiostatoperfruolo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettocambiostatoperfruolo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettocambiostatoperfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettocambiostatoperfruolo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettocambiostatoperfruolo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettocambiostatoperfruolo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettocambiostatoperfruolo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettocambiostatoperfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettocambiostatoperfruolo] ALTER COLUMN lu varchar(64) NOT NULL
GO
