
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


-- CREAZIONE TABELLA perfschedastatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfschedastatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfschedastatus] (
idperfschedastatus int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkperfschedastatus PRIMARY KEY (idperfschedastatus
)
)
END
GO

-- VERIFICA STRUTTURA perfschedastatus --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedastatus' and C.name = 'idperfschedastatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedastatus] ADD idperfschedastatus int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfschedastatus') and col.name = 'idperfschedastatus' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfschedastatus] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedastatus' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedastatus] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [perfschedastatus] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedastatus' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedastatus] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfschedastatus') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfschedastatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfschedastatus] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedastatus' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedastatus] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfschedastatus') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfschedastatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfschedastatus] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedastatus' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedastatus] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfschedastatus] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedastatus' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedastatus] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfschedastatus') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfschedastatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfschedastatus] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedastatus' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedastatus] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfschedastatus') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfschedastatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfschedastatus] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedastatus' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedastatus] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [perfschedastatus] ALTER COLUMN title varchar(1024) NULL
GO

-- VERIFICA DI perfschedastatus IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfschedastatus'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatus','int','assistenza','idperfschedastatus','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedastatus','char(1)','assistenza','active','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatus','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatus','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedastatus','varchar(max)','assistenza','description','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatus','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatus','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedastatus','varchar(1024)','assistenza','title','1024','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI perfschedastatus IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfschedastatus')
UPDATE customobject set isreal = 'S' where objectname = 'perfschedastatus'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfschedastatus', 'S')
GO

-- GENERAZIONE DATI PER perfschedastatus --
IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '1')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-05-24 13:23:20.143'},cu = 'seg_psuma',description = 'Bozza',lt = {ts '2021-05-24 13:23:20.143'},lu = 'seg_psuma',title = 'Bozza' WHERE idperfschedastatus = '1'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('1','S',{ts '2021-05-24 13:23:20.143'},'seg_psuma','Bozza',{ts '2021-05-24 13:23:20.143'},'seg_psuma','Bozza')
GO

IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '2')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-05-24 13:23:20.223'},cu = 'seg_psuma',description = 'Da completare',lt = {ts '2021-05-24 13:23:20.223'},lu = 'seg_psuma',title = 'Da completare' WHERE idperfschedastatus = '2'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('2','S',{ts '2021-05-24 13:23:20.223'},'seg_psuma','Da completare',{ts '2021-05-24 13:23:20.223'},'seg_psuma','Da completare')
GO

IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '3')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-05-24 13:23:20.307'},cu = 'seg_psuma',description = 'Obiettivi Assegnati',lt = {ts '2021-06-07 14:15:32.557'},lu = 'seg_fcaprilli{SEGADM}',title = 'Obiettivi Assegnati' WHERE idperfschedastatus = '3'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('3','S',{ts '2021-05-24 13:23:20.307'},'seg_psuma','Obiettivi Assegnati',{ts '2021-06-07 14:15:32.557'},'seg_fcaprilli{SEGADM}','Obiettivi Assegnati')
GO

IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '4')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-05-24 13:23:20.307'},cu = 'seg_psuma',description = 'Obiettivi Accettati',lt = {ts '2021-05-24 13:23:20.307'},lu = 'seg_psuma',title = 'Obiettivi Accettati' WHERE idperfschedastatus = '4'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('4','S',{ts '2021-05-24 13:23:20.307'},'seg_psuma','Obiettivi Accettati',{ts '2021-05-24 13:23:20.307'},'seg_psuma','Obiettivi Accettati')
GO

IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '5')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-05-24 13:23:20.390'},cu = 'seg_psuma',description = 'Obiettivi Conclusi',lt = {ts '2021-05-24 13:23:20.390'},lu = 'seg_psuma',title = 'Obiettivi Conclusi' WHERE idperfschedastatus = '5'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('5','S',{ts '2021-05-24 13:23:20.390'},'seg_psuma','Obiettivi Conclusi',{ts '2021-05-24 13:23:20.390'},'seg_psuma','Obiettivi Conclusi')
GO

IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '6')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-05-24 13:23:20.390'},cu = 'seg_psuma',description = 'Risultati Validati',lt = {ts '2021-05-24 13:23:20.390'},lu = 'seg_psuma',title = 'Risultati Validati' WHERE idperfschedastatus = '6'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('6','S',{ts '2021-05-24 13:23:20.390'},'seg_psuma','Risultati Validati',{ts '2021-05-24 13:23:20.390'},'seg_psuma','Risultati Validati')
GO

IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '7')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-05-24 13:23:20.390'},cu = 'seg_psuma',description = 'Valutazione Accettata',lt = {ts '2021-05-24 13:23:20.390'},lu = 'seg_psuma',title = 'Valutazione Accettata' WHERE idperfschedastatus = '7'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('7','S',{ts '2021-05-24 13:23:20.390'},'seg_psuma','Valutazione Accettata',{ts '2021-05-24 13:23:20.390'},'seg_psuma','Valutazione Accettata')
GO

IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '8')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-05-24 13:23:20.393'},cu = 'seg_psuma',description = 'Valutazione Rifiutata',lt = {ts '2021-05-24 13:23:20.393'},lu = 'seg_psuma',title = 'Valutazione Rifiutata' WHERE idperfschedastatus = '8'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('8','S',{ts '2021-05-24 13:23:20.393'},'seg_psuma','Valutazione Rifiutata',{ts '2021-05-24 13:23:20.393'},'seg_psuma','Valutazione Rifiutata')
GO

IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '9')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-06-07 14:15:59.937'},cu = 'seg_fcaprilli{SEGADM}',description = 'Valutazione Approvata',lt = {ts '2021-07-30 14:33:54.870'},lu = 'ferdinando.giannetti{PERFADM}',title = 'Valutazione Approvata' WHERE idperfschedastatus = '9'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('9','S',{ts '2021-06-07 14:15:59.937'},'seg_fcaprilli{SEGADM}','Valutazione Approvata',{ts '2021-07-30 14:33:54.870'},'ferdinando.giannetti{PERFADM}','Valutazione Approvata')
GO

IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '10')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-06-07 14:16:21.747'},cu = 'seg_fcaprilli{SEGADM}',description = 'Monit. intermedio',lt = {ts '2021-07-30 14:34:09.447'},lu = 'ferdinando.giannetti{PERFADM}',title = 'Monit. intermedio' WHERE idperfschedastatus = '10'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('10','S',{ts '2021-06-07 14:16:21.747'},'seg_fcaprilli{SEGADM}','Monit. intermedio',{ts '2021-07-30 14:34:09.447'},'ferdinando.giannetti{PERFADM}','Monit. intermedio')
GO

IF exists(SELECT * FROM [perfschedastatus] WHERE idperfschedastatus = '11')
UPDATE [perfschedastatus] SET active = 'S',ct = {ts '2021-06-07 14:16:32.843'},cu = 'seg_fcaprilli{SEGADM}',description = 'Monit. bimestrale',lt = {ts '2021-07-30 14:34:15.830'},lu = 'ferdinando.giannetti{PERFADM}',title = 'Monit. bimestrale' WHERE idperfschedastatus = '11'
ELSE
INSERT INTO [perfschedastatus] (idperfschedastatus,active,ct,cu,description,lt,lu,title) VALUES ('11','S',{ts '2021-06-07 14:16:32.843'},'seg_fcaprilli{SEGADM}','Monit. bimestrale',{ts '2021-07-30 14:34:15.830'},'ferdinando.giannetti{PERFADM}','Monit. bimestrale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfschedastatus')
UPDATE [tabledescr] SET description = 'Stati delle schede',idapplication = null,isdbo = 'N',lt = {ts '2021-05-24 14:40:12.953'},lu = 'assistenza',title = 'Stati delle schede' WHERE tablename = 'perfschedastatus'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfschedastatus','Stati delle schede',null,'N',{ts '2021-05-24 14:40:12.953'},'assistenza','Stati delle schede')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'perfschedastatus')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Attivo',kind = 'S',lt = {ts '2021-05-24 14:40:45.840'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'perfschedastatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','perfschedastatus','1',null,null,'Attivo','S',{ts '2021-05-24 14:40:45.840'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfschedastatus')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:40:15.473'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfschedastatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfschedastatus','8',null,null,null,'S',{ts '2021-05-24 14:40:15.473'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfschedastatus')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:40:15.473'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfschedastatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfschedastatus','64',null,null,null,'S',{ts '2021-05-24 14:40:15.473'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'perfschedastatus')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-05-24 14:40:45.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'perfschedastatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','perfschedastatus','-1',null,null,'Descrizione','S',{ts '2021-05-24 14:40:45.843'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfschedastatus' AND tablename = 'perfschedastatus')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:40:15.473'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfschedastatus' AND tablename = 'perfschedastatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfschedastatus','perfschedastatus','4',null,null,null,'S',{ts '2021-05-24 14:40:15.473'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfschedastatus')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:40:15.473'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfschedastatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfschedastatus','8',null,null,null,'S',{ts '2021-05-24 14:40:15.473'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfschedastatus')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:40:15.473'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfschedastatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfschedastatus','64',null,null,null,'S',{ts '2021-05-24 14:40:15.473'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'perfschedastatus')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2021-05-24 14:44:56.543'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'perfschedastatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','perfschedastatus','1024',null,null,'Stato','S',{ts '2021-05-24 14:44:56.543'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

