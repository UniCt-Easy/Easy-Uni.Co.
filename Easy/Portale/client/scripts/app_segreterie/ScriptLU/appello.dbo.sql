
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


-- CREAZIONE TABELLA appello --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appello]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[appello] (
idappello int NOT NULL,
aa varchar(9) NULL,
basevoto int NULL,
cftoend decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(1024) NULL,
esteroend date NULL,
esterostart date NULL,
idappelloazionekind int NULL,
idappellokind int NULL,
idsessione int NULL,
idstudprenotkind int NULL,
lavoratori char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
minanniiscr int NULL,
minvoto int NULL,
passaggio char(1) NULL,
penotend datetime NULL,
posti int NULL,
prenotstart datetime NULL,
prointermedia char(1) NULL,
publicato char(1) NULL,
surmanestop varchar(50) NULL,
surnamestart varchar(50) NULL,
 CONSTRAINT xpkappello PRIMARY KEY (idappello
)
)
END
GO

-- VERIFICA STRUTTURA appello --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'idappello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD idappello int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appello') and col.name = 'idappello' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appello] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD aa varchar(9) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN aa varchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'basevoto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD basevoto int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN basevoto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'cftoend' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD cftoend decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN cftoend decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appello') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appello') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD description varchar(1024) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN description varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'esteroend' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD esteroend date NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN esteroend date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'esterostart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD esterostart date NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN esterostart date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'idappelloazionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD idappelloazionekind int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN idappelloazionekind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'idappellokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD idappellokind int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN idappellokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'idsessione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD idsessione int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN idsessione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'idstudprenotkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD idstudprenotkind int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN idstudprenotkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'lavoratori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD lavoratori char(1) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN lavoratori char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appello') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appello') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'minanniiscr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD minanniiscr int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN minanniiscr int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'minvoto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD minvoto int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN minvoto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'passaggio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD passaggio char(1) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN passaggio char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'penotend' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD penotend datetime NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN penotend datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'posti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD posti int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN posti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'prenotstart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD prenotstart datetime NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN prenotstart datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'prointermedia' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD prointermedia char(1) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN prointermedia char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'publicato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD publicato char(1) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN publicato char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'surmanestop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD surmanestop varchar(50) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN surmanestop varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'surnamestart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD surnamestart varchar(50) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN surnamestart varchar(50) NULL
GO

