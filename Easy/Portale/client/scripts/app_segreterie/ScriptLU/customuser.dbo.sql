
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


-- CREAZIONE TABELLA customuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customuser] (
idcustomuser varchar(50) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
username varchar(50) NOT NULL,
 CONSTRAINT xpkcustomuser PRIMARY KEY (idcustomuser
)
)
END
GO

-- VERIFICA STRUTTURA customuser --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'idcustomuser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD idcustomuser varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('customuser') and col.name = 'idcustomuser' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [customuser] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'lastmodtimestamp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD lastmodtimestamp datetime NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN lastmodtimestamp datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'lastmoduser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD lastmoduser varchar(64) NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN lastmoduser varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'username' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD username varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('customuser') and col.name = 'username' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [customuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN username varchar(50) NOT NULL
GO

