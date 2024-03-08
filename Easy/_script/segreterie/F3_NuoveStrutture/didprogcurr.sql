
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


--[DBO]--
-- CREAZIONE TABELLA didprogcurr --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogcurr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprogcurr] (
iddidprogcurr int NOT NULL,
iddidprog int NOT NULL,
idcorsostudio int NOT NULL,
codice varchar(50) NULL,
codicemiur varchar(50) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(256) NULL,
 CONSTRAINT xpkdidprogcurr PRIMARY KEY (iddidprogcurr,
iddidprog,
idcorsostudio
)
)
END
GO

-- VERIFICA STRUTTURA didprogcurr --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogcurr' and C.name = 'iddidprogcurr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogcurr] ADD iddidprogcurr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogcurr') and col.name = 'iddidprogcurr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogcurr] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogcurr' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogcurr] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogcurr') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogcurr] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogcurr' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogcurr] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogcurr') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogcurr] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogcurr' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogcurr] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [didprogcurr] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogcurr' and C.name = 'codicemiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogcurr] ADD codicemiur varchar(50) NULL 
END
ELSE
	ALTER TABLE [didprogcurr] ALTER COLUMN codicemiur varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogcurr' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogcurr] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogcurr') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogcurr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogcurr] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogcurr' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogcurr] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogcurr') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogcurr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogcurr] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogcurr' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogcurr] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogcurr') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogcurr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogcurr] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogcurr' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogcurr] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogcurr') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogcurr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogcurr] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogcurr' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogcurr] ADD title varchar(256) NULL 
END
ELSE
	ALTER TABLE [didprogcurr] ALTER COLUMN title varchar(256) NULL
GO

-- VERIFICA DI didprogcurr IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'didprogcurr'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogcurr','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogcurr','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogcurr','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogcurr','varchar(50)','ASSISTENZA','codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogcurr','varchar(50)','ASSISTENZA','codicemiur','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogcurr','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogcurr','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogcurr','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogcurr','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogcurr','varchar(256)','ASSISTENZA','title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI didprogcurr IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'didprogcurr')
UPDATE customobject set isreal = 'S' where objectname = 'didprogcurr'
ELSE
INSERT INTO customobject (objectname, isreal) values('didprogcurr', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'didprogcurr')
UPDATE [tabledescr] SET description = '2.4.10 curriculum',idapplication = null,isdbo = 'N',lt = {ts '2018-07-19 17:37:31.307'},lu = 'assistenza',title = 'Curriculum della didattica programmata' WHERE tablename = 'didprogcurr'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('didprogcurr','2.4.10 curriculum',null,'N',{ts '2018-07-19 17:37:31.307'},'assistenza','Curriculum della didattica programmata')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice' AND tablename = 'didprogcurr')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:37:33.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice' AND tablename = 'didprogcurr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice','didprogcurr','50',null,null,null,'S',{ts '2018-07-19 17:37:33.927'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codicemiur' AND tablename = 'didprogcurr')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice MIUR',kind = 'S',lt = {ts '2019-09-11 17:29:05.033'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codicemiur' AND tablename = 'didprogcurr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codicemiur','didprogcurr','50',null,null,'Codice MIUR','S',{ts '2019-09-11 17:29:05.033'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'didprogcurr')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:37:33.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'didprogcurr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','didprogcurr','8',null,null,null,'S',{ts '2018-07-19 17:37:33.927'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'didprogcurr')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:37:33.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'didprogcurr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','didprogcurr','64',null,null,null,'S',{ts '2018-07-19 17:37:33.927'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'didprogcurr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:06:53.033'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'didprogcurr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','didprogcurr','4',null,null,null,'S',{ts '2019-09-23 16:06:53.033'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'didprogcurr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-10 18:03:03.347'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'didprogcurr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','didprogcurr','4',null,null,null,'S',{ts '2019-04-10 18:03:03.347'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogcurr' AND tablename = 'didprogcurr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:37:33.927'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogcurr' AND tablename = 'didprogcurr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogcurr','didprogcurr','4',null,null,null,'S',{ts '2018-07-19 17:37:33.927'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'didprogcurr')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:37:33.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'didprogcurr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','didprogcurr','8',null,null,null,'S',{ts '2018-07-19 17:37:33.927'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'didprogcurr')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:37:33.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'didprogcurr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','didprogcurr','64',null,null,null,'S',{ts '2018-07-19 17:37:33.927'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'didprogcurr')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-09-11 17:29:05.033'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'didprogcurr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','didprogcurr','256',null,null,'Denominazione','S',{ts '2019-09-11 17:29:05.033'},'assistenza','N','varchar(256)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3285')
UPDATE [relation] SET childtable = 'didprogcurr',description = 'didattica che contiene il curriculum',lt = {ts '2018-07-19 17:37:56.607'},lu = 'assistenza',parenttable = 'didprog',title = null WHERE idrelation = '3285'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3285','didprogcurr','didattica che contiene il curriculum',{ts '2018-07-19 17:37:56.607'},'assistenza','didprog',null)
GO

-- FINE GENERAZIONE SCRIPT --

