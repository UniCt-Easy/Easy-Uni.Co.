
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


-- CREAZIONE TABELLA numerodip --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[numerodip]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[numerodip] (
idnumerodip int NOT NULL,
active varchar(1) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NOT NULL,
title nvarchar(50) NOT NULL,
 CONSTRAINT xpknumerodip PRIMARY KEY (idnumerodip
)
)
END
GO

-- VERIFICA STRUTTURA numerodip --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'idnumerodip' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD idnumerodip int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('numerodip') and col.name = 'idnumerodip' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [numerodip] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD active varchar(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('numerodip') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [numerodip] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [numerodip] ALTER COLUMN active varchar(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [numerodip] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [numerodip] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('numerodip') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [numerodip] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [numerodip] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'numerodip' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [numerodip] ADD title nvarchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('numerodip') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [numerodip] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [numerodip] ALTER COLUMN title nvarchar(50) NOT NULL
GO

-- VERIFICA DI numerodip IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'numerodip'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','numerodip','int','ASSISTENZA','idnumerodip','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','numerodip','varchar(1)','ASSISTENZA','active','1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','numerodip','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','numerodip','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','numerodip','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','numerodip','nvarchar(50)','ASSISTENZA','title','50','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI numerodip IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'numerodip')
UPDATE customobject set isreal = 'S' where objectname = 'numerodip'
ELSE
INSERT INTO customobject (objectname, isreal) values('numerodip', 'S')
GO

-- GENERAZIONE DATI PER numerodip --
IF exists(SELECT * FROM [numerodip] WHERE idnumerodip = '1')
UPDATE [numerodip] SET active = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = '1-14' WHERE idnumerodip = '1'
ELSE
INSERT INTO [numerodip] (idnumerodip,active,lt,lu,sortcode,title) VALUES ('1','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','1-14')
GO

IF exists(SELECT * FROM [numerodip] WHERE idnumerodip = '2')
UPDATE [numerodip] SET active = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = '15-49' WHERE idnumerodip = '2'
ELSE
INSERT INTO [numerodip] (idnumerodip,active,lt,lu,sortcode,title) VALUES ('2','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','15-49')
GO

IF exists(SELECT * FROM [numerodip] WHERE idnumerodip = '3')
UPDATE [numerodip] SET active = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '3',title = '50-249' WHERE idnumerodip = '3'
ELSE
INSERT INTO [numerodip] (idnumerodip,active,lt,lu,sortcode,title) VALUES ('3','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','50-249')
GO

IF exists(SELECT * FROM [numerodip] WHERE idnumerodip = '4')
UPDATE [numerodip] SET active = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '4',title = '>250' WHERE idnumerodip = '4'
ELSE
INSERT INTO [numerodip] (idnumerodip,active,lt,lu,sortcode,title) VALUES ('4','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','4','>250')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'numerodip')
UPDATE [tabledescr] SET description = 'VOCABOLARIO dei range di numero di dipendenti di 2.4.34 2.5.19  Enti e Aziende',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-20 16:26:38.583'},lu = 'assistenza',title = 'Range di numero di dipendenti di Enti e Aziende' WHERE tablename = 'numerodip'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('numerodip','VOCABOLARIO dei range di numero di dipendenti di 2.4.34 2.5.19  Enti e Aziende','2','S',{ts '2018-07-20 16:26:38.583'},'assistenza','Range di numero di dipendenti di Enti e Aziende')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'numerodip')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:47:11.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'numerodip'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','numerodip','1',null,null,null,'S',{ts '2018-07-17 17:47:11.083'},'assistenza','N','varchar(1)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnumerodip' AND tablename = 'numerodip')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:47:11.083'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnumerodip' AND tablename = 'numerodip'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnumerodip','numerodip','4',null,null,null,'S',{ts '2018-07-17 17:47:11.083'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'numerodip')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:47:11.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'numerodip'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','numerodip','4',null,null,null,'S',{ts '2018-07-17 17:47:11.083'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'numerodip')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:47:11.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'numerodip'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','numerodip','50',null,null,null,'S',{ts '2018-07-17 17:47:11.083'},'assistenza','N','nvarchar(50)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

