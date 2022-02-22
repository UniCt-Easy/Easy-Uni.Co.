
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


-- CREAZIONE TABELLA corsostudio --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[corsostudio] (
idcorsostudio int NOT NULL,
almalaureasurvey char(1) NULL,
annoistituz int NULL,
basevoto int NULL,
codice varchar(50) NULL,
codicemiur varchar(10) NULL,
codicemiurlungo varchar(50) NULL,
crediti int NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
durata int NULL,
idcorsostudiokind int NOT NULL,
idcorsostudiolivello int NULL,
idcorsostudionorma int NULL,
idduratakind int NULL,
idstruttura int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
obbform nvarchar(max) NULL,
sboccocc nvarchar(max) NULL,
title varchar(1024) NULL,
title_en varchar(1024) NULL,
 CONSTRAINT xpkcorsostudio PRIMARY KEY (idcorsostudio
)
)
END
GO

-- VERIFICA STRUTTURA corsostudio --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'almalaureasurvey' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD almalaureasurvey char(1) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN almalaureasurvey char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'annoistituz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD annoistituz int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN annoistituz int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'basevoto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD basevoto int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN basevoto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'codicemiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD codicemiur varchar(10) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN codicemiur varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'codicemiurlungo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD codicemiurlungo varchar(50) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN codicemiurlungo varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'crediti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD crediti int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN crediti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'durata' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD durata int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN durata int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idcorsostudiokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idcorsostudiokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'idcorsostudiokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN idcorsostudiokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idcorsostudiolivello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idcorsostudiolivello int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN idcorsostudiolivello int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idcorsostudionorma' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idcorsostudionorma int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN idcorsostudionorma int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idduratakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idduratakind int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN idduratakind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'obbform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD obbform nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN obbform nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'sboccocc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD sboccocc nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN sboccocc nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN title varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD title_en varchar(1024) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN title_en varchar(1024) NULL
GO

-- CREAZIONE TABELLA corsostudiokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[corsostudiokind] (
idcorsostudiokind int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkcorsostudiokind PRIMARY KEY (idcorsostudiokind
)
)
END
GO

-- VERIFICA STRUTTURA corsostudiokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiokind' and C.name = 'idcorsostudiokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiokind] ADD idcorsostudiokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiokind') and col.name = 'idcorsostudiokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiokind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [corsostudiokind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiokind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER corsostudiokind --
IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '1')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Corso di Studi' WHERE idcorsostudiokind = '1'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Corso di Studi')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '2')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Master' WHERE idcorsostudiokind = '2'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Master')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '3')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Corso di perfezionamento' WHERE idcorsostudiokind = '3'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Corso di perfezionamento')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '4')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Dottorato di ricerca' WHERE idcorsostudiokind = '4'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Dottorato di ricerca')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '5')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'Scuola di specializzazione' WHERE idcorsostudiokind = '5'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Scuola di specializzazione')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '6')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'Corsi di specializzazione' WHERE idcorsostudiokind = '6'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','6','Corsi di specializzazione')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '7')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',title = 'Percorsi Abilitanti Speciali - PAS' WHERE idcorsostudiokind = '7'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','7','Percorsi Abilitanti Speciali - PAS')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '8')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '8',title = 'Tirocinio Formativo Attivo - TFA' WHERE idcorsostudiokind = '8'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('8','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','8','Tirocinio Formativo Attivo - TFA')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '9')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '9',title = 'Corso di accesso ai FIT (24 CFU)' WHERE idcorsostudiokind = '9'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('9','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','9','Corso di accesso ai FIT (24 CFU)')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '10')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '10',title = 'Corso preaccademico' WHERE idcorsostudiokind = '10'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('10','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','10','Corso preaccademico')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '11')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '11',title = 'Corso accademico' WHERE idcorsostudiokind = '11'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('11','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','11','Corso accademico')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '12')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '12',title = 'Test ammissione' WHERE idcorsostudiokind = '12'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('12','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','12','Test ammissione')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '13')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '13',title = 'Esame di stato' WHERE idcorsostudiokind = '13'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('13','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','13','Esame di stato')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '14')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando
',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando
',sortcode = '14',title = 'Corso base' WHERE idcorsostudiokind = '14'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('14','S',{ts '2018-06-11 11:35:00.653'},'ferdinando
',null,{ts '2018-06-11 11:35:00.653'},'ferdinando
','14','Corso base')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '15')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando
',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando
',sortcode = '15',title = 'Corso propedeutico' WHERE idcorsostudiokind = '15'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('15','S',{ts '2018-06-11 11:35:00.653'},'ferdinando
',null,{ts '2018-06-11 11:35:00.653'},'ferdinando
','15','Corso propedeutico')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '16')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '16',title = 'Corso di Formazione Professionale' WHERE idcorsostudiokind = '16'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('16','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','16','Corso di Formazione Professionale')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '17')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '17',title = 'Titolo generico d''area medica/ospedaliera' WHERE idcorsostudiokind = '17'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('17','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','17','Titolo generico d''area medica/ospedaliera')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '18')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '18',title = 'Abilitazione Professionale' WHERE idcorsostudiokind = '18'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('18','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','18','Abilitazione Professionale')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '19')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '19',title = 'Diploma' WHERE idcorsostudiokind = '19'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('19','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','19','Diploma')
GO

