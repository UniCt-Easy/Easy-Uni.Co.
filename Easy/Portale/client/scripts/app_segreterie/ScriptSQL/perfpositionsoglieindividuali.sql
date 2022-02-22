
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


-- CREAZIONE TABELLA perfpositionsoglieindividuali --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfpositionsoglieindividuali]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfpositionsoglieindividuali] (
idperfpositionsoglieindividuali int NOT NULL,
idmansionekind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idperfsogliakind varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
valore decimal(19,2) NULL,
year int NULL,
 CONSTRAINT xpkperfpositionsoglieindividuali PRIMARY KEY (idperfpositionsoglieindividuali,
idmansionekind
)
)
END
GO

-- VERIFICA STRUTTURA perfpositionsoglieindividuali --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfpositionsoglieindividuali' and C.name = 'idperfpositionsoglieindividuali' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfpositionsoglieindividuali] ADD idperfpositionsoglieindividuali int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfpositionsoglieindividuali') and col.name = 'idperfpositionsoglieindividuali' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfpositionsoglieindividuali] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfpositionsoglieindividuali' and C.name = 'idmansionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfpositionsoglieindividuali] ADD idmansionekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfpositionsoglieindividuali') and col.name = 'idmansionekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfpositionsoglieindividuali] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfpositionsoglieindividuali' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfpositionsoglieindividuali] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfpositionsoglieindividuali') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfpositionsoglieindividuali] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfpositionsoglieindividuali] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfpositionsoglieindividuali' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfpositionsoglieindividuali] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfpositionsoglieindividuali') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfpositionsoglieindividuali] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfpositionsoglieindividuali] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfpositionsoglieindividuali' and C.name = 'idperfsogliakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfpositionsoglieindividuali] ADD idperfsogliakind varchar(50) NULL 
END
ELSE
	ALTER TABLE [perfpositionsoglieindividuali] ALTER COLUMN idperfsogliakind varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfpositionsoglieindividuali' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfpositionsoglieindividuali] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfpositionsoglieindividuali') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfpositionsoglieindividuali] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfpositionsoglieindividuali] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfpositionsoglieindividuali' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfpositionsoglieindividuali] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfpositionsoglieindividuali') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfpositionsoglieindividuali] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfpositionsoglieindividuali] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfpositionsoglieindividuali' and C.name = 'valore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfpositionsoglieindividuali] ADD valore decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfpositionsoglieindividuali] ALTER COLUMN valore decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfpositionsoglieindividuali' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfpositionsoglieindividuali] ADD year int NULL 
END
ELSE
	ALTER TABLE [perfpositionsoglieindividuali] ALTER COLUMN year int NULL
GO

-- VERIFICA DI perfpositionsoglieindividuali IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfpositionsoglieindividuali'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfpositionsoglieindividuali','int','assistenza','idmansionekind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfpositionsoglieindividuali','int','assistenza','idperfpositionsoglieindividuali','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfpositionsoglieindividuali','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfpositionsoglieindividuali','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfpositionsoglieindividuali','varchar(50)','assistenza','idperfsogliakind','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfpositionsoglieindividuali','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfpositionsoglieindividuali','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfpositionsoglieindividuali','decimal(19,2)','assistenza','valore','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfpositionsoglieindividuali','int','assistenza','year','4','N','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI perfpositionsoglieindividuali IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfpositionsoglieindividuali')
UPDATE customobject set isreal = 'S' where objectname = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfpositionsoglieindividuali', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfpositionsoglieindividuali')
UPDATE [tabledescr] SET description = null,idapplication = null,isdbo = 'N',lt = {ts '2021-05-21 11:51:45.080'},lu = 'assistenza',title = 'Soglie degli obiettivi individuali' WHERE tablename = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfpositionsoglieindividuali',null,null,'N',{ts '2021-05-21 11:51:45.080'},'assistenza','Soglie degli obiettivi individuali')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfpositionsoglieindividuali')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 16:11:24.560'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfpositionsoglieindividuali','8',null,null,null,'S',{ts '2021-05-21 16:11:24.560'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfpositionsoglieindividuali')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 11:51:48.317'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfpositionsoglieindividuali','64',null,null,null,'S',{ts '2021-05-21 11:51:48.317'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmansionekind' AND tablename = 'perfpositionsoglieindividuali')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-10-04 11:07:00.650'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idmansionekind' AND tablename = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmansionekind','perfpositionsoglieindividuali','4',null,null,null,'S',{ts '2021-10-04 11:07:00.650'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfpositionsoglieindividuali' AND tablename = 'perfpositionsoglieindividuali')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 11:51:48.317'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfpositionsoglieindividuali' AND tablename = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfpositionsoglieindividuali','perfpositionsoglieindividuali','4',null,null,null,'S',{ts '2021-05-21 11:51:48.317'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfsogliakind' AND tablename = 'perfpositionsoglieindividuali')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2021-05-21 15:46:28.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfsogliakind' AND tablename = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfsogliakind','perfpositionsoglieindividuali','50',null,null,'Tipo','S',{ts '2021-05-21 15:46:28.927'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfpositionsoglieindividuali')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 16:11:24.560'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfpositionsoglieindividuali','8',null,null,null,'S',{ts '2021-05-21 16:11:24.560'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfpositionsoglieindividuali')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 11:51:48.317'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfpositionsoglieindividuali','64',null,null,null,'S',{ts '2021-05-21 11:51:48.317'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valore' AND tablename = 'perfpositionsoglieindividuali')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Valore % soglia',kind = 'S',lt = {ts '2021-05-21 11:52:23.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'valore' AND tablename = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valore','perfpositionsoglieindividuali','9','19','2','Valore % soglia','S',{ts '2021-05-21 11:52:23.493'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'perfpositionsoglieindividuali')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno solare',kind = 'S',lt = {ts '2021-05-21 11:52:13.123'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'perfpositionsoglieindividuali'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','perfpositionsoglieindividuali','4',null,null,'Anno solare','S',{ts '2021-05-21 11:52:13.123'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

