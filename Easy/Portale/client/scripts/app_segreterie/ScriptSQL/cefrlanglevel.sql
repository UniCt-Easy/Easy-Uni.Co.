
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


-- CREAZIONE TABELLA cefrlanglevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[cefrlanglevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[cefrlanglevel] (
idcefrlanglevel int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idaccordoscambiomi int NULL,
idaccordoscambiomidett int NULL,
idaccordoscambiomidettaz int NULL,
idaccordoscambiomidettlangkind int NOT NULL,
idcefr_compasc int NULL,
idcefr_complett int NULL,
idcefr_parlinter int NULL,
idcefr_parlprod int NULL,
idcefr_scritto int NULL,
idiscrizionebmi int NULL,
idlearningagrstud int NULL,
idlearningagrtrainer int NULL,
idnation int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcefrlanglevel PRIMARY KEY (idcefrlanglevel
)
)
END
GO

-- VERIFICA STRUTTURA cefrlanglevel --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idcefrlanglevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idcefrlanglevel int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefrlanglevel') and col.name = 'idcefrlanglevel' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefrlanglevel] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefrlanglevel') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefrlanglevel] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefrlanglevel') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefrlanglevel] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idaccordoscambiomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idaccordoscambiomi int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idaccordoscambiomi int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idaccordoscambiomidett' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idaccordoscambiomidett int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idaccordoscambiomidett int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idaccordoscambiomidettaz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idaccordoscambiomidettaz int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idaccordoscambiomidettaz int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idaccordoscambiomidettlangkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idaccordoscambiomidettlangkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefrlanglevel') and col.name = 'idaccordoscambiomidettlangkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefrlanglevel] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idaccordoscambiomidettlangkind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idcefr_compasc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idcefr_compasc int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idcefr_compasc int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idcefr_complett' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idcefr_complett int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idcefr_complett int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idcefr_parlinter' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idcefr_parlinter int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idcefr_parlinter int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idcefr_parlprod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idcefr_parlprod int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idcefr_parlprod int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idcefr_scritto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idcefr_scritto int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idcefr_scritto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idiscrizionebmi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idiscrizionebmi int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idiscrizionebmi int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idlearningagrstud' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idlearningagrstud int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idlearningagrstud int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idlearningagrtrainer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idlearningagrtrainer int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idlearningagrtrainer int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'idnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD idnation int NULL 
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN idnation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefrlanglevel') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefrlanglevel] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefrlanglevel' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefrlanglevel] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefrlanglevel') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefrlanglevel] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefrlanglevel] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI cefrlanglevel IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'cefrlanglevel'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrlanglevel','int','assistenza','idcefrlanglevel','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrlanglevel','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrlanglevel','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idaccordoscambiomi','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idaccordoscambiomidett','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idaccordoscambiomidettaz','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrlanglevel','int','assistenza','idaccordoscambiomidettlangkind','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idcefr_compasc','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idcefr_complett','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idcefr_parlinter','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idcefr_parlprod','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idcefr_scritto','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idiscrizionebmi','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idlearningagrstud','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idlearningagrtrainer','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cefrlanglevel','int','assistenza','idnation','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrlanglevel','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefrlanglevel','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI cefrlanglevel IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'cefrlanglevel')
UPDATE customobject set isreal = 'S' where objectname = 'cefrlanglevel'
ELSE
INSERT INTO customobject (objectname, isreal) values('cefrlanglevel', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'cefrlanglevel')
UPDATE [tabledescr] SET description = 'Livelli cefr che un soggetto possiede nei riguardi di una lingua specifica nei vari ambiti
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 13:17:17.457'},lu = 'assistenza',title = 'Livelli cefr che un soggetto possiede nei riguardi di una lingua specifica nei vari ambiti' WHERE tablename = 'cefrlanglevel'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('cefrlanglevel','Livelli cefr che un soggetto possiede nei riguardi di una lingua specifica nei vari ambiti
',null,'N',{ts '2018-07-27 13:17:17.457'},'assistenza','Livelli cefr che un soggetto possiede nei riguardi di una lingua specifica nei vari ambiti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:17:19.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','cefrlanglevel','8',null,null,null,'S',{ts '2018-07-27 13:17:19.143'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:17:19.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','cefrlanglevel','64',null,null,null,'S',{ts '2018-07-27 13:17:19.143'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomi' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-21 11:15:47.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomi' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomi','cefrlanglevel','4',null,null,null,'S',{ts '2021-06-21 11:15:47.470'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomidett' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-21 11:15:47.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomidett' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomidett','cefrlanglevel','4',null,null,null,'S',{ts '2021-06-21 11:15:47.470'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomidettaz' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-21 11:15:47.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomidettaz' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomidettaz','cefrlanglevel','4',null,null,null,'S',{ts '2021-06-21 11:15:47.470'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomidettlangkind' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2021-06-29 15:54:14.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomidettlangkind' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomidettlangkind','cefrlanglevel','4',null,null,'Tipologia','S',{ts '2021-06-29 15:54:14.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcefr_compasc' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Comprensione ascolto',kind = 'S',lt = {ts '2020-09-07 12:21:08.537'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcefr_compasc' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcefr_compasc','cefrlanglevel','4',null,null,'Comprensione ascolto','S',{ts '2020-09-07 12:21:08.537'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcefr_complett' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Comprensione lettura',kind = 'S',lt = {ts '2020-09-07 12:21:08.537'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcefr_complett' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcefr_complett','cefrlanglevel','4',null,null,'Comprensione lettura','S',{ts '2020-09-07 12:21:08.537'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcefr_parlinter' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Parlato interazione',kind = 'S',lt = {ts '2020-09-07 12:21:08.537'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcefr_parlinter' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcefr_parlinter','cefrlanglevel','4',null,null,'Parlato interazione','S',{ts '2020-09-07 12:21:08.537'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcefr_parlprod' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Parlato produzione',kind = 'S',lt = {ts '2020-09-07 12:21:08.537'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcefr_parlprod' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcefr_parlprod','cefrlanglevel','4',null,null,'Parlato produzione','S',{ts '2020-09-07 12:21:08.537'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcefr_scritto' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Scritto',kind = 'S',lt = {ts '2020-09-07 12:21:08.540'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcefr_scritto' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcefr_scritto','cefrlanglevel','4',null,null,'Scritto','S',{ts '2020-09-07 12:21:08.540'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcefrlanglevel' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:17:19.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcefrlanglevel' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcefrlanglevel','cefrlanglevel','4',null,null,null,'S',{ts '2018-07-27 13:17:19.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizionebmi' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-21 11:15:47.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizionebmi' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizionebmi','cefrlanglevel','4',null,null,null,'S',{ts '2021-06-21 11:15:47.470'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrstud' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-21 11:15:47.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrstud' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrstud','cefrlanglevel','4',null,null,null,'S',{ts '2021-06-21 11:15:47.470'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrtrainer' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-21 11:15:47.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrtrainer' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrtrainer','cefrlanglevel','4',null,null,null,'S',{ts '2021-06-21 11:15:47.470'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Lingua',kind = 'S',lt = {ts '2020-09-07 12:21:08.540'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','cefrlanglevel','4',null,null,'Lingua','S',{ts '2020-09-07 12:21:08.540'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:17:19.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','cefrlanglevel','8',null,null,null,'S',{ts '2018-07-27 13:17:19.147'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'cefrlanglevel')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:17:19.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','cefrlanglevel','64',null,null,null,'S',{ts '2018-07-27 13:17:19.147'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

