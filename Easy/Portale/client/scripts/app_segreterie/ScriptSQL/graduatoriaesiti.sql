
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
-- CREAZIONE TABELLA graduatoriaesiti --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[graduatoriaesiti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[graduatoriaesiti] (
idgraduatoriaesiti int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datachiusura datetime NULL,
idcorsostudio int NULL,
idgraduatoria int NOT NULL,
idtipologiastudente int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
provvisoria char(1) NOT NULL,
 CONSTRAINT xpkgraduatoriaesiti PRIMARY KEY (idgraduatoriaesiti
)
)
END
GO

-- VERIFICA STRUTTURA graduatoriaesiti --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesiti' and C.name = 'idgraduatoriaesiti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesiti] ADD idgraduatoriaesiti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesiti') and col.name = 'idgraduatoriaesiti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesiti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesiti' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesiti] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesiti') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesiti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriaesiti] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesiti' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesiti] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesiti') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesiti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriaesiti] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesiti' and C.name = 'datachiusura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesiti] ADD datachiusura datetime NULL 
END
ELSE
	ALTER TABLE [graduatoriaesiti] ALTER COLUMN datachiusura datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesiti' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesiti] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [graduatoriaesiti] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesiti' and C.name = 'idgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesiti] ADD idgraduatoria int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesiti') and col.name = 'idgraduatoria' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesiti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriaesiti] ALTER COLUMN idgraduatoria int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesiti' and C.name = 'idtipologiastudente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesiti] ADD idtipologiastudente int NULL 
END
ELSE
	ALTER TABLE [graduatoriaesiti] ALTER COLUMN idtipologiastudente int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesiti' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesiti] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesiti') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesiti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriaesiti] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesiti' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesiti] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesiti') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesiti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriaesiti] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesiti' and C.name = 'provvisoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesiti] ADD provvisoria char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesiti') and col.name = 'provvisoria' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesiti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriaesiti] ALTER COLUMN provvisoria char(1) NOT NULL
GO

-- VERIFICA DI graduatoriaesiti IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'graduatoriaesiti'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesiti','int','ASSISTENZA','idgraduatoriaesiti','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesiti','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesiti','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriaesiti','datetime','ASSISTENZA','datachiusura','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriaesiti','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesiti','int','ASSISTENZA','idgraduatoria','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriaesiti','int','ASSISTENZA','idtipologiastudente','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesiti','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesiti','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesiti','char(1)','ASSISTENZA','provvisoria','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI graduatoriaesiti IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'graduatoriaesiti')
UPDATE customobject set isreal = 'S' where objectname = 'graduatoriaesiti'
ELSE
INSERT INTO customobject (objectname, isreal) values('graduatoriaesiti', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'graduatoriaesiti')
UPDATE [tabledescr] SET description = 'Contenitore dei singoli esiti della 2.4.36 Graduatoria',idapplication = null,isdbo = 'N',lt = {ts '2018-07-18 17:50:31.707'},lu = 'assistenza',title = 'Contenitore dei singoli esiti della graduatoria' WHERE tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('graduatoriaesiti','Contenitore dei singoli esiti della 2.4.36 Graduatoria',null,'N',{ts '2018-07-18 17:50:31.707'},'assistenza','Contenitore dei singoli esiti della graduatoria')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'graduatoriaesiti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:50:33.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','graduatoriaesiti','8',null,null,null,'S',{ts '2018-07-18 17:50:33.150'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'graduatoriaesiti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:50:33.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','graduatoriaesiti','64',null,null,null,'S',{ts '2018-07-18 17:50:33.150'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datachiusura' AND tablename = 'graduatoriaesiti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di chiusura',kind = 'S',lt = {ts '2020-03-04 15:50:37.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'datachiusura' AND tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datachiusura','graduatoriaesiti','8',null,null,'Data di chiusura','S',{ts '2020-03-04 15:50:37.680'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'graduatoriaesiti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-04 13:16:35.287'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','graduatoriaesiti','4',null,null,null,'S',{ts '2020-03-04 13:16:35.287'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoria' AND tablename = 'graduatoriaesiti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Calcolo su cui è basata',kind = 'S',lt = {ts '2020-10-01 11:29:47.957'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoria' AND tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoria','graduatoriaesiti','4',null,null,'Calcolo su cui è basata','S',{ts '2020-10-01 11:29:47.957'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoriaesiti' AND tablename = 'graduatoriaesiti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:50:33.150'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoriaesiti' AND tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoriaesiti','graduatoriaesiti','4',null,null,null,'S',{ts '2018-07-18 17:50:33.150'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtipologiastudente' AND tablename = 'graduatoriaesiti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-04 13:16:35.287'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtipologiastudente' AND tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtipologiastudente','graduatoriaesiti','4',null,null,null,'S',{ts '2020-03-04 13:16:35.287'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'graduatoriaesiti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:50:33.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','graduatoriaesiti','8',null,null,null,'S',{ts '2018-07-18 17:50:33.150'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'graduatoriaesiti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:50:33.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','graduatoriaesiti','64',null,null,null,'S',{ts '2018-07-18 17:50:33.150'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'provvisoria' AND tablename = 'graduatoriaesiti')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:50:33.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'provvisoria' AND tablename = 'graduatoriaesiti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('provvisoria','graduatoriaesiti','1',null,null,null,'S',{ts '2018-07-18 17:50:33.150'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3258')
UPDATE [relation] SET childtable = 'graduatoriaesiti',description = 'graduatoria di cui esprime gli esiti',lt = {ts '2018-07-18 17:50:54.963'},lu = 'assistenza',parenttable = 'graduatoria',title = null WHERE idrelation = '3258'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3258','graduatoriaesiti','graduatoria di cui esprime gli esiti',{ts '2018-07-18 17:50:54.963'},'assistenza','graduatoria',null)
GO

-- FINE GENERAZIONE SCRIPT --

