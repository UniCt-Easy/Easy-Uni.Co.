
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


-- CREAZIONE TABELLA perfvalutazionepersonalecomportamento --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazionepersonalecomportamento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazionepersonalecomportamento] (
idperfvalutazionepersonale int NOT NULL,
idperfvalutazionepersonalecomportamento int NOT NULL,
idperfcomportamento int NOT NULL,
completamento decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
peso decimal(19,2) NULL,
valorenumerico decimal(19,2) NULL,
 CONSTRAINT xpkperfvalutazionepersonalecomportamento PRIMARY KEY (idperfvalutazionepersonale,
idperfvalutazionepersonalecomportamento,
idperfcomportamento
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazionepersonalecomportamento --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalecomportamento' and C.name = 'idperfvalutazionepersonale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalecomportamento] ADD idperfvalutazionepersonale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalecomportamento') and col.name = 'idperfvalutazionepersonale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalecomportamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalecomportamento' and C.name = 'idperfvalutazionepersonalecomportamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalecomportamento] ADD idperfvalutazionepersonalecomportamento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalecomportamento') and col.name = 'idperfvalutazionepersonalecomportamento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalecomportamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalecomportamento' and C.name = 'idperfcomportamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalecomportamento] ADD idperfcomportamento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalecomportamento') and col.name = 'idperfcomportamento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalecomportamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalecomportamento' and C.name = 'completamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalecomportamento] ADD completamento decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonalecomportamento] ALTER COLUMN completamento decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalecomportamento' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalecomportamento] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalecomportamento') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalecomportamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonalecomportamento] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalecomportamento' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalecomportamento] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalecomportamento') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalecomportamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonalecomportamento] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalecomportamento' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalecomportamento] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalecomportamento') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalecomportamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonalecomportamento] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalecomportamento' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalecomportamento] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonalecomportamento') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonalecomportamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonalecomportamento] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalecomportamento' and C.name = 'peso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalecomportamento] ADD peso decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonalecomportamento] ALTER COLUMN peso decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonalecomportamento' and C.name = 'valorenumerico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonalecomportamento] ADD valorenumerico decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonalecomportamento] ALTER COLUMN valorenumerico decimal(19,2) NULL
GO

