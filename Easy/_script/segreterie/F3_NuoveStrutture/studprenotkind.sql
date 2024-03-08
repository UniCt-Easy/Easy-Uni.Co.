
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
-- CREAZIONE TABELLA studprenotkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[studprenotkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[studprenotkind] (
idstudprenotkind int NOT NULL,
active char(1) NOT NULL,
description varchar(512) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortorder int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkstudprenotkind PRIMARY KEY (idstudprenotkind
)
)
END
GO

-- VERIFICA STRUTTURA studprenotkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'idstudprenotkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD idstudprenotkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'idstudprenotkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD description varchar(512) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN description varchar(512) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'sortorder' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD sortorder int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'sortorder' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN sortorder int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI studprenotkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'studprenotkind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','studprenotkind','int','ASSISTENZA','idstudprenotkind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','studprenotkind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','studprenotkind','varchar(512)','ASSISTENZA','description','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','studprenotkind','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','studprenotkind','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','studprenotkind','int','ASSISTENZA','sortorder','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','studprenotkind','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI studprenotkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'studprenotkind')
UPDATE customobject set isreal = 'S' where objectname = 'studprenotkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('studprenotkind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'studprenotkind')
UPDATE [tabledescr] SET description = 'sede, fuorisede, ecc.',idapplication = null,isdbo = 'N',lt = {ts '2018-12-18 18:48:24.000'},lu = 'Ferdinando',title = 'Tipologia di studente durante la prenotazione' WHERE tablename = 'studprenotkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('studprenotkind','sede, fuorisede, ecc.',null,'N',{ts '2018-12-18 18:48:24.000'},'Ferdinando','Tipologia di studente durante la prenotazione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-16 15:36:19.830'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','studprenotkind','1',null,null,null,'S',{ts '2018-07-16 15:36:19.830'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2018-12-18 18:46:48.360'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','studprenotkind','512',null,null,'Descrizione','S',{ts '2018-12-18 18:46:48.360'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstudprenotkind' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-12-18 18:58:23.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstudprenotkind' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstudprenotkind','studprenotkind','4',null,null,'Codice','S',{ts '2018-12-18 18:58:23.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-18 18:45:49.847'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','studprenotkind','8',null,null,null,'S',{ts '2018-12-18 18:45:49.847'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-18 18:45:49.847'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','studprenotkind','64',null,null,null,'S',{ts '2018-12-18 18:45:49.847'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortorder' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordine',kind = 'S',lt = {ts '2018-12-18 18:46:48.363'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortorder' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortorder','studprenotkind','4',null,null,'Ordine','S',{ts '2018-12-18 18:46:48.363'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2018-12-18 18:46:48.363'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','studprenotkind','50',null,null,'Titolo','S',{ts '2018-12-18 18:46:48.363'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

