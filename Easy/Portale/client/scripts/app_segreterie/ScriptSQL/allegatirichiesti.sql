
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


-- CREAZIONE TABELLA allegatirichiesti --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[allegatirichiesti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[allegatirichiesti] (
idallegatirichiesti int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(max) NOT NULL,
 CONSTRAINT xpkallegatirichiesti PRIMARY KEY (idallegatirichiesti
)
)
END
GO

-- VERIFICA STRUTTURA allegatirichiesti --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allegatirichiesti' and C.name = 'idallegatirichiesti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allegatirichiesti] ADD idallegatirichiesti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('allegatirichiesti') and col.name = 'idallegatirichiesti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [allegatirichiesti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allegatirichiesti' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allegatirichiesti] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [allegatirichiesti] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allegatirichiesti' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allegatirichiesti] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('allegatirichiesti') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [allegatirichiesti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [allegatirichiesti] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allegatirichiesti' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allegatirichiesti] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('allegatirichiesti') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [allegatirichiesti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [allegatirichiesti] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allegatirichiesti' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allegatirichiesti] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('allegatirichiesti') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [allegatirichiesti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [allegatirichiesti] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allegatirichiesti' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allegatirichiesti] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('allegatirichiesti') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [allegatirichiesti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [allegatirichiesti] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allegatirichiesti' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allegatirichiesti] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('allegatirichiesti') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [allegatirichiesti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [allegatirichiesti] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'allegatirichiesti' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [allegatirichiesti] ADD title varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('allegatirichiesti') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [allegatirichiesti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [allegatirichiesti] ALTER COLUMN title varchar(max) NOT NULL
GO

-- VERIFICA DI allegatirichiesti IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'allegatirichiesti'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiesti','int','assistenza','idallegatirichiesti','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','allegatirichiesti','char(1)','assistenza','active','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiesti','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiesti','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiesti','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiesti','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiesti','int','assistenza','sortcode','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','allegatirichiesti','varchar(max)','assistenza','title','-1','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI allegatirichiesti IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'allegatirichiesti')
UPDATE customobject set isreal = 'S' where objectname = 'allegatirichiesti'
ELSE
INSERT INTO customobject (objectname, isreal) values('allegatirichiesti', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'allegatirichiesti')
UPDATE [tabledescr] SET description = 'Allegati richiedibili dai 2.5.15 Bandi per la mobilità internazionale
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 11:13:41.290'},lu = 'assistenza',title = 'Allegati richiedibili dai bandi per la mobilità internazionale' WHERE tablename = 'allegatirichiesti'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('allegatirichiesti','Allegati richiedibili dai 2.5.15 Bandi per la mobilità internazionale
',null,'N',{ts '2018-07-27 11:13:41.290'},'assistenza','Allegati richiedibili dai bandi per la mobilità internazionale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'allegatirichiesti')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Attivo',kind = 'S',lt = {ts '2021-06-21 17:47:33.910'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'allegatirichiesti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','allegatirichiesti','1',null,null,'Attivo','S',{ts '2021-06-21 17:47:33.910'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'allegatirichiesti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:13:42.977'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'allegatirichiesti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','allegatirichiesti','8',null,null,null,'S',{ts '2018-07-27 11:13:42.977'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'allegatirichiesti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:13:42.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'allegatirichiesti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','allegatirichiesti','64',null,null,null,'S',{ts '2018-07-27 11:13:42.980'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idallegatirichiesti' AND tablename = 'allegatirichiesti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:13:42.980'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idallegatirichiesti' AND tablename = 'allegatirichiesti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idallegatirichiesti','allegatirichiesti','4',null,null,null,'S',{ts '2018-07-27 11:13:42.980'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'allegatirichiesti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:13:42.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'allegatirichiesti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','allegatirichiesti','8',null,null,null,'S',{ts '2018-07-27 11:13:42.980'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'allegatirichiesti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:13:42.980'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'allegatirichiesti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','allegatirichiesti','64',null,null,null,'S',{ts '2018-07-27 11:13:42.980'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'allegatirichiesti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice identificativo',kind = 'S',lt = {ts '2020-09-07 12:30:33.707'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'allegatirichiesti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','allegatirichiesti','4',null,null,'Codice identificativo','S',{ts '2020-09-07 12:30:33.707'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'allegatirichiesti')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-09-07 12:30:33.707'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'allegatirichiesti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','allegatirichiesti','-1',null,null,'Titolo','S',{ts '2020-09-07 12:30:33.707'},'assistenza','N','varchar(max)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3358')
UPDATE [relation] SET childtable = 'allegatirichiesti',description = 'bando di mobilità internazionale di cui fanno parte ',lt = {ts '2018-07-27 11:14:27.720'},lu = 'assistenza',parenttable = 'bandomi',title = null WHERE idrelation = '3358'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3358','allegatirichiesti','bando di mobilità internazionale di cui fanno parte ',{ts '2018-07-27 11:14:27.720'},'assistenza','bandomi',null)
GO

-- FINE GENERAZIONE SCRIPT --

