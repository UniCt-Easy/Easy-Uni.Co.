
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
-- CREAZIONE TABELLA rendicont --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicont]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[rendicont] (
idreg_docenti int NOT NULL,
aa varchar(9) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkrendicont PRIMARY KEY (idreg_docenti,
aa
)
)
END
GO

-- VERIFICA STRUTTURA rendicont --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD idreg_docenti int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN title varchar(1024) NULL
GO

-- VERIFICA DI rendicont IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicont'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicont','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicont','int','ASSISTENZA','idreg_docenti','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicont','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicont','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicont','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicont','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicont','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicont IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicont')
UPDATE customobject set isreal = 'S' where objectname = 'rendicont'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicont', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicont')
UPDATE [tabledescr] SET description = '2.4.31 Scheda di rendicontazione / registro elettronico
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 18:16:36.967'},lu = 'assistenza',title = 'Scheda di rendicontazione / registro elettronico' WHERE tablename = 'rendicont'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicont','2.4.31 Scheda di rendicontazione / registro elettronico
',null,'N',{ts '2018-07-27 18:16:36.967'},'assistenza','Scheda di rendicontazione / registro elettronico')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico',kind = 'S',lt = {ts '2019-10-15 16:01:49.763'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','rendicont','9',null,null,'Anno accademico','S',{ts '2019-10-15 16:01:49.763'},'assistenza','S','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:16:39.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','rendicont','8',null,null,null,'S',{ts '2018-07-27 18:16:39.210'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:16:39.213'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','rendicont','64',null,null,null,'S',{ts '2018-07-27 18:16:39.213'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente',kind = 'S',lt = {ts '2019-04-24 17:25:10.743'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','rendicont','4',null,null,'Docente','S',{ts '2019-04-24 17:25:10.743'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:16:39.213'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','rendicont','8',null,null,null,'S',{ts '2018-07-27 18:16:39.213'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:16:39.217'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','rendicont','64',null,null,null,'S',{ts '2018-07-27 18:16:39.217'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-10-16 12:53:52.563'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','rendicont','1024',null,null,'Denominazione','S',{ts '2019-10-16 12:53:52.563'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3442')
UPDATE [relation] SET childtable = 'rendicont',description = 'Rendicontazioni annuali',lt = {ts '2018-12-07 18:37:51.957'},lu = 'assistenza',parenttable = 'docenti',title = '2.4.31 Scheda di rendicontazione / registro elettronico
' WHERE idrelation = '3442'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3442','rendicont','Rendicontazioni annuali',{ts '2018-12-07 18:37:51.957'},'assistenza','docenti','2.4.31 Scheda di rendicontazione / registro elettronico
')
GO

-- FINE GENERAZIONE SCRIPT --

