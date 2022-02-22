
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
-- CREAZIONE TABELLA costoscontodef --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[costoscontodef]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[costoscontodef] (
idcostoscontodef int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
idcostoscontodefkind int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
paridcostoscontodef int NULL,
title nvarchar(2024) NULL,
 CONSTRAINT xpkcostoscontodef PRIMARY KEY (idcostoscontodef
)
)
END
GO

-- VERIFICA STRUTTURA costoscontodef --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'idcostoscontodef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD idcostoscontodef int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('costoscontodef') and col.name = 'idcostoscontodef' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [costoscontodef] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'idcostoscontodefkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD idcostoscontodefkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('costoscontodef') and col.name = 'idcostoscontodefkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [costoscontodef] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN idcostoscontodefkind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'paridcostoscontodef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD paridcostoscontodef int NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN paridcostoscontodef int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodef' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodef] ADD title nvarchar(2024) NULL 
END
ELSE
	ALTER TABLE [costoscontodef] ALTER COLUMN title nvarchar(2024) NULL
GO

-- VERIFICA DI costoscontodef IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'costoscontodef'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodef','int','ASSISTENZA','idcostoscontodef','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodef','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodef','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodef','int','ASSISTENZA','idcostoscontodefkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodef','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodef','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodef','int','ASSISTENZA','paridcostoscontodef','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodef','nvarchar(2024)','ASSISTENZA','title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI costoscontodef IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'costoscontodef')
UPDATE customobject set isreal = 'S' where objectname = 'costoscontodef'
ELSE
INSERT INTO customobject (objectname, isreal) values('costoscontodef', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'costoscontodef')
UPDATE [tabledescr] SET description = '2.3.11 Costi
2.3.10 Sconti 
2.3.12 Indennit? / More
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 17:26:42.977'},lu = 'assistenza',title = 'Costi
, Sconti, Indennit? / More' WHERE tablename = 'costoscontodef'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('costoscontodef','2.3.11 Costi
2.3.10 Sconti 
2.3.12 Indennit? / More
',null,'N',{ts '2018-07-27 17:26:42.977'},'assistenza','Costi
, Sconti, Indennit? / More')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'costoscontodef')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:26:51.530'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','costoscontodef','8',null,null,null,'S',{ts '2018-07-27 17:26:51.530'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'costoscontodef')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:26:51.530'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','costoscontodef','64',null,null,null,'S',{ts '2018-07-27 17:26:51.530'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcostoscontodef' AND tablename = 'costoscontodef')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:26:51.530'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcostoscontodef' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcostoscontodef','costoscontodef','4',null,null,null,'S',{ts '2018-07-27 17:26:51.530'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcostoscontodefkind' AND tablename = 'costoscontodef')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2020-01-07 10:46:32.893'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcostoscontodefkind' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcostoscontodefkind','costoscontodef','4',null,null,'Tipologia','S',{ts '2020-01-07 10:46:32.893'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'costoscontodef')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:26:51.530'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','costoscontodef','8',null,null,null,'S',{ts '2018-07-27 17:26:51.530'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'costoscontodef')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:26:51.530'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','costoscontodef','64',null,null,null,'S',{ts '2018-07-27 17:26:51.530'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paridcostoscontodef' AND tablename = 'costoscontodef')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Relativo al costo',kind = 'S',lt = {ts '2020-01-08 12:41:18.153'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'paridcostoscontodef' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paridcostoscontodef','costoscontodef','4',null,null,'Relativo al costo','S',{ts '2020-01-08 12:41:18.153'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'costoscontodef')
UPDATE [coldescr] SET col_len = '2024',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2019-11-29 10:21:47.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2024)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','costoscontodef','2024',null,null,'Titolo','S',{ts '2019-11-29 10:21:47.927'},'assistenza','N','nvarchar(2024)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

