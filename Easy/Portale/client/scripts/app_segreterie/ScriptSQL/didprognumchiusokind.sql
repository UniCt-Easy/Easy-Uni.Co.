
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


-- CREAZIONE TABELLA didprognumchiusokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprognumchiusokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprognumchiusokind] (
iddidprognumchiusokind int NOT NULL,
active char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkdidprognumchiusokind PRIMARY KEY (iddidprognumchiusokind
)
)
END
GO

-- VERIFICA STRUTTURA didprognumchiusokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprognumchiusokind' and C.name = 'iddidprognumchiusokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprognumchiusokind] ADD iddidprognumchiusokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprognumchiusokind') and col.name = 'iddidprognumchiusokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprognumchiusokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprognumchiusokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprognumchiusokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprognumchiusokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprognumchiusokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprognumchiusokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprognumchiusokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprognumchiusokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprognumchiusokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprognumchiusokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprognumchiusokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprognumchiusokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprognumchiusokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprognumchiusokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprognumchiusokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprognumchiusokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprognumchiusokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprognumchiusokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprognumchiusokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprognumchiusokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprognumchiusokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprognumchiusokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprognumchiusokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprognumchiusokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprognumchiusokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprognumchiusokind] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI didprognumchiusokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'didprognumchiusokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprognumchiusokind','int','assistenza','iddidprognumchiusokind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprognumchiusokind','char(1)','assistenza','active','1','S','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprognumchiusokind','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprognumchiusokind','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprognumchiusokind','int','assistenza','sortcode','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprognumchiusokind','varchar(50)','assistenza','title','50','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI didprognumchiusokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'didprognumchiusokind')
UPDATE customobject set isreal = 'S' where objectname = 'didprognumchiusokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('didprognumchiusokind', 'S')
GO

-- GENERAZIONE DATI PER didprognumchiusokind --
IF exists(SELECT * FROM [didprognumchiusokind] WHERE iddidprognumchiusokind = '1')
UPDATE [didprognumchiusokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'No' WHERE iddidprognumchiusokind = '1'
ELSE
INSERT INTO [didprognumchiusokind] (iddidprognumchiusokind,active,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','No')
GO

IF exists(SELECT * FROM [didprognumchiusokind] WHERE iddidprognumchiusokind = '2')
UPDATE [didprognumchiusokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Locale' WHERE iddidprognumchiusokind = '2'
ELSE
INSERT INTO [didprognumchiusokind] (iddidprognumchiusokind,active,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Locale')
GO

IF exists(SELECT * FROM [didprognumchiusokind] WHERE iddidprognumchiusokind = '3')
UPDATE [didprognumchiusokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Nazionale' WHERE iddidprognumchiusokind = '3'
ELSE
INSERT INTO [didprognumchiusokind] (iddidprognumchiusokind,active,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Nazionale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'didprognumchiusokind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO delle tipologie di accesso alla 2.4.1 Didattica programmata / Ordinamento didattico / Regolamento del corso di studi',idapplication = '2',isdbo = 'S',lt = {ts '2022-01-11 12:25:54.670'},lu = 'Generator',title = 'VOCABOLARIO delle tipologie di accesso alla Didattica programmata / Ordinamento didattico / Re' WHERE tablename = 'didprognumchiusokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('didprognumchiusokind','VOCABOLARIO delle tipologie di accesso alla 2.4.1 Didattica programmata / Ordinamento didattico / Regolamento del corso di studi','2','S',{ts '2022-01-11 12:25:54.670'},'Generator','VOCABOLARIO delle tipologie di accesso alla Didattica programmata / Ordinamento didattico / Re')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'didprognumchiusokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:11:11.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'didprognumchiusokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','didprognumchiusokind','1',null,null,null,'S',{ts '2018-07-19 15:11:11.733'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprognumchiusokind' AND tablename = 'didprognumchiusokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:11:11.733'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprognumchiusokind' AND tablename = 'didprognumchiusokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprognumchiusokind','didprognumchiusokind','4',null,null,null,'S',{ts '2018-07-19 15:11:11.733'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'didprognumchiusokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:11:11.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'didprognumchiusokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','didprognumchiusokind','8',null,null,null,'S',{ts '2018-07-19 15:11:11.733'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'didprognumchiusokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:11:11.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'didprognumchiusokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','didprognumchiusokind','64',null,null,null,'S',{ts '2018-07-19 15:11:11.733'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'didprognumchiusokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:11:11.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'didprognumchiusokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','didprognumchiusokind','4',null,null,null,'S',{ts '2018-07-19 15:11:11.733'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'didprognumchiusokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:11:11.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'didprognumchiusokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','didprognumchiusokind','50',null,null,null,'S',{ts '2018-07-19 15:11:11.733'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3264')
UPDATE [relation] SET childtable = 'didprognumchiusokind',description = 'didattica programmata di cui descrive la modalità di accesso',lt = {ts '2018-07-19 15:11:41.767'},lu = 'assistenza',parenttable = 'didprog',title = null WHERE idrelation = '3264'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3264','didprognumchiusokind','didattica programmata di cui descrive la modalità di accesso',{ts '2018-07-19 15:11:41.767'},'assistenza','didprog',null)
GO

-- FINE GENERAZIONE SCRIPT --

