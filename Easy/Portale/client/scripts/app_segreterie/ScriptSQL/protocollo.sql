
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


-- CREAZIONE TABELLA protocollo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[protocollo] (
protnumero int NOT NULL,
protanno int NOT NULL,
annullato char(1) NOT NULL,
codiceammipa varchar(50) NOT NULL,
codiceregistro varchar(1024) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
dataannullamento datetime NULL,
idaoo int NOT NULL,
idreg_origine int NULL,
lt datetime NULL,
lu varchar(64) NULL,
oggetto varchar(1024) NOT NULL,
originecodiceaoo varchar(50) NULL,
origineidamm varchar(50) NULL,
originemail varchar(512) NULL,
protdata date NOT NULL,
testo varchar(max) NULL,
 CONSTRAINT xpkprotocollo PRIMARY KEY (protnumero,
protanno
)
)
END
GO

-- VERIFICA STRUTTURA protocollo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'protnumero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD protnumero int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'protnumero' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'protanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD protanno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'protanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'annullato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD annullato char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'annullato' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN annullato char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'codiceammipa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD codiceammipa varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'codiceammipa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN codiceammipa varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'codiceregistro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD codiceregistro varchar(1024) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'codiceregistro' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN codiceregistro varchar(1024) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'dataannullamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD dataannullamento datetime NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN dataannullamento datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'idaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD idaoo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'idaoo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN idaoo int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'idreg_origine' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD idreg_origine int NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN idreg_origine int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'oggetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD oggetto varchar(1024) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'oggetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN oggetto varchar(1024) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'originecodiceaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD originecodiceaoo varchar(50) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN originecodiceaoo varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'origineidamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD origineidamm varchar(50) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN origineidamm varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'originemail' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD originemail varchar(512) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN originemail varchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'protdata' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD protdata date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollo') and col.name = 'protdata' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN protdata date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollo' and C.name = 'testo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollo] ADD testo varchar(max) NULL 
END
ELSE
	ALTER TABLE [protocollo] ALTER COLUMN testo varchar(max) NULL
GO

