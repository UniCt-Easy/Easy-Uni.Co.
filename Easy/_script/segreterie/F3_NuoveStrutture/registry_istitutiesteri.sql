
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
-- CREAZIONE TABELLA registry_istitutiesteri --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_istitutiesteri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_istitutiesteri] (
idreg int NOT NULL,
city varchar(255) NOT NULL,
code varchar(50) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idnace nvarchar(50) NULL,
institutionalcode varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
name varchar(1024) NOT NULL,
referencenumber varchar(50) NULL,
 CONSTRAINT xpkregistry_istitutiesteri PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_istitutiesteri --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istitutiesteri') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istitutiesteri] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'city' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD city varchar(255) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istitutiesteri') and col.name = 'city' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istitutiesteri] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istitutiesteri] ALTER COLUMN city varchar(255) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'code' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD code varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_istitutiesteri] ALTER COLUMN code varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istitutiesteri') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istitutiesteri] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istitutiesteri] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istitutiesteri') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istitutiesteri] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istitutiesteri] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'idnace' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD idnace nvarchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_istitutiesteri] ALTER COLUMN idnace nvarchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'institutionalcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD institutionalcode varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_istitutiesteri] ALTER COLUMN institutionalcode varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istitutiesteri') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istitutiesteri] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istitutiesteri] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istitutiesteri') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istitutiesteri] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istitutiesteri] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'name' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD name varchar(1024) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istitutiesteri') and col.name = 'name' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istitutiesteri] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istitutiesteri] ALTER COLUMN name varchar(1024) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istitutiesteri' and C.name = 'referencenumber' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istitutiesteri] ADD referencenumber varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_istitutiesteri] ALTER COLUMN referencenumber varchar(50) NULL
GO

-- VERIFICA DI registry_istitutiesteri IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry_istitutiesteri'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istitutiesteri','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istitutiesteri','varchar(255)','ASSISTENZA','city','255','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istitutiesteri','varchar(50)','ASSISTENZA','code','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istitutiesteri','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istitutiesteri','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istitutiesteri','nvarchar(50)','ASSISTENZA','idnace','50','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istitutiesteri','varchar(50)','ASSISTENZA','institutionalcode','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istitutiesteri','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istitutiesteri','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_istitutiesteri','varchar(1024)','ASSISTENZA','name','1024','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_istitutiesteri','varchar(50)','ASSISTENZA','referencenumber','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registry_istitutiesteri IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry_istitutiesteri')
UPDATE customobject set isreal = 'S' where objectname = 'registry_istitutiesteri'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry_istitutiesteri', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_istitutiesteri')
UPDATE [tabledescr] SET description = '2.4.30 Istituti esteri',idapplication = null,isdbo = 'N',lt = {ts '2018-11-29 16:24:47.000'},lu = 'Ferdinando',title = 'Istituti esteri' WHERE tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_istitutiesteri','2.4.30 Istituti esteri',null,'N',{ts '2018-11-29 16:24:47.000'},'Ferdinando','Istituti esteri')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'city' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'city' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('city','registry_istitutiesteri','255',null,null,null,'S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','varchar(255)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'code' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'code' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('code','registry_istitutiesteri','50',null,null,null,'S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:44:37.123'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_istitutiesteri','8',null,null,null,'S',{ts '2018-07-17 10:44:37.123'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:44:37.123'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_istitutiesteri','64',null,null,null,'S',{ts '2018-07-17 10:44:37.123'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnace' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'NACE code',kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'idnace' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnace','registry_istitutiesteri','50',null,null,'NACE code','S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','nvarchar(50)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_istitutiesteri','4',null,null,null,'S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'institutionalcode' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Institutional code',kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'institutionalcode' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('institutionalcode','registry_istitutiesteri','50',null,null,'Institutional code','S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:44:37.123'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_istitutiesteri','8',null,null,null,'S',{ts '2018-07-17 10:44:37.123'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:44:37.123'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_istitutiesteri','64',null,null,null,'S',{ts '2018-07-17 10:44:37.123'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'name' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'name' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('name','registry_istitutiesteri','1024',null,null,null,'S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'referencenumber' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Reference number',kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'referencenumber' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('referencenumber','registry_istitutiesteri','50',null,null,'Reference number','S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3189')
UPDATE [relation] SET childtable = 'registry_istitutiesteri',description = 'Anagrafica di base degli istituti esteri',lt = {ts '2018-07-17 11:06:13.873'},lu = 'assistenza',parenttable = 'registry',title = null WHERE idrelation = '3189'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3189','registry_istitutiesteri','Anagrafica di base degli istituti esteri',{ts '2018-07-17 11:06:13.873'},'assistenza','registry',null)
GO

-- FINE GENERAZIONE SCRIPT --

