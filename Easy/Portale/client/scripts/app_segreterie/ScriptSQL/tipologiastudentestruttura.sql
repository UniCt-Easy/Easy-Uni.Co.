
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


-- CREAZIONE TABELLA tipologiastudentestruttura --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tipologiastudentestruttura]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tipologiastudentestruttura] (
idtipologiastudente int NOT NULL,
idbandodsservizio int NOT NULL,
idbandods int NOT NULL,
idstruttura int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpktipologiastudentestruttura PRIMARY KEY (idtipologiastudente,
idbandodsservizio,
idbandods,
idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA tipologiastudentestruttura --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudentestruttura' and C.name = 'idtipologiastudente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudentestruttura] ADD idtipologiastudente int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudentestruttura') and col.name = 'idtipologiastudente' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudentestruttura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudentestruttura' and C.name = 'idbandodsservizio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudentestruttura] ADD idbandodsservizio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudentestruttura') and col.name = 'idbandodsservizio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudentestruttura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudentestruttura' and C.name = 'idbandods' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudentestruttura] ADD idbandods int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudentestruttura') and col.name = 'idbandods' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudentestruttura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudentestruttura' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudentestruttura] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudentestruttura') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudentestruttura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudentestruttura' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudentestruttura] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudentestruttura') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudentestruttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipologiastudentestruttura] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudentestruttura' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudentestruttura] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudentestruttura') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudentestruttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipologiastudentestruttura] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudentestruttura' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudentestruttura] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudentestruttura') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudentestruttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipologiastudentestruttura] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipologiastudentestruttura' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipologiastudentestruttura] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipologiastudentestruttura') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipologiastudentestruttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipologiastudentestruttura] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI tipologiastudentestruttura IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tipologiastudentestruttura'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipologiastudentestruttura','int','ASSISTENZA','idbandods','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipologiastudentestruttura','int','ASSISTENZA','idbandodsservizio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipologiastudentestruttura','int','ASSISTENZA','idstruttura','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipologiastudentestruttura','int','ASSISTENZA','idtipologiastudente','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipologiastudentestruttura','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipologiastudentestruttura','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipologiastudentestruttura','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipologiastudentestruttura','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tipologiastudentestruttura IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tipologiastudentestruttura')
UPDATE customobject set isreal = 'S' where objectname = 'tipologiastudentestruttura'
ELSE
INSERT INTO customobject (objectname, isreal) values('tipologiastudentestruttura', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tipologiastudentestruttura')
UPDATE [tabledescr] SET description = 'Strutture a cui è riferita una tipologia di studente per un 2.5.12 Bando per il diritto allo studio',idapplication = null,isdbo = 'N',lt = {ts '2020-09-10 16:42:34.787'},lu = 'assistenza',title = 'Strutture a cui è riferita una tipologia di studente per un bando per il diritto allo studio' WHERE tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tipologiastudentestruttura','Strutture a cui è riferita una tipologia di studente per un 2.5.12 Bando per il diritto allo studio',null,'N',{ts '2020-09-10 16:42:34.787'},'assistenza','Strutture a cui è riferita una tipologia di studente per un bando per il diritto allo studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tipologiastudentestruttura','8',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tipologiastudentestruttura','64',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandods' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandods' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandods','tipologiastudentestruttura','4',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandodsservizio' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandodsservizio' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandodsservizio','tipologiastudentestruttura','4',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura didattica',kind = 'S',lt = {ts '2020-09-10 16:44:54.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','tipologiastudentestruttura','4',null,null,'Struttura didattica','S',{ts '2020-09-10 16:44:54.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtipologiastudente' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Categoria di studenti',kind = 'S',lt = {ts '2020-09-10 16:44:54.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtipologiastudente' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtipologiastudente','tipologiastudentestruttura','4',null,null,'Categoria di studenti','S',{ts '2020-09-10 16:44:54.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tipologiastudentestruttura','8',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tipologiastudentestruttura','64',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

