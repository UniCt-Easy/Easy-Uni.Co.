
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


-- CREAZIONE TABELLA affidamentokindcostoora --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentokindcostoora]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[affidamentokindcostoora] (
idaffidamentokindcostoora int NOT NULL,
idaffidamentokind int NOT NULL,
aa varchar(9) NULL,
costoora decimal(9,2) NULL,
title nvarchar(1024) NULL,
 CONSTRAINT xpkaffidamentokindcostoora PRIMARY KEY (idaffidamentokindcostoora,
idaffidamentokind
)
)
END
GO

-- VERIFICA STRUTTURA affidamentokindcostoora --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokindcostoora' and C.name = 'idaffidamentokindcostoora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokindcostoora] ADD idaffidamentokindcostoora int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokindcostoora') and col.name = 'idaffidamentokindcostoora' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokindcostoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokindcostoora' and C.name = 'idaffidamentokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokindcostoora] ADD idaffidamentokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamentokindcostoora') and col.name = 'idaffidamentokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamentokindcostoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokindcostoora' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokindcostoora] ADD aa varchar(9) NULL 
END
ELSE
	ALTER TABLE [affidamentokindcostoora] ALTER COLUMN aa varchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokindcostoora' and C.name = 'costoora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokindcostoora] ADD costoora decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [affidamentokindcostoora] ALTER COLUMN costoora decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamentokindcostoora' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamentokindcostoora] ADD title nvarchar(1024) NULL 
END
ELSE
	ALTER TABLE [affidamentokindcostoora] ALTER COLUMN title nvarchar(1024) NULL
GO

-- VERIFICA DI affidamentokindcostoora IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'affidamentokindcostoora'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokindcostoora','int','ASSISTENZA','idaffidamentokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokindcostoora','int','ASSISTENZA','idaffidamentokindcostoora','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentokindcostoora','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentokindcostoora','decimal(9,2)','ASSISTENZA','costoora','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentokindcostoora','nvarchar(1024)','ASSISTENZA','title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI affidamentokindcostoora IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'affidamentokindcostoora')
UPDATE customobject set isreal = 'S' where objectname = 'affidamentokindcostoora'
ELSE
INSERT INTO customobject (objectname, isreal) values('affidamentokindcostoora', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'affidamentokindcostoora')
UPDATE [tabledescr] SET description = 'Costo orario per anno accademico della tipologia di affidamento',idapplication = null,isdbo = 'N',lt = {ts '2020-10-19 13:25:57.203'},lu = 'assistenza',title = 'Costo orario per anno accademico' WHERE tablename = 'affidamentokindcostoora'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('affidamentokindcostoora','Costo orario per anno accademico della tipologia di affidamento',null,'N',{ts '2020-10-19 13:25:57.203'},'assistenza','Costo orario per anno accademico')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'affidamentokindcostoora')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico',kind = 'S',lt = {ts '2020-10-19 13:26:34.207'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'affidamentokindcostoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','affidamentokindcostoora','9',null,null,'Anno accademico','S',{ts '2020-10-19 13:26:34.207'},'assistenza','N','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costoora' AND tablename = 'affidamentokindcostoora')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Costo orario',kind = 'S',lt = {ts '2020-10-19 13:26:34.207'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costoora' AND tablename = 'affidamentokindcostoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costoora','affidamentokindcostoora','5','9','2','Costo orario','S',{ts '2020-10-19 13:26:34.207'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaffidamentokind' AND tablename = 'affidamentokindcostoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-10-19 13:26:00.500'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaffidamentokind' AND tablename = 'affidamentokindcostoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaffidamentokind','affidamentokindcostoora','4',null,null,null,'S',{ts '2020-10-19 13:26:00.500'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaffidamentokindcostoora' AND tablename = 'affidamentokindcostoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-10-19 13:26:00.500'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaffidamentokindcostoora' AND tablename = 'affidamentokindcostoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaffidamentokindcostoora','affidamentokindcostoora','4',null,null,null,'S',{ts '2020-10-19 13:26:00.500'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'affidamentokindcostoora')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-10-19 13:26:34.207'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(1024)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'affidamentokindcostoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','affidamentokindcostoora','1024',null,null,'Descrizione','S',{ts '2020-10-19 13:26:34.207'},'assistenza','N','nvarchar(1024)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

