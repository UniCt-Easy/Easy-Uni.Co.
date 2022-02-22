
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


--[DBO]--
-- CREAZIONE TABELLA dichiar_altrititoli --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiar_altrititoli]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dichiar_altrititoli] (
iddichiar int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
dataottenimento date NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rilasciatoda varchar(1024) NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkdichiar_altrititoli PRIMARY KEY (iddichiar,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA dichiar_altrititoli --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiar_altrititoli' and C.name = 'iddichiar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiar_altrititoli] ADD iddichiar int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiar_altrititoli') and col.name = 'iddichiar' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiar_altrititoli] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiar_altrititoli' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiar_altrititoli] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiar_altrititoli') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiar_altrititoli] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiar_altrititoli' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiar_altrititoli] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiar_altrititoli') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiar_altrititoli] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiar_altrititoli] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiar_altrititoli' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiar_altrititoli] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiar_altrititoli') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiar_altrititoli] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiar_altrititoli] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiar_altrititoli' and C.name = 'dataottenimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiar_altrititoli] ADD dataottenimento date NULL 
END
ELSE
	ALTER TABLE [dichiar_altrititoli] ALTER COLUMN dataottenimento date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiar_altrititoli' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiar_altrititoli] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiar_altrititoli') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiar_altrititoli] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiar_altrititoli] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiar_altrititoli' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiar_altrititoli] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiar_altrititoli') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiar_altrititoli] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiar_altrititoli] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiar_altrititoli' and C.name = 'rilasciatoda' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiar_altrititoli] ADD rilasciatoda varchar(1024) NULL 
END
ELSE
	ALTER TABLE [dichiar_altrititoli] ALTER COLUMN rilasciatoda varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiar_altrititoli' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiar_altrititoli] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [dichiar_altrititoli] ALTER COLUMN title varchar(1024) NULL
GO

-- VERIFICA DI dichiar_altrititoli IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiar_altrititoli'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiar_altrititoli','int','ASSISTENZA','iddichiar','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiar_altrititoli','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiar_altrititoli','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiar_altrititoli','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiar_altrititoli','date','ASSISTENZA','dataottenimento','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiar_altrititoli','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiar_altrititoli','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiar_altrititoli','varchar(1024)','ASSISTENZA','rilasciatoda','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiar_altrititoli','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiar_altrititoli IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiar_altrititoli')
UPDATE customobject set isreal = 'S' where objectname = 'dichiar_altrititoli'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiar_altrititoli', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'dichiar_altrititoli')
UPDATE [tabledescr] SET description = '2.1.2 Dichiarazione di altri titoli',idapplication = null,isdbo = 'N',lt = {ts '2018-07-17 15:56:12.520'},lu = 'assistenza',title = 'Dichiarazione di altri titoli' WHERE tablename = 'dichiar_altrititoli'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('dichiar_altrititoli','2.1.2 Dichiarazione di altri titoli',null,'N',{ts '2018-07-17 15:56:12.520'},'assistenza','Dichiarazione di altri titoli')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'dichiar_altrititoli')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 15:56:14.557'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'dichiar_altrititoli'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','dichiar_altrititoli','8',null,null,null,'S',{ts '2018-07-17 15:56:14.557'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'dichiar_altrititoli')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 15:56:14.560'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'dichiar_altrititoli'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','dichiar_altrititoli','64',null,null,null,'S',{ts '2018-07-17 15:56:14.560'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'dataottenimento' AND tablename = 'dichiar_altrititoli')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data ottenimento',kind = 'S',lt = {ts '2020-09-11 17:23:52.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'dataottenimento' AND tablename = 'dichiar_altrititoli'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('dataottenimento','dichiar_altrititoli','3',null,null,'Data ottenimento','S',{ts '2020-09-11 17:23:52.640'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddichiar' AND tablename = 'dichiar_altrititoli')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 15:56:14.560'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddichiar' AND tablename = 'dichiar_altrititoli'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddichiar','dichiar_altrititoli','4',null,null,null,'S',{ts '2018-07-17 15:56:14.560'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'dichiar_altrititoli')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-13 10:50:34.693'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'dichiar_altrititoli'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','dichiar_altrititoli','4',null,null,null,'S',{ts '2019-11-13 10:50:34.693'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'dichiar_altrititoli')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 15:56:14.560'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'dichiar_altrititoli'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','dichiar_altrititoli','8',null,null,null,'S',{ts '2018-07-17 15:56:14.560'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'dichiar_altrititoli')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 15:56:14.560'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'dichiar_altrititoli'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','dichiar_altrititoli','64',null,null,null,'S',{ts '2018-07-17 15:56:14.560'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rilasciatoda' AND tablename = 'dichiar_altrititoli')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Rilasciato da',kind = 'S',lt = {ts '2020-09-11 17:23:52.643'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'rilasciatoda' AND tablename = 'dichiar_altrititoli'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rilasciatoda','dichiar_altrititoli','1024',null,null,'Rilasciato da','S',{ts '2020-09-11 17:23:52.643'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'dichiar_altrititoli')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-09-14 13:20:47.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'dichiar_altrititoli'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','dichiar_altrititoli','1024',null,null,'Titolo','S',{ts '2020-09-14 13:20:47.073'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

