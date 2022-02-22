
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


-- CREAZIONE TABELLA progettotiporicavokindcontrattokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettotiporicavokindcontrattokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettotiporicavokindcontrattokind] (
idprogettotipocostokind int NOT NULL,
idcontrattokind int NOT NULL,
idprogettokind int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprogettotiporicavokindcontrattokind PRIMARY KEY (idprogettotipocostokind,
idcontrattokind,
idprogettokind
)
)
END
GO

-- VERIFICA STRUTTURA progettotiporicavokindcontrattokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindcontrattokind' and C.name = 'idprogettotipocostokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindcontrattokind] ADD idprogettotipocostokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotiporicavokindcontrattokind') and col.name = 'idprogettotipocostokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotiporicavokindcontrattokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindcontrattokind' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindcontrattokind] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotiporicavokindcontrattokind') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotiporicavokindcontrattokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindcontrattokind' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindcontrattokind] ADD idprogettokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotiporicavokindcontrattokind') and col.name = 'idprogettokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotiporicavokindcontrattokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindcontrattokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindcontrattokind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotiporicavokindcontrattokind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindcontrattokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindcontrattokind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotiporicavokindcontrattokind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindcontrattokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindcontrattokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotiporicavokindcontrattokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotiporicavokindcontrattokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotiporicavokindcontrattokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotiporicavokindcontrattokind] ALTER COLUMN lu varchar(64) NULL
GO

-- VERIFICA DI progettotiporicavokindcontrattokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettotiporicavokindcontrattokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotiporicavokindcontrattokind','int','Generator','idcontrattokind','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotiporicavokindcontrattokind','int','Generator','idprogettokind','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotiporicavokindcontrattokind','int','Generator','idprogettotipocostokind','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotiporicavokindcontrattokind','datetime','Generator','ct','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotiporicavokindcontrattokind','varchar(64)','Generator','cu','64','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotiporicavokindcontrattokind','datetime','Generator','lt','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotiporicavokindcontrattokind','varchar(64)','Generator','lu','64','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI progettotiporicavokindcontrattokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettotiporicavokindcontrattokind')
UPDATE customobject set isreal = 'S' where objectname = 'progettotiporicavokindcontrattokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettotiporicavokindcontrattokind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotiporicavokindcontrattokind')
UPDATE [tabledescr] SET description = 'Tipi di contratto associati come ricavo',idapplication = '2',isdbo = 'S',lt = {ts '2021-11-05 14:55:27.743'},lu = 'Generator',title = 'Tipi di contratto associati come ricavo' WHERE tablename = 'progettotiporicavokindcontrattokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotiporicavokindcontrattokind','Tipi di contratto associati come ricavo','2','S',{ts '2021-11-05 14:55:27.743'},'Generator','Tipi di contratto associati come ricavo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotiporicavokindcontrattokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-05 13:01:11.523'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotiporicavokindcontrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotiporicavokindcontrattokind','8',null,null,'','S',{ts '2021-11-05 13:01:11.523'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotiporicavokindcontrattokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-05 13:01:11.523'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotiporicavokindcontrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotiporicavokindcontrattokind','64',null,null,'','S',{ts '2021-11-05 13:01:11.523'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'progettotiporicavokindcontrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-05 13:01:11.523'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'progettotiporicavokindcontrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','progettotiporicavokindcontrattokind','4',null,null,'','S',{ts '2021-11-05 13:01:11.523'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progettotiporicavokindcontrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-05 13:01:11.523'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progettotiporicavokindcontrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progettotiporicavokindcontrattokind','4',null,null,'','S',{ts '2021-11-05 13:01:11.523'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocostokind' AND tablename = 'progettotiporicavokindcontrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-05 13:01:11.523'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocostokind' AND tablename = 'progettotiporicavokindcontrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocostokind','progettotiporicavokindcontrattokind','4',null,null,'','S',{ts '2021-11-05 13:01:11.523'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotiporicavokindcontrattokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-05 13:01:11.523'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotiporicavokindcontrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotiporicavokindcontrattokind','8',null,null,'','S',{ts '2021-11-05 13:01:11.523'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotiporicavokindcontrattokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-05 13:01:11.523'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotiporicavokindcontrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotiporicavokindcontrattokind','64',null,null,'','S',{ts '2021-11-05 13:01:11.523'},'Generator','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

