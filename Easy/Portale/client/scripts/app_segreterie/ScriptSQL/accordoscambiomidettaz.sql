
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


-- CREAZIONE TABELLA accordoscambiomidettaz --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accordoscambiomidettaz]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accordoscambiomidettaz] (
idaccordoscambiomidettaz int NOT NULL,
idreg_aziende int NOT NULL,
idaccordoscambiomi int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
numstud int NULL,
stipula date NULL,
stop date NULL,
 CONSTRAINT xpkaccordoscambiomidettaz PRIMARY KEY (idaccordoscambiomidettaz,
idreg_aziende,
idaccordoscambiomi
)
)
END
GO

-- VERIFICA STRUTTURA accordoscambiomidettaz --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettaz' and C.name = 'idaccordoscambiomidettaz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettaz] ADD idaccordoscambiomidettaz int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettaz') and col.name = 'idaccordoscambiomidettaz' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettaz] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettaz' and C.name = 'idreg_aziende' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettaz] ADD idreg_aziende int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettaz') and col.name = 'idreg_aziende' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettaz] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettaz' and C.name = 'idaccordoscambiomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettaz] ADD idaccordoscambiomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettaz') and col.name = 'idaccordoscambiomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettaz] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettaz' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettaz] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettaz') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidettaz] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettaz' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettaz] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettaz') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidettaz] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettaz' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettaz] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettaz') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidettaz] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettaz' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettaz] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettaz') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidettaz] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettaz' and C.name = 'numstud' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettaz] ADD numstud int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidettaz] ALTER COLUMN numstud int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettaz' and C.name = 'stipula' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettaz] ADD stipula date NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidettaz] ALTER COLUMN stipula date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettaz' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettaz] ADD stop date NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidettaz] ALTER COLUMN stop date NULL
GO

-- VERIFICA DI accordoscambiomidettaz IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accordoscambiomidettaz'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettaz','int','assistenza','idaccordoscambiomi','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettaz','int','assistenza','idaccordoscambiomidettaz','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettaz','int','assistenza','idreg_aziende','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettaz','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettaz','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettaz','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettaz','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettaz','int','assistenza','numstud','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettaz','date','assistenza','stipula','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettaz','date','assistenza','stop','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

-- VERIFICA DI accordoscambiomidettaz IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accordoscambiomidettaz')
UPDATE customobject set isreal = 'S' where objectname = 'accordoscambiomidettaz'
ELSE
INSERT INTO customobject (objectname, isreal) values('accordoscambiomidettaz', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'accordoscambiomidettaz')
UPDATE [tabledescr] SET description = '2.5.31 Dettaglio accordo di mobilità internazionale con enti',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 16:22:27.997'},lu = 'assistenza',title = 'Dettaglio accordo di mobilità internazionale con enti' WHERE tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('accordoscambiomidettaz','2.5.31 Dettaglio accordo di mobilità internazionale con enti',null,'N',{ts '2018-07-20 16:22:27.997'},'assistenza','Dettaglio accordo di mobilità internazionale con enti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'accordoscambiomidettaz')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:22:40.913'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','accordoscambiomidettaz','8',null,null,null,'S',{ts '2018-07-20 16:22:40.913'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'accordoscambiomidettaz')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:22:40.913'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','accordoscambiomidettaz','64',null,null,null,'S',{ts '2018-07-20 16:22:40.913'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomi' AND tablename = 'accordoscambiomidettaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 15:56:21.503'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomi' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomi','accordoscambiomidettaz','4',null,null,null,'S',{ts '2019-11-28 15:56:21.503'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomidettaz' AND tablename = 'accordoscambiomidettaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:22:40.913'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomidettaz' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomidettaz','accordoscambiomidettaz','4',null,null,null,'S',{ts '2018-07-20 16:22:40.913'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende' AND tablename = 'accordoscambiomidettaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Azienda',kind = 'S',lt = {ts '2019-11-28 15:58:22.930'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende','accordoscambiomidettaz','4',null,null,'Azienda','S',{ts '2019-11-28 15:58:22.930'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'accordoscambiomidettaz')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:22:40.913'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','accordoscambiomidettaz','8',null,null,null,'S',{ts '2018-07-20 16:22:40.913'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'accordoscambiomidettaz')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:22:40.913'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','accordoscambiomidettaz','64',null,null,null,'S',{ts '2018-07-20 16:22:40.913'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numstud' AND tablename = 'accordoscambiomidettaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di studenti',kind = 'S',lt = {ts '2019-11-28 15:57:18.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numstud' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numstud','accordoscambiomidettaz','4',null,null,'Numero di studenti','S',{ts '2019-11-28 15:57:18.677'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stipula' AND tablename = 'accordoscambiomidettaz')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di stipula',kind = 'S',lt = {ts '2019-11-28 15:58:22.930'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stipula' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stipula','accordoscambiomidettaz','3',null,null,'Data di stipula','S',{ts '2019-11-28 15:58:22.930'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'accordoscambiomidettaz')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di termine',kind = 'S',lt = {ts '2019-11-28 15:58:22.930'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','accordoscambiomidettaz','3',null,null,'Data di termine','S',{ts '2019-11-28 15:58:22.930'},'assistenza','N','date','date','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --

