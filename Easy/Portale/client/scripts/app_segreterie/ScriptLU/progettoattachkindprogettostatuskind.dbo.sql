
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


-- CREAZIONE TABELLA progettoattachkindprogettostatuskind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoattachkindprogettostatuskind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettoattachkindprogettostatuskind] (
idprogettostatuskind int NOT NULL,
idprogettoattachkind int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
 CONSTRAINT xpkprogettoattachkindprogettostatuskind PRIMARY KEY (idprogettostatuskind,
idprogettoattachkind
)
)
END
GO

-- VERIFICA STRUTTURA progettoattachkindprogettostatuskind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD idprogettostatuskind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkindprogettostatuskind') and col.name = 'idprogettostatuskind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkindprogettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'idprogettoattachkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD idprogettoattachkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkindprogettostatuskind') and col.name = 'idprogettoattachkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkindprogettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN lu varchar(60) NULL
GO
