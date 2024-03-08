
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
-- CREAZIONE TABELLA didprogporzanno --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogporzanno]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprogporzanno] (
iddidprogporzanno int NOT NULL,
iddidproganno int NOT NULL,
iddidprogori int NOT NULL,
iddidprogcurr int NOT NULL,
iddidprog int NOT NULL,
idcorsostudio int NOT NULL,
aa varchar(9) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
iddidprogporzannokind int NULL,
indice int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start date NULL,
stop date NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkdidprogporzanno PRIMARY KEY (iddidprogporzanno,
iddidproganno,
iddidprogori,
iddidprogcurr,
iddidprog,
idcorsostudio,
aa
)
)
END
GO

-- VERIFICA STRUTTURA didprogporzanno --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'iddidprogporzanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD iddidprogporzanno int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'iddidprogporzanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'iddidproganno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD iddidproganno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'iddidproganno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'iddidprogori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD iddidprogori int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'iddidprogori' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'iddidprogcurr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD iddidprogcurr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'iddidprogcurr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogporzanno] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogporzanno] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'iddidprogporzannokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD iddidprogporzannokind int NULL 
END
ELSE
	ALTER TABLE [didprogporzanno] ALTER COLUMN iddidprogporzannokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'indice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD indice int NULL 
END
ELSE
	ALTER TABLE [didprogporzanno] ALTER COLUMN indice int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogporzanno] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzanno') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzanno] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogporzanno] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD start date NULL 
END
ELSE
	ALTER TABLE [didprogporzanno] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD stop date NULL 
END
ELSE
	ALTER TABLE [didprogporzanno] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzanno' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzanno] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [didprogporzanno] ALTER COLUMN title varchar(2048) NULL
GO

-- VERIFICA DI didprogporzanno IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'didprogporzanno'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzanno','int','ASSISTENZA','iddidprogporzannokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzanno','int','ASSISTENZA','indice','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzanno','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzanno','date','ASSISTENZA','start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzanno','date','ASSISTENZA','stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzanno','varchar(2048)','ASSISTENZA','title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI didprogporzanno IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'didprogporzanno')
UPDATE customobject set isreal = 'S' where objectname = 'didprogporzanno'
ELSE
INSERT INTO customobject (objectname, isreal) values('didprogporzanno', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'didprogporzanno')
UPDATE [tabledescr] SET description = '2.4.15 porzione d''anno',idapplication = null,isdbo = 'N',lt = {ts '2020-09-29 18:07:06.157'},lu = 'assistenza',title = 'Porzione d''anno' WHERE tablename = 'didprogporzanno'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('didprogporzanno','2.4.15 porzione d''anno',null,'N',{ts '2020-09-29 18:07:06.157'},'assistenza','Porzione d''anno')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:08:25.063'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','didprogporzanno','9',null,null,null,'S',{ts '2019-09-23 16:08:25.063'},'assistenza','S','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:40:46.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','didprogporzanno','8',null,null,null,'S',{ts '2018-07-19 17:40:46.440'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:40:46.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','didprogporzanno','64',null,null,null,'S',{ts '2018-07-19 17:40:46.440'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:08:25.063'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','didprogporzanno','4',null,null,null,'S',{ts '2019-09-23 16:08:25.063'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-10 18:13:35.060'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','didprogporzanno','4',null,null,null,'S',{ts '2019-04-10 18:13:35.060'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidproganno' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-10 18:13:35.060'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidproganno' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidproganno','didprogporzanno','4',null,null,null,'S',{ts '2019-04-10 18:13:35.060'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogcurr' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-10 18:13:35.060'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogcurr' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogcurr','didprogporzanno','4',null,null,null,'S',{ts '2019-04-10 18:13:35.060'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogori' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-10 18:13:35.060'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogori' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogori','didprogporzanno','4',null,null,null,'S',{ts '2019-04-10 18:13:35.060'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogporzanno' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:40:46.440'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogporzanno' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogporzanno','didprogporzanno','4',null,null,null,'S',{ts '2018-07-19 17:40:46.440'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogporzannokind' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Durata',kind = 'S',lt = {ts '2019-09-10 16:42:14.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogporzannokind' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogporzannokind','didprogporzanno','4',null,null,'Durata','S',{ts '2019-09-10 16:42:14.627'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indice' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:40:46.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indice' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indice','didprogporzanno','4',null,null,null,'S',{ts '2018-07-19 17:40:46.440'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:40:46.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','didprogporzanno','8',null,null,null,'S',{ts '2018-07-19 17:40:46.440'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:40:46.443'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','didprogporzanno','64',null,null,null,'S',{ts '2018-07-19 17:40:46.443'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Dal',kind = 'S',lt = {ts '2019-09-10 16:42:14.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','didprogporzanno','3',null,null,'Dal','S',{ts '2019-09-10 16:42:14.630'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Al',kind = 'S',lt = {ts '2019-09-10 16:42:14.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','didprogporzanno','3',null,null,'Al','S',{ts '2019-09-10 16:42:14.630'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'didprogporzanno')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Porzione d''anno',kind = 'S',lt = {ts '2020-09-29 18:06:49.133'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','didprogporzanno','2048',null,null,'Porzione d''anno','S',{ts '2020-09-29 18:06:49.133'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3289')
UPDATE [relation] SET childtable = 'didprogporzanno',description = 'anno di corso che contiene la porzione d''anno',lt = {ts '2018-07-19 17:41:16.607'},lu = 'assistenza',parenttable = 'didproganno',title = null WHERE idrelation = '3289'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3289','didprogporzanno','anno di corso che contiene la porzione d''anno',{ts '2018-07-19 17:41:16.607'},'assistenza','didproganno',null)
GO

-- FINE GENERAZIONE SCRIPT --

