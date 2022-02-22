
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


-- CREAZIONE TABELLA perfvalutazionepersonaleuo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazionepersonaleuo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazionepersonaleuo] (
idperfvalutazionepersonale int NOT NULL,
idperfvalutazionepersonaleuo int NOT NULL,
idstruttura int NOT NULL,
afferenza decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
peso decimal(19,2) NULL,
punteggio decimal(19,2) NULL,
punteggiopesato decimal(19,2) NULL,
 CONSTRAINT xpkperfvalutazionepersonaleuo PRIMARY KEY (idperfvalutazionepersonale,
idperfvalutazionepersonaleuo,
idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazionepersonaleuo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'idperfvalutazionepersonale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD idperfvalutazionepersonale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleuo') and col.name = 'idperfvalutazionepersonale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'idperfvalutazionepersonaleuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD idperfvalutazionepersonaleuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleuo') and col.name = 'idperfvalutazionepersonaleuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleuo') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'afferenza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD afferenza decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleuo] ALTER COLUMN afferenza decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleuo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleuo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleuo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleuo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleuo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleuo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleuo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleuo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'peso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD peso decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleuo] ALTER COLUMN peso decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'punteggio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD punteggio decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleuo] ALTER COLUMN punteggio decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleuo' and C.name = 'punteggiopesato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleuo] ADD punteggiopesato decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleuo] ALTER COLUMN punteggiopesato decimal(19,2) NULL
GO

