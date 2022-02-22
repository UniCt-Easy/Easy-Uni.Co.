
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


-- CREAZIONE TABELLA corsostudiolivello --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiolivello]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[corsostudiolivello] (
idcorsostudiolivello int NOT NULL,
idcorsostudiokind int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NULL,
 CONSTRAINT xpkcorsostudiolivello PRIMARY KEY (idcorsostudiolivello
)
)
END
GO

-- VERIFICA STRUTTURA corsostudiolivello --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiolivello' and C.name = 'idcorsostudiolivello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiolivello] ADD idcorsostudiolivello int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiolivello') and col.name = 'idcorsostudiolivello' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiolivello] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiolivello' and C.name = 'idcorsostudiokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiolivello] ADD idcorsostudiokind int NULL 
END
ELSE
	ALTER TABLE [corsostudiolivello] ALTER COLUMN idcorsostudiokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiolivello' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiolivello] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiolivello') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiolivello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiolivello] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiolivello' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiolivello] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiolivello') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiolivello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiolivello] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiolivello' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiolivello] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [corsostudiolivello] ALTER COLUMN title varchar(50) NULL
GO


-- GENERAZIONE DATI PER corsostudiolivello --
IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '1')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '11',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Primo livello' WHERE idcorsostudiolivello = '1'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('1','11',{ts '2018-06-11 11:35:00.653'},'ferdinando','Primo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '2')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '11',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Secondo livello' WHERE idcorsostudiolivello = '2'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('2','11',{ts '2018-06-11 11:35:00.653'},'ferdinando','Secondo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '3')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Primo livello' WHERE idcorsostudiolivello = '3'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('3','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','Primo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '4')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Secondo livello' WHERE idcorsostudiolivello = '4'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('4','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','Secondo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '5')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '3',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Primo livello' WHERE idcorsostudiolivello = '5'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('5','3',{ts '2018-06-11 11:35:00.653'},'ferdinando','Primo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '6')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '3',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Secondo livello' WHERE idcorsostudiolivello = '6'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('6','3',{ts '2018-06-11 11:35:00.653'},'ferdinando','Secondo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '7')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Corso di laurea' WHERE idcorsostudiolivello = '7'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('7','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','Corso di laurea')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '8')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Corso di laurea magistrale' WHERE idcorsostudiolivello = '8'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('8','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','Corso di laurea magistrale')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '9')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Corso di laurea magistrale c. u.' WHERE idcorsostudiolivello = '9'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('9','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','Corso di laurea magistrale c. u.')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '10')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '6',lt = {ts '2020-05-15 16:08:59.883'},lu = 'ASSISTENZA',title = 'test_e2e_cHokFVhPWtPtjHRBvLcfROEYtVqXujOvnhdMcWNjT' WHERE idcorsostudiolivello = '10'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('10','6',{ts '2020-05-15 16:08:59.883'},'ASSISTENZA','test_e2e_cHokFVhPWtPtjHRBvLcfROEYtVqXujOvnhdMcWNjT')
GO

