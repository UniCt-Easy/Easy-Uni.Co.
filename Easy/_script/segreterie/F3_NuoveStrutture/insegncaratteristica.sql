
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
-- CREAZIONE TABELLA insegncaratteristica --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[insegncaratteristica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[insegncaratteristica] (
idinsegn int NOT NULL,
idinsegncaratteristica int NOT NULL,
cf decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idsasd int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
profess char(1) NOT NULL,
 CONSTRAINT xpkinsegncaratteristica PRIMARY KEY (idinsegn,
idinsegncaratteristica
)
)
END
GO

-- VERIFICA STRUTTURA insegncaratteristica --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegncaratteristica' and C.name = 'idinsegn' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegncaratteristica] ADD idinsegn int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegncaratteristica') and col.name = 'idinsegn' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegncaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegncaratteristica' and C.name = 'idinsegncaratteristica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegncaratteristica] ADD idinsegncaratteristica int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegncaratteristica') and col.name = 'idinsegncaratteristica' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegncaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegncaratteristica' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegncaratteristica] ADD cf decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [insegncaratteristica] ALTER COLUMN cf decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegncaratteristica' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegncaratteristica] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegncaratteristica') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegncaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegncaratteristica] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegncaratteristica' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegncaratteristica] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegncaratteristica') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegncaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegncaratteristica] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegncaratteristica' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegncaratteristica] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [insegncaratteristica] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegncaratteristica' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegncaratteristica] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegncaratteristica') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegncaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegncaratteristica] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegncaratteristica' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegncaratteristica] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegncaratteristica') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegncaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegncaratteristica] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegncaratteristica' and C.name = 'profess' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegncaratteristica] ADD profess char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegncaratteristica') and col.name = 'profess' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegncaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegncaratteristica] ALTER COLUMN profess char(1) NOT NULL
GO

-- VERIFICA DI insegncaratteristica IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'insegncaratteristica'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegncaratteristica','int','ASSISTENZA','idinsegn','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegncaratteristica','int','ASSISTENZA','idinsegncaratteristica','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','insegncaratteristica','decimal(9,2)','ASSISTENZA','cf','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegncaratteristica','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegncaratteristica','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','insegncaratteristica','int','ASSISTENZA','idsasd','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegncaratteristica','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegncaratteristica','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','insegncaratteristica','char(1)','ASSISTENZA','profess','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI insegncaratteristica IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'insegncaratteristica')
UPDATE customobject set isreal = 'S' where objectname = 'insegncaratteristica'
ELSE
INSERT INTO customobject (objectname, isreal) values('insegncaratteristica', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'insegncaratteristica')
UPDATE [tabledescr] SET description = 'caratteristiche dell?insegnamento nel vocabolario ovvero sasd e cf',idapplication = null,isdbo = 'N',lt = {ts '2018-07-19 17:43:52.800'},lu = 'assistenza',title = 'Caratteristiche dell?insegnamento nel vocabolario ovvero sasd e cf' WHERE tablename = 'insegncaratteristica'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('insegncaratteristica','caratteristiche dell?insegnamento nel vocabolario ovvero sasd e cf',null,'N',{ts '2018-07-19 17:43:52.800'},'assistenza','Caratteristiche dell?insegnamento nel vocabolario ovvero sasd e cf')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'cf' AND tablename = 'insegncaratteristica')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti',kind = 'S',lt = {ts '2019-03-28 11:15:53.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cf' AND tablename = 'insegncaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cf','insegncaratteristica','5','9','2','Crediti','S',{ts '2019-03-28 11:15:53.143'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'insegncaratteristica')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:43:54.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'insegncaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','insegncaratteristica','8',null,null,null,'S',{ts '2018-07-19 17:43:54.953'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'insegncaratteristica')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:43:54.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'insegncaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','insegncaratteristica','64',null,null,null,'S',{ts '2018-07-19 17:43:54.953'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinsegn' AND tablename = 'insegncaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-03-28 11:09:45.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinsegn' AND tablename = 'insegncaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinsegn','insegncaratteristica','4',null,null,null,'S',{ts '2019-03-28 11:09:45.937'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinsegncaratteristica' AND tablename = 'insegncaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-03-28 11:09:45.937'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinsegncaratteristica' AND tablename = 'insegncaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinsegncaratteristica','insegncaratteristica','4',null,null,null,'S',{ts '2019-03-28 11:09:45.937'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'insegncaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD',kind = 'S',lt = {ts '2019-03-28 11:15:53.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'insegncaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','insegncaratteristica','4',null,null,'SASD','S',{ts '2019-03-28 11:15:53.143'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'insegncaratteristica')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:43:54.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'insegncaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','insegncaratteristica','8',null,null,null,'S',{ts '2018-07-19 17:43:54.953'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'insegncaratteristica')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:43:54.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'insegncaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','insegncaratteristica','64',null,null,null,'S',{ts '2018-07-19 17:43:54.953'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'profess' AND tablename = 'insegncaratteristica')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Professionalizzante',kind = 'S',lt = {ts '2019-03-28 11:15:53.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'profess' AND tablename = 'insegncaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('profess','insegncaratteristica','1',null,null,'Professionalizzante','S',{ts '2019-03-28 11:15:53.143'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3291')
UPDATE [relation] SET childtable = 'insegncaratteristica',description = 'insegnamento da caratterizzare',lt = {ts '2018-07-19 17:44:41.867'},lu = 'assistenza',parenttable = 'Insegn',title = null WHERE idrelation = '3291'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3291','insegncaratteristica','insegnamento da caratterizzare',{ts '2018-07-19 17:44:41.867'},'assistenza','Insegn',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3292')
UPDATE [relation] SET childtable = 'insegncaratteristica',description = 'caratteristica dell''insegnamento',lt = {ts '2018-07-19 17:44:41.890'},lu = 'assistenza',parenttable = 'caratteristica',title = null WHERE idrelation = '3292'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3292','insegncaratteristica','caratteristica dell''insegnamento',{ts '2018-07-19 17:44:41.890'},'assistenza','caratteristica',null)
GO

-- FINE GENERAZIONE SCRIPT --

