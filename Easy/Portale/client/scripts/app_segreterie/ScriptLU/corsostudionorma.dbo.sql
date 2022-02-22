
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


-- CREAZIONE TABELLA corsostudionorma --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudionorma]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[corsostudionorma] (
idcorsostudionorma int NOT NULL,
idistitutokind int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkcorsostudionorma PRIMARY KEY (idcorsostudionorma
)
)
END
GO

-- VERIFICA STRUTTURA corsostudionorma --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudionorma' and C.name = 'idcorsostudionorma' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudionorma] ADD idcorsostudionorma int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudionorma') and col.name = 'idcorsostudionorma' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudionorma] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudionorma' and C.name = 'idistitutokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudionorma] ADD idistitutokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudionorma') and col.name = 'idistitutokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudionorma] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudionorma] ALTER COLUMN idistitutokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudionorma' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudionorma] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudionorma') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudionorma] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudionorma] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudionorma' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudionorma] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudionorma') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudionorma] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudionorma] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudionorma' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudionorma] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudionorma') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudionorma] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudionorma] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER corsostudionorma --
IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '1')
UPDATE [corsostudionorma] SET idistitutokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Precedente alla riforma D.M.508/1999' WHERE idcorsostudionorma = '1'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('1','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','Precedente alla riforma D.M.508/1999')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '2')
UPDATE [corsostudionorma] SET idistitutokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'I livello D.M.482/2008' WHERE idcorsostudionorma = '2'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('2','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','I livello D.M.482/2008')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '3')
UPDATE [corsostudionorma] SET idistitutokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello D.M.626/2003' WHERE idcorsostudionorma = '3'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('3','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello D.M.626/2003')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '4')
UPDATE [corsostudionorma] SET idistitutokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello abilitanti D.M.82/2004' WHERE idcorsostudionorma = '4'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('4','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello abilitanti D.M.82/2004')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '5')
UPDATE [corsostudionorma] SET idistitutokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello abilitanti D.M.302/2010' WHERE idcorsostudionorma = '5'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('5','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello abilitanti D.M.302/2010')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '6')
UPDATE [corsostudionorma] SET idistitutokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello sostegno D.M.56/2006' WHERE idcorsostudionorma = '6'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('6','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello sostegno D.M.56/2006')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '7')
UPDATE [corsostudionorma] SET idistitutokind = '4',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Precedente alla riforma D.M.508/1999' WHERE idcorsostudionorma = '7'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('7','4',{ts '2018-06-11 11:35:00.653'},'ferdinando','Precedente alla riforma D.M.508/1999')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '8')
UPDATE [corsostudionorma] SET idistitutokind = '4',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'I livello D.M.483/2008' WHERE idcorsostudionorma = '8'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('8','4',{ts '2018-06-11 11:35:00.653'},'ferdinando','I livello D.M.483/2008')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '9')
UPDATE [corsostudionorma] SET idistitutokind = '4',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello D.M.1/2004' WHERE idcorsostudionorma = '9'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('9','4',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello D.M.1/2004')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '10')
UPDATE [corsostudionorma] SET idistitutokind = '4',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello abilitanti D.M.100/2004' WHERE idcorsostudionorma = '10'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('10','4',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello abilitanti D.M.100/2004')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '11')
UPDATE [corsostudionorma] SET idistitutokind = '4',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello abilitanti D.M.137/2007' WHERE idcorsostudionorma = '11'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('11','4',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello abilitanti D.M.137/2007')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '12')
UPDATE [corsostudionorma] SET idistitutokind = '5',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Precedente alla riforma D.M.508/1999' WHERE idcorsostudionorma = '12'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('12','5',{ts '2018-06-11 11:35:00.653'},'ferdinando','Precedente alla riforma D.M.508/1999')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '13')
UPDATE [corsostudionorma] SET idistitutokind = '5',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'I livello D.M.483/2008' WHERE idcorsostudionorma = '13'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('13','5',{ts '2018-06-11 11:35:00.653'},'ferdinando','I livello D.M.483/2008')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '14')
UPDATE [corsostudionorma] SET idistitutokind = '5',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello D.M.1/2004' WHERE idcorsostudionorma = '14'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('14','5',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello D.M.1/2004')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '15')
UPDATE [corsostudionorma] SET idistitutokind = '5',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello abilitanti D.M.100/2004' WHERE idcorsostudionorma = '15'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('15','5',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello abilitanti D.M.100/2004')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '16')
UPDATE [corsostudionorma] SET idistitutokind = '5',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello abilitanti D.M.137/2007' WHERE idcorsostudionorma = '16'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('16','5',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello abilitanti D.M.137/2007')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '17')
UPDATE [corsostudionorma] SET idistitutokind = '3',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Precedente alla riforma D.M.508/1999' WHERE idcorsostudionorma = '17'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('17','3',{ts '2018-06-11 11:35:00.653'},'ferdinando','Precedente alla riforma D.M.508/1999')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '18')
UPDATE [corsostudionorma] SET idistitutokind = '3',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'I livello D.M.23/2008' WHERE idcorsostudionorma = '18'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('18','3',{ts '2018-06-11 11:35:00.653'},'ferdinando','I livello D.M.23/2008')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '19')
UPDATE [corsostudionorma] SET idistitutokind = '3',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'I livello D.M.109/2010' WHERE idcorsostudionorma = '19'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('19','3',{ts '2018-06-11 11:35:00.653'},'ferdinando','I livello D.M.109/2010')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '20')
UPDATE [corsostudionorma] SET idistitutokind = '3',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello D.M.93/2004' WHERE idcorsostudionorma = '20'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('20','3',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello D.M.93/2004')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '21')
UPDATE [corsostudionorma] SET idistitutokind = '3',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello D.M.92/2004' WHERE idcorsostudionorma = '21'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('21','3',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello D.M.92/2004')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '22')
UPDATE [corsostudionorma] SET idistitutokind = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Precedente alla riforma D.M.508/1999' WHERE idcorsostudionorma = '22'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('22','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','Precedente alla riforma D.M.508/1999')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '23')
UPDATE [corsostudionorma] SET idistitutokind = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'I livello D.M.22/2010' WHERE idcorsostudionorma = '23'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('23','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','I livello D.M.22/2010')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '24')
UPDATE [corsostudionorma] SET idistitutokind = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'II livello D.M.631/2003' WHERE idcorsostudionorma = '24'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('24','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','II livello D.M.631/2003')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '25')
UPDATE [corsostudionorma] SET idistitutokind = '6',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Precedente alla riforma D.M.508/1999' WHERE idcorsostudionorma = '25'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('25','6',{ts '2018-06-11 11:35:00.653'},'ferdinando','Precedente alla riforma D.M.508/1999')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '26')
UPDATE [corsostudionorma] SET idistitutokind = '6',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'I livello D.M.17/2010' WHERE idcorsostudionorma = '26'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('26','6',{ts '2018-06-11 11:35:00.653'},'ferdinando','I livello D.M.17/2010')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '27')
UPDATE [corsostudionorma] SET idistitutokind = '9',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Lauree precedenti alla riforma D.M.509/1999' WHERE idcorsostudionorma = '27'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('27','9',{ts '2018-06-11 11:35:00.653'},'ferdinando','Lauree precedenti alla riforma D.M.509/1999')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '28')
UPDATE [corsostudionorma] SET idistitutokind = '10',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Lauree precedenti alla riforma D.M.509/1999' WHERE idcorsostudionorma = '28'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('28','10',{ts '2018-06-11 11:35:00.653'},'ferdinando','Lauree precedenti alla riforma D.M.509/1999')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '29')
UPDATE [corsostudionorma] SET idistitutokind = '9',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Scuole di specializzazione D.I.68/2015' WHERE idcorsostudionorma = '29'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('29','9',{ts '2018-06-11 11:35:00.653'},'ferdinando','Scuole di specializzazione D.I.68/2015')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '30')
UPDATE [corsostudionorma] SET idistitutokind = '9',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Scuole di specializzazione D.M.1/8/2005' WHERE idcorsostudionorma = '30'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('30','9',{ts '2018-06-11 11:35:00.653'},'ferdinando','Scuole di specializzazione D.M.1/8/2005')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '31')
UPDATE [corsostudionorma] SET idistitutokind = '10',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Scuole di specializzazione D.I.68/2015' WHERE idcorsostudionorma = '31'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('31','10',{ts '2018-06-11 11:35:00.653'},'ferdinando','Scuole di specializzazione D.I.68/2015')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '32')
UPDATE [corsostudionorma] SET idistitutokind = '10',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Scuole di specializzazione D.M.1/8/2005' WHERE idcorsostudionorma = '32'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('32','10',{ts '2018-06-11 11:35:00.653'},'ferdinando','Scuole di specializzazione D.M.1/8/2005')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '33')
UPDATE [corsostudionorma] SET idistitutokind = '9',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Lauree D.M.509/1999' WHERE idcorsostudionorma = '33'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('33','9',{ts '2018-06-11 11:35:00.653'},'ferdinando','Lauree D.M.509/1999')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '34')
UPDATE [corsostudionorma] SET idistitutokind = '9',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Lauree D.M.270/2008' WHERE idcorsostudionorma = '34'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('34','9',{ts '2018-06-11 11:35:00.653'},'ferdinando','Lauree D.M.270/2008')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '35')
UPDATE [corsostudionorma] SET idistitutokind = '10',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Lauree D.M.509/1999' WHERE idcorsostudionorma = '35'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('35','10',{ts '2018-06-11 11:35:00.653'},'ferdinando','Lauree D.M.509/1999')
GO

IF exists(SELECT * FROM [corsostudionorma] WHERE idcorsostudionorma = '36')
UPDATE [corsostudionorma] SET idistitutokind = '10',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Lauree D.M.270/2008' WHERE idcorsostudionorma = '36'
ELSE
INSERT INTO [corsostudionorma] (idcorsostudionorma,idistitutokind,lt,lu,title) VALUES ('36','10',{ts '2018-06-11 11:35:00.653'},'ferdinando','Lauree D.M.270/2008')
GO

