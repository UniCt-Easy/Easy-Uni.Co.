
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


-- CREAZIONE TABELLA sasdgruppo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasdgruppo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sasdgruppo] (
idsasdgruppo int NOT NULL,
idtipoattform int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NULL,
 CONSTRAINT xpksasdgruppo PRIMARY KEY (idsasdgruppo,
idtipoattform
)
)
END
GO

-- VERIFICA STRUTTURA sasdgruppo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'idsasdgruppo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD idsasdgruppo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'idsasdgruppo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'idtipoattform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD idtipoattform int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'idtipoattform' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasdgruppo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasdgruppo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasdgruppo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasdgruppo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [sasdgruppo] ALTER COLUMN title varchar(50) NULL
GO


-- GENERAZIONE DATI PER sasdgruppo --
IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '1' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A11' WHERE idsasdgruppo = '1' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('1','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A11')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '2' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A12' WHERE idsasdgruppo = '2' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('2','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A12')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '3' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A13' WHERE idsasdgruppo = '3' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('3','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A13')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '4' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A14' WHERE idsasdgruppo = '4' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('4','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A14')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '5' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A15' WHERE idsasdgruppo = '5' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('5','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A15')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '6' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A21' WHERE idsasdgruppo = '6' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('6','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A21')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '7' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A22' WHERE idsasdgruppo = '7' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('7','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A22')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '8' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A23' WHERE idsasdgruppo = '8' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('8','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A23')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '9' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A24' WHERE idsasdgruppo = '9' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('9','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A24')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '10' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A24' WHERE idsasdgruppo = '10' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('10','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A24')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '11' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A31' WHERE idsasdgruppo = '11' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('11','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A31')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '12' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A32' WHERE idsasdgruppo = '12' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('12','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A32')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '13' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A33' WHERE idsasdgruppo = '13' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('13','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A33')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '14' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A34' WHERE idsasdgruppo = '14' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('14','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A34')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '15' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A35' WHERE idsasdgruppo = '15' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('15','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A35')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '16' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C11' WHERE idsasdgruppo = '16' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('16','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C11')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '17' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C12' WHERE idsasdgruppo = '17' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('17','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C12')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '18' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C13' WHERE idsasdgruppo = '18' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('18','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C13')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '19' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C14' WHERE idsasdgruppo = '19' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('19','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C14')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '20' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C15' WHERE idsasdgruppo = '20' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('20','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C15')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '21' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C21' WHERE idsasdgruppo = '21' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('21','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C21')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '22' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C22' WHERE idsasdgruppo = '22' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('22','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C22')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '23' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C23' WHERE idsasdgruppo = '23' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('23','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C23')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '24' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C24' WHERE idsasdgruppo = '24' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('24','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C24')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '25' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C25' WHERE idsasdgruppo = '25' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('25','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C25')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '26' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C31' WHERE idsasdgruppo = '26' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('26','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C31')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '27' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C32' WHERE idsasdgruppo = '27' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('27','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C32')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '28' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C33' WHERE idsasdgruppo = '28' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('28','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C33')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '29' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C34' WHERE idsasdgruppo = '29' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('29','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C34')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '30' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C35' WHERE idsasdgruppo = '30' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('30','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C35')
GO

