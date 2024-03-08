
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
-- CREAZIONE TABELLA insegnintegcaratteristica --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[insegnintegcaratteristica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[insegnintegcaratteristica] (
idinsegn int NOT NULL,
idinsegninteg int NOT NULL,
idinsegnintegcaratteristica int NOT NULL,
cf decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idsasd int NULL,
json varchar(max) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
profess char(1) NOT NULL,
 CONSTRAINT xpkinsegnintegcaratteristica PRIMARY KEY (idinsegn,
idinsegninteg,
idinsegnintegcaratteristica
)
)
END
GO

-- VERIFICA STRUTTURA insegnintegcaratteristica --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idinsegn' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idinsegn int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'idinsegn' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idinsegninteg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idinsegninteg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'idinsegninteg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idinsegnintegcaratteristica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idinsegnintegcaratteristica int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'idinsegnintegcaratteristica' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD cf decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN cf decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'json' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD json varchar(max) NULL 
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN json varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'profess' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD profess char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'profess' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN profess char(1) NOT NULL
GO

-- VERIFICA DI insegnintegcaratteristica IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'insegnintegcaratteristica'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegnintegcaratteristica','int','ASSISTENZA','idinsegn','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegnintegcaratteristica','int','ASSISTENZA','idinsegninteg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegnintegcaratteristica','int','ASSISTENZA','idinsegnintegcaratteristica','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','insegnintegcaratteristica','decimal(9,2)','ASSISTENZA','cf','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegnintegcaratteristica','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegnintegcaratteristica','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','insegnintegcaratteristica','int','ASSISTENZA','idsasd','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','insegnintegcaratteristica','varchar(max)','ASSISTENZA','json','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegnintegcaratteristica','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegnintegcaratteristica','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegnintegcaratteristica','char(1)','ASSISTENZA','profess','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI insegnintegcaratteristica IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'insegnintegcaratteristica')
UPDATE customobject set isreal = 'S' where objectname = 'insegnintegcaratteristica'
ELSE
INSERT INTO customobject (objectname, isreal) values('insegnintegcaratteristica', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'insegnintegcaratteristica')
UPDATE [tabledescr] SET description = null,idapplication = null,isdbo = 'N',lt = {ts '2019-04-09 15:37:14.540'},lu = 'assistenza',title = 'Caratteristiche degli insegnamenti integrandi' WHERE tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('insegnintegcaratteristica',null,null,'N',{ts '2019-04-09 15:37:14.540'},'assistenza','Caratteristiche degli insegnamenti integrandi')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'cf' AND tablename = 'insegnintegcaratteristica')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti',kind = 'S',lt = {ts '2019-04-09 15:38:16.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cf' AND tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cf','insegnintegcaratteristica','5','9','2','Crediti','S',{ts '2019-04-09 15:38:16.997'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'insegnintegcaratteristica')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-09 15:37:17.567'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','insegnintegcaratteristica','8',null,null,null,'S',{ts '2019-04-09 15:37:17.567'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'insegnintegcaratteristica')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-09 15:37:17.567'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','insegnintegcaratteristica','64',null,null,null,'S',{ts '2019-04-09 15:37:17.567'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinsegn' AND tablename = 'insegnintegcaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-09 18:29:58.660'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinsegn' AND tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinsegn','insegnintegcaratteristica','4',null,null,null,'S',{ts '2019-04-09 18:29:58.660'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinsegninteg' AND tablename = 'insegnintegcaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-09 18:29:58.660'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinsegninteg' AND tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinsegninteg','insegnintegcaratteristica','4',null,null,null,'S',{ts '2019-04-09 18:29:58.660'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinsegnintegcaratteristica' AND tablename = 'insegnintegcaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-09 15:37:17.570'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinsegnintegcaratteristica' AND tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinsegnintegcaratteristica','insegnintegcaratteristica','4',null,null,null,'S',{ts '2019-04-09 15:37:17.570'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'insegnintegcaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Settore artistico scientifico disciplinare',kind = 'S',lt = {ts '2019-04-09 15:38:16.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','insegnintegcaratteristica','4',null,null,'Settore artistico scientifico disciplinare','S',{ts '2019-04-09 15:38:16.997'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'insegnintegcaratteristica')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-09 15:37:17.570'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','insegnintegcaratteristica','8',null,null,null,'S',{ts '2019-04-09 15:37:17.570'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'insegnintegcaratteristica')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-09 15:37:17.570'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','insegnintegcaratteristica','64',null,null,null,'S',{ts '2019-04-09 15:37:17.570'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'profess' AND tablename = 'insegnintegcaratteristica')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Professionalizzante',kind = 'S',lt = {ts '2019-04-09 15:38:16.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'profess' AND tablename = 'insegnintegcaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('profess','insegnintegcaratteristica','1',null,null,'Professionalizzante','S',{ts '2019-04-09 15:38:16.997'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

