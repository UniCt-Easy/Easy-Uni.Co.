
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
-- CREAZIONE TABELLA affidamentoattach --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentoattach]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[affidamentoattach] (
idattach int NOT NULL,
idaffidamento int NOT NULL,
idcanale int NOT NULL,
idattivform int NOT NULL,
iddidprogporzanno int NOT NULL,
iddidproganno int NOT NULL,
iddidprogori int NOT NULL,
iddidprogcurr int NOT NULL,
iddidprog int NOT NULL,
idcorsostudio int NOT NULL,
aa varchar(9) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idreg_docenti int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkaffidamentoattach PRIMARY KEY (idattach,
idaffidamento,
idcanale,
idattivform,
iddidprogporzanno,
iddidproganno,
iddidprogori,
iddidprogcurr,
iddidprog,
idcorsostudio,
aa
)
)
END
GO

-- VERIFICA STRUTTURA affidamentoattach --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'idattach' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD idattach int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'idattach' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'idaffidamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD idaffidamento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'idaffidamento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'idcanale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD idcanale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'idcanale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'idattivform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD idattivform int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'idattivform' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'iddidprogporzanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD iddidprogporzanno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'iddidprogporzanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'iddidproganno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD iddidproganno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'iddidproganno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'iddidprogori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD iddidprogori int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'iddidprogori' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'iddidprogcurr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD iddidprogcurr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'iddidprogcurr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentoattach] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentoattach] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD idreg_docenti int NULL 
END
ELSE
	ALTER TABLE [affidamentoattach] ALTER COLUMN idreg_docenti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentoattach] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentoattach' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentoattach] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentoattach') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentoattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamentoattach] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI affidamentoattach IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'affidamentoattach'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','int','ASSISTENZA','idaffidamento','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','int','ASSISTENZA','idattach','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','int','ASSISTENZA','idattivform','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','int','ASSISTENZA','idcanale','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentoattach','int','ASSISTENZA','idreg_docenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentoattach','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI affidamentoattach IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'affidamentoattach')
UPDATE customobject set isreal = 'S' where objectname = 'affidamentoattach'
ELSE
INSERT INTO customobject (objectname, isreal) values('affidamentoattach', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'affidamentoattach')
UPDATE [tabledescr] SET description = 'Allegati dell''affidamento',idapplication = null,isdbo = 'N',lt = {ts '2019-09-23 16:10:47.577'},lu = 'assistenza',title = 'Allegati dell''affidamento' WHERE tablename = 'affidamentoattach'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('affidamentoattach','Allegati dell''affidamento',null,'N',{ts '2019-09-23 16:10:47.577'},'assistenza','Allegati dell''affidamento')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','affidamentoattach','9',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','S','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','affidamentoattach','8',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','affidamentoattach','64',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaffidamento' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaffidamento' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaffidamento','affidamentoattach','4',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattach' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Allegato',kind = 'S',lt = {ts '2019-09-23 16:11:14.180'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattach' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattach','affidamentoattach','4',null,null,'Allegato','S',{ts '2019-09-23 16:11:14.180'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattivform' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattivform' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattivform','affidamentoattach','4',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcanale' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcanale' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcanale','affidamentoattach','4',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','affidamentoattach','4',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','affidamentoattach','4',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidproganno' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidproganno' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidproganno','affidamentoattach','4',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogcurr' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogcurr' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogcurr','affidamentoattach','4',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogori' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogori' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogori','affidamentoattach','4',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogporzanno' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogporzanno' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogporzanno','affidamentoattach','4',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente',kind = 'S',lt = {ts '2020-06-09 10:22:51.970'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','affidamentoattach','4',null,null,'Docente','S',{ts '2020-06-09 10:22:51.970'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','affidamentoattach','8',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'affidamentoattach')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:49.710'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'affidamentoattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','affidamentoattach','64',null,null,null,'S',{ts '2019-09-23 16:10:49.710'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

