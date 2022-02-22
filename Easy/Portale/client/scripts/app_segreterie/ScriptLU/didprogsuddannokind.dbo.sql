
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


-- CREAZIONE TABELLA didprogsuddannokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogsuddannokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprogsuddannokind] (
iddidprogsuddannokind int NOT NULL,
active char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
title varchar(50) NULL,
 CONSTRAINT xpkdidprogsuddannokind PRIMARY KEY (iddidprogsuddannokind
)
)
END
GO

-- VERIFICA STRUTTURA didprogsuddannokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'iddidprogsuddannokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD iddidprogsuddannokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogsuddannokind') and col.name = 'iddidprogsuddannokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogsuddannokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [didprogsuddannokind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogsuddannokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogsuddannokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogsuddannokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogsuddannokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogsuddannokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogsuddannokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [didprogsuddannokind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [didprogsuddannokind] ALTER COLUMN title varchar(50) NULL
GO


-- GENERAZIONE DATI PER didprogsuddannokind --
IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '1')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'mensile' WHERE iddidprogsuddannokind = '1'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','mensile')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '2')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'bimestrale' WHERE iddidprogsuddannokind = '2'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','bimestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '3')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'trimestrale' WHERE iddidprogsuddannokind = '3'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','trimestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '4')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'quadrimestrale' WHERE iddidprogsuddannokind = '4'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','quadrimestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '5')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'semestrale' WHERE iddidprogsuddannokind = '5'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','semestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '6')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'annuale' WHERE iddidprogsuddannokind = '6'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','6','annuale')
GO

