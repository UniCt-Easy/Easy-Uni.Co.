
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


--[DBO]--
-- CREAZIONE TABELLA bandomobilitaintkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandomobilitaintkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[bandomobilitaintkind] (
idbandomobilitaintkind int NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
sortcode int NULL,
title nvarchar(200) NULL,
 CONSTRAINT xpkbandomobilitaintkind PRIMARY KEY (idbandomobilitaintkind
)
)
END
GO

-- VERIFICA STRUTTURA bandomobilitaintkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomobilitaintkind' and C.name = 'idbandomobilitaintkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomobilitaintkind] ADD idbandomobilitaintkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomobilitaintkind') and col.name = 'idbandomobilitaintkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomobilitaintkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomobilitaintkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomobilitaintkind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [bandomobilitaintkind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomobilitaintkind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomobilitaintkind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [bandomobilitaintkind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomobilitaintkind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomobilitaintkind] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [bandomobilitaintkind] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomobilitaintkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomobilitaintkind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [bandomobilitaintkind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomobilitaintkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomobilitaintkind] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [bandomobilitaintkind] ALTER COLUMN lu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomobilitaintkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomobilitaintkind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [bandomobilitaintkind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomobilitaintkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomobilitaintkind] ADD title nvarchar(200) NULL 
END
ELSE
	ALTER TABLE [bandomobilitaintkind] ALTER COLUMN title nvarchar(200) NULL
GO

-- VERIFICA DI bandomobilitaintkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'bandomobilitaintkind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomobilitaintkind','int','ASSISTENZA','idbandomobilitaintkind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkind','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkind','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkind','varchar(60)','ASSISTENZA','cu','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkind','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkind','varchar(60)','ASSISTENZA','lu','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkind','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomobilitaintkind','nvarchar(200)','ASSISTENZA','title','200','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI bandomobilitaintkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'bandomobilitaintkind')
UPDATE customobject set isreal = 'S' where objectname = 'bandomobilitaintkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('bandomobilitaintkind', 'S')
GO

-- GENERAZIONE DATI PER bandomobilitaintkind --
IF exists(SELECT * FROM [bandomobilitaintkind] WHERE idbandomobilitaintkind = '1')
UPDATE [bandomobilitaintkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Outgoing Learning' WHERE idbandomobilitaintkind = '1'
ELSE
INSERT INTO [bandomobilitaintkind] (idbandomobilitaintkind,active,ct,cu,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Outgoing Learning')
GO

IF exists(SELECT * FROM [bandomobilitaintkind] WHERE idbandomobilitaintkind = '2')
UPDATE [bandomobilitaintkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Outgoing Traineership' WHERE idbandomobilitaintkind = '2'
ELSE
INSERT INTO [bandomobilitaintkind] (idbandomobilitaintkind,active,ct,cu,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Outgoing Traineership')
GO

IF exists(SELECT * FROM [bandomobilitaintkind] WHERE idbandomobilitaintkind = '3')
UPDATE [bandomobilitaintkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Outgoing Visiting Professor' WHERE idbandomobilitaintkind = '3'
ELSE
INSERT INTO [bandomobilitaintkind] (idbandomobilitaintkind,active,ct,cu,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Outgoing Visiting Professor')
GO

IF exists(SELECT * FROM [bandomobilitaintkind] WHERE idbandomobilitaintkind = '4')
UPDATE [bandomobilitaintkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Incoming Learning' WHERE idbandomobilitaintkind = '4'
ELSE
INSERT INTO [bandomobilitaintkind] (idbandomobilitaintkind,active,ct,cu,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Incoming Learning')
GO

IF exists(SELECT * FROM [bandomobilitaintkind] WHERE idbandomobilitaintkind = '5')
UPDATE [bandomobilitaintkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'Incoming Visiting Professor' WHERE idbandomobilitaintkind = '5'
ELSE
INSERT INTO [bandomobilitaintkind] (idbandomobilitaintkind,active,ct,cu,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Incoming Visiting Professor')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'bandomobilitaintkind')
UPDATE [tabledescr] SET description = 'Tipologa del bando di mobilità internanzionale',idapplication = null,isdbo = 'N',lt = {ts '2020-09-07 17:49:52.907'},lu = 'assistenza',title = 'Tipologa del bando di mobilità internanzionale' WHERE tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('bandomobilitaintkind','Tipologa del bando di mobilità internanzionale',null,'N',{ts '2020-09-07 17:49:52.907'},'assistenza','Tipologa del bando di mobilità internanzionale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'bandomobilitaintkind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-07 17:49:55.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','bandomobilitaintkind','1',null,null,null,'S',{ts '2020-09-07 17:49:55.853'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'bandomobilitaintkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-07 17:49:55.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','bandomobilitaintkind','8',null,null,null,'S',{ts '2020-09-07 17:49:55.853'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'bandomobilitaintkind')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-07 17:49:55.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','bandomobilitaintkind','60',null,null,null,'S',{ts '2020-09-07 17:49:55.853'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandomobilitaintkind' AND tablename = 'bandomobilitaintkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-07 17:49:55.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandomobilitaintkind' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandomobilitaintkind','bandomobilitaintkind','4',null,null,null,'S',{ts '2020-09-07 17:49:55.853'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'bandomobilitaintkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-07 17:49:55.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','bandomobilitaintkind','8',null,null,null,'S',{ts '2020-09-07 17:49:55.853'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'bandomobilitaintkind')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-07 17:49:55.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','bandomobilitaintkind','60',null,null,null,'S',{ts '2020-09-07 17:49:55.853'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'bandomobilitaintkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-07 17:49:55.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','bandomobilitaintkind','4',null,null,null,'S',{ts '2020-09-07 17:49:55.853'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'bandomobilitaintkind')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-07 17:49:55.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(200)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','bandomobilitaintkind','200',null,null,null,'S',{ts '2020-09-07 17:49:55.853'},'assistenza','N','nvarchar(200)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

