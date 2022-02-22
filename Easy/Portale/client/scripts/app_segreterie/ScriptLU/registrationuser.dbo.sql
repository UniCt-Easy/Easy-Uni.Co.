
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


-- CREAZIONE TABELLA registrationuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrationuser] (
idregistrationuser int NOT NULL,
cf varchar(16) NULL,
email varchar(1024) NULL,
esercizio int NULL,
forename varchar(49) NULL,
idregistrationuserstatus int NULL,
login varchar(60) NULL,
matricola varchar(50) NULL,
surname varchar(50) NULL,
userkind int NULL,
usertype varchar(50) NULL,
 CONSTRAINT xpkregistrationuser PRIMARY KEY (idregistrationuser
)
)
END
GO

-- VERIFICA STRUTTURA registrationuser --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'idregistrationuser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD idregistrationuser int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registrationuser') and col.name = 'idregistrationuser' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registrationuser] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD cf varchar(16) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN cf varchar(16) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'email' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD email varchar(1024) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN email varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'esercizio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD esercizio int NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN esercizio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'forename' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD forename varchar(49) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN forename varchar(49) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'idregistrationuserstatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD idregistrationuserstatus int NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN idregistrationuserstatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'login' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD login varchar(60) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN login varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'matricola' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD matricola varchar(50) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN matricola varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'surname' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD surname varchar(50) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN surname varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'userkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD userkind int NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN userkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'usertype' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD usertype varchar(50) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN usertype varchar(50) NULL
GO

