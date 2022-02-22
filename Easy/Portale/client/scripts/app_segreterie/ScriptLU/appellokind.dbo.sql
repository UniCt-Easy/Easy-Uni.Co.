
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


-- CREAZIONE TABELLA appellokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appellokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[appellokind] (
idappellokind int NOT NULL,
active char(1) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkappellokind PRIMARY KEY (idappellokind
)
)
END
GO

-- VERIFICA STRUTTURA appellokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'idappellokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD idappellokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'idappellokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER appellokind --
IF exists(SELECT * FROM [appellokind] WHERE idappellokind = '1')
UPDATE [appellokind] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'esami' WHERE idappellokind = '1'
ELSE
INSERT INTO [appellokind] (idappellokind,active,description,lt,lu,sortcode,title) VALUES ('1','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','esami')
GO

IF exists(SELECT * FROM [appellokind] WHERE idappellokind = '2')
UPDATE [appellokind] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'conseguimento del titolo' WHERE idappellokind = '2'
ELSE
INSERT INTO [appellokind] (idappellokind,active,description,lt,lu,sortcode,title) VALUES ('2','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','conseguimento del titolo')
GO

IF exists(SELECT * FROM [appellokind] WHERE idappellokind = '3')
UPDATE [appellokind] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'esami di stato' WHERE idappellokind = '3'
ELSE
INSERT INTO [appellokind] (idappellokind,active,description,lt,lu,sortcode,title) VALUES ('3','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','3','esami di stato')
GO

