
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


-- CREAZIONE TABELLA learningagrstud --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[learningagrstud]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[learningagrstud] (
idlearningagrstud int NOT NULL,
idiscrizionebmi int NOT NULL,
idbandomi int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idlearningagrkind int NOT NULL,
idreg_istitutiesteri int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
note varchar(max) NULL,
start date NOT NULL,
stop date NOT NULL,
 CONSTRAINT xpklearningagrstud PRIMARY KEY (idlearningagrstud,
idiscrizionebmi,
idbandomi,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA learningagrstud --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'idlearningagrstud' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD idlearningagrstud int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'idlearningagrstud' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'idiscrizionebmi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD idiscrizionebmi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'idiscrizionebmi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'idbandomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD idbandomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'idbandomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrstud] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrstud] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'idlearningagrkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD idlearningagrkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'idlearningagrkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrstud] ALTER COLUMN idlearningagrkind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'idreg_istitutiesteri' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD idreg_istitutiesteri int NULL 
END
ELSE
	ALTER TABLE [learningagrstud] ALTER COLUMN idreg_istitutiesteri int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrstud] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrstud] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'note' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD note varchar(max) NULL 
END
ELSE
	ALTER TABLE [learningagrstud] ALTER COLUMN note varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD start date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'start' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrstud] ALTER COLUMN start date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrstud' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrstud] ADD stop date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrstud') and col.name = 'stop' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrstud] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrstud] ALTER COLUMN stop date NOT NULL
GO

-- VERIFICA DI learningagrstud IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'learningagrstud'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','int','ASSISTENZA','idbandomi','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','int','ASSISTENZA','idiscrizionebmi','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','int','ASSISTENZA','idlearningagrstud','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','int','ASSISTENZA','idlearningagrkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstud','int','ASSISTENZA','idreg_istitutiesteri','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstud','varchar(max)','ASSISTENZA','note','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','date','ASSISTENZA','start','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstud','date','ASSISTENZA','stop','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI learningagrstud IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'learningagrstud')
UPDATE customobject set isreal = 'S' where objectname = 'learningagrstud'
ELSE
INSERT INTO customobject (objectname, isreal) values('learningagrstud', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'learningagrstud')
UPDATE [tabledescr] SET description = '2.2.16 Learning Agreement for studies (Contratto di insegnamento)
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 13:08:19.290'},lu = 'assistenza',title = 'Learning Agreement for studies (Contratto di insegnamento)' WHERE tablename = 'learningagrstud'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('learningagrstud','2.2.16 Learning Agreement for studies (Contratto di insegnamento)
',null,'N',{ts '2018-07-27 13:08:19.290'},'assistenza','Learning Agreement for studies (Contratto di insegnamento)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:08:22.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','learningagrstud','8',null,null,null,'S',{ts '2018-07-27 13:08:22.483'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:08:22.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','learningagrstud','64',null,null,null,'S',{ts '2018-07-27 13:08:22.483'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandomi' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 17:02:42.060'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandomi' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandomi','learningagrstud','4',null,null,null,'S',{ts '2019-11-28 17:02:42.060'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizionebmi' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione al bando di mobilit� internazionale',kind = 'S',lt = {ts '2019-11-28 17:02:42.063'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizionebmi' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizionebmi','learningagrstud','4',null,null,'Iscrizione al bando di mobilit� internazionale','S',{ts '2019-11-28 17:02:42.063'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrkind' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia di learning agreement',kind = 'S',lt = {ts '2019-02-25 10:49:18.253'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrkind' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrkind','learningagrstud','4',null,null,'Tipologia di learning agreement','S',{ts '2019-02-25 10:49:18.253'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrstud' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:08:22.487'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrstud' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrstud','learningagrstud','4',null,null,null,'S',{ts '2018-07-27 13:08:22.487'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 17:02:42.063'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','learningagrstud','4',null,null,null,'S',{ts '2019-11-28 17:02:42.063'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_istitutiesteri' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto',kind = 'S',lt = {ts '2019-02-25 10:51:03.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_istitutiesteri' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_istitutiesteri','learningagrstud','4',null,null,'Istituto','S',{ts '2019-02-25 10:51:03.483'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:08:22.487'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','learningagrstud','8',null,null,null,'S',{ts '2018-07-27 13:08:22.487'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:08:22.487'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','learningagrstud','64',null,null,null,'S',{ts '2018-07-27 13:08:22.487'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'note' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:08:22.487'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'note' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('note','learningagrstud','-1',null,null,null,'S',{ts '2018-07-27 13:08:22.487'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio',kind = 'S',lt = {ts '2019-02-25 10:51:03.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','learningagrstud','3',null,null,'Data di inizio','S',{ts '2019-02-25 10:51:03.483'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'learningagrstud')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine',kind = 'S',lt = {ts '2019-02-25 10:51:03.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','learningagrstud','3',null,null,'Data di fine','S',{ts '2019-02-25 10:51:03.483'},'assistenza','N','date','date','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --
