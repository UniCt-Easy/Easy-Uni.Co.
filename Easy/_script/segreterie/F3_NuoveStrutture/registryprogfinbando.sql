
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
-- CREAZIONE TABELLA registryprogfinbando --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryprogfinbando]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registryprogfinbando] (
idregistryprogfinbando int NOT NULL,
idregistryprogfin int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description nvarchar(max) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
number nvarchar(2048) NULL,
scadenza date NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkregistryprogfinbando PRIMARY KEY (idregistryprogfinbando,
idregistryprogfin,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA registryprogfinbando --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'idregistryprogfinbando' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD idregistryprogfinbando int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryprogfinbando') and col.name = 'idregistryprogfinbando' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryprogfinbando] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'idregistryprogfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD idregistryprogfin int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryprogfinbando') and col.name = 'idregistryprogfin' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryprogfinbando] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryprogfinbando') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryprogfinbando] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryprogfinbando') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryprogfinbando] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryprogfinbando] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryprogfinbando') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryprogfinbando] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryprogfinbando] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registryprogfinbando] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryprogfinbando') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryprogfinbando] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryprogfinbando] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryprogfinbando') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryprogfinbando] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryprogfinbando] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'number' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD number nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [registryprogfinbando] ALTER COLUMN number nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'scadenza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD scadenza date NULL 
END
ELSE
	ALTER TABLE [registryprogfinbando] ALTER COLUMN scadenza date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryprogfinbando' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryprogfinbando] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [registryprogfinbando] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI registryprogfinbando IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryprogfinbando'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinbando','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinbando','int','ASSISTENZA','idregistryprogfin','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinbando','int','ASSISTENZA','idregistryprogfinbando','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinbando','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinbando','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryprogfinbando','nvarchar(max)','ASSISTENZA','description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinbando','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryprogfinbando','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryprogfinbando','nvarchar(2048)','ASSISTENZA','number','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryprogfinbando','date','ASSISTENZA','scadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryprogfinbando','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registryprogfinbando IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryprogfinbando')
UPDATE customobject set isreal = 'S' where objectname = 'registryprogfinbando'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryprogfinbando', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registryprogfinbando')
UPDATE [tabledescr] SET description = '2.7.15 Bandi dei programmi di finanziamento',idapplication = null,isdbo = 'N',lt = {ts '2020-06-12 16:01:49.013'},lu = 'assistenza',title = 'Bandi dei programmi di finanziamento' WHERE tablename = 'registryprogfinbando'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registryprogfinbando','2.7.15 Bandi dei programmi di finanziamento',null,'N',{ts '2020-06-12 16:01:49.013'},'assistenza','Bandi dei programmi di finanziamento')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 16:01:52.693'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registryprogfinbando','8',null,null,null,'S',{ts '2020-06-12 16:01:52.693'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 16:01:52.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registryprogfinbando','64',null,null,null,'S',{ts '2020-06-12 16:01:52.697'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-06-12 16:02:33.583'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','registryprogfinbando','0',null,null,'Descrizione','S',{ts '2020-06-12 16:02:33.583'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 16:01:52.697'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registryprogfinbando','4',null,null,null,'S',{ts '2020-06-12 16:01:52.697'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryprogfin' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 16:01:52.697'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryprogfin' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryprogfin','registryprogfinbando','4',null,null,null,'S',{ts '2020-06-12 16:01:52.697'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryprogfinbando' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 16:01:52.697'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryprogfinbando' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryprogfinbando','registryprogfinbando','4',null,null,null,'S',{ts '2020-06-12 16:01:52.697'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 16:01:52.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registryprogfinbando','8',null,null,null,'S',{ts '2020-06-12 16:01:52.697'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 16:01:52.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registryprogfinbando','64',null,null,null,'S',{ts '2020-06-12 16:01:52.697'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'number' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Numero',kind = 'S',lt = {ts '2020-06-12 16:02:33.583'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'number' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('number','registryprogfinbando','2048',null,null,'Numero','S',{ts '2020-06-12 16:02:33.583'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scadenza' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Scadenza',kind = 'S',lt = {ts '2020-06-12 16:02:33.583'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'scadenza' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scadenza','registryprogfinbando','3',null,null,'Scadenza','S',{ts '2020-06-12 16:02:33.583'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'registryprogfinbando')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-06-12 16:02:33.583'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','registryprogfinbando','2048',null,null,'Titolo','S',{ts '2020-06-12 16:02:33.583'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

