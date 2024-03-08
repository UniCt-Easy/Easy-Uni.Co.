
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
-- CREAZIONE TABELLA progettoattachkindprogettostatuskind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoattachkindprogettostatuskind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettoattachkindprogettostatuskind] (
idprogettostatuskind int NOT NULL,
idprogettoattachkind int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
 CONSTRAINT xpkprogettoattachkindprogettostatuskind PRIMARY KEY (idprogettostatuskind,
idprogettoattachkind
)
)
END
GO

-- VERIFICA STRUTTURA progettoattachkindprogettostatuskind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD idprogettostatuskind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkindprogettostatuskind') and col.name = 'idprogettostatuskind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkindprogettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'idprogettoattachkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD idprogettoattachkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoattachkindprogettostatuskind') and col.name = 'idprogettoattachkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoattachkindprogettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoattachkindprogettostatuskind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoattachkindprogettostatuskind] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettoattachkindprogettostatuskind] ALTER COLUMN lu varchar(60) NULL
GO

-- VERIFICA DI progettoattachkindprogettostatuskind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettoattachkindprogettostatuskind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattachkindprogettostatuskind','int','assistenza','idprogettoattachkind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoattachkindprogettostatuskind','int','assistenza','idprogettostatuskind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattachkindprogettostatuskind','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattachkindprogettostatuskind','varchar(60)','assistenza','cu','60','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattachkindprogettostatuskind','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoattachkindprogettostatuskind','varchar(60)','assistenza','lu','60','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progettoattachkindprogettostatuskind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettoattachkindprogettostatuskind')
UPDATE customobject set isreal = 'S' where objectname = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettoattachkindprogettostatuskind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettoattachkindprogettostatuskind')
UPDATE [tabledescr] SET description = 'Stati in cui l''allegato è obbligatorio',idapplication = null,isdbo = 'N',lt = {ts '2020-11-12 16:17:08.297'},lu = 'assistenza',title = 'Stati in cui l''allegato è obbligatorio' WHERE tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettoattachkindprogettostatuskind','Stati in cui l''allegato è obbligatorio',null,'N',{ts '2020-11-12 16:17:08.297'},'assistenza','Stati in cui l''allegato è obbligatorio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:17:12.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettoattachkindprogettostatuskind','8',null,null,null,'S',{ts '2020-11-12 16:17:12.303'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:17:12.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettoattachkindprogettostatuskind','60',null,null,null,'S',{ts '2020-11-12 16:17:12.303'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettoattachkind' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:17:12.303'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettoattachkind' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettoattachkind','progettoattachkindprogettostatuskind','4',null,null,null,'S',{ts '2020-11-12 16:17:12.303'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettostatuskind' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2020-11-12 16:17:38.733'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettostatuskind' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettostatuskind','progettoattachkindprogettostatuskind','4',null,null,'Stato','S',{ts '2020-11-12 16:17:38.733'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:17:12.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettoattachkindprogettostatuskind','8',null,null,null,'S',{ts '2020-11-12 16:17:12.303'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettoattachkindprogettostatuskind')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-12 16:17:12.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettoattachkindprogettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettoattachkindprogettostatuskind','60',null,null,null,'S',{ts '2020-11-12 16:17:12.303'},'assistenza','N','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

