
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE TABELLA tirociniocandidatura --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tirociniocandidatura]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tirociniocandidatura] (
idtirociniocandidatura int NOT NULL,
idtirocinioproposto int NOT NULL,
idreg_referente int NOT NULL,
idreg_studenti int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data datetime NULL,
idreg_docenti int NULL,
idtirociniocandidaturakind int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpktirociniocandidatura PRIMARY KEY (idtirociniocandidatura,
idtirocinioproposto,
idreg_referente,
idreg_studenti
)
)
END
GO

-- VERIFICA STRUTTURA tirociniocandidatura --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'idtirociniocandidatura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD idtirociniocandidatura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirociniocandidatura') and col.name = 'idtirociniocandidatura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirociniocandidatura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'idtirocinioproposto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD idtirocinioproposto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirociniocandidatura') and col.name = 'idtirocinioproposto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirociniocandidatura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'idreg_referente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD idreg_referente int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirociniocandidatura') and col.name = 'idreg_referente' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirociniocandidatura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'idreg_studenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD idreg_studenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirociniocandidatura') and col.name = 'idreg_studenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirociniocandidatura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirociniocandidatura') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirociniocandidatura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirociniocandidatura] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirociniocandidatura') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirociniocandidatura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirociniocandidatura] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD data datetime NULL 
END
ELSE
	ALTER TABLE [tirociniocandidatura] ALTER COLUMN data datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD idreg_docenti int NULL 
END
ELSE
	ALTER TABLE [tirociniocandidatura] ALTER COLUMN idreg_docenti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'idtirociniocandidaturakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD idtirociniocandidaturakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirociniocandidatura') and col.name = 'idtirociniocandidaturakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirociniocandidatura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirociniocandidatura] ALTER COLUMN idtirociniocandidaturakind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirociniocandidatura') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirociniocandidatura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirociniocandidatura] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirociniocandidatura' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirociniocandidatura] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirociniocandidatura') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirociniocandidatura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirociniocandidatura] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI tirociniocandidatura IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tirociniocandidatura'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidatura','int','ASSISTENZA','idreg_referente','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidatura','int','ASSISTENZA','idreg_studenti','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidatura','int','ASSISTENZA','idtirociniocandidatura','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidatura','int','ASSISTENZA','idtirocinioproposto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidatura','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidatura','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniocandidatura','datetime','ASSISTENZA','data','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniocandidatura','int','ASSISTENZA','idreg_docenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidatura','int','ASSISTENZA','idtirociniocandidaturakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidatura','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniocandidatura','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tirociniocandidatura IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tirociniocandidatura')
UPDATE customobject set isreal = 'S' where objectname = 'tirociniocandidatura'
ELSE
INSERT INTO customobject (objectname, isreal) values('tirociniocandidatura', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tirociniocandidatura')
UPDATE [tabledescr] SET description = '2.5.21 Candidatura al tirocinio 
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 13:31:10.233'},lu = 'assistenza',title = 'Candidatura al tirocinio ' WHERE tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tirociniocandidatura','2.5.21 Candidatura al tirocinio 
',null,'N',{ts '2018-07-27 13:31:10.233'},'assistenza','Candidatura al tirocinio ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tirociniocandidatura','8',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tirociniocandidatura','64',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','tirociniocandidatura','8',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tutor',kind = 'S',lt = {ts '2019-11-28 18:04:20.023'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','tirociniocandidatura','4',null,null,'Tutor','S',{ts '2019-11-28 18:04:20.023'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_referente' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Referente dell''azienda',kind = 'S',lt = {ts '2019-11-28 18:04:05.853'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_referente' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_referente','tirociniocandidatura','4',null,null,'Referente dell''azienda','S',{ts '2019-11-28 18:04:05.853'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_studenti' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-11-28 18:04:05.853'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_studenti' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_studenti','tirociniocandidatura','4',null,null,'Studente','S',{ts '2019-11-28 18:04:05.853'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniocandidatura' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirociniocandidatura' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniocandidatura','tirociniocandidatura','4',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniocandidaturakind' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2021-06-22 10:57:38.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirociniocandidaturakind' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniocandidaturakind','tirociniocandidatura','4',null,null,'Tipologia','S',{ts '2021-06-22 10:57:38.687'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniopoposto' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Proposta di tirocinio',kind = 'S',lt = {ts '2019-11-28 18:04:40.503'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirociniopoposto' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniopoposto','tirociniocandidatura','4',null,null,'Proposta di tirocinio','S',{ts '2019-11-28 18:04:40.503'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirocinioproposto' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Proposta di tirocinio',kind = 'S',lt = {ts '2020-09-03 17:27:42.770'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirocinioproposto' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirocinioproposto','tirociniocandidatura','4',null,null,'Proposta di tirocinio','S',{ts '2020-09-03 17:27:42.770'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tirociniocandidatura','8',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tirociniocandidatura','64',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3381')
UPDATE [relation] SET childtable = 'tirociniocandidatura',description = 'torocinio a cui ci si candida',lt = {ts '2018-07-27 13:31:47.967'},lu = 'assistenza',parenttable = 'tirocinioproposto',title = null WHERE idrelation = '3381'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3381','tirociniocandidatura','torocinio a cui ci si candida',{ts '2018-07-27 13:31:47.967'},'assistenza','tirocinioproposto',null)
GO

-- FINE GENERAZIONE SCRIPT --

