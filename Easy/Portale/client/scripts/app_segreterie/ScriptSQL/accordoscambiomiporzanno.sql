
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


-- CREAZIONE TABELLA accordoscambiomiporzanno --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accordoscambiomiporzanno]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accordoscambiomiporzanno] (
idaccordoscambiomiporzanno int NOT NULL,
iddidprogporzannokind int NOT NULL,
idaccordoscambiomidett int NOT NULL,
idaccordoscambiomi int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
indice int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkaccordoscambiomiporzanno PRIMARY KEY (idaccordoscambiomiporzanno,
iddidprogporzannokind,
idaccordoscambiomidett,
idaccordoscambiomi
)
)
END
GO

-- VERIFICA STRUTTURA accordoscambiomiporzanno --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomiporzanno' and C.name = 'idaccordoscambiomiporzanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomiporzanno] ADD idaccordoscambiomiporzanno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomiporzanno') and col.name = 'idaccordoscambiomiporzanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomiporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomiporzanno' and C.name = 'iddidprogporzannokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomiporzanno] ADD iddidprogporzannokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomiporzanno') and col.name = 'iddidprogporzannokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomiporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomiporzanno' and C.name = 'idaccordoscambiomidett' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomiporzanno] ADD idaccordoscambiomidett int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomiporzanno') and col.name = 'idaccordoscambiomidett' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomiporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomiporzanno' and C.name = 'idaccordoscambiomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomiporzanno] ADD idaccordoscambiomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomiporzanno') and col.name = 'idaccordoscambiomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomiporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomiporzanno' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomiporzanno] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomiporzanno') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomiporzanno] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomiporzanno] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomiporzanno' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomiporzanno] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomiporzanno') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomiporzanno] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomiporzanno] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomiporzanno' and C.name = 'indice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomiporzanno] ADD indice int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomiporzanno] ALTER COLUMN indice int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomiporzanno' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomiporzanno] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomiporzanno') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomiporzanno] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomiporzanno] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomiporzanno' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomiporzanno] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomiporzanno') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomiporzanno] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomiporzanno] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI accordoscambiomiporzanno IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accordoscambiomiporzanno'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomiporzanno','int','assistenza','idaccordoscambiomi','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomiporzanno','int','assistenza','idaccordoscambiomidett','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomiporzanno','int','assistenza','idaccordoscambiomiporzanno','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomiporzanno','int','assistenza','iddidprogporzannokind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomiporzanno','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomiporzanno','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomiporzanno','int','assistenza','indice','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomiporzanno','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomiporzanno','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI accordoscambiomiporzanno IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accordoscambiomiporzanno')
UPDATE customobject set isreal = 'S' where objectname = 'accordoscambiomiporzanno'
ELSE
INSERT INTO customobject (objectname, isreal) values('accordoscambiomiporzanno', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'accordoscambiomiporzanno')
UPDATE [tabledescr] SET description = 'Periodi didattici dell’2.5.16 Accordo Bilaterale per la mobilità internazionale / Programma di scambio
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 10:35:15.083'},lu = 'assistenza',title = 'Periodi didattici dell’accordo Bilaterale per la mobilità internazionale / Programma di scamb' WHERE tablename = 'accordoscambiomiporzanno'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('accordoscambiomiporzanno','Periodi didattici dell’2.5.16 Accordo Bilaterale per la mobilità internazionale / Programma di scambio
',null,'N',{ts '2018-07-27 10:35:15.083'},'assistenza','Periodi didattici dell’accordo Bilaterale per la mobilità internazionale / Programma di scamb')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'accordoscambiomiporzanno')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:34:25.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'accordoscambiomiporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','accordoscambiomiporzanno','8',null,null,null,'S',{ts '2018-07-27 10:34:25.377'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'accordoscambiomiporzanno')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:34:25.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'accordoscambiomiporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','accordoscambiomiporzanno','64',null,null,null,'S',{ts '2018-07-27 10:34:25.377'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomi' AND tablename = 'accordoscambiomiporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-21 16:04:56.677'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomi' AND tablename = 'accordoscambiomiporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomi','accordoscambiomiporzanno','4',null,null,null,'S',{ts '2020-09-21 16:04:56.677'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomidett' AND tablename = 'accordoscambiomiporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-21 16:04:56.677'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomidett' AND tablename = 'accordoscambiomiporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomidett','accordoscambiomiporzanno','4',null,null,null,'S',{ts '2020-09-21 16:04:56.677'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomiporzanno' AND tablename = 'accordoscambiomiporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:34:25.377'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomiporzanno' AND tablename = 'accordoscambiomiporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomiporzanno','accordoscambiomiporzanno','4',null,null,null,'S',{ts '2018-07-27 10:34:25.377'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogporzannokind' AND tablename = 'accordoscambiomiporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:34:25.377'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogporzannokind' AND tablename = 'accordoscambiomiporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogporzannokind','accordoscambiomiporzanno','4',null,null,null,'S',{ts '2018-07-27 10:34:25.377'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indice' AND tablename = 'accordoscambiomiporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:34:25.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indice' AND tablename = 'accordoscambiomiporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indice','accordoscambiomiporzanno','4',null,null,null,'S',{ts '2018-07-27 10:34:25.377'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'accordoscambiomiporzanno')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:34:25.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'accordoscambiomiporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','accordoscambiomiporzanno','8',null,null,null,'S',{ts '2018-07-27 10:34:25.377'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'accordoscambiomiporzanno')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:34:25.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'accordoscambiomiporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','accordoscambiomiporzanno','64',null,null,null,'S',{ts '2018-07-27 10:34:25.377'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3356')
UPDATE [relation] SET childtable = 'accordoscambiomiporzanno',description = 'accordo di cui inidicano il periodo
',lt = {ts '2018-07-27 10:35:07.193'},lu = 'assistenza',parenttable = 'accordoscambiomi',title = null WHERE idrelation = '3356'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3356','accordoscambiomiporzanno','accordo di cui inidicano il periodo
',{ts '2018-07-27 10:35:07.193'},'assistenza','accordoscambiomi',null)
GO

-- FINE GENERAZIONE SCRIPT --

