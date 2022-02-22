
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


-- CREAZIONE TABELLA progettofinanziamento --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettofinanziamento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettofinanziamento] (
idprogettofinanziamento int NOT NULL,
idprogetto int NOT NULL,
contributo decimal(18,2) NULL,
contributoente decimal(18,2) NULL,
ct datetime NOT NULL,
cu varchar(60) NOT NULL,
data date NULL,
lt datetime NOT NULL,
lu varchar(60) NOT NULL,
 CONSTRAINT xpkprogettofinanziamento PRIMARY KEY (idprogettofinanziamento,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettofinanziamento --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettofinanziamento' and C.name = 'idprogettofinanziamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettofinanziamento] ADD idprogettofinanziamento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettofinanziamento') and col.name = 'idprogettofinanziamento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettofinanziamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettofinanziamento' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettofinanziamento] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettofinanziamento') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettofinanziamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettofinanziamento' and C.name = 'contributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettofinanziamento] ADD contributo decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [progettofinanziamento] ALTER COLUMN contributo decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettofinanziamento' and C.name = 'contributoente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettofinanziamento] ADD contributoente decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [progettofinanziamento] ALTER COLUMN contributoente decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettofinanziamento' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettofinanziamento] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettofinanziamento') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettofinanziamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettofinanziamento] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettofinanziamento' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettofinanziamento] ADD cu varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettofinanziamento') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettofinanziamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettofinanziamento] ALTER COLUMN cu varchar(60) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettofinanziamento' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettofinanziamento] ADD data date NULL 
END
ELSE
	ALTER TABLE [progettofinanziamento] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettofinanziamento' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettofinanziamento] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettofinanziamento') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettofinanziamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettofinanziamento] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettofinanziamento' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettofinanziamento] ADD lu varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettofinanziamento') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettofinanziamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettofinanziamento] ALTER COLUMN lu varchar(60) NOT NULL
GO

-- VERIFICA DI progettofinanziamento IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettofinanziamento'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettofinanziamento','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettofinanziamento','int','assistenza','idprogettofinanziamento','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettofinanziamento','decimal(18,2)','assistenza','contributo','9','N','decimal','System.Decimal','','2','''assistenza''','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettofinanziamento','decimal(18,2)','assistenza','contributoente','9','N','decimal','System.Decimal','','2','''assistenza''','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettofinanziamento','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettofinanziamento','varchar(60)','assistenza','cu','60','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettofinanziamento','date','assistenza','data','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettofinanziamento','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettofinanziamento','varchar(60)','assistenza','lu','60','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progettofinanziamento IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettofinanziamento')
UPDATE customobject set isreal = 'S' where objectname = 'progettofinanziamento'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettofinanziamento', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettofinanziamento')
UPDATE [tabledescr] SET description = 'qualora l’importo del finanziamento o del contributo cambiasse si può inserire la variazione',idapplication = '3',isdbo = 'N',lt = {ts '2021-06-17 16:58:49.557'},lu = 'assistenza',title = 'Rimodulazioni del finanziamento' WHERE tablename = 'progettofinanziamento'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettofinanziamento','qualora l’importo del finanziamento o del contributo cambiasse si può inserire la variazione','3','N',{ts '2021-06-17 16:58:49.557'},'assistenza','Rimodulazioni del finanziamento')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributo' AND tablename = 'progettofinanziamento')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Cofinanziamento richiesto all''ateneo',kind = 'S',lt = {ts '2021-06-17 16:58:49.557'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributo' AND tablename = 'progettofinanziamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributo','progettofinanziamento','9','18','2','Cofinanziamento richiesto all''ateneo','S',{ts '2021-06-17 16:58:49.557'},'assistenza','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributoente' AND tablename = 'progettofinanziamento')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Contributo totale richiesto dall''ateneo all’ente finanziatore',kind = 'S',lt = {ts '2021-06-17 16:58:49.557'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributoente' AND tablename = 'progettofinanziamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributoente','progettofinanziamento','9','18','2','Contributo totale richiesto dall''ateneo all’ente finanziatore','S',{ts '2021-06-17 16:58:49.557'},'assistenza','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettofinanziamento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-17 16:47:29.233'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettofinanziamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettofinanziamento','8',null,null,null,'S',{ts '2021-06-17 16:47:29.233'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettofinanziamento')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-17 16:47:29.233'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettofinanziamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettofinanziamento','60',null,null,null,'S',{ts '2021-06-17 16:47:29.233'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'progettofinanziamento')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-17 16:47:29.233'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'progettofinanziamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','progettofinanziamento','3',null,null,null,'S',{ts '2021-06-17 16:47:29.233'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettofinanziamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-17 16:47:29.237'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettofinanziamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettofinanziamento','4',null,null,null,'S',{ts '2021-06-17 16:47:29.237'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettofinanziamento' AND tablename = 'progettofinanziamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-17 16:47:29.237'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettofinanziamento' AND tablename = 'progettofinanziamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettofinanziamento','progettofinanziamento','4',null,null,null,'S',{ts '2021-06-17 16:47:29.237'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettofinanziamento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-17 16:47:29.237'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettofinanziamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettofinanziamento','8',null,null,null,'S',{ts '2021-06-17 16:47:29.237'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettofinanziamento')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-17 16:47:29.237'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettofinanziamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettofinanziamento','60',null,null,null,'S',{ts '2021-06-17 16:47:29.237'},'assistenza','N','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