IF exists(SELECT * FROM [corsostudiokind] WHERE idcorsostudiokind = '20')
UPDATE [corsostudiokind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '20',title = 'Scuola Diretta Ai Fini Speciali' WHERE idcorsostudiokind = '20'
ELSE
INSERT INTO [corsostudiokind] (idcorsostudiokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('20','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','20','Scuola Diretta Ai Fini Speciali')
GO

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

-- CREAZIONE VISTA corsostudiodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudiodefaultview]
GO

CREATE VIEW [dbo].[corsostudiodefaultview] AS 
SELECT CASE WHEN corsostudio.almalaureasurvey = 'S' THEN 'Si' WHEN corsostudio.almalaureasurvey = 'N' THEN 'No' END AS corsostudio_almalaureasurvey, corsostudio.annoistituz AS corsostudio_annoistituz, corsostudio.basevoto AS corsostudio_basevoto, corsostudio.codice AS corsostudio_codice, corsostudio.codicemiur AS corsostudio_codicemiur, corsostudio.codicemiurlungo AS corsostudio_codicemiurlungo, corsostudio.crediti AS corsostudio_crediti, corsostudio.ct AS corsostudio_ct, corsostudio.cu AS corsostudio_cu, corsostudio.durata AS corsostudio_durata, corsostudio.idcorsostudio,
 [dbo].corsostudiokind.title AS corsostudiokind_title, corsostudio.idcorsostudiokind AS corsostudio_idcorsostudiokind,
 [dbo].corsostudiolivello.title AS corsostudiolivello_title, corsostudio.idcorsostudiolivello,
 [dbo].corsostudionorma.title AS corsostudionorma_title, corsostudio.idcorsostudionorma,
 [dbo].duratakind.title AS duratakind_title, corsostudio.idduratakind AS corsostudio_idduratakind,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].strutturakind.idstrutturakind AS strutturakind_idstrutturakind, corsostudio.idstruttura, corsostudio.lt AS corsostudio_lt, corsostudio.lu AS corsostudio_lu, corsostudio.obbform AS corsostudio_obbform, corsostudio.sboccocc AS corsostudio_sboccocc, corsostudio.title, corsostudio.title_en AS corsostudio_title_en,
 isnull('Denominazione: ' + corsostudio.title + '; ','') + ' ' + isnull('Anno accademico di istituzione: ' + CAST( corsostudio.annoistituz AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].strutturakind.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + CAST( [dbo].strutturakind.idstrutturakind AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].corsostudio WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudiokind WITH (NOLOCK) ON corsostudio.idcorsostudiokind = [dbo].corsostudiokind.idcorsostudiokind
LEFT OUTER JOIN [dbo].corsostudiolivello WITH (NOLOCK) ON corsostudio.idcorsostudiolivello = [dbo].corsostudiolivello.idcorsostudiolivello
LEFT OUTER JOIN [dbo].corsostudionorma WITH (NOLOCK) ON corsostudio.idcorsostudionorma = [dbo].corsostudionorma.idcorsostudionorma
LEFT OUTER JOIN [dbo].duratakind WITH (NOLOCK) ON corsostudio.idduratakind = [dbo].duratakind.idduratakind
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON corsostudio.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  corsostudio.idcorsostudio IS NOT NULL  AND corsostudio.idcorsostudiokind  not in (12, 13, 2)
GO

-- CREAZIONE VISTA corsostudiokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudiokinddefaultview]
GO

CREATE VIEW [dbo].[corsostudiokinddefaultview] AS 
SELECT CASE WHEN corsostudiokind.active = 'S' THEN 'Si' WHEN corsostudiokind.active = 'N' THEN 'No' END AS corsostudiokind_active, corsostudiokind.ct AS corsostudiokind_ct, corsostudiokind.cu AS corsostudiokind_cu, corsostudiokind.description AS corsostudiokind_description, corsostudiokind.idcorsostudiokind, corsostudiokind.lt AS corsostudiokind_lt, corsostudiokind.lu AS corsostudiokind_lu, corsostudiokind.sortcode AS corsostudiokind_sortcode, corsostudiokind.title,
 isnull('Tipologia: ' + corsostudiokind.title + '; ','') as dropdown_title
