
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


-- CREAZIONE TABELLA sessionekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sessionekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sessionekind] (
idsessionekind int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpksessionekind PRIMARY KEY (idsessionekind
)
)
END
GO

-- VERIFICA STRUTTURA sessionekind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sessionekind' and C.name = 'idsessionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sessionekind] ADD idsessionekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sessionekind') and col.name = 'idsessionekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sessionekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sessionekind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sessionekind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sessionekind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sessionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sessionekind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sessionekind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sessionekind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sessionekind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sessionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sessionekind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sessionekind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sessionekind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sessionekind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sessionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sessionekind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sessionekind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sessionekind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [sessionekind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sessionekind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sessionekind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sessionekind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sessionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sessionekind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sessionekind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sessionekind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sessionekind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sessionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sessionekind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sessionekind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sessionekind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sessionekind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sessionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sessionekind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sessionekind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sessionekind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sessionekind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sessionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sessionekind] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI sessionekind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sessionekind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekind','int','ASSISTENZA','idsessionekind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sessionekind','varchar(256)','ASSISTENZA','description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sessionekind','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sessionekind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sessionekind')
UPDATE customobject set isreal = 'S' where objectname = 'sessionekind'
ELSE
INSERT INTO customobject (objectname, isreal) values('sessionekind', 'S')
GO

-- GENERAZIONE DATI PER sessionekind --
IF exists(SELECT * FROM [sessionekind] WHERE idsessionekind = '1')
UPDATE [sessionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'anticipata' WHERE idsessionekind = '1'
ELSE
INSERT INTO [sessionekind] (idsessionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','anticipata')
GO

IF exists(SELECT * FROM [sessionekind] WHERE idsessionekind = '2')
UPDATE [sessionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'invernale' WHERE idsessionekind = '2'
ELSE
INSERT INTO [sessionekind] (idsessionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','invernale')
GO

IF exists(SELECT * FROM [sessionekind] WHERE idsessionekind = '3')
UPDATE [sessionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'primaverile' WHERE idsessionekind = '3'
ELSE
INSERT INTO [sessionekind] (idsessionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','3','primaverile')
GO

IF exists(SELECT * FROM [sessionekind] WHERE idsessionekind = '4')
UPDATE [sessionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'estiva' WHERE idsessionekind = '4'
ELSE
INSERT INTO [sessionekind] (idsessionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','4','estiva')
GO

IF exists(SELECT * FROM [sessionekind] WHERE idsessionekind = '5')
UPDATE [sessionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'autunnale' WHERE idsessionekind = '5'
ELSE
INSERT INTO [sessionekind] (idsessionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','5','autunnale')
GO

IF exists(SELECT * FROM [sessionekind] WHERE idsessionekind = '6')
UPDATE [sessionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'straordinaria' WHERE idsessionekind = '6'
ELSE
INSERT INTO [sessionekind] (idsessionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','6','straordinaria')
GO

IF exists(SELECT * FROM [sessionekind] WHERE idsessionekind = '7')
UPDATE [sessionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',title = 'laureandi' WHERE idsessionekind = '7'
ELSE
INSERT INTO [sessionekind] (idsessionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','7','laureandi')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'sessionekind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO modificabile da loro delle tipologie delle 2.2.6 Sessione di esami',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-20 16:28:42.553'},lu = 'assistenza',title = 'Tipologie delle Sessione di esami' WHERE tablename = 'sessionekind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('sessionekind','VOCABOLARIO modificabile da loro delle tipologie delle 2.2.6 Sessione di esami','2','S',{ts '2018-07-20 16:28:42.553'},'assistenza','Tipologie delle Sessione di esami')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'sessionekind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:29:36.653'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'sessionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','sessionekind','1',null,null,null,'S',{ts '2018-07-18 17:29:36.653'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'sessionekind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:29:36.653'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'sessionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','sessionekind','8',null,null,null,'S',{ts '2018-07-18 17:29:36.653'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'sessionekind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:29:36.653'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'sessionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','sessionekind','64',null,null,null,'S',{ts '2018-07-18 17:29:36.653'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'sessionekind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:29:36.653'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'sessionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','sessionekind','256',null,null,null,'S',{ts '2018-07-18 17:29:36.653'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsessionekind' AND tablename = 'sessionekind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:29:36.653'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsessionekind' AND tablename = 'sessionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsessionekind','sessionekind','4',null,null,null,'S',{ts '2018-07-18 17:29:36.653'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'sessionekind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:29:36.653'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'sessionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','sessionekind','8',null,null,null,'S',{ts '2018-07-18 17:29:36.653'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'sessionekind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:29:36.653'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'sessionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','sessionekind','64',null,null,null,'S',{ts '2018-07-18 17:29:36.653'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'sessionekind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:29:36.653'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'sessionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','sessionekind','4',null,null,null,'S',{ts '2018-07-18 17:29:36.653'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'sessionekind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:29:36.653'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'sessionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','sessionekind','50',null,null,null,'S',{ts '2018-07-18 17:29:36.653'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3249')
UPDATE [relation] SET childtable = 'sessionekind',description = 'sessione di cui descrive il tipo',lt = {ts '2018-07-18 17:30:02.780'},lu = 'assistenza',parenttable = 'sessione',title = null WHERE idrelation = '3249'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3249','sessionekind','sessione di cui descrive il tipo',{ts '2018-07-18 17:30:02.780'},'assistenza','sessione',null)
GO

-- FINE GENERAZIONE SCRIPT --

