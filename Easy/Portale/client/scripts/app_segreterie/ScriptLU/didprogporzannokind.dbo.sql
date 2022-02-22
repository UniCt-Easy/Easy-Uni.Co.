
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


-- CREAZIONE TABELLA didprogporzannokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogporzannokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprogporzannokind] (
iddidprogporzannokind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkdidprogporzannokind PRIMARY KEY (iddidprogporzannokind
)
)
END
GO

-- VERIFICA STRUTTURA didprogporzannokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzannokind' and C.name = 'iddidprogporzannokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzannokind] ADD iddidprogporzannokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzannokind') and col.name = 'iddidprogporzannokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzannokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzannokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzannokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzannokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzannokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogporzannokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzannokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzannokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzannokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzannokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogporzannokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzannokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzannokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzannokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzannokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogporzannokind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER didprogporzannokind --
IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '1')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',title = 'Mensile' WHERE iddidprogporzannokind = '1'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('1',{ts '2018-06-11 11:35:00.653'},'ferdinando','Mensile')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '2')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Bimestrale' WHERE iddidprogporzannokind = '2'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('2',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Bimestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '3')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Trimestrale' WHERE iddidprogporzannokind = '3'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('3',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Trimestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '4')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Quadrimestrale' WHERE iddidprogporzannokind = '4'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('4',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Quadrimestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '5')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Semestrale' WHERE iddidprogporzannokind = '5'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('5',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Semestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '6')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Annuale' WHERE iddidprogporzannokind = '6'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('6',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Annuale')
GO

