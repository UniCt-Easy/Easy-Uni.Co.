
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
-- CREAZIONE TABELLA registry_istituti --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_istituti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_istituti] (
idreg int NOT NULL,
active char(1) NULL,
codicemiur varchar(50) NULL,
codiceustat varchar(50) NULL,
comune varchar(64) NULL,
ct datetime NULL,
cu varchar(64) NOT NULL,
idistitutokind int NOT NULL,
idistitutoustat int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nome nchar(128) NULL,
sortcode int NULL,
title varchar(256) NULL,
title_en varchar(256) NULL,
 CONSTRAINT xpkregistry_istituti PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_istituti --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istituti') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istituti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'codicemiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD codicemiur varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN codicemiur varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'codiceustat' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD codiceustat varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN codiceustat varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'comune' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD comune varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN comune varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istituti') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istituti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'idistitutokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD idistitutokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istituti') and col.name = 'idistitutokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istituti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN idistitutokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'idistitutoustat' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD idistitutoustat int NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN idistitutoustat int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istituti') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istituti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istituti') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istituti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'nome' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD nome nchar(128) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN nome nchar(128) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD title varchar(256) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN title varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD title_en varchar(256) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN title_en varchar(256) NULL
GO

-- VERIFICA DI registry_istituti IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry_istituti'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istituti','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istituti','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istituti','varchar(50)','ASSISTENZA','codicemiur','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istituti','varchar(50)','ASSISTENZA','codiceustat','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istituti','varchar(64)','ASSISTENZA','comune','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istituti','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istituti','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istituti','int','ASSISTENZA','idistitutokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istituti','int','ASSISTENZA','idistitutoustat','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istituti','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istituti','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istituti','nchar(128)','ASSISTENZA','nome','128','N','nchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istituti','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istituti','varchar(256)','ASSISTENZA','title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istituti','varchar(256)','ASSISTENZA','title_en','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registry_istituti IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry_istituti')
UPDATE customobject set isreal = 'S' where objectname = 'registry_istituti'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry_istituti', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_istituti')
UPDATE [tabledescr] SET description = null,idapplication = null,isdbo = 'N',lt = {ts '2018-11-29 16:24:47.000'},lu = 'Ferdinando',title = 'Istituti' WHERE tablename = 'registry_istituti'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_istituti',null,null,'N',{ts '2018-11-29 16:24:47.000'},'Ferdinando','Istituti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codicemiur' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice MIUR',kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codicemiur' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codicemiur','registry_istituti','50',null,null,'Codice MIUR','S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceustat' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice USTAT',kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceustat' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceustat','registry_istituti','50',null,null,'Codice USTAT','S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'comune' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'Comune',kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'comune' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('comune','registry_istituti','64',null,null,'Comune','S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_istituti','8',null,null,null,'S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_istituti','64',null,null,null,'S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistitutokind' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2018-12-05 17:22:18.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistitutokind' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistitutokind','registry_istituti','4',null,null,'Tipologia','S',{ts '2018-12-05 17:22:18.527'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistitutoustat' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice USTAT',kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistitutoustat' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistitutoustat','registry_istituti','4',null,null,'Codice USTAT','S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_istituti','4',null,null,'Codice','S',{ts '2018-12-05 17:21:56.627'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_istituti','8',null,null,null,'S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_istituti','64',null,null,null,'S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nome' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '128',col_precision = null,col_scale = null,description = 'Denominazione breve',kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nchar(128)',sql_type = 'nchar',system_type = 'System.String' WHERE colname = 'nome' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nome','registry_istituti','128',null,null,'Denominazione breve','S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','nchar(128)','nchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','registry_istituti','4',null,null,null,'S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title_en' AND tablename = 'registry_istituti')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Denominazione (ENG)',kind = 'S',lt = {ts '2018-12-05 17:21:56.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title_en' AND tablename = 'registry_istituti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title_en','registry_istituti','256',null,null,'Denominazione (ENG)','S',{ts '2018-12-05 17:21:56.627'},'assistenza','N','varchar(256)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3193')
UPDATE [relation] SET childtable = 'registry_istituti',description = 'Anagrafica di base degli istituti',lt = {ts '2018-07-17 11:07:00.377'},lu = 'assistenza',parenttable = 'registry',title = null WHERE idrelation = '3193'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3193','registry_istituti','Anagrafica di base degli istituti',{ts '2018-07-17 11:07:00.377'},'assistenza','registry',null)
GO

-- FINE GENERAZIONE SCRIPT --

