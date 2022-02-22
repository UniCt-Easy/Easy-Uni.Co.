
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

-- VERIFICA DI corsostudiokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'corsostudiokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokind','int','ASSISTENZA','idcorsostudiokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudiokind','varchar(256)','ASSISTENZA','description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiokind','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI corsostudiokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'corsostudiokind')
UPDATE customobject set isreal = 'S' where objectname = 'corsostudiokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('corsostudiokind', 'S')
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

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'corsostudiokind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO modificabile da loro delle tipologie dei  2.4.2 Corso di studio ',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 11:24:39.123'},lu = 'assistenza',title = 'Tipologie dei corsi di studio' WHERE tablename = 'corsostudiokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('corsostudiokind','VOCABOLARIO modificabile da loro delle tipologie dei  2.4.2 Corso di studio ',null,'N',{ts '2018-07-20 11:24:39.123'},'assistenza','Tipologie dei corsi di studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','corsostudiokind','1',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','corsostudiokind','8',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','corsostudiokind','64',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','corsostudiokind','256',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiokind','corsostudiokind','4',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','corsostudiokind','8',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','corsostudiokind','64',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','corsostudiokind','4',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','corsostudiokind','50',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3236')
UPDATE [relation] SET childtable = 'corsostudiokind',description = 'corso di studio di cui descrive il tipo',lt = {ts '2018-07-18 16:21:21.127'},lu = 'assistenza',parenttable = 'corsostudio',title = null WHERE idrelation = '3236'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3236','corsostudiokind','corso di studio di cui descrive il tipo',{ts '2018-07-18 16:21:21.127'},'assistenza','corsostudio',null)
GO

-- FINE GENERAZIONE SCRIPT --

