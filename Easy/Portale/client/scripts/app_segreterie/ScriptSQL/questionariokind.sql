
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

-- VERIFICA DI questionariokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'questionariokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokind','int','ASSISTENZA','idquestionariokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariokind','varchar(256)','ASSISTENZA','description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariokind','varchar(128)','ASSISTENZA','title','128','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI questionariokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'questionariokind')
UPDATE customobject set isreal = 'S' where objectname = 'questionariokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('questionariokind', 'S')
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

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'questionariokind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO delle tipologie dei questionari, modificabile da loro. parte di 2.4.33 Questionari',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 15:40:08.617'},lu = 'assistenza',title = 'Ttipologie dei questionari' WHERE tablename = 'questionariokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('questionariokind','VOCABOLARIO delle tipologie dei questionari, modificabile da loro. parte di 2.4.33 Questionari',null,'N',{ts '2018-07-20 15:40:08.617'},'assistenza','Ttipologie dei questionari')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'questionariokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Attivo',kind = 'S',lt = {ts '2019-12-20 13:22:13.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'questionariokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','questionariokind','1',null,null,'Attivo','S',{ts '2019-12-20 13:22:13.673'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'questionariokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:40:12.513'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'questionariokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','questionariokind','8',null,null,null,'S',{ts '2018-07-20 15:40:12.513'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'questionariokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:40:12.513'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'questionariokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','questionariokind','64',null,null,null,'S',{ts '2018-07-20 15:40:12.513'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'questionariokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2019-12-20 13:22:13.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'questionariokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','questionariokind','256',null,null,'Descrizione','S',{ts '2019-12-20 13:22:13.673'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idquestionariokind' AND tablename = 'questionariokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:40:12.513'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idquestionariokind' AND tablename = 'questionariokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idquestionariokind','questionariokind','4',null,null,null,'S',{ts '2018-07-20 15:40:12.513'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'questionariokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:40:12.513'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'questionariokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','questionariokind','8',null,null,null,'S',{ts '2018-07-20 15:40:12.513'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'questionariokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:40:12.513'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'questionariokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','questionariokind','64',null,null,null,'S',{ts '2018-07-20 15:40:12.513'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'questionariokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordinamento',kind = 'S',lt = {ts '2019-12-20 13:22:13.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'questionariokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','questionariokind','4',null,null,'Ordinamento','S',{ts '2019-12-20 13:22:13.673'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'questionariokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-12-20 13:22:13.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'questionariokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','questionariokind','50',null,null,'Tipologia','S',{ts '2019-12-20 13:22:13.673'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3337')
UPDATE [relation] SET childtable = 'questionariokind',description = 'questionario di cui descrive la tipologia',lt = {ts '2018-07-20 15:43:03.193'},lu = 'assistenza',parenttable = 'questionario',title = null WHERE idrelation = '3337'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3337','questionariokind','questionario di cui descrive la tipologia',{ts '2018-07-20 15:43:03.193'},'assistenza','questionario',null)
GO

-- FINE GENERAZIONE SCRIPT --

