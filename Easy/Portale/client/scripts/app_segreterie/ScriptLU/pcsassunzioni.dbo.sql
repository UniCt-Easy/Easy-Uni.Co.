
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


-- CREAZIONE TABELLA pcsassunzioni --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcsassunzioni]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pcsassunzioni] (
idpcsassunzioni int NOT NULL,
year int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data datetime NULL,
finanziamento varchar(150) NULL,
idcontrattokind int NULL,
idcontrattokind_start int NULL,
idsasd int NULL,
idstruttura int NULL,
legge varchar(250) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nominativo varchar(150) NULL,
numeropersoneassunzione decimal(19,2) NULL,
percentuale decimal(19,2) NULL,
stipendio decimal(19,2) NULL,
totale decimal(19,2) NULL,
totale1 decimal(19,2) NULL,
totale2 decimal(19,2) NULL,
totale3 decimal(19,2) NULL,
 CONSTRAINT xpkpcsassunzioni PRIMARY KEY (idpcsassunzioni,
year
)
)
END
GO

-- VERIFICA STRUTTURA pcsassunzioni --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idpcsassunzioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idpcsassunzioni int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'idpcsassunzioni' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD data datetime NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN data datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'finanziamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD finanziamento varchar(150) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN finanziamento varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idcontrattokind_start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idcontrattokind_start int NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN idcontrattokind_start int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'legge' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD legge varchar(250) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN legge varchar(250) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'nominativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD nominativo varchar(150) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN nominativo varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'numeropersoneassunzione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD numeropersoneassunzione decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN numeropersoneassunzione decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'percentuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD percentuale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN percentuale decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'stipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD stipendio decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN stipendio decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale3 decimal(19,2) NULL
GO

