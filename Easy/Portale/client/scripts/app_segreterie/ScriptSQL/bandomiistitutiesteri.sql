
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


--[DBO]--
-- CREAZIONE TABELLA bandomiistitutiesteri --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandomiistitutiesteri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[bandomiistitutiesteri] (
idbandomi int NOT NULL,
idreg_istitutiesteri int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkbandomiistitutiesteri PRIMARY KEY (idbandomi,
idreg_istitutiesteri
)
)
END
GO

-- VERIFICA STRUTTURA bandomiistitutiesteri --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomiistitutiesteri' and C.name = 'idbandomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomiistitutiesteri] ADD idbandomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomiistitutiesteri') and col.name = 'idbandomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomiistitutiesteri] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomiistitutiesteri' and C.name = 'idreg_istitutiesteri' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomiistitutiesteri] ADD idreg_istitutiesteri int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomiistitutiesteri') and col.name = 'idreg_istitutiesteri' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomiistitutiesteri] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomiistitutiesteri' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomiistitutiesteri] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomiistitutiesteri') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomiistitutiesteri] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomiistitutiesteri] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomiistitutiesteri' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomiistitutiesteri] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomiistitutiesteri') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomiistitutiesteri] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomiistitutiesteri] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomiistitutiesteri' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomiistitutiesteri] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomiistitutiesteri') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomiistitutiesteri] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomiistitutiesteri] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomiistitutiesteri' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomiistitutiesteri] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomiistitutiesteri') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomiistitutiesteri] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomiistitutiesteri] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI bandomiistitutiesteri IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'bandomiistitutiesteri'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomiistitutiesteri','int','ASSISTENZA','idbandomi','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomiistitutiesteri','int','ASSISTENZA','idreg_istitutiesteri','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomiistitutiesteri','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomiistitutiesteri','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomiistitutiesteri','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomiistitutiesteri','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI bandomiistitutiesteri IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'bandomiistitutiesteri')
UPDATE customobject set isreal = 'S' where objectname = 'bandomiistitutiesteri'
ELSE
INSERT INTO customobject (objectname, isreal) values('bandomiistitutiesteri', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'bandomiistitutiesteri')
UPDATE [tabledescr] SET description = 'Istituti partner dei 2.5.15 Bandi per la mobilit� internazionale
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 11:17:15.907'},lu = 'assistenza',title = 'Istituti partner dei bandi per la mobilit� internazionale' WHERE tablename = 'bandomiistitutiesteri'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('bandomiistitutiesteri','Istituti partner dei 2.5.15 Bandi per la mobilit� internazionale
',null,'N',{ts '2018-07-27 11:17:15.907'},'assistenza','Istituti partner dei bandi per la mobilit� internazionale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'bandomiistitutiesteri')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:17:34.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'bandomiistitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','bandomiistitutiesteri','8',null,null,null,'S',{ts '2018-07-27 11:17:34.813'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'bandomiistitutiesteri')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:17:34.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'bandomiistitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','bandomiistitutiesteri','64',null,null,null,'S',{ts '2018-07-27 11:17:34.813'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandomi' AND tablename = 'bandomiistitutiesteri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:17:34.813'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandomi' AND tablename = 'bandomiistitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandomi','bandomiistitutiesteri','4',null,null,null,'S',{ts '2018-07-27 11:17:34.813'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_istitutiesteri' AND tablename = 'bandomiistitutiesteri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto',kind = 'S',lt = {ts '2019-02-25 10:38:19.340'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_istitutiesteri' AND tablename = 'bandomiistitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_istitutiesteri','bandomiistitutiesteri','4',null,null,'Istituto','S',{ts '2019-02-25 10:38:19.340'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'bandomiistitutiesteri')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:17:34.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'bandomiistitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','bandomiistitutiesteri','8',null,null,null,'S',{ts '2018-07-27 11:17:34.813'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'bandomiistitutiesteri')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:17:34.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'bandomiistitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','bandomiistitutiesteri','64',null,null,null,'S',{ts '2018-07-27 11:17:34.813'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3362')
UPDATE [relation] SET childtable = 'bandomiistitutiesteri',description = 'bando di mobilit� internazionale di cui fanno parte ',lt = {ts '2018-07-27 11:17:34.593'},lu = 'assistenza',parenttable = 'bandomi',title = null WHERE idrelation = '3362'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3362','bandomiistitutiesteri','bando di mobilit� internazionale di cui fanno parte ',{ts '2018-07-27 11:17:34.593'},'assistenza','bandomi',null)
GO

-- FINE GENERAZIONE SCRIPT --

