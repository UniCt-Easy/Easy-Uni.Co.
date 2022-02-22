
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


-- CREAZIONE TABELLA perfprogettoobiettivosoglia --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivosoglia]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogettoobiettivosoglia] (
idperfprogetto int NOT NULL,
idperfprogettoobiettivo int NOT NULL,
idperfprogettoobiettivosoglia int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NULL,
idperfsogliakind varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
percentuale decimal(19,2) NULL,
valorenumerico decimal(19,2) NULL,
 CONSTRAINT xpkperfprogettoobiettivosoglia PRIMARY KEY (idperfprogetto,
idperfprogettoobiettivo,
idperfprogettoobiettivosoglia
)
)
END
GO

-- VERIFICA STRUTTURA perfprogettoobiettivosoglia --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'idperfprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD idperfprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivosoglia') and col.name = 'idperfprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivosoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'idperfprogettoobiettivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD idperfprogettoobiettivo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivosoglia') and col.name = 'idperfprogettoobiettivo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivosoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'idperfprogettoobiettivosoglia' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD idperfprogettoobiettivosoglia int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivosoglia') and col.name = 'idperfprogettoobiettivosoglia' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivosoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivosoglia') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivosoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivosoglia] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivosoglia') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivosoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivosoglia] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivosoglia] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'idperfsogliakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD idperfsogliakind varchar(50) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivosoglia] ALTER COLUMN idperfsogliakind varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivosoglia') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivosoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivosoglia] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivosoglia') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivosoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivosoglia] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'percentuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD percentuale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivosoglia] ALTER COLUMN percentuale decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivosoglia' and C.name = 'valorenumerico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivosoglia] ADD valorenumerico decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivosoglia] ALTER COLUMN valorenumerico decimal(19,2) NULL
GO

-- VERIFICA DI perfprogettoobiettivosoglia IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfprogettoobiettivosoglia'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivosoglia','int','assistenza','idperfprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivosoglia','int','assistenza','idperfprogettoobiettivo','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivosoglia','int','assistenza','idperfprogettoobiettivosoglia','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivosoglia','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivosoglia','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivosoglia','varchar(max)','assistenza','description','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivosoglia','varchar(50)','assistenza','idperfsogliakind','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivosoglia','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivosoglia','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivosoglia','decimal(19,2)','assistenza','percentuale','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivosoglia','decimal(19,2)','assistenza','valorenumerico','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

-- VERIFICA DI perfprogettoobiettivosoglia IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfprogettoobiettivosoglia')
UPDATE customobject set isreal = 'S' where objectname = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfprogettoobiettivosoglia', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfprogettoobiettivosoglia')
UPDATE [tabledescr] SET description = 'Soglie definite per l’obiettivo',idapplication = '2',isdbo = 'S',lt = {ts '2021-09-16 17:19:34.500'},lu = 'Generator',title = 'Soglie definite per l’obiettivo' WHERE tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfprogettoobiettivosoglia','Soglie definite per l’obiettivo','2','S',{ts '2021-09-16 17:19:34.500'},'Generator','Soglie definite per l’obiettivo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-07 15:51:14.160'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfprogettoobiettivosoglia','8',null,null,null,'S',{ts '2021-06-07 15:51:14.160'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-07 15:51:14.160'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfprogettoobiettivosoglia','64',null,null,null,'S',{ts '2021-06-07 15:51:14.160'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-06-07 15:51:59.670'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','perfprogettoobiettivosoglia','-1',null,null,'Descrizione','S',{ts '2021-06-07 15:51:59.670'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogetto' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-07 15:51:14.160'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogetto' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogetto','perfprogettoobiettivosoglia','4',null,null,null,'S',{ts '2021-06-07 15:51:14.160'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogettoobiettivo' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-07 15:51:14.160'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogettoobiettivo' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogettoobiettivo','perfprogettoobiettivosoglia','4',null,null,null,'S',{ts '2021-06-07 15:51:14.160'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogettoobiettivosoglia' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-07 15:51:14.160'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogettoobiettivosoglia' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogettoobiettivosoglia','perfprogettoobiettivosoglia','4',null,null,null,'S',{ts '2021-06-07 15:51:14.160'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfsogliakind' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Soglia',kind = 'S',lt = {ts '2021-06-07 16:50:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfsogliakind' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfsogliakind','perfprogettoobiettivosoglia','50',null,null,'Soglia','S',{ts '2021-06-07 16:50:03.853'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-07 15:51:14.160'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfprogettoobiettivosoglia','8',null,null,null,'S',{ts '2021-06-07 15:51:14.160'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-07 15:51:14.160'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfprogettoobiettivosoglia','64',null,null,null,'S',{ts '2021-06-07 15:51:14.160'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'percentuale' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale',kind = 'S',lt = {ts '2021-06-07 15:51:59.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'percentuale' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('percentuale','perfprogettoobiettivosoglia','9','19','2','Percentuale','S',{ts '2021-06-07 15:51:59.673'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valorenumerico' AND tablename = 'perfprogettoobiettivosoglia')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Valore numerico soglia',kind = 'S',lt = {ts '2021-09-16 17:19:10.523'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'valorenumerico' AND tablename = 'perfprogettoobiettivosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valorenumerico','perfprogettoobiettivosoglia','9','19','2','Valore numerico soglia','S',{ts '2021-09-16 17:19:10.523'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --

