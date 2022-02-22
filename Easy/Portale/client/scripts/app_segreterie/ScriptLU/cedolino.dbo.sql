
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


-- CREAZIONE TABELLA cedolino --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[cedolino]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[cedolino] (
idcedolino int NOT NULL,
idcontratto int NOT NULL,
idreg int NOT NULL,
assegno decimal(18,2) NULL,
classe int NULL,
data date NULL,
idmese int NULL,
iis decimal(18,2) NULL,
irap decimal(18,2) NULL,
lordo decimal(18,2) NULL,
scatto int NULL,
stipendio decimal(18,2) NULL,
totale decimal(18,2) NULL,
year int NULL,
 CONSTRAINT xpkcedolino PRIMARY KEY (idcedolino,
idcontratto,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA cedolino --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'idcedolino' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD idcedolino int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cedolino') and col.name = 'idcedolino' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cedolino] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'idcontratto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD idcontratto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cedolino') and col.name = 'idcontratto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cedolino] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cedolino') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cedolino] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'assegno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD assegno decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN assegno decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'classe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD classe int NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN classe int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD data date NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'idmese' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD idmese int NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN idmese int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'iis' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD iis decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN iis decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'irap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD irap decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN irap decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'lordo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD lordo decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN lordo decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD scatto int NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN scatto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'stipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD stipendio decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN stipendio decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'totale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD totale decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN totale decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD year int NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN year int NULL
GO

