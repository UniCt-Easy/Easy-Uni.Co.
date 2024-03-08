
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
-- CREAZIONE TABELLA struttura --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[struttura]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[struttura] (
idstruttura int NOT NULL,
codice varchar(50) NULL,
codiceipa nchar(10) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
email varchar(200) NULL,
fax varchar(50) NULL,
idaoo int NULL,
idreg int NULL,
idsede int NOT NULL,
idstrutturakind int NOT NULL,
idupb varchar(36) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
telefono varchar(50) NULL,
title varchar(1024) NULL,
title_en varchar(1024) NULL,
 CONSTRAINT xpkstruttura PRIMARY KEY (idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA struttura --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'codiceipa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD codiceipa nchar(10) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN codiceipa nchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'email' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD email varchar(200) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN email varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'fax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD fax varchar(50) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN fax varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idaoo int NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idaoo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idsede int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'idsede' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idsede int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idstrutturakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idstrutturakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'idstrutturakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idstrutturakind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idupb varchar(36) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'idupb' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idupb varchar(36) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'telefono' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD telefono varchar(50) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN telefono varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN title varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD title_en varchar(1024) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN title_en varchar(1024) NULL
GO

-- VERIFICA DI struttura IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'struttura'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','struttura','int','ASSISTENZA','idstruttura','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','struttura','varchar(50)','ASSISTENZA','codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','struttura','nchar(10)','ASSISTENZA','codiceipa','10','N','nchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','struttura','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','struttura','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','struttura','varchar(200)','ASSISTENZA','email','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','struttura','varchar(50)','ASSISTENZA','fax','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','struttura','int','ASSISTENZA','idaoo','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','struttura','int','ASSISTENZA','idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','struttura','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','struttura','int','ASSISTENZA','idstrutturakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','struttura','varchar(36)','ASSISTENZA','idupb','36','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','struttura','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','struttura','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','struttura','varchar(50)','ASSISTENZA','telefono','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','struttura','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','struttura','varchar(1024)','ASSISTENZA','title_en','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI struttura IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'struttura')
UPDATE customobject set isreal = 'S' where objectname = 'struttura'
ELSE
INSERT INTO customobject (objectname, isreal) values('struttura', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'struttura')
UPDATE [tabledescr] SET description = '2.4.11 Struttura / Unit? organizzativa',idapplication = null,isdbo = 'N',lt = {ts '2019-09-09 18:10:59.477'},lu = 'assistenza',title = 'Struttura / Unit? organizzativa' WHERE tablename = 'struttura'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('struttura','2.4.11 Struttura / Unit? organizzativa',null,'N',{ts '2019-09-09 18:10:59.477'},'assistenza','Struttura / Unit? organizzativa')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-09 18:11:03.260'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice','struttura','50',null,null,null,'S',{ts '2019-09-09 18:11:03.260'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceipa' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Codice IPA',kind = 'S',lt = {ts '2019-09-09 18:12:28.350'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nchar(10)',sql_type = 'nchar',system_type = 'System.String' WHERE colname = 'codiceipa' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceipa','struttura','10',null,null,'Codice IPA','S',{ts '2019-09-09 18:12:28.350'},'assistenza','N','nchar(10)','nchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-09 18:11:03.260'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','struttura','8',null,null,null,'S',{ts '2019-09-09 18:11:03.260'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-09 18:11:03.263'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','struttura','64',null,null,null,'S',{ts '2019-09-09 18:11:03.263'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'email' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'E-Mail',kind = 'S',lt = {ts '2019-09-09 18:12:28.353'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'email' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('email','struttura','200',null,null,'E-Mail','S',{ts '2019-09-09 18:12:28.353'},'assistenza','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fax' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-09 18:11:03.263'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'fax' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fax','struttura','50',null,null,null,'S',{ts '2019-09-09 18:11:03.263'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaoo' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'AOO',kind = 'S',lt = {ts '2019-09-09 18:12:28.353'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaoo' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaoo','struttura','4',null,null,'AOO','S',{ts '2019-09-09 18:12:28.353'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto o ente o azienda',kind = 'S',lt = {ts '2020-01-03 16:17:42.820'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','struttura','4',null,null,'Istituto o ente o azienda','S',{ts '2020-01-03 16:17:42.820'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsede' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sede',kind = 'S',lt = {ts '2019-09-09 18:12:28.353'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsede' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsede','struttura','4',null,null,'Sede','S',{ts '2019-09-09 18:12:28.353'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-09 18:11:03.263'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','struttura','4',null,null,null,'S',{ts '2019-09-09 18:11:03.263'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstrutturakind' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-09-09 18:12:28.353'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstrutturakind' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstrutturakind','struttura','4',null,null,'Tipologia','S',{ts '2019-09-09 18:12:28.353'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'UPB',kind = 'S',lt = {ts '2019-09-09 18:12:28.353'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idupb' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','struttura','36',null,null,'UPB','S',{ts '2019-09-09 18:12:28.353'},'assistenza','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-09 18:11:03.263'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','struttura','8',null,null,null,'S',{ts '2019-09-09 18:11:03.263'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-09 18:11:03.263'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','struttura','64',null,null,null,'S',{ts '2019-09-09 18:11:03.263'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'telefono' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-09 18:11:03.263'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'telefono' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('telefono','struttura','50',null,null,null,'S',{ts '2019-09-09 18:11:03.263'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-09-09 18:12:28.353'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','struttura','1024',null,null,'Denominazione','S',{ts '2019-09-09 18:12:28.353'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title_en' AND tablename = 'struttura')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Denominazione (ENG)',kind = 'S',lt = {ts '2019-09-09 18:12:28.353'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title_en' AND tablename = 'struttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title_en','struttura','1024',null,null,'Denominazione (ENG)','S',{ts '2019-09-09 18:12:28.353'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

