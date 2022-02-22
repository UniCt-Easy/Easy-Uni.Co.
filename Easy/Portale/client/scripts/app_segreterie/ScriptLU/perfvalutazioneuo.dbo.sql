
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


-- CREAZIONE TABELLA perfvalutazioneuo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazioneuo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazioneuo] (
idperfvalutazioneuo int NOT NULL,
idstruttura int NOT NULL,
completamentopsauo decimal(19,2) NULL,
completamentopsuo decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idperfschedastatus int NULL,
idreg_appr int NULL,
idreg_val int NULL,
indicatori decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
obiettiviindividuali decimal(19,2) NULL,
pesoindicatori decimal(19,2) NULL,
pesoobiettivi decimal(19,2) NULL,
pesoprogaltreuo decimal(19,2) NULL,
pesoproguo decimal(19,2) NULL,
risultato decimal(19,2) NULL,
year int NULL,
 CONSTRAINT xpkperfvalutazioneuo PRIMARY KEY (idperfvalutazioneuo,
idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazioneuo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'idperfvalutazioneuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD idperfvalutazioneuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'idperfvalutazioneuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'completamentopsauo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD completamentopsauo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN completamentopsauo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'completamentopsuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD completamentopsuo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN completamentopsuo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'idperfschedastatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD idperfschedastatus int NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN idperfschedastatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'idreg_appr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD idreg_appr int NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN idreg_appr int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'idreg_val' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD idreg_val int NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN idreg_val int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'indicatori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD indicatori decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN indicatori decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'obiettiviindividuali' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD obiettiviindividuali decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN obiettiviindividuali decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'pesoindicatori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD pesoindicatori decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN pesoindicatori decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'pesoobiettivi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD pesoobiettivi decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN pesoobiettivi decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'pesoprogaltreuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD pesoprogaltreuo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN pesoprogaltreuo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'pesoproguo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD pesoproguo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN pesoproguo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'risultato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD risultato decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN risultato decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD year int NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN year int NULL
GO

