
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
-- CREAZIONE TABELLA costoscontodefdettaglio --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[costoscontodefdettaglio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[costoscontodefdettaglio] (
idcostoscontodefdettaglio int NOT NULL,
idratadef int NOT NULL,
idfasciaiseedef int NOT NULL,
idcostoscontodef int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
idcostoscontodefdettagliokind int NULL,
importo decimal(9,2) NULL,
lt datetime NULL,
lu varchar(64) NULL,
parama decimal(9,2) NULL,
paramb decimal(9,2) NULL,
paramc decimal(9,2) NULL,
paramd decimal(9,2) NULL,
percentuale decimal(9,2) NULL,
 CONSTRAINT xpkcostoscontodefdettaglio PRIMARY KEY (idcostoscontodefdettaglio,
idratadef,
idfasciaiseedef,
idcostoscontodef
)
)
END
GO

-- VERIFICA STRUTTURA costoscontodefdettaglio --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'idcostoscontodefdettaglio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD idcostoscontodefdettaglio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('costoscontodefdettaglio') and col.name = 'idcostoscontodefdettaglio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [costoscontodefdettaglio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'idratadef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD idratadef int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('costoscontodefdettaglio') and col.name = 'idratadef' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [costoscontodefdettaglio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'idfasciaiseedef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD idfasciaiseedef int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('costoscontodefdettaglio') and col.name = 'idfasciaiseedef' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [costoscontodefdettaglio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'idcostoscontodef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD idcostoscontodef int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('costoscontodefdettaglio') and col.name = 'idcostoscontodef' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [costoscontodefdettaglio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'idcostoscontodefdettagliokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD idcostoscontodefdettagliokind int NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN idcostoscontodefdettagliokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'importo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD importo decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN importo decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'parama' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD parama decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN parama decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'paramb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD paramb decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN paramb decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'paramc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD paramc decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN paramc decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'paramd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD paramd decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN paramd decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettaglio' and C.name = 'percentuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettaglio] ADD percentuale decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettaglio] ALTER COLUMN percentuale decimal(9,2) NULL
GO

-- VERIFICA DI costoscontodefdettaglio IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'costoscontodefdettaglio'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefdettaglio','int','ASSISTENZA','idcostoscontodef','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefdettaglio','int','ASSISTENZA','idcostoscontodefdettaglio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefdettaglio','int','ASSISTENZA','idfasciaiseedef','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefdettaglio','int','ASSISTENZA','idratadef','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','int','ASSISTENZA','idcostoscontodefdettagliokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','decimal(9,2)','ASSISTENZA','importo','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','decimal(9,2)','ASSISTENZA','parama','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','decimal(9,2)','ASSISTENZA','paramb','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','decimal(9,2)','ASSISTENZA','paramc','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','decimal(9,2)','ASSISTENZA','paramd','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettaglio','decimal(9,2)','ASSISTENZA','percentuale','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

-- VERIFICA DI costoscontodefdettaglio IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'costoscontodefdettaglio')
UPDATE customobject set isreal = 'S' where objectname = 'costoscontodefdettaglio'
ELSE
INSERT INTO customobject (objectname, isreal) values('costoscontodefdettaglio', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'costoscontodefdettaglio')
UPDATE [tabledescr] SET description = 'Dettaglio di 2.3.11 Costi, 2.3.10 Sconti o 2.3.12 Indennit? / More',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 17:29:34.617'},lu = 'assistenza',title = 'Dettaglio di Costi, Sconti o Indennit? / More' WHERE tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('costoscontodefdettaglio','Dettaglio di 2.3.11 Costi, 2.3.10 Sconti o 2.3.12 Indennit? / More',null,'N',{ts '2018-07-27 17:29:34.617'},'assistenza','Dettaglio di Costi, Sconti o Indennit? / More')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:29:36.653'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','costoscontodefdettaglio','8',null,null,null,'S',{ts '2018-07-27 17:29:36.653'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:29:36.653'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','costoscontodefdettaglio','64',null,null,null,'S',{ts '2018-07-27 17:29:36.653'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcostoscontodef' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:23:24.790'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcostoscontodef' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcostoscontodef','costoscontodefdettaglio','4',null,null,null,'S',{ts '2019-11-29 10:23:24.790'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcostoscontodefdettaglio' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:29:36.653'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcostoscontodefdettaglio' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcostoscontodefdettaglio','costoscontodefdettaglio','4',null,null,null,'S',{ts '2018-07-27 17:29:36.653'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcostoscontodefdettagliokind' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2019-11-29 10:24:24.390'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcostoscontodefdettagliokind' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcostoscontodefdettagliokind','costoscontodefdettaglio','4',null,null,'Tipo','S',{ts '2019-11-29 10:24:24.390'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idfasciaiseedef' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:23:24.790'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idfasciaiseedef' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idfasciaiseedef','costoscontodefdettaglio','4',null,null,null,'S',{ts '2019-11-29 10:23:24.790'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idratadef' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:23:24.790'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idratadef' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idratadef','costoscontodefdettaglio','4',null,null,null,'S',{ts '2019-11-29 10:23:24.790'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'importo' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = null,kind = 'S',lt = {ts '2018-07-27 17:29:36.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'importo' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('importo','costoscontodefdettaglio','5','9','2',null,'S',{ts '2018-07-27 17:29:36.657'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:29:36.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','costoscontodefdettaglio','8',null,null,null,'S',{ts '2018-07-27 17:29:36.657'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:29:36.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','costoscontodefdettaglio','64',null,null,null,'S',{ts '2018-07-27 17:29:36.657'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parama' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Parametro A',kind = 'S',lt = {ts '2019-11-29 10:24:24.390'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'parama' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parama','costoscontodefdettaglio','5','9','2','Parametro A','S',{ts '2019-11-29 10:24:24.390'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paramb' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Parametro B',kind = 'S',lt = {ts '2019-11-29 10:24:24.390'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'paramb' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paramb','costoscontodefdettaglio','5','9','2','Parametro B','S',{ts '2019-11-29 10:24:24.390'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paramc' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Parametro C',kind = 'S',lt = {ts '2019-11-29 10:24:24.390'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'paramc' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paramc','costoscontodefdettaglio','5','9','2','Parametro C','S',{ts '2019-11-29 10:24:24.390'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paramd' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Parametro D',kind = 'S',lt = {ts '2019-11-29 10:24:24.390'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'paramd' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paramd','costoscontodefdettaglio','5','9','2','Parametro D','S',{ts '2019-11-29 10:24:24.390'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'percentuale' AND tablename = 'costoscontodefdettaglio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = null,kind = 'S',lt = {ts '2018-07-27 17:29:36.657'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'percentuale' AND tablename = 'costoscontodefdettaglio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('percentuale','costoscontodefdettaglio','5','9','2',null,'S',{ts '2018-07-27 17:29:36.657'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3409')
UPDATE [relation] SET childtable = 'costoscontodefdettaglio',description = ' Costi, Sconti o Indennit? / More che sta dettagliando',lt = {ts '2018-07-27 17:30:19.930'},lu = 'assistenza',parenttable = 'costoscontodef',title = null WHERE idrelation = '3409'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3409','costoscontodefdettaglio',' Costi, Sconti o Indennit? / More che sta dettagliando',{ts '2018-07-27 17:30:19.930'},'assistenza','costoscontodef',null)
GO

-- FINE GENERAZIONE SCRIPT --