-- VERIFICA DI protocollo IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'protocollo'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollo','int','ASSISTENZA','protanno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollo','int','ASSISTENZA','protnumero','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollo','char(1)','ASSISTENZA','annullato','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollo','varchar(50)','ASSISTENZA','codiceammipa','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollo','varchar(1024)','ASSISTENZA','codiceregistro','1024','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollo','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollo','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollo','datetime','ASSISTENZA','dataannullamento','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollo','int','ASSISTENZA','idaoo','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollo','int','ASSISTENZA','idreg_origine','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollo','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollo','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollo','varchar(1024)','ASSISTENZA','oggetto','1024','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollo','varchar(50)','ASSISTENZA','originecodiceaoo','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollo','varchar(50)','ASSISTENZA','origineidamm','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollo','varchar(512)','ASSISTENZA','originemail','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollo','date','ASSISTENZA','protdata','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollo','varchar(max)','ASSISTENZA','testo','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI protocollo IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'protocollo')
UPDATE customobject set isreal = 'S' where objectname = 'protocollo'
ELSE
INSERT INTO customobject (objectname, isreal) values('protocollo', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'protocollo')
UPDATE [tabledescr] SET description = '2.6.12 Registrazione di protocollo e Segnatura',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-22 10:31:23.380'},lu = 'assistenza',title = 'Registrazione di protocollo e Segnatura' WHERE tablename = 'protocollo'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('protocollo','2.6.12 Registrazione di protocollo e Segnatura','3','S',{ts '2021-02-22 10:31:23.380'},'assistenza','Registrazione di protocollo e Segnatura')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'annullato' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-27 10:44:30.100'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'annullato' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annullato','protocollo','1',null,null,null,'S',{ts '2020-03-27 10:44:30.100'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceammipa' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice IPA dell''Istituto',kind = 'S',lt = {ts '2020-03-27 10:42:43.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceammipa' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceammipa','protocollo','50',null,null,'Codice IPA dell''Istituto','S',{ts '2020-03-27 10:42:43.043'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceregistro' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Codice Registro (univoco nell''Istituto)',kind = 'S',lt = {ts '2020-09-16 10:31:03.503'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceregistro' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceregistro','protocollo','1024',null,null,'Codice Registro (univoco nell''Istituto)','S',{ts '2020-09-16 10:31:03.503'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:05:35.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','protocollo','8',null,null,null,'S',{ts '2018-07-18 16:05:35.833'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:05:35.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','protocollo','64',null,null,null,'S',{ts '2018-07-18 16:05:35.833'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'dataannullamento' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di annullamento',kind = 'S',lt = {ts '2020-09-16 10:31:15.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'dataannullamento' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('dataannullamento','protocollo','8',null,null,'Data di annullamento','S',{ts '2020-09-16 10:31:15.303'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaoo' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Area organizzativa omogenea',kind = 'S',lt = {ts '2020-03-27 10:42:43.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaoo' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaoo','protocollo','4',null,null,'Area organizzativa omogenea','S',{ts '2020-03-27 10:42:43.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_origine' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Mittente',kind = 'S',lt = {ts '2020-03-27 10:42:43.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_origine' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_origine','protocollo','4',null,null,'Mittente','S',{ts '2020-03-27 10:42:43.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:05:35.837'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','protocollo','8',null,null,null,'S',{ts '2018-07-18 16:05:35.837'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:05:35.837'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','protocollo','64',null,null,null,'S',{ts '2018-07-18 16:05:35.837'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oggetto' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Oggetto del documento',kind = 'S',lt = {ts '2020-03-27 10:54:48.823'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'oggetto' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oggetto','protocollo','1024',null,null,'Oggetto del documento','S',{ts '2020-03-27 10:54:48.823'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'originecodiceaoo' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Amministrazione pubblica mittente - Codice IPA area organizzativa omogenea',kind = 'S',lt = {ts '2020-03-27 11:02:51.807'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'originecodiceaoo' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('originecodiceaoo','protocollo','50',null,null,'Amministrazione pubblica mittente - Codice IPA area organizzativa omogenea','S',{ts '2020-03-27 11:02:51.807'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'origineidamm' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Amministrazione pubblica mittente - Codice IPA',kind = 'S',lt = {ts '2020-03-27 11:02:51.807'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'origineidamm' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('origineidamm','protocollo','50',null,null,'Amministrazione pubblica mittente - Codice IPA','S',{ts '2020-03-27 11:02:51.807'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'originemail' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'E-mail mittente',kind = 'S',lt = {ts '2020-03-27 10:54:48.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'originemail' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('originemail','protocollo','512',null,null,'E-mail mittente','S',{ts '2020-03-27 10:54:48.827'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protanno' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di protocollo',kind = 'S',lt = {ts '2020-03-27 10:54:48.827'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protanno' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protanno','protocollo','4',null,null,'Anno di protocollo','S',{ts '2020-03-27 10:54:48.827'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protdata' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di protocollo',kind = 'S',lt = {ts '2020-03-27 10:54:48.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'protdata' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protdata','protocollo','3',null,null,'Data di protocollo','S',{ts '2020-03-27 10:54:48.827'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protnumero' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di protocollo',kind = 'S',lt = {ts '2020-03-27 10:44:28.387'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protnumero' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protnumero','protocollo','4',null,null,'Numero di protocollo','S',{ts '2020-03-27 10:44:28.387'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'testo' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Testo del documento (alternativamente al descrittore del documento)',kind = 'S',lt = {ts '2020-09-16 10:31:03.503'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'testo' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('testo','protocollo','-1',null,null,'Testo del documento (alternativamente al descrittore del documento)','S',{ts '2020-09-16 10:31:03.503'},'assistenza','N','varchar(max)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

