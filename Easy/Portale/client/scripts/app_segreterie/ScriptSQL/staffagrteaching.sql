
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
-- CREAZIONE TABELLA staffagrteaching --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[staffagrteaching]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[staffagrteaching] (
idstaffagrteaching int NOT NULL,
idiscrizionebmi int NOT NULL,
idbandomi int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idisced2013 int NOT NULL,
idlivelloeqf int NOT NULL,
idnation int NULL,
idreg_docenti int NOT NULL,
idreg_resp int NOT NULL,
idreg_respestero int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
numore int NULL,
numstud int NULL,
obiettivi varchar(max) NULL,
programma varchar(max) NULL,
risultati varchar(max) NULL,
valore varchar(max) NULL,
 CONSTRAINT xpkstaffagrteaching PRIMARY KEY (idstaffagrteaching,
idiscrizionebmi,
idbandomi,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA staffagrteaching --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'idstaffagrteaching' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD idstaffagrteaching int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'idstaffagrteaching' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'idiscrizionebmi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD idiscrizionebmi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'idiscrizionebmi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'idbandomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD idbandomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'idbandomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'idisced2013' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD idisced2013 int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'idisced2013' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN idisced2013 int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'idlivelloeqf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD idlivelloeqf int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'idlivelloeqf' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN idlivelloeqf int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'idnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD idnation int NULL 
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN idnation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN idreg_docenti int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'idreg_resp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD idreg_resp int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'idreg_resp' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN idreg_resp int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'idreg_respestero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD idreg_respestero int NULL 
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN idreg_respestero int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('staffagrteaching') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [staffagrteaching] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'numore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD numore int NULL 
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN numore int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'numstud' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD numstud int NULL 
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN numstud int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'obiettivi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD obiettivi varchar(max) NULL 
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN obiettivi varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'programma' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD programma varchar(max) NULL 
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN programma varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'risultati' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD risultati varchar(max) NULL 
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN risultati varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'staffagrteaching' and C.name = 'valore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [staffagrteaching] ADD valore varchar(max) NULL 
END
ELSE
	ALTER TABLE [staffagrteaching] ALTER COLUMN valore varchar(max) NULL
GO

-- VERIFICA DI staffagrteaching IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'staffagrteaching'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','int','ASSISTENZA','idbandomi','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','int','ASSISTENZA','idiscrizionebmi','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','int','ASSISTENZA','idstaffagrteaching','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','int','ASSISTENZA','idisced2013','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','int','ASSISTENZA','idlivelloeqf','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','staffagrteaching','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','int','ASSISTENZA','idreg_docenti','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','int','ASSISTENZA','idreg_resp','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','staffagrteaching','int','ASSISTENZA','idreg_respestero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','staffagrteaching','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','staffagrteaching','int','ASSISTENZA','numore','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','staffagrteaching','int','ASSISTENZA','numstud','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','staffagrteaching','varchar(max)','ASSISTENZA','obiettivi','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','staffagrteaching','varchar(max)','ASSISTENZA','programma','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','staffagrteaching','varchar(max)','ASSISTENZA','risultati','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','staffagrteaching','varchar(max)','ASSISTENZA','valore','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI staffagrteaching IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'staffagrteaching')
UPDATE customobject set isreal = 'S' where objectname = 'staffagrteaching'
ELSE
INSERT INTO customobject (objectname, isreal) values('staffagrteaching', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'staffagrteaching')
UPDATE [tabledescr] SET description = '2.4.39 Staff Mobility Agreement for teaching
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 13:17:40.597'},lu = 'assistenza',title = 'Staff Mobility Agreement for teaching' WHERE tablename = 'staffagrteaching'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('staffagrteaching','2.4.39 Staff Mobility Agreement for teaching
',null,'N',{ts '2018-07-27 13:17:40.597'},'assistenza','Staff Mobility Agreement for teaching')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:17:42.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','staffagrteaching','8',null,null,null,'S',{ts '2018-07-27 13:17:42.077'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:17:42.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','staffagrteaching','64',null,null,null,'S',{ts '2018-07-27 13:17:42.077'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandomi' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 17:06:13.860'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandomi' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandomi','staffagrteaching','4',null,null,null,'S',{ts '2019-11-28 17:06:13.860'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idisced2013' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Mansione',kind = 'S',lt = {ts '2019-02-25 12:12:08.703'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idisced2013' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idisced2013','staffagrteaching','4',null,null,'Mansione','S',{ts '2019-02-25 12:12:08.703'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizionebmi' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione al bando di mobilità internazionale',kind = 'S',lt = {ts '2019-11-28 17:06:13.860'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizionebmi' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizionebmi','staffagrteaching','4',null,null,'Iscrizione al bando di mobilità internazionale','S',{ts '2019-11-28 17:06:13.860'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlivelloeqf' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Livello EQF',kind = 'S',lt = {ts '2019-02-25 12:12:08.703'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlivelloeqf' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlivelloeqf','staffagrteaching','4',null,null,'Livello EQF','S',{ts '2019-02-25 12:12:08.703'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Lingua in cui svolge l’attività',kind = 'S',lt = {ts '2019-02-25 12:12:08.703'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','staffagrteaching','4',null,null,'Lingua in cui svolge l’attività','S',{ts '2019-02-25 12:12:08.703'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 17:06:13.860'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','staffagrteaching','4',null,null,null,'S',{ts '2019-11-28 17:06:13.860'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente',kind = 'S',lt = {ts '2019-02-25 12:12:08.703'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','staffagrteaching','4',null,null,'Docente','S',{ts '2019-02-25 12:12:08.703'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_resp' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Responsabile',kind = 'S',lt = {ts '2019-02-25 12:10:13.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_resp' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_resp','staffagrteaching','4',null,null,'Responsabile','S',{ts '2019-02-25 12:10:13.393'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_respestero' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Responsabile estero',kind = 'S',lt = {ts '2019-02-25 12:10:13.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_respestero' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_respestero','staffagrteaching','4',null,null,'Responsabile estero','S',{ts '2019-02-25 12:10:13.393'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstaffagrteaching' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:17:42.083'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstaffagrteaching' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstaffagrteaching','staffagrteaching','4',null,null,null,'S',{ts '2018-07-27 13:17:42.083'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:17:42.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','staffagrteaching','8',null,null,null,'S',{ts '2018-07-27 13:17:42.083'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:17:42.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','staffagrteaching','64',null,null,null,'S',{ts '2018-07-27 13:17:42.083'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numore' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di ore dell’attività del docente',kind = 'S',lt = {ts '2019-02-25 12:10:13.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numore' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numore','staffagrteaching','4',null,null,'Numero di ore dell’attività del docente','S',{ts '2019-02-25 12:10:13.393'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numstud' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di studenti a cui si rivolge l’attività del docente',kind = 'S',lt = {ts '2019-02-25 12:10:13.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numstud' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numstud','staffagrteaching','4',null,null,'Numero di studenti a cui si rivolge l’attività del docente','S',{ts '2019-02-25 12:10:13.393'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'obiettivi' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Obiettivi generali della mobilità',kind = 'S',lt = {ts '2019-02-25 12:12:08.707'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'obiettivi' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('obiettivi','staffagrteaching','-1',null,null,'Obiettivi generali della mobilità','S',{ts '2019-02-25 12:12:08.707'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'programma' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Contenuto del programma di insegnamento',kind = 'S',lt = {ts '2019-02-25 12:12:49.423'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'programma' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('programma','staffagrteaching','-1',null,null,'Contenuto del programma di insegnamento','S',{ts '2019-02-25 12:12:49.423'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'risultati' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Risultati attesi e impatto',kind = 'S',lt = {ts '2019-02-25 12:12:49.427'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'risultati' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('risultati','staffagrteaching','-1',null,null,'Risultati attesi e impatto','S',{ts '2019-02-25 12:12:49.427'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valore' AND tablename = 'staffagrteaching')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Valore aggiunto della mobilità',kind = 'S',lt = {ts '2019-02-25 12:12:08.707'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'valore' AND tablename = 'staffagrteaching'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valore','staffagrteaching','-1',null,null,'Valore aggiunto della mobilità','S',{ts '2019-02-25 12:12:08.707'},'assistenza','N','varchar(max)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

