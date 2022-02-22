
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


-- CREAZIONE TABELLA publicaz --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[publicaz]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[publicaz] (
idpublicaz int NOT NULL,
abstractstring nvarchar(max) NULL,
annocopyright int NULL,
annopub int NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
editore varchar(150) NULL,
fascicolo varchar(150) NULL,
idcity int NULL,
idcity_ed int NULL,
idnation_ed int NULL,
idnation_lang int NULL,
idprogetto int NULL,
isbn varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
numrivista int NULL,
pagestart int NULL,
pagestop int NULL,
pagetot int NULL,
title varchar(512) NULL,
title2 nvarchar(512) NULL,
volume varchar(150) NULL,
 CONSTRAINT xpkpublicaz PRIMARY KEY (idpublicaz
)
)
END
GO

-- VERIFICA STRUTTURA publicaz --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idpublicaz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idpublicaz int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'idpublicaz' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'abstractstring' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD abstractstring nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN abstractstring nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'annocopyright' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD annocopyright int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN annocopyright int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'annopub' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD annopub int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN annopub int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'editore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD editore varchar(150) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN editore varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'fascicolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD fascicolo varchar(150) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN fascicolo varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idcity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idcity int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idcity int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idcity_ed' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idcity_ed int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idcity_ed int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idnation_ed' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idnation_ed int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idnation_ed int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idnation_lang' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idnation_lang int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idnation_lang int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD idprogetto int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN idprogetto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'isbn' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD isbn varchar(50) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN isbn varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicaz') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicaz] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'numrivista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD numrivista int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN numrivista int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'pagestart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD pagestart int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN pagestart int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'pagestop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD pagestop int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN pagestop int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'pagetot' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD pagetot int NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN pagetot int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD title varchar(512) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN title varchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'title2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD title2 nvarchar(512) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN title2 nvarchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicaz' and C.name = 'volume' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicaz] ADD volume varchar(150) NULL 
END
ELSE
	ALTER TABLE [publicaz] ALTER COLUMN volume varchar(150) NULL
GO

-- VERIFICA DI publicaz IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'publicaz'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicaz','int','assistenza','idpublicaz','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','nvarchar(max)','assistenza','abstractstring','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','annocopyright','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','annopub','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicaz','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicaz','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','varchar(150)','assistenza','editore','150','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','varchar(150)','assistenza','fascicolo','150','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','idcity','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','idcity_ed','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','idnation_ed','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','idnation_lang','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','idprogetto','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','varchar(50)','assistenza','isbn','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicaz','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicaz','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','numrivista','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','pagestart','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','pagestop','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','int','assistenza','pagetot','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','varchar(512)','assistenza','title','512','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','nvarchar(512)','assistenza','title2','512','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicaz','varchar(150)','assistenza','volume','150','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI publicaz IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'publicaz')
UPDATE customobject set isreal = 'S' where objectname = 'publicaz'
ELSE
INSERT INTO customobject (objectname, isreal) values('publicaz', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'publicaz')
UPDATE [tabledescr] SET description = '2.4.27 pubblicazione',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 11:06:51.257'},lu = 'assistenza',title = 'Pubblicazione' WHERE tablename = 'publicaz'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('publicaz','2.4.27 pubblicazione','3','S',{ts '2021-02-19 11:06:51.257'},'assistenza','Pubblicazione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'abstractstring' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Abstract',kind = 'S',lt = {ts '2018-12-04 18:12:43.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'abstractstring' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('abstractstring','publicaz','0',null,null,'Abstract','S',{ts '2018-12-04 18:12:43.767'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annocopyright' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno Copyright',kind = 'S',lt = {ts '2018-11-21 18:33:45.263'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annocopyright' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annocopyright','publicaz','4',null,null,'Anno Copyright','S',{ts '2018-11-21 18:33:45.263'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annopub' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno pubblicazione',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annopub' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annopub','publicaz','4',null,null,'Anno pubblicazione','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','publicaz','8',null,null,null,'S',{ts '2018-07-17 17:01:54.597'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','publicaz','64',null,null,null,'S',{ts '2018-07-17 17:01:54.597'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'editore' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'editore' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('editore','publicaz','150',null,null,null,'S',{ts '2018-07-17 17:01:54.597'},'assistenza','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fascicolo' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'fascicolo' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fascicolo','publicaz','150',null,null,null,'S',{ts '2018-07-17 17:01:54.597'},'assistenza','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Comune',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity','publicaz','4',null,null,'Comune','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity_ed' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Comune editore',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity_ed' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity_ed','publicaz','4',null,null,'Comune editore','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation_ed' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Nazionalità editore',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation_ed' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation_ed','publicaz','4',null,null,'Nazionalità editore','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation_lang' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Lingua',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation_lang' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation_lang','publicaz','4',null,null,'Lingua','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-02 09:38:36.883'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','publicaz','4',null,null,null,'S',{ts '2021-07-02 09:38:36.883'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpublicaz' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Istituto',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpublicaz' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpublicaz','publicaz','4',null,null,'Codice Istituto','S',{ts '2018-11-21 18:33:45.267'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'isbn' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'ISBN',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'isbn' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('isbn','publicaz','50',null,null,'ISBN','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','publicaz','8',null,null,null,'S',{ts '2018-07-17 17:01:54.600'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','publicaz','64',null,null,null,'S',{ts '2018-07-17 17:01:54.600'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numrivista' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero Rivista',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numrivista' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numrivista','publicaz','4',null,null,'Numero Rivista','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pagestart' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Inizio a pagina',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'pagestart' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pagestart','publicaz','4',null,null,'Inizio a pagina','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pagestop' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'fine a pagina',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'pagestop' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pagestop','publicaz','4',null,null,'fine a pagina','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pagetot' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di pagine',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'pagetot' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pagetot','publicaz','4',null,null,'Numero di pagine','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','publicaz','512',null,null,'Titolo','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title2' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Sottotitolo',kind = 'S',lt = {ts '2018-11-21 18:33:45.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(512)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title2' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title2','publicaz','512',null,null,'Sottotitolo','S',{ts '2018-11-21 18:33:45.267'},'assistenza','N','nvarchar(512)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'volume' AND tablename = 'publicaz')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:01:54.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'volume' AND tablename = 'publicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('volume','publicaz','150',null,null,null,'S',{ts '2018-07-17 17:01:54.600'},'assistenza','N','varchar(150)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

