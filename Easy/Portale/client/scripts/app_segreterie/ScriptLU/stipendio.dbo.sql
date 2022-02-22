
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


-- CREAZIONE TABELLA stipendio --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[stipendio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[stipendio] (
idstipendio int NOT NULL,
idcontrattokind int NOT NULL,
idinquadramento int NOT NULL,
assegno decimal(18,2) NULL,
classe int NULL,
ct datetime NULL,
cu varchar(64) NULL,
iis decimal(18,2) NULL,
irap decimal(18,2) NULL,
lordo decimal(18,2) NULL,
lt datetime NULL,
lu varchar(64) NULL,
scatto int NULL,
siglaimportazione varchar(1024) NULL,
stipendio decimal(18,2) NULL,
totale decimal(18,2) NULL,
 CONSTRAINT xpkstipendio PRIMARY KEY (idstipendio,
idcontrattokind,
idinquadramento
)
)
END
GO

-- VERIFICA STRUTTURA stipendio --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'idstipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD idstipendio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendio') and col.name = 'idstipendio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendio') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'idinquadramento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD idinquadramento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendio') and col.name = 'idinquadramento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'assegno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD assegno decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN assegno decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'classe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD classe int NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN classe int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'iis' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD iis decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN iis decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'irap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD irap decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN irap decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'lordo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD lordo decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN lordo decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD scatto int NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN scatto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'siglaimportazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD siglaimportazione varchar(1024) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN siglaimportazione varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'stipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD stipendio decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN stipendio decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'totale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD totale decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN totale decimal(18,2) NULL
GO

