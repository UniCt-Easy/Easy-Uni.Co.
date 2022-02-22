
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


-- CREAZIONE TABELLA orakind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[orakind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[orakind] (
idorakind int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ripetizioni char(1) NULL,
sortcode int NULL,
title varchar(50) NULL,
 CONSTRAINT xpkorakind PRIMARY KEY (idorakind
)
)
END
GO

-- VERIFICA STRUTTURA orakind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'orakind' and C.name = 'idorakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [orakind] ADD idorakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('orakind') and col.name = 'idorakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [orakind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'orakind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [orakind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [orakind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'orakind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [orakind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('orakind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [orakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [orakind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'orakind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [orakind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('orakind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [orakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [orakind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'orakind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [orakind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [orakind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'orakind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [orakind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('orakind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [orakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [orakind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'orakind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [orakind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('orakind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [orakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [orakind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'orakind' and C.name = 'ripetizioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [orakind] ADD ripetizioni char(1) NULL 
END
ELSE
	ALTER TABLE [orakind] ALTER COLUMN ripetizioni char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'orakind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [orakind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [orakind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'orakind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [orakind] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [orakind] ALTER COLUMN title varchar(50) NULL
GO

-- VERIFICA DI orakind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'orakind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakind','int','ASSISTENZA','idorakind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','orakind','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','orakind','varchar(256)','ASSISTENZA','description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','orakind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','orakind','char(1)','ASSISTENZA','ripetizioni','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','orakind','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','orakind','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI orakind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'orakind')
UPDATE customobject set isreal = 'S' where objectname = 'orakind'
ELSE
INSERT INTO customobject (objectname, isreal) values('orakind', 'S')
GO

-- GENERAZIONE DATI PER orakind --
IF exists(SELECT * FROM [orakind] WHERE idorakind = '1')
UPDATE [orakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-05-21 18:12:22.780'},lu = 'riccardotest{0001}',ripetizioni = 'S',sortcode = '1',title = 'lezione individuale' WHERE idorakind = '1'
ELSE
INSERT INTO [orakind] (idorakind,active,ct,cu,description,lt,lu,ripetizioni,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-05-21 18:12:22.780'},'riccardotest{0001}','S','1','lezione individuale')
GO

IF exists(SELECT * FROM [orakind] WHERE idorakind = '2')
UPDATE [orakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-05-21 18:12:28.470'},lu = 'riccardotest{0001}',ripetizioni = 'N',sortcode = '2',title = 'lezione collettiva' WHERE idorakind = '2'
ELSE
INSERT INTO [orakind] (idorakind,active,ct,cu,description,lt,lu,ripetizioni,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-05-21 18:12:28.470'},'riccardotest{0001}','N','2','lezione collettiva')
GO

IF exists(SELECT * FROM [orakind] WHERE idorakind = '3')
UPDATE [orakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-05-21 18:12:47.360'},lu = 'riccardotest{0001}',ripetizioni = 'N',sortcode = '3',title = 'esercitazione' WHERE idorakind = '3'
ELSE
INSERT INTO [orakind] (idorakind,active,ct,cu,description,lt,lu,ripetizioni,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-05-21 18:12:47.360'},'riccardotest{0001}','N','3','esercitazione')
GO

IF exists(SELECT * FROM [orakind] WHERE idorakind = '4')
UPDATE [orakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-05-21 18:13:40.197'},lu = 'riccardotest{0001}',ripetizioni = 'S',sortcode = '4',title = 'laboratorio' WHERE idorakind = '4'
ELSE
INSERT INTO [orakind] (idorakind,active,ct,cu,description,lt,lu,ripetizioni,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-05-21 18:13:40.197'},'riccardotest{0001}','S','4','laboratorio')
GO

IF exists(SELECT * FROM [orakind] WHERE idorakind = '5')
UPDATE [orakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-05-21 18:15:51.860'},lu = 'riccardotest{0001}',ripetizioni = 'N',sortcode = '5',title = 'tirocini' WHERE idorakind = '5'
ELSE
INSERT INTO [orakind] (idorakind,active,ct,cu,description,lt,lu,ripetizioni,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-05-21 18:15:51.860'},'riccardotest{0001}','N','5','tirocini')
GO

IF exists(SELECT * FROM [orakind] WHERE idorakind = '6')
UPDATE [orakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-05-21 18:15:57.503'},lu = 'riccardotest{0001}',ripetizioni = 'N',sortcode = '6',title = 'seminari' WHERE idorakind = '6'
ELSE
INSERT INTO [orakind] (idorakind,active,ct,cu,description,lt,lu,ripetizioni,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-05-21 18:15:57.503'},'riccardotest{0001}','N','6','seminari')
GO

IF exists(SELECT * FROM [orakind] WHERE idorakind = '7')
UPDATE [orakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-05-21 18:16:03.753'},lu = 'riccardotest{0001}',ripetizioni = 'N',sortcode = '7',title = 'studio' WHERE idorakind = '7'
ELSE
INSERT INTO [orakind] (idorakind,active,ct,cu,description,lt,lu,ripetizioni,sortcode,title) VALUES ('7','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-05-21 18:16:03.753'},'riccardotest{0001}','N','7','studio')
GO

IF exists(SELECT * FROM [orakind] WHERE idorakind = '8')
UPDATE [orakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-05-21 18:16:07.603'},lu = 'riccardotest{0001}',ripetizioni = 'N',sortcode = '8',title = 'altro' WHERE idorakind = '8'
ELSE
INSERT INTO [orakind] (idorakind,active,ct,cu,description,lt,lu,ripetizioni,sortcode,title) VALUES ('8','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-05-21 18:16:07.603'},'riccardotest{0001}','N','8','altro')
GO

IF exists(SELECT * FROM [orakind] WHERE idorakind = '9')
UPDATE [orakind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-05-21 18:12:52.897'},lu = 'riccardotest{0001}',ripetizioni = 'S',sortcode = '3',title = 'lezione a gruppi' WHERE idorakind = '9'
ELSE
INSERT INTO [orakind] (idorakind,active,ct,cu,description,lt,lu,ripetizioni,sortcode,title) VALUES ('9','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-05-21 18:12:52.897'},'riccardotest{0001}','S','3','lezione a gruppi')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'orakind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO modificabile da loro delle tipologie di ore: didattica frontale, laboratorio, ecc.',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 16:27:06.063'},lu = 'assistenza',title = 'Tipologie di ore: didattica frontale, laboratorio, ecc.' WHERE tablename = 'orakind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('orakind','VOCABOLARIO modificabile da loro delle tipologie di ore: didattica frontale, laboratorio, ecc.',null,'N',{ts '2018-07-20 16:27:06.063'},'assistenza','Tipologie di ore: didattica frontale, laboratorio, ecc.')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'orakind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:56:09.477'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'orakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','orakind','1',null,null,null,'S',{ts '2018-07-19 15:56:09.477'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'orakind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:56:09.477'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'orakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','orakind','8',null,null,null,'S',{ts '2018-07-19 15:56:09.477'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'orakind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:56:09.477'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'orakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','orakind','64',null,null,null,'S',{ts '2018-07-19 15:56:09.477'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'orakind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:56:09.477'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'orakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','orakind','256',null,null,null,'S',{ts '2018-07-19 15:56:09.477'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idorakind' AND tablename = 'orakind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:56:09.480'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idorakind' AND tablename = 'orakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idorakind','orakind','4',null,null,null,'S',{ts '2018-07-19 15:56:09.480'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'orakind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:56:09.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'orakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','orakind','8',null,null,null,'S',{ts '2018-07-19 15:56:09.480'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'orakind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:56:09.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'orakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','orakind','64',null,null,null,'S',{ts '2018-07-19 15:56:09.480'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ripetizioni' AND tablename = 'orakind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Consente ripetizioni',kind = 'S',lt = {ts '2020-05-20 13:00:36.133'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'ripetizioni' AND tablename = 'orakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ripetizioni','orakind','1',null,null,'Consente ripetizioni','S',{ts '2020-05-20 13:00:36.133'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'orakind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:56:09.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'orakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','orakind','4',null,null,null,'S',{ts '2018-07-19 15:56:09.480'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'orakind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:56:09.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'orakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','orakind','50',null,null,null,'S',{ts '2018-07-19 15:56:09.480'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3276')
UPDATE [relation] SET childtable = 'orakind',description = 'descrizione di ora che stiamo tipizzando',lt = {ts '2018-07-19 15:56:50.043'},lu = 'assistenza',parenttable = 'caratteristicaora',title = null WHERE idrelation = '3276'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3276','orakind','descrizione di ora che stiamo tipizzando',{ts '2018-07-19 15:56:50.043'},'assistenza','caratteristicaora',null)
GO

-- FINE GENERAZIONE SCRIPT --

