
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


-- CREAZIONE TABELLA erogazkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[erogazkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[erogazkind] (
iderogazkind int NOT NULL,
active char(1) NOT NULL,
ans varchar(10) NULL,
description varchar(255) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkerogazkind PRIMARY KEY (iderogazkind
)
)
END
GO

-- VERIFICA STRUTTURA erogazkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'iderogazkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD iderogazkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'iderogazkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'ans' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD ans varchar(10) NULL 
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN ans varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD description varchar(255) NULL 
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN description varchar(255) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER erogazkind --
IF exists(SELECT * FROM [erogazkind] WHERE iderogazkind = '1')
UPDATE [erogazkind] SET active = 'S',ans = 'C',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Convenzionale' WHERE iderogazkind = '1'
ELSE
INSERT INTO [erogazkind] (iderogazkind,active,ans,description,lt,lu,sortcode,title) VALUES ('1','S','C',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Convenzionale')
GO

IF exists(SELECT * FROM [erogazkind] WHERE iderogazkind = '2')
UPDATE [erogazkind] SET active = 'S',ans = 'T',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Teledidattica' WHERE iderogazkind = '2'
ELSE
INSERT INTO [erogazkind] (iderogazkind,active,ans,description,lt,lu,sortcode,title) VALUES ('2','S','T',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Teledidattica')
GO

IF exists(SELECT * FROM [erogazkind] WHERE iderogazkind = '3')
UPDATE [erogazkind] SET active = 'S',ans = null,description = 'replicato con didattica frontale e in teledidattica',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Doppia ' WHERE iderogazkind = '3'
ELSE
INSERT INTO [erogazkind] (iderogazkind,active,ans,description,lt,lu,sortcode,title) VALUES ('3','S',null,'replicato con didattica frontale e in teledidattica',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Doppia ')
GO

IF exists(SELECT * FROM [erogazkind] WHERE iderogazkind = '4')
UPDATE [erogazkind] SET active = 'S',ans = 'P',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Prevalentemente a distanza' WHERE iderogazkind = '4'
ELSE
INSERT INTO [erogazkind] (iderogazkind,active,ans,description,lt,lu,sortcode,title) VALUES ('4','S','P',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Prevalentemente a distanza')
GO

IF exists(SELECT * FROM [erogazkind] WHERE iderogazkind = '5')
UPDATE [erogazkind] SET active = 'S',ans = 'B',description = 'insegnamenti o parte di insegnamenti in didattica frontale e didattica in teledidattica',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'Blended/Modalità Mista' WHERE iderogazkind = '5'
ELSE
INSERT INTO [erogazkind] (iderogazkind,active,ans,description,lt,lu,sortcode,title) VALUES ('5','S','B','insegnamenti o parte di insegnamenti in didattica frontale e didattica in teledidattica',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Blended/Modalità Mista')
GO

