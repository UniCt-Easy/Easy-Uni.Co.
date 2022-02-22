
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


-- CREAZIONE TABELLA perfprogettoavanzamento --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoavanzamento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogettoavanzamento] (
idperfprogetto int NOT NULL,
idperfprogettoavanzamento int NOT NULL,
avanzamento decimal(18,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data date NULL,
idreg_amministrativi int NULL,
idreg_amministrativi_ver int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkperfprogettoavanzamento PRIMARY KEY (idperfprogetto,
idperfprogettoavanzamento
)
)
END
GO

-- VERIFICA STRUTTURA perfprogettoavanzamento --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'idperfprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD idperfprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'idperfprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'idperfprogettoavanzamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD idperfprogettoavanzamento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'idperfprogettoavanzamento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'avanzamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD avanzamento decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN avanzamento decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD data date NULL 
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'idreg_amministrativi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD idreg_amministrativi int NULL 
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN idreg_amministrativi int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'idreg_amministrativi_ver' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD idreg_amministrativi_ver int NULL 
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN idreg_amministrativi_ver int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoavanzamento' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoavanzamento] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoavanzamento') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoavanzamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoavanzamento] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI perfprogettoavanzamento IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfprogettoavanzamento'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoavanzamento','int','assistenza','idperfprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoavanzamento','int','assistenza','idperfprogettoavanzamento','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoavanzamento','decimal(18,2)','assistenza','avanzamento','9','N','decimal','System.Decimal','','2','''assistenza''','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoavanzamento','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoavanzamento','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoavanzamento','date','assistenza','data','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoavanzamento','int','assistenza','idreg_amministrativi','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoavanzamento','int','assistenza','idreg_amministrativi_ver','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoavanzamento','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoavanzamento','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI perfprogettoavanzamento IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfprogettoavanzamento')
UPDATE customobject set isreal = 'S' where objectname = 'perfprogettoavanzamento'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfprogettoavanzamento', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfprogettoavanzamento')
UPDATE [tabledescr] SET description = 'Avanzamenti',idapplication = null,isdbo = 'N',lt = {ts '2021-05-27 12:26:16.090'},lu = 'assistenza',title = 'Avanzamenti' WHERE tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfprogettoavanzamento','Avanzamenti',null,'N',{ts '2021-05-27 12:26:16.090'},'assistenza','Avanzamenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'avanzamento' AND tablename = 'perfprogettoavanzamento')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Percentuale di avanzamento degli obiettivi',kind = 'S',lt = {ts '2021-05-27 12:31:23.520'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'avanzamento' AND tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('avanzamento','perfprogettoavanzamento','9','18','2','Percentuale di avanzamento degli obiettivi','S',{ts '2021-05-27 12:31:23.520'},'assistenza','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfprogettoavanzamento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 12:30:15.940'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfprogettoavanzamento','8',null,null,null,'S',{ts '2021-05-27 12:30:15.940'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfprogettoavanzamento')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 12:30:15.940'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfprogettoavanzamento','64',null,null,null,'S',{ts '2021-05-27 12:30:15.940'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'perfprogettoavanzamento')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data',kind = 'S',lt = {ts '2021-10-27 11:24:02.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','perfprogettoavanzamento','3',null,null,'Data','S',{ts '2021-10-27 11:24:02.470'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogetto' AND tablename = 'perfprogettoavanzamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 12:30:15.940'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogetto' AND tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogetto','perfprogettoavanzamento','4',null,null,null,'S',{ts '2021-05-27 12:30:15.940'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogettoavanzamento' AND tablename = 'perfprogettoavanzamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 12:30:15.940'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogettoavanzamento' AND tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogettoavanzamento','perfprogettoavanzamento','4',null,null,null,'S',{ts '2021-05-27 12:30:15.940'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_amministrativi' AND tablename = 'perfprogettoavanzamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iniziato da',kind = 'S',lt = {ts '2021-05-27 12:31:23.520'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_amministrativi' AND tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_amministrativi','perfprogettoavanzamento','4',null,null,'Iniziato da','S',{ts '2021-05-27 12:31:23.520'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_amministrativi_ver' AND tablename = 'perfprogettoavanzamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Verificato da',kind = 'S',lt = {ts '2021-05-27 12:31:23.520'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_amministrativi_ver' AND tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_amministrativi_ver','perfprogettoavanzamento','4',null,null,'Verificato da','S',{ts '2021-05-27 12:31:23.520'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfprogettoavanzamento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 12:30:15.940'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfprogettoavanzamento','8',null,null,null,'S',{ts '2021-05-27 12:30:15.940'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfprogettoavanzamento')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 12:30:15.940'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfprogettoavanzamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfprogettoavanzamento','64',null,null,null,'S',{ts '2021-05-27 12:30:15.940'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

