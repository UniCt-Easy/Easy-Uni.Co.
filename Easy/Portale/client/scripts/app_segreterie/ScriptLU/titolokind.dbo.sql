
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


-- CREAZIONE TABELLA titolokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[titolokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[titolokind] (
idtitolokind int NOT NULL,
active char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpktitolokind PRIMARY KEY (idtitolokind
)
)
END
GO

-- VERIFICA STRUTTURA titolokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolokind' and C.name = 'idtitolokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolokind] ADD idtitolokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolokind') and col.name = 'idtitolokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [titolokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [titolokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [titolokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [titolokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'titolokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [titolokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('titolokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [titolokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [titolokind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER titolokind --
IF exists(SELECT * FROM [titolokind] WHERE idtitolokind = '1')
UPDATE [titolokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Normale' WHERE idtitolokind = '1'
ELSE
INSERT INTO [titolokind] (idtitolokind,active,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Normale')
GO

IF exists(SELECT * FROM [titolokind] WHERE idtitolokind = '2')
UPDATE [titolokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Congiunto' WHERE idtitolokind = '2'
ELSE
INSERT INTO [titolokind] (idtitolokind,active,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Congiunto')
GO

IF exists(SELECT * FROM [titolokind] WHERE idtitolokind = '3')
UPDATE [titolokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Doppio' WHERE idtitolokind = '3'
ELSE
INSERT INTO [titolokind] (idtitolokind,active,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Doppio')
GO

