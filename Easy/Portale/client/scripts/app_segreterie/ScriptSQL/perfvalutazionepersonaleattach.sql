
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


-- CREAZIONE TABELLA perfvalutazionepersonaleattach --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazionepersonaleattach]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazionepersonaleattach] (
idperfvalutazionepersonaleattach int NOT NULL,
idperfvalutazionepersonale int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idattach int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkperfvalutazionepersonaleattach PRIMARY KEY (idperfvalutazionepersonaleattach,
idperfvalutazionepersonale
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazionepersonaleattach --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleattach' and C.name = 'idperfvalutazionepersonaleattach' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleattach] ADD idperfvalutazionepersonaleattach int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleattach') and col.name = 'idperfvalutazionepersonaleattach' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleattach' and C.name = 'idperfvalutazionepersonale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleattach] ADD idperfvalutazionepersonale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleattach') and col.name = 'idperfvalutazionepersonale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleattach] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleattach' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleattach] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleattach') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleattach] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleattach' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleattach] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleattach') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleattach] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleattach' and C.name = 'idattach' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleattach] ADD idattach int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleattach] ALTER COLUMN idattach int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleattach' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleattach] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleattach') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleattach] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleattach' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleattach] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleattach') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleattach] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleattach] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI perfvalutazionepersonaleattach IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfvalutazionepersonaleattach'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazionepersonaleattach','int','assistenza','idperfvalutazionepersonale','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazionepersonaleattach','int','assistenza','idperfvalutazionepersonaleattach','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazionepersonaleattach','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazionepersonaleattach','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazionepersonaleattach','int','assistenza','idattach','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazionepersonaleattach','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazionepersonaleattach','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI perfvalutazionepersonaleattach IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfvalutazionepersonaleattach')
UPDATE customobject set isreal = 'S' where objectname = 'perfvalutazionepersonaleattach'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfvalutazionepersonaleattach', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfvalutazionepersonaleattach')
UPDATE [tabledescr] SET description = null,idapplication = null,isdbo = 'N',lt = {ts '2021-05-31 17:55:58.173'},lu = 'assistenza',title = 'Allegati' WHERE tablename = 'perfvalutazionepersonaleattach'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfvalutazionepersonaleattach',null,null,'N',{ts '2021-05-31 17:55:58.173'},'assistenza','Allegati')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfvalutazionepersonaleattach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 17:56:01.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfvalutazionepersonaleattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfvalutazionepersonaleattach','8',null,null,null,'S',{ts '2021-05-31 17:56:01.143'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfvalutazionepersonaleattach')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 17:56:01.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfvalutazionepersonaleattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfvalutazionepersonaleattach','64',null,null,null,'S',{ts '2021-05-31 17:56:01.143'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattach' AND tablename = 'perfvalutazionepersonaleattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Allegato',kind = 'S',lt = {ts '2021-05-31 17:57:11.063'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattach' AND tablename = 'perfvalutazionepersonaleattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattach','perfvalutazionepersonaleattach','4',null,null,'Allegato','S',{ts '2021-05-31 17:57:11.063'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazionepersonale' AND tablename = 'perfvalutazionepersonaleattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 17:56:01.143'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazionepersonale' AND tablename = 'perfvalutazionepersonaleattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazionepersonale','perfvalutazionepersonaleattach','4',null,null,null,'S',{ts '2021-05-31 17:56:01.143'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazionepersonaleattach' AND tablename = 'perfvalutazionepersonaleattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 17:56:01.143'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazionepersonaleattach' AND tablename = 'perfvalutazionepersonaleattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazionepersonaleattach','perfvalutazionepersonaleattach','4',null,null,null,'S',{ts '2021-05-31 17:56:01.143'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfvalutazionepersonaleattach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 17:56:01.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfvalutazionepersonaleattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfvalutazionepersonaleattach','8',null,null,null,'S',{ts '2021-05-31 17:56:01.143'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfvalutazionepersonaleattach')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 17:56:01.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfvalutazionepersonaleattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfvalutazionepersonaleattach','64',null,null,null,'S',{ts '2021-05-31 17:56:01.143'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --
