
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
-- CREAZIONE TABELLA registry_amministrativi --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_amministrativi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_amministrativi] (
idreg int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
cv nvarchar(max) NULL,
idcontrattokind int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkregistry_amministrativi PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_amministrativi --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_amministrativi') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_amministrativi] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'cv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD cv nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN cv nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN lu varchar(64) NULL
GO

-- VERIFICA DI registry_amministrativi IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry_amministrativi'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_amministrativi','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','nvarchar(max)','ASSISTENZA','cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','int','ASSISTENZA','idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registry_amministrativi IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry_amministrativi')
UPDATE customobject set isreal = 'S' where objectname = 'registry_amministrativi'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry_amministrativi', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_amministrativi')
UPDATE [tabledescr] SET description = '2.7.8 Personale amministrativo',idapplication = null,isdbo = 'N',lt = {ts '2020-05-25 13:44:18.543'},lu = 'assistenza',title = 'Personale amministrativo' WHERE tablename = 'registry_amministrativi'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_amministrativi','2.7.8 Personale amministrativo',null,'N',{ts '2020-05-25 13:44:18.543'},'assistenza','Personale amministrativo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_amministrativi','8',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_amministrativi','64',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cv' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Curriculum vitae',kind = 'S',lt = {ts '2020-05-25 13:44:54.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cv' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cv','registry_amministrativi','0',null,null,'Curriculum vitae','S',{ts '2020-05-25 13:44:54.460'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2020-05-25 13:44:54.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','registry_amministrativi','4',null,null,'Tipo','S',{ts '2020-05-25 13:44:54.460'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_amministrativi','4',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_amministrativi','8',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_amministrativi','64',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

