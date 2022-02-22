
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


-- CREAZIONE TABELLA duratakind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[duratakind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[duratakind] (
idduratakind int NOT NULL,
active char(1) NOT NULL,
ans varchar(10) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkduratakind PRIMARY KEY (idduratakind
)
)
END
GO

-- VERIFICA STRUTTURA duratakind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'duratakind' and C.name = 'idduratakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [duratakind] ADD idduratakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('duratakind') and col.name = 'idduratakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [duratakind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'duratakind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [duratakind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('duratakind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [duratakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [duratakind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'duratakind' and C.name = 'ans' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [duratakind] ADD ans varchar(10) NULL 
END
ELSE
	ALTER TABLE [duratakind] ALTER COLUMN ans varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'duratakind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [duratakind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('duratakind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [duratakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [duratakind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'duratakind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [duratakind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('duratakind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [duratakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [duratakind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'duratakind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [duratakind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('duratakind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [duratakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [duratakind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'duratakind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [duratakind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('duratakind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [duratakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [duratakind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER duratakind --
IF exists(SELECT * FROM [duratakind] WHERE idduratakind = '1')
UPDATE [duratakind] SET active = 'S',ans = 'A',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'anni' WHERE idduratakind = '1'
ELSE
INSERT INTO [duratakind] (idduratakind,active,ans,lt,lu,sortcode,title) VALUES ('1','S','A',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','anni')
GO

IF exists(SELECT * FROM [duratakind] WHERE idduratakind = '2')
UPDATE [duratakind] SET active = 'S',ans = 'M',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'mesi' WHERE idduratakind = '2'
ELSE
INSERT INTO [duratakind] (idduratakind,active,ans,lt,lu,sortcode,title) VALUES ('2','S','M',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','mesi')
GO

IF exists(SELECT * FROM [duratakind] WHERE idduratakind = '3')
UPDATE [duratakind] SET active = 'S',ans = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'settimane' WHERE idduratakind = '3'
ELSE
INSERT INTO [duratakind] (idduratakind,active,ans,lt,lu,sortcode,title) VALUES ('3','S','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','settimane')
GO

IF exists(SELECT * FROM [duratakind] WHERE idduratakind = '4')
UPDATE [duratakind] SET active = 'S',ans = 'G',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'giorni' WHERE idduratakind = '4'
ELSE
INSERT INTO [duratakind] (idduratakind,active,ans,lt,lu,sortcode,title) VALUES ('4','S','G',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','giorni')
GO

IF exists(SELECT * FROM [duratakind] WHERE idduratakind = '5')
UPDATE [duratakind] SET active = 'S',ans = 'O',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'ore' WHERE idduratakind = '5'
ELSE
INSERT INTO [duratakind] (idduratakind,active,ans,lt,lu,sortcode,title) VALUES ('5','S','O',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','ore')
GO

IF exists(SELECT * FROM [duratakind] WHERE idduratakind = '6')
UPDATE [duratakind] SET active = 'S',ans = '9',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'altro' WHERE idduratakind = '6'
ELSE
INSERT INTO [duratakind] (idduratakind,active,ans,lt,lu,sortcode,title) VALUES ('6','S','9',{ts '2018-06-11 11:35:00.653'},'ferdinando','6','altro')
GO

