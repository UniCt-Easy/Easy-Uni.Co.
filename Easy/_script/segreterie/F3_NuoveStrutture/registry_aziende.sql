
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
-- CREAZIONE TABELLA registry_aziende --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_aziende]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_aziende] (
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idateco int NULL,
idnace nvarchar(50) NULL,
idnaturagiur int NULL,
idnumerodip int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
pic varchar(10) NULL,
title_en varchar(150) NULL,
txt_en nvarchar(max) NULL,
 CONSTRAINT xpkregistry_aziende PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_aziende --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_aziende') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_aziende] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_aziende') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_aziende') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'idateco' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD idateco int NULL 
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN idateco int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'idnace' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD idnace nvarchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN idnace nvarchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'idnaturagiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD idnaturagiur int NULL 
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN idnaturagiur int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'idnumerodip' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD idnumerodip int NULL 
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN idnumerodip int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_aziende') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_aziende') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'pic' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD pic varchar(10) NULL 
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN pic varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD title_en varchar(150) NULL 
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN title_en varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_aziende' and C.name = 'txt_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_aziende] ADD txt_en nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_aziende] ALTER COLUMN txt_en nvarchar(max) NULL
GO

-- VERIFICA DI registry_aziende IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry_aziende'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_aziende','int','assistenza','idreg','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_aziende','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_aziende','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_aziende','int','assistenza','idateco','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_aziende','nvarchar(50)','assistenza','idnace','50','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_aziende','int','assistenza','idnaturagiur','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_aziende','int','assistenza','idnumerodip','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_aziende','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_aziende','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_aziende','varchar(10)','assistenza','pic','10','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_aziende','varchar(150)','assistenza','title_en','150','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_aziende','nvarchar(max)','assistenza','txt_en','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI registry_aziende IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry_aziende')
UPDATE customobject set isreal = 'S' where objectname = 'registry_aziende'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry_aziende', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_aziende')
UPDATE [tabledescr] SET description = '2.4.34 2.5.19  Enti e Aziende',idapplication = null,isdbo = 'N',lt = {ts '2018-11-29 16:24:46.000'},lu = 'Ferdinando',title = 'Enti e Aziende' WHERE tablename = 'registry_aziende'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_aziende','2.4.34 2.5.19  Enti e Aziende',null,'N',{ts '2018-11-29 16:24:46.000'},'Ferdinando','Enti e Aziende')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:22:01.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_aziende','8',null,null,null,'S',{ts '2018-07-17 17:22:01.493'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:22:01.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_aziende','64',null,null,null,'S',{ts '2018-07-17 17:22:01.493'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2018-11-26 12:48:13.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','registry_aziende','0',null,null,'Descrizione','S',{ts '2018-11-26 12:48:13.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description_en' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione (ENG)',kind = 'S',lt = {ts '2018-11-26 12:48:13.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description_en' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description_en','registry_aziende','0',null,null,'Descrizione (ENG)','S',{ts '2018-11-26 12:48:13.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idateco' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Classificazione Ateco',kind = 'S',lt = {ts '2018-12-05 17:05:15.717'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idateco' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idateco','registry_aziende','4',null,null,'Classificazione Ateco','S',{ts '2018-12-05 17:05:15.717'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnace' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'NACE',kind = 'S',lt = {ts '2020-11-04 17:59:36.110'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'idnace' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnace','registry_aziende','50',null,null,'NACE','S',{ts '2020-11-04 17:59:36.110'},'assistenza','N','nvarchar(50)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnaturagiur' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Natura Giuridica',kind = 'S',lt = {ts '2018-12-05 17:05:15.717'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnaturagiur' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnaturagiur','registry_aziende','4',null,null,'Natura Giuridica','S',{ts '2018-12-05 17:05:15.717'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnumerodip' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di dipendenti',kind = 'S',lt = {ts '2018-12-05 17:05:15.717'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnumerodip' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnumerodip','registry_aziende','4',null,null,'Numero di dipendenti','S',{ts '2018-12-05 17:05:15.717'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-11-26 17:21:21.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_aziende','4',null,null,'Codice','S',{ts '2018-11-26 17:21:21.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:22:01.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_aziende','8',null,null,null,'S',{ts '2018-07-17 17:22:01.493'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:22:01.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_aziende','64',null,null,null,'S',{ts '2018-07-17 17:22:01.493'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pic' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Participant Identification Code (PIC)',kind = 'S',lt = {ts '2020-11-03 16:05:51.590'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'pic' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pic','registry_aziende','10',null,null,'Participant Identification Code (PIC)','S',{ts '2020-11-03 16:05:51.590'},'assistenza','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title_en' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Denominazione (ENG)',kind = 'S',lt = {ts '2018-11-26 12:48:13.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title_en' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title_en','registry_aziende','150',null,null,'Denominazione (ENG)','S',{ts '2018-11-26 12:48:13.000'},'Ferdinando','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt_en' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:03:50.877'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'txt_en' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt_en','registry_aziende','0',null,null,null,'S',{ts '2018-12-05 17:03:50.877'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3213')
UPDATE [relation] SET childtable = 'registry_aziende',description = 'Campi comni alle aagrafiche di persone fisiche e giuridiche ',lt = {ts '2018-07-17 17:22:01.170'},lu = 'assistenza',parenttable = 'registry',title = null WHERE idrelation = '3213'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3213','registry_aziende','Campi comni alle aagrafiche di persone fisiche e giuridiche ',{ts '2018-07-17 17:22:01.170'},'assistenza','registry',null)
GO

-- FINE GENERAZIONE SCRIPT --

