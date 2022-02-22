
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
-- CREAZIONE TABELLA tassacsingconf --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tassacsingconf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tassacsingconf] (
idtassacsingconf int NOT NULL,
aa varchar(9) NULL,
costomax decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idcostoscontodef int NULL,
idcostoscontodef_2 int NULL,
idcostoscontodef_sconto int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
numerosconto int NULL,
 CONSTRAINT xpktassacsingconf PRIMARY KEY (idtassacsingconf
)
)
END
GO

-- VERIFICA STRUTTURA tassacsingconf --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'idtassacsingconf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD idtassacsingconf int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassacsingconf') and col.name = 'idtassacsingconf' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassacsingconf] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD aa varchar(9) NULL 
END
ELSE
	ALTER TABLE [tassacsingconf] ALTER COLUMN aa varchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'costomax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD costomax decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [tassacsingconf] ALTER COLUMN costomax decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassacsingconf') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassacsingconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassacsingconf] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassacsingconf') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassacsingconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassacsingconf] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'idcostoscontodef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD idcostoscontodef int NULL 
END
ELSE
	ALTER TABLE [tassacsingconf] ALTER COLUMN idcostoscontodef int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'idcostoscontodef_2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD idcostoscontodef_2 int NULL 
END
ELSE
	ALTER TABLE [tassacsingconf] ALTER COLUMN idcostoscontodef_2 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'idcostoscontodef_sconto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD idcostoscontodef_sconto int NULL 
END
ELSE
	ALTER TABLE [tassacsingconf] ALTER COLUMN idcostoscontodef_sconto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassacsingconf') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassacsingconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassacsingconf] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassacsingconf') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassacsingconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassacsingconf] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassacsingconf' and C.name = 'numerosconto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassacsingconf] ADD numerosconto int NULL 
END
ELSE
	ALTER TABLE [tassacsingconf] ALTER COLUMN numerosconto int NULL
GO

-- VERIFICA DI tassacsingconf IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tassacsingconf'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconf','int','ASSISTENZA','idtassacsingconf','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconf','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconf','decimal(9,2)','ASSISTENZA','costomax','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconf','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconf','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconf','int','ASSISTENZA','idcostoscontodef','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconf','int','ASSISTENZA','idcostoscontodef_2','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconf','int','ASSISTENZA','idcostoscontodef_sconto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconf','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassacsingconf','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassacsingconf','int','ASSISTENZA','numerosconto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tassacsingconf IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tassacsingconf')
UPDATE customobject set isreal = 'S' where objectname = 'tassacsingconf'
ELSE
INSERT INTO customobject (objectname, isreal) values('tassacsingconf', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tassacsingconf')
UPDATE [tabledescr] SET description = '3.4.9 Configurazione delle tasse 3.4.9.3 Inserimento per le iscrizioni a corsi singoli
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 17:42:23.137'},lu = 'assistenza',title = 'Configurazione delle tasse -Inserimento per le iscrizioni a corsi singoli' WHERE tablename = 'tassacsingconf'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tassacsingconf','3.4.9 Configurazione delle tasse 3.4.9.3 Inserimento per le iscrizioni a corsi singoli
',null,'N',{ts '2018-07-27 17:42:23.137'},'assistenza','Configurazione delle tasse -Inserimento per le iscrizioni a corsi singoli')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico',kind = 'S',lt = {ts '2020-01-07 12:12:27.670'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','tassacsingconf','9',null,null,'Anno accademico','S',{ts '2020-01-07 12:12:27.670'},'assistenza','N','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costomax' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Costo massimo',kind = 'S',lt = {ts '2020-01-07 12:12:27.670'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costomax' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costomax','tassacsingconf','5','9','2','Costo massimo','S',{ts '2020-01-07 12:12:27.670'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:42:25.933'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tassacsingconf','8',null,null,null,'S',{ts '2018-07-27 17:42:25.933'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:42:25.933'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tassacsingconf','64',null,null,null,'S',{ts '2018-07-27 17:42:25.933'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcostoscontodef' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Costo',kind = 'S',lt = {ts '2020-01-07 12:12:27.670'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcostoscontodef' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcostoscontodef','tassacsingconf','4',null,null,'Costo','S',{ts '2020-01-07 12:12:27.670'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcostoscontodef_2' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Costo corsi speciali',kind = 'S',lt = {ts '2020-01-07 12:12:27.670'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcostoscontodef_2' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcostoscontodef_2','tassacsingconf','4',null,null,'Costo corsi speciali','S',{ts '2020-01-07 12:12:27.670'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcostoscontodef_sconto' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sconto',kind = 'S',lt = {ts '2020-01-07 12:12:27.670'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcostoscontodef_sconto' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcostoscontodef_sconto','tassacsingconf','4',null,null,'Sconto','S',{ts '2020-01-07 12:12:27.670'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtassacsingconf' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:42:25.937'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtassacsingconf' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtassacsingconf','tassacsingconf','4',null,null,null,'S',{ts '2018-07-27 17:42:25.937'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:42:25.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tassacsingconf','8',null,null,null,'S',{ts '2018-07-27 17:42:25.937'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:42:25.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tassacsingconf','64',null,null,null,'S',{ts '2018-07-27 17:42:25.937'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numerosconto' AND tablename = 'tassacsingconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di insegnamenti per cui si applica lo sconto',kind = 'S',lt = {ts '2020-01-07 12:12:27.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numerosconto' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numerosconto','tassacsingconf','4',null,null,'Numero di insegnamenti per cui si applica lo sconto','S',{ts '2020-01-07 12:12:27.673'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