FROM [dbo].corsostudiokind WITH (NOLOCK) 
WHERE  corsostudiokind.idcorsostudiokind IS NOT NULL 
GO


-- GENERAZIONE DATI PER corsostudiokinddefaultview --
-- CREAZIONE VISTA corsostudiolivellodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiolivellodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudiolivellodefaultview]
GO

CREATE VIEW [dbo].[corsostudiolivellodefaultview] AS 
SELECT 
 [dbo].corsostudiokind.title AS corsostudiokind_title, corsostudiolivello.idcorsostudiokind AS corsostudiolivello_idcorsostudiokind, corsostudiolivello.idcorsostudiolivello, corsostudiolivello.lt AS corsostudiolivello_lt, corsostudiolivello.lu AS corsostudiolivello_lu, corsostudiolivello.title,
 isnull('Livello: ' + corsostudiolivello.title + '; ','') as dropdown_title
FROM [dbo].corsostudiolivello WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudiokind WITH (NOLOCK) ON corsostudiolivello.idcorsostudiokind = [dbo].corsostudiokind.idcorsostudiokind
WHERE  corsostudiolivello.idcorsostudiolivello IS NOT NULL 
GO


-- GENERAZIONE DATI PER corsostudiolivellodefaultview --
-- CREAZIONE VISTA corsostudionormadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudionormadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudionormadefaultview]
GO

CREATE VIEW [dbo].[corsostudionormadefaultview] AS 
SELECT  corsostudionorma.idcorsostudionorma,
 [dbo].istitutokind.tipoistituto AS istitutokind_tipoistituto, corsostudionorma.idistitutokind AS corsostudionorma_idistitutokind, corsostudionorma.lt AS corsostudionorma_lt, corsostudionorma.lu AS corsostudionorma_lu, corsostudionorma.title,
 isnull('Denominazione: ' + corsostudionorma.title + '; ','') as dropdown_title
FROM [dbo].corsostudionorma WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].istitutokind WITH (NOLOCK) ON corsostudionorma.idistitutokind = [dbo].istitutokind.idistitutokind
WHERE  corsostudionorma.idcorsostudionorma IS NOT NULL 
GO


-- GENERAZIONE DATI PER corsostudionormadefaultview --

---metadati viste

IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[metadatamanagedtable]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN

	CREATE TABLE [dbo].[metadatamanagedtable](
		[tablename] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_metadatamanagedtable_1] PRIMARY KEY CLUSTERED 
	(
		[tablename] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[metadataprimarykey]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN

	CREATE TABLE [dbo].[metadataprimarykey](
		[tablename] [varchar](50) NOT NULL,
		[primarykey] [varchar](250) NOT NULL,
	 CONSTRAINT [PK_metadataprimarykey_1] PRIMARY KEY CLUSTERED 
	(
		[tablename] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[metadatasorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN

	CREATE TABLE [dbo].[metadatasorting](
		[tablename] [varchar](50) NOT NULL,
		[listtype] [varchar](50) NOT NULL,
		[sorting] [varchar](2048) NOT NULL,
	 CONSTRAINT [PK_metadatasorting_1] PRIMARY KEY CLUSTERED 
	(
		[tablename] ASC,
		[listtype] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[metadatastaticfilter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN

	CREATE TABLE [dbo].[metadatastaticfilter](
		[tablename] [varchar](50) NOT NULL,
		[listtype] [varchar](50) NOT NULL,
		[staticfilter] [varchar](max) NOT NULL,
	 CONSTRAINT [PK_metadatastaticfilter] PRIMARY KEY CLUSTERED 
	(
		[tablename] ASC,
		[listtype] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'saldefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('saldefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'saldefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('saldefaultview', '"idprogetto","idsal"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idsal"' WHERE [tablename] = 'sal'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'saldefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('saldefaultview', 'default', 'start asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'start asc ' WHERE [tablename] = 'saldefaultview' AND [listtype] = 'default'
GO

--voci di menù

exec menuweb_addentry @idmenuwebparent = 29, @idx = 439, @tableName = '', @editType = '', @label = 'Pagine a bottone';
exec menuweb_addentry @idmenuwebparent = 439, @idx = 438, @tableName = 'progettocosto', @editType = 'segprg', @label = 'Dettaglio dei costi';
exec menuweb_addentry @idmenuwebparent = 439, @idx = 440, @tableName = 'sal', @editType = 'default', @label = 'Stato avanzamento lavori';
