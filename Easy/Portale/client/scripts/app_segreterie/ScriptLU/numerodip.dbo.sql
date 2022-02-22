
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


-- CREAZIONE TABELLA numerodip --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[numerodip]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[numerodip] (
idnumerodip int NOT NULL,
active varchar(1) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NOT NULL,
title nvarchar(50) NOT NULL,
 CONSTRAINT xpknumerodip PRIMARY KEY (idnumerodip
)
)
END
GO

-- VERIFICA STRUTTURA numerodip --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'idnumerodip' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD idnumerodip int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('numerodip') and col.name = 'idnumerodip' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [numerodip] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD active varchar(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('numerodip') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [numerodip] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [numerodip] ALTER COLUMN active varchar(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [numerodip] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [numerodip] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('numerodip') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [numerodip] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [numerodip] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD title nvarchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('numerodip') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [numerodip] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [numerodip] ALTER COLUMN title nvarchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER numerodip --
IF exists(SELECT * FROM [numerodip] WHERE idnumerodip = '1')
UPDATE [numerodip] SET active = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = '1-14' WHERE idnumerodip = '1'
ELSE
INSERT INTO [numerodip] (idnumerodip,active,lt,lu,sortcode,title) VALUES ('1','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','1-14')
GO

IF exists(SELECT * FROM [numerodip] WHERE idnumerodip = '2')
UPDATE [numerodip] SET active = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = '15-49' WHERE idnumerodip = '2'
ELSE
INSERT INTO [numerodip] (idnumerodip,active,lt,lu,sortcode,title) VALUES ('2','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','15-49')
GO

IF exists(SELECT * FROM [numerodip] WHERE idnumerodip = '3')
UPDATE [numerodip] SET active = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '3',title = '50-249' WHERE idnumerodip = '3'
ELSE
INSERT INTO [numerodip] (idnumerodip,active,lt,lu,sortcode,title) VALUES ('3','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','50-249')
GO

IF exists(SELECT * FROM [numerodip] WHERE idnumerodip = '4')
UPDATE [numerodip] SET active = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '4',title = '>250' WHERE idnumerodip = '4'
ELSE
INSERT INTO [numerodip] (idnumerodip,active,lt,lu,sortcode,title) VALUES ('4','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','4','>250')
GO

