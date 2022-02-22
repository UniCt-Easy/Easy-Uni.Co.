
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


-- CREAZIONE TABELLA questionariokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[questionariokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[questionariokind] (
idquestionariokind int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(128) NOT NULL,
 CONSTRAINT xpkquestionariokind PRIMARY KEY (idquestionariokind
)
)
END
GO

-- VERIFICA STRUTTURA questionariokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariokind' and C.name = 'idquestionariokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariokind] ADD idquestionariokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariokind') and col.name = 'idquestionariokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariokind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [questionariokind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariokind] ADD title varchar(128) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariokind] ALTER COLUMN title varchar(128) NOT NULL
GO


-- GENERAZIONE DATI PER questionariokind --
IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '1')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Questionario di valutazione del tirocinio da parte dello studente' WHERE idquestionariokind = '1'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Questionario di valutazione del tirocinio da parte dello studente')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '2')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Questionario di valutazione del tirocinio da parte del referente' WHERE idquestionariokind = '2'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Questionario di valutazione del tirocinio da parte del referente')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '3')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Test di ingresso' WHERE idquestionariokind = '3'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Test di ingresso')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '4')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Esame' WHERE idquestionariokind = '4'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Esame')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '5')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'Domande iniziali per l’iscrizione al bando di mobilità internazionale' WHERE idquestionariokind = '5'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Domande iniziali per l’iscrizione al bando di mobilità internazionale')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '6')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'Domande finali per l’iscrizione al bando di mobilità internazionale' WHERE idquestionariokind = '6'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','6','Domande finali per l’iscrizione al bando di mobilità internazionale')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '7')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',title = 'Questionario studenti iscritti AFAM 2017' WHERE idquestionariokind = '7'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','7','Questionario studenti iscritti AFAM 2017')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '8')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '8',title = 'Questionario studenti diplomandi AFAM 2017' WHERE idquestionariokind = '8'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('8','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','8','Questionario studenti diplomandi AFAM 2017')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '9')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '9',title = 'Questionario diplomati AFAM 2017' WHERE idquestionariokind = '9'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('9','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','9','Questionario diplomati AFAM 2017')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '10')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '10',title = 'Questionario insegnamento studenti frequentanti 2013 (scheda 1)' WHERE idquestionariokind = '10'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('10','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','10','Questionario insegnamento studenti frequentanti 2013 (scheda 1)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '11')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '11',title = 'Questionario insegnamento studenti non frequentanti 2013 (scheda 3)' WHERE idquestionariokind = '11'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('11','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','11','Questionario insegnamento studenti non frequentanti 2013 (scheda 3)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '12')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '12',title = 'Questionario insegnamento docenti 2013 (scheda 7)' WHERE idquestionariokind = '12'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('12','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','12','Questionario insegnamento docenti 2013 (scheda 7)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '13')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '13',title = 'Questionario insegnamento a distanza studenti frequentanti 2013 (scheda 1 bis)' WHERE idquestionariokind = '13'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('13','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','13','Questionario insegnamento a distanza studenti frequentanti 2013 (scheda 1 bis)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '14')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '14',title = 'Questionario insegnamento a distanza  studenti non frequentanti 2013 (scheda 3 bis)' WHERE idquestionariokind = '14'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('14','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','14','Questionario insegnamento a distanza  studenti non frequentanti 2013 (scheda 3 bis)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '15')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '15',title = 'Questionario insegnamento a distanza  docenti 2013 (scheda 7 bis)' WHERE idquestionariokind = '15'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('15','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','15','Questionario insegnamento a distanza  docenti 2013 (scheda 7 bis)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '16')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '16',title = 'Questionario corso a.a. precedente studenti frequentanti 2013 (scheda 2)' WHERE idquestionariokind = '16'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('16','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','16','Questionario corso a.a. precedente studenti frequentanti 2013 (scheda 2)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '17')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '17',title = 'Questionario corso a.a. precedente studenti non frequentanti 2013 (scheda 4)' WHERE idquestionariokind = '17'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('17','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','17','Questionario corso a.a. precedente studenti non frequentanti 2013 (scheda 4)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '18')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '18',title = 'Questionario corso a.a. precedente a distanza studenti frequentanti 2013 (scheda 2 bis)' WHERE idquestionariokind = '18'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('18','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','18','Questionario corso a.a. precedente a distanza studenti frequentanti 2013 (scheda 2 bis)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '19')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '19',title = 'Questionario corso a.a. precedente a distanza  studenti non frequentanti 2013 (scheda 4 bis)' WHERE idquestionariokind = '19'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('19','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','19','Questionario corso a.a. precedente a distanza  studenti non frequentanti 2013 (scheda 4 bis)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '20')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '20',title = 'Questionario studenti laureandi 2013 (scheda 5)' WHERE idquestionariokind = '20'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('20','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','20','Questionario studenti laureandi 2013 (scheda 5)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '21')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '21',title = 'Questionario studenti laureati 2013 (scheda 6)' WHERE idquestionariokind = '21'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('21','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','21','Questionario studenti laureati 2013 (scheda 6)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '22')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '22',title = 'Questionario corso a distanza studenti laureandi 2013 (scheda 5 bis)' WHERE idquestionariokind = '22'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('22','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','22','Questionario corso a distanza studenti laureandi 2013 (scheda 5 bis)')
GO

IF exists(SELECT * FROM [questionariokind] WHERE idquestionariokind = '23')
UPDATE [questionariokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '23',title = 'Questionario corso a distanza  studenti laureati 2013 (scheda 6 bis)' WHERE idquestionariokind = '23'
ELSE
INSERT INTO [questionariokind] (idquestionariokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('23','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','23','Questionario corso a distanza  studenti laureati 2013 (scheda 6 bis)')
GO

