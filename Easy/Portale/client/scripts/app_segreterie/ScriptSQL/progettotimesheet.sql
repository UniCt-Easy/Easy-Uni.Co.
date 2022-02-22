
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


-- CREAZIONE TABELLA progettotimesheet --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotimesheet]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotimesheet] (
idprogettotimesheet int NOT NULL,
idreg int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
idtimesheettemplate varchar(60) NULL,
intestazioneallsheet char(1) NULL,
lt datetime NULL,
lu varchar(60) NULL,
riepilogoanno char(1) NULL,
showactivitiesrow char(1) NULL,
title nvarchar(2048) NULL,
year int NULL,
 CONSTRAINT xpkprogettotimesheet PRIMARY KEY (idprogettotimesheet,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA progettotimesheet --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'idprogettotimesheet' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD idprogettotimesheet int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheet') and col.name = 'idprogettotimesheet' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheet] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheet') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheet] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'idtimesheettemplate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD idtimesheettemplate varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN idtimesheettemplate varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'intestazioneallsheet' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD intestazioneallsheet char(1) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN intestazioneallsheet char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN lu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'riepilogoanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD riepilogoanno char(1) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN riepilogoanno char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'showactivitiesrow' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD showactivitiesrow char(1) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN showactivitiesrow char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN title nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD year int NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN year int NULL
GO

-- VERIFICA DI progettotimesheet IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettotimesheet'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotimesheet','int','assistenza','idprogettotimesheet','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotimesheet','int','assistenza','idreg','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','varchar(60)','assistenza','cu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','varchar(60)','assistenza','idtimesheettemplate','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','char(1)','assistenza','intestazioneallsheet','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','varchar(60)','assistenza','lu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','char(1)','assistenza','riepilogoanno','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','char(1)','assistenza','showactivitiesrow','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','nvarchar(2048)','assistenza','title','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','int','assistenza','year','4','N','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI progettotimesheet IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettotimesheet')
UPDATE customobject set isreal = 'S' where objectname = 'progettotimesheet'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettotimesheet', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotimesheet')
UPDATE [tabledescr] SET description = 'Timesheets',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-03 11:24:45.727'},lu = 'assistenza',title = 'Timesheets' WHERE tablename = 'progettotimesheet'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotimesheet','Timesheets','3','S',{ts '2021-02-03 11:24:45.727'},'assistenza','Timesheets')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:30:13.560'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotimesheet','8',null,null,null,'S',{ts '2021-02-03 11:30:13.560'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:30:13.560'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotimesheet','60',null,null,null,'S',{ts '2021-02-03 11:30:13.560'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotimesheet' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 12:19:10.057'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotimesheet' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotimesheet','progettotimesheet','4',null,null,null,'S',{ts '2021-02-03 12:19:10.057'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:30:13.563'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','progettotimesheet','4',null,null,null,'S',{ts '2021-02-03 11:30:13.563'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtimesheettemplate' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = 'Intestazione',kind = 'S',lt = {ts '2021-07-20 17:55:00.400'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idtimesheettemplate' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtimesheettemplate','progettotimesheet','60',null,null,'Intestazione','S',{ts '2021-07-20 17:55:00.400'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'intestazioneallsheet' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Intestazione in  tutti i fogli',kind = 'S',lt = {ts '2021-07-20 16:34:15.467'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'intestazioneallsheet' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('intestazioneallsheet','progettotimesheet','1',null,null,'Intestazione in  tutti i fogli','S',{ts '2021-07-20 16:34:15.467'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:30:13.563'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotimesheet','8',null,null,null,'S',{ts '2021-02-03 11:30:13.563'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:30:13.563'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotimesheet','60',null,null,null,'S',{ts '2021-02-03 11:30:13.563'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'riepilogoanno' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Inserisci il riepilogo annuale',kind = 'S',lt = {ts '2021-07-20 16:34:15.467'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'riepilogoanno' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('riepilogoanno','progettotimesheet','1',null,null,'Inserisci il riepilogo annuale','S',{ts '2021-07-20 16:34:15.467'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'showactivitiesrow' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Visualizza la riga con il totale giornaliero',kind = 'S',lt = {ts '2021-02-03 11:38:05.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'showactivitiesrow' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('showactivitiesrow','progettotimesheet','1',null,null,'Visualizza la riga con il totale giornaliero','S',{ts '2021-02-03 11:38:05.607'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-02-03 11:30:50.300'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progettotimesheet','2048',null,null,'Descrizione','S',{ts '2021-02-03 11:30:50.300'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno',kind = 'S',lt = {ts '2021-02-03 12:19:07.873'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','progettotimesheet','4',null,null,'Anno','S',{ts '2021-02-03 12:19:07.873'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

