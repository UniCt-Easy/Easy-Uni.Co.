
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
-- CREAZIONE TABELLA contratto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contratto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[contratto] (
idcontratto int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
estremibando varchar(50) NULL,
idcontrattokind int NOT NULL,
idinquadramento int NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
parttime decimal(5,2) NULL,
scatto int NULL,
start date NOT NULL,
stop date NULL,
tempdef char(1) NOT NULL,
tempindet char(1) NOT NULL,
 CONSTRAINT xpkcontratto PRIMARY KEY (idcontratto
)
)
END
GO

-- VERIFICA STRUTTURA contratto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'idcontratto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD idcontratto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'idcontratto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'estremibando' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD estremibando varchar(50) NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN estremibando varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN idcontrattokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'idinquadramento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD idinquadramento int NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN idinquadramento int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'parttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD parttime decimal(5,2) NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN parttime decimal(5,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD scatto int NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN scatto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD start date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'start' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN start date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD stop date NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'tempdef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD tempdef char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'tempdef' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN tempdef char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'tempindet' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD tempindet char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'tempindet' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN tempindet char(1) NOT NULL
GO

-- VERIFICA DI contratto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'contratto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contratto','int','ASSISTENZA','idcontratto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contratto','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contratto','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contratto','varchar(50)','ASSISTENZA','estremibando','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contratto','int','ASSISTENZA','idcontrattokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contratto','int','ASSISTENZA','idinquadramento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contratto','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contratto','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contratto','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contratto','decimal(5,2)','ASSISTENZA','parttime','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contratto','int','ASSISTENZA','scatto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contratto','date','ASSISTENZA','start','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contratto','date','ASSISTENZA','stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contratto','char(1)','ASSISTENZA','tempdef','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contratto','char(1)','ASSISTENZA','tempindet','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI contratto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'contratto')
UPDATE customobject set isreal = 'S' where objectname = 'contratto'
ELSE
INSERT INTO customobject (objectname, isreal) values('contratto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'contratto')
UPDATE [tabledescr] SET description = '2.4.21 Contratto',idapplication = null,isdbo = 'N',lt = {ts '2018-11-27 12:51:42.000'},lu = 'Ferdinando',title = 'Contratto' WHERE tablename = 'contratto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('contratto','2.4.21 Contratto',null,'N',{ts '2018-11-27 12:51:42.000'},'Ferdinando','Contratto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:15:43.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','contratto','8',null,null,null,'S',{ts '2018-07-17 16:15:43.843'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:15:43.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','contratto','64',null,null,null,'S',{ts '2018-07-17 16:15:43.843'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'estremibando' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Estremi del bando di contratto',kind = 'S',lt = {ts '2018-11-21 15:51:08.620'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'estremibando' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('estremibando','contratto','50',null,null,'Estremi del bando di contratto','S',{ts '2018-11-21 15:51:08.620'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontratto' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-11-27 13:03:00.603'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontratto' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontratto','contratto','4',null,null,'Codice','S',{ts '2018-11-27 13:03:00.603'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia di contratto',kind = 'S',lt = {ts '2018-11-27 13:03:00.603'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','contratto','4',null,null,'Tipologia di contratto','S',{ts '2018-11-27 13:03:00.603'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinquadramento' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Inquadramento',kind = 'S',lt = {ts '2020-07-14 15:37:31.507'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinquadramento' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinquadramento','contratto','4',null,null,'Inquadramento','S',{ts '2020-07-14 15:37:31.507'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente',kind = 'S',lt = {ts '2018-11-21 15:51:08.620'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','contratto','4',null,null,'Docente','S',{ts '2018-11-21 15:51:08.620'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:15:43.847'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','contratto','8',null,null,null,'S',{ts '2018-07-17 16:15:43.847'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:15:43.847'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','contratto','64',null,null,null,'S',{ts '2018-07-17 16:15:43.847'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parttime' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Part-time %',kind = 'S',lt = {ts '2020-05-21 16:38:00.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'parttime' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parttime','contratto','5','5','2','Part-time %','S',{ts '2020-05-21 16:38:00.547'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scatto' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:37:20.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'scatto' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scatto','contratto','4',null,null,null,'S',{ts '2020-07-14 15:37:20.090'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Inizio',kind = 'S',lt = {ts '2018-11-21 15:51:08.620'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','contratto','3',null,null,'Inizio','S',{ts '2018-11-21 15:51:08.620'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Fine',kind = 'S',lt = {ts '2018-11-21 15:51:08.620'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','contratto','3',null,null,'Fine','S',{ts '2018-11-21 15:51:08.620'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tempdef' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Tempo definito',kind = 'S',lt = {ts '2020-05-21 10:47:29.447'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tempdef' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tempdef','contratto','1',null,null,'Tempo definito','S',{ts '2020-05-21 10:47:29.447'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tempindet' AND tablename = 'contratto')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Tempo indeterminato',kind = 'S',lt = {ts '2018-11-21 15:51:08.620'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tempindet' AND tablename = 'contratto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tempindet','contratto','1',null,null,'Tempo indeterminato','S',{ts '2018-11-21 15:51:08.620'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3440')
UPDATE [relation] SET childtable = 'contratto',description = 'Contratti',lt = {ts '2018-12-07 18:37:51.917'},lu = 'assistenza',parenttable = 'docenti',title = '2.4.21 Contratto' WHERE idrelation = '3440'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3440','contratto','Contratti',{ts '2018-12-07 18:37:51.917'},'assistenza','docenti','2.4.21 Contratto')
GO

-- FINE GENERAZIONE SCRIPT --

