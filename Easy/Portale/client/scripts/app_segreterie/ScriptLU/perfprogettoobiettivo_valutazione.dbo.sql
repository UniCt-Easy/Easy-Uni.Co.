
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


-- CREAZIONE TABELLA perfprogettoobiettivo_valutazione --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivo_valutazione]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogettoobiettivo_valutazione] (
idperfprogetto int NOT NULL,
idperfprogettoobiettivo int NOT NULL,
idperfvalutazioneuo int NOT NULL,
idperfprogettouo int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkperfprogettoobiettivo_valutazione PRIMARY KEY (idperfprogetto,
idperfprogettoobiettivo,
idperfvalutazioneuo,
idperfprogettouo
)
)
END
GO

-- VERIFICA STRUTTURA perfprogettoobiettivo_valutazione --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivo_valutazione' and C.name = 'idperfprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivo_valutazione] ADD idperfprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivo_valutazione') and col.name = 'idperfprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivo_valutazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivo_valutazione' and C.name = 'idperfprogettoobiettivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivo_valutazione] ADD idperfprogettoobiettivo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivo_valutazione') and col.name = 'idperfprogettoobiettivo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivo_valutazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivo_valutazione' and C.name = 'idperfvalutazioneuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivo_valutazione] ADD idperfvalutazioneuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivo_valutazione') and col.name = 'idperfvalutazioneuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivo_valutazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivo_valutazione' and C.name = 'idperfprogettouo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivo_valutazione] ADD idperfprogettouo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivo_valutazione') and col.name = 'idperfprogettouo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivo_valutazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivo_valutazione' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivo_valutazione] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivo_valutazione') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivo_valutazione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivo_valutazione] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivo_valutazione' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivo_valutazione] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivo_valutazione') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivo_valutazione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivo_valutazione] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivo_valutazione' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivo_valutazione] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivo_valutazione] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivo_valutazione' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivo_valutazione] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivo_valutazione] ALTER COLUMN lu varchar(64) NULL
GO
