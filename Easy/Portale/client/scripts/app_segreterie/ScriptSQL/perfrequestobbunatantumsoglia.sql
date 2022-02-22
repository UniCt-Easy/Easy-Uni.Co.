
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


-- CREAZIONE TABELLA perfrequestobbunatantumsoglia --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfrequestobbunatantumsoglia]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfrequestobbunatantumsoglia] (
idperfrequestobbunatantum int NOT NULL,
idperfrequestobbunatantumsoglia int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idperfsogliakind varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
percentuale decimal(19,2) NULL,
valorenumerico decimal(19,2) NULL,
 CONSTRAINT xpkperfrequestobbunatantumsoglia PRIMARY KEY (idperfrequestobbunatantum,
idperfrequestobbunatantumsoglia
)
)
END
GO

-- VERIFICA STRUTTURA perfrequestobbunatantumsoglia --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantumsoglia' and C.name = 'idperfrequestobbunatantum' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantumsoglia] ADD idperfrequestobbunatantum int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantumsoglia') and col.name = 'idperfrequestobbunatantum' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantumsoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantumsoglia' and C.name = 'idperfrequestobbunatantumsoglia' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantumsoglia] ADD idperfrequestobbunatantumsoglia int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantumsoglia') and col.name = 'idperfrequestobbunatantumsoglia' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantumsoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantumsoglia' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantumsoglia] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantumsoglia') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantumsoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfrequestobbunatantumsoglia] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantumsoglia' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantumsoglia] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantumsoglia') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantumsoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfrequestobbunatantumsoglia] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantumsoglia' and C.name = 'idperfsogliakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantumsoglia] ADD idperfsogliakind varchar(50) NULL 
END
ELSE
	ALTER TABLE [perfrequestobbunatantumsoglia] ALTER COLUMN idperfsogliakind varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantumsoglia' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantumsoglia] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantumsoglia') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantumsoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfrequestobbunatantumsoglia] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantumsoglia' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantumsoglia] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfrequestobbunatantumsoglia') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfrequestobbunatantumsoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfrequestobbunatantumsoglia] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantumsoglia' and C.name = 'percentuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantumsoglia] ADD percentuale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfrequestobbunatantumsoglia] ALTER COLUMN percentuale decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfrequestobbunatantumsoglia' and C.name = 'valorenumerico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfrequestobbunatantumsoglia] ADD valorenumerico decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfrequestobbunatantumsoglia] ALTER COLUMN valorenumerico decimal(19,2) NULL
GO

-- VERIFICA DI perfrequestobbunatantumsoglia IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfrequestobbunatantumsoglia'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','int','Generator','idperfrequestobbunatantum','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','int','Generator','idperfrequestobbunatantumsoglia','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','datetime','Generator','ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','varchar(64)','Generator','cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbunatantumsoglia','varchar(50)','Generator','idperfsogliakind','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','datetime','Generator','lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfrequestobbunatantumsoglia','varchar(64)','Generator','lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbunatantumsoglia','decimal(19,2)','Generator','percentuale','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfrequestobbunatantumsoglia','decimal(19,2)','Generator','valorenumerico','9','N','decimal','System.Decimal','','2','','19','N')
GO

-- VERIFICA DI perfrequestobbunatantumsoglia IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfrequestobbunatantumsoglia')
UPDATE customobject set isreal = 'S' where objectname = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfrequestobbunatantumsoglia', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfrequestobbunatantumsoglia')
UPDATE [tabledescr] SET description = 'Soglie',idapplication = '2',isdbo = 'S',lt = {ts '2021-10-05 13:01:36.290'},lu = 'Generator',title = 'Soglie' WHERE tablename = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfrequestobbunatantumsoglia','Soglie','2','S',{ts '2021-10-05 13:01:36.290'},'Generator','Soglie')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfrequestobbunatantumsoglia')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 13:01:36.290'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfrequestobbunatantumsoglia','8',null,null,'','S',{ts '2021-10-05 13:01:36.290'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfrequestobbunatantumsoglia')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 13:01:36.290'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfrequestobbunatantumsoglia','64',null,null,'','S',{ts '2021-10-05 13:01:36.290'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfrequestobbunatantum' AND tablename = 'perfrequestobbunatantumsoglia')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 13:01:36.290'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfrequestobbunatantum' AND tablename = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfrequestobbunatantum','perfrequestobbunatantumsoglia','4',null,null,'','S',{ts '2021-10-05 13:01:36.290'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfrequestobbunatantumsoglia' AND tablename = 'perfrequestobbunatantumsoglia')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 13:01:36.290'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfrequestobbunatantumsoglia' AND tablename = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfrequestobbunatantumsoglia','perfrequestobbunatantumsoglia','4',null,null,'','S',{ts '2021-10-05 13:01:36.290'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfsogliakind' AND tablename = 'perfrequestobbunatantumsoglia')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 13:01:36.290'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfsogliakind' AND tablename = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfsogliakind','perfrequestobbunatantumsoglia','50',null,null,'','S',{ts '2021-10-05 13:01:36.290'},'Generator','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfrequestobbunatantumsoglia')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 13:01:36.290'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfrequestobbunatantumsoglia','8',null,null,'','S',{ts '2021-10-05 13:01:36.290'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfrequestobbunatantumsoglia')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 13:01:36.290'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfrequestobbunatantumsoglia','64',null,null,'','S',{ts '2021-10-05 13:01:36.290'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'percentuale' AND tablename = 'perfrequestobbunatantumsoglia')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-05 13:01:36.290'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'percentuale' AND tablename = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('percentuale','perfrequestobbunatantumsoglia','9','19','2','','S',{ts '2021-10-05 13:01:36.290'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valorenumerico' AND tablename = 'perfrequestobbunatantumsoglia')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-05 13:01:36.290'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'valorenumerico' AND tablename = 'perfrequestobbunatantumsoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valorenumerico','perfrequestobbunatantumsoglia','9','19','2','','S',{ts '2021-10-05 13:01:36.290'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --

