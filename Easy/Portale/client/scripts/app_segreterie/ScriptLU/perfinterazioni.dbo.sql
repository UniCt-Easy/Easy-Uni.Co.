
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


-- CREAZIONE TABELLA perfinterazioni --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfinterazioni]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfinterazioni] (
idperfvalutazionepersonale int NOT NULL,
idperfinterazioni int NOT NULL,
commenti varchar(max) NULL,
commentival varchar(max) NULL,
data datetime NULL,
idperfinterazionekind int NOT NULL,
 CONSTRAINT xpkperfinterazioni PRIMARY KEY (idperfvalutazionepersonale,
idperfinterazioni
)
)
END
GO

-- VERIFICA STRUTTURA perfinterazioni --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'idperfvalutazionepersonale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD idperfvalutazionepersonale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfinterazioni') and col.name = 'idperfvalutazionepersonale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfinterazioni] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'idperfinterazioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD idperfinterazioni int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfinterazioni') and col.name = 'idperfinterazioni' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfinterazioni] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'commenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD commenti varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfinterazioni] ALTER COLUMN commenti varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'commentival' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD commentival varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfinterazioni] ALTER COLUMN commentival varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD data datetime NULL 
END
ELSE
	ALTER TABLE [perfinterazioni] ALTER COLUMN data datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'idperfinterazionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD idperfinterazionekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfinterazioni') and col.name = 'idperfinterazionekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfinterazioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfinterazioni] ALTER COLUMN idperfinterazionekind int NOT NULL
GO

