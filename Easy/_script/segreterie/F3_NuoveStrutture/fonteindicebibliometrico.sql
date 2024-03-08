
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
-- CREAZIONE TABELLA fonteindicebibliometrico --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[fonteindicebibliometrico]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[fonteindicebibliometrico] (
idfonteindicebibliometrico int NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description nvarchar(max) NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NULL,
title nvarchar(1024) NULL,
 CONSTRAINT xpkfonteindicebibliometrico PRIMARY KEY (idfonteindicebibliometrico
)
)
END
GO

-- VERIFICA STRUTTURA fonteindicebibliometrico --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'idfonteindicebibliometrico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD idfonteindicebibliometrico int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('fonteindicebibliometrico') and col.name = 'idfonteindicebibliometrico' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [fonteindicebibliometrico] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD title nvarchar(1024) NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN title nvarchar(1024) NULL
GO

-- VERIFICA DI fonteindicebibliometrico IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'fonteindicebibliometrico'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','fonteindicebibliometrico','int','ASSISTENZA','idfonteindicebibliometrico','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometrico','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometrico','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometrico','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometrico','nvarchar(max)','ASSISTENZA','description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometrico','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometrico','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometrico','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','fonteindicebibliometrico','nvarchar(1024)','ASSISTENZA','title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI fonteindicebibliometrico IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'fonteindicebibliometrico')
UPDATE customobject set isreal = 'S' where objectname = 'fonteindicebibliometrico'
ELSE
INSERT INTO customobject (objectname, isreal) values('fonteindicebibliometrico', 'S')
GO

-- GENERAZIONE DATI PER fonteindicebibliometrico --
IF exists(SELECT * FROM [fonteindicebibliometrico] WHERE idfonteindicebibliometrico = '1')
UPDATE [fonteindicebibliometrico] SET active = 'S',ct = {d '2003-11-20'},cu = 'ferdinando',description = null,lt = {d '2003-11-20'},lu = 'ferdinando',sortcode = '1',title = 'WoS' WHERE idfonteindicebibliometrico = '1'
ELSE
INSERT INTO [fonteindicebibliometrico] (idfonteindicebibliometrico,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{d '2003-11-20'},'ferdinando',null,{d '2003-11-20'},'ferdinando','1','WoS')
GO

IF exists(SELECT * FROM [fonteindicebibliometrico] WHERE idfonteindicebibliometrico = '2')
UPDATE [fonteindicebibliometrico] SET active = 'S',ct = {d '2003-11-20'},cu = 'ferdinando',description = null,lt = {d '2003-11-20'},lu = 'ferdinando',sortcode = '2',title = 'Scopus' WHERE idfonteindicebibliometrico = '2'
ELSE
INSERT INTO [fonteindicebibliometrico] (idfonteindicebibliometrico,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{d '2003-11-20'},'ferdinando',null,{d '2003-11-20'},'ferdinando','2','Scopus')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'fonteindicebibliometrico')
UPDATE [tabledescr] SET description = 'Fonti indice bibliometrico',idapplication = null,isdbo = 'N',lt = {ts '2020-05-25 13:42:20.837'},lu = 'assistenza',title = 'Fonti indice bibliometrico' WHERE tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('fonteindicebibliometrico','Fonti indice bibliometrico',null,'N',{ts '2020-05-25 13:42:20.837'},'assistenza','Fonti indice bibliometrico')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'fonteindicebibliometrico')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:42:23.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','fonteindicebibliometrico','1',null,null,null,'S',{ts '2020-05-25 13:42:23.657'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'fonteindicebibliometrico')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:42:23.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','fonteindicebibliometrico','8',null,null,null,'S',{ts '2020-05-25 13:42:23.657'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'fonteindicebibliometrico')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:42:23.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','fonteindicebibliometrico','64',null,null,null,'S',{ts '2020-05-25 13:42:23.657'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'fonteindicebibliometrico')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:42:23.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','fonteindicebibliometrico','0',null,null,null,'S',{ts '2020-05-25 13:42:23.657'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'fonteindicebibliometrico')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:42:23.657'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idfonteindicebibliometrico','fonteindicebibliometrico','4',null,null,null,'S',{ts '2020-05-25 13:42:23.657'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'fonteindicebibliometrico')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:42:23.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','fonteindicebibliometrico','8',null,null,null,'S',{ts '2020-05-25 13:42:23.657'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'fonteindicebibliometrico')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:42:23.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','fonteindicebibliometrico','64',null,null,null,'S',{ts '2020-05-25 13:42:23.657'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'fonteindicebibliometrico')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:42:23.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','fonteindicebibliometrico','4',null,null,null,'S',{ts '2020-05-25 13:42:23.657'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'fonteindicebibliometrico')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:42:23.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(1024)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','fonteindicebibliometrico','1024',null,null,null,'S',{ts '2020-05-25 13:42:23.657'},'assistenza','N','nvarchar(1024)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

