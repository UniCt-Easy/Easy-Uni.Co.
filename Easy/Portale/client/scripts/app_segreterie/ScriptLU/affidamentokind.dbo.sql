
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


-- CREAZIONE TABELLA affidamentokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[affidamentokind] (
idaffidamentokind int NOT NULL,
active char(1) NOT NULL,
costoora decimal(9,2) NULL,
costoorariodacontratto char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkaffidamentokind PRIMARY KEY (idaffidamentokind
)
)
END
GO

-- VERIFICA STRUTTURA affidamentokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'idaffidamentokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD idaffidamentokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokind') and col.name = 'idaffidamentokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'costoora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD costoora decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [affidamentokind] ALTER COLUMN costoora decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'costoorariodacontratto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD costoorariodacontratto char(1) NULL 
END
ELSE
	ALTER TABLE [affidamentokind] ALTER COLUMN costoorariodacontratto char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD description varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentokind] ALTER COLUMN description varchar(256) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentokind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER affidamentokind --
IF exists(SELECT * FROM [affidamentokind] WHERE idaffidamentokind = '1')
UPDATE [affidamentokind] SET active = 'S',costoora = null,costoorariodacontratto = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Docente dell’Istituto',lt = {ts '2020-10-20 18:58:37.550'},lu = 'riccardotest{ADMSEG1}',sortcode = '1',title = 'Affidamento di incarico' WHERE idaffidamentokind = '1'
ELSE
INSERT INTO [affidamentokind] (idaffidamentokind,active,costoora,costoorariodacontratto,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',null,'S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Docente dell’Istituto',{ts '2020-10-20 18:58:37.550'},'riccardotest{ADMSEG1}','1','Affidamento di incarico')
GO

IF exists(SELECT * FROM [affidamentokind] WHERE idaffidamentokind = '2')
UPDATE [affidamentokind] SET active = 'S',costoora = null,costoorariodacontratto = 'N',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Docente di altro istituto o ente',lt = {ts '2020-10-20 18:58:30.603'},lu = 'riccardotest{ADMSEG1}',sortcode = '2',title = 'Affidamento in convenzione' WHERE idaffidamentokind = '2'
ELSE
INSERT INTO [affidamentokind] (idaffidamentokind,active,costoora,costoorariodacontratto,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',null,'N',{ts '2018-06-11 11:35:00.653'},'ferdinando','Docente di altro istituto o ente',{ts '2020-10-20 18:58:30.603'},'riccardotest{ADMSEG1}','2','Affidamento in convenzione')
GO

IF exists(SELECT * FROM [affidamentokind] WHERE idaffidamentokind = '3')
UPDATE [affidamentokind] SET active = 'S',costoora = null,costoorariodacontratto = 'N',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Non si dispone di un docente e si apre una posizione',lt = {ts '2020-10-20 18:58:24.213'},lu = 'riccardotest{ADMSEG1}',sortcode = '3',title = 'Bando' WHERE idaffidamentokind = '3'
ELSE
INSERT INTO [affidamentokind] (idaffidamentokind,active,costoora,costoorariodacontratto,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',null,'N',{ts '2018-06-11 11:35:00.653'},'ferdinando','Non si dispone di un docente e si apre una posizione',{ts '2020-10-20 18:58:24.213'},'riccardotest{ADMSEG1}','3','Bando')
GO

IF exists(SELECT * FROM [affidamentokind] WHERE idaffidamentokind = '4')
UPDATE [affidamentokind] SET active = 'S',costoora = null,costoorariodacontratto = null,ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Un docente che aveva l’incarico ma va sostituito per un periodo',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Sostituzione' WHERE idaffidamentokind = '4'
ELSE
INSERT INTO [affidamentokind] (idaffidamentokind,active,costoora,costoorariodacontratto,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',null,null,{ts '2018-06-11 11:35:00.653'},'ferdinando','Un docente che aveva l’incarico ma va sostituito per un periodo',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Sostituzione')
GO

IF exists(SELECT * FROM [affidamentokind] WHERE idaffidamentokind = '5')
UPDATE [affidamentokind] SET active = 'S',costoora = null,costoorariodacontratto = null,ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Un docente che aveva l’incarico ma non può procedere alla verbalizzazione degli esami, usato spesso per appelli riferiti ad anni accademici precedenti quando il docente è andato in pensione',lt = {ts '2020-06-02 23:20:07.093'},lu = 'riccardotest{0001}',sortcode = '5',title = 'Verbalizzante sostitutivo' WHERE idaffidamentokind = '5'
ELSE
INSERT INTO [affidamentokind] (idaffidamentokind,active,costoora,costoorariodacontratto,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S',null,null,{ts '2018-06-11 11:35:00.653'},'ferdinando','Un docente che aveva l’incarico ma non può procedere alla verbalizzazione degli esami, usato spesso per appelli riferiti ad anni accademici precedenti quando il docente è andato in pensione',{ts '2020-06-02 23:20:07.093'},'riccardotest{0001}','5','Verbalizzante sostitutivo')
GO

IF exists(SELECT * FROM [affidamentokind] WHERE idaffidamentokind = '6')
UPDATE [affidamentokind] SET active = 'S',costoora = '67.6',costoorariodacontratto = null,ct = {ts '2020-01-21 18:21:02.973'},cu = 'ferdinando',description = 'Non si dispone di un docente e si apre una posizione',lt = {ts '2020-01-21 18:21:02.973'},lu = 'ferdinando',sortcode = '4',title = 'Bando lingue 52€ + 30%' WHERE idaffidamentokind = '6'
ELSE
INSERT INTO [affidamentokind] (idaffidamentokind,active,costoora,costoorariodacontratto,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S','67.6',null,{ts '2020-01-21 18:21:02.973'},'ferdinando','Non si dispone di un docente e si apre una posizione',{ts '2020-01-21 18:21:02.973'},'ferdinando','4','Bando lingue 52€ + 30%')
GO

IF exists(SELECT * FROM [affidamentokind] WHERE idaffidamentokind = '7')
UPDATE [affidamentokind] SET active = 'S',costoora = '33.8',costoorariodacontratto = null,ct = {ts '2020-01-21 18:21:02.973'},cu = 'ferdinando',description = 'Non si dispone di un docente e si apre una posizione',lt = {ts '2020-01-21 18:21:02.973'},lu = 'ferdinando',sortcode = '4',title = 'Bando esercitatori o tutor 26€ + 30%' WHERE idaffidamentokind = '7'
ELSE
INSERT INTO [affidamentokind] (idaffidamentokind,active,costoora,costoorariodacontratto,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S','33.8',null,{ts '2020-01-21 18:21:02.973'},'ferdinando','Non si dispone di un docente e si apre una posizione',{ts '2020-01-21 18:21:02.973'},'ferdinando','4','Bando esercitatori o tutor 26€ + 30%')
GO

