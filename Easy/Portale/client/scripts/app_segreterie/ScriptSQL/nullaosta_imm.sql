
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


-- CREAZIONE TABELLA nullaosta_imm --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[nullaosta_imm]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[nullaosta_imm] (
idnullaosta int NOT NULL,
idistanza int NOT NULL,
idreg int NOT NULL,
idistanzakind int NOT NULL,
annoimm int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idcorsostudio int NULL,
iddidprog int NULL,
iddidprogcurr int NULL,
iddidprogori int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
parttime char(1) NOT NULL,
 CONSTRAINT xpknullaosta_imm PRIMARY KEY (idnullaosta,
idistanza,
idreg,
idistanzakind
)
)
END
GO

-- VERIFICA STRUTTURA nullaosta_imm --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'idnullaosta' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD idnullaosta int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nullaosta_imm') and col.name = 'idnullaosta' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nullaosta_imm] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'idistanza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD idistanza int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nullaosta_imm') and col.name = 'idistanza' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nullaosta_imm] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nullaosta_imm') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nullaosta_imm] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'idistanzakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD idistanzakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nullaosta_imm') and col.name = 'idistanzakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nullaosta_imm] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'annoimm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD annoimm int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nullaosta_imm') and col.name = 'annoimm' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nullaosta_imm] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [nullaosta_imm] ALTER COLUMN annoimm int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nullaosta_imm') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nullaosta_imm] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [nullaosta_imm] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nullaosta_imm') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nullaosta_imm] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [nullaosta_imm] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [nullaosta_imm] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD iddidprog int NULL 
END
ELSE
	ALTER TABLE [nullaosta_imm] ALTER COLUMN iddidprog int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'iddidprogcurr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD iddidprogcurr int NULL 
END
ELSE
	ALTER TABLE [nullaosta_imm] ALTER COLUMN iddidprogcurr int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'iddidprogori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD iddidprogori int NULL 
END
ELSE
	ALTER TABLE [nullaosta_imm] ALTER COLUMN iddidprogori int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nullaosta_imm') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nullaosta_imm] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [nullaosta_imm] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nullaosta_imm') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nullaosta_imm] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [nullaosta_imm] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nullaosta_imm' and C.name = 'parttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nullaosta_imm] ADD parttime char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nullaosta_imm') and col.name = 'parttime' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nullaosta_imm] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [nullaosta_imm] ALTER COLUMN parttime char(1) NOT NULL
GO

-- VERIFICA DI nullaosta_imm IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'nullaosta_imm'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaosta_imm','int','ASSISTENZA','idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaosta_imm','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaosta_imm','int','ASSISTENZA','idnullaosta','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaosta_imm','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaosta_imm','int','ASSISTENZA','annoimm','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaosta_imm','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaosta_imm','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaosta_imm','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaosta_imm','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaosta_imm','int','ASSISTENZA','iddidprogcurr','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaosta_imm','int','ASSISTENZA','iddidprogori','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaosta_imm','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaosta_imm','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaosta_imm','char(1)','ASSISTENZA','parttime','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI nullaosta_imm IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'nullaosta_imm')
UPDATE customobject set isreal = 'S' where objectname = 'nullaosta_imm'
ELSE
INSERT INTO customobject (objectname, isreal) values('nullaosta_imm', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'nullaosta_imm')
UPDATE [tabledescr] SET description = '2.2.2 Nullaosta di preimmatricolazione, 2.2.33 Nullaosta di immatricolazione, tabella di estensione di nullaosta',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 11:12:41.943'},lu = 'assistenza',title = 'Nullaosta di preimmatricolazione, Nullaosta di immatricolazione, tabella di estensione ' WHERE tablename = 'nullaosta_imm'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('nullaosta_imm','2.2.2 Nullaosta di preimmatricolazione, 2.2.33 Nullaosta di immatricolazione, tabella di estensione di nullaosta',null,'N',{ts '2018-07-20 11:12:41.943'},'assistenza','Nullaosta di preimmatricolazione, Nullaosta di immatricolazione, tabella di estensione ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'annoimm' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'anno di corso di immatricolazione',kind = 'S',lt = {ts '2019-11-13 18:24:59.923'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annoimm' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annoimm','nullaosta_imm','4',null,null,'anno di corso di immatricolazione','S',{ts '2019-11-13 18:24:59.923'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 11:12:44.507'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','nullaosta_imm','8',null,null,null,'S',{ts '2018-07-20 11:12:44.507'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 11:12:44.507'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','nullaosta_imm','64',null,null,null,'S',{ts '2018-07-20 11:12:44.507'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-04-23 16:27:21.573'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','nullaosta_imm','4',null,null,null,'S',{ts '2020-04-23 16:27:21.573'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-04-23 16:01:01.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','nullaosta_imm','4',null,null,null,'S',{ts '2020-04-23 16:01:01.440'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogcurr' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Curriculum',kind = 'S',lt = {ts '2020-03-26 11:17:47.807'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogcurr' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogcurr','nullaosta_imm','4',null,null,'Curriculum','S',{ts '2020-03-26 11:17:47.807'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogori' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Corso e orientamento',kind = 'S',lt = {ts '2020-03-24 15:36:41.153'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogori' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogori','nullaosta_imm','4',null,null,'Corso e orientamento','S',{ts '2020-03-24 15:36:41.153'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanza' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istanza',kind = 'S',lt = {ts '2019-11-13 18:24:59.923'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanza' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanza','nullaosta_imm','4',null,null,'Istanza','S',{ts '2019-11-13 18:24:59.923'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanzakind' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-04 12:56:25.220'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanzakind' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanzakind','nullaosta_imm','4',null,null,null,'S',{ts '2020-05-04 12:56:25.220'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnullaosta' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 11:12:44.507'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnullaosta' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnullaosta','nullaosta_imm','4',null,null,null,'S',{ts '2018-07-20 11:12:44.507'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-11-13 18:24:59.923'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','nullaosta_imm','4',null,null,'Studente','S',{ts '2019-11-13 18:24:59.923'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 11:12:44.507'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','nullaosta_imm','8',null,null,null,'S',{ts '2018-07-20 11:12:44.507'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 11:12:44.507'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','nullaosta_imm','64',null,null,null,'S',{ts '2018-07-20 11:12:44.507'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parttime' AND tablename = 'nullaosta_imm')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-24 10:20:48.583'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'parttime' AND tablename = 'nullaosta_imm'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parttime','nullaosta_imm','1',null,null,null,'S',{ts '2020-03-24 10:20:48.583'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3313')
UPDATE [relation] SET childtable = 'nullaosta_imm',description = 'record che sta estendendo',lt = {ts '2018-07-20 11:13:15.207'},lu = 'assistenza',parenttable = 'nullaosta',title = null WHERE idrelation = '3313'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3313','nullaosta_imm','record che sta estendendo',{ts '2018-07-20 11:13:15.207'},'assistenza','nullaosta',null)
GO

-- FINE GENERAZIONE SCRIPT --

