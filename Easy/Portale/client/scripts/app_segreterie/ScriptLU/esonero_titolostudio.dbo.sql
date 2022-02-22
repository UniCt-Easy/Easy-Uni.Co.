
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


-- CREAZIONE TABELLA esonero_titolostudio --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[esonero_titolostudio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[esonero_titolostudio] (
idesonero int NOT NULL,
conseguitoincorso char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
dataconstutticf date NULL,
datalaurea date NULL,
idstruttura int NULL,
lt datetime NULL,
lu varchar(64) NULL,
nellistituto char(1) NULL,
noabbr char(1) NULL,
noparttime char(1) NULL,
votomin int NULL,
 CONSTRAINT xpkesonero_titolostudio PRIMARY KEY (idesonero
)
)
END
GO

-- VERIFICA STRUTTURA esonero_titolostudio --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'idesonero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD idesonero int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('esonero_titolostudio') and col.name = 'idesonero' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [esonero_titolostudio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'conseguitoincorso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD conseguitoincorso char(1) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN conseguitoincorso char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'dataconstutticf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD dataconstutticf date NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN dataconstutticf date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'datalaurea' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD datalaurea date NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN datalaurea date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'nellistituto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD nellistituto char(1) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN nellistituto char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'noabbr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD noabbr char(1) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN noabbr char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'noparttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD noparttime char(1) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN noparttime char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'votomin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD votomin int NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN votomin int NULL
GO

