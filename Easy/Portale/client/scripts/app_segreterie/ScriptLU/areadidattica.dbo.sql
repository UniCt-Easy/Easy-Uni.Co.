
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE TABELLA areadidattica --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[areadidattica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[areadidattica] (
idareadidattica int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu nvarchar(64) NOT NULL,
idcorsostudiokind int NOT NULL,
lt datetime NOT NULL,
lu nvarchar(64) NOT NULL,
sortcode int NOT NULL,
subtitle varchar(100) NULL,
title varchar(100) NOT NULL,
 CONSTRAINT xpkareadidattica PRIMARY KEY (idareadidattica
)
)
END
GO

-- VERIFICA STRUTTURA areadidattica --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'areadidattica' and C.name = 'idareadidattica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [areadidattica] ADD idareadidattica int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('areadidattica') and col.name = 'idareadidattica' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [areadidattica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'areadidattica' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [areadidattica] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('areadidattica') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [areadidattica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [areadidattica] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'areadidattica' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [areadidattica] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('areadidattica') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [areadidattica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [areadidattica] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'areadidattica' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [areadidattica] ADD cu nvarchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('areadidattica') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [areadidattica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [areadidattica] ALTER COLUMN cu nvarchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'areadidattica' and C.name = 'idcorsostudiokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [areadidattica] ADD idcorsostudiokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('areadidattica') and col.name = 'idcorsostudiokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [areadidattica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [areadidattica] ALTER COLUMN idcorsostudiokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'areadidattica' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [areadidattica] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('areadidattica') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [areadidattica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [areadidattica] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'areadidattica' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [areadidattica] ADD lu nvarchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('areadidattica') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [areadidattica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [areadidattica] ALTER COLUMN lu nvarchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'areadidattica' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [areadidattica] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('areadidattica') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [areadidattica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [areadidattica] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'areadidattica' and C.name = 'subtitle' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [areadidattica] ADD subtitle varchar(100) NULL 
END
ELSE
	ALTER TABLE [areadidattica] ALTER COLUMN subtitle varchar(100) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'areadidattica' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [areadidattica] ADD title varchar(100) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('areadidattica') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [areadidattica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [areadidattica] ALTER COLUMN title varchar(100) NOT NULL
GO


-- GENERAZIONE DATI PER areadidattica --
IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '1')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '5',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',subtitle = null,title = 'AREA MEDICA' WHERE idareadidattica = '1'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','5',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',null,'AREA MEDICA')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '2')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '5',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',subtitle = null,title = 'AREA CHIRURGICA ' WHERE idareadidattica = '2'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','5',{ts '2018-06-11 11:35:00.653'},'ferdinando','2',null,'AREA CHIRURGICA ')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '3')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '5',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',subtitle = 'SOTTO-AREA DEI SERVIZI CLINICI DIAGNOSTICI E TERAPEUTICI ',title = 'AREA SERVIZI CLINICI' WHERE idareadidattica = '3'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','5',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','SOTTO-AREA DEI SERVIZI CLINICI DIAGNOSTICI E TERAPEUTICI ','AREA SERVIZI CLINICI')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '4')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '5',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',subtitle = 'SOTTO-AREA DEI SERVIZI CLINICI ORGANIZZATIVI E DELLA SANITÀ PUBBLICA ',title = 'AREA SERVIZI CLINICI' WHERE idareadidattica = '4'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','5',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','SOTTO-AREA DEI SERVIZI CLINICI ORGANIZZATIVI E DELLA SANITÀ PUBBLICA ','AREA SERVIZI CLINICI')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '5')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',subtitle = null,title = 'Area 01 - Scienze matematiche e informatiche ' WHERE idareadidattica = '5'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','5',null,'Area 01 - Scienze matematiche e informatiche ')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '6')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',subtitle = null,title = 'Area 02 - Scienze fisiche' WHERE idareadidattica = '6'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','6',null,'Area 02 - Scienze fisiche')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '7')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',subtitle = null,title = 'Area 03 - Scienze chimiche' WHERE idareadidattica = '7'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('7','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','7',null,'Area 03 - Scienze chimiche')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '8')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '8',subtitle = null,title = 'Area 04 - Scienze della terra' WHERE idareadidattica = '8'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('8','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','8',null,'Area 04 - Scienze della terra')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '9')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '9',subtitle = null,title = 'Area 05 - Scienze biologiche' WHERE idareadidattica = '9'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('9','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','9',null,'Area 05 - Scienze biologiche')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '10')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '10',subtitle = null,title = 'Area 06 - Scienze mediche' WHERE idareadidattica = '10'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('10','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','10',null,'Area 06 - Scienze mediche')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '11')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '11',subtitle = null,title = 'Area 07 - Scienze agrarie e veterinarie' WHERE idareadidattica = '11'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('11','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','11',null,'Area 07 - Scienze agrarie e veterinarie')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '12')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '12',subtitle = null,title = 'Area 08 - Ingegneria civile e Architettura' WHERE idareadidattica = '12'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('12','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','12',null,'Area 08 - Ingegneria civile e Architettura')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '13')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '13',subtitle = null,title = 'Area 09 - Ingegneria industriale e dell''informazione' WHERE idareadidattica = '13'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('13','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','13',null,'Area 09 - Ingegneria industriale e dell''informazione')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '14')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '14',subtitle = null,title = 'Area 10 - Scienze dell''antichità, filologico-letterarie e storico-artistiche ' WHERE idareadidattica = '14'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('14','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','14',null,'Area 10 - Scienze dell''antichità, filologico-letterarie e storico-artistiche ')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '15')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '15',subtitle = null,title = 'Area 11 - Scienze storiche, filosofiche, pedagogiche e psicologiche' WHERE idareadidattica = '15'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('15','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','15',null,'Area 11 - Scienze storiche, filosofiche, pedagogiche e psicologiche')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '16')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '16',subtitle = null,title = 'Area 12 - Scienze giuridiche' WHERE idareadidattica = '16'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('16','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','16',null,'Area 12 - Scienze giuridiche')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '17')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '17',subtitle = null,title = 'Area 13 - Scienze economiche e statistiche' WHERE idareadidattica = '17'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('17','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','17',null,'Area 13 - Scienze economiche e statistiche')
GO

IF exists(SELECT * FROM [areadidattica] WHERE idareadidattica = '18')
UPDATE [areadidattica] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '18',subtitle = null,title = 'Area 14 - Scienze politiche e sociali' WHERE idareadidattica = '18'
ELSE
INSERT INTO [areadidattica] (idareadidattica,active,ct,cu,idcorsostudiokind,lt,lu,sortcode,subtitle,title) VALUES ('18','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','18',null,'Area 14 - Scienze politiche e sociali')
GO

