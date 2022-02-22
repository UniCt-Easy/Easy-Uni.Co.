
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


-- CREAZIONE TABELLA address --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[address]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[address] (
idaddress int NOT NULL,
active char(1) NULL,
codeaddress varchar(20) NOT NULL,
description varchar(60) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkaddress PRIMARY KEY (idaddress
)
)
END
GO

-- VERIFICA STRUTTURA address --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'idaddress' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD idaddress int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('address') and col.name = 'idaddress' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [address] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [address] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'codeaddress' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD codeaddress varchar(20) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('address') and col.name = 'codeaddress' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [address] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [address] ALTER COLUMN codeaddress varchar(20) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD description varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('address') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [address] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [address] ALTER COLUMN description varchar(60) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [address] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [address] ALTER COLUMN lu varchar(64) NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukaddress' and id=object_id('address'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukaddress
     ON address (codeaddress )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukaddress
     ON address (codeaddress )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1address' and id=object_id('address'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1address
     ON address (codeaddress )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1address
     ON address (codeaddress )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

