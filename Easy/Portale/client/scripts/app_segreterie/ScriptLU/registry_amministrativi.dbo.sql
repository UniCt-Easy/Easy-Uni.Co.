
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


-- CREAZIONE TABELLA registry_amministrativi --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_amministrativi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_amministrativi] (
idreg int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
cv nvarchar(max) NULL,
idcontrattokind int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkregistry_amministrativi PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_amministrativi --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_amministrativi') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_amministrativi] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'cv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD cv nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN cv nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN lu varchar(64) NULL
GO

