
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
-- CREAZIONE TABELLA menuweb --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[menuweb]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[menuweb] (
idmenuweb int NOT NULL,
editType nvarchar(60) NULL,
idmenuwebparent int NULL,
label nvarchar(250) NOT NULL,
link nvarchar(250) NULL,
sort int NULL,
tableName nvarchar(60) NULL,
 CONSTRAINT xpkmenuweb PRIMARY KEY (idmenuweb
)
)
END
GO

-- VERIFICA STRUTTURA menuweb --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'idmenuweb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD idmenuweb int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('menuweb') and col.name = 'idmenuweb' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [menuweb] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'editType' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD editType nvarchar(60) NULL 
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN editType nvarchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'idmenuwebparent' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD idmenuwebparent int NULL 
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN idmenuwebparent int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'label' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD label nvarchar(250) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('menuweb') and col.name = 'label' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [menuweb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN label nvarchar(250) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'link' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD link nvarchar(250) NULL 
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN link nvarchar(250) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'sort' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD sort int NULL 
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN sort int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'tableName' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD tableName nvarchar(60) NULL 
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN tableName nvarchar(60) NULL
GO

-- VERIFICA DI menuweb IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'menuweb'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','menuweb','int','assistenza','idmenuweb','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuweb','nvarchar(60)','assistenza','editType','60','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuweb','int','assistenza','idmenuwebparent','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','menuweb','nvarchar(250)','assistenza','label','250','S','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuweb','nvarchar(250)','assistenza','link','250','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuweb','int','assistenza','sort','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','menuweb','nvarchar(60)','assistenza','tableName','60','N','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI menuweb IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'menuweb')
UPDATE customobject set isreal = 'S' where objectname = 'menuweb'
ELSE
INSERT INTO customobject (objectname, isreal) values('menuweb', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'menuweb')
UPDATE [tabledescr] SET description = null,idapplication = null,isdbo = 'N',lt = {ts '2018-11-29 10:09:04.080'},lu = 'assistenza',title = 'menuweb' WHERE tablename = 'menuweb'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('menuweb',null,null,'N',{ts '2018-11-29 10:09:04.080'},'assistenza','menuweb')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'editType' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-29 10:09:09.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(60)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'editType' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('editType','menuweb','60',null,null,null,'S',{ts '2018-11-29 10:09:09.357'},'assistenza','N','nvarchar(60)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmenuweb' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-29 10:09:09.357'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idmenuweb' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmenuweb','menuweb','4',null,null,null,'S',{ts '2018-11-29 10:09:09.357'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmenuwebparent' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-29 10:09:09.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idmenuwebparent' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmenuwebparent','menuweb','4',null,null,null,'S',{ts '2018-11-29 10:09:09.357'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'label' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '250',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-28 14:21:42.053'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(250)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'label' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('label','menuweb','250',null,null,null,'S',{ts '2018-12-28 14:21:42.053'},'assistenza','N','nvarchar(250)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'link' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '250',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-28 14:21:42.053'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(250)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'link' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('link','menuweb','250',null,null,null,'S',{ts '2018-12-28 14:21:42.053'},'assistenza','N','nvarchar(250)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sort' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-28 14:21:42.053'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sort' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sort','menuweb','4',null,null,null,'S',{ts '2018-12-28 14:21:42.053'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tableName' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-29 10:09:09.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(60)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'tableName' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tableName','menuweb','60',null,null,null,'S',{ts '2018-11-29 10:09:09.357'},'assistenza','N','nvarchar(60)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

