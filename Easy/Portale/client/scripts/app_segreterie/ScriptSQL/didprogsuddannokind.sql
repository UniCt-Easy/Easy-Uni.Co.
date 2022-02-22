
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


-- CREAZIONE TABELLA didprogsuddannokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogsuddannokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprogsuddannokind] (
iddidprogsuddannokind int NOT NULL,
active char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
title varchar(50) NULL,
 CONSTRAINT xpkdidprogsuddannokind PRIMARY KEY (iddidprogsuddannokind
)
)
END
GO

-- VERIFICA STRUTTURA didprogsuddannokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'iddidprogsuddannokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD iddidprogsuddannokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogsuddannokind') and col.name = 'iddidprogsuddannokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogsuddannokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [didprogsuddannokind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogsuddannokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogsuddannokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogsuddannokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogsuddannokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogsuddannokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogsuddannokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [didprogsuddannokind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogsuddannokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogsuddannokind] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [didprogsuddannokind] ALTER COLUMN title varchar(50) NULL
GO

-- VERIFICA DI didprogsuddannokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'didprogsuddannokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogsuddannokind','int','assistenza','iddidprogsuddannokind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogsuddannokind','char(1)','assistenza','active','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogsuddannokind','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogsuddannokind','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogsuddannokind','int','assistenza','sortcode','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogsuddannokind','varchar(50)','assistenza','title','50','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI didprogsuddannokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'didprogsuddannokind')
UPDATE customobject set isreal = 'S' where objectname = 'didprogsuddannokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('didprogsuddannokind', 'S')
GO

-- GENERAZIONE DATI PER didprogsuddannokind --
IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '1')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'mensile' WHERE iddidprogsuddannokind = '1'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','mensile')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '2')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'bimestrale' WHERE iddidprogsuddannokind = '2'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','bimestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '3')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'trimestrale' WHERE iddidprogsuddannokind = '3'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','trimestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '4')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'quadrimestrale' WHERE iddidprogsuddannokind = '4'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','quadrimestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '5')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'semestrale' WHERE iddidprogsuddannokind = '5'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','semestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '6')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'annuale' WHERE iddidprogsuddannokind = '6'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','6','annuale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'didprogsuddannokind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO delle possibili partizioni dell’anno',idapplication = '2',isdbo = 'S',lt = {ts '2022-01-11 13:24:45.443'},lu = 'Generator',title = 'VOCABOLARIO delle possibili partizioni dell’anno' WHERE tablename = 'didprogsuddannokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('didprogsuddannokind','VOCABOLARIO delle possibili partizioni dell’anno','2','S',{ts '2022-01-11 13:24:45.443'},'Generator','VOCABOLARIO delle possibili partizioni dell’anno')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'didprogsuddannokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:21:06.243'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'didprogsuddannokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','didprogsuddannokind','1',null,null,null,'S',{ts '2018-07-19 15:21:06.243'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogsuddannokind' AND tablename = 'didprogsuddannokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:21:06.243'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogsuddannokind' AND tablename = 'didprogsuddannokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogsuddannokind','didprogsuddannokind','4',null,null,null,'S',{ts '2018-07-19 15:21:06.243'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'didprogsuddannokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:21:06.243'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'didprogsuddannokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','didprogsuddannokind','8',null,null,null,'S',{ts '2018-07-19 15:21:06.243'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'didprogsuddannokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:21:06.243'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'didprogsuddannokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','didprogsuddannokind','64',null,null,null,'S',{ts '2018-07-19 15:21:06.243'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'didprogsuddannokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:21:06.243'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'didprogsuddannokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','didprogsuddannokind','4',null,null,null,'S',{ts '2018-07-19 15:21:06.243'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'didprogsuddannokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:21:06.243'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'didprogsuddannokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','didprogsuddannokind','50',null,null,null,'S',{ts '2018-07-19 15:21:06.243'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3267')
UPDATE [relation] SET childtable = 'didprogsuddannokind',description = 'didattica programmata di cui descrive la partizione temporale',lt = {ts '2018-07-19 15:22:07.847'},lu = 'assistenza',parenttable = 'didprog',title = null WHERE idrelation = '3267'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3267','didprogsuddannokind','didattica programmata di cui descrive la partizione temporale',{ts '2018-07-19 15:22:07.847'},'assistenza','didprog',null)
GO

-- FINE GENERAZIONE SCRIPT --

