
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
-- CREAZIONE TABELLA convenzione --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[convenzione]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[convenzione] (
idconvenzione int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start date NULL,
stop date NULL,
title varchar(256) NULL,
url varchar(512) NULL,
 CONSTRAINT xpkconvenzione PRIMARY KEY (idconvenzione,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA convenzione --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convenzione' and C.name = 'idconvenzione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convenzione] ADD idconvenzione int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convenzione') and col.name = 'idconvenzione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convenzione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convenzione' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convenzione] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convenzione') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convenzione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convenzione' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convenzione] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convenzione') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convenzione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convenzione] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convenzione' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convenzione] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convenzione') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convenzione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convenzione] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convenzione' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convenzione] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convenzione') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convenzione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convenzione] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convenzione' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convenzione] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('convenzione') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [convenzione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [convenzione] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convenzione' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convenzione] ADD start date NULL 
END
ELSE
	ALTER TABLE [convenzione] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convenzione' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convenzione] ADD stop date NULL 
END
ELSE
	ALTER TABLE [convenzione] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convenzione' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convenzione] ADD title varchar(256) NULL 
END
ELSE
	ALTER TABLE [convenzione] ALTER COLUMN title varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'convenzione' and C.name = 'url' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [convenzione] ADD url varchar(512) NULL 
END
ELSE
	ALTER TABLE [convenzione] ALTER COLUMN url varchar(512) NULL
GO

-- VERIFICA DI convenzione IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'convenzione'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzione','int','ASSISTENZA','idconvenzione','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzione','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzione','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzione','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzione','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','convenzione','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','convenzione','date','ASSISTENZA','start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','convenzione','date','ASSISTENZA','stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','convenzione','varchar(256)','ASSISTENZA','title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','convenzione','varchar(512)','ASSISTENZA','url','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI convenzione IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'convenzione')
UPDATE customobject set isreal = 'S' where objectname = 'convenzione'
ELSE
INSERT INTO customobject (objectname, isreal) values('convenzione', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'convenzione')
UPDATE [tabledescr] SET description = '2.5.22 Convezione per Tirocini',idapplication = null,isdbo = 'N',lt = {ts '2018-07-18 17:53:23.310'},lu = 'assistenza',title = 'Convezione per Tirocini' WHERE tablename = 'convenzione'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('convenzione','2.5.22 Convezione per Tirocini',null,'N',{ts '2018-07-18 17:53:23.310'},'assistenza','Convezione per Tirocini')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'convenzione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:53:26.960'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'convenzione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','convenzione','8',null,null,null,'S',{ts '2018-07-18 17:53:26.960'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'convenzione')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:53:26.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'convenzione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','convenzione','64',null,null,null,'S',{ts '2018-07-18 17:53:26.963'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idconvenzione' AND tablename = 'convenzione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:53:26.963'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idconvenzione' AND tablename = 'convenzione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idconvenzione','convenzione','4',null,null,null,'S',{ts '2018-07-18 17:53:26.963'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'convenzione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto, ente o azienda',kind = 'S',lt = {ts '2020-10-15 16:55:27.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'convenzione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','convenzione','4',null,null,'Istituto, ente o azienda','S',{ts '2020-10-15 16:55:27.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'convenzione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:53:26.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'convenzione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','convenzione','8',null,null,null,'S',{ts '2018-07-18 17:53:26.963'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'convenzione')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:53:26.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'convenzione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','convenzione','64',null,null,null,'S',{ts '2018-07-18 17:53:26.963'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'convenzione')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio',kind = 'S',lt = {ts '2020-10-15 16:55:27.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'convenzione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','convenzione','3',null,null,'Data di inizio','S',{ts '2020-10-15 16:55:27.147'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'convenzione')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine',kind = 'S',lt = {ts '2020-10-15 16:55:27.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'convenzione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','convenzione','3',null,null,'Data di fine','S',{ts '2020-10-15 16:55:27.147'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'convenzione')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-10-15 16:55:27.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'convenzione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','convenzione','256',null,null,'Titolo','S',{ts '2020-10-15 16:55:27.147'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'url' AND tablename = 'convenzione')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'URL',kind = 'S',lt = {ts '2020-10-15 16:55:27.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'url' AND tablename = 'convenzione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('url','convenzione','512',null,null,'URL','S',{ts '2020-10-15 16:55:27.147'},'assistenza','N','varchar(512)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

