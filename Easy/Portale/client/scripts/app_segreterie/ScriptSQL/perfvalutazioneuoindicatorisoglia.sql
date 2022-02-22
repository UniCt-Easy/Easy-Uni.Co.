
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


-- CREAZIONE TABELLA perfvalutazioneuoindicatorisoglia --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazioneuoindicatorisoglia]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazioneuoindicatorisoglia] (
idperfvalutazioneuoindicatorisoglia int NOT NULL,
idperfvalutazioneuoindicatori int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NOT NULL,
idperfsogliakind varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
valore decimal(19,2) NOT NULL,
valorenumerico decimal(19,2) NULL,
year int NOT NULL,
 CONSTRAINT xpkperfvalutazioneuoindicatorisoglia PRIMARY KEY (idperfvalutazioneuoindicatorisoglia,
idperfvalutazioneuoindicatori
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazioneuoindicatorisoglia --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'idperfvalutazioneuoindicatorisoglia' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD idperfvalutazioneuoindicatorisoglia int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatorisoglia') and col.name = 'idperfvalutazioneuoindicatorisoglia' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatorisoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'idperfvalutazioneuoindicatori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD idperfvalutazioneuoindicatori int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatorisoglia') and col.name = 'idperfvalutazioneuoindicatori' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatorisoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatorisoglia') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatorisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatorisoglia') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatorisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD description varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatorisoglia') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatorisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ALTER COLUMN description varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'idperfsogliakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD idperfsogliakind varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatorisoglia') and col.name = 'idperfsogliakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatorisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ALTER COLUMN idperfsogliakind varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatorisoglia') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatorisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatorisoglia') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatorisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'valore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD valore decimal(19,2) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatorisoglia') and col.name = 'valore' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatorisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ALTER COLUMN valore decimal(19,2) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'valorenumerico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD valorenumerico decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ALTER COLUMN valorenumerico decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatorisoglia' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatorisoglia') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatorisoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatorisoglia] ALTER COLUMN year int NOT NULL
GO

-- VERIFICA DI perfvalutazioneuoindicatorisoglia IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfvalutazioneuoindicatorisoglia'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuoindicatorisoglia','int','assistenza','idperfvalutazioneuoindicatori','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuoindicatorisoglia','int','assistenza','idperfvalutazioneuoindicatorisoglia','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuoindicatorisoglia','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuoindicatorisoglia','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuoindicatorisoglia','varchar(max)','assistenza','description','-1','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuoindicatorisoglia','varchar(50)','assistenza','idperfsogliakind','50','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuoindicatorisoglia','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuoindicatorisoglia','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuoindicatorisoglia','decimal(19,2)','assistenza','valore','9','S','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuoindicatorisoglia','decimal(19,2)','assistenza','valorenumerico','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuoindicatorisoglia','int','assistenza','year','4','S','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI perfvalutazioneuoindicatorisoglia IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfvalutazioneuoindicatorisoglia')
UPDATE customobject set isreal = 'S' where objectname = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfvalutazioneuoindicatorisoglia', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [tabledescr] SET description = 'Soglie',idapplication = '2',isdbo = 'S',lt = {ts '2021-09-08 10:07:33.443'},lu = 'Generator',title = 'Soglie' WHERE tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfvalutazioneuoindicatorisoglia','Soglie','2','S',{ts '2021-09-08 10:07:33.443'},'Generator','Soglie')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-08 10:07:33.447'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfvalutazioneuoindicatorisoglia','8',null,null,'','S',{ts '2021-09-08 10:07:33.447'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-08 10:07:33.447'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfvalutazioneuoindicatorisoglia','64',null,null,'','S',{ts '2021-09-08 10:07:33.447'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-09-14 09:14:42.320'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','perfvalutazioneuoindicatorisoglia','-1',null,null,'Descrizione','S',{ts '2021-09-14 09:14:42.320'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfsogliakind' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2021-09-14 09:14:42.323'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfsogliakind' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfsogliakind','perfvalutazioneuoindicatorisoglia','50',null,null,'Tipo','S',{ts '2021-09-14 09:14:42.323'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazioneuoindicatori' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-08 10:07:33.447'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazioneuoindicatori' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazioneuoindicatori','perfvalutazioneuoindicatorisoglia','4',null,null,'','S',{ts '2021-09-08 10:07:33.447'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazioneuoindicatorisoglia' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-09-13 12:59:46.937'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazioneuoindicatorisoglia' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazioneuoindicatorisoglia','perfvalutazioneuoindicatorisoglia','4',null,null,null,'S',{ts '2021-09-13 12:59:46.937'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-08 10:07:33.447'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfvalutazioneuoindicatorisoglia','8',null,null,'','S',{ts '2021-09-08 10:07:33.447'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-08 10:07:33.447'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfvalutazioneuoindicatorisoglia','64',null,null,'','S',{ts '2021-09-08 10:07:33.447'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valore' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Valore Percentuale',kind = 'S',lt = {ts '2021-09-14 09:14:42.323'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'valore' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valore','perfvalutazioneuoindicatorisoglia','9','19','2','Valore Percentuale','S',{ts '2021-09-14 09:14:42.323'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valorenumerico' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Valore numerico soglia',kind = 'S',lt = {ts '2021-09-14 09:19:11.410'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'valorenumerico' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valorenumerico','perfvalutazioneuoindicatorisoglia','9','19','2','Valore numerico soglia','S',{ts '2021-09-14 09:19:11.410'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'perfvalutazioneuoindicatorisoglia')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno',kind = 'S',lt = {ts '2021-09-14 09:14:42.323'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'perfvalutazioneuoindicatorisoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','perfvalutazioneuoindicatorisoglia','4',null,null,'Anno','S',{ts '2021-09-14 09:14:42.323'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

