
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


-- CREAZIONE TABELLA progettotipocostotax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotipocostotax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotipocostotax] (
idprogettotipocosto int NOT NULL,
taxcode int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprogettotipocostotax PRIMARY KEY (idprogettotipocosto,
taxcode,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettotipocostotax --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD idprogettotipocosto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostotax') and col.name = 'idprogettotipocosto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostotax] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD taxcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostotax') and col.name = 'taxcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostotax] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostotax') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostotax] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostotax] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostotax] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostotax] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostotax' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostotax] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostotax] ALTER COLUMN lu varchar(64) NULL
GO

-- VERIFICA DI progettotipocostotax IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettotipocostotax'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotipocostotax','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotipocostotax','int','ASSISTENZA','idprogettotipocosto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotipocostotax','int','ASSISTENZA','taxcode','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocostotax','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocostotax','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocostotax','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocostotax','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettotipocostotax IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettotipocostotax')
UPDATE customobject set isreal = 'S' where objectname = 'progettotipocostotax'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettotipocostotax', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotipocostotax')
UPDATE [tabledescr] SET description = 'Tipi di ritenuta associati alla voce di costo della attivit? o progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-06-18 18:32:03.350'},lu = 'assistenza',title = 'Tipi di ritenuta associati' WHERE tablename = 'progettotipocostotax'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotipocostotax','Tipi di ritenuta associati alla voce di costo della attivit? o progetto',null,'N',{ts '2020-06-18 18:32:03.350'},'assistenza','Tipi di ritenuta associati')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotipocostotax','8',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotipocostotax','64',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettotipocostotax','4',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocosto' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocosto' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocosto','progettotipocostotax','4',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotipocostotax','8',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotipocostotax','64',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxcode' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipi di ritenuta',kind = 'S',lt = {ts '2020-06-18 18:32:23.803'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'taxcode' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxcode','progettotipocostotax','4',null,null,'Tipi di ritenuta','S',{ts '2020-06-18 18:32:23.803'},'assistenza','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

