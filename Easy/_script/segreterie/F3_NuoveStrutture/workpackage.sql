
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


-- CREAZIONE TABELLA workpackage --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[workpackage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [workpackage] (
idworkpackage int NOT NULL,
idprogetto int NOT NULL,
acronimo nvarchar(2048) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description nvarchar(max) NULL,
idstruttura int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
raggruppamento nvarchar(2048) NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkworkpackage PRIMARY KEY (idworkpackage,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA workpackage --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'acronimo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD acronimo nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN acronimo nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'raggruppamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD raggruppamento nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN raggruppamento nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI workpackage IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'workpackage'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','int','assistenza','idworkpackage','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','acronimo','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(max)','assistenza','description','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','int','assistenza','idstruttura','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','raggruppamento','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','title','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI workpackage IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'workpackage')
UPDATE customobject set isreal = 'S' where objectname = 'workpackage'
ELSE
INSERT INTO customobject (objectname, isreal) values('workpackage', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'workpackage')
UPDATE [tabledescr] SET description = 'Workpackage',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:05:03.637'},lu = 'assistenza',title = 'Workpackage' WHERE tablename = 'workpackage'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('workpackage','Workpackage',null,'N',{ts '2020-05-20 14:05:03.637'},'assistenza','Workpackage')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'acronimo' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-02 18:25:10.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'acronimo' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('acronimo','workpackage','2048',null,null,null,'S',{ts '2020-11-02 18:25:10.753'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','workpackage','8',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','workpackage','64',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','workpackage','0',null,null,'Descrizione','S',{ts '2020-05-20 14:05:52.450'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','workpackage','4',null,null,'Progetto','S',{ts '2020-05-20 14:05:52.450'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dipartimento',kind = 'S',lt = {ts '2020-11-02 18:25:36.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','workpackage','4',null,null,'Dipartimento','S',{ts '2020-11-02 18:25:36.680'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Unità previsionale di base (UPB)',kind = 'S',lt = {ts '2020-11-02 18:25:36.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idupb' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','workpackage','50',null,null,'Unità previsionale di base (UPB)','S',{ts '2020-11-02 18:25:36.680'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','workpackage','4',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.637'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','workpackage','8',null,null,null,'S',{ts '2020-05-20 14:05:05.637'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.637'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','workpackage','64',null,null,null,'S',{ts '2020-05-20 14:05:05.637'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'raggruppamento' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-02 18:25:10.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'raggruppamento' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('raggruppamento','workpackage','2048',null,null,null,'S',{ts '2020-11-02 18:25:10.753'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','workpackage','2048',null,null,'Titolo','S',{ts '2020-05-20 14:05:52.450'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

