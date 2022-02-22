
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
-- CREAZIONE TABELLA accordoscambiomidettlangkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accordoscambiomidettlangkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accordoscambiomidettlangkind] (
idaccordoscambiomidettlangkind int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
title varchar(50) NULL,
 CONSTRAINT xpkaccordoscambiomidettlangkind PRIMARY KEY (idaccordoscambiomidettlangkind
)
)
END
GO

-- VERIFICA STRUTTURA accordoscambiomidettlangkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettlangkind' and C.name = 'idaccordoscambiomidettlangkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettlangkind] ADD idaccordoscambiomidettlangkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettlangkind') and col.name = 'idaccordoscambiomidettlangkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettlangkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettlangkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettlangkind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidettlangkind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettlangkind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettlangkind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettlangkind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettlangkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidettlangkind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettlangkind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettlangkind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettlangkind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettlangkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidettlangkind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettlangkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettlangkind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettlangkind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettlangkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidettlangkind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettlangkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettlangkind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidettlangkind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidettlangkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidettlangkind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettlangkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettlangkind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidettlangkind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidettlangkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidettlangkind] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidettlangkind] ALTER COLUMN title varchar(50) NULL
GO

-- VERIFICA DI accordoscambiomidettlangkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accordoscambiomidettlangkind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettlangkind','int','ASSISTENZA','idaccordoscambiomidettlangkind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettlangkind','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettlangkind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettlangkind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettlangkind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettlangkind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettlangkind','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettlangkind','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI accordoscambiomidettlangkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accordoscambiomidettlangkind')
UPDATE customobject set isreal = 'S' where objectname = 'accordoscambiomidettlangkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('accordoscambiomidettlangkind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'accordoscambiomidettlangkind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO indica se il livello della lingua è indicato per studenti, docenti o dipendenti. Parte di 2.5.30 Dettaglio accordo di mobilità internazionale con istituti
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 10:28:51.187'},lu = 'assistenza',title = 'VOCABOLARIO dice se il livello della lingua è indicato per studenti, docenti o dipendenti' WHERE tablename = 'accordoscambiomidettlangkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('accordoscambiomidettlangkind','VOCABOLARIO indica se il livello della lingua è indicato per studenti, docenti o dipendenti. Parte di 2.5.30 Dettaglio accordo di mobilità internazionale con istituti
',null,'N',{ts '2018-07-27 10:28:51.187'},'assistenza','VOCABOLARIO dice se il livello della lingua è indicato per studenti, docenti o dipendenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'accordoscambiomidettlangkind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:28:55.007'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'accordoscambiomidettlangkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','accordoscambiomidettlangkind','1',null,null,null,'S',{ts '2018-07-27 10:28:55.007'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'accordoscambiomidettlangkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:28:55.007'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'accordoscambiomidettlangkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','accordoscambiomidettlangkind','8',null,null,null,'S',{ts '2018-07-27 10:28:55.007'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'accordoscambiomidettlangkind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:28:55.007'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'accordoscambiomidettlangkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','accordoscambiomidettlangkind','64',null,null,null,'S',{ts '2018-07-27 10:28:55.007'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomidettlangkind' AND tablename = 'accordoscambiomidettlangkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:28:55.007'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomidettlangkind' AND tablename = 'accordoscambiomidettlangkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomidettlangkind','accordoscambiomidettlangkind','4',null,null,null,'S',{ts '2018-07-27 10:28:55.007'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'accordoscambiomidettlangkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:28:55.007'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'accordoscambiomidettlangkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','accordoscambiomidettlangkind','8',null,null,null,'S',{ts '2018-07-27 10:28:55.007'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'accordoscambiomidettlangkind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:28:55.007'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'accordoscambiomidettlangkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','accordoscambiomidettlangkind','64',null,null,null,'S',{ts '2018-07-27 10:28:55.007'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'accordoscambiomidettlangkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 10:28:55.007'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'accordoscambiomidettlangkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','accordoscambiomidettlangkind','4',null,null,null,'S',{ts '2018-07-27 10:28:55.007'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'accordoscambiomidettlangkind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Soggetto',kind = 'S',lt = {ts '2020-09-21 16:34:50.383'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'accordoscambiomidettlangkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','accordoscambiomidettlangkind','50',null,null,'Soggetto','S',{ts '2020-09-21 16:34:50.383'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3353')
UPDATE [relation] SET childtable = 'accordoscambiomidettlangkind',description = 'lingua del dettaglio accordo di cui indica i soggetti',lt = {ts '2018-07-27 10:29:54.013'},lu = 'assistenza',parenttable = 'accordoscambiomidettlang',title = null WHERE idrelation = '3353'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3353','accordoscambiomidettlangkind','lingua del dettaglio accordo di cui indica i soggetti',{ts '2018-07-27 10:29:54.013'},'assistenza','accordoscambiomidettlang',null)
GO

-- FINE GENERAZIONE SCRIPT --

