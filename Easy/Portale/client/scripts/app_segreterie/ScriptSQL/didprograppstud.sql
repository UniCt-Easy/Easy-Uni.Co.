
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE TABELLA didprograppstud --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprograppstud]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprograppstud] (
iddidprog int NOT NULL,
idreg_studenti int NOT NULL,
idcorsostudio int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkdidprograppstud PRIMARY KEY (iddidprog,
idreg_studenti,
idcorsostudio
)
)
END
GO

-- VERIFICA STRUTTURA didprograppstud --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprograppstud' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprograppstud] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprograppstud') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprograppstud] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprograppstud' and C.name = 'idreg_studenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprograppstud] ADD idreg_studenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprograppstud') and col.name = 'idreg_studenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprograppstud] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprograppstud' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprograppstud] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprograppstud') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprograppstud] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprograppstud' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprograppstud] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprograppstud') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprograppstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprograppstud] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprograppstud' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprograppstud] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprograppstud') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprograppstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprograppstud] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprograppstud' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprograppstud] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprograppstud') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprograppstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprograppstud] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprograppstud' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprograppstud] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprograppstud') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprograppstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprograppstud] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI didprograppstud IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'didprograppstud'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprograppstud','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprograppstud','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprograppstud','int','ASSISTENZA','idreg_studenti','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprograppstud','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprograppstud','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprograppstud','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprograppstud','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI didprograppstud IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'didprograppstud')
UPDATE customobject set isreal = 'S' where objectname = 'didprograppstud'
ELSE
INSERT INTO customobject (objectname, isreal) values('didprograppstud', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'didprograppstud')
UPDATE [tabledescr] SET description = 'Rappresentanti degli studenti per la 2.4.1 Didattica programmata',idapplication = null,isdbo = 'N',lt = {ts '2018-07-19 15:43:59.677'},lu = 'assistenza',title = 'Rappresentanti degli studenti per la didattica programmata' WHERE tablename = 'didprograppstud'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('didprograppstud','Rappresentanti degli studenti per la 2.4.1 Didattica programmata',null,'N',{ts '2018-07-19 15:43:59.677'},'assistenza','Rappresentanti degli studenti per la didattica programmata')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'didprograppstud')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:44:00.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'didprograppstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','didprograppstud','8',null,null,null,'S',{ts '2018-07-19 15:44:00.863'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'didprograppstud')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:44:00.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'didprograppstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','didprograppstud','64',null,null,null,'S',{ts '2018-07-19 15:44:00.863'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'didprograppstud')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:07:38.733'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'didprograppstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','didprograppstud','4',null,null,null,'S',{ts '2019-09-23 16:07:38.733'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'didprograppstud')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica Programmata',kind = 'S',lt = {ts '2019-02-22 17:28:25.210'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'didprograppstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','didprograppstud','4',null,null,'Didattica Programmata','S',{ts '2019-02-22 17:28:25.210'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_studenti' AND tablename = 'didprograppstud')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-02-22 17:28:25.210'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_studenti' AND tablename = 'didprograppstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_studenti','didprograppstud','4',null,null,'Studente','S',{ts '2019-02-22 17:28:25.210'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'didprograppstud')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:44:00.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'didprograppstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','didprograppstud','8',null,null,null,'S',{ts '2018-07-19 15:44:00.863'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'didprograppstud')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:44:00.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'didprograppstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','didprograppstud','64',null,null,null,'S',{ts '2018-07-19 15:44:00.863'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3270')
UPDATE [relation] SET childtable = 'didprograppstud',description = 'didattica in cui lo studente ? rappresentante',lt = {ts '2018-07-19 15:45:26.097'},lu = 'assistenza',parenttable = 'didprog',title = null WHERE idrelation = '3270'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3270','didprograppstud','didattica in cui lo studente ? rappresentante',{ts '2018-07-19 15:45:26.097'},'assistenza','didprog',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3271')
UPDATE [relation] SET childtable = 'didprograppstud',description = 'lo studente rappresentante',lt = {ts '2018-07-19 15:45:26.123'},lu = 'assistenza',parenttable = 'registry',title = null WHERE idrelation = '3271'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3271','didprograppstud','lo studente rappresentante',{ts '2018-07-19 15:45:26.123'},'assistenza','registry',null)
GO

-- FINE GENERAZIONE SCRIPT --
