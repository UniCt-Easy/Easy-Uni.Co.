
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
-- CREAZIONE TABELLA aoo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[aoo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[aoo] (
idaoo int NOT NULL,
codiceaooipa varchar(50) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idreg int NULL,
idsede int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(1024) NOT NULL,
 CONSTRAINT xpkaoo PRIMARY KEY (idaoo
)
)
END
GO

-- VERIFICA STRUTTURA aoo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'aoo' and C.name = 'idaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [aoo] ADD idaoo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('aoo') and col.name = 'idaoo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [aoo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'aoo' and C.name = 'codiceaooipa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [aoo] ADD codiceaooipa varchar(50) NULL 
END
ELSE
	ALTER TABLE [aoo] ALTER COLUMN codiceaooipa varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'aoo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [aoo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('aoo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [aoo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [aoo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'aoo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [aoo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('aoo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [aoo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [aoo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'aoo' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [aoo] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [aoo] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'aoo' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [aoo] ADD idsede int NULL 
END
ELSE
	ALTER TABLE [aoo] ALTER COLUMN idsede int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'aoo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [aoo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('aoo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [aoo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [aoo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'aoo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [aoo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('aoo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [aoo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [aoo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'aoo' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [aoo] ADD title varchar(1024) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('aoo') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [aoo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [aoo] ALTER COLUMN title varchar(1024) NOT NULL
GO

-- VERIFICA DI aoo IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'aoo'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aoo','int','ASSISTENZA','idaoo','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','aoo','varchar(50)','ASSISTENZA','codiceaooipa','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aoo','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aoo','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','aoo','int','ASSISTENZA','idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','aoo','int','ASSISTENZA','idsede','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aoo','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aoo','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','aoo','varchar(1024)','ASSISTENZA','title','1024','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI aoo IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'aoo')
UPDATE customobject set isreal = 'S' where objectname = 'aoo'
ELSE
INSERT INTO customobject (objectname, isreal) values('aoo', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'aoo')
UPDATE [tabledescr] SET description = '2.4.38 Area organizzativa omogenea (AOO)',idapplication = null,isdbo = 'N',lt = {ts '2018-07-17 18:17:37.940'},lu = 'assistenza',title = 'Area organizzativa omogenea (AOO)' WHERE tablename = 'aoo'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('aoo','2.4.38 Area organizzativa omogenea (AOO)',null,'N',{ts '2018-07-17 18:17:37.940'},'assistenza','Area organizzativa omogenea (AOO)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceaooipa' AND tablename = 'aoo')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice IPA',kind = 'S',lt = {ts '2019-03-13 16:39:31.320'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceaooipa' AND tablename = 'aoo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceaooipa','aoo','50',null,null,'Codice IPA','S',{ts '2019-03-13 16:39:31.320'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'aoo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 18:17:39.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'aoo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','aoo','8',null,null,null,'S',{ts '2018-07-17 18:17:39.180'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'aoo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 18:17:39.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'aoo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','aoo','64',null,null,null,'S',{ts '2018-07-17 18:17:39.180'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaoo' AND tablename = 'aoo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 18:17:39.180'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaoo' AND tablename = 'aoo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaoo','aoo','4',null,null,null,'S',{ts '2018-07-17 18:17:39.180'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'aoo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto o ente o azienda',kind = 'S',lt = {ts '2020-01-03 16:18:45.320'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'aoo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','aoo','4',null,null,'Istituto o ente o azienda','S',{ts '2020-01-03 16:18:45.320'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsede' AND tablename = 'aoo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sede',kind = 'S',lt = {ts '2019-08-30 15:41:51.497'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsede' AND tablename = 'aoo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsede','aoo','4',null,null,'Sede','S',{ts '2019-08-30 15:41:51.497'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'aoo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 18:17:39.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'aoo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','aoo','8',null,null,null,'S',{ts '2018-07-17 18:17:39.180'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'aoo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 18:17:39.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'aoo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','aoo','64',null,null,null,'S',{ts '2018-07-17 18:17:39.180'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'aoo')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-03-13 16:39:31.323'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'aoo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','aoo','1024',null,null,'Denominazione','S',{ts '2019-03-13 16:39:31.323'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

