
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
-- CREAZIONE TABELLA didprogaccesso --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogaccesso]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprogaccesso] (
iddidprog int NOT NULL,
iddidprog_acc int NOT NULL,
idcorsostudio int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkdidprogaccesso PRIMARY KEY (iddidprog,
iddidprog_acc,
idcorsostudio
)
)
END
GO

-- VERIFICA STRUTTURA didprogaccesso --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogaccesso' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogaccesso] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogaccesso') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogaccesso] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogaccesso' and C.name = 'iddidprog_acc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogaccesso] ADD iddidprog_acc int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogaccesso') and col.name = 'iddidprog_acc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogaccesso] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogaccesso' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogaccesso] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogaccesso') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogaccesso] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogaccesso' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogaccesso] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogaccesso') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogaccesso] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogaccesso] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogaccesso' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogaccesso] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogaccesso') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogaccesso] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogaccesso] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogaccesso' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogaccesso] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogaccesso') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogaccesso] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogaccesso] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogaccesso' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogaccesso] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogaccesso') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogaccesso] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogaccesso] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI didprogaccesso IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'didprogaccesso'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogaccesso','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogaccesso','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogaccesso','int','ASSISTENZA','iddidprog_acc','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogaccesso','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogaccesso','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogaccesso','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogaccesso','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI didprogaccesso IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'didprogaccesso')
UPDATE customobject set isreal = 'S' where objectname = 'didprogaccesso'
ELSE
INSERT INTO customobject (objectname, isreal) values('didprogaccesso', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'didprogaccesso')
UPDATE [tabledescr] SET description = 'Elenco delle 2.4.1 Didattica programmata a cui il test di ingresso da acesso',idapplication = null,isdbo = 'N',lt = {ts '2018-07-19 15:15:07.643'},lu = 'assistenza',title = 'Elenco delle didattiche programmate a cui il test di ingresso da acesso' WHERE tablename = 'didprogaccesso'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('didprogaccesso','Elenco delle 2.4.1 Didattica programmata a cui il test di ingresso da acesso',null,'N',{ts '2018-07-19 15:15:07.643'},'assistenza','Elenco delle didattiche programmate a cui il test di ingresso da acesso')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'didprogaccesso')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:15:10.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'didprogaccesso'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','didprogaccesso','8',null,null,null,'S',{ts '2018-07-19 15:15:10.640'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'didprogaccesso')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:15:10.643'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'didprogaccesso'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','didprogaccesso','64',null,null,null,'S',{ts '2018-07-19 15:15:10.643'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'didprogaccesso')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-10-09 17:09:27.457'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'didprogaccesso'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','didprogaccesso','4',null,null,null,'S',{ts '2019-10-09 17:09:27.457'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'didprogaccesso')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'test di ingresso',kind = 'S',lt = {ts '2019-04-12 10:52:14.827'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'didprogaccesso'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','didprogaccesso','4',null,null,'test di ingresso','S',{ts '2019-04-12 10:52:14.827'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog_acc' AND tablename = 'didprogaccesso')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'didattica programmata a cui il test di ingresso da l''accesso',kind = 'S',lt = {ts '2019-04-12 10:51:55.630'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog_acc' AND tablename = 'didprogaccesso'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog_acc','didprogaccesso','4',null,null,'didattica programmata a cui il test di ingresso da l''accesso','S',{ts '2019-04-12 10:51:55.630'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'didprogaccesso')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:15:10.643'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'didprogaccesso'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','didprogaccesso','8',null,null,null,'S',{ts '2018-07-19 15:15:10.643'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'didprogaccesso')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:15:10.643'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'didprogaccesso'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','didprogaccesso','64',null,null,null,'S',{ts '2018-07-19 15:15:10.643'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3266')
UPDATE [relation] SET childtable = 'didprogaccesso',description = 'iddidprog_test ? il test di ingresso, iddidprog_acc sono le programmate a cui il test da accesso',lt = {ts '2018-07-19 15:20:31.010'},lu = 'assistenza',parenttable = 'didprog',title = null WHERE idrelation = '3266'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3266','didprogaccesso','iddidprog_test ? il test di ingresso, iddidprog_acc sono le programmate a cui il test da accesso',{ts '2018-07-19 15:20:31.010'},'assistenza','didprog',null)
GO

-- FINE GENERAZIONE SCRIPT --

