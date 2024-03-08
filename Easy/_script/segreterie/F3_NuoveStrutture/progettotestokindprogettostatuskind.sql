
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
-- CREAZIONE TABELLA progettotestokindprogettostatuskind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettotestokindprogettostatuskind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettotestokindprogettostatuskind] (
idprogettostatuskind int NOT NULL,
idprogettotestokind int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
 CONSTRAINT xpkprogettotestokindprogettostatuskind PRIMARY KEY (idprogettostatuskind,
idprogettotestokind
)
)
END
GO

-- VERIFICA STRUTTURA progettotestokindprogettostatuskind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD idprogettostatuskind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotestokindprogettostatuskind') and col.name = 'idprogettostatuskind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotestokindprogettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'idprogettotestokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD idprogettotestokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotestokindprogettostatuskind') and col.name = 'idprogettotestokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotestokindprogettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotestokindprogettostatuskind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotestokindprogettostatuskind] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotestokindprogettostatuskind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotestokindprogettostatuskind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotestokindprogettostatuskind] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotestokindprogettostatuskind] ALTER COLUMN lu varchar(60) NULL
GO

-- VERIFICA DI progettotestokindprogettostatuskind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettotestokindprogettostatuskind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotestokindprogettostatuskind','int','assistenza','idprogettostatuskind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotestokindprogettostatuskind','int','assistenza','idprogettotestokind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokindprogettostatuskind','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokindprogettostatuskind','varchar(60)','assistenza','cu','60','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokindprogettostatuskind','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotestokindprogettostatuskind','varchar(60)','assistenza','lu','60','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progettotestokindprogettostatuskind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettotestokindprogettostatuskind')
UPDATE customobject set isreal = 'S' where objectname = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettotestokindprogettostatuskind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotestokindprogettostatuskind')
UPDATE [tabledescr] SET description = 'Stati in cui il testo è obbligatorio',idapplication = null,isdbo = 'N',lt = {ts '2020-11-12 16:18:29.967'},lu = 'assistenza',title = 'Stati in cui il testo è obbligatorio' WHERE tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotestokindprogettostatuskind','Stati in cui il testo è obbligatorio',null,'N',{ts '2020-11-12 16:18:29.967'},'assistenza','Stati in cui il testo è obbligatorio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:18:33.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotestokindprogettostatuskind','8',null,null,null,'S',{ts '2020-11-12 16:18:33.673'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:18:33.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotestokindprogettostatuskind','60',null,null,null,'S',{ts '2020-11-12 16:18:33.673'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettostatuskind' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2020-11-12 16:18:43.750'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettostatuskind' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettostatuskind','progettotestokindprogettostatuskind','4',null,null,'Stato','S',{ts '2020-11-12 16:18:43.750'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotestokind' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:18:33.673'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotestokind' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotestokind','progettotestokindprogettostatuskind','4',null,null,null,'S',{ts '2020-11-12 16:18:33.673'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:18:33.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotestokindprogettostatuskind','8',null,null,null,'S',{ts '2020-11-12 16:18:33.677'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotestokindprogettostatuskind')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:18:33.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotestokindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotestokindprogettostatuskind','60',null,null,null,'S',{ts '2020-11-12 16:18:33.677'},'assistenza','N','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

