
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE TABELLA perfprogettouomembro --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettouomembro]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogettouomembro] (
idperfprogetto int NOT NULL,
idperfprogettouo int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(36) NOT NULL,
lt datetime NOT NULL,
lu varchar(36) NOT NULL,
 CONSTRAINT xpkperfprogettouomembro PRIMARY KEY (idperfprogetto,
idperfprogettouo,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA perfprogettouomembro --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettouomembro' and C.name = 'idperfprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettouomembro] ADD idperfprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettouomembro') and col.name = 'idperfprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettouomembro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettouomembro' and C.name = 'idperfprogettouo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettouomembro] ADD idperfprogettouo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettouomembro') and col.name = 'idperfprogettouo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettouomembro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettouomembro' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettouomembro] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettouomembro') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettouomembro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettouomembro' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettouomembro] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettouomembro') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettouomembro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettouomembro] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettouomembro' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettouomembro] ADD cu varchar(36) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettouomembro') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettouomembro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettouomembro] ALTER COLUMN cu varchar(36) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettouomembro' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettouomembro] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettouomembro') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettouomembro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettouomembro] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettouomembro' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettouomembro] ADD lu varchar(36) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettouomembro') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettouomembro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettouomembro] ALTER COLUMN lu varchar(36) NOT NULL
GO

-- VERIFICA DI perfprogettouomembro IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfprogettouomembro'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettouomembro','int','assistenza','idperfprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettouomembro','int','assistenza','idperfprogettouo','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettouomembro','int','assistenza','idreg','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettouomembro','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettouomembro','varchar(36)','assistenza','cu','36','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettouomembro','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettouomembro','varchar(36)','assistenza','lu','36','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI perfprogettouomembro IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfprogettouomembro')
UPDATE customobject set isreal = 'S' where objectname = 'perfprogettouomembro'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfprogettouomembro', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfprogettouomembro')
UPDATE [tabledescr] SET description = 'Membri',idapplication = null,isdbo = 'N',lt = {ts '2021-05-24 14:48:22.753'},lu = 'assistenza',title = 'Membri' WHERE tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfprogettouomembro','Membri',null,'N',{ts '2021-05-24 14:48:22.753'},'assistenza','Membri')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfprogettouomembro','8',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfprogettouomembro','36',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogetto' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogetto' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogetto','perfprogettouomembro','4',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogettouo' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogettouo' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogettouo','perfprogettouomembro','4',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Membro',kind = 'S',lt = {ts '2021-06-10 12:30:46.857'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','perfprogettouomembro','4',null,null,'Membro','S',{ts '2021-06-10 12:30:46.857'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfprogettouomembro','8',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfprogettouomembro','36',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','N','varchar(36)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

