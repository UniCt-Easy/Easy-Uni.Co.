
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


-- CREAZIONE TABELLA workpackagekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[workpackagekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[workpackagekind] (
idworkpackagekind int NOT NULL,
idprogettokind int NOT NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkworkpackagekind PRIMARY KEY (idworkpackagekind,
idprogettokind
)
)
END
GO

-- VERIFICA STRUTTURA workpackagekind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackagekind' and C.name = 'idworkpackagekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackagekind] ADD idworkpackagekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackagekind') and col.name = 'idworkpackagekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackagekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackagekind' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackagekind] ADD idprogettokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackagekind') and col.name = 'idprogettokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackagekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackagekind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackagekind] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackagekind] ALTER COLUMN title nvarchar(2048) NULL
GO

