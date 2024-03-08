
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


--[DBO]--
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

-- VERIFICA DI affidamentokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'affidamentokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokind','int','ASSISTENZA','idaffidamentokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentokind','decimal(9,2)','ASSISTENZA','costoora','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentokind','char(1)','ASSISTENZA','costoorariodacontratto','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokind','varchar(256)','ASSISTENZA','description','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokind','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI affidamentokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'affidamentokind')
UPDATE customobject set isreal = 'S' where objectname = 'affidamentokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('affidamentokind', 'S')
GO

-- GENERAZIONE DATI PER affidamentokind --
IF exists(SELECT * FROM [affidamentokind] WHERE idaffidamentokind = '1')
UPDATE [affidamentokind] SET active = 'S',costoora = null,costoorariodacontratto = null,ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Docente dell’Istituto',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Affidamento di incarico' WHERE idaffidamentokind = '1'
ELSE
INSERT INTO [affidamentokind] (idaffidamentokind,active,costoora,costoorariodacontratto,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',null,null,{ts '2018-06-11 11:35:00.653'},'ferdinando','Docente dell’Istituto',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Affidamento di incarico')
GO

IF exists(SELECT * FROM [affidamentokind] WHERE idaffidamentokind = '2')
UPDATE [affidamentokind] SET active = 'S',costoora = null,costoorariodacontratto = null,ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Docente di altro istituto o ente',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Affidamento in convenzione' WHERE idaffidamentokind = '2'
ELSE
INSERT INTO [affidamentokind] (idaffidamentokind,active,costoora,costoorariodacontratto,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',null,null,{ts '2018-06-11 11:35:00.653'},'ferdinando','Docente di altro istituto o ente',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Affidamento in convenzione')
GO

IF exists(SELECT * FROM [affidamentokind] WHERE idaffidamentokind = '3')
UPDATE [affidamentokind] SET active = 'S',costoora = '52',costoorariodacontratto = null,ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Non si dispone di un docente e si apre una posizione',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Bando 40€ +30%' WHERE idaffidamentokind = '3'
ELSE
INSERT INTO [affidamentokind] (idaffidamentokind,active,costoora,costoorariodacontratto,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S','52',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','Non si dispone di un docente e si apre una posizione',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Bando 40€ +30%')
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

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'affidamentokind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO modificabile da loro delle tipologie di 2.4.18 Affidamento',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 11:21:30.037'},lu = 'assistenza',title = 'Ttipologie di affidamento' WHERE tablename = 'affidamentokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('affidamentokind','VOCABOLARIO modificabile da loro delle tipologie di 2.4.18 Affidamento',null,'N',{ts '2018-07-20 11:21:30.037'},'assistenza','Ttipologie di affidamento')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:28:54.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','affidamentokind','1',null,null,null,'S',{ts '2018-07-19 18:28:54.077'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costoora' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Costo orario',kind = 'S',lt = {ts '2020-05-20 12:58:43.987'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costoora' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costoora','affidamentokind','5','9','2','Costo orario','S',{ts '2020-05-20 12:58:43.987'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costoorariodacontratto' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Costo orario da ruolo',kind = 'S',lt = {ts '2020-10-19 13:25:29.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'costoorariodacontratto' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costoorariodacontratto','affidamentokind','1',null,null,'Costo orario da ruolo','S',{ts '2020-10-19 13:25:29.723'},'assistenza','N','varchar(1)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:28:54.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','affidamentokind','8',null,null,null,'S',{ts '2018-07-19 18:28:54.077'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:28:54.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','affidamentokind','64',null,null,null,'S',{ts '2018-07-19 18:28:54.077'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:28:54.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','affidamentokind','256',null,null,null,'S',{ts '2018-07-19 18:28:54.077'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaffidamentokind' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:28:54.077'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaffidamentokind' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaffidamentokind','affidamentokind','4',null,null,null,'S',{ts '2018-07-19 18:28:54.077'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:28:54.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','affidamentokind','8',null,null,null,'S',{ts '2018-07-19 18:28:54.077'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:28:54.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','affidamentokind','64',null,null,null,'S',{ts '2018-07-19 18:28:54.077'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:28:54.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','affidamentokind','4',null,null,null,'S',{ts '2018-07-19 18:28:54.077'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'affidamentokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:28:54.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','affidamentokind','50',null,null,null,'S',{ts '2018-07-19 18:28:54.077'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3298')
UPDATE [relation] SET childtable = 'affidamentokind',description = 'affidamento di cui indica la tipologia',lt = {ts '2018-07-19 18:29:11.507'},lu = 'assistenza',parenttable = 'affidamento',title = null WHERE idrelation = '3298'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3298','affidamentokind','affidamento di cui indica la tipologia',{ts '2018-07-19 18:29:11.507'},'assistenza','affidamento',null)
GO

-- FINE GENERAZIONE SCRIPT --

