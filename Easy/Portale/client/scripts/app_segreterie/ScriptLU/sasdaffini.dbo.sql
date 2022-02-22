
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


-- CREAZIONE TABELLA sasdaffini --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasdaffini]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sasdaffini] (
idsasd int NOT NULL,
idsasd_affine int NOT NULL,
affinita int NOT NULL,
 CONSTRAINT xpksasdaffini PRIMARY KEY (idsasd,
idsasd_affine
)
)
END
GO

-- VERIFICA STRUTTURA sasdaffini --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdaffini' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdaffini] ADD idsasd int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdaffini') and col.name = 'idsasd' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdaffini] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdaffini' and C.name = 'idsasd_affine' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdaffini] ADD idsasd_affine int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdaffini') and col.name = 'idsasd_affine' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdaffini] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdaffini' and C.name = 'affinita' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdaffini] ADD affinita int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdaffini') and col.name = 'affinita' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdaffini] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasdaffini] ALTER COLUMN affinita int NOT NULL
GO

