
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


-- CREAZIONE TABELLA studprenotkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[studprenotkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[studprenotkind] (
idstudprenotkind int NOT NULL,
active char(1) NOT NULL,
description varchar(512) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortorder int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkstudprenotkind PRIMARY KEY (idstudprenotkind
)
)
END
GO

-- VERIFICA STRUTTURA studprenotkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'idstudprenotkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD idstudprenotkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'idstudprenotkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD description varchar(512) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN description varchar(512) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'sortorder' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD sortorder int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'sortorder' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN sortorder int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER studprenotkind --
IF exists(SELECT * FROM [studprenotkind] WHERE idstudprenotkind = '1')
UPDATE [studprenotkind] SET active = 'S',description = 'Iscritto ad un corso dell''Istituto',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortorder = '2',title = 'Interno' WHERE idstudprenotkind = '1'
ELSE
INSERT INTO [studprenotkind] (idstudprenotkind,active,description,lt,lu,sortorder,title) VALUES ('1','S','Iscritto ad un corso dell''Istituto',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Interno')
GO

IF exists(SELECT * FROM [studprenotkind] WHERE idstudprenotkind = '2')
UPDATE [studprenotkind] SET active = 'S',description = 'Iscritto ad un corso dell''Istituto e docente altrove',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortorder = '3',title = 'Docente' WHERE idstudprenotkind = '2'
ELSE
INSERT INTO [studprenotkind] (idstudprenotkind,active,description,lt,lu,sortorder,title) VALUES ('2','S','Iscritto ad un corso dell''Istituto e docente altrove',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Docente')
GO

IF exists(SELECT * FROM [studprenotkind] WHERE idstudprenotkind = '3')
UPDATE [studprenotkind] SET active = 'S',description = 'Non è iscritto ad un corso dell''Istituto ma può prenotarsi ad appelli dedicati',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortorder = '1',title = 'Esterno' WHERE idstudprenotkind = '3'
ELSE
INSERT INTO [studprenotkind] (idstudprenotkind,active,description,lt,lu,sortorder,title) VALUES ('3','S','Non è iscritto ad un corso dell''Istituto ma può prenotarsi ad appelli dedicati',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Esterno')
GO

